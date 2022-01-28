using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class AccountManager : UserControl
    {
        bool initialized = false;

        public AccountManager()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            initialized = false;

            string searchText = tbSearch.TextLength > 0 ? tbSearch.Text : null;
            dgvAcc.DataSource = BUS.AccountManager.GetAllAccounts(searchText);

            initialized = true;
        }

        private void dgvAcc_SelectionChanged(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            // Check selection changed

            // To show information on the right of datagridview.
            DataGridView dgv = sender as DataGridView;

            if (dgv.SelectedRows.Count == 1)
            {
                tbID.Text = dgv.SelectedRows[0].Cells[0].Value == null ? "" : dgv.SelectedRows[0].Cells[0].Value.ToString();
                tbName.Text = dgv.SelectedRows[0].Cells[1].Value == null ? "" : dgv.SelectedRows[0].Cells[1].Value.ToString();
                tbUsername.Text = dgv.SelectedRows[0].Cells[2].Value == null ? "" : dgv.SelectedRows[0].Cells[2].Value.ToString();
                tbTelephone.Text = dgv.SelectedRows[0].Cells[3].Value == null ? "" : dgv.SelectedRows[0].Cells[3].Value.ToString();
                tbIsAdmin.Text = Convert.ToBoolean(dgv.SelectedRows[0].Cells[4].Value).ToString();
                tbCreatedDate.Text = Convert.ToDateTime(dgv.SelectedRows[0].Cells[5].Value).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                tbID.Clear();
                tbName.Clear();
                tbUsername.Clear();
                tbTelephone.Clear();
                tbIsAdmin.Clear();
                tbCreatedDate.Clear();
            }

            // To control button.
            switch (dgv.SelectedRows.Count)
            {
                case 1:
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    btnChangePass.Enabled = true;
                    break;
                case 0:
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    btnChangePass.Enabled = false;
                    break;
                default:
                    btnEdit.Enabled = false;
                    btnDel.Enabled = true;
                    btnChangePass.Enabled = false;
                    break;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            if (dgvAcc.SelectedRows.Count != 1)
                return;

            // Open Account Info with edit mode
            AccountInfo acc = new AccountInfo(BUS.AccountManager.GetAccountByID(Convert.ToInt64(dgvAcc.SelectedRows[0].Cells[0].Value)));
            acc.ShowDialog();
            if (acc.DialogResult == DialogResult.OK)
                LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            AccountInfo acc = new AccountInfo();
            acc.ShowDialog();

            // Open Account Info with create mode
            if (acc.DialogResult == DialogResult.OK)
                LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            if (dgvAcc.SelectedRows.Count <= 0)
                return;

            // Delete selected string if user clicked 'Delete' and confirm with 'Yes'.
            DialogResult dg = MessageBox.Show(
                String.Format("You are about to delete {0} item(s).\nThis cannot be undone!\n\nAre you sure you want to delete them?", dgvAcc.SelectedRows.Count),
                "Delete?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                long[] id = new long[dgvAcc.SelectedRows.Count];
                for (int i = 0; i < dgvAcc.SelectedRows.Count; i++)
                    id[i] = Convert.ToInt64(dgvAcc.SelectedRows[i].Cells[0].Value);
                BUS.AccountManager.DeleteAccountsByID(id);

                LoadData();
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            if (dgvAcc.SelectedRows.Count != 1)
                return;

            // Change Password
            AccountChangePassword accChangePass = new AccountChangePassword(BUS.AccountManager.GetAccountByID(Convert.ToInt64(dgvAcc.SelectedRows[0].Cells[0].Value)));
            accChangePass.ShowDialog();

            if (accChangePass.DialogResult == DialogResult.OK)
                LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadData();
            }
        }
    }
}
