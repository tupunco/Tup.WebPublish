﻿namespace Tup.WebPublish
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ButtonGo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LabelSrcProjectFile = new System.Windows.Forms.Label();
            this.DefaultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonSelectOutFolder = new System.Windows.Forms.Button();
            this.ButtonSelectSrcFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxSelectFolder = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxOutFolder = new System.Windows.Forms.TextBox();
            this.TextBoxSrcFolder = new System.Windows.Forms.TextBox();
            this.DateTimePickerFilter = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TextBoxMsg = new System.Windows.Forms.TextBox();
            this.TreeViewOutFolder = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(585, 511);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ButtonGo);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.DateTimePickerFilter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(579, 152);
            this.panel3.TabIndex = 0;
            // 
            // ButtonGo
            // 
            this.ButtonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGo.Location = new System.Drawing.Point(456, 49);
            this.ButtonGo.Name = "ButtonGo";
            this.ButtonGo.Size = new System.Drawing.Size(92, 84);
            this.ButtonGo.TabIndex = 6;
            this.ButtonGo.Text = "GO";
            this.ButtonGo.UseVisualStyleBackColor = true;
            this.ButtonGo.Click += new System.EventHandler(this.ButtonGo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LabelSrcProjectFile);
            this.groupBox1.Controls.Add(this.ButtonSelectOutFolder);
            this.groupBox1.Controls.Add(this.ButtonSelectSrcFolder);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ComboBoxSelectFolder);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextBoxOutFolder);
            this.groupBox1.Controls.Add(this.TextBoxSrcFolder);
            this.groupBox1.Location = new System.Drawing.Point(3, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目录选择";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "源项目文件";
            // 
            // LabelSrcProjectFile
            // 
            this.LabelSrcProjectFile.AutoSize = true;
            this.LabelSrcProjectFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultBindingSource, "SrcProjectFile", true));
            this.LabelSrcProjectFile.Location = new System.Drawing.Point(89, 116);
            this.LabelSrcProjectFile.Name = "LabelSrcProjectFile";
            this.LabelSrcProjectFile.Size = new System.Drawing.Size(0, 12);
            this.LabelSrcProjectFile.TabIndex = 5;
            // 
            // DefaultBindingSource
            // 
            this.DefaultBindingSource.DataSource = typeof(Tup.WebPublish.Catalog);
            // 
            // ButtonSelectOutFolder
            // 
            this.ButtonSelectOutFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelectOutFolder.Location = new System.Drawing.Point(358, 80);
            this.ButtonSelectOutFolder.Name = "ButtonSelectOutFolder";
            this.ButtonSelectOutFolder.Size = new System.Drawing.Size(46, 23);
            this.ButtonSelectOutFolder.TabIndex = 4;
            this.ButtonSelectOutFolder.Text = "...";
            this.ButtonSelectOutFolder.UseVisualStyleBackColor = true;
            this.ButtonSelectOutFolder.Click += new System.EventHandler(this.ButtonSelectOutFolder_Click);
            // 
            // ButtonSelectSrcFolder
            // 
            this.ButtonSelectSrcFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSelectSrcFolder.Location = new System.Drawing.Point(358, 51);
            this.ButtonSelectSrcFolder.Name = "ButtonSelectSrcFolder";
            this.ButtonSelectSrcFolder.Size = new System.Drawing.Size(46, 23);
            this.ButtonSelectSrcFolder.TabIndex = 2;
            this.ButtonSelectSrcFolder.Text = "...";
            this.ButtonSelectSrcFolder.UseVisualStyleBackColor = true;
            this.ButtonSelectSrcFolder.Click += new System.EventHandler(this.ButtonSelectSrcFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "目标目录";
            // 
            // ComboBoxSelectFolder
            // 
            this.ComboBoxSelectFolder.DataSource = this.DefaultBindingSource;
            this.ComboBoxSelectFolder.DisplayMember = "Name";
            this.ComboBoxSelectFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSelectFolder.DropDownWidth = 250;
            this.ComboBoxSelectFolder.FormattingEnabled = true;
            this.ComboBoxSelectFolder.Location = new System.Drawing.Point(14, 20);
            this.ComboBoxSelectFolder.Name = "ComboBoxSelectFolder";
            this.ComboBoxSelectFolder.Size = new System.Drawing.Size(246, 20);
            this.ComboBoxSelectFolder.TabIndex = 0;
            this.ComboBoxSelectFolder.ValueMember = "Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "发布目录";
            // 
            // TextBoxOutFolder
            // 
            this.TextBoxOutFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxOutFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultBindingSource, "OutFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBoxOutFolder.Location = new System.Drawing.Point(91, 81);
            this.TextBoxOutFolder.Name = "TextBoxOutFolder";
            this.TextBoxOutFolder.Size = new System.Drawing.Size(261, 21);
            this.TextBoxOutFolder.TabIndex = 3;
            // 
            // TextBoxSrcFolder
            // 
            this.TextBoxSrcFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxSrcFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DefaultBindingSource, "SrcFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TextBoxSrcFolder.Location = new System.Drawing.Point(91, 51);
            this.TextBoxSrcFolder.Name = "TextBoxSrcFolder";
            this.TextBoxSrcFolder.Size = new System.Drawing.Size(261, 21);
            this.TextBoxSrcFolder.TabIndex = 1;
            // 
            // DateTimePickerFilter
            // 
            this.DateTimePickerFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePickerFilter.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.DateTimePickerFilter.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.DefaultBindingSource, "LastPublishTime", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DateTimePickerFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePickerFilter.Location = new System.Drawing.Point(419, 7);
            this.DateTimePickerFilter.Name = "DateTimePickerFilter";
            this.DateTimePickerFilter.Size = new System.Drawing.Size(151, 21);
            this.DateTimePickerFilter.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 161);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TextBoxMsg);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TreeViewOutFolder);
            this.splitContainer1.Size = new System.Drawing.Size(579, 347);
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 1;
            // 
            // TextBoxMsg
            // 
            this.TextBoxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxMsg.Location = new System.Drawing.Point(0, 0);
            this.TextBoxMsg.Multiline = true;
            this.TextBoxMsg.Name = "TextBoxMsg";
            this.TextBoxMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxMsg.Size = new System.Drawing.Size(579, 189);
            this.TextBoxMsg.TabIndex = 0;
            // 
            // TreeViewOutFolder
            // 
            this.TreeViewOutFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewOutFolder.Location = new System.Drawing.Point(0, 0);
            this.TreeViewOutFolder.Name = "TreeViewOutFolder";
            this.TreeViewOutFolder.Size = new System.Drawing.Size(579, 154);
            this.TreeViewOutFolder.TabIndex = 0;
            this.TreeViewOutFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewOutFolder_AfterSelect);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(585, 511);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(498, 394);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "站点发布工具";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TextBoxMsg;
        private System.Windows.Forms.TreeView TreeViewOutFolder;
        private System.Windows.Forms.ComboBox ComboBoxSelectFolder;
        private System.Windows.Forms.Button ButtonGo;
        private System.Windows.Forms.DateTimePicker DateTimePickerFilter;
        private System.Windows.Forms.TextBox TextBoxOutFolder;
        private System.Windows.Forms.TextBox TextBoxSrcFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonSelectOutFolder;
        private System.Windows.Forms.Button ButtonSelectSrcFolder;
        private System.Windows.Forms.BindingSource DefaultBindingSource;
        private System.Windows.Forms.Label LabelSrcProjectFile;
        private System.Windows.Forms.Label label3;
    }
}

