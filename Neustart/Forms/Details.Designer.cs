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
            this.SuspendLayout();
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(18, 37);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(232, 26);
            this.NameTextBox.TabIndex = 0;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(14, 12);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(51, 20);
            this.IDLabel.TabIndex = 1;
            this.IDLabel.Text = "Name";
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(14, 72);
            this.PathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(84, 20);
            this.PathLabel.TabIndex = 2;
            this.PathLabel.Text = "Path to file";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(18, 97);
            this.PathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(475, 26);
            this.PathTextBox.TabIndex = 3;
            // 
            // ArgsLabel
            // 
            this.ArgsLabel.AutoSize = true;
            this.ArgsLabel.Location = new System.Drawing.Point(14, 132);
            this.ArgsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ArgsLabel.Name = "ArgsLabel";
            this.ArgsLabel.Size = new System.Drawing.Size(190, 20);
            this.ArgsLabel.TabIndex = 4;
            this.ArgsLabel.Text = "Command line arguments";
            // 
            // ArgsTextBox
            // 
            this.ArgsTextBox.Location = new System.Drawing.Point(18, 158);
            this.ArgsTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ArgsTextBox.Multiline = true;
            this.ArgsTextBox.Name = "ArgsTextBox";
            this.ArgsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ArgsTextBox.Size = new System.Drawing.Size(475, 102);
            this.ArgsTextBox.TabIndex = 5;
            // 
            // AffinityLabel
            // 
            this.AffinityLabel.AutoSize = true;
            this.AffinityLabel.Location = new System.Drawing.Point(256, 12);
            this.AffinityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AffinityLabel.Name = "AffinityLabel";
            this.AffinityLabel.Size = new System.Drawing.Size(70, 20);
            this.AffinityLabel.TabIndex = 6;
            this.AffinityLabel.Text = "Affinities";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.SubmitButton.Location = new System.Drawing.Point(15, 328);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(236, 46);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Save";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(260, 328);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(236, 46);
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
            this.AffinityContainer.Location = new System.Drawing.Point(261, 66);
            this.AffinityContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AffinityContainer.Name = "AffinityContainer";
            this.AffinityContainer.Size = new System.Drawing.Size(233, 122);
            this.AffinityContainer.TabIndex = 9;
            this.AffinityContainer.Visible = false;
            // 
            // AffinityButton
            // 
            this.AffinityButton.Location = new System.Drawing.Point(261, 35);
            this.AffinityButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AffinityButton.Name = "AffinityButton";
            this.AffinityButton.Size = new System.Drawing.Size(234, 34);
            this.AffinityButton.TabIndex = 10;
            this.AffinityButton.UseVisualStyleBackColor = true;
            this.AffinityButton.Click += new System.EventHandler(this.AffinityButton_Click);
            // 
            // PriorityLabel
            // 
            this.PriorityLabel.AutoSize = true;
            this.PriorityLabel.Location = new System.Drawing.Point(14, 274);
            this.PriorityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PriorityLabel.Name = "PriorityLabel";
            this.PriorityLabel.Size = new System.Drawing.Size(93, 20);
            this.PriorityLabel.TabIndex = 11;
            this.PriorityLabel.Text = "CPU Priority";
            // 
            // RadioBelow
            // 
            this.RadioBelow.AutoSize = true;
            this.RadioBelow.Location = new System.Drawing.Point(88, 295);
            this.RadioBelow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioBelow.Name = "RadioBelow";
            this.RadioBelow.Size = new System.Drawing.Size(77, 24);
            this.RadioBelow.TabIndex = 12;
            this.RadioBelow.Text = "Below";
            this.RadioBelow.UseVisualStyleBackColor = true;
            // 
            // RadioNormal
            // 
            this.RadioNormal.AutoSize = true;
            this.RadioNormal.Checked = true;
            this.RadioNormal.Location = new System.Drawing.Point(174, 295);
            this.RadioNormal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioNormal.Name = "RadioNormal";
            this.RadioNormal.Size = new System.Drawing.Size(84, 24);
            this.RadioNormal.TabIndex = 13;
            this.RadioNormal.TabStop = true;
            this.RadioNormal.Text = "Normal";
            this.RadioNormal.UseVisualStyleBackColor = true;
            // 
            // RadioHigh
            // 
            this.RadioHigh.AutoSize = true;
            this.RadioHigh.Location = new System.Drawing.Point(357, 295);
            this.RadioHigh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioHigh.Name = "RadioHigh";
            this.RadioHigh.Size = new System.Drawing.Size(67, 24);
            this.RadioHigh.TabIndex = 14;
            this.RadioHigh.Text = "High";
            this.RadioHigh.UseVisualStyleBackColor = true;
            // 
            // RadioReal
            // 
            this.RadioReal.AutoSize = true;
            this.RadioReal.Location = new System.Drawing.Point(432, 295);
            this.RadioReal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioReal.Name = "RadioReal";
            this.RadioReal.Size = new System.Drawing.Size(67, 24);
            this.RadioReal.TabIndex = 15;
            this.RadioReal.Text = "Real";
            this.RadioReal.UseVisualStyleBackColor = true;
            // 
            // RadioLow
            // 
            this.RadioLow.AutoSize = true;
            this.RadioLow.Location = new System.Drawing.Point(18, 295);
            this.RadioLow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioLow.Name = "RadioLow";
            this.RadioLow.Size = new System.Drawing.Size(63, 24);
            this.RadioLow.TabIndex = 16;
            this.RadioLow.TabStop = true;
            this.RadioLow.Text = "Low";
            this.RadioLow.UseVisualStyleBackColor = true;
            // 
            // RadioAbove
            // 
            this.RadioAbove.AutoSize = true;
            this.RadioAbove.Location = new System.Drawing.Point(267, 295);
            this.RadioAbove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioAbove.Name = "RadioAbove";
            this.RadioAbove.Size = new System.Drawing.Size(79, 24);
            this.RadioAbove.TabIndex = 17;
            this.RadioAbove.TabStop = true;
            this.RadioAbove.Text = "Above";
            this.RadioAbove.UseVisualStyleBackColor = true;
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 391);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}