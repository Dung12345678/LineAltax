using BMS.Business;
using BMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
	public partial class frmPrint : _Forms
	{
		public delegate void SendData(string QRCode, string OrderCode, string ProductName);
		public SendData _SendData;
		public frmPrint()
		{
			InitializeComponent();
		}

		private void frmPrint_Load(object sender, EventArgs e)
		{

			_SendData = new SendData(sendData);
		}
		void sendData(string QRCode, string OrderCode, string ProductName)
		{
			try
			{
				string date = TextUtils.ToString(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
				DataTable dt = TextUtils.LoadDataFromSP("spGetHistoryCheckDataDetail", "A"
					, new string[] { "QRCode" }
					, new object[] { QRCode });
				grdData.DataSource = dt;
				string[] arr = QRCode.Split(' ');
				string[] arrOrder = arr[0].Split('-');

				//grdData.Print();
				if (grvData.RowCount <= 0) return;
				string filePath = TextUtils.ExportExcelReturnFilePathLocal(grvData, QRCode);
				if (string.IsNullOrEmpty(filePath)) return;

				Excel.Application app = default(Excel.Application);
				Excel.Workbook workBoook = default(Excel.Workbook);
				Excel.Worksheet workSheet = default(Excel.Worksheet);
				try
				{
					app = new Excel.Application();
					app.Workbooks.Open(filePath);
					workBoook = app.Workbooks[1];
					workSheet = (Excel.Worksheet)workBoook.Worksheets[1];
					app.DisplayAlerts = false;
					for (int i = 0; i < 5; i++)
					{
						((Excel.Range)workSheet.Rows[1]).Insert();
					}

					workSheet.Cells[1, 1] = "Order No: ";
					workSheet.Cells[1, 3] = arrOrder[0];
					workSheet.Cells[2, 1] = "PID No: ";
					workSheet.Cells[2, 3] = arr[1];

					workSheet.Cells[3, 1] = "Mô Tả: ";
					workSheet.Cells[3, 3] = ProductName;
					workSheet.Cells[4, 1] = "Ngày lắp: ";
					workSheet.Cells[4, 3] = "'" + date;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi: " + ex.Message);
				}
				finally
				{

					app.ActiveWorkbook.Save();
					app.ActiveWorkbook.PrintOutEx();
					app.Workbooks.Close();
					app.Quit();
					//Process.Start(filePath);

				}
			}

			catch
			{

			}
		}

	}
}
