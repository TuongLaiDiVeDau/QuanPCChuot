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
    public partial class BillInfo : Form
    {
        DTO.Bill bill = null;

        public BillInfo(DTO.Bill bill)
        {
            InitializeComponent();
            this.bill = bill;

            LoadData(this.bill);
        }

        private void LoadData(Bill bill)
        {
            if (bill != null)
            {
                tbID.Text = bill.ID.ToString();
                tbTelephone.Text = bill.Account.Name;
                textBox1.Text = bill.CreatedDate.ToString("dd/MM/yyyy HH:mm");
                tbUsername.Text = bill.CustomerName;
                tbName.Text = bill.CustomerTelephone;
                tbPassword.Text = bill.CustomerAddress;

                switch (bill.Purchased)
                {
                    case 2:
                        textBox2.Text = "Purchased";
                        break;
                    case 1:
                        textBox2.Text = "Cancelled";
                        break;
                    case 0:
                        textBox2.Text = "Not purchased";
                        break;
                }

                var purchaseList = BUS.BillManager.GetListItemsByID(bill.ID);
                dataGridView1.DataSource = purchaseList;

                decimal totalamount = 0;
                foreach (var purchaseInfo in purchaseList)
                {
                    totalamount += purchaseInfo.UnitPrice * purchaseInfo.Count;
                }

                textBox3.Text = totalamount.ToString();

                if (bill.DiscountEnabled)
                {
                    if (bill.DiscountType)
                    {
                        // Giảm giá theo phần trăm
                        decimal giamGia = totalamount * (bill.DiscountValue / 100);
                        textBox4.Text = giamGia.ToString();
                        textBox5.Text = (totalamount - giamGia).ToString();
                    }
                    else
                    {
                        // Giảm giá theo số tiền
                        textBox4.Text = bill.DiscountValue.ToString();
                        textBox5.Text = (totalamount - bill.DiscountValue).ToString();
                    }
                }
                else
                {
                    // Không giảm giá
                    textBox4.Text = "No";
                    textBox5.Text = textBox3.Text;
                }
            }
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (bill.Purchased == 2)
            {
                var form = new QuanPCChuot.UI.Controls.PrintPreview(this.bill);
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
