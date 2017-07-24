using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Neustart.Forms
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        public static event EventHandler OnInterfaceReady;
        public static event EventHandler OnInterfaceClosed;

        private static Main _this;
        public static Main Get() => _this;

        public struct AppRowTemplate
        {
            public string ID;
            public string Title;
            public int Crashes;
            public string Uptime;
            public string CPU;
            public string Memory;
        }
        private struct AppRowDict
        {
            public AppRowTemplate template;
            public DataGridViewRow row;
        }
        private Dictionary<App, AppRowDict> m_AppRowDictionary = new Dictionary<App, AppRowDict>();

        public Main()
        {
            _this = this;

            InitializeComponent();

            this.BuildDate.Text = Core.Version;

            new Thread(UpdateAppStatuses).Start();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            App.OnAppInitialized += OnAppInitialized;

            AppGrid.SizeChanged += OnGridSizeChanged;

            AppGrid.CellContentClick += OnCellContentClicked;
            AppGrid.CellMouseDown += OnCellMouseDown;
            AppGrid.CellMouseUp += OnCellMouseUp;
            AppGrid.CellMouseEnter += OnCellMouseEnter;
            AppGrid.CellMouseLeave += OnCellMouseLeave;
            AppGrid.CellPainting += OnCellPaint;

            Resize += OnResized;

            OnInterfaceReady?.Invoke(this, null);
        }

        private void OnGridSizeChanged(object sender, EventArgs e)
        {
            BuildDate.Location = new Point(BuildDate.Location.X, AppGrid.Location.Y + AppGrid.Height + 3);
            Height = AppGrid.Location.Y + AppGrid.Height + 23;
        }

        private void Main_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            _this = null;

            OnInterfaceClosed?.Invoke(this, null);
        }

        public void AppRenamed(App app)
        {
            Debug.Log("App renamed: " + app.Config.ID);

            AppRowDict dict = m_AppRowDictionary[app];
            dict.template.ID = app.Config.ID;
            dict.row.Cells[0].Value = app.Config.ID;
        }

        public void AppDeleted(App app)
        {
            AppRowDict dict = m_AppRowDictionary[app];

            AppGrid.Rows.Remove(dict.row);
            m_AppRowDictionary.Remove(app);

            Debug.Log("Removed AppGrid row for " + app.Config.ID);
        }

        private void OnAppInitialized(object sender, EventArgs e)
        {
            App app = sender as App;
            Debug.Log("Create GridView for app " + app.Config.ID);

            object[] rowData = new object[] { app.Config.ID, app.Config.ID, "0", "00:00:00", "0%", "0 MB", app.Config.Enabled ? "Stop" : "Start", app.Config.Hidden ? "Show" : "Hide", "Edit" };
            DataGridViewRow gridRow = this.AppGrid.Rows[this.AppGrid.Rows.Add(rowData)];

            m_AppRowDictionary[app] = new AppRowDict
            {
                row = gridRow,
                template = new AppRowTemplate
                {
                    ID = app.Config.ID,
                    Title = app.Config.ID,
                    Crashes = 0,
                    Uptime = "00:00:00",
                    CPU = "0%",
                    Memory = "0 MB"
                }
            };
        }

        private void OnCellContentClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 6)
                return;

            var senderGrid = (DataGridView)sender;
            DataGridViewRow curRow = senderGrid.Rows[e.RowIndex];

            DataGridViewCell btn = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            App app = Core.GetContainer().GetAppByID(curRow.Cells[0].Value.ToString());

            switch (e.ColumnIndex)
            {
                case 6: //StartStop
                    if (app.Config.Enabled)
                        app.Stop();
                    else
                        app.Start();

                    btn.Value = app.Config.Enabled ? "Stop" : "Start";
                    break;
                case 7: //HideShow
                    app.ToggleHide();

                    btn.Value = app.Config.Hidden ? "Show" : "Hide";
                    break;
                case 8: //Edit
                    EditAppClick(app);
                    break;
            }
        }

        int curRow = -1;
        int curCol = -1;
        private void OnCellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            curRow = e.RowIndex;
            curCol = e.ColumnIndex;

            if (e.RowIndex < 0 || e.ColumnIndex < 6)
                return;

            AppGrid.InvalidateCell(AppGrid.Rows[curRow].Cells[curCol]);
        }

        private void OnCellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            curRow = -1;
            curCol = -1;

            if (e.RowIndex < 0 || e.ColumnIndex < 6)
                return;

            AppGrid.InvalidateCell(AppGrid.Rows[e.RowIndex].Cells[e.ColumnIndex]);
        }

        DataGridViewCell curClicked;
        private void OnCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 6)
                return;

            curClicked = AppGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            AppGrid.InvalidateCell(curClicked);
        }

        private void OnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (curClicked != null && curClicked.RowIndex >= 0)
                AppGrid.InvalidateCell(curClicked);

            curClicked = null;
        }

        private void OnCellPaint(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 6)
                return;

            Color bgCol;
            if (e.RowIndex == curRow && e.ColumnIndex == curCol)
                if (curClicked != null && curClicked == AppGrid.Rows[e.RowIndex].Cells[e.ColumnIndex])
                    bgCol = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
                else
                    bgCol = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            else
                bgCol = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));

            bool drawStopBorder = false;
            Pen stopBorder = new Pen(System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(50)))), ((int)(((byte)(50))))), 1);
            if (AppGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Stop")
                drawStopBorder = true;

            using (var bgPen = new Pen(bgCol, 1))
            using (var borderPen = new Pen(System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12))))), 1))
            {
                var topLeftPoint = new Point(e.CellBounds.Left, e.CellBounds.Top);
                var topRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Top);
                var bottomRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                var bottomleftPoint = new Point(e.CellBounds.Left, e.CellBounds.Bottom - 1);

                e.Graphics.FillRectangle(bgPen.Brush, e.CellBounds);

                e.Graphics.DrawLine(borderPen, topLeftPoint, topRightPoint);
                e.Graphics.DrawLine(borderPen, topLeftPoint, bottomleftPoint);
                e.Graphics.DrawLine(borderPen, topRightPoint, bottomRightPoint);
                e.Graphics.DrawLine(borderPen, bottomleftPoint, bottomRightPoint);

                if (drawStopBorder)
                {
                    topLeftPoint.X += 1;
                    topLeftPoint.Y += 1;
                    bottomleftPoint.X += 1;
                    bottomleftPoint.Y -= 1;
                    topRightPoint.X -= 1;
                    topRightPoint.Y += 1;
                    bottomRightPoint.X -= 1;
                    bottomRightPoint.Y -= 1;

                    e.Graphics.DrawLine(stopBorder, topLeftPoint, topRightPoint);
                    e.Graphics.DrawLine(stopBorder, topLeftPoint, bottomleftPoint);
                    e.Graphics.DrawLine(stopBorder, topRightPoint, bottomRightPoint);
                    e.Graphics.DrawLine(stopBorder, bottomleftPoint, bottomRightPoint);
                }

                e.PaintContent(e.CellBounds);

                e.Handled = true;
            }
        }

        private void UpdateAppStatuses()
        {
            while (Get() != null)
            {
                if (Visible)
                {
                    if (Core.UpdateAvailable)
                        BuildDate.Invoke((MethodInvoker)delegate { BuildDate.Text = Core.Version + " (Update available, click here!)"; });

                    foreach (var entry in m_AppRowDictionary)
                    {
                        App app = entry.Key;
                        DataGridViewRow row = entry.Value.row;
                        AppRowTemplate template = entry.Value.template;

                        // We wrap this in a try just because it's not exactly thread safe to the app's processes.
                        // If an exception is thrown here we can pretty safely assume the process ended one way or another - we'll just use what was cached.
                        try { app.RefreshStatuses(ref template); } catch (Exception) { }

                        row.Cells[1].Value = template.Title;
                        row.Cells[2].Value = template.Crashes;
                        row.Cells[3].Value = template.Uptime;
                        row.Cells[4].Value = template.CPU;
                        row.Cells[5].Value = template.Memory;
                    }
                }

                Thread.Sleep(750);
            }
        }

        private void EditAppClick(App app)
        {
            Forms.Details details = new Details();
            details.TopMost = true;
            details.SetApp(app);
            details.ShowDialog();
        }

        private void NewAppClick(object sender, EventArgs e)
        {
            Forms.Details details = new Details();
            details.TopMost = true;
            details.ShowDialog();
        }

        private void GitHubClick(object sender, EventArgs e)
            => System.Diagnostics.Process.Start("https://github.com/SuperiorServers/Neustart");

        private void BuildDateClick(object sender, EventArgs e)
        {
            if (!Core.UpdateAvailable)
                return;

            BuildDate.Text = "Please wait..";
            Core.TriggerUpdate();
        }

        private void OnResized(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                TaskTrayIcon.Visible = true;
                TaskTrayIcon.ShowBalloonTip(5000);
                ShowInTaskbar = false;
            }
        }

        private void TaskTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            Focus();
            BringToFront();
            TaskTrayIcon.Visible = false;
        }
    }
}
