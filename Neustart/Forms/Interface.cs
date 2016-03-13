using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

[assembly: AssemblyVersion("1.0.*")]

namespace Neustart.Forms
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            this.BuildDate.Text = Assembly.GetCallingAssembly().GetName().Version.ToString();
        }

        private void DataGridClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            DataGridViewRow curRow = senderGrid.Rows[e.RowIndex];

            App app = Neustart.Program.GetAppByID(curRow.Cells[0].Value.ToString());

            switch (e.ColumnIndex)
            {
                case 2: //StartStop
                    app.Enabled = !app.Enabled;

                    if (app.Enabled)
                    {
                        app.Start();
                        app.ResetCrashes();
                    }
                    else
                    {
                        app.Stop();
                    }

                    Neustart.Program.SaveAppData();

                    break;
                case 3: //HideShow
                    app.ToggleHide();

                    break;
                case 4: //Edit
                    Details detailsForm = new Details();
                    detailsForm.SetApp(app);

                    detailsForm.ShowDialog();

                    break;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            bool doResume = false;
            bool asked = false;

            foreach (App app in Neustart.Program.GetApps())
            {
                if (app.Enabled)
                {
                    if (!asked)
                    {
                        asked = true;

                        if (MessageBox.Show("Would you like Neustart to close your running apps? If you choose no, Neustart will try to reattach itself to their processes next time you open it.", "Neustart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            doResume = true;
                        }
                    }

                    if (doResume)
                        app.PrepareForResume();
                    else
                        app.Process.Kill();
                }
            }
            
            Neustart.Program.SaveAppData();
        }

        private void OnClose(object sender, EventArgs e)
        {
            Neustart.Program.Close();
           
        }

        private void NewAppClick(object sender, EventArgs e)
        {
            new Details().ShowDialog();
        }

        private void DataCellPaint(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string id = AppsTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                App app = Neustart.Program.GetAppByID(id);

                if (e.ColumnIndex == 1)
                {
                    if (app != null && app.Enabled && app.FrozenInterval != 0)
                        e.CellStyle.BackColor = Color.FromArgb(255, 255 - (app.FrozenInterval * 20), 255 - (app.FrozenInterval * 20));
                    else
                        e.CellStyle.BackColor = Color.White;
                }

                if (e.ColumnIndex == 2)
                {
                    if (app != null && app.Enabled)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 50, 50);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(255, 50, 50);
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.FromArgb(50, 255, 50);
                        e.CellStyle.SelectionBackColor = Color.FromArgb(50, 255, 50);
                    }
                }
            }
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/SuperiorServers/Neustart");
        }
    }
}
