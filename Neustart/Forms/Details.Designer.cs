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
            this.PathTextBox.Size = new System.Drawing.Size(318, 20);
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
            this.ArgsTextBox.Name = "ArgsTextBox";
            this.ArgsTextBox.Size = new System.Drawing.Size(318, 20);
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
            this.SubmitButton.Location = new System.Drawing.Point(11, 130);
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
            this.DeleteButton.Location = new System.Drawing.Point(174, 130);
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
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 171);
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
    }
}