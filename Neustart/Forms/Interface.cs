using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
                        app.Start();
                    else
                        app.Stop();

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
            if (MessageBox.Show("This will close all your apps. Are you sure you want to close?", "Neustart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
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
