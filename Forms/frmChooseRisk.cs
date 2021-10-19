using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmChooseRisk : Form
    {
        public string RiskDescription = "";
        public frmChooseRisk()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRisk.Text.Trim()=="")
            {
                MessageBox.Show("Bạn phải nhập nguyên nhân sự cố!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RiskDescription = txtRisk.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}
