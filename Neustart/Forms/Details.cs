using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neustart.Forms
{
    public partial class Details : Form
    {
        private App curApp;
        private List<CheckBox> Affinities;
        private int newAffinity;

        public Details()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            Affinities = new List<CheckBox>();
            List<Label> lbls = new List<Label>();

            int x = 3;
            int y = 3;
            for (int i=1; i <= Environment.ProcessorCount; i++)
            {
                CheckBox aff = new CheckBox();
                aff.Parent = AffinityContainer;
                aff.Location = new System.Drawing.Point(x, y);
                aff.Size = new System.Drawing.Size(16, 16);
                aff.Checked = true;

                Label lbl = new Label();
                lbl.Parent = AffinityContainer;
                lbl.Location = new System.Drawing.Point(x + 13, y + 1);
                lbl.Size = new System.Drawing.Size(20, 16);
                lbl.Text = i.ToString();

                Affinities.Add(aff);
                lbls.Add(lbl);
            
                x = x + 33;
                if (x > 127 && i < Environment.ProcessorCount)
                {
                    x = 3;
                    y = y + 20;
                }
            }
            y += 20;

            AffinityContainer.Height = Math.Min(y, 81);

            if (y != 81)
            {
                int off = 1;
                foreach (CheckBox aff in Affinities)
                {
                    if (aff.Left != 3)
                        { aff.Left += (6 * off); off++; }
                    else
                        off = 1;
                }

                foreach (Label lbl in lbls)
                {
                    if (lbl.Left != 16)
                        { lbl.Left += (6 * off); off++; }
                    else
                        off = 1;
                }
            }

            CalculateAffinity();
        }

        public void SetApp(App app)
        {
            curApp = app;

            NameTextBox.Text = app.ID;
            PathTextBox.Text = app.Path;
            ArgsTextBox.Text = app.Args;

            DeleteButton.Enabled = true;
            DeleteButton.BackColor = Color.FromArgb(255, 50, 50);
            DeleteButton.ForeColor = SystemColors.ControlLightLight;

            int i = 0;
            foreach (CheckBox aff in Affinities)
            {
                aff.Checked = (app.Affinities & (1 << i)) == (1 << i);
                i++;
            }

            CalculateAffinity();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (AffinityContainer.Visible)
                AffinityButton_Click(null, null);

            if (newAffinity == 0)
            {
                MessageBox.Show("Please select processor affinities for the application.", "Neustart", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (NameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please enter a valid identifier.", "Neustart", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (PathTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please enter a valid file path.", "Neustart", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (curApp == null)
            { // New app
                if (Neustart.Program.GetAppByID(NameTextBox.Text) != null)
                {
                    MessageBox.Show("An app with that identifier already exists.", "Neustart", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                App newApp = new App();
                newApp.ID = NameTextBox.Text;
                newApp.Path = PathTextBox.Text;
                newApp.Args = ArgsTextBox.Text;
                newApp.Affinities = newAffinity;
                newApp.Enabled = false;

                this.Close();

                Neustart.Program.InitNewApp(newApp, true);
            } else { // Editing app
                string prevID = curApp.ID;

                curApp.ID = NameTextBox.Text;
                curApp.Path = PathTextBox.Text;
                curApp.Args = ArgsTextBox.Text;
                curApp.Affinities = newAffinity;

                this.Close();

                if (curApp.ID != prevID)
                {
                    curApp.DataRow.Cells[0].Value = curApp.ID;
                    Neustart.Program.RenameApp(prevID, curApp.ID);
                }

                Neustart.Program.SaveAppData();

                if (curApp.Enabled)
                {
                    DialogResult res = MessageBox.Show("This process is currently running. Would you like to restart it now?", "Restart App", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (res == DialogResult.Yes)
                    {
                        curApp.Stop();
                        curApp.Start();
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to remove " + curApp.ID + "?", "Delete App", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Neustart.Program.RemoveApp(curApp);
                this.Close();
            }
        }

        private void CalculateAffinity()
        {
            int affinity = 0;
            int i = 0;
            List<string> txt = new List<string>();
            foreach (CheckBox aff in Affinities)
            {
                if (aff.Checked)
                {
                    txt.Add((i + 1).ToString());
                    affinity = affinity | (1 << i);
                }

                i++;
            }

            if (txt.Count == 0)
                AffinityButton.Text = "Choose Affinities";
            else
            {
                string newText = String.Join(", ", txt);
                AffinityButton.Text = newText;
            }

            newAffinity = affinity;
        }

        private void AffinityButton_Click(object sender, EventArgs e)
        {
            if (AffinityContainer.Visible)
            {
                AffinityContainer.Visible = false;
                CalculateAffinity();
            } else
            {
                AffinityContainer.Visible = true;
                AffinityButton.Text = "Finish";
            }
        }
    }
}
