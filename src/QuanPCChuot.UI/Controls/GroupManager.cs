using System;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class GroupManager : UserControl
    {
        private bool initialized = false;

        public GroupManager()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            initialized = false;

            string searchText = tbSearch.TextLength > 0 ? tbSearch.Text : null;
            dgvGroup.DataSource = BUS.GroupManager.GetAllGroups(searchText);

            initialized = true;
        }

        private void dgvGroup_SelectionChanged(object sender, EventArgs e)
        {
            // Group Info
            if (!initialized)
                return;

            DataGridView dgv = sender as DataGridView;
            if (dgv.SelectedRows.Count == 1)
            {
                tbID.Text = dgv.SelectedRows[0].Cells[0].Value == null ? "" : dgv.SelectedRows[0].Cells[0].Value.ToString();
                tbName.Text = dgv.SelectedRows[0].Cells[1].Value == null ? "" : dgv.SelectedRows[0].Cells[1].Value.ToString();
                tbDescription.Text = dgv.SelectedRows[0].Cells[2].Value == null ? "" : dgv.SelectedRows[0].Cells[2].Value.ToString();
                tbCreatedDate.Text = Convert.ToDateTime(dgv.SelectedRows[0].Cells[3].Value).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                tbID.Clear();
                tbName.Clear();
                tbDescription.Clear();
                tbCreatedDate.Clear();
            }

            // Buttons
            switch (dgv.SelectedRows.Count)
            {
                case 1:
                    btnEdit.Enabled = true;
                    btnDel.Enabled = true;
                    break;
                case 0:
                    btnEdit.Enabled = false;
                    btnDel.Enabled = false;
                    break;
                default:
                    btnEdit.Enabled = false;
                    btnDel.Enabled = true;
                    break;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            if (dgvGroup.SelectedRows.Count <= 0)
                return;

            // Delete selected string if user clicked 'Delete' and confirm with 'Yes'.
            DialogResult dg = MessageBox.Show(
                String.Format("You are about to delete {0} item(s).\nThis cannot be undone!\n\nAre you sure you want to delete them?", dgvGroup.SelectedRows.Count),
                "Delete?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                long[] id = new long[dgvGroup.SelectedRows.Count];
                for (int i = 0; i < dgvGroup.SelectedRows.Count; i++)
                    id[i] = Convert.ToInt64(dgvGroup.SelectedRows[i].Cells[0].Value);
                BUS.GroupManager.DeleteGroupsByID(id);

                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            if (dgvGroup.SelectedRows.Count != 1)
                return;

            // Open Group Info with edit mode
            GroupInfo groupForm = new GroupInfo(BUS.GroupManager.GetGroupByID(Convert.ToInt64(dgvGroup.SelectedRows[0].Cells[0].Value)));
            groupForm.ShowDialog();
            if (groupForm.DialogResult == DialogResult.OK)
                LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            GroupInfo groupForm = new GroupInfo();
            groupForm.ShowDialog();

            // Open Group Info with create mode
            if (groupForm.DialogResult == DialogResult.OK)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
