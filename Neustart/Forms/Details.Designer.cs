using System;

namespace Neustart.Forms
{
    partial class Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Details));
            this.NameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.IDLabel = new MetroFramework.Controls.MetroLabel();
            this.PathLabel = new MetroFramework.Controls.MetroLabel();
            this.PathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.ArgsLabel = new MetroFramework.Controls.MetroLabel();
            this.ArgsTextBox = new MetroFramework.Controls.MetroTextBox();
            this.AffinityLabel = new MetroFramework.Controls.MetroLabel();
            this.SubmitButton = new MetroFramework.Controls.MetroButton();
            this.DeleteButton = new MetroFramework.Controls.MetroButton();
            this.AffinityContainer = new MetroFramework.Controls.MetroPanel();
            this.AffinityButton = new MetroFramework.Controls.MetroButton();
            this.PriorityLabel = new MetroFramework.Controls.MetroLabel();
            this.RadioBelow = new MetroFramework.Controls.MetroRadioButton();
            this.RadioNormal = new MetroFramework.Controls.MetroRadioButton();
            this.RadioHigh = new MetroFramework.Controls.MetroRadioButton();
            this.RadioReal = new MetroFramework.Controls.MetroRadioButton();
            this.RadioLow = new MetroFramework.Controls.MetroRadioButton();
            this.RadioAbove = new MetroFramework.Controls.MetroRadioButton();
            this.BrowseButton = new MetroFramework.Controls.MetroButton();
            this.PathFileBrowserDiag = new System.Windows.Forms.OpenFileDialog();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            // 
            // 
            // 
            this.NameTextBox.CustomButton.Image = null;
            this.NameTextBox.CustomButton.Location = new System.Drawing.Point(138, 2);
            this.NameTextBox.CustomButton.Name = "";
            this.NameTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.NameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NameTextBox.CustomButton.TabIndex = 1;
            this.NameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NameTextBox.CustomButton.UseSelectable = true;
            this.NameTextBox.CustomButton.Visible = false;
            this.NameTextBox.Lines = new string[0];
            this.NameTextBox.Location = new System.Drawing.Point(26, 79);
            this.NameTextBox.MaxLength = 32767;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PasswordChar = '\0';
            this.NameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameTextBox.SelectedText = "";
            this.NameTextBox.SelectionLength = 0;
            this.NameTextBox.SelectionStart = 0;
            this.NameTextBox.ShortcutsEnabled = true;
            this.NameTextBox.Size = new System.Drawing.Size(156, 20);
            this.NameTextBox.TabIndex = 0;
            this.NameTextBox.UseSelectable = true;
            this.NameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(26, 60);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(45, 19);
            this.IDLabel.TabIndex = 1;
            this.IDLabel.Text = "Name";
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(26, 102);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(71, 19);
            this.PathLabel.TabIndex = 2;
            this.PathLabel.Text = "Path to file";
            // 
            // PathTextBox
            // 
            // 
            // 
            // 
            this.PathTextBox.CustomButton.Image = null;
            this.PathTextBox.CustomButton.Location = new System.Drawing.Point(233, 2);
            this.PathTextBox.CustomButton.Name = "";
            this.PathTextBox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.PathTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PathTextBox.CustomButton.TabIndex = 1;
            this.PathTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PathTextBox.CustomButton.UseSelectable = true;
            this.PathTextBox.CustomButton.Visible = false;
            this.PathTextBox.Lines = new string[0];
            this.PathTextBox.Location = new System.Drawing.Point(26, 119);
            this.PathTextBox.MaxLength = 32767;
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.PasswordChar = '\0';
            this.PathTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PathTextBox.SelectedText = "";
            this.PathTextBox.SelectionLength = 0;
            this.PathTextBox.SelectionStart = 0;
            this.PathTextBox.ShortcutsEnabled = true;
            this.PathTextBox.Size = new System.Drawing.Size(251, 20);
            this.PathTextBox.TabIndex = 3;
            this.PathTextBox.UseSelectable = true;
            this.PathTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PathTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ArgsLabel
            // 
            this.ArgsLabel.AutoSize = true;
            this.ArgsLabel.Location = new System.Drawing.Point(26, 142);
            this.ArgsLabel.Name = "ArgsLabel";
            this.ArgsLabel.Size = new System.Drawing.Size(162, 19);
            this.ArgsLabel.TabIndex = 4;
            this.ArgsLabel.Text = "Command line arguments";
            // 
            // ArgsTextBox
            // 
            // 
            // 
            // 
            this.ArgsTextBox.CustomButton.Image = null;
            this.ArgsTextBox.CustomButton.Location = new System.Drawing.Point(248, 2);
            this.ArgsTextBox.CustomButton.Name = "";
            this.ArgsTextBox.CustomButton.Size = new System.Drawing.Size(67, 67);
            this.ArgsTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ArgsTextBox.CustomButton.TabIndex = 1;
            this.ArgsTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ArgsTextBox.CustomButton.UseSelectable = true;
            this.ArgsTextBox.CustomButton.Visible = false;
            this.ArgsTextBox.Lines = new string[0];
            this.ArgsTextBox.Location = new System.Drawing.Point(26, 160);
            this.ArgsTextBox.MaxLength = 32767;
            this.ArgsTextBox.Multiline = true;
            this.ArgsTextBox.Name = "ArgsTextBox";
            this.ArgsTextBox.PasswordChar = '\0';
            this.ArgsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ArgsTextBox.SelectedText = "";
            this.ArgsTextBox.SelectionLength = 0;
            this.ArgsTextBox.SelectionStart = 0;
            this.ArgsTextBox.ShortcutsEnabled = true;
            this.ArgsTextBox.Size = new System.Drawing.Size(318, 72);
            this.ArgsTextBox.TabIndex = 5;
            this.ArgsTextBox.UseSelectable = true;
            this.ArgsTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ArgsTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AffinityLabel
            // 
            this.AffinityLabel.AutoSize = true;
            this.AffinityLabel.Location = new System.Drawing.Point(188, 60);
            this.AffinityLabel.Name = "AffinityLabel";
            this.AffinityLabel.Size = new System.Drawing.Size(58, 19);
            this.AffinityLabel.TabIndex = 6;
            this.AffinityLabel.Text = "Affinities";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(26, 303);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(157, 30);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Save";
            this.SubmitButton.UseSelectable = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(189, 303);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(157, 30);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseSelectable = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AffinityContainer
            // 
            this.AffinityContainer.AutoScroll = true;
            this.AffinityContainer.BackColor = System.Drawing.Color.White;
            this.AffinityContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AffinityContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AffinityContainer.HorizontalScrollbar = true;
            this.AffinityContainer.HorizontalScrollbarBarColor = true;
            this.AffinityContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.AffinityContainer.HorizontalScrollbarSize = 10;
            this.AffinityContainer.Location = new System.Drawing.Point(184, 100);
            this.AffinityContainer.Name = "AffinityContainer";
            this.AffinityContainer.Size = new System.Drawing.Size(164, 80);
            this.AffinityContainer.TabIndex = 9;
            this.AffinityContainer.VerticalScrollbar = true;
            this.AffinityContainer.VerticalScrollbarBarColor = true;
            this.AffinityContainer.VerticalScrollbarHighlightOnWheel = false;
            this.AffinityContainer.VerticalScrollbarSize = 10;
            this.AffinityContainer.Visible = false;
            // 
            // AffinityButton
            // 
            this.AffinityButton.Location = new System.Drawing.Point(188, 78);
            this.AffinityButton.Name = "AffinityButton";
            this.AffinityButton.Size = new System.Drawing.Size(156, 22);
            this.AffinityButton.TabIndex = 10;
            this.AffinityButton.UseSelectable = true;
            this.AffinityButton.Click += new System.EventHandler(this.AffinityButton_Click);
            // 
            // PriorityLabel
            // 
            this.PriorityLabel.AutoSize = true;
            this.PriorityLabel.Location = new System.Drawing.Point(26, 235);
            this.PriorityLabel.Name = "PriorityLabel";
            this.PriorityLabel.Size = new System.Drawing.Size(81, 19);
            this.PriorityLabel.TabIndex = 11;
            this.PriorityLabel.Text = "CPU Priority";
            // 
            // RadioBelow
            // 
            this.RadioBelow.AutoSize = true;
            this.RadioBelow.Location = new System.Drawing.Point(79, 257);
            this.RadioBelow.Name = "RadioBelow";
            this.RadioBelow.Size = new System.Drawing.Size(58, 17);
            this.RadioBelow.TabIndex = 12;
            this.RadioBelow.Text = "Below";
            this.RadioBelow.UseSelectable = true;
            // 
            // RadioNormal
            // 
            this.RadioNormal.AutoSize = true;
            this.RadioNormal.Checked = true;
            this.RadioNormal.Location = new System.Drawing.Point(142, 257);
            this.RadioNormal.Name = "RadioNormal";
            this.RadioNormal.Size = new System.Drawing.Size(68, 17);
            this.RadioNormal.TabIndex = 13;
            this.RadioNormal.TabStop = true;
            this.RadioNormal.Text = "Normal";
            this.RadioNormal.UseSelectable = true;
            // 
            // RadioHigh
            // 
            this.RadioHigh.AutoSize = true;
            this.RadioHigh.Location = new System.Drawing.Point(283, 257);
            this.RadioHigh.Name = "RadioHigh";
            this.RadioHigh.Size = new System.Drawing.Size(51, 17);
            this.RadioHigh.TabIndex = 14;
            this.RadioHigh.Text = "High";
            this.RadioHigh.UseSelectable = true;
            // 
            // RadioReal
            // 
            this.RadioReal.AutoSize = true;
            this.RadioReal.Location = new System.Drawing.Point(28, 280);
            this.RadioReal.Name = "RadioReal";
            this.RadioReal.Size = new System.Drawing.Size(49, 17);
            this.RadioReal.TabIndex = 15;
            this.RadioReal.Text = "Real";
            this.RadioReal.UseSelectable = true;
            // 
            // RadioLow
            // 
            this.RadioLow.AutoSize = true;
            this.RadioLow.Location = new System.Drawing.Point(28, 257);
            this.RadioLow.Name = "RadioLow";
            this.RadioLow.Size = new System.Drawing.Size(47, 17);
            this.RadioLow.TabIndex = 16;
            this.RadioLow.TabStop = true;
            this.RadioLow.Text = "Low";
            this.RadioLow.UseSelectable = true;
            // 
            // RadioAbove
            // 
            this.RadioAbove.AutoSize = true;
            this.RadioAbove.Location = new System.Drawing.Point(216, 257);
            this.RadioAbove.Name = "RadioAbove";
            this.RadioAbove.Size = new System.Drawing.Size(61, 17);
            this.RadioAbove.TabIndex = 17;
            this.RadioAbove.TabStop = true;
            this.RadioAbove.Text = "Above";
            this.RadioAbove.UseSelectable = true;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(283, 119);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(61, 20);
            this.BrowseButton.TabIndex = 18;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseSelectable = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PathFileBrowserDiag
            // 
            this.PathFileBrowserDiag.DefaultExt = "exe";
            this.PathFileBrowserDiag.InitialDirectory = "C:\\";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 358);
            this.Controls.Add(this.RadioAbove);
            this.Controls.Add(this.RadioLow);
            this.Controls.Add(this.RadioReal);
            this.Controls.Add(this.RadioHigh);
            this.Controls.Add(this.RadioNormal);
            this.Controls.Add(this.RadioBelow);
            this.Controls.Add(this.PriorityLabel);
            this.Controls.Add(this.AffinityButton);
            this.Controls.Add(this.AffinityContainer);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.AffinityLabel);
            this.Controls.Add(this.ArgsTextBox);
            this.Controls.Add(this.ArgsLabel);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.PathLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.BrowseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Details";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "App Details";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox NameTextBox;
        private MetroFramework.Controls.MetroLabel IDLabel;
        private MetroFramework.Controls.MetroLabel PathLabel;
        private MetroFramework.Controls.MetroTextBox PathTextBox;
        private MetroFramework.Controls.MetroLabel ArgsLabel;
        private MetroFramework.Controls.MetroTextBox ArgsTextBox;
        private MetroFramework.Controls.MetroLabel AffinityLabel;
        private MetroFramework.Controls.MetroButton SubmitButton;
        private MetroFramework.Controls.MetroButton DeleteButton;
        private MetroFramework.Controls.MetroPanel AffinityContainer;
        private MetroFramework.Controls.MetroButton AffinityButton;
        private MetroFramework.Controls.MetroLabel PriorityLabel;
        private MetroFramework.Controls.MetroRadioButton RadioBelow;
        private MetroFramework.Controls.MetroRadioButton RadioNormal;
        private MetroFramework.Controls.MetroRadioButton RadioHigh;
        private MetroFramework.Controls.MetroRadioButton RadioReal;
        private MetroFramework.Controls.MetroRadioButton RadioLow;
        private MetroFramework.Controls.MetroRadioButton RadioAbove;
        private MetroFramework.Controls.MetroButton BrowseButton;
        private System.Windows.Forms.OpenFileDialog PathFileBrowserDiag;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}