namespace Neustart.Forms
{
    partial class Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Interface));
            this.AppsTable = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crashes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uptime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnVisible = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnEnabled = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.appBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OptionsPane = new System.Windows.Forms.MenuStrip();
            this.NewAppButton = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AppsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appBindingSource)).BeginInit();
            this.OptionsPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // AppsTable
            // 
            this.AppsTable.AllowUserToAddRows = false;
            this.AppsTable.AllowUserToDeleteRows = false;
            this.AppsTable.AllowUserToResizeColumns = false;
            this.AppsTable.AllowUserToResizeRows = false;
            this.AppsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProcName,
            this.Crashes,
            this.Uptime,
            this.CPU,
            this.Ram,
            this.BtnVisible,
            this.BtnEnabled,
            this.BtnEdit});
            this.AppsTable.Location = new System.Drawing.Point(12, 27);
            this.AppsTable.Name = "AppsTable";
            this.AppsTable.ReadOnly = true;
            this.AppsTable.RowHeadersVisible = false;
            this.AppsTable.Size = new System.Drawing.Size(667, 236);
            this.AppsTable.TabIndex = 0;
            this.AppsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridClick);
            this.AppsTable.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataCellPaint);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 5;
            // 
            // ProcName
            // 
            this.ProcName.HeaderText = "Name";
            this.ProcName.Name = "ProcName";
            this.ProcName.ReadOnly = true;
            this.ProcName.Width = 267;
            // 
            // Crashes
            // 
            this.Crashes.FillWeight = 50F;
            this.Crashes.HeaderText = "Crashes";
            this.Crashes.Name = "Crashes";
            this.Crashes.ReadOnly = true;
            this.Crashes.Width = 50;
            // 
            // Uptime
            // 
            this.Uptime.FillWeight = 40F;
            this.Uptime.HeaderText = "Uptime";
            this.Uptime.Name = "Uptime";
            this.Uptime.ReadOnly = true;
            this.Uptime.Width = 50;
            // 
            // CPU
            // 
            this.CPU.FillWeight = 35F;
            this.CPU.HeaderText = "CPU";
            this.CPU.Name = "CPU";
            this.CPU.ReadOnly = true;
            this.CPU.Width = 45;
            // 
            // Ram
            // 
            this.Ram.FillWeight = 50F;
            this.Ram.HeaderText = "Memory";
            this.Ram.Name = "Memory";
            this.Ram.ReadOnly = true;
            this.Ram.Width = 60;
            // 
            // BtnVisible
            // 
            this.BtnVisible.HeaderText = "";
            this.BtnVisible.Name = "BtnVisible";
            this.BtnVisible.ReadOnly = true;
            this.BtnVisible.Width = 64;
            // 
            // BtnEnabled
            // 
            this.BtnEnabled.HeaderText = "";
            this.BtnEnabled.Name = "BtnEnabled";
            this.BtnEnabled.ReadOnly = true;
            this.BtnEnabled.Width = 64;
            // 
            // BtnEdit
            // 
            this.BtnEdit.HeaderText = "";
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.ReadOnly = true;
            this.BtnEdit.Width = 64;
            // 
            // OptionsPane
            // 
            this.OptionsPane.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.OptionsPane.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.OptionsPane.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewAppButton,
            this.gitHubToolStripMenuItem});
            this.OptionsPane.Location = new System.Drawing.Point(0, 0);
            this.OptionsPane.Name = "OptionsPane";
            this.OptionsPane.Size = new System.Drawing.Size(691, 24);
            this.OptionsPane.TabIndex = 1;
            this.OptionsPane.Text = "OptionsPanel";
            // 
            // NewAppButton
            // 
            this.NewAppButton.Name = "NewAppButton";
            this.NewAppButton.Size = new System.Drawing.Size(68, 20);
            this.NewAppButton.Text = "New App";
            this.NewAppButton.Click += new System.EventHandler(this.NewAppClick);
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.gitHubToolStripMenuItem.Text = "GitHub";
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // BuildDate
            // 
            this.BuildDate.Location = new System.Drawing.Point(283, 263);
            this.BuildDate.Margin = new System.Windows.Forms.Padding(0);
            this.BuildDate.Name = "BuildDate";
            this.BuildDate.Size = new System.Drawing.Size(400, 11);
            this.BuildDate.TabIndex = 2;
            this.BuildDate.Text = "BuildDate";
            this.BuildDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 275);
            this.Controls.Add(this.BuildDate);
            this.Controls.Add(this.AppsTable);
            this.Controls.Add(this.OptionsPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Interface";
            this.Text = "Neustart";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            ((System.ComponentModel.ISupportInitialize)(this.AppsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appBindingSource)).EndInit();
            this.OptionsPane.ResumeLayout(false);
            this.OptionsPane.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView AppsTable;
        private System.Windows.Forms.BindingSource appBindingSource;
        private System.Windows.Forms.MenuStrip OptionsPane;
        private System.Windows.Forms.ToolStripMenuItem NewAppButton;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.Label BuildDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crashes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uptime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ram;
        private System.Windows.Forms.DataGridViewButtonColumn BtnVisible;
        private System.Windows.Forms.DataGridViewButtonColumn BtnEnabled;
        private System.Windows.Forms.DataGridViewButtonColumn BtnEdit;
    }
}