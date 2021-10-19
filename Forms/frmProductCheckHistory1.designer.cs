using System;

namespace BMS
{
    partial class frmProductCheckHistory1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.txtQRCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtWorker = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cboWorkingStep = new System.Windows.Forms.ComboBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.grdData = new DevExpress.XtraGrid.GridControl();
			this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colProductWorkingName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStandardValue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.colValueTypeText = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRealValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRealValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRealValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRealValue4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRealValue5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colRealValue6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colWorkingID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComport = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMinValue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMaxValue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colValueType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCheckValueType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSortOrder = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSSortOrder = new DevExpress.XtraGrid.Columns.GridColumn();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.txtStepName = new System.Windows.Forms.TextBox();
			this.txtOrder = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.aToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startRiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.endRiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtMo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtGoal = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTimeDelay = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnNotUseCD8 = new System.Windows.Forms.Button();
			this.txtNumDelay = new System.Windows.Forms.TextBox();
			this.panelTop = new System.Windows.Forms.Panel();
			this.txtQtyReal = new System.Windows.Forms.TextBox();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.cboSub = new System.Windows.Forms.ComboBox();
			this.txtSalesOrder = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.pannelBot = new System.Windows.Forms.Panel();
			this.btnShow = new System.Windows.Forms.Button();
			this.lblTakt = new System.Windows.Forms.Label();
			this.lblCD = new System.Windows.Forms.Label();
			this.timerShowCanMo = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panelTop.SuspendLayout();
			this.pannelBot.SuspendLayout();
			this.SuspendLayout();
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
			this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// txtQRCode
			// 
			this.txtQRCode.BackColor = System.Drawing.Color.White;
			this.txtQRCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQRCode.Location = new System.Drawing.Point(89, 4);
			this.txtQRCode.Name = "txtQRCode";
			this.txtQRCode.Size = new System.Drawing.Size(240, 29);
			this.txtQRCode.TabIndex = 0;
			this.txtQRCode.TextChanged += new System.EventHandler(this.txt_TextChanged);
			this.txtQRCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQRCode_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(5, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "NHẬP QRCODE";
			// 
			// txtWorker
			// 
			this.txtWorker.BackColor = System.Drawing.Color.White;
			this.txtWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtWorker.Location = new System.Drawing.Point(445, 4);
			this.txtWorker.Name = "txtWorker";
			this.txtWorker.Size = new System.Drawing.Size(136, 29);
			this.txtWorker.TabIndex = 3;
			this.txtWorker.TextChanged += new System.EventHandler(this.txt_TextChanged);
			this.txtWorker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWorker_KeyDown);
			this.txtWorker.Leave += new System.EventHandler(this.txtWorker_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(335, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "NGƯỜI LÀM";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(334, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "CHỌN CÔNG ĐOẠN";
			// 
			// cboWorkingStep
			// 
			this.cboWorkingStep.BackColor = System.Drawing.Color.White;
			this.cboWorkingStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboWorkingStep.FormattingEnabled = true;
			this.cboWorkingStep.Location = new System.Drawing.Point(445, 35);
			this.cboWorkingStep.Name = "cboWorkingStep";
			this.cboWorkingStep.Size = new System.Drawing.Size(136, 30);
			this.cboWorkingStep.TabIndex = 2;
			this.cboWorkingStep.SelectedIndexChanged += new System.EventHandler(this.cboWorkingStep_SelectedIndexChanged);
			this.cboWorkingStep.TextChanged += new System.EventHandler(this.cboWorkingStep_TextChanged);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(1117, 33);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(154, 33);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "CẤT DỮ LIỆU";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// grdData
			// 
			this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdData.Location = new System.Drawing.Point(4, 107);
			this.grdData.MainView = this.grvData;
			this.grdData.Name = "grdData";
			this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
			this.grdData.Size = new System.Drawing.Size(1274, 755);
			this.grdData.TabIndex = 4;
			this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
			// 
			// grvData
			// 
			this.grvData.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Lime;
			this.grvData.Appearance.FocusedCell.Options.UseBorderColor = true;
			this.grvData.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(204)))));
			this.grvData.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White;
			this.grvData.Appearance.HeaderPanel.Options.UseBackColor = true;
			this.grvData.Appearance.HeaderPanel.Options.UseBorderColor = true;
			this.grvData.Appearance.HeaderPanel.Options.UseFont = true;
			this.grvData.Appearance.HeaderPanel.Options.UseForeColor = true;
			this.grvData.Appearance.HeaderPanel.Options.UseImage = true;
			this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
			this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.grvData.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.grvData.Appearance.ViewCaption.Options.UseTextOptions = true;
			this.grvData.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.grvData.ColumnPanelRowHeight = 50;
			this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductWorkingName,
            this.colStandardValue,
            this.colValueTypeText,
            this.colRealValue1,
            this.colRealValue2,
            this.colRealValue3,
            this.colRealValue4,
            this.colRealValue5,
            this.colRealValue6,
            this.colWorkingID,
            this.colComport,
            this.colMinValue,
            this.colMaxValue,
            this.colValueType,
            this.colCheckValueType,
            this.colSortOrder,
            this.colSSortOrder});
			this.grvData.GridControl = this.grdData;
			this.grvData.HorzScrollStep = 5;
			this.grvData.Name = "grvData";
			this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
			this.grvData.OptionsCustomization.AllowFilter = false;
			this.grvData.OptionsCustomization.AllowSort = false;
			this.grvData.OptionsFilter.AllowFilterEditor = false;
			this.grvData.OptionsFind.ShowCloseButton = false;
			this.grvData.OptionsLayout.Columns.AddNewColumns = false;
			this.grvData.OptionsLayout.Columns.RemoveOldColumns = false;
			this.grvData.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.grvData.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.grvData.OptionsView.ColumnAutoWidth = false;
			this.grvData.OptionsView.RowAutoHeight = true;
			this.grvData.OptionsView.ShowGroupPanel = false;
			this.grvData.PaintStyleName = "Flat";
			this.grvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvData_RowCellStyle);
			this.grvData.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvData_CellValueChanged);
			this.grvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvData_KeyDown);
			// 
			// colProductWorkingName
			// 
			this.colProductWorkingName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colProductWorkingName.AppearanceCell.Options.UseFont = true;
			this.colProductWorkingName.AppearanceCell.Options.UseTextOptions = true;
			this.colProductWorkingName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colProductWorkingName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colProductWorkingName.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.colProductWorkingName.AppearanceHeader.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.colProductWorkingName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
			this.colProductWorkingName.AppearanceHeader.Options.UseFont = true;
			this.colProductWorkingName.AppearanceHeader.Options.UseTextOptions = true;
			this.colProductWorkingName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colProductWorkingName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colProductWorkingName.Caption = "Mục kiểm tra";
			this.colProductWorkingName.ColumnEdit = this.repositoryItemMemoEdit1;
			this.colProductWorkingName.FieldName = "WorkingName";
			this.colProductWorkingName.Name = "colProductWorkingName";
			this.colProductWorkingName.OptionsColumn.AllowEdit = false;
			this.colProductWorkingName.OptionsColumn.AllowFocus = false;
			this.colProductWorkingName.Visible = true;
			this.colProductWorkingName.VisibleIndex = 0;
			this.colProductWorkingName.Width = 455;
			// 
			// colStandardValue
			// 
			this.colStandardValue.AppearanceCell.Options.UseTextOptions = true;
			this.colStandardValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colStandardValue.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colStandardValue.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colStandardValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.colStandardValue.AppearanceHeader.Options.UseFont = true;
			this.colStandardValue.AppearanceHeader.Options.UseTextOptions = true;
			this.colStandardValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colStandardValue.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colStandardValue.Caption = "Giá trị tiêu chuẩn";
			this.colStandardValue.ColumnEdit = this.repositoryItemMemoEdit2;
			this.colStandardValue.FieldName = "StandardValue";
			this.colStandardValue.Name = "colStandardValue";
			this.colStandardValue.OptionsColumn.AllowEdit = false;
			this.colStandardValue.OptionsColumn.AllowFocus = false;
			this.colStandardValue.OptionsColumn.AllowSize = false;
			this.colStandardValue.Visible = true;
			this.colStandardValue.VisibleIndex = 1;
			this.colStandardValue.Width = 217;
			// 
			// repositoryItemMemoEdit2
			// 
			this.repositoryItemMemoEdit2.Appearance.Options.UseTextOptions = true;
			this.repositoryItemMemoEdit2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.repositoryItemMemoEdit2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.repositoryItemMemoEdit2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
			// 
			// colValueTypeText
			// 
			this.colValueTypeText.AppearanceCell.Options.UseTextOptions = true;
			this.colValueTypeText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colValueTypeText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colValueTypeText.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colValueTypeText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
			this.colValueTypeText.AppearanceHeader.Options.UseFont = true;
			this.colValueTypeText.Caption = "Ghi chép";
			this.colValueTypeText.ColumnEdit = this.repositoryItemMemoEdit2;
			this.colValueTypeText.FieldName = "ValueTypeText";
			this.colValueTypeText.Name = "colValueTypeText";
			this.colValueTypeText.OptionsColumn.AllowEdit = false;
			this.colValueTypeText.OptionsColumn.AllowFocus = false;
			this.colValueTypeText.OptionsColumn.AllowSize = false;
			this.colValueTypeText.Visible = true;
			this.colValueTypeText.VisibleIndex = 2;
			this.colValueTypeText.Width = 70;
			// 
			// colRealValue1
			// 
			this.colRealValue1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
			this.colRealValue1.AppearanceCell.Options.UseFont = true;
			this.colRealValue1.AppearanceCell.Options.UseTextOptions = true;
			this.colRealValue1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colRealValue1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.colRealValue1.AppearanceHeader.Options.UseFont = true;
			this.colRealValue1.AppearanceHeader.Options.UseTextOptions = true;
			this.colRealValue1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue1.Caption = "#";
			this.colRealValue1.FieldName = "RealValue1";
			this.colRealValue1.Name = "colRealValue1";
			this.colRealValue1.OptionsColumn.AllowSize = false;
			this.colRealValue1.Visible = true;
			this.colRealValue1.VisibleIndex = 3;
			this.colRealValue1.Width = 85;
			// 
			// colRealValue2
			// 
			this.colRealValue2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
			this.colRealValue2.AppearanceCell.Options.UseFont = true;
			this.colRealValue2.AppearanceCell.Options.UseTextOptions = true;
			this.colRealValue2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colRealValue2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.colRealValue2.AppearanceHeader.Options.UseFont = true;
			this.colRealValue2.AppearanceHeader.Options.UseTextOptions = true;
			this.colRealValue2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue2.Caption = "#";
			this.colRealValue2.FieldName = "RealValue2";
			this.colRealValue2.Name = "colRealValue2";
			this.colRealValue2.OptionsColumn.AllowSize = false;
			this.colRealValue2.Visible = true;
			this.colRealValue2.VisibleIndex = 4;
			this.colRealValue2.Width = 85;
			// 
			// colRealValue3
			// 
			this.colRealValue3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
			this.colRealValue3.AppearanceCell.Options.UseFont = true;
			this.colRealValue3.AppearanceCell.Options.UseTextOptions = true;
			this.colRealValue3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colRealValue3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.colRealValue3.AppearanceHeader.Options.UseFont = true;
			this.colRealValue3.AppearanceHeader.Options.UseTextOptions = true;
			this.colRealValue3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue3.Caption = "#";
			this.colRealValue3.FieldName = "RealValue3";
			this.colRealValue3.Name = "colRealValue3";
			this.colRealValue3.OptionsColumn.AllowSize = false;
			this.colRealValue3.Visible = true;
			this.colRealValue3.VisibleIndex = 5;
			this.colRealValue3.Width = 85;
			// 
			// colRealValue4
			// 
			this.colRealValue4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
			this.colRealValue4.AppearanceCell.Options.UseFont = true;
			this.colRealValue4.AppearanceCell.Options.UseTextOptions = true;
			this.colRealValue4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue4.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colRealValue4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.colRealValue4.AppearanceHeader.Options.UseFont = true;
			this.colRealValue4.AppearanceHeader.Options.UseTextOptions = true;
			this.colRealValue4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue4.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue4.Caption = "#";
			this.colRealValue4.FieldName = "RealValue4";
			this.colRealValue4.Name = "colRealValue4";
			this.colRealValue4.OptionsColumn.AllowSize = false;
			this.colRealValue4.Visible = true;
			this.colRealValue4.VisibleIndex = 6;
			this.colRealValue4.Width = 85;
			// 
			// colRealValue5
			// 
			this.colRealValue5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
			this.colRealValue5.AppearanceCell.Options.UseFont = true;
			this.colRealValue5.AppearanceCell.Options.UseTextOptions = true;
			this.colRealValue5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue5.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colRealValue5.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.colRealValue5.AppearanceHeader.Options.UseFont = true;
			this.colRealValue5.AppearanceHeader.Options.UseTextOptions = true;
			this.colRealValue5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue5.Caption = "#";
			this.colRealValue5.FieldName = "RealValue5";
			this.colRealValue5.Name = "colRealValue5";
			this.colRealValue5.OptionsColumn.AllowSize = false;
			this.colRealValue5.Visible = true;
			this.colRealValue5.VisibleIndex = 7;
			this.colRealValue5.Width = 85;
			// 
			// colRealValue6
			// 
			this.colRealValue6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
			this.colRealValue6.AppearanceCell.Options.UseFont = true;
			this.colRealValue6.AppearanceCell.Options.UseTextOptions = true;
			this.colRealValue6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue6.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colRealValue6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
			this.colRealValue6.AppearanceHeader.Options.UseFont = true;
			this.colRealValue6.AppearanceHeader.Options.UseTextOptions = true;
			this.colRealValue6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colRealValue6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colRealValue6.Caption = "#";
			this.colRealValue6.FieldName = "RealValue6";
			this.colRealValue6.Name = "colRealValue6";
			this.colRealValue6.OptionsColumn.AllowSize = false;
			this.colRealValue6.Visible = true;
			this.colRealValue6.VisibleIndex = 8;
			this.colRealValue6.Width = 85;
			// 
			// colWorkingID
			// 
			this.colWorkingID.AppearanceCell.Options.UseTextOptions = true;
			this.colWorkingID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colWorkingID.AppearanceHeader.Options.UseTextOptions = true;
			this.colWorkingID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colWorkingID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colWorkingID.Caption = "WorkingID";
			this.colWorkingID.FieldName = "WorkingID";
			this.colWorkingID.Name = "colWorkingID";
			this.colWorkingID.OptionsColumn.AllowEdit = false;
			// 
			// colComport
			// 
			this.colComport.AppearanceCell.Options.UseTextOptions = true;
			this.colComport.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colComport.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.colComport.AppearanceHeader.Options.UseFont = true;
			this.colComport.AppearanceHeader.Options.UseTextOptions = true;
			this.colComport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colComport.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colComport.Caption = "Comport";
			this.colComport.FieldName = "Comport";
			this.colComport.Name = "colComport";
			this.colComport.OptionsColumn.AllowEdit = false;
			this.colComport.Width = 141;
			// 
			// colMinValue
			// 
			this.colMinValue.AppearanceCell.Options.UseTextOptions = true;
			this.colMinValue.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colMinValue.AppearanceHeader.Options.UseTextOptions = true;
			this.colMinValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colMinValue.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colMinValue.Caption = "MinValue";
			this.colMinValue.FieldName = "MinValue";
			this.colMinValue.Name = "colMinValue";
			this.colMinValue.OptionsColumn.AllowEdit = false;
			this.colMinValue.Width = 104;
			// 
			// colMaxValue
			// 
			this.colMaxValue.AppearanceCell.Options.UseTextOptions = true;
			this.colMaxValue.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colMaxValue.AppearanceHeader.Options.UseTextOptions = true;
			this.colMaxValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colMaxValue.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colMaxValue.Caption = "MaxValue";
			this.colMaxValue.FieldName = "MaxValue";
			this.colMaxValue.Name = "colMaxValue";
			this.colMaxValue.OptionsColumn.AllowEdit = false;
			// 
			// colValueType
			// 
			this.colValueType.Caption = "ValueType";
			this.colValueType.FieldName = "ValueType";
			this.colValueType.Name = "colValueType";
			// 
			// colCheckValueType
			// 
			this.colCheckValueType.Caption = "CheckValueType";
			this.colCheckValueType.FieldName = "CheckValueType";
			this.colCheckValueType.Name = "colCheckValueType";
			// 
			// colSortOrder
			// 
			this.colSortOrder.Caption = "SortOrder";
			this.colSortOrder.FieldName = "SortOrder";
			this.colSortOrder.Name = "colSortOrder";
			// 
			// colSSortOrder
			// 
			this.colSSortOrder.Caption = "SSortOrder";
			this.colSSortOrder.FieldName = "SSortOrder";
			this.colSSortOrder.Name = "colSSortOrder";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(796, 7);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(49, 23);
			this.textBox1.TabIndex = 5;
			this.textBox1.Tag = "1";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox1.TextAlignChanged += new System.EventHandler(this.textBox1_TextAlignChanged);
			this.textBox1.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			this.textBox1.GotFocus += new System.EventHandler(this.textBox_GotFocus);
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.BackColor = System.Drawing.Color.White;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(881, 7);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(49, 23);
			this.textBox2.TabIndex = 6;
			this.textBox2.Tag = "2";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			this.textBox2.GotFocus += new System.EventHandler(this.textBox_GotFocus);
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.BackColor = System.Drawing.Color.White;
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox3.Location = new System.Drawing.Point(967, 7);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(49, 23);
			this.textBox3.TabIndex = 7;
			this.textBox3.Tag = "3";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox3.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			this.textBox3.GotFocus += new System.EventHandler(this.textBox_GotFocus);
			this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.BackColor = System.Drawing.Color.White;
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox4.Location = new System.Drawing.Point(1052, 7);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(49, 23);
			this.textBox4.TabIndex = 8;
			this.textBox4.Tag = "4";
			this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox4.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			this.textBox4.GotFocus += new System.EventHandler(this.textBox_GotFocus);
			this.textBox4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.BackColor = System.Drawing.Color.White;
			this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox5.Location = new System.Drawing.Point(1137, 7);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(49, 23);
			this.textBox5.TabIndex = 9;
			this.textBox5.Tag = "5";
			this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox5.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			this.textBox5.GotFocus += new System.EventHandler(this.textBox_GotFocus);
			this.textBox5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.BackColor = System.Drawing.Color.White;
			this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox6.Location = new System.Drawing.Point(1223, 7);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(49, 23);
			this.textBox6.TabIndex = 10;
			this.textBox6.Tag = "6";
			this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox6.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			this.textBox6.GotFocus += new System.EventHandler(this.textBox_GotFocus);
			this.textBox6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
			// 
			// txtStepName
			// 
			this.txtStepName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStepName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtStepName.Location = new System.Drawing.Point(587, 36);
			this.txtStepName.Multiline = true;
			this.txtStepName.Name = "txtStepName";
			this.txtStepName.ReadOnly = true;
			this.txtStepName.Size = new System.Drawing.Size(586, 29);
			this.txtStepName.TabIndex = 14;
			// 
			// txtOrder
			// 
			this.txtOrder.BackColor = System.Drawing.Color.White;
			this.txtOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOrder.Location = new System.Drawing.Point(88, 36);
			this.txtOrder.Name = "txtOrder";
			this.txtOrder.Size = new System.Drawing.Size(240, 29);
			this.txtOrder.TabIndex = 1;
			this.txtOrder.TextChanged += new System.EventHandler(this.txt_TextChanged);
			this.txtOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOrder_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(4, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "NHẬP ORDER";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(282, 596);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
			this.menuStrip1.Size = new System.Drawing.Size(31, 24);
			this.menuStrip1.TabIndex = 16;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// aToolStripMenuItem
			// 
			this.aToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cấtToolStripMenuItem,
            this.startRiskToolStripMenuItem,
            this.endRiskToolStripMenuItem,
            this.loginToolStripMenuItem});
			this.aToolStripMenuItem.Name = "aToolStripMenuItem";
			this.aToolStripMenuItem.Size = new System.Drawing.Size(25, 22);
			this.aToolStripMenuItem.Text = "a";
			// 
			// cấtToolStripMenuItem
			// 
			this.cấtToolStripMenuItem.Name = "cấtToolStripMenuItem";
			this.cấtToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
			this.cấtToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.cấtToolStripMenuItem.Text = "Cất";
			this.cấtToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// startRiskToolStripMenuItem
			// 
			this.startRiskToolStripMenuItem.Name = "startRiskToolStripMenuItem";
			this.startRiskToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.startRiskToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.startRiskToolStripMenuItem.Text = "StartRisk";
			this.startRiskToolStripMenuItem.Click += new System.EventHandler(this.startRiskToolStripMenuItem_Click);
			// 
			// endRiskToolStripMenuItem
			// 
			this.endRiskToolStripMenuItem.Name = "endRiskToolStripMenuItem";
			this.endRiskToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
			this.endRiskToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.endRiskToolStripMenuItem.Text = "EndRisk";
			this.endRiskToolStripMenuItem.Click += new System.EventHandler(this.endRiskToolStripMenuItem_Click);
			// 
			// loginToolStripMenuItem
			// 
			this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
			this.loginToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
			this.loginToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.loginToolStripMenuItem.Text = "Login";
			this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.BackColor = System.Drawing.Color.White;
			this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(445, 68);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(832, 29);
			this.txtName.TabIndex = 3;
			this.txtName.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(335, 76);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "TÊN SP";
			// 
			// txtMo
			// 
			this.txtMo.BackColor = System.Drawing.Color.White;
			this.txtMo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMo.Location = new System.Drawing.Point(89, 68);
			this.txtMo.Name = "txtMo";
			this.txtMo.ReadOnly = true;
			this.txtMo.Size = new System.Drawing.Size(240, 29);
			this.txtMo.TabIndex = 3;
			this.txtMo.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(5, 76);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "LOẠI MỠ";
			// 
			// txtGoal
			// 
			this.txtGoal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtGoal.Location = new System.Drawing.Point(1180, 4);
			this.txtGoal.Name = "txtGoal";
			this.txtGoal.ReadOnly = true;
			this.txtGoal.Size = new System.Drawing.Size(97, 29);
			this.txtGoal.TabIndex = 18;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(1137, 12);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "ĐÍCH";
			// 
			// txtTimeDelay
			// 
			this.txtTimeDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTimeDelay.BackColor = System.Drawing.Color.Yellow;
			this.txtTimeDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTimeDelay.Location = new System.Drawing.Point(407, 7);
			this.txtTimeDelay.Name = "txtTimeDelay";
			this.txtTimeDelay.ReadOnly = true;
			this.txtTimeDelay.Size = new System.Drawing.Size(56, 23);
			this.txtTimeDelay.TabIndex = 19;
			this.txtTimeDelay.Text = "0";
			this.txtTimeDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(340, 10);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 17);
			this.label8.TabIndex = 20;
			this.label8.Text = "Delay(s)";
			// 
			// btnNotUseCD8
			// 
			this.btnNotUseCD8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNotUseCD8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNotUseCD8.Location = new System.Drawing.Point(3, 7);
			this.btnNotUseCD8.Name = "btnNotUseCD8";
			this.btnNotUseCD8.Size = new System.Drawing.Size(195, 55);
			this.btnNotUseCD8.TabIndex = 11;
			this.btnNotUseCD8.Text = "Không sử dụng";
			this.btnNotUseCD8.UseVisualStyleBackColor = true;
			this.btnNotUseCD8.Visible = false;
			this.btnNotUseCD8.Click += new System.EventHandler(this.btnNotUseCD8_Click);
			// 
			// txtNumDelay
			// 
			this.txtNumDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtNumDelay.BackColor = System.Drawing.Color.Yellow;
			this.txtNumDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumDelay.Location = new System.Drawing.Point(407, 36);
			this.txtNumDelay.Name = "txtNumDelay";
			this.txtNumDelay.ReadOnly = true;
			this.txtNumDelay.Size = new System.Drawing.Size(56, 23);
			this.txtNumDelay.TabIndex = 22;
			this.txtNumDelay.Text = "0";
			this.txtNumDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.txtQtyReal);
			this.panelTop.Controls.Add(this.txtQty);
			this.panelTop.Controls.Add(this.label12);
			this.panelTop.Controls.Add(this.label11);
			this.panelTop.Controls.Add(this.cboSub);
			this.panelTop.Controls.Add(this.txtSalesOrder);
			this.panelTop.Controls.Add(this.label9);
			this.panelTop.Controls.Add(this.txtOrder);
			this.panelTop.Controls.Add(this.txtQRCode);
			this.panelTop.Controls.Add(this.txtWorker);
			this.panelTop.Controls.Add(this.txtName);
			this.panelTop.Controls.Add(this.txtMo);
			this.panelTop.Controls.Add(this.label1);
			this.panelTop.Controls.Add(this.label4);
			this.panelTop.Controls.Add(this.label2);
			this.panelTop.Controls.Add(this.label5);
			this.panelTop.Controls.Add(this.label6);
			this.panelTop.Controls.Add(this.label3);
			this.panelTop.Controls.Add(this.cboWorkingStep);
			this.panelTop.Controls.Add(this.txtStepName);
			this.panelTop.Controls.Add(this.label7);
			this.panelTop.Controls.Add(this.txtGoal);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Margin = new System.Windows.Forms.Padding(2);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(1280, 102);
			this.panelTop.TabIndex = 26;
			// 
			// txtQtyReal
			// 
			this.txtQtyReal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtQtyReal.BackColor = System.Drawing.SystemColors.Control;
			this.txtQtyReal.Enabled = false;
			this.txtQtyReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQtyReal.Location = new System.Drawing.Point(1068, 4);
			this.txtQtyReal.Name = "txtQtyReal";
			this.txtQtyReal.ReadOnly = true;
			this.txtQtyReal.Size = new System.Drawing.Size(63, 29);
			this.txtQtyReal.TabIndex = 33;
			// 
			// txtQty
			// 
			this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtQty.BackColor = System.Drawing.SystemColors.Control;
			this.txtQty.Enabled = false;
			this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQty.Location = new System.Drawing.Point(943, 4);
			this.txtQty.Name = "txtQty";
			this.txtQty.ReadOnly = true;
			this.txtQty.Size = new System.Drawing.Size(63, 29);
			this.txtQty.TabIndex = 32;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(1012, 12);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(54, 13);
			this.label12.TabIndex = 31;
			this.label12.Text = "THỰC TẾ";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(873, 12);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 13);
			this.label11.TabIndex = 30;
			this.label11.Text = "SỐ LƯỢNG";
			// 
			// cboSub
			// 
			this.cboSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboSub.BackColor = System.Drawing.Color.White;
			this.cboSub.Cursor = System.Windows.Forms.Cursors.Default;
			this.cboSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboSub.FormattingEnabled = true;
			this.cboSub.Items.AddRange(new object[] {
            "Line 1",
            "Line 2",
            "Line 3"});
			this.cboSub.Location = new System.Drawing.Point(1179, 35);
			this.cboSub.Name = "cboSub";
			this.cboSub.Size = new System.Drawing.Size(97, 30);
			this.cboSub.TabIndex = 25;
			// 
			// txtSalesOrder
			// 
			this.txtSalesOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSalesOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSalesOrder.Location = new System.Drawing.Point(676, 4);
			this.txtSalesOrder.Name = "txtSalesOrder";
			this.txtSalesOrder.ReadOnly = true;
			this.txtSalesOrder.Size = new System.Drawing.Size(191, 29);
			this.txtSalesOrder.TabIndex = 20;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(588, 12);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(82, 13);
			this.label9.TabIndex = 19;
			this.label9.Text = "SALES ORDER";
			// 
			// pannelBot
			// 
			this.pannelBot.Controls.Add(this.btnShow);
			this.pannelBot.Controls.Add(this.lblTakt);
			this.pannelBot.Controls.Add(this.lblCD);
			this.pannelBot.Controls.Add(this.btnSave);
			this.pannelBot.Controls.Add(this.txtNumDelay);
			this.pannelBot.Controls.Add(this.btnNotUseCD8);
			this.pannelBot.Controls.Add(this.textBox1);
			this.pannelBot.Controls.Add(this.textBox2);
			this.pannelBot.Controls.Add(this.textBox3);
			this.pannelBot.Controls.Add(this.textBox4);
			this.pannelBot.Controls.Add(this.textBox5);
			this.pannelBot.Controls.Add(this.textBox6);
			this.pannelBot.Controls.Add(this.txtTimeDelay);
			this.pannelBot.Controls.Add(this.label8);
			this.pannelBot.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pannelBot.Location = new System.Drawing.Point(0, 858);
			this.pannelBot.Margin = new System.Windows.Forms.Padding(2);
			this.pannelBot.Name = "pannelBot";
			this.pannelBot.Size = new System.Drawing.Size(1280, 103);
			this.pannelBot.TabIndex = 27;
			// 
			// btnShow
			// 
			this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnShow.Location = new System.Drawing.Point(588, 7);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(141, 52);
			this.btnShow.TabIndex = 25;
			this.btnShow.Text = "Xem Bản Vẽ";
			this.btnShow.UseVisualStyleBackColor = true;
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// lblTakt
			// 
			this.lblTakt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTakt.BackColor = System.Drawing.Color.Blue;
			this.lblTakt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTakt.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTakt.ForeColor = System.Drawing.Color.Red;
			this.lblTakt.Location = new System.Drawing.Point(477, 8);
			this.lblTakt.Name = "lblTakt";
			this.lblTakt.Size = new System.Drawing.Size(105, 52);
			this.lblTakt.TabIndex = 24;
			this.lblTakt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblCD
			// 
			this.lblCD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblCD.BackColor = System.Drawing.Color.Silver;
			this.lblCD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCD.Location = new System.Drawing.Point(204, 8);
			this.lblCD.Margin = new System.Windows.Forms.Padding(0);
			this.lblCD.Name = "lblCD";
			this.lblCD.Size = new System.Drawing.Size(125, 52);
			this.lblCD.TabIndex = 23;
			this.lblCD.Text = "CD";
			this.lblCD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timerShowCanMo
			// 
			this.timerShowCanMo.Tick += new System.EventHandler(this.timerShowCanMo_Tick);
			// 
			// frmProductCheckHistory1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1280, 961);
			this.Controls.Add(this.pannelBot);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.grdData);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "frmProductCheckHistory1";
			this.Text = "KIỂM TRA THEO CÔNG ĐOẠN";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProductCheckHistory_FormClosed);
			this.Load += new System.EventHandler(this.frmProductCheckHistory1_Load);
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.pannelBot.ResumeLayout(false);
			this.pannelBot.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.TextBox txtQRCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboWorkingStep;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colProductWorkingName;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkingID;
        private DevExpress.XtraGrid.Columns.GridColumn colComport;
        private DevExpress.XtraGrid.Columns.GridColumn colMinValue;
        private DevExpress.XtraGrid.Columns.GridColumn colStandardValue;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxValue;
        private DevExpress.XtraGrid.Columns.GridColumn colRealValue2;
        private DevExpress.XtraGrid.Columns.GridColumn colRealValue6;
        private DevExpress.XtraGrid.Columns.GridColumn colRealValue4;
        private DevExpress.XtraGrid.Columns.GridColumn colRealValue1;
        private DevExpress.XtraGrid.Columns.GridColumn colRealValue3;
        private DevExpress.XtraGrid.Columns.GridColumn colRealValue5;
        private DevExpress.XtraGrid.Columns.GridColumn colValueType;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private DevExpress.XtraGrid.Columns.GridColumn colValueTypeText;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private System.Windows.Forms.TextBox txtStepName;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckValueType;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn colSortOrder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cấtToolStripMenuItem;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMo;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn colSSortOrder;
        private System.Windows.Forms.ToolStripMenuItem startRiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endRiskToolStripMenuItem;
        private System.Windows.Forms.TextBox txtGoal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTimeDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNotUseCD8;
		private System.Windows.Forms.TextBox txtNumDelay;
		private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Panel pannelBot;
		private System.Windows.Forms.Label lblCD;
		private System.Windows.Forms.Label lblTakt;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtSalesOrder;
		private System.Windows.Forms.ComboBox cboSub;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.TextBox txtQtyReal;
		private System.Windows.Forms.TextBox txtQty;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Timer timerShowCanMo;
	}
}