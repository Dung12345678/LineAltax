using BMS.Business;
using BMS.Model;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using BMS.Utils;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace BMS
{
	public partial class frmProductCheckHistory1 : _Forms
	{
		public delegate void SLCanMo(double value, int Row, string Column);

		int FocusbtnSave = 0;
		public long _WorkerID = 0;
		DataTable dtCD;
		string _order = "";
		int RowCanNew = 9999;
		int sortOrder4 = 999999;
		int focus = 0;
		string _AritelID = "";
		string _productCode = "";
		string _tienTo = "";
		int RowCan = 99999;
		string CDOld = "";
		string _stt = "";
		List<string> _lstCD = new List<string>();
		int _workingStepID = 9999;
		int _RowMotor = 999;
		int _stepIndex = 0;
		Color _colorEmpty;
		string _GroupCode;
		int _productID = 0;
		int oldHeight = 0;
		int oldHeightGrid = 0;
		int _RowPin = 999;
		int _RowPinSL = 999;
		int _PlanID = 9999;
		int rowOld = 9999;
		bool _Print = false;
		//Danh sách dòng #1#
		List<int> _lst = new List<int>();
		//Danh sách dong #4#
		List<int> _lst4 = new List<int>();
		//DateTime _sTimeDelay;
		List<string> _lstMotor = new List<string>();
		//Thread _threadDelay;
		Thread _threadRisk;
		Thread _threadFreeze;
		Thread _threadCheckColorCD;
		Thread _threadResetSocket;
		Thread _threadGetAndonDetailsByCD;
		private Thread _threadLoadAndon;
		Thread _threadTakeTime;
		Thread _StartThreadFreeze;
		string _ProductCode = "";

		string _stepCode = "";
		string _socketIPAddress = "192.168.1.46";
		int _socketPort = 3000;
		Socket _socket;
		ASCIIEncoding _encoding = new ASCIIEncoding();

		string Sub = "";
		int _taktTime = 10;
		string _step;
		int andonActive = 0;
		int _currentStatus = 999;
		bool _enable = true;
		int _focusColumns = 0;
		int row = 9999;// Hiển thị dòng trong grid dag focus
		int column = 9999;// hiển thị cột trong grid đag focus
		DataTable _DataShipTo = new DataTable();
		frmPrint _frm;

		string pathSub = Application.StartupPath + "/Sub.txt";
		int _PeriodTime = 0;
		string CD = "";
		int _status = 0;
		bool _isStart = false;
		bool _isLogin = false;
		DateTime _startMakeTime;
		DateTime _endMakeTime;

		DateTime _sTimeRisk;
		DateTime _eTimeRisk;
		DataTable _dtData = new DataTable();
		AndonModel _oAndonModel = new AndonModel();
		ProductionPlanModel _Planmodel = new ProductionPlanModel();

		private string _pathFileBanDo = Path.Combine(Application.StartupPath, "BanDo.txt");
		string _pathFileConfigUpdate = Path.Combine(Application.StartupPath, "ConfigUpdate.txt");
		string _pathFolderUpdate = "";
		string _pathUpdateServer = "";
		string _pathFileVersion = "";
		string _pathError = Path.Combine(Application.StartupPath, "Errors");

		public frmProductCheckHistory1()
		{
			InitializeComponent();
			//event Khi focus vào textbox
			//btnFocus.GotFocus += GotFocusButton;
			if (!File.Exists(pathSub))
			{
				File.WriteAllText(pathSub, "0");
			}
		}
		private void frmProductCheckHistory1_Load(object sender, EventArgs e)
		{
			string version = File.ReadAllText(Application.StartupPath + "/Version.txt");
			this.Text += "  -  Version: " + version;
			Sub = File.ReadAllText(Application.StartupPath + "/Sub.txt");
			cboSub.SelectedIndex = TextUtils.ToInt(Sub);
			if (File.Exists(Application.StartupPath + "/CD.txt"))
			{
				CD = File.ReadAllText(Application.StartupPath + "/CD.txt");
				if (CD.Trim() != "")
				{
					btnNotUseCD8.Visible = true;
				}
				lblCD.Text = CD.Trim();
			}
			//Show frmPrint
			if (CD.Trim() == "CD11")
			{
				_frm = new frmPrint();
				_frm.ShowInTaskbar = false;
				_frm.Show();
			}
			DocUtils.InitFTPQLSX();
			//Check update version
			updateVersion();
			txtQRCode.Focus();
			_oAndonModel = new AndonModel();
			// kết nối với AnDon
			ConnectAnDon();
			sendDataTCP("11", "10");
			ToolTip toolTip1 = new ToolTip();
			toolTip1.ShowAlways = true;
			toolTip1.SetToolTip(this.btnSave, "F12");
			LoadConfigShipTo();

			//andonActive = TextUtils.ToInt(TextUtils.ExcuteScalar($"select top 1 KeyValue from ConfigSystem where KeyName = 'IsAndonActiveHyp'"));
			//andonActive = 1;
			//if (andonActive == 0) return;

			_colorEmpty = Color.FromArgb(255, 192, 255);
			initBackColor();
			oldHeight = this.Height;
			oldHeightGrid = grdData.Height;

			//Thread hiển thị giá trị delay
			_threadGetAndonDetailsByCD = new Thread(new ThreadStart(threadShowAndonDetails));
			_threadGetAndonDetailsByCD.IsBackground = true;
			_threadGetAndonDetailsByCD.Start();

			// Chạy thread load Andon theo thời gian hiện tại
			_threadLoadAndon = new Thread(new ThreadStart(threadLoadAndon));
			_threadLoadAndon.IsBackground = true;
			_threadLoadAndon.Start();
			//Đóng băng
			StartThreadFreeze();
			//startThreadFreeze();
			//Hiển thị màu
			startThreadCheckColorCD();
			//Kết nối Socket
			startThreadResetSocket();

			//Nhận giá trị TaktTime
			_threadTakeTime = new Thread(new ThreadStart(TakeTime));
			_threadTakeTime.IsBackground = true;
			_threadTakeTime.Start();
		}
		void StartThreadFreeze()
		{
			_StartThreadFreeze = new Thread(checkFreezeAll);
			_StartThreadFreeze.IsBackground = true;
			_StartThreadFreeze.Start();
		}
		//void GotFocusButton(object sender, EventArgs e)
		//{
		//	focus = 1;
		//}
		void checkFreezeAll()
		{
			while (true)
			{
				Thread.Sleep(500);
				try
				{
					this.Invoke((MethodInvoker)delegate
					{
						if (cboSub.SelectedIndex != 0) return;


						if (cboWorkingStep.Text.Trim() != "")
							_stepCode = cboWorkingStep.Text.ToString().Trim();
						else
						{
							_stepCode = CD;
						}

						if (_stepCode == "") return;
						if (_stepCode == "CD8-1") _stepCode = "CD81";

						DataTable dt = TextUtils.Select("select top 1 * from StatusColorCD");
						if (dt.Rows.Count == 0) return;
						//Hiển thị số màu trong bảng StatusColorCD
						if (_stepCode.Contains("CD"))
							_currentStatus = TextUtils.ToInt(dt.Rows[0][_stepCode]);
						// Mở khóa CD
						if (_currentStatus != 4)
						{
							_enable = true;
							this.Invoke((MethodInvoker)delegate
							{
								if (btnNotUseCD8.Text == "Không sử dụng")
									panelTop.Enabled = pannelBot.Enabled = grdData.Enabled = _enable;
								if (_focusColumns == 1)
								{
									if (FocusbtnSave == 0)
									{
										//focus vào ô của cột tiếp theo
										setFocusCell(row, column);
									}
									else
									{
										btnSave.Focus();
									}
									if (txtQRCode.Text.Trim() == "")
									{
										txtQRCode.Focus();
									}

									_focusColumns = 0;
								}
							});
						}
						// Đóng khóa CD
						if (_currentStatus == 4)
						{
							_enable = false;
							_focusColumns = 1;
							this.Invoke((MethodInvoker)delegate
							{
								if (btnNotUseCD8.Text == "Không sử dụng")
									panelTop.Enabled = pannelBot.Enabled = grdData.Enabled = _enable;
							});
						}
					});

				}
				catch (Exception)
				{
				}
			}
		}
		void TakeTime()
		{
			ASCIIEncoding encoding = new ASCIIEncoding();

			while (true)
			{
				Thread.Sleep(100);
				try
				{
					string value = "";
					//Nhận giá trị TaktTime
					if (_socket != null && _socket.Connected)
					{
						try
						{
							byte[] buffer = new byte[500];
							_socket.Receive(buffer);
							value = encoding.GetString(buffer).Replace("\0", "").Trim();

						}
						catch (Exception ex)
						{
							ConnectAnDon();
						}
					}
					else
					{
						ConnectAnDon();
					}
					if (value == "")
					{
						continue;
					}
					this.Invoke((MethodInvoker)delegate
					{
						lblTakt.Text = value.Trim();
						if (lblTakt.Text == TextUtils.ToString(_taktTime - 1))
						{
							_startMakeTime = DateTime.Now;
							_PeriodTime = 0;
						}
						if (TextUtils.ToInt(lblTakt.Text) < 0)
						{
							_PeriodTime = TextUtils.ToInt(value.Trim()) * -1;
						}
					});
				}
				catch
				{

				}
			}
		}
		void ConnectAnDon()
		{
			try
			{
				//Load ra config trong database lấy takt time, địa chỉ tcp, port
				DataTable dtConfig = TextUtils.Select("SELECT TOP 1 * FROM dbo.AndonConfig with (nolock)");
				_socketIPAddress = TextUtils.ToString(dtConfig.Rows[0]["TcpIp"]);
				//_socketPort = TextUtils.ToInt(dtConfig.Rows[0]["SocketPort"]);

				IPAddress ipAddOut = IPAddress.Parse(_socketIPAddress);
				IPEndPoint endPoint = new IPEndPoint(ipAddOut, _socketPort);
				_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				_socket.Connect(endPoint);
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Can't connect to Andon!");
				_socket = null;
			}
		}
		void updateVersion()
		{
			if (!File.Exists(_pathFileConfigUpdate)) return;
			try
			{
				string[] lines = File.ReadAllLines(_pathFileConfigUpdate);
				if (lines == null) return;
				if (lines.Length < 2) return;
				string[] stringSeparators = new string[] { "||" };
				string[] arr = lines[1].Split(stringSeparators, 4, StringSplitOptions.RemoveEmptyEntries);

				if (arr == null) return;
				if (arr.Length < 4) return;
				_pathFolderUpdate = Path.Combine(Application.StartupPath, arr[1].Trim());
				_pathUpdateServer = arr[2].Trim();
				_pathFileVersion = Path.Combine(Application.StartupPath, arr[3].Trim());

				if (!Directory.Exists(_pathError))
				{
					Directory.CreateDirectory(_pathError);
				}
				if (!Directory.Exists(_pathFolderUpdate))
				{
					Directory.CreateDirectory(_pathFolderUpdate);
				}
				if (!File.Exists(_pathFileVersion))
				{
					File.Create(_pathFileVersion);
					File.WriteAllText(_pathFileVersion, "1");
				}
				int currentVerion = TextUtils.ToInt(File.ReadAllText(_pathFileVersion).Trim());
				string[] listFileSv = DocUtils.GetFilesList(_pathUpdateServer);
				if (listFileSv == null) return;
				if (listFileSv.Length == 0) return;

				List<string> lst = listFileSv.ToList();
				lst = lst.Where(o => o.Contains(".zip")).ToList();
				int newVersion = lst.Max(o => TextUtils.ToInt(Path.GetFileNameWithoutExtension(o)));

				if (newVersion != currentVerion)
				{
					Process.Start(Path.Combine(Application.StartupPath, "UpdateVersion.exe"));
				}
			}
			catch
			{
				MessageBox.Show("Can't connect to server!");
				return;
			}
		}
		void checkColorCD()
		{
			while (true)
			{
				Thread.Sleep(100);
				try
				{
					this.Invoke((MethodInvoker)delegate
					{
						if (cboSub.SelectedIndex != 0) return;

						DataTable dt = TextUtils.Select("select top 1 * from StatusColorCD with (nolock)");
						if (dt.Rows.Count == 0) return;
						string step = "";
						this.Invoke((MethodInvoker)delegate
						{
							if (cboWorkingStep.Text.Trim() != "")
								step = cboWorkingStep.Text.Trim();
							else
								step = CD.Trim();
							if (step == "CD8-1")
							{
								step = "CD81";
							}
						});
						_status = TextUtils.ToInt(dt.Rows[0][step]);

						//Control control = pannelBot.Controls.Find("lblCD", true)[0];
						switch (_status)
						{
							case 1:
								lblCD.BackColor = Color.White;

								break;
							case 2:
								lblCD.BackColor = Color.Yellow;
								break;
							case 3:
								lblCD.BackColor = Color.Red;
								break;
							case 4:
								lblCD.BackColor = Color.Lime;
								break;
							case 5:
								lblCD.BackColor = Color.FromArgb(192, 192, 255);
								break;
							case 6:
								lblCD.BackColor = Color.FromArgb(255, 192, 128);
								break;
							default:
								break;
						}
					});
				}
				catch (Exception)
				{

				}
			}
		}
		void startThreadFreeze()
		{
			_threadFreeze = new Thread(checkFreeze);
			_threadFreeze.IsBackground = true;
			_threadFreeze.Start();
		}
		void threadShowAndonDetails()
		{
			while (true)
			{
				Thread.Sleep(1000);
				if (string.IsNullOrWhiteSpace(_step)) continue;
				try
				{
					DataSet dts = TextUtils.GetListDataFromSP("spGetAndonDetailsByCD", "AnDonDetails"
						   , new string[1] { "@CD" }
						   , new object[1] { _step });
					DataTable data = dts.Tables[0];

					this.Invoke((MethodInvoker)delegate
					{
						txtNumDelay.Text = TextUtils.ToString(data.Rows[0]["TotalDelayNum"]);
						txtTimeDelay.Text = TextUtils.ToString(data.Rows[0]["TotalDelayTime"]);
					});
				}
				catch (Exception ex)
				{
					File.AppendAllText(_pathError + "/Error_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt",
							 DateTime.Now.ToString("HH:mm:ss") + ":threadShowAndonDetails(): " + ex.ToString() + Environment.NewLine);
				}
			}
		}
		void threadLoadAndon()
		{
			while (true)
			{
				Thread.Sleep(500);
				try
				{
					// Store load Andon theo ngày giờ hiện tại
					ArrayList arr = AndonBO.Instance.GetListObject("spGetAndonByDateTimeNow", new string[] { }, new object[] { });
					if (arr.Count > 0)
					{
						_oAndonModel = (AndonModel)arr[0];
						_taktTime = _oAndonModel.Takt;
					}
					else
					{
						_isStart = false;
						_oAndonModel = new AndonModel();
					}
				}
				catch (Exception ex)
				{
					_oAndonModel = new AndonModel();

					File.AppendAllText(_pathError + "/Error_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt",
						DateTime.Now.ToString("HH:mm:ss") + ":LoadAndon(): " + ex.ToString() + Environment.NewLine);
				}
			}
		}
		void startThreadResetSocket()
		{
			_threadResetSocket = new Thread(resetSocket);
			_threadResetSocket.IsBackground = true;
			_threadResetSocket.Start();
		}
		void startThreadCheckColorCD()
		{
			_threadCheckColorCD = new Thread(checkColorCD);
			_threadCheckColorCD.IsBackground = true;
			_threadCheckColorCD.Start();
		}
		void resetSocket()
		{
			while (true)
			{
				Thread.Sleep(1000);

				if (_socket == null)
				{
					try
					{
						IPAddress ipAddOut = IPAddress.Parse(_socketIPAddress);
						IPEndPoint endPoint = new IPEndPoint(ipAddOut, _socketPort);
						_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
						_socket.Connect(endPoint);
					}
					catch
					{
						_socket = null;
					}
				}
			}
		}

		/// <summary>
		/// Kiểm tra xem có công đoạn khác nào bị delay, và công đoạn này ko bị delay
		/// Thì sẽ đóng băng form lại ko cho thao tác
		/// </summary>
		/// 
		void checkFreeze()
		{
			while (true)
			{
				Thread.Sleep(1000);
				try
				{

					if (_oAndonModel == null || _isLogin)
					{
						this.Invoke((MethodInvoker)delegate
						{
							textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = true;
						});
						continue;
					}

					string stepCode = "";
					bool enable = true;
					this.Invoke((MethodInvoker)delegate
					{
						stepCode = cboWorkingStep.Text.ToString().Trim();
					});

					if (stepCode == "") continue;
					if (stepCode == "CD8-1") stepCode = "CD81";

					DataTable dt = TextUtils.Select("select top 1 * from StatusColorCD");
					if (dt.Rows.Count == 0) continue;
					int currentStatus = TextUtils.ToInt(dt.Rows[0][stepCode]);
					if (currentStatus == 2)
					{
						this.Invoke((MethodInvoker)delegate
						{
							textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = enable;
						});
						continue;
					}

					for (int i = 1; i <= 10; i++)
					{
						string step = "";
						int status = 0;
						if (i == 10)
						{
							step = "CD81";
							status = TextUtils.ToInt(dt.Rows[0]["CD81"]);
							step = "CD8-1";
						}
						else
						{
							step = "CD" + i;
							status = TextUtils.ToInt(dt.Rows[0][step]);
						}

						if (step == stepCode) continue;

						if (status == 2)
						{
							enable = false;
							//textBox7.Focus();
							break;
						}
					}

					this.Invoke((MethodInvoker)delegate
					{
						textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = enable;
					});
				}
				catch (Exception)
				{
				}
			}
		}

		/// <summary>
		/// Gửi thông điệp lên andon
		/// </summary>
		/// <param name="value">Giá trị, trạng thái</param>
		/// <param name="type">1:sự cố, 2: đã hoàn thành, 3: cập nhật SL thực tế, 4: khởi động ca</param>
		void sendDataTCP(string value, string type)
		{
			try
			{
				//Gửi tín hiệu delay xuống server Andon qua TCP/IP
				if (_socket != null && _socket.Connected)
				{
					this.Invoke((MethodInvoker)delegate
					{
						if (cboSub.SelectedIndex != 0) return;
						string sendData;
						if (cboWorkingStep.Text.Trim() != "")
						{
							sendData = string.Format("{0};{1};{2}", cboWorkingStep.Text.Trim(), value, type);
						}
						else
							sendData = string.Format("{0};{1};{2}", CD, value, type);
						byte[] data = _encoding.GetBytes(sendData);
						_socket.Send(data);
					});
				}
			}
			catch (Exception ex)
			{
				//Ghi log vào 
				_socket = null;
			}
		}

		/// <summary>
		/// Set focus vào cell trên grid
		/// </summary>
		/// <param name="indexRow"></param>
		/// <param name="indexColum"></param>
		/// 
		void resetControl()
		{
			/*
             * reset lại tiêu đề cột, các kết quả check
             */
			for (int i = 3; i < 9; i++)
			{
				grvData.Columns["RealValue" + (i - 2)].Caption = "#";

				Control control = pannelBot.Controls.Find("textbox" + (i - 2), false)[0];
				control.Text = "";
			}
		}

		void initBackColor()
		{
			if (cboWorkingStep.SelectedIndex > 0)
			{
				cboWorkingStep.BackColor = Color.White;
			}
			else
			{
				cboWorkingStep.BackColor = _colorEmpty;
			}

			if (string.IsNullOrWhiteSpace(txtQRCode.Text))
			{
				txtQRCode.BackColor = _colorEmpty;
			}
			else
			{
				txtQRCode.BackColor = Color.White;
			}

			if (string.IsNullOrWhiteSpace(txtWorker.Text))
			{
				txtWorker.BackColor = _colorEmpty;
			}
			else
			{
				txtWorker.BackColor = Color.White;
			}

			if (string.IsNullOrWhiteSpace(txtOrder.Text))
			{
				txtOrder.BackColor = _colorEmpty;
			}
			else
			{
				txtOrder.BackColor = Color.White;
			}
		}

		void loadComboStep(string productCode)
		{
			dtCD = TextUtils.LoadDataFromSP("spGetProductStep_ByProductCode", "A"
			   , new string[1] { "@ProductCode" }
			   , new object[1] { productCode });
			DataRow dr = dtCD.NewRow();
			dr["ID"] = 0;
			dr["ProductStepCode"] = "";
			dtCD.Rows.InsertAt(dr, 0);
			_ProductCode = productCode;
			cboWorkingStep.DataSource = dtCD;
			cboWorkingStep.DisplayMember = "ProductStepCode";
			cboWorkingStep.ValueMember = "ID";

			if (_stepIndex > 0 && _stepIndex < dtCD.Rows.Count)
			{
				cboWorkingStep.SelectedIndex = _stepIndex;
			}
		}

		/// <summary>
		/// Load danh sách công đoạn kiểm tra
		/// </summary>
		void loadDataWorkingStep()
		{
			if (!string.IsNullOrWhiteSpace(txtQRCode.Text.Trim()))
			{
				string orderCode = txtQRCode.Text.Trim();
				string[] arr = orderCode.Split(' ');
				if (arr.Length > 1)
				{
					loadComboStep(arr[1]);
				}
				else
				{
					cboWorkingStep.DataSource = null;
				}
			}
			else
			{
				cboWorkingStep.DataSource = null;
			}
		}

		int getSumHeightRows()
		{
			int total = 0;
			GridViewInfo vi = grvData.GetViewInfo() as GridViewInfo;
			for (int i = 0; i < grvData.RowCount; i++)
			{
				GridRowInfo ri = vi.RowsInfo.FindRow(i);
				if (ri != null)
					total += ri.Bounds.Height;
			}

			return total;
		}

		int getRowIndex(int columnIndex)
		{
			int rowIndex = -1;
			for (int i = 0; i < _dtData.Rows.Count; i++)
			{
				DataRow r = _dtData.Rows[i];
				string value = TextUtils.ToString(r["RealValue" + (columnIndex - 2)]);
				int type = TextUtils.ToInt(r["ValueType"]);
				int checkValueType = TextUtils.ToInt(r["CheckValueType"]);
				string standardValue = TextUtils.ToString(r["StandardValue"]);

				if (_lst4.Contains(i))
				{
					for (int j = 1; j <= 6; j++)
					{
						string nameCol = "RealValue" + $"{j}";
						value = TextUtils.ToString(grvData.GetRowCellValue(i, nameCol));
						if (value != "")
							break;
					}
					if (!string.IsNullOrWhiteSpace(value))
						continue;
				}

				// Nếu có giá trị thì sẽ bỏ qua 
				if ((string.IsNullOrWhiteSpace(value) && type > 0) || (checkValueType == 2 && string.IsNullOrWhiteSpace(value)
					&& !string.IsNullOrWhiteSpace(standardValue)))
				{
					rowIndex = i;
					break;
				}
			}
			if (rowIndex == -1)
			{
				rowIndex = grvData.RowCount + 1;
			}
			return rowIndex;
		}

		void setFocusCell(int indexRow, int indexColum)
		{
			if (cboWorkingStep.Text.Trim() != "")
				_stepCode = cboWorkingStep.Text.ToString().Trim();
			else _stepCode = CD;
			if (_stepCode == "CD8-1") _stepCode = "CD81";
			row = indexRow;
			column = indexColum;
			if (indexRow <= grvData.RowCount - 1)
			{
				grvData.FocusedRowHandle = indexRow;

				grvData.FocusedColumn = grvData.VisibleColumns[indexColum];

				grvData.ShowEditor();
			}
			else
			{
				try
				{
					(pannelBot.Controls.Find("textBox" + (indexColum - 2), true)[0]).Focus();
				}
				catch
				{

				}
			}
		}

		int getNextIndex(int index)
		{
			int valueIndex = grvData.RowCount;
			for (int i = index + 1; i < grvData.RowCount; i++)
			{
				string value = "";
				for (int j = 1; j < 6; j++)
				{
					string nameCol = "RealValue" + $"{j}";
					value = TextUtils.ToString(grvData.GetRowCellValue(i, nameCol));
					if (value != "")
						break;
				}
				//#1# && #4#
				if ((_lst.Contains(i) || _lst4.Contains(i)) && (!string.IsNullOrWhiteSpace(value)))
				{
					continue;
				}

				int valueType = TextUtils.ToInt(grvData.GetRowCellValue(i, colValueType));
				//_SortOrderValue = TextUtils.ToInt(grvData.GetRowCellValue(i, colSortOrder));
				//if (_SortOrderValue == _SortOrder1)
				//	valueType = 0;
				if (valueType == 1)//Kiểu giá trị
				{
					valueIndex = i;
					break;
				}
			}

			return valueIndex;
		}

		/// <summary>
		/// Set caption cho các cột nhập giá trị kiểm tra
		/// Cái này làm cho dự án thêm hạng mục kiểm tra order sản phẩm
		/// </summary>
		void setCaptionGridColumn()
		{
			for (int i = 0; i < 6; i++)
			{
				if (_stt.Length > (int.Parse(_stt) + i).ToString().Length)
				{
					int lech = _stt.Length - (int.Parse(_stt) + i).ToString().Length;
					StringBuilder sokhong = new StringBuilder();
					for (int j = 0; j < lech; j++)
					{
						sokhong.Append("0");
					}

					grvData.Columns["RealValue" + (i + 1)].Caption = sokhong + (int.Parse(_stt) + i).ToString();
				}
				else
				{
					grvData.Columns["RealValue" + (i + 1)].Caption = (int.Parse(_stt) + i).ToString();

				}
			}
		}

		bool _isStartColor = false;
		//bool _isStart = false;
		private void cboWorkingStep_SelectedIndexChanged(object sender, EventArgs e)
		{
			Reset();
			//Stopwatch s = new Stopwatch();
			//s.Start();
			if (cboWorkingStep.Text.Trim() == "CD11")
			{
				btnSave.Visible = false;
			}
			loadGridData();
			//Check bỏ qua công đoạn
			if (CheckSkipCD(0, 0) == false)
			{
				MessageBox.Show($"Sản phẩm chưa đi qua công đoạn {CDOld}");
			}
		}
		bool CheckSkipCD(int TextOrCb, int columnIndex)
		{
			//Check bỏ qua công đoạn
			if (!cboWorkingStep.Text.Contains("TP"))
			{
				for (int i = cboWorkingStep.SelectedIndex - 1; i > 0; i--)
				{
					if (dtCD == null) return false;
					if (dtCD.Rows.Count <= 0) return false;
					CDOld = TextUtils.ToString(dtCD.Rows[i]["ProductStepCode"]);
					//Check có trong database chưa 
					if (_lstCD.Contains(CDOld))
					{
						continue;
					}
					else
					{
						if (cboWorkingStep.Text.Trim() != TextUtils.ToString(dtCD.Rows[1]["ProductStepCode"]))
						{
							int check = 0;
							if (TextOrCb == 0)
							{
								check = TextUtils.ToInt(TextUtils.ExcuteScalar($"SELECT TOP 1 1 FROM [SumitomoTest].[dbo].[AndonDetail]  WHERE ProductStepCode='{CDOld}' AND QrCode='{txtQRCode.Text.Trim()}' AND OrderCode='{txtOrder.Text.Trim()}'"));
							}
							else
							{
								check = TextUtils.ToInt(TextUtils.ExcuteScalar($"SELECT TOP 1 1 FROM [SumitomoTest].[dbo].[AndonDetail]  WHERE ProductStepCode='{CDOld}' AND QrCode='{_tienTo + grvData.Columns[columnIndex].Caption + " " + _productCode}' AND OrderCode='{txtOrder.Text.Trim()}'"));
							}
							if (check == 0)
							{
								return false;
							}
							return true;

						}
					}

				}
			}
			return true;

		}
		void Reset()
		{
			RowCan = 9999;
			_RowMotor = 999;
			_RowPin = 999;
			_RowPinSL = 999;
			_AritelID = "";
			_lst.Clear();
			_lst4.Clear();
			_lstMotor.Clear();
		}
		void loadGridData()
		{
			if (string.IsNullOrEmpty(txtWorker.Text.Trim()) && cboWorkingStep.SelectedIndex != 0)
			{
				MessageBox.Show("Bạn chưa nhập tên người làm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWorker.Focus();
				return;
			}
			if (cboWorkingStep.Text.Trim() != "")
				_step = cboWorkingStep.Text.Trim();
			else _step = CD.Trim();

			if (cboWorkingStep.Text.Trim() == "CD1")
			{
				sendDataTCP("0", "4");
			}
			_isStartColor = false;
			_workingStepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
			string qrCode = txtQRCode.Text.Trim();
			if (string.IsNullOrWhiteSpace(qrCode)) return;

			if (cboWorkingStep.SelectedIndex > 0)
			{
				cboWorkingStep.BackColor = Color.White;
			}
			else
			{
				cboWorkingStep.BackColor = _colorEmpty;
			}

			resetControl();

			if (_workingStepID == 0)
			{
				_dtData = null;
				grdData.DataSource = null;
				txtStepName.Text = "";
				return;
			}

			//Sinh ra file lưu tên công đoạn
			File.WriteAllText(Application.StartupPath + "\\CD.txt", cboWorkingStep.Text.Trim());

			/*
             * Tách chuỗi QrCode
             */
			string orderCode = txtQRCode.Text.Trim();
			string[] arr1 = orderCode.Split(' ');
			if (arr1.Length > 1)
			{
				_order = arr1[0];
				_productCode = arr1[1].Trim();
				string[] arr;
				if (_order.Contains("-"))
				{
					arr = _order.Split('-');
					_tienTo = (arr[0] + "-" + arr[1] + "-");
					_stt = arr[2];
				}
				else
				{
					arr = Regex.Split(_order, @"\D+");
					_stt = arr[arr.Length - 1];
					_tienTo = _order.Substring(0, _order.IndexOf(_stt));
				}
			}

			//Ghi dữ liệu trạng thái vào bảng StatusCD
			string stepCode = cboWorkingStep.Text.Trim();
			//if (stepCode == "CD8-1") stepCode = "CD81";
			//string sqlUpdate = string.Format("Update StatusCD WITH (ROWLOCK) set {0} = 1", stepCode);
			//TextUtils.ExcuteSQL(sqlUpdate);

			//Hiển thị nút không sử dụng khi chọn xong công đoạn
			btnNotUseCD8.Visible = true;

			//Gán dữ liệu vào grid
			DataSet ds = ProductCheckHistoryDetailBO.Instance.GetDataSet("spGetWorkingByProduct",
				new string[] { "@WorkingStepID", "@WorkingStepCode", "@ProductCode" },
				new object[] { _workingStepID, stepCode, arr1[1].ToString() });
			if (ds.Tables.Count == 0) return;
			_dtData = ds.Tables[0];

			txtStepName.Text = TextUtils.ToString(ds.Tables[1].Rows.Count > 0 ? ds.Tables[1].Rows[0][0] : "");

			_GroupCode = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ProductGroupCode"] : "");
			txtName.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ProductName"] : "");
			txtMo.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["LoaiMo"] : "");
			//txtGoal.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["Goal"] : "");
			//Hiển thị Công đoạn bỏ qua của PID 
			string CDSkip = TextUtils.ToString(TextUtils.ExcuteScalar($"SELECT Top 1 CDSkip FROM SkipCD WHERE Product='{TextUtils.ToString(arr1[1])}'"));
			_lstCD = CDSkip.Split(',').ToList();
			string gunNumber = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["GunNumber"] : "");
			string jobNumber = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["JobNumber"] : "");
			string qtyOcBanGa = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["QtyOcBanGa"] : "");
			string qtyOcBanThat = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["QtyOcBanThat"] : "");
			_productID = TextUtils.ToInt(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ID"] : "");
			if (_DataShipTo != null && _DataShipTo.Rows.Count != 0)
			{
				if (_DataShipTo.Select($"ShipTo = '{txtGoal.Text.Trim()}' and IsHidden = 1").Count() > 0)
				{
					if (_dtData != null && _dtData.Rows.Count != 0)
						_dtData = _dtData.Select("SortOrder < 1000").CopyToDataTable();
				}
			}
			grdData.DataSource = _dtData;


			for (int i = 0; i < grvData.RowCount; i++)
			{
				string ProductWorkingName = TextUtils.ToString(grvData.GetRowCellValue(i, colProductWorkingName));
				if (ProductWorkingName.ToUpper().Contains("#5#"))
				{
					//lấy dòng motor
					_RowMotor = i;
					try
					{
						//Check đã có mã Motor chưa
						string Motor = TextUtils.ToString(grvData.GetRowCellValue(_RowMotor, colStandardValue));
						if (Motor.Trim() == "0")
						{
							//Tìm kiếm Mã Motor theo Order trong base ShiStock
							DataTable dt = TextUtils.Select($"SELECT TOP 1 ArticleID FROM [ShiStock].[dbo].[OrderPart] WHERE OrderCodeAndCnt ='{txtOrder.Text.Trim()}' AND Shelf=''");
							if (dt != null && dt.Rows.Count > 0)
							{
								//Hiển thị lên gridview 
								grvData.SetRowCellValue(_RowMotor, colStandardValue, dt.Rows[0]["ArticleID"]);
								//Update vào base 
								TextUtils.ExcuteSQL($"UPDATE dbo.[ProductWorking] SET PeriodValue='{dt.Rows[0]["ArticleID"]}' WHERE ProductID = {_productID} AND ProductStepID={_workingStepID} AND IsDeleted = 0  AND WorkingName LIKE '#5#%'");
							}
						}
					}

					catch (Exception ex)
					{
						TextUtils.errorLog($"Lỗi mã Motor {txtOrder.Text.Trim()}", $"{ex}", "Line Hyp");
					}
				}
				if (ProductWorkingName.ToUpper().Contains("#6#"))
				{
					//dòng cân
					RowCanNew = RowCan = i;
				}
				if (ProductWorkingName.ToUpper().Contains("#7#"))
				{
					try
					{
						_RowPin = i;
						string PinCode = TextUtils.ToString(grvData.GetRowCellValue(_RowPin, colStandardValue));
						if (PinCode == "0")
						{
							DataTable dt = TextUtils.Select($"SELECT TOP 1 ArticleID, Qty FROM [ShiStock].[dbo].[OrderPart] WHERE OrderCodeAndCnt ='{txtOrder.Text.Trim()}' AND Description LIKE '%RING GEAR PIN%'");
							if (dt != null && dt.Rows.Count > 0)
							{
								//Hiển thị lên gridview 
								grvData.SetRowCellValue(_RowPin, colStandardValue, dt.Rows[0]["ArticleID"]);
								//Update vào base 
								TextUtils.ExcuteSQL($"UPDATE dbo.[ProductWorking] SET PeriodValue='{dt.Rows[0]["ArticleID"]}' WHERE ProductID = {_productID} AND ProductStepID={_workingStepID} AND IsDeleted = 0  AND WorkingName LIKE '%#7#%'");
							}
						}
					}
					catch (Exception ex)
					{
						TextUtils.errorLog($"Lỗi mã pin {txtOrder.Text.Trim()}", $"{ex}", "Line Altax");
					}

				}
				decimal SL = 0;
				if (ProductWorkingName.ToUpper().Contains("#8#"))
				{
					try
					{
						_RowPinSL = i;
						int PinCode = TextUtils.ToInt(grvData.GetRowCellValue(_RowPinSL, colStandardValue));
						if (PinCode == 0)
						{
							DataTable dt = TextUtils.Select($"SELECT TOP 1 ArticleID, Qty FROM [ShiStock].[dbo].[OrderPart] WHERE OrderCodeAndCnt ='{txtOrder.Text.Trim()}' AND Description LIKE '%RING GEAR PIN%'");
							if (dt != null && dt.Rows.Count > 0)
							{
								SL = TextUtils.ToDecimal(dt.Rows[0]["Qty"]) / TextUtils.ToDecimal(txtQty.Text.Trim());
								//Hiển thị lên gridview 
								grvData.SetRowCellValue(_RowPinSL, colStandardValue, SL);
								//Update vào base 
								TextUtils.ExcuteSQL($"UPDATE dbo.[ProductWorking] SET PeriodValue='{SL}' WHERE ProductID = {_productID} AND ProductStepID={_workingStepID} AND IsDeleted = 0  AND WorkingName LIKE '%#8#%'");
							}
						}
					}
					catch (Exception ex)
					{
						TextUtils.errorLog($"Lỗi số lượng pin {SL},{txtQty.Text.Trim()}", $"{ex}", "Line Altax");
					}
				}


			}

			string file = string.Format("{0};{1};{2};{3}", gunNumber, jobNumber, qtyOcBanGa, qtyOcBanThat);
			try
			{
				System.IO.File.WriteAllText(Application.StartupPath + "\\SettingsTouque.txt", file);
			}
			catch
			{
			}

			// Set lại chiều cao của dòng
			if (grvData.RowCount > 0)
			{
				grvData.RowHeight = -1;
				int totalHeightRow = this.getSumHeightRows();
				if ((oldHeightGrid - grvData.ColumnPanelRowHeight - 30) > totalHeightRow)
				{
					grvData.RowHeight = (oldHeightGrid - grvData.ColumnPanelRowHeight - 30) / grvData.RowCount;
				}
			}

			//Nhảy đến ô cần điền giá trị đầu tiên
			int cIndex = grvData.Columns["RealValue1"].VisibleIndex;
			setFocusCell(getRowIndex(cIndex), cIndex);

			_isStartColor = true;

			setCaptionGridColumn();


		}
		void LoadConfigShipTo()
		{
			_DataShipTo = TextUtils.Select("select * from ConfigShipTo");
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			if (grvData.RowCount == 0)
			{
				return;
			}

			int productID = _productID;
			int stepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
			if (productID == 0)
			{
				MessageBox.Show(string.Format("Không tồn tại sản phẩm có mã [{0}]!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (stepID == 0)
			{
				MessageBox.Show(string.Format("Bạn chưa chọn công đoạn nào!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(txtWorker.Text.Trim()))
			{
				MessageBox.Show(string.Format("Bạn chưa điền người làm!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWorker.Focus();
				return;
			}
			bool isHasValue = false;
			for (int i = 1; i < 7; i++)
			{
				Control control = pannelBot.Controls.Find("textbox" + i, false)[0];
				if (control.Text == "0" || control.Text == "1")
				{
					isHasValue = true;
					break;
				}
			}
			if (!isHasValue)
			{
				//MessageBox.Show("Bạn chưa nhập các giá trị kiểm tra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DialogResult result = MessageBox.Show("Bạn có chắc muốn cất dữ liệu?", "Cất?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.No) return;

			int count = _dtData.Rows.Count;
			//TimeSpan b = new TimeSpan();
			//Stopwatch stopwatch = new Stopwatch();
			//stopwatch.Start();

			for (int i = 3; i < 9; i++)
			{
				Control control = pannelBot.Controls.Find("textbox" + (i - 2), false)[0];
				string columnCaption = grvData.Columns[i].Caption;
				string qrCode = "";
				if (string.IsNullOrEmpty(control.Text.Trim()))
					continue;
				else
				{
					qrCode = _tienTo + columnCaption + " " + _productCode;
				}
				if (string.IsNullOrWhiteSpace(control.Text.Trim()) || TextUtils.ToInt(control.Text.Trim()) > 1
					|| TextUtils.ToInt(control.Text.Trim()) < 0)
				{
					continue;
				}
				string orderCode = string.IsNullOrWhiteSpace(txtOrder.Text.Trim()) ?
						(_tienTo.Contains("-") ? _tienTo.Substring(0, _tienTo.Length - 1) : _order) :
						txtOrder.Text.Trim();

				/*
                 * Xóa các giá trị đã lưu cũ
                 */
				// ProductCheckHistoryDetailBO.Instance.DeleteByExpression(new Utils.Expression("QRCode", qrCode).And(new Utils.Expression("ProductStepID", stepID)));

				/*
                 * Insert Master
                 */
				if (cboWorkingStep.Text.ToUpper() == "CD7" || cboWorkingStep.Text.ToUpper().StartsWith("TP-"))
				{
					ProductCheckHistoryModel master = new ProductCheckHistoryModel();
					master.CreatedBy = txtWorker.Text.Trim();
					master.CreatedDate = DateTime.Now;
					master.DateLR = DateTime.Now;
					master.OrderCode = orderCode;
					master.ProductCode = _productCode;
					master.ProductID = productID;
					master.QRCode = qrCode;
					master.UpdatedBy = txtWorker.Text.Trim();
					master.UpdatedDate = DateTime.Now;
					master.SalesOrder = txtSalesOrder.Text.Trim();
					Expression exp2 = new Expression("QRCode", qrCode);
					Expression exp1 = new Expression("OrderCode", orderCode);
					ArrayList arr = ProductCheckHistoryBO.Instance.FindByExpression(exp1.And(exp2));
					saveMaster(master, arr);
					//ProductCheckHistoryBO.Instance.Insert(master);
				}

				/*
                 * Insert Detail dữ liệu kiểm tra vào bảng
                 */
				List<ProductCheckHistoryDetailModel> lstDetail = new List<ProductCheckHistoryDetailModel>();
				for (int j = 0; j < count; j++)
				{
					ProductCheckHistoryDetailModel cModel = new ProductCheckHistoryDetailModel();
					//cModel.ProductCheckHistoryID = masterID;
					cModel.ProductStepID = stepID;
					cModel.ProductStepCode = cboWorkingStep.Text.Trim();
					cModel.ProductStepName = txtStepName.Text.Trim();
					cModel.SSortOrder = TextUtils.ToInt(grvData.GetRowCellValue(j, colSSortOrder));

					cModel.ProductWorkingID = TextUtils.ToInt(grvData.GetRowCellValue(j, colWorkingID));
					cModel.ProductWorkingName = TextUtils.ToString(grvData.GetRowCellValue(j, colProductWorkingName));
					cModel.WSortOrder = TextUtils.ToInt(grvData.GetRowCellValue(j, colSortOrder));

					cModel.WorkerCode = txtWorker.Text.Trim();
					cModel.StandardValue = TextUtils.ToString(grvData.GetRowCellValue(j, colStandardValue));
					cModel.RealValue = TextUtils.ToString(grvData.GetRowCellValue(j, "RealValue" + (i - 2)));
					cModel.ValueType = TextUtils.ToInt(grvData.GetRowCellValue(j, colValueType));
					cModel.ValueTypeName = cModel.ValueType == 1 ? "Giá trị\n数値" : "Check mark";
					cModel.EditValue1 = "";
					cModel.EditValue2 = "";
					cModel.StatusResult = TextUtils.ToInt(control.Text.Trim());
					cModel.ProductID = productID;
					cModel.QRCode = qrCode;
					cModel.OrderCode = orderCode;
					//cModel.PackageNumber = _tienTo.Contains("-") ? _tienTo.Split('-')[1] : "";
					//cModel.QtyInPackage = columnCaption;
					cModel.Approved = "";
					cModel.Monitor = "";
					cModel.DateLR = DateTime.Now;
					cModel.EditContent = "";
					cModel.EditDate = DateTime.Now;
					cModel.ProductCode = _productCode;
					cModel.ProductOrder = _order;
					cModel.Line = cboSub.Text.Trim();
					lstDetail.Add(cModel);
					// ProductCheckHistoryDetailBO.Instance.Insert(cModel);
				}
				saveDetail(lstDetail);

				//Update Số lượng thực tế vào kế hoạch sản xuất 

				//Update Số lượng thực tế vào kế hoạch sản xuất 
				if (cboWorkingStep.Text.Trim().ToUpper().Contains("CD7"))
				{
					_Planmodel.Show = 3;
					savePlan(_Planmodel);
				}
				if (cboWorkingStep.Text.Trim().ToUpper().Contains("TP-"))
				{
					try
					{
						if (TextUtils.ToInt(control.Text.Trim()) == 1 || TextUtils.ToInt(control.Text.Trim()) == 13)
						{
							_Planmodel.RealQty += 1; //Cộng vào số lượng thực tế
							if (_Planmodel.Qty <= _Planmodel.RealQty)//So sánh số lượng thực tế với số lượng 
							{
								_Planmodel.Status = 1;// Trạng thái đã xong 1 , Trạng thái chưa xong 0, Trạng thái Quá Hạn so sanh ngayd hhien tai vs jgdate
							}
						}
						if (TextUtils.ToInt(control.Text.Trim()) == 0 || TextUtils.ToInt(control.Text.Trim()) == 03)
						{
							_Planmodel.QtyNG += 1; //Cộng vào số lượng NG
						}
						_Planmodel.Show = 4;
						savePlan(_Planmodel);
					}
					catch
					{

					}
				}
			}
			//stopwatch.Stop();
			//b = stopwatch.Elapsed;

			// MessageBox.Show(string.Format("Time: {0}", b.Seconds));

			_stepIndex = cboWorkingStep.SelectedIndex;
			_PlanID = 9999;
			grdData.DataSource = null;
			txtQRCode.Text = "";
			FocusbtnSave = 0;
			txtOrder.Text = "";
			cboWorkingStep.DataSource = null;
			//btnNotUseCD8.Visible = false;
			resetControl();
			txtQRCode.Focus();
		}
		async void savePlan(ProductionPlanModel item)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				ProductionPlanBO.Instance.Update(item);
			}
			);
			await task;
		}
		async void saveMaster(ProductCheckHistoryModel master, ArrayList arr)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				if (arr.Count > 0)
				{
					return;
				}
				ProductCheckHistoryBO.Instance.Insert(master);
			}
			);
			await task;
		}
		async void saveDetail(List<ProductCheckHistoryDetailModel> lstDetail)
		{
			Task task = Task.Factory.StartNew(() =>
			{
				foreach (ProductCheckHistoryDetailModel item in lstDetail)
				{
					ProductCheckHistoryDetailBO.Instance.Insert(item);
				}
			}
			);
			await task;
		}
		private void txtQRCode_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				txtOrder.Focus();
			}
		}
		private void txtOrder_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					string orderFull = txtOrder.Text.Trim();
					//DataTable dt = TextUtils.Select($"select Top 1 ShipTo, ID, SalesOrder, Prints from ProductionPlan where OrderCodeFull='{orderFull}'");
					_Planmodel = ((ProductionPlanModel)ProductionPlanBO.Instance.FindByAttribute("OrderCodeFull", orderFull)[0]);
					if (_Planmodel.ID <= 0)
					{
						MessageBox.Show("Không tồn tại Order!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						txtOrder.Focus();
						txtOrder.SelectAll();
						return;
					}
					txtQty.Text = TextUtils.ToString(_Planmodel.Qty);
					txtQtyReal.Text = TextUtils.ToString(_Planmodel.RealQty);
					txtGoal.Text = _Planmodel.ShipTo;
					//_PlanID = _Planmodel.SalesOrder;
					txtSalesOrder.Text = _Planmodel.SalesOrder;
					_Print = _Planmodel.Prints;
					txtWorker.Focus();
					loadDataWorkingStep();
				}
			}
			catch
			{
				MessageBox.Show("Không tồn tại Order!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtOrder.Focus();
				txtOrder.SelectAll();
			}
		}
		private void frmProductCheckHistory_FormClosed(object sender, FormClosedEventArgs e)
		{
			//if (_threadDelay != null) _threadDelay.Abort();
			if (_threadRisk != null) _threadRisk.Abort();
			if (_threadFreeze != null) _threadFreeze.Abort();
			File.WriteAllText(pathSub, $"{cboSub.SelectedIndex}");
			Application.Exit();
		}
		private void grvData_KeyDown(object sender, KeyEventArgs e)
		{
			if (grvData.FocusedRowHandle == grvData.RowCount - 1 && e.KeyCode == Keys.Down)//dòng cuối cùng
			{
				int indexColumn = grvData.FocusedColumn.VisibleIndex;
				(pannelBot.Controls.Find("textBox" + (indexColumn - 2), true)[0]).Focus();
			}
		}
		private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if (!_isStartColor) return;
			string workingName = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colProductWorkingName));
			//So sánh giá trị tiêu chuẩn với giá trị nhập vào nếu sai thì selectAll
			int CheckTypeValue = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colCheckValueType));
			string StandardValue = TextUtils.ToString(grvData.GetFocusedRowCellValue(colStandardValue));
			//bỏ qua check motor và check order check ẩn
			if (workingName.Contains("#5#") || workingName.Trim().ToLower() == "checkorder")
			{

			}
			else
			{
				if (e.RowHandle >= 0 && e.Column.VisibleIndex > 2)
				{
					try
					{
						ColumnView view = grdData.FocusedView as ColumnView;
						string value1 = TextUtils.ToString(view.FocusedValue);
						focus = 1;

						//check nếu là dạng string 
						if (CheckTypeValue > 1)
						{
							//if (value1.Trim().ToUpper() != StandardValue.Trim().ToUpper())
							//{

							//	return;
							//}
						}
						//check nếu là dạng số 
						else
						{
							decimal min = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colMinValue));
							decimal max = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colMaxValue));
							if (TextUtils.ToDecimal(value1.Trim()) < min || TextUtils.ToDecimal(value1.Trim()) > max)
							{
								//select all vào cột đó
								//view.SelectAll();
								RowCanNew = RowCan;

								if (RowCanNew == e.RowHandle)
								{
									fieldname = e.Column.FieldName;
									rowhandle = e.RowHandle;
									timerShowCanMo.Enabled = true;
								}
								//this.setFocusCell(getNextIndex(e.RowHandle), grvData.FocusedColumn.VisibleIndex);
								return;
							}
						}

					}
					catch
					{

					}
				}

			}


			if (e.RowHandle >= 0 && e.Column.VisibleIndex == 3)
			{
				string value = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colRealValue1));
				if (workingName.ToUpper().Contains("#1#"))
				{
					if (!_lst.Contains(e.RowHandle))
						_lst.Add(e.RowHandle);
					for (int j = 2; j < 7; j++)
					{
						grvData.SetRowCellValue(e.RowHandle, "RealValue" + (j), value);
					}
				}
			}

			if (e.RowHandle >= 0 && e.Column.VisibleIndex > 2)
			{
				//Check motor
				if (workingName.Trim().Contains("#5#"))
				{
					LoadColorMotor(StandardValue, e);
				}
				//#4# điền giá trị 1 cột rồi bỏ qua
				if (workingName.ToUpper().Contains("#4#"))
				{
					if (!_lst4.Contains(e.RowHandle))
						_lst4.Add(e.RowHandle);
				}

				Control control = pannelBot.Controls.Find("textbox" + (e.Column.VisibleIndex - 2), false)[0];
				if (control.Text.Trim() == "0" || control.Text.Trim() == "1")
				{
					control.BackColor = Color.White;
				}
				else
				{
					control.BackColor = _colorEmpty;
				}

				if (cboWorkingStep.Text == "CD3")
				{
					int sortOrder1 = 70;
					int sortOrder2 = 80;
					int sortOrder3 = 90;
					sortOrder4 = 100;

					if (_GroupCode == "511" || _GroupCode == "512")
					{
						sortOrder1 = 110;
						sortOrder2 = 120;
						sortOrder3 = 130;
						sortOrder4 = 140;
					}

					int sortOrder = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colSortOrder));
					if (sortOrder == sortOrder1 || sortOrder == sortOrder2 || sortOrder == sortOrder3)
					{
						string fieldName = string.Format("RealValue{0}", e.Column.VisibleIndex - 2);

						DataRow r1 = _dtData.Select("SortOrder = " + sortOrder1)[0];
						DataRow r2 = _dtData.Select("SortOrder = " + sortOrder2)[0];
						DataRow r3 = _dtData.Select("SortOrder = " + sortOrder3)[0];
						DataRow r = _dtData.Select("SortOrder = " + sortOrder4)[0];

						List<decimal> lst = new List<decimal>() { TextUtils.ToDecimal(r1[fieldName]), TextUtils.ToDecimal(r2[fieldName]), TextUtils.ToDecimal(r3[fieldName]) };

						r[fieldName] = lst.Max() - lst.Min();
					}
					if (sortOrder == sortOrder3)
					{
						// bỏ qua 2 lần 
						this.setFocusCell(e.RowHandle + 2, grvData.FocusedColumn.VisibleIndex);
					}
					else
					{
						this.setFocusCell(getNextIndex(e.RowHandle), grvData.FocusedColumn.VisibleIndex);
						//this.setFocusCell(getRowIndex(e.Column.VisibleIndex), grvData.FocusedColumn.VisibleIndex);
					}
				}
				else
				{
					this.setFocusCell(getNextIndex(e.RowHandle), grvData.FocusedColumn.VisibleIndex);
					//this.setFocusCell(getRowIndex(e.Column.VisibleIndex), grvData.FocusedColumn.VisibleIndex);
				}
			}
			focus = 1;
		}
		private void grvData_RowCellStyle3(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			if (!_isStartColor) return;
			if (e.RowHandle < 0) return;

			if (e.Column.VisibleIndex < 3) return;

			string value = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, e.Column));
			int checkValueType = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colCheckValueType));
			string standardValue = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colStandardValue));
			string productWorkingName = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colProductWorkingName));
			string columnCaption = e.Column.Caption;

			if (checkValueType == 2 && !string.IsNullOrWhiteSpace(value.Trim()) && !string.IsNullOrWhiteSpace(standardValue.Trim()))
			{
				if (productWorkingName.Trim().ToLower() == "checkorder")
				{
					/*
                     * Mục này kiểm tra giá trị của qrcode của từng con sản phẩm
                     */
					string qrCode = txtQRCode.Text.Trim();
					string[] arrQR = qrCode.Split(' ');
					string firstWord = arrQR[0];
					int lenghtFirstWord = firstWord.Length;
					if (firstWord.Contains("-"))
					{
						//Dạng qrcode có tiền tố chứa ký tự '-' VD: MVNL0123-0-2 911KV5067J25T
						firstWord = firstWord.Split('-')[0];
						lenghtFirstWord = firstWord.Length;
						if (value.Length < lenghtFirstWord)
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							string currentValue = value.Substring(0, lenghtFirstWord);
							if (currentValue.ToLower() == firstWord.ToLower())
							{
								e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
							}
							else
							{
								e.Appearance.BackColor = Color.Red;
							}
						}
					}
					else
					{
						//Dạng qrcode có tiền tố không chứa ký tự '-', VD: VN0123 PA120932
						string orderText = _tienTo + columnCaption;
						if (orderText.Length != firstWord.Length)
						{
							orderText = _tienTo + "0" + columnCaption;
						}
						if (value.Length < orderText.Length)
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							string currentValue = value.Substring(0, orderText.Length);
							if (currentValue.ToLower() == orderText.ToLower())
							{
								e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
							}
							else
							{
								e.Appearance.BackColor = Color.Red;
							}
						}
					}
				}
				else
				{
					/*
                     * Kiểm tra ghi chép dạng giá trị, nhưng giá trị tiêu chuẩn dạng text chứ không phải dạng số
                     */
					string[] arr = value.Split(',');
					if (arr.Length > 0)
					{
						if (arr[0].ToLower() != standardValue.ToLower())
						{
							e.Appearance.BackColor = Color.Red;
						}
						else
						{
							e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
						}
					}
					else
					{
						e.Appearance.BackColor = _colorEmpty;
					}
				}

				return;
			}

			int valueType = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colValueType));
			if (valueType <= 0)
			{
				if (checkValueType == 2 && string.IsNullOrWhiteSpace(value.Trim()) && !string.IsNullOrWhiteSpace(standardValue.Trim()))
				{
					e.Appearance.BackColor = _colorEmpty;
				}
				if (value.ToUpper() == "OK")
				{
					e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
				}
				else if (value.ToUpper() == "NG")
				{
					e.Appearance.BackColor = Color.Red;
				}
				return;
			}

			if (string.IsNullOrWhiteSpace(value))
			{
				e.Appearance.BackColor = _colorEmpty;
			}
			else
			{
				decimal number = TextUtils.ToDecimal(value);
				decimal min = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMinValue));
				decimal max = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMaxValue));
				if (number < min || number > max)
				{
					e.Appearance.BackColor = Color.Red;
					e.Appearance.ForeColor = Color.FromArgb(255, 255, 0);
				}
				else
				{
					e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
				}
			}

			//102, 255, 255
		}
		private void grvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
		{
			if (!_isStartColor) return;
			if (e.RowHandle < 0) return;

			if (e.Column.VisibleIndex < 3) return;
			try
			{
				string value = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, e.Column));
				int checkValueType = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colCheckValueType));
				string standardValue = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colStandardValue));
				string productWorkingName = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colProductWorkingName));
				int SortOrder = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colSortOrder));
				string columnCaption = e.Column.Caption;
				ColumnView view = grdData.FocusedView as ColumnView;
				if (checkValueType == 2 && !string.IsNullOrWhiteSpace(value.Trim()) && !string.IsNullOrWhiteSpace(standardValue.Trim()))
				{
					if (productWorkingName.Trim().ToLower() == "checkorder")
					{
						/*
						 * Mục này kiểm tra giá trị của qrcode của từng con sản phẩm
						 */
						string qrCode = txtQRCode.Text.Trim();
						string[] arrQR = qrCode.Split(' ');
						string firstWord = arrQR[0];
						int lenghtFirstWord = firstWord.Length;
						if (firstWord.Contains("-"))
						{
							//Dạng qrcode có tiền tố chứa ký tự '-' VD: MVNL0123-0-2 911KV5067J25T
							firstWord = firstWord.Split('-')[0];
							lenghtFirstWord = firstWord.Length;
							if (value.Length < lenghtFirstWord)
							{
								e.Appearance.BackColor = Color.Red;
								FocusGridview(e, SortOrder);
							}
							else
							{
								string currentValue = value.Substring(0, lenghtFirstWord);
								if (currentValue.ToLower() == firstWord.ToLower())
								{
									e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
								}
								else
								{
									e.Appearance.BackColor = Color.Red;
									FocusGridview(e, SortOrder);
								}
							}
						}
						else
						{
							//Dạng qrcode có tiền tố không chứa ký tự '-', VD: VN0123 PA120932
							string orderText = _tienTo + columnCaption;
							if (orderText.Length != firstWord.Length)
							{
								orderText = _tienTo + "0" + columnCaption;
							}
							if (value.Length < orderText.Length)
							{
								e.Appearance.BackColor = Color.Red;
								FocusGridview(e, SortOrder);
							}
							else
							{
								string currentValue = value.Substring(0, orderText.Length);
								if (currentValue.ToLower() == orderText.ToLower())
								{
									e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
								}
								else
								{
									e.Appearance.BackColor = Color.Red;
									FocusGridview(e, SortOrder);
								}
							}
						}
					}
					else
					{
						/*
						 * Kiểm tra ghi chép dạng giá trị, nhưng giá trị tiêu chuẩn dạng text chứ không phải dạng số
						 */
						string[] arr = value.Split(',');
						if (arr.Length > 0)
						{
							if (arr[0].ToLower() != standardValue.ToLower())
							{
								e.Appearance.BackColor = Color.Red;
								if (!productWorkingName.Contains("#5#"))
									FocusGridview(e, SortOrder);
							}
							else
							{
								e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
							}
						}
						else
						{
							e.Appearance.BackColor = _colorEmpty;
						}
						//check ký tự khi bắn motor check aritelID theo giá trị tiêu chuẩn
						if (productWorkingName.Trim().Contains("#5#"))
						{
							if (!_lstMotor.Contains($"{value.Trim().ToLower()}"))
							{
								e.Appearance.BackColor = Color.Red;
								FocusGridview(e, TextUtils.ToInt(grvData.GetRowCellValue(_RowMotor, colSortOrder)));
							}
							else
							{
								e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
							}
						}
					}

					return;
				}

				int valueType = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colValueType));
				if (valueType <= 0)
				{
					if (checkValueType == 2 && string.IsNullOrWhiteSpace(value.Trim()) && !string.IsNullOrWhiteSpace(standardValue.Trim()))
					{
						e.Appearance.BackColor = _colorEmpty;
					}
					if (value.ToUpper() == "OK")
					{
						e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
					}
					else if (value.ToUpper() == "NG")
					{
						e.Appearance.BackColor = Color.Red;
					}
					return;
				}

				if (string.IsNullOrWhiteSpace(value))
				{
					e.Appearance.BackColor = _colorEmpty;
				}
				else
				{
					decimal number = TextUtils.ToDecimal(value);
					decimal min = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMinValue));
					decimal max = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMaxValue));
					if (number < min || number > max)
					{
						e.Appearance.BackColor = Color.Red;
						e.Appearance.ForeColor = Color.FromArgb(255, 255, 0);
						FocusGridview(e, SortOrder);
					}
					else
					{
						e.Appearance.BackColor = Color.FromArgb(102, 255, 255);
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
			//102, 255, 255
		}
		void FocusGridview(DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e, int SortOrder)
		{
			try
			{
				if (focus == 1)
				{
					//Nếu là ô check max thì dừng lại 
					if (TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colValueType)) != 1)
					{
						return;
					}
					if (sortOrder4 == SortOrder)
						return;
					focus = 0;
					grvData.Focus();
					grvData.FocusedRowHandle = e.RowHandle;
					grvData.FocusedColumn = e.Column;
				}
			}
			catch (Exception)
			{


			}
		}
		void sendData(double slCanMo, int row, string column)
		{
			grvData.SetRowCellValue(row, column, slCanMo);
		}

		void LoadColorMotor(string standardValue, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			try
			{
				_AritelID = TextUtils.ToString(TextUtils.ExcuteScalar($"SELECT TOP 1 ArticleID FROM [SystemData].[dbo].[CheckMotor] WHERE MotorInspSealNo=N'{TextUtils.ToString(grvData.GetRowCellValue(_RowMotor, e.Column.FieldName))}' Or CardNo=N'{TextUtils.ToString(grvData.GetRowCellValue(_RowMotor, e.Column.FieldName))}' Or ArticleID=N'{TextUtils.ToString(grvData.GetRowCellValue(_RowMotor, e.Column.FieldName))}'"));
				//#5# check Motor khi bắn CardNo hiển thị AritelID check với giá trị tiêu chuẩn 
				if (_AritelID.Trim().ToUpper() != "")
				{
					if (standardValue.ToLower() == "0")
					{
						//Update StandValue trong bảng ProductWorking với mã #5# theo ProductID và ProductStepID
						TextUtils.ExcuteSQL($"UPDATE dbo.[ProductWorking] SET PeriodValue='{_AritelID}' WHERE ProductID = {_productID} AND ProductStepID={_workingStepID} AND IsDeleted = 0  AND WorkingName LIKE '%#5#%'");
						grvData.SetRowCellValue(_RowMotor, colStandardValue, _AritelID);
					}
					//So sánh với giá trị tiêu chuẩn nếu đúng thì Add List Card_No
					if (TextUtils.ToString(grvData.GetRowCellValue(_RowMotor, colStandardValue)).ToUpper() == _AritelID.ToUpper())
					{
						_lstMotor.Add(TextUtils.ToString(grvData.GetRowCellValue(_RowMotor, e.Column.FieldName)).ToLower());
					}
				}
			}
			catch (Exception)
			{

			}


		}
		private void txt_TextChanged(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;
			if (string.IsNullOrWhiteSpace(txt.Text.Trim()))
			{
				txt.BackColor = _colorEmpty;

			}
			else
			{
				txt.BackColor = Color.White;
			}
		}
		private void textBox_TextChanged(object sender, EventArgs e)
		{
			TextBox txt = (TextBox)sender;

			if (txt.Text.Trim() == "0" || txt.Text.Trim() == "1")
			{
				txt.BackColor = Color.White;
			}
			else
			{
				txt.BackColor = _colorEmpty;
			}
		}
		int getPreviousIndex()
		{
			int valueIndex = grvData.RowCount;
			for (int i = grvData.RowCount; i >= 0; i--)
			{
				int valueType = TextUtils.ToInt(grvData.GetRowCellValue(i, colValueType));

				if (valueType == 1)//Kiểu giá trị
				{
					valueIndex = i;
					break;
				}
			}
			return valueIndex;
		}
		private void textBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (grvData.RowCount == 0) return;
			TextBox textBox = (TextBox)sender;
			int textIndex = TextUtils.ToInt(textBox.Tag);

			int columnIndex = textIndex + 2;

			//Khi ấn mũi tên đi lên thì focus vào cột tương ứng
			if (e.KeyCode == Keys.Up)
			{
				this.setFocusCell(getPreviousIndex(), columnIndex);
				//setFocusCell(getRowIndex(columnIndex), columnIndex);
			}
			if (e.KeyCode == Keys.Enter)
			{
				if (CheckSkipCD(1, columnIndex) == false)
				{
					MessageBox.Show($"Sản phẩm chưa đi qua công đoạn {CDOld}");
					return;
				}
				string value = ((TextBox)sender).Text;
				string valueString = "";// 
				if (value == "1")
				{
					valueString = "OK";
				}
				else if (value == "0")
				{
					valueString = "NG";
				}
				if (value == "1")
				{
					//Check phải điền hết các giá trị mới cho đánh giá ok
					for (int i = 0; i < _dtData.Rows.Count; i++)
					{
						DataRow r = _dtData.Rows[i];
						int checkValueType = TextUtils.ToInt(r["CheckValueType"]);
						string standardValue = TextUtils.ToString(r["StandardValue"]);
						string WorkingName = TextUtils.ToString(r["WorkingName"]);
						int valueType = TextUtils.ToInt(r["ValueType"]);
						if (WorkingName.Contains("#4#")) continue;
						if (valueType == 0) continue;
						if (valueType > 0)
						{
							string RealValue = TextUtils.ToString(grvData.GetRowCellValue(i, "RealValue" + (columnIndex - 2)));
							if (RealValue.Trim() == "")
							{
								MessageBox.Show("Bạn phải nhập đầy đủ giá trị theo cột đánh giá", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								((TextBox)sender).Text = "";
								setFocusCell(getRowIndex(columnIndex), columnIndex);
								return;
							}
						}
					}
				}
				//Set giá trị các ô có giá trị check mark
				for (int i = 0; i < _dtData.Rows.Count; i++)
				{
					DataRow r = _dtData.Rows[i];

					int checkValueType = TextUtils.ToInt(r["CheckValueType"]);
					string standardValue = TextUtils.ToString(r["StandardValue"]);
					int valueType = TextUtils.ToInt(r["ValueType"]);

					if (valueType > 0) continue;

					if (checkValueType == 2 && !string.IsNullOrWhiteSpace(standardValue))
					{
						continue;
					}

					if (valueType == 0)
					{
						r["RealValue" + (columnIndex - 2)] = valueString;
					}
				}
				//Set tiêu đề cột trước khi chuyển sang cột mới
				if (value == "1" || value == "0")
				{
					//grvData.Columns["RealValue" + (columnIndex - 2)].Caption = (int.Parse(_stt) + columnIndex - 3).ToString();

					if (columnIndex < 8)
					{
						//focus vào ô của cột tiếp theo
						setFocusCell(getRowIndex(columnIndex + 1), columnIndex + 1);
					}
					else
					{
						FocusbtnSave = 1;
						btnSave.Focus();
					}
					if (_oAndonModel.ID > 0)
					{
						//Cập nhật trạng thái đã làm xong
						sendDataTCP("4", "2");
					}
					if (_startMakeTime == new DateTime())
					{
						_startMakeTime = DateTime.Now;
					}
					_isStart = false;
					_endMakeTime = DateTime.Now;
					//Cất vào bảng AndonDetail
					AndonDetailModel andonDetail = new AndonDetailModel();
					andonDetail.ProductCode = _productCode;
					andonDetail.ProductID = _productID;
					andonDetail.ProductStepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
					andonDetail.QrCode = _tienTo + grvData.Columns[columnIndex].Caption + " " + _productCode;
					andonDetail.OrderCode = txtOrder.Text.Trim();
					andonDetail.ProductStepCode = cboWorkingStep.Text.Trim();
					andonDetail.StartTime = _startMakeTime;
					andonDetail.EndTime = _endMakeTime;
					andonDetail.MakeTime = TextUtils.ToInt(_taktTime - TextUtils.ToInt(lblTakt.Text.Trim()));

					andonDetail.AnDonID = _oAndonModel.ID;
					andonDetail.ShiftID = _oAndonModel.ShiftID;
					andonDetail.Takt = _oAndonModel.Takt;
					if (_PeriodTime > 0 && _PeriodTime < 200)
					{
						andonDetail.Type = 1;
						andonDetail.PeriodTime = _PeriodTime;
					}
					else
					{
						andonDetail.Type = 3;
						andonDetail.PeriodTime = _PeriodTime;
					}

					andonDetail.WorkerCode = txtWorker.Text.Trim();
					andonDetail.OkStatus = TextUtils.ToInt(value);
					AndonDetailBO.Instance.Insert(andonDetail);
					//tăng qty actual
					if (cboWorkingStep.Text.Trim() == "CD7")
					{
						sendDataTCP("0", "3");
					}

					if (cboWorkingStep.Text.Trim() == "CD11" && value == "1" && _Print == true)
					{
						try
						{
							int productID = _productID;
							int stepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
							if (productID == 0)
							{
								MessageBox.Show(string.Format("Không tồn tại sản phẩm có mã [{0}]!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
							if (stepID == 0)
							{
								MessageBox.Show(string.Format("Bạn chưa chọn công đoạn nào!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return;
							}
							if (string.IsNullOrEmpty(txtWorker.Text.Trim()))
							{
								MessageBox.Show(string.Format("Bạn chưa điền người làm!", _productCode.Trim()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
								txtWorker.Focus();
								return;
							}
							int count = _dtData.Rows.Count;
							Control control = pannelBot.Controls.Find("textbox" + (columnIndex - 2), false)[0];
							string columnCaption = grvData.Columns[columnIndex].Caption;
							string qrCode = "";
							if (string.IsNullOrEmpty(control.Text.Trim()))
							{

							}
							else
							{
								qrCode = _tienTo + columnCaption + " " + _productCode;
							}
							string orderCode = string.IsNullOrWhiteSpace(txtOrder.Text.Trim()) ?
									(_tienTo.Contains("-") ? _tienTo.Substring(0, _tienTo.Length - 1) : _order) :
									txtOrder.Text.Trim();
							List<ProductCheckHistoryDetailModel> lstDetail = new List<ProductCheckHistoryDetailModel>();
							for (int j = 0; j < count; j++)
							{
								ProductCheckHistoryDetailModel cModel = new ProductCheckHistoryDetailModel();
								//cModel.ProductCheckHistoryID = masterID;
								cModel.ProductStepID = stepID;
								cModel.ProductStepCode = cboWorkingStep.Text.Trim();
								cModel.ProductStepName = txtStepName.Text.Trim();
								cModel.SSortOrder = TextUtils.ToInt(grvData.GetRowCellValue(j, colSSortOrder));

								cModel.ProductWorkingID = TextUtils.ToInt(grvData.GetRowCellValue(j, colWorkingID));
								cModel.ProductWorkingName = TextUtils.ToString(grvData.GetRowCellValue(j, colProductWorkingName));
								cModel.WSortOrder = TextUtils.ToInt(grvData.GetRowCellValue(j, colSortOrder));

								cModel.WorkerCode = txtWorker.Text.Trim();
								cModel.StandardValue = TextUtils.ToString(grvData.GetRowCellValue(j, colStandardValue));
								cModel.RealValue = TextUtils.ToString(grvData.GetRowCellValue(j, "RealValue" + (columnIndex - 2)));
								cModel.ValueType = TextUtils.ToInt(grvData.GetRowCellValue(j, colValueType));
								cModel.ValueTypeName = cModel.ValueType == 1 ? "Giá trị\n数値" : "Check mark";
								cModel.EditValue1 = "";
								cModel.EditValue2 = "";
								cModel.StatusResult = TextUtils.ToInt(control.Text.Trim());
								cModel.ProductID = productID;
								cModel.QRCode = qrCode;
								cModel.OrderCode = orderCode;
								//cModel.PackageNumber = _tienTo.Contains("-") ? _tienTo.Split('-')[1] : "";
								//cModel.QtyInPackage = columnCaption;
								cModel.Approved = "";
								cModel.Monitor = "";
								cModel.DateLR = DateTime.Now;
								cModel.EditContent = "";
								cModel.EditDate = DateTime.Now;
								cModel.ProductCode = _productCode;
								cModel.ProductOrder = _order;
								cModel.Line = cboSub.Text.Trim();
								lstDetail.Add(cModel);
								ProductCheckHistoryDetailBO.Instance.Insert(cModel);
							}
							//saveDetail(lstDetail);

							// gửi data qua frm Print
							_frm._SendData(txtQRCode.Text.Trim(), txtOrder.Text.Trim(), txtName.Text.Trim());

							if (columnIndex == 6)
							{
								_stepIndex = cboWorkingStep.SelectedIndex;
								_PlanID = 9999;
								grdData.DataSource = null;
								txtQRCode.Text = "";
								txtOrder.Text = "";
								cboWorkingStep.DataSource = null;
								//btnNotUseCD8.Visible = false;
								resetControl();
								txtQRCode.Focus();
							}
						}
						catch
						{ }
					}
				}
				else
				{
					this.setFocusCell(getPreviousIndex(), columnIndex);
					//setFocusCell(getRowIndex(columnIndex), columnIndex);
				}



			}
		}
		private void textBox_GotFocus(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (cboWorkingStep.Text.Trim() != "CD11")
				btnSave_Click(null, null);
		}
		private void startRiskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//startThreadRisk();
			_sTimeRisk = DateTime.Now;
			this.BackColor = Color.Red;

			//Gửi tín hiệu risk qua server Andon qua TCP/IP
			sendDataTCP("3", "1");
		}
		private void endRiskToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (_sTimeRisk == new DateTime())
			{
				_sTimeRisk = DateTime.Now;
			}
			_eTimeRisk = DateTime.Now;
			try
			{
				frmChooseRisk frm = new frmChooseRisk();
				if (frm.ShowDialog() == DialogResult.OK)
				{
					//Ghi dữ liệu sự cố vào bảng Andon
					AndonDetailModel detail = new AndonDetailModel();
					detail.ProductID = _productID;
					detail.ProductCode = _productCode;
					detail.OrderCode = txtOrder.Text.Trim();
					detail.ProductStepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
					detail.ProductStepCode = cboWorkingStep.Text.Trim();
					detail.Type = 2;
					if (_oAndonModel != null)
					{
						detail.Takt = _oAndonModel.Takt;
						detail.AnDonID = _oAndonModel.ID;
						detail.ShiftID = _oAndonModel.ShiftID;
					}
					detail.PeriodTime = TextUtils.ToInt(Math.Round((_eTimeRisk - _sTimeRisk).TotalSeconds, 0));
					detail.MakeTime = 0;
					detail.StartTime = _sTimeRisk;
					detail.EndTime = _eTimeRisk;
					detail.RiskDescription = frm.RiskDescription;
					detail.WorkerCode = txtWorker.Text;

					AndonDetailBO.Instance.Insert(detail);
					// kiểm tra lại trạng thái nút Không sử dụng để gửi tín hiệu.
					if (btnNotUseCD8.Text == "Không sử dụng")
					{
						sendDataTCP("11", "10");
					}
					else
					{
						sendDataTCP("4", "2");
					}


					this.BackColor = Color.WhiteSmoke;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		bool _isUse = false;
		private void btnNotUseCD8_Click(object sender, EventArgs e)
		{
			//Khi nhấn ko sử dụng công đoạn 8 thì nó luôn cập nhật vào bảng statuscolorCD = 4 
			if (!_isUse)
			{
				//startThreadNotUseCD8();
				//TextUtils.ExcuteSQL(@"update AndonConfig set IsStopCD8 = 1");
				sendDataTCP("10", "10");
				btnNotUseCD8.Text = "Sử dụng";
				_isUse = true;
			}
			else
			{
				//TextUtils.ExcuteSQL(@"update AndonConfig set IsStopCD8 = 0");
				//if (_threadNotUseCD8 != null) _threadNotUseCD8.Abort();
				sendDataTCP("11", "10");
				_isUse = false;
				btnNotUseCD8.Text = "Không sử dụng";
			}
			grdData.Enabled = txtOrder.Enabled = txtQRCode.Enabled = !_isUse;
			textBox1.Enabled = textBox1.Enabled = textBox1.Enabled = textBox1.Enabled = textBox1.Enabled = textBox1.Enabled = !_isUse;
		}

		private void loginToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!_isLogin)
			{
				frmLogin frm = new frmLogin();
				frm.ShowDialog();
				if (frm.DialogResult == DialogResult.OK)
				{
					_isLogin = true;
				}
			}
			else
			{
				DialogResult rs = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo);
				if (rs == DialogResult.No) return;
				_isLogin = false;
			}
		}

		private void txtWorker_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtWorker.Text.Trim()))
			{
				MessageBox.Show("Bạn chưa điền tên người làm!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtWorker.Focus();
			}
		}

		private void txtWorker_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				cboWorkingStep.Focus();
			}
		}

		private void cboWorkingStep_TextChanged(object sender, EventArgs e)
		{
			lblCD.Text = cboWorkingStep.Text.Trim();
		}

		private void btnShow_Click(object sender, EventArgs e)
		{
			if (!File.Exists(_pathFileBanDo)) return;
			try
			{
				string[] lines = File.ReadAllLines(_pathFileBanDo);
				if (lines == null) return;
				if (lines.Length < 2) return;

				string[] stringSeparators = new string[] { "||" };
				string[] arr = lines[1].Split(stringSeparators, 4, StringSplitOptions.RemoveEmptyEntries);

				if (arr == null) return;
				if (arr.Length < 4) return;
				string name = "";
				string path = Path.Combine(Application.StartupPath, arr[1].Trim());
				string pathUpdate = arr[2].Trim();
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				if (_ProductCode == "") return;
				string[] fileList = Directory.GetFiles(pathUpdate);//lay danh sách file cho vao mảng
				string strFileName = "";
				//duyet mang file trong thư mục
				foreach (string i in fileList)
				{
					strFileName = "";
					strFileName = Path.GetFileName(i).Trim();
					if (strFileName.ToUpper().Contains($"{_ProductCode.ToUpper()}"))
					{
						name = strFileName;
						break;
					}
				}
				Process.Start($"{pathUpdate}\\{name}");
			}
			catch
			{
				MessageBox.Show("Không tìm thấy File DPF", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void textBox1_TextAlignChanged(object sender, EventArgs e)
		{

		}

		private string fieldname;
		private int rowhandle;
		private void timerShowCanMo_Tick(object sender, EventArgs e)
		{
			timerShowCanMo.Enabled = false;
			Double sl = TextUtils.ToDouble(grvData.GetFocusedValue());
			RowCanNew = 9999;
			// Show form
			frmCanMo frm = new frmCanMo();
			frm.SL = sl;
			frm.column = fieldname;
			frm.row = rowhandle;

			frm._SLCanMo = new SLCanMo(sendData);
			frm.Show();
			frm.Activate();
		}
	}
}
