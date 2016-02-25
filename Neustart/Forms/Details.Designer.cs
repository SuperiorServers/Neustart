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
            this.AffinityContainer = new System.Windows.Forms.Panel();
            this.AffinityButton = new System.Windows.Forms.Button();
            this.NameTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PathTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ArgsTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ButtonSave = new MaterialSkin.Controls.MaterialFlatButton();
            this.ButtonDelete = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // AffinityContainer
            // 
            this.AffinityContainer.AutoScroll = true;
            this.AffinityContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.AffinityContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AffinityContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AffinityContainer.Location = new System.Drawing.Point(185, 87);
            this.AffinityContainer.Name = "AffinityContainer";
            this.AffinityContainer.Size = new System.Drawing.Size(156, 80);
            this.AffinityContainer.TabIndex = 9;
            this.AffinityContainer.Visible = false;
            // 
            // AffinityButton
            // 
            this.AffinityButton.Location = new System.Drawing.Point(185, 70);
            this.AffinityButton.Name = "AffinityButton";
            this.AffinityButton.Size = new System.Drawing.Size(156, 22);
            this.AffinityButton.TabIndex = 10;
            this.AffinityButton.UseVisualStyleBackColor = true;
            this.AffinityButton.Click += new System.EventHandler(this.AffinityButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Depth = 0;
            this.NameTextBox.Hint = "Name";
            this.NameTextBox.Location = new System.Drawing.Point(10, 70);
            this.NameTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PasswordChar = '\0';
            this.NameTextBox.SelectedText = "";
            this.NameTextBox.SelectionLength = 0;
            this.NameTextBox.SelectionStart = 0;
            this.NameTextBox.Size = new System.Drawing.Size(169, 32);
            this.NameTextBox.TabIndex = 11;
            this.NameTextBox.UseSystemPasswordChar = false;
            // 
            // PathTextBox
            // 
            this.PathTextBox.Depth = 0;
            this.PathTextBox.Hint = "Executable path";
            this.PathTextBox.Location = new System.Drawing.Point(10, 107);
            this.PathTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.PasswordChar = '\0';
            this.PathTextBox.SelectedText = "";
            this.PathTextBox.SelectionLength = 0;
            this.PathTextBox.SelectionStart = 0;
            this.PathTextBox.Size = new System.Drawing.Size(328, 32);
            this.PathTextBox.TabIndex = 12;
            this.PathTextBox.TabStop = false;
            this.PathTextBox.UseSystemPasswordChar = false;
            // 
            // ArgsTextBox
            // 
            this.ArgsTextBox.Depth = 0;
            this.ArgsTextBox.Hint = "Command line arguments";
            this.ArgsTextBox.Location = new System.Drawing.Point(10, 144);
            this.ArgsTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.ArgsTextBox.Name = "ArgsTextBox";
            this.ArgsTextBox.PasswordChar = '\0';
            this.ArgsTextBox.SelectedText = "";
            this.ArgsTextBox.SelectionLength = 0;
            this.ArgsTextBox.SelectionStart = 0;
            this.ArgsTextBox.Size = new System.Drawing.Size(328, 32);
            this.ArgsTextBox.TabIndex = 13;
            this.ArgsTextBox.UseSystemPasswordChar = false;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Depth = 0;
            this.ButtonSave.Location = new System.Drawing.Point(10, 180);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ButtonSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Primary = false;
            this.ButtonSave.Size = new System.Drawing.Size(169, 36);
            this.ButtonSave.TabIndex = 14;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Depth = 0;
            this.ButtonDelete.Enabled = false;
            this.ButtonDelete.Location = new System.Drawing.Point(185, 180);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.ButtonDelete.MouseState = MaterialSkin.MouseState.HOVER;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Primary = false;
            this.ButtonDelete.Size = new System.Drawing.Size(156, 36);
            this.ButtonDelete.TabIndex = 15;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 223);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.AffinityContainer);
            this.Controls.Add(this.ArgsTextBox);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.AffinityButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Details";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "App Settings";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel AffinityContainer;
        private System.Windows.Forms.Button AffinityButton;
        private MaterialSkin.Controls.MaterialSingleLineTextField NameTextBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField PathTextBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField ArgsTextBox;
        private MaterialSkin.Controls.MaterialFlatButton ButtonSave;
        private MaterialSkin.Controls.MaterialFlatButton ButtonDelete;
    }
}