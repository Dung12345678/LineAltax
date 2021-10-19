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

namespace BMS
{
    public partial class frmProductCheckHistory2 : _Forms
    {
        public long _WorkerID = 0;
        string _order = "";
        string _productCode = "";
        string _tienTo = "";
        string _stt = "";
        int _stepIndex = 0;
        Color _colorEmpty;
        string _GroupCode;

        int oldHeight = 0;
        int oldHeightGrid = 0;
        //DateTime _sTimeDelay;


        int _productID = 0;
        //Thread _threadDelay;
        Thread _threadResetSocket;

        string _socketIPAddress = "192.168.1.46";
        int _socketPort = 3000;
        Socket _socket;
        ASCIIEncoding _encoding = new ASCIIEncoding();

        int _currentIndex = 0;
        int _totalTimeDelay = 0;
        int _taktTime = 10;


        DataTable _dtData = new DataTable();

        string _pathFileConfigUpdate = Path.Combine(Application.StartupPath, "ConfigUpdate.txt");
        string _pathFolderUpdate = "";
        string _pathUpdateServer = "";
        string _pathFileVersion = "";
        string _pathError = Path.Combine(Application.StartupPath, "Errors");

        public frmProductCheckHistory2()
        {
            InitializeComponent();
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
            catch { }


        }
        private void frmProductCheckHistory1_Load(object sender, EventArgs e)
        {

            DocUtils.InitFTPQLSX();

            //Check update version
            updateVersion();

            try
            {
                ////Load ra config trong database lấy takt time, địa chỉ tcp, port
                //DataTable dtConfig = TextUtils.Select("SELECT TOP 1 * FROM dbo.AndonConfig with (nolock)");
                //_taktTime = TextUtils.ToInt(dtConfig.Rows[0]["Takt"]);
                //_socketIPAddress = TextUtils.ToString(dtConfig.Rows[0]["TcpIp"]);
                //_socketPort = TextUtils.ToInt(dtConfig.Rows[0]["SocketPort"]);

                //IPAddress ipAddOut = IPAddress.Parse(_socketIPAddress);
                //IPEndPoint endPoint = new IPEndPoint(ipAddOut, _socketPort);
                //_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //_socket.Connect(endPoint);
            }
            catch (Exception ex)
            {

                _socket = null;
            }

            ToolTip toolTip1 = new ToolTip();
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.btnSave, "F12");

            _colorEmpty = Color.FromArgb(255, 192, 255);
            initBackColor();
            oldHeight = this.Height;
            oldHeightGrid = grdData.Height;


            //startThreadResetSocket();
        }


        void startThreadResetSocket()
        {
            _threadResetSocket = new Thread(resetSocket);
            _threadResetSocket.IsBackground = true;
            _threadResetSocket.Start();
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
            DataTable dt = TextUtils.LoadDataFromSP("spGetProductStep_ByProductCode", "A"
                , new string[1] { "@ProductCode" }
                , new object[1] { productCode });
            DataRow dr = dt.NewRow();
            dr["ID"] = 0;
            dr["ProductStepCode"] = "";
            dt.Rows.InsertAt(dr, 0);

            cboWorkingStep.DataSource = dt;
            cboWorkingStep.DisplayMember = "ProductStepCode";
            cboWorkingStep.ValueMember = "ID";

            if (_stepIndex > 0 && _stepIndex < dt.Rows.Count)
            {
                cboWorkingStep.SelectedIndex = _stepIndex;
            }
        }
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
                if ((string.IsNullOrWhiteSpace(value) && type > 0) || (checkValueType == 2 && string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(standardValue)))
                {
                    rowIndex = i;
                    break;
                }
            }
            if (rowIndex == -1)
            {
                rowIndex = grvData.RowCount - 1;
            }
            return rowIndex;
        }

        void setFocusCell(int indexRow, int indexColum)
        {
            if (indexRow <= grvData.RowCount - 1)
            {
                grvData.FocusedRowHandle = indexRow;

                grvData.FocusedColumn = grvData.VisibleColumns[indexColum];

                grvData.ShowEditor();
            }
            else
            {
                (pannelBot.Controls.Find("textBox" + (indexColum - 2), true)[0]).Focus();
            }
        }

        int getNextIndex(int index)
        {
            int valueIndex = grvData.RowCount;
            for (int i = index + 1; i < grvData.RowCount; i++)
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
            //Stopwatch s = new Stopwatch();
            //s.Start();

            if (string.IsNullOrEmpty(txtWorker.Text.Trim()) && cboWorkingStep.SelectedIndex != 0)
            {
                MessageBox.Show("Bạn chưa nhập tên người làm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWorker.Focus();
                return;
            }


            int workingStepID = TextUtils.ToInt(cboWorkingStep.SelectedValue);
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

            if (workingStepID == 0)
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

            //Gán dữ liệu vào grid
            DataSet ds = ProductCheckHistoryDetailBO.Instance.GetDataSet("spGetWorkingByProduct",
                new string[] { "@WorkingStepID", "@WorkingStepCode", "@ProductCode" },
                new object[] { workingStepID, stepCode, arr1[1].ToString() });

            _dtData = ds.Tables[0];
            grdData.DataSource = _dtData;
            txtStepName.Text = TextUtils.ToString(ds.Tables[1].Rows.Count > 0 ? ds.Tables[1].Rows[0][0] : "");

            _GroupCode = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ProductGroupCode"] : "");
            txtName.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ProductName"] : "");
            txtMo.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["LoaiMo"] : "");
            txtGoal.Text = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["Goal"] : "");

            string gunNumber = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["GunNumber"] : "");
            string jobNumber = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["JobNumber"] : "");
            string qtyOcBanGa = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["QtyOcBanGa"] : "");
            string qtyOcBanThat = TextUtils.ToString(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["QtyOcBanThat"] : "");
            _productID = TextUtils.ToInt(ds.Tables[2].Rows.Count > 0 ? ds.Tables[2].Rows[0]["ID"] : "");

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

            _currentIndex = 1;//đánh dấu số thứ tự sản phẩm được check trong order 

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
                if (string.IsNullOrEmpty(control.Text.Trim())) continue;
                else
                {

                    qrCode = _tienTo + columnCaption + " " + _productCode;
                }
                if (string.IsNullOrWhiteSpace(control.Text.Trim()) || TextUtils.ToInt(control.Text.Trim()) > 1 || TextUtils.ToInt(control.Text.Trim()) < 0)
                {
                    continue;
                }

                /*
                 * Xóa các giá trị đã lưu cũ
                 */
                // ProductCheckHistoryDetailBO.Instance.DeleteByExpression(new Utils.Expression("QRCode", qrCode).And(new Utils.Expression("ProductStepID", stepID)));
                /*
                 * Insert lại dữ liệu kiểm tra vào bảng
                 */
                for (int j = 0; j < count; j++)
                {
                    ProductCheckHistoryDetailModel cModel = new ProductCheckHistoryDetailModel();
                    cModel.ProductStepID = stepID;
                    cModel.ProductStepCode = cboWorkingStep.Text.Trim();
                    cModel.ProductStepName = txtStepName.Text.Trim();
                    cModel.SSortOrder = TextUtils.ToInt(grvData.GetRowCellValue(j, colSSortOrder));

                    cModel.ProductWorkingID = TextUtils.ToInt(grvData.GetRowCellValue(j, colWorkingID));
                    //cModel.ProductWorkingCode = TextUtils.ToInt(grvData.GetRowCellValue(j, colWorkingID));
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
                    cModel.OrderCode = string.IsNullOrWhiteSpace(txtOrder.Text.Trim()) ?
                        (_tienTo.Contains("-") ? _tienTo.Substring(0, _tienTo.Length - 1) : _order) :
                        txtOrder.Text.Trim();
                    cModel.PackageNumber = _tienTo.Contains("-") ? _tienTo.Split('-')[1] : "";
                    cModel.QtyInPackage = columnCaption;
                    cModel.Approved = "";
                    cModel.Monitor = "";
                    cModel.DateLR = DateTime.Now;
                    cModel.EditContent = "";
                    cModel.EditDate = DateTime.Now;
                    cModel.ProductCode = _productCode;

                    cModel.ProductOrder = _order;

                    ProductCheckHistoryDetailBO.Instance.Insert(cModel);
                }
            }
            //stopwatch.Stop();
            //b = stopwatch.Elapsed;

            // MessageBox.Show(string.Format("Time: {0}", b.Seconds));

            _stepIndex = cboWorkingStep.SelectedIndex;
            _currentIndex = 0;

            _totalTimeDelay = 0;

            grdData.DataSource = null;
            txtQRCode.Text = "";
            txtOrder.Text = "";
            cboWorkingStep.DataSource = null;
            resetControl();
            txtQRCode.Focus();
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

            if (e.KeyCode == Keys.Enter)
            {
                txtWorker.Focus();
                loadDataWorkingStep();
            }
        }
        private void frmProductCheckHistory_FormClosed(object sender, FormClosedEventArgs e)
        {

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
            if (e.RowHandle >= 0 && e.Column.VisibleIndex > 2)
            {
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
                    int sortOrder4 = 100;

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

                        //r[fieldName] = lst.Max() - lst.Min();
                    }
                    if (sortOrder == sortOrder3)
                    {
                        this.setFocusCell(e.RowHandle + 2, grvData.FocusedColumn.VisibleIndex);
                    }
                    else
                    {
                        this.setFocusCell(getNextIndex(e.RowHandle), grvData.FocusedColumn.VisibleIndex);
                    }
                }
                else
                {
                    this.setFocusCell(getNextIndex(e.RowHandle), grvData.FocusedColumn.VisibleIndex);
                }
            }
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
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvData.RowCount == 0) return;
            TextBox textBox = (TextBox)sender;
            int textIndex = TextUtils.ToInt(textBox.Tag);

            int columnIndex = textIndex + 2;

            //Khi ấn mũi tên đi lên thì focus vào cột tương ứng
            if (e.KeyCode == Keys.Up)
            {
                setFocusCell(getRowIndex(columnIndex), columnIndex);
            }
            if (e.KeyCode == Keys.Enter)
            {
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
                        btnSave.Focus();
                    }
                }
                else
                {
                    setFocusCell(getRowIndex(columnIndex), columnIndex);
                }

            }


        }
        private void textBox_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
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
    }
}
