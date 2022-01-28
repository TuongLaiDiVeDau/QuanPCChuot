using QuanPCChuot.DTO;
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
    public partial class LogViewer : Form
    {
        public LogViewer(DTO.Log log)
        {
            InitializeComponent();

            LoadData(log);
        }

        private void LoadData(Log log)
        {
            if (log != null)
            {
                rtbLogData.Text = String.Format(
                    "Staff Name: {0}\nCreated at {1}\n\n{2}",
                    log.Account.Name,
                    log.CreatedDate.ToString("dd/MM/yyyy HH:mm"),
                    log.Description
                    );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
