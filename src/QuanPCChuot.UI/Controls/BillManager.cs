using System;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class BillManager : UserControl
    {
        bool initialized = false;

        public BillManager()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            dgvBill.DataSource = BUS.BillManager.GetAllBills();

            initialized = true;
        }

        private void dgvBill_SelectionChanged(object sender, System.EventArgs e)
        {
            if (!initialized)
                return;

            // Check selection changed

            // To show information on the right of datagridview.
            DataGridView dgv = sender as DataGridView;

            if (dgv.SelectedRows.Count == 1)
            {
                tbID.Text = dgv.SelectedRows[0].Cells[0].Value == null ? "" : dgv.SelectedRows[0].Cells[0].Value.ToString();
                tbCusName.Text = dgv.SelectedRows[0].Cells[1].Value == null ? "" : dgv.SelectedRows[0].Cells[1].Value.ToString();
                tbCusAdd.Text = dgv.SelectedRows[0].Cells[2].Value == null ? "" : dgv.SelectedRows[0].Cells[2].Value.ToString();
                tbCusTel.Text = dgv.SelectedRows[0].Cells[3].Value == null ? "" : dgv.SelectedRows[0].Cells[3].Value.ToString();
                tbStaffName.Text = dgv.SelectedRows[0].Cells[4].Value == null ? "" : dgv.SelectedRows[0].Cells[4].Value.ToString();
                tbTotalAmount.Text = dgv.SelectedRows[0].Cells[5].Value == null ? "" : dgv.SelectedRows[0].Cells[5].Value.ToString();
                tbDiscount.Text = dgv.SelectedRows[0].Cells[6].Value == null ? "" : dgv.SelectedRows[0].Cells[6].Value.ToString();
                tbStatus.Text = dgv.SelectedRows[0].Cells[7].Value == null ? "" : dgv.SelectedRows[0].Cells[7].Value.ToString();
                tbCreatedDate.Text = Convert.ToDateTime(dgv.SelectedRows[0].Cells[8].Value).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                tbID.Clear();
                tbCusName.Clear();
                tbCusAdd.Clear();
                tbCusTel.Clear();
                tbStaffName.Clear();
                tbTotalAmount.Clear();
                tbDiscount.Clear();
                tbStatus.Clear();
                tbCreatedDate.Clear();
            }

            // To control button.
            switch (dgv.SelectedRows.Count)
            {
                case 1:
                    btnView.Enabled = true;
                    btnPrint.Enabled = true;
                    break;
                default:
                    btnView.Enabled = true;
                    btnPrint.Enabled = false;
                    break;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            BillInfo bill = new BillInfo(BUS.BillManager.GetBillByID(Convert.ToInt64(dgvBill.SelectedRows[0].Cells[0].Value)));
            bill.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Value = DateTime.Today;
            dtpDateTo.Value = DateTime.Today;

            LoadData();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            dgvBill.DataSource = BUS.BillManager.GetBillsFromDate(dtpDateFrom.Value, dtpDateTo.Value);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var bill = BUS.BillManager.GetBillByID(Convert.ToInt64(dgvBill.SelectedRows[0].Cells[0].Value));
            if (bill.Purchased == 2)
            {
                var form = new QuanPCChuot.UI.Controls.PrintPreview(bill);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Sorry, this function is available only when this bill is mark as purchased.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }
    }
}
