namespace TotalCommanderWinForms
{
    partial class MainWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftDataView = new System.Windows.Forms.DataGridView();
            this.leftImgColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.leftNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftExtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftSizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftAttrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftPathInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.leftDiskSpaceInfo = new System.Windows.Forms.Label();
            this.leftDiskDropDown = new System.Windows.Forms.ComboBox();
            this.rightDataView = new System.Windows.Forms.DataGridView();
            this.rightImgColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.rightNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightExtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightSizeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightAttrColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightPathInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rightDiskSpaceInfo = new System.Windows.Forms.Label();
            this.rightDiskDropDown = new System.Windows.Forms.ComboBox();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.СommandsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.swapBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.backBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.цветаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowerPanel = new System.Windows.Forms.Panel();
            this.createDirBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.transferBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.pasteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftDataView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightDataView)).BeginInit();
            this.panel2.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.lowerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 28);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(4);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.leftDataView);
            this.MainSplitContainer.Panel1.Controls.Add(this.leftPathInfo);
            this.MainSplitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.rightDataView);
            this.MainSplitContainer.Panel2.Controls.Add(this.rightPathInfo);
            this.MainSplitContainer.Panel2.Controls.Add(this.panel2);
            this.MainSplitContainer.Size = new System.Drawing.Size(1067, 498);
            this.MainSplitContainer.SplitterDistance = 477;
            this.MainSplitContainer.SplitterWidth = 5;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // leftDataView
            // 
            this.leftDataView.AllowDrop = true;
            this.leftDataView.AllowUserToAddRows = false;
            this.leftDataView.AllowUserToDeleteRows = false;
            this.leftDataView.AllowUserToResizeRows = false;
            this.leftDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.leftDataView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.leftDataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.leftDataView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.leftDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leftDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.leftImgColumn,
            this.leftNameColumn,
            this.leftExtColumn,
            this.leftSizeColumn,
            this.leftDateColumn,
            this.leftAttrColumn});
            this.leftDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftDataView.Location = new System.Drawing.Point(0, 52);
            this.leftDataView.Margin = new System.Windows.Forms.Padding(4);
            this.leftDataView.Name = "leftDataView";
            this.leftDataView.RowHeadersVisible = false;
            this.leftDataView.RowHeadersWidth = 51;
            this.leftDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.leftDataView.Size = new System.Drawing.Size(473, 442);
            this.leftDataView.TabIndex = 3;
            this.leftDataView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
            this.leftDataView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellEndEdit);
            this.leftDataView.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.leftDataView.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // leftImgColumn
            // 
            this.leftImgColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle1.NullValue")));
            this.leftImgColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.leftImgColumn.FillWeight = 60.9137F;
            this.leftImgColumn.HeaderText = "Img";
            this.leftImgColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.leftImgColumn.MinimumWidth = 35;
            this.leftImgColumn.Name = "leftImgColumn";
            this.leftImgColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.leftImgColumn.Width = 35;
            // 
            // leftNameColumn
            // 
            this.leftNameColumn.FillWeight = 107.8173F;
            this.leftNameColumn.HeaderText = "Name";
            this.leftNameColumn.MinimumWidth = 6;
            this.leftNameColumn.Name = "leftNameColumn";
            // 
            // leftExtColumn
            // 
            this.leftExtColumn.FillWeight = 107.8173F;
            this.leftExtColumn.HeaderText = "Ext";
            this.leftExtColumn.MinimumWidth = 6;
            this.leftExtColumn.Name = "leftExtColumn";
            this.leftExtColumn.ReadOnly = true;
            // 
            // leftSizeColumn
            // 
            this.leftSizeColumn.FillWeight = 107.8173F;
            this.leftSizeColumn.HeaderText = "Size";
            this.leftSizeColumn.MinimumWidth = 6;
            this.leftSizeColumn.Name = "leftSizeColumn";
            this.leftSizeColumn.ReadOnly = true;
            // 
            // leftDateColumn
            // 
            this.leftDateColumn.FillWeight = 107.8173F;
            this.leftDateColumn.HeaderText = "Date";
            this.leftDateColumn.MinimumWidth = 6;
            this.leftDateColumn.Name = "leftDateColumn";
            this.leftDateColumn.ReadOnly = true;
            // 
            // leftAttrColumn
            // 
            this.leftAttrColumn.FillWeight = 107.8173F;
            this.leftAttrColumn.HeaderText = "Attr";
            this.leftAttrColumn.MinimumWidth = 6;
            this.leftAttrColumn.Name = "leftAttrColumn";
            this.leftAttrColumn.ReadOnly = true;
            // 
            // leftPathInfo
            // 
            this.leftPathInfo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.leftPathInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftPathInfo.Location = new System.Drawing.Point(0, 26);
            this.leftPathInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.leftPathInfo.Name = "leftPathInfo";
            this.leftPathInfo.Size = new System.Drawing.Size(473, 26);
            this.leftPathInfo.TabIndex = 2;
            this.leftPathInfo.Text = "Путь: ";
            this.leftPathInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.leftDiskSpaceInfo);
            this.panel1.Controls.Add(this.leftDiskDropDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 26);
            this.panel1.TabIndex = 1;
            // 
            // leftDiskSpaceInfo
            // 
            this.leftDiskSpaceInfo.BackColor = System.Drawing.SystemColors.Control;
            this.leftDiskSpaceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftDiskSpaceInfo.Location = new System.Drawing.Point(56, 0);
            this.leftDiskSpaceInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.leftDiskSpaceInfo.Name = "leftDiskSpaceInfo";
            this.leftDiskSpaceInfo.Size = new System.Drawing.Size(417, 26);
            this.leftDiskSpaceInfo.TabIndex = 5;
            this.leftDiskSpaceInfo.Text = "0 из 0 свободно";
            this.leftDiskSpaceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // leftDiskDropDown
            // 
            this.leftDiskDropDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftDiskDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftDiskDropDown.FormattingEnabled = true;
            this.leftDiskDropDown.Location = new System.Drawing.Point(0, 0);
            this.leftDiskDropDown.Margin = new System.Windows.Forms.Padding(4);
            this.leftDiskDropDown.Name = "leftDiskDropDown";
            this.leftDiskDropDown.Size = new System.Drawing.Size(56, 24);
            this.leftDiskDropDown.TabIndex = 4;
            this.leftDiskDropDown.SelectedIndexChanged += new System.EventHandler(this.leftDiskDropDown_SelectedIndexChanged);
            // 
            // rightDataView
            // 
            this.rightDataView.AllowDrop = true;
            this.rightDataView.AllowUserToAddRows = false;
            this.rightDataView.AllowUserToDeleteRows = false;
            this.rightDataView.AllowUserToResizeRows = false;
            this.rightDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rightDataView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.rightDataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rightDataView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.rightDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rightDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rightImgColumn,
            this.rightNameColumn,
            this.rightExtColumn,
            this.rightSizeColumn,
            this.rightDateColumn,
            this.rightAttrColumn});
            this.rightDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightDataView.Location = new System.Drawing.Point(0, 52);
            this.rightDataView.Margin = new System.Windows.Forms.Padding(4);
            this.rightDataView.Name = "rightDataView";
            this.rightDataView.RowHeadersVisible = false;
            this.rightDataView.RowHeadersWidth = 51;
            this.rightDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rightDataView.Size = new System.Drawing.Size(581, 442);
            this.rightDataView.TabIndex = 6;
            this.rightDataView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellDoubleClick);
            this.rightDataView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellEndEdit);
            this.rightDataView.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.rightDataView.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            // 
            // rightImgColumn
            // 
            this.rightImgColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            this.rightImgColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.rightImgColumn.FillWeight = 60.9137F;
            this.rightImgColumn.HeaderText = "Img";
            this.rightImgColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.rightImgColumn.MinimumWidth = 35;
            this.rightImgColumn.Name = "rightImgColumn";
            this.rightImgColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rightImgColumn.Width = 35;
            // 
            // rightNameColumn
            // 
            this.rightNameColumn.FillWeight = 107.8173F;
            this.rightNameColumn.HeaderText = "Name";
            this.rightNameColumn.MinimumWidth = 6;
            this.rightNameColumn.Name = "rightNameColumn";
            // 
            // rightExtColumn
            // 
            this.rightExtColumn.FillWeight = 107.8173F;
            this.rightExtColumn.HeaderText = "Ext";
            this.rightExtColumn.MinimumWidth = 6;
            this.rightExtColumn.Name = "rightExtColumn";
            this.rightExtColumn.ReadOnly = true;
            // 
            // rightSizeColumn
            // 
            this.rightSizeColumn.FillWeight = 107.8173F;
            this.rightSizeColumn.HeaderText = "Size";
            this.rightSizeColumn.MinimumWidth = 6;
            this.rightSizeColumn.Name = "rightSizeColumn";
            this.rightSizeColumn.ReadOnly = true;
            // 
            // rightDateColumn
            // 
            this.rightDateColumn.FillWeight = 107.8173F;
            this.rightDateColumn.HeaderText = "Date";
            this.rightDateColumn.MinimumWidth = 6;
            this.rightDateColumn.Name = "rightDateColumn";
            this.rightDateColumn.ReadOnly = true;
            // 
            // rightAttrColumn
            // 
            this.rightAttrColumn.FillWeight = 107.8173F;
            this.rightAttrColumn.HeaderText = "Attr";
            this.rightAttrColumn.MinimumWidth = 6;
            this.rightAttrColumn.Name = "rightAttrColumn";
            this.rightAttrColumn.ReadOnly = true;
            // 
            // rightPathInfo
            // 
            this.rightPathInfo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.rightPathInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightPathInfo.Location = new System.Drawing.Point(0, 26);
            this.rightPathInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rightPathInfo.Name = "rightPathInfo";
            this.rightPathInfo.Size = new System.Drawing.Size(581, 26);
            this.rightPathInfo.TabIndex = 5;
            this.rightPathInfo.Text = "Путь: ";
            this.rightPathInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rightDiskSpaceInfo);
            this.panel2.Controls.Add(this.rightDiskDropDown);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(581, 26);
            this.panel2.TabIndex = 4;
            // 
            // rightDiskSpaceInfo
            // 
            this.rightDiskSpaceInfo.BackColor = System.Drawing.SystemColors.Control;
            this.rightDiskSpaceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightDiskSpaceInfo.Location = new System.Drawing.Point(56, 0);
            this.rightDiskSpaceInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rightDiskSpaceInfo.Name = "rightDiskSpaceInfo";
            this.rightDiskSpaceInfo.Size = new System.Drawing.Size(525, 26);
            this.rightDiskSpaceInfo.TabIndex = 3;
            this.rightDiskSpaceInfo.Text = "0 из 0 свободно";
            this.rightDiskSpaceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rightDiskDropDown
            // 
            this.rightDiskDropDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.rightDiskDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rightDiskDropDown.FormattingEnabled = true;
            this.rightDiskDropDown.Location = new System.Drawing.Point(0, 0);
            this.rightDiskDropDown.Margin = new System.Windows.Forms.Padding(4);
            this.rightDiskDropDown.Name = "rightDiskDropDown";
            this.rightDiskDropDown.Size = new System.Drawing.Size(56, 24);
            this.rightDiskDropDown.TabIndex = 0;
            this.rightDiskDropDown.SelectedIndexChanged += new System.EventHandler(this.leftDiskDropDown_SelectedIndexChanged);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.СommandsToolStrip,
            this.настройкиToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1067, 28);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // СommandsToolStrip
            // 
            this.СommandsToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.swapBtn,
            this.equalizeBtn,
            this.backBtn});
            this.СommandsToolStrip.Name = "СommandsToolStrip";
            this.СommandsToolStrip.Size = new System.Drawing.Size(88, 24);
            this.СommandsToolStrip.Text = "Команды";
            // 
            // swapBtn
            // 
            this.swapBtn.Name = "swapBtn";
            this.swapBtn.Size = new System.Drawing.Size(281, 26);
            this.swapBtn.Text = "Поменять панели местами";
            this.swapBtn.Click += new System.EventHandler(this.OnSwapBtnClick);
            // 
            // equalizeBtn
            // 
            this.equalizeBtn.Name = "equalizeBtn";
            this.equalizeBtn.Size = new System.Drawing.Size(281, 26);
            this.equalizeBtn.Text = "Сравнять панели";
            this.equalizeBtn.Click += new System.EventHandler(this.OnEqualizeBtnClick);
            // 
            // backBtn
            // 
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(281, 26);
            this.backBtn.Text = "Назад";
            this.backBtn.Click += new System.EventHandler(this.OnBackBtnClick);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шрифтToolStripMenuItem,
            this.цветаToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // шрифтToolStripMenuItem
            // 
            this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
            this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.шрифтToolStripMenuItem.Text = "Шрифт";
            // 
            // цветаToolStripMenuItem
            // 
            this.цветаToolStripMenuItem.Name = "цветаToolStripMenuItem";
            this.цветаToolStripMenuItem.Size = new System.Drawing.Size(140, 26);
            this.цветаToolStripMenuItem.Text = "Цвета";
            // 
            // lowerPanel
            // 
            this.lowerPanel.Controls.Add(this.createDirBtn);
            this.lowerPanel.Controls.Add(this.deleteBtn);
            this.lowerPanel.Controls.Add(this.transferBtn);
            this.lowerPanel.Controls.Add(this.copyBtn);
            this.lowerPanel.Controls.Add(this.pasteBtn);
            this.lowerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lowerPanel.Location = new System.Drawing.Point(0, 526);
            this.lowerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.lowerPanel.Name = "lowerPanel";
            this.lowerPanel.Size = new System.Drawing.Size(1067, 28);
            this.lowerPanel.TabIndex = 3;
            this.lowerPanel.SizeChanged += new System.EventHandler(this.OnLowerPanelSizeChanged);
            // 
            // createDirBtn
            // 
            this.createDirBtn.BackColor = System.Drawing.Color.Lime;
            this.createDirBtn.FlatAppearance.BorderSize = 0;
            this.createDirBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createDirBtn.Location = new System.Drawing.Point(473, 0);
            this.createDirBtn.Margin = new System.Windows.Forms.Padding(4);
            this.createDirBtn.Name = "createDirBtn";
            this.createDirBtn.Size = new System.Drawing.Size(148, 28);
            this.createDirBtn.TabIndex = 10;
            this.createDirBtn.Text = "Создать папку";
            this.createDirBtn.UseVisualStyleBackColor = false;
            this.createDirBtn.Click += new System.EventHandler(this.OnCreateDirClick);
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.Lime;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Location = new System.Drawing.Point(356, 0);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(109, 28);
            this.deleteBtn.TabIndex = 9;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.OnDeleteClick);
            // 
            // transferBtn
            // 
            this.transferBtn.BackColor = System.Drawing.Color.Lime;
            this.transferBtn.FlatAppearance.BorderSize = 0;
            this.transferBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transferBtn.Location = new System.Drawing.Point(121, 0);
            this.transferBtn.Margin = new System.Windows.Forms.Padding(4);
            this.transferBtn.Name = "transferBtn";
            this.transferBtn.Size = new System.Drawing.Size(109, 28);
            this.transferBtn.TabIndex = 8;
            this.transferBtn.Text = "Перенести";
            this.transferBtn.UseVisualStyleBackColor = false;
            this.transferBtn.Click += new System.EventHandler(this.OnTransferClick);
            // 
            // copyBtn
            // 
            this.copyBtn.BackColor = System.Drawing.Color.Lime;
            this.copyBtn.FlatAppearance.BorderSize = 0;
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyBtn.Location = new System.Drawing.Point(4, 0);
            this.copyBtn.Margin = new System.Windows.Forms.Padding(4);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(109, 28);
            this.copyBtn.TabIndex = 7;
            this.copyBtn.Text = "Копировать";
            this.copyBtn.UseVisualStyleBackColor = false;
            this.copyBtn.Click += new System.EventHandler(this.OnCopyClick);
            // 
            // pasteBtn
            // 
            this.pasteBtn.BackColor = System.Drawing.Color.Lime;
            this.pasteBtn.FlatAppearance.BorderSize = 0;
            this.pasteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pasteBtn.Location = new System.Drawing.Point(239, 0);
            this.pasteBtn.Margin = new System.Windows.Forms.Padding(4);
            this.pasteBtn.Name = "pasteBtn";
            this.pasteBtn.Size = new System.Drawing.Size(109, 28);
            this.pasteBtn.TabIndex = 6;
            this.pasteBtn.Text = "Вставить";
            this.pasteBtn.UseVisualStyleBackColor = false;
            this.pasteBtn.Click += new System.EventHandler(this.OnPasteClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.lowerPanel);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(699, 271);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тотальный коммандир";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftDataView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightDataView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.lowerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem СommandsToolStrip;
        private System.Windows.Forms.DataGridView leftDataView;
        private System.Windows.Forms.Label leftPathInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label leftDiskSpaceInfo;
        private System.Windows.Forms.ComboBox leftDiskDropDown;
        private System.Windows.Forms.Label rightPathInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label rightDiskSpaceInfo;
        private System.Windows.Forms.ComboBox rightDiskDropDown;
        private System.Windows.Forms.DataGridViewImageColumn leftImgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftExtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftSizeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftAttrColumn;
        private System.Windows.Forms.DataGridView rightDataView;
        private System.Windows.Forms.Panel lowerPanel;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button transferBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button pasteBtn;
        private System.Windows.Forms.Button createDirBtn;
        private System.Windows.Forms.DataGridViewImageColumn rightImgColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightExtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightSizeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightAttrColumn;
        private System.Windows.Forms.ToolStripMenuItem swapBtn;
        private System.Windows.Forms.ToolStripMenuItem equalizeBtn;
        private System.Windows.Forms.ToolStripMenuItem backBtn;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem цветаToolStripMenuItem;
    }
}