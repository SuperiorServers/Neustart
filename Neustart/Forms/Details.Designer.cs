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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Details));
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.PathLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.ArgsLabel = new System.Windows.Forms.Label();
            this.ArgsTextBox = new System.Windows.Forms.TextBox();
            this.AffinityLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AffinityContainer = new System.Windows.Forms.Panel();
            this.AffinityButton = new System.Windows.Forms.Button();
            this.PriorityLabel = new System.Windows.Forms.Label();
            this.RadioBelow = new System.Windows.Forms.RadioButton();
            this.RadioNormal = new System.Windows.Forms.RadioButton();
            this.RadioHigh = new System.Windows.Forms.RadioButton();
            this.RadioReal = new System.Windows.Forms.RadioButton();
            this.RadioLow = new System.Windows.Forms.RadioButton();
            this.RadioAbove = new System.Windows.Forms.RadioButton();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PathFileBrowserDiag = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 24);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(156, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(9, 8);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(35, 13);
            this.IDLabel.TabIndex = 1;
            this.IDLabel.Text = "Name";
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(9, 47);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(57, 13);
            this.PathLabel.TabIndex = 2;
            this.PathLabel.Text = "Path to file";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(12, 63);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(251, 20);
            this.PathTextBox.TabIndex = 3;
            // 
            // ArgsLabel
            // 
            this.ArgsLabel.AutoSize = true;
            this.ArgsLabel.Location = new System.Drawing.Point(9, 86);
            this.ArgsLabel.Name = "ArgsLabel";
            this.ArgsLabel.Size = new System.Drawing.Size(125, 13);
            this.ArgsLabel.TabIndex = 4;
            this.ArgsLabel.Text = "Command line arguments";
            // 
            // ArgsTextBox
            // 
            this.ArgsTextBox.Location = new System.Drawing.Point(12, 103);
            this.ArgsTextBox.Multiline = true;
            this.ArgsTextBox.Name = "ArgsTextBox";
            this.ArgsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ArgsTextBox.Size = new System.Drawing.Size(318, 68);
            this.ArgsTextBox.TabIndex = 5;
            // 
            // AffinityLabel
            // 
            this.AffinityLabel.AutoSize = true;
            this.AffinityLabel.Location = new System.Drawing.Point(171, 8);
            this.AffinityLabel.Name = "AffinityLabel";
            this.AffinityLabel.Size = new System.Drawing.Size(46, 13);
            this.AffinityLabel.TabIndex = 6;
            this.AffinityLabel.Text = "Affinities";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.SubmitButton.Location = new System.Drawing.Point(10, 213);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(157, 30);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Save";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(173, 213);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(157, 30);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AffinityContainer
            // 
            this.AffinityContainer.AutoScroll = true;
            this.AffinityContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.AffinityContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AffinityContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AffinityContainer.Location = new System.Drawing.Point(174, 43);
            this.AffinityContainer.Name = "AffinityContainer";
            this.AffinityContainer.Size = new System.Drawing.Size(156, 80);
            this.AffinityContainer.TabIndex = 9;
            this.AffinityContainer.Visible = false;
            // 
            // AffinityButton
            // 
            this.AffinityButton.Location = new System.Drawing.Point(174, 23);
            this.AffinityButton.Name = "AffinityButton";
            this.AffinityButton.Size = new System.Drawing.Size(156, 22);
            this.AffinityButton.TabIndex = 10;
            this.AffinityButton.UseVisualStyleBackColor = true;
            this.AffinityButton.Click += new System.EventHandler(this.AffinityButton_Click);
            // 
            // PriorityLabel
            // 
            this.PriorityLabel.AutoSize = true;
            this.PriorityLabel.Location = new System.Drawing.Point(9, 178);
            this.PriorityLabel.Name = "PriorityLabel";
            this.PriorityLabel.Size = new System.Drawing.Size(63, 13);
            this.PriorityLabel.TabIndex = 11;
            this.PriorityLabel.Text = "CPU Priority";
            // 
            // RadioBelow
            // 
            this.RadioBelow.AutoSize = true;
            this.RadioBelow.Location = new System.Drawing.Point(59, 192);
            this.RadioBelow.Name = "RadioBelow";
            this.RadioBelow.Size = new System.Drawing.Size(54, 17);
            this.RadioBelow.TabIndex = 12;
            this.RadioBelow.Text = "Below";
            this.RadioBelow.UseVisualStyleBackColor = true;
            // 
            // RadioNormal
            // 
            this.RadioNormal.AutoSize = true;
            this.RadioNormal.Checked = true;
            this.RadioNormal.Location = new System.Drawing.Point(116, 192);
            this.RadioNormal.Name = "RadioNormal";
            this.RadioNormal.Size = new System.Drawing.Size(58, 17);
            this.RadioNormal.TabIndex = 13;
            this.RadioNormal.TabStop = true;
            this.RadioNormal.Text = "Normal";
            this.RadioNormal.UseVisualStyleBackColor = true;
            // 
            // RadioHigh
            // 
            this.RadioHigh.AutoSize = true;
            this.RadioHigh.Location = new System.Drawing.Point(238, 192);
            this.RadioHigh.Name = "RadioHigh";
            this.RadioHigh.Size = new System.Drawing.Size(47, 17);
            this.RadioHigh.TabIndex = 14;
            this.RadioHigh.Text = "High";
            this.RadioHigh.UseVisualStyleBackColor = true;
            // 
            // RadioReal
            // 
            this.RadioReal.AutoSize = true;
            this.RadioReal.Location = new System.Drawing.Point(288, 192);
            this.RadioReal.Name = "RadioReal";
            this.RadioReal.Size = new System.Drawing.Size(47, 17);
            this.RadioReal.TabIndex = 15;
            this.RadioReal.Text = "Real";
            this.RadioReal.UseVisualStyleBackColor = true;
            // 
            // RadioLow
            // 
            this.RadioLow.AutoSize = true;
            this.RadioLow.Location = new System.Drawing.Point(12, 192);
            this.RadioLow.Name = "RadioLow";
            this.RadioLow.Size = new System.Drawing.Size(45, 17);
            this.RadioLow.TabIndex = 16;
            this.RadioLow.TabStop = true;
            this.RadioLow.Text = "Low";
            this.RadioLow.UseVisualStyleBackColor = true;
            // 
            // RadioAbove
            // 
            this.RadioAbove.AutoSize = true;
            this.RadioAbove.Location = new System.Drawing.Point(178, 192);
            this.RadioAbove.Name = "RadioAbove";
            this.RadioAbove.Size = new System.Drawing.Size(56, 17);
            this.RadioAbove.TabIndex = 17;
            this.RadioAbove.TabStop = true;
            this.RadioAbove.Text = "Above";
            this.RadioAbove.UseVisualStyleBackColor = true;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(269, 62);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(61, 22);
            this.BrowseButton.TabIndex = 18;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PathFileBrowserDiag
            // 
            this.PathFileBrowserDiag.DefaultExt = "exe";
            this.PathFileBrowserDiag.InitialDirectory = "C:\\";
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 254);
            this.Controls.Add(this.BrowseButton);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Details";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "App Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label ArgsLabel;
        private System.Windows.Forms.TextBox ArgsTextBox;
        private System.Windows.Forms.Label AffinityLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Panel AffinityContainer;
        private System.Windows.Forms.Button AffinityButton;
        private System.Windows.Forms.Label PriorityLabel;
        private System.Windows.Forms.RadioButton RadioBelow;
        private System.Windows.Forms.RadioButton RadioNormal;
        private System.Windows.Forms.RadioButton RadioHigh;
        private System.Windows.Forms.RadioButton RadioReal;
        private System.Windows.Forms.RadioButton RadioLow;
        private System.Windows.Forms.RadioButton RadioAbove;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.OpenFileDialog PathFileBrowserDiag;
    }
}