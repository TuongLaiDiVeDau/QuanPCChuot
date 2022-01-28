using System;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class InventoryManager : UserControl
    {
        private bool initialized = false;

        public InventoryManager()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            initialized = false;

            string searchText = tbSearch.TextLength > 0 ? tbSearch.Text : null;
            dgvInventory.DataSource = BUS.InventoryManager.GetAllInventories(searchText);

            initialized = true;
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            // Inventory Info
            if (!initialized)
                return;

            DataGridView dgv = sender as DataGridView;
            if (dgv.SelectedRows.Count == 1)
            {
                tbID.Text = dgv.SelectedRows[0].Cells[0].Value == null ? "" : dgv.SelectedRows[0].Cells[0].Value.ToString();
                tbName.Text = dgv.SelectedRows[0].Cells[1].Value == null ? "" : dgv.SelectedRows[0].Cells[1].Value.ToString();
                tbManufacturer.Text = dgv.SelectedRows[0].Cells[2].Value == null ? "" : dgv.SelectedRows[0].Cells[2].Value.ToString();
                tbGroupName.Text = dgv.SelectedRows[0].Cells[3].Value == null ? "" : dgv.SelectedRows[0].Cells[3].Value.ToString();
                tbCount.Text = dgv.SelectedRows[0].Cells[4].Value == null ? "" : dgv.SelectedRows[0].Cells[4].Value.ToString();
                tbDescription.Text = dgv.SelectedRows[0].Cells[5].Value == null ? "" : dgv.SelectedRows[0].Cells[5].Value.ToString();
                tbCostPrice.Text = dgv.SelectedRows[0].Cells[6].Value == null ? "" : dgv.SelectedRows[0].Cells[6].Value.ToString();
                tbSellPrice.Text = dgv.SelectedRows[0].Cells[7].Value == null ? "" : dgv.SelectedRows[0].Cells[7].Value.ToString();
                tbWarranty.Text = dgv.SelectedRows[0].Cells[8].Value == null ? "" : dgv.SelectedRows[0].Cells[8].Value.ToString();
                tbUnit.Text = dgv.SelectedRows[0].Cells[9].Value == null ? "" : dgv.SelectedRows[0].Cells[9].Value.ToString();
                tbCreatedDate.Text = Convert.ToDateTime(dgv.SelectedRows[0].Cells[10].Value).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                tbID.Clear();
                tbName.Clear();
                tbManufacturer.Clear();
                tbCount.Clear();
                tbDescription.Clear();
                tbCostPrice.Clear();
                tbSellPrice.Clear();
                tbWarranty.Clear();
                tbGroupName.Clear();
                tbUnit.Clear();
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

            if (dgvInventory.SelectedRows.Count <= 0)
                return;

            // Delete selected Inventories if user clicked 'Delete' and confirm with 'Yes'.
            DialogResult dg = MessageBox.Show(
                String.Format("You are about to delete {0} item(s).\nThis cannot be undone!\n\nAre you sure you want to delete them?", dgvInventory.SelectedRows.Count),
                "Delete?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                long[] id = new long[dgvInventory.SelectedRows.Count];
                for (int i = 0; i < dgvInventory.SelectedRows.Count; i++)
                    id[i] = Convert.ToInt64(dgvInventory.SelectedRows[i].Cells[0].Value);
                BUS.InventoryManager.DeleteInventory(id);

                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!initialized)
                return;

            if (dgvInventory.SelectedRows.Count != 1)
                return;

            // Open Inventory Info with edit mode
            InventoryInfo item = new InventoryInfo(BUS.InventoryManager.GetInventory(Convert.ToInt64(dgvInventory.SelectedRows[0].Cells[0].Value)));
            item.ShowDialog();
            if (item.DialogResult == DialogResult.OK)
                LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Open Inventory Info with create mode
            InventoryInfo item = new InventoryInfo();
            item.ShowDialog();

            if (item.DialogResult == DialogResult.OK)
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
