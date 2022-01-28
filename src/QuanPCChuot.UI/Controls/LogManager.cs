using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class LogManager : UserControl
    {
        bool initialized = false;

        public LogManager()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            initialized = false;

            dgvLog.DataSource = BUS.LogManager.GetAllLogs();

            initialized = true;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            if (dgvLog.SelectedRows.Count != 1)
                return;

            LogViewer log = new LogViewer(BUS.LogManager.GetLogByID(Convert.ToInt64(dgvLog.SelectedRows[0].Cells[0].Value)));
            log.ShowDialog();
        }

        private void dgvLog_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnView_Click(new object(), new EventArgs());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Value = DateTime.Today;
            dtpDateTo.Value = DateTime.Today;

            LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgvLog.DataSource = BUS.LogManager.GetLogFromDate(dtpDateFrom.Value, dtpDateTo.Value);
        }
    }
}
