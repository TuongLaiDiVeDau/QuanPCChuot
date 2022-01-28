using QuanPCChuot.DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class InventoryInfo : Form
    {
        bool modified = false;
        bool initialized = false;

        public InventoryInfo(DTO.Inventory item = null)
        {
            InitializeComponent();

            LoadGroupItem();
            LoadData(item);

            initialized = true;
        }

        private void LoadGroupItem()
        {
            int previousSelection = cobGroup.SelectedIndex;
            var groupList = BUS.GroupManager.GetAllGroups();

            cobGroup.Items.Clear();
            foreach (DataRow groupItem in groupList.Rows)
            {
                cobGroup.Items.Add(groupItem["Name"]);
            }

            cobGroup.SelectedIndex = previousSelection == -1 ? 0 : previousSelection;
        }

        private void LoadData(Inventory item)
        {
            if (item != null)
            {
                tbID.Text = item.ID.ToString();
                tbName.Text = item.Name;
                tbManufacturer.Text = item.Manufacturer;
                tbCount.Text = item.Count.ToString();
                tbCostPrice.Text = item.CostPrice.ToString();
                tbSellPrice.Text = item.SellPrice.ToString();
                tbWarranty.Text = item.Warranty.ToString();
                tbUnit.Text = item.Unit;
                dtpLastAddDate.Value = item.LastAddDate;

                // Find Group
                foreach (var cobItem in cobGroup.Items)
                {
                    if (cobItem.ToString().Contains(item.ItemGroup.Name))
                    {
                        cobGroup.SelectedItem = cobItem;
                        break;
                    }
                }

                label1.Text = "Edit a inventory";
            }
            else
            {
                dtpLastAddDate.Value = DateTime.Now;

                label1.Text = "Create new Inventory";
            }
        }

        private bool CloseForm()
        {
            bool return1 = false;
            if (modified)
            {
                DialogResult dg = MessageBox.Show("You has changed but not saved this data.\nAll data modifited from this form will be lost.\n\nAre you sure you want to cancel?",
                    this.Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (dg == DialogResult.Yes)
                    return1 = true;
            }
            else return1 = true;
            return return1;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            if (initialized) modified = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CloseForm())
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (modified)
            {
                DTO.Inventory item = new Inventory();

                item.Name = tbName.Text;
                item.Manufacturer = tbManufacturer.Text;
                item.Count = Convert.ToInt64(tbCount.Text);
                item.Description = tbDescription.Text;
                item.CostPrice = Convert.ToDecimal(tbCostPrice.Text);
                item.SellPrice = Convert.ToDecimal(tbSellPrice.Text);
                item.Warranty = Convert.ToInt32(tbWarranty.Text);
                item.GroupID = BUS.GroupManager.GetGroupByName(cobGroup.SelectedItem.ToString()).ID;
                item.Unit = tbUnit.Text;
                item.LastAddDate = dtpLastAddDate.Value;

                if (tbID.Text.Length > 0)
                {
                    item.ID = Convert.ToInt64(tbID.Text);
                    BUS.InventoryManager.EditInventory(item);
                }
                else
                {
                    BUS.InventoryManager.AddInventory(item);
                }
                this.DialogResult = DialogResult.OK;
            }
            else this.DialogResult = DialogResult.OK;
        }
    }
}
