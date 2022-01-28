using System;
using System.Data;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class BillMainForm : UserControl
    {
        private long id;
        private bool billLoaded = false;

        public BillMainForm()
        {
            InitializeComponent();
        }

        #region Preload data
        public void LoadBill(long ID)
        {
            this.id = ID;

            // Load all inventory.
            LoadItem(cbInventoryItem.SelectedIndex);

            // Update bill before continue.
            if (BUS.BillManager.CheckBillStatusByID(ID) == 0)
                BUS.BillManager.UpdateBillFromID(ID);

            // Load bill information
            LoadBillInformation(ID);

            // Load bill discount
            LoadBillDiscount(ID);

            // Load bill cart
            LoadBillCart(ID);

            billLoaded = true;

            btnPurchased.Enabled = true;
            btnPurchaseCancel.Enabled = true;
            btnSaveInformation.Enabled = true;
        }

        private void LoadItem(int index = -1)
        {
            cbInventoryItem.Items.Clear();
            var d = BUS.InventoryManager.GetAllInventories();
            foreach (DataRow d1 in d.Rows)
            {
                cbInventoryItem.Items.Add(d1["Name"]);
            }

            if (index > -1)
            {
                cbInventoryItem.SelectedIndex = index;
                cbInventoryItem_SelectedIndexChanged(cbInventoryItem, new EventArgs());
            }
        }

        private void LoadBillInformation(long ID)
        {
            // Load bill.
            var billItem = BUS.BillManager.GetBillByID(ID);

            // Get customer information.
            tbID.Text = billItem.ID.ToString();
            tbCusName.Text = billItem.CustomerName;
            tbCusAddress.Text = billItem.CustomerAddress;
            tbCusTel.Text = billItem.CustomerTelephone;
            switch (billItem.Purchased)
            {
                case 0:
                    textBox2.Text = "Not purchased";
                    break;
                case 1:
                    textBox2.Text = "Cancelled";
                    break;
                case 2:
                    textBox2.Text = "Purchased";
                    break;
            }
        }

        private void LoadBillDiscount(long ID)
        {
            // Load bill.
            var billItem = BUS.BillManager.GetBillByID(ID);

            
            switch (billItem.Purchased)
            {
                case 0:
                    textBox2.Text = "Not purchased";
                    cbDiscountType.Enabled = true;
                    tbDiscountValue.Enabled = true;
                    break;
                case 1:
                    textBox2.Text = "Cancelled";
                    cbDiscountType.Enabled = false;
                    tbDiscountValue.Enabled = false;
                    break;
                case 2:
                    textBox2.Text = "Purchased";
                    cbDiscountType.Enabled = false;
                    tbDiscountValue.Enabled = false;
                    break;
            }

            // Get discount information.
            if (!billItem.DiscountEnabled)
                cbDiscountType.SelectedIndex = 0;
            else if (!billItem.DiscountType)
                cbDiscountType.SelectedIndex = 1;
            else cbDiscountType.SelectedIndex = 2;
            tbDiscountValue.Text = billItem.DiscountValue.ToString();
        }

        private void LoadBillCart(long ID)
        {
            // Load cart from bill
            var list = BUS.BillManager.GetListItemsByID(ID);
            dgvPurchaseList.DataSource = list;

            // Calculate price
            decimal total = 0;
            foreach (var item in list)
            {
                total += item.TotalAmount;
            }

            // Calculate total amount
            tbTotalAmount.Text = total.ToString();

            LoadBillPrice();
        }

        private void LoadBillPrice()
        {
            if (tbTotalAmount.Text.Length == 0)
                return;

            var total = Convert.ToDecimal(tbTotalAmount.Text);

            // Calculate discount money and final price
            decimal discountMoney;
            switch (cbDiscountType.SelectedIndex)
            {
                case 2:
                    discountMoney = total * (Convert.ToDecimal(tbDiscountValue.Text) / 100);
                    tbFinalPrice.Text = (total - discountMoney).ToString();
                    break;
                case 1:
                    tbFinalPrice.Text = (total - Convert.ToDecimal(tbDiscountValue.Text)).ToString();
                    break;
                case 0:
                    tbDiscountValue.Text = "0";
                    tbFinalPrice.Text = tbTotalAmount.Text;
                    break;
            }
        }
        #endregion

        public void Clear()
        {
            tbID.Clear();
            tbTotalAmount.Clear();
            tbFinalPrice.Clear();
            tbDiscountValue.Clear();
            tbCusTel.Clear();
            tbCusName.Clear();
            tbCusAddress.Clear();
            tbCount.Clear();
            textBox1.Clear();
            textBox2.Clear();
            cbInventoryItem.Items.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            switch (dgvPurchaseList.SelectedRows.Count)
            {
                case 0:
                    btnDel.Enabled = false;
                    break;
                case 1:
                    btnDel.Enabled = true;
                    break;
                default:
                    btnDel.Enabled = true;
                    break;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!billLoaded)
                return;
            
            if (!CheckBillCanEdit())
                return;

            if (cbInventoryItem.SelectedIndex > -1)
            {
                // If tbCount (item count) <= 0, rollback changes.
                var count = int.Parse(tbCount.Text);
                if (count <= 0)
                {
                    MessageBox.Show(
                        "Item amount you entered must be greater than 0!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    return;
                }
                if (count > Convert.ToInt32(textBox1.Text))
                {
                    MessageBox.Show(
                        "The number of items you entered cannot exceed the number of items in stock!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
                    return;
                }

                // Get inventory information by id.
                var item = BUS.InventoryManager.GetInventory(cbInventoryItem.SelectedItem.ToString());

                // Add item to cart.
                BUS.BillManager.AddItemFromID(
                    Convert.ToInt64(tbID.Text),
                    item.ID,
                    Convert.ToInt32(tbCount.Text)
                    );

                // Load bill again
                LoadBill(this.id);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (!billLoaded)
                return;
            
            if (!CheckBillCanEdit())
                return;

            // TODO: Warning here!

            if (dgvPurchaseList.SelectedRows.Count > -1)
            {
                for (int i = 0; i < dgvPurchaseList.SelectedRows.Count; i++)
                {
                    var inventoryID = Convert.ToInt64(dgvPurchaseList.SelectedRows[i].Cells[0].Value);
                    BUS.BillManager.DeleteItemFromID(this.id, inventoryID);
                }

                LoadBill(this.id);
            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            if (!billLoaded)
                return;

            if (!CheckBillCanEdit())
                return;

            // TODO: Warning here!

            BUS.BillManager.DeleteAllItemsFromID(this.id);

            LoadBill(this.id);
        }

        private void cbDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBillPrice();
        }

        private bool CheckBillCanEdit()
        {
            if (BUS.BillManager.CheckBillStatusByID(this.id) != 0)
            {
                MessageBox.Show(
                    "This bill has purchased/cancelled.\nYou can't perform this action.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                return false;
            }
            return true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (!billLoaded)
                return;

            if (!CheckBillCanEdit())
                return;

            if (tbDiscountValue.Text.Length == 0)
                tbDiscountValue.Text = "0";

            var bill = BUS.BillManager.GetBillByID(id);
            bill.CustomerName = tbCusName.Text;
            bill.CustomerAddress = tbCusAddress.Text;
            bill.CustomerTelephone = tbCusTel.Text;
            bill.DiscountEnabled = cbDiscountType.SelectedIndex == 0 ? false : true;
            bill.DiscountType = cbDiscountType.SelectedIndex == 1 ? false : true;
            bill.DiscountValue = Convert.ToDecimal(tbDiscountValue.Text);

            BUS.BillManager.EditBill(bill);
        }

        private void btnPurchaseCancel_Click(object sender, EventArgs e)
        {
            if (!billLoaded)
                return;

            if (!CheckBillCanEdit())
                return;

            DialogResult dg = MessageBox.Show(
                "Do you want to cancel this bill?\nEverything you have added in this bill will return to the inventory.",
                "Cancel this bill?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (dg == DialogResult.Yes)
            {
                BUS.BillManager.MarkThisBillByID(this.id, false);
                LoadBill(this.id);

                btnPurchased.Enabled = false;
                btnPurchaseCancel.Enabled = false;
                btnSaveInformation.Enabled = false;
            }
        }

        private void btnPurchased_Click(object sender, EventArgs e)
        {
            if (!billLoaded)
                return;

            if (!CheckBillCanEdit())
                return;

            DialogResult dg = MessageBox.Show(
                "Do you want to mark this bill as purchased?",
                "Mark this bill as purchased?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (dg == DialogResult.Yes)
            {
                BUS.BillManager.MarkThisBillByID(this.id, true);
                btnPurchased.Enabled = false;
                btnPurchaseCancel.Enabled = false;
                btnSaveInformation.Enabled = false;

                LoadBill(this.id);

                DialogResult dg2 = MessageBox.Show(
                    "Successfully marked this bill as purchased.\nDo you want to print this bill now?",
                    "Print this bill?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (dg2 == DialogResult.Yes)
                {
                    var form = new QuanPCChuot.UI.Controls.PrintPreview(BUS.BillManager.GetBillByID(Convert.ToInt64(this.id)));
                    form.ShowDialog();
                }
            }
        }

        private void cbInventoryItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbInventoryItem.SelectedIndex < 0)
                return;

            var data = BUS.InventoryManager.GetInventory(cbInventoryItem.SelectedItem.ToString());
            textBox1.Text = data.Count.ToString();
        }
    }
}
