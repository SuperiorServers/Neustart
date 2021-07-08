namespace Neustart.Forms
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.AppGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Crashes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uptime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildDate = new System.Windows.Forms.Label();
            this.BtnNewApp = new System.Windows.Forms.Button();
            this.BtnGithub = new System.Windows.Forms.Button();
            this.TaskTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.BtnWebserver = new System.Windows.Forms.Button();
            this.LblWebserverStatus = new System.Windows.Forms.Label();
            this.TimerStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AppGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AppGrid
            // 
            this.AppGrid.AutoSize = true;
            this.AppGrid.AllowUserToAddRows = false;
            this.AppGrid.AllowUserToDeleteRows = false;
            this.AppGrid.AllowUserToResizeColumns = false;
            this.AppGrid.AllowUserToResizeRows = false;
            this.AppGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.AppGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AppGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AppGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AppGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AppGrid.ColumnHeadersHeight = 33;
            this.AppGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AppGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProcName,
            this.Crashes,
            this.Uptime,
            this.CPU,
            this.Memory,
            this.BtnVisible,
            this.BtnEnabled,
            this.BtnEdit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AppGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.AppGrid.EnableHeadersVisualStyles = false;
            this.AppGrid.GridColor = System.Drawing.Color.Black;
            this.AppGrid.Location = new System.Drawing.Point(23, 63);
            this.AppGrid.MaximumSize = new System.Drawing.Size(692, -2147483648);
            this.AppGrid.MinimumSize = new System.Drawing.Size(692, 298);
            this.AppGrid.Name = "AppGrid";
            this.AppGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AppGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.AppGrid.RowHeadersVisible = false;
            this.AppGrid.RowTemplate.Height = 30;
            this.AppGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AppGrid.Size = new System.Drawing.Size(692, 298);
            this.AppGrid.TabIndex = 0;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ProcName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProcName.HeaderText = "Name";
            this.ProcName.Name = "ProcName";
            this.ProcName.ReadOnly = true;
            this.ProcName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ProcName.Width = 237;
            // 
            // Crashes
            // 
            this.Crashes.FillWeight = 50F;
            this.Crashes.HeaderText = "Crashes";
            this.Crashes.Name = "Crashes";
            this.Crashes.ReadOnly = true;
            this.Crashes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Crashes.Width = 68;
            // 
            // Uptime
            // 
            this.Uptime.FillWeight = 40F;
            this.Uptime.HeaderText = "Uptime";
            this.Uptime.Name = "Uptime";
            this.Uptime.ReadOnly = true;
            this.Uptime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Uptime.Width = 60;
            // 
            // CPU
            // 
            this.CPU.FillWeight = 35F;
            this.CPU.HeaderText = "CPU";
            this.CPU.Name = "CPU";
            this.CPU.ReadOnly = true;
            this.CPU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CPU.Width = 60;
            // 
            // Memory
            // 
            this.Memory.FillWeight = 50F;
            this.Memory.HeaderText = "Memory";
            this.Memory.Name = "Memory";
            this.Memory.ReadOnly = true;
            this.Memory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Memory.Width = 75;
            // 
            // BtnVisible
            // 
            this.BtnVisible.HeaderText = "";
            this.BtnVisible.Name = "BtnVisible";
            this.BtnVisible.ReadOnly = true;
            this.BtnVisible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BtnVisible.Width = 64;
            // 
            // BtnEnabled
            // 
            this.BtnEnabled.HeaderText = "";
            this.BtnEnabled.Name = "BtnEnabled";
            this.BtnEnabled.ReadOnly = true;
            this.BtnEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BtnEnabled.Width = 64;
            // 
            // BtnEdit
            // 
            this.BtnEdit.HeaderText = "";
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.ReadOnly = true;
            this.BtnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.BtnEdit.Width = 64;
            // 
            // BuildDate
            // 
            this.BuildDate.BackColor = System.Drawing.Color.Transparent;
            this.BuildDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.BuildDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BuildDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.BuildDate.Location = new System.Drawing.Point(315, 364);
            this.BuildDate.Margin = new System.Windows.Forms.Padding(0);
            this.BuildDate.Name = "BuildDate";
            this.BuildDate.Size = new System.Drawing.Size(400, 15);
            this.BuildDate.TabIndex = 3;
            this.BuildDate.Text = "BuildDate";
            this.BuildDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BuildDate.Click += new System.EventHandler(this.BuildDateClick);
            // 
            // BtnNewApp
            // 
            this.BtnNewApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.BtnNewApp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BtnNewApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNewApp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BtnNewApp.ForeColor = System.Drawing.Color.White;
            this.BtnNewApp.Location = new System.Drawing.Point(123, 22);
            this.BtnNewApp.Name = "BtnNewApp";
            this.BtnNewApp.Size = new System.Drawing.Size(75, 34);
            this.BtnNewApp.TabIndex = 4;
            this.BtnNewApp.Text = "New App";
            this.BtnNewApp.UseVisualStyleBackColor = false;
            this.BtnNewApp.Click += new System.EventHandler(this.NewAppClick);
            // 
            // BtnGithub
            // 
            this.BtnGithub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.BtnGithub.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BtnGithub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGithub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BtnGithub.ForeColor = System.Drawing.Color.White;
            this.BtnGithub.Location = new System.Drawing.Point(204, 22);
            this.BtnGithub.Name = "BtnGithub";
            this.BtnGithub.Size = new System.Drawing.Size(75, 34);
            this.BtnGithub.TabIndex = 5;
            this.BtnGithub.Text = "GitHub";
            this.BtnGithub.UseVisualStyleBackColor = false;
            this.BtnGithub.Click += new System.EventHandler(this.GitHubClick);
            // 
            // TaskTrayIcon
            // 
            this.TaskTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TaskTrayIcon.BalloonTipText = "We\'re still running and restarting your apps in the background!";
            this.TaskTrayIcon.BalloonTipTitle = "Neustart";
            this.TaskTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TaskTrayIcon.Icon")));
            this.TaskTrayIcon.Text = "Neustart";
            this.TaskTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TaskTrayIcon_MouseDoubleClick);
            // 
            // BtnWebserver
            // 
            this.BtnWebserver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.BtnWebserver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BtnWebserver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnWebserver.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BtnWebserver.ForeColor = System.Drawing.Color.White;
            this.BtnWebserver.Location = new System.Drawing.Point(285, 22);
            this.BtnWebserver.Name = "BtnWebserver";
            this.BtnWebserver.Size = new System.Drawing.Size(126, 34);
            this.BtnWebserver.TabIndex = 6;
            this.BtnWebserver.Text = "Start webserver";
            this.BtnWebserver.UseVisualStyleBackColor = false;
            this.BtnWebserver.Click += new System.EventHandler(this.BtnWebserverClick);
            // 
            // LblWebserverStatus
            // 
            this.LblWebserverStatus.AutoSize = true;
            this.LblWebserverStatus.ForeColor = System.Drawing.Color.White;
            this.LblWebserverStatus.Location = new System.Drawing.Point(417, 34);
            this.LblWebserverStatus.Name = "LblWebserverStatus";
            this.LblWebserverStatus.Size = new System.Drawing.Size(100, 13);
            this.LblWebserverStatus.TabIndex = 7;
            this.LblWebserverStatus.Text = "Webserver stopped";
            // 
            // TimerStatus
            // 
            this.TimerStatus.Enabled = true;
            this.TimerStatus.Tick += new System.EventHandler(this.TimerStatus_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 384);
            this.Controls.Add(this.LblWebserverStatus);
            this.Controls.Add(this.BtnWebserver);
            this.Controls.Add(this.BtnGithub);
            this.Controls.Add(this.BtnNewApp);
            this.Controls.Add(this.BuildDate);
            this.Controls.Add(this.AppGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Neustart";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AppGrid;
        private System.Windows.Forms.Label BuildDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Crashes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uptime;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPU;
        private System.Windows.Forms.DataGridViewTextBoxColumn BtnVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn BtnEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn BtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memory;
        private System.Windows.Forms.Button BtnNewApp;
        private System.Windows.Forms.Button BtnGithub;
        private System.Windows.Forms.NotifyIcon TaskTrayIcon;
        private System.Windows.Forms.Button BtnWebserver;
        private System.Windows.Forms.Label LblWebserverStatus;
        private System.Windows.Forms.Timer TimerStatus;
    }
}