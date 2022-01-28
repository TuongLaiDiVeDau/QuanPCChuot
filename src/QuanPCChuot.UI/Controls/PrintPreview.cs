using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class PrintPreview : Form
    {
        public PrintPreview(DTO.Bill bill)
        {
            InitializeComponent();

            LoadBill(bill);
        }

        private void LoadBill (DTO.Bill bill)
        {
            label6.Text = "Tên khách hàng: " + bill.CustomerName;
            label7.Text = "Địa chỉ: " + bill.CustomerAddress;
            label11.Text = String.Format(
                "Ngày {0} tháng {1} năm {2}",
                bill.CreatedDate.Day,
                bill.CreatedDate.Month,
                bill.CreatedDate.Year);

            listView1.Items.Clear();

            var purchaseList = BUS.BillManager.GetListItemsByID(bill.ID);
            decimal totalamount = 0;
            for (int i = 0; i < purchaseList.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(purchaseList[i].Name.ToString());
                item.SubItems.Add(purchaseList[i].Count.ToString());
                item.SubItems.Add(purchaseList[i].Unit.ToString());
                item.SubItems.Add(purchaseList[i].UnitPrice.ToString());
                item.SubItems.Add(purchaseList[i].TotalAmount.ToString());

                totalamount += purchaseList[i].UnitPrice * purchaseList[i].Count;

                listView1.Items.Add(item);
            }

            if (bill.DiscountEnabled)
            {
                if (bill.DiscountType)
                {
                    // Giảm giá theo phần trăm
                    label8.Text = String.Format(
                        "Thành tiền: {0} VNĐ (Giá gốc: {1} VNĐ, giảm giá {2}%)",
                        totalamount - (totalamount * bill.DiscountValue / 100),
                        totalamount,
                        Convert.ToInt32(bill.DiscountValue));
                }
                else
                {
                    // Giảm giá theo số tiền
                    label8.Text = String.Format(
                        "Thành tiền: {0} VNĐ (Giá gốc: {1} VNĐ, giảm giá {2} VNĐ)",
                        totalamount - bill.DiscountValue,
                        totalamount,
                        bill.DiscountValue);
                }
            }
            else
            {
                // Không giảm giá
                label8.Text = String.Format(
                    "Thành tiền: {0} VNĐ",
                    totalamount);
            }
        }

        #region Print function
        // Source: https://stackoverflow.com/a/10640745

        private void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(this.panel1);
        }

        //Rest of the code
        Bitmap MemoryImage;
        Panel pannel = null;
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }

        public void Print(Panel pnl)
        {
            pannel = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printdoc1;
            previewdlg.ShowDialog();
        }
        #endregion
    }
}
