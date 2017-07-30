using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using MetroFramework.Controls;

namespace Neustart.Forms
{
    public partial class Details : MetroFramework.Forms.MetroForm
    {
        private App curApp;
        private List<MetroCheckBox> Affinities;
        private int newAffinity;
        private List<MetroRadioButton> Priorities;

        public Details()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            Affinities = new List<MetroCheckBox>();
            List<Label> lbls = new List<Label>();

            int x = 3;
            int y = 3;
            for (int i=1; i <= Environment.ProcessorCount; i++)
            {
                MetroCheckBox aff = new MetroCheckBox();
                aff.Parent = AffinityContainer;
                aff.Location = new Point(x, y);
                aff.Size = new Size(16, 16);
                aff.Checked = true;
                aff.Style = MetroFramework.MetroColorStyle.Orange;
                aff.Theme = MetroFramework.MetroThemeStyle.Dark;

                MetroLabel lbl = new MetroLabel();
                lbl.Parent = AffinityContainer;
                lbl.Location = new Point(x + 13, y - 2);
                lbl.Size = new Size(22, 16);
                lbl.Text = i.ToString();
                lbl.Style = MetroFramework.MetroColorStyle.Orange;
                lbl.Theme = MetroFramework.MetroThemeStyle.Dark;

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
                foreach (MetroCheckBox aff in Affinities)
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

            Priorities = new List<MetroRadioButton>
            {
                RadioLow,
                RadioBelow,
                RadioNormal,
                RadioAbove,
                RadioHigh,
                RadioReal
            };
        }

        public void SetApp(App app)
        {
            curApp = app;

            NameTextBox.Text = app.Config.ID;
            PathTextBox.Text = app.Config.Path;
            ArgsTextBox.Text = app.Config.Args;

            DeleteButton.Enabled = true;
            DeleteButton.BackColor = Color.FromArgb(255, 50, 50);
            DeleteButton.ForeColor = SystemColors.ControlLightLight;

            int i = 0;
            foreach (MetroCheckBox aff in Affinities)
            {
                aff.Checked = (app.Config.Affinities & (1 << i)) == (1 << i);
                i++;
            }

            CalculateAffinity();

            Priorities[app.Config.Priority].Checked = true;
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
                if (Core.GetContainer().GetAppByID(NameTextBox.Text) != null)
                {
                    MessageBox.Show("An app with that identifier already exists.", "Neustart", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                AppConfig newConfig = new AppConfig();
                newConfig.ID = NameTextBox.Text;
                newConfig.Path = PathTextBox.Text;
                newConfig.Args = ArgsTextBox.Text;
                newConfig.Affinities = newAffinity;

                for (int i = 0; i < Priorities.Count; i++)
                {
                    if (Priorities[i].Checked)
                    {
                        newConfig.Priority = i;
                        break;
                    }
                }

                newConfig.Enabled = false;

                Close();

                Core.GetContainer().SetupApp(newConfig, true);
            } else { // Editing app
                string prevID = curApp.Config.ID;

                curApp.Config.ID = NameTextBox.Text;
                curApp.Config.Path = PathTextBox.Text;
                curApp.Config.Args = ArgsTextBox.Text;
                curApp.Config.Affinities = newAffinity;

                for (int i = 0; i < Priorities.Count; i++)
                    if (Priorities[i].Checked)
                    {
                        curApp.Config.Priority = i;
                        break;
                    }

                Close();

                if (curApp.Config.ID != prevID)
                    Main.Get().AppRenamed(curApp);

                if (curApp.Config.Enabled)
                {
                    DialogResult res = MessageBox.Show("This process is currently running. Would you like to restart it now?", "Restart App", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (res == DialogResult.Yes)
                    {
                        curApp.Stop();

                        Task.Run(async () =>
                        {
                            await Task.Delay(1000);
                            curApp.Start();
                        });
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to remove " + curApp.Config.ID + "?", "Delete App", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Core.GetContainer().DeleteApp(curApp);
                this.Close();
            }
        }

        private void CalculateAffinity()
        {
            int affinity = 0;
            int i = 0;
            List<string> txt = new List<string>();
            foreach (MetroCheckBox aff in Affinities)
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

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (PathFileBrowserDiag.ShowDialog() == DialogResult.OK)
            {
                this.PathTextBox.Text = PathFileBrowserDiag.FileName;
            }
        }
    }
}
