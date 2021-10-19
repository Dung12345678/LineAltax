using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BMS.frmProductCheckHistory1;

namespace BMS
{
	public partial class frmCanMo : Form
	{
		public int row = 0;
		public string column = "";
		public double SL = 0;
		internal SLCanMo _SLCanMo;

		public frmCanMo()
		{
			InitializeComponent();
		}

		private void frmCanMo_Load(object sender, EventArgs e)
		{
			txtSoLuong.Focus();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			SL += TextUtils.ToDouble(txtSoLuong.Text.Trim());
			_SLCanMo(SL, row, column);
			this.Close();
			//this.DialogResult = DialogResult.OK;
		}

		private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnOK.Focus();
		}

		private void frmCanMo_Shown(object sender, EventArgs e)
		{
			txtSoLuong.Focus();
		}
	}
}
