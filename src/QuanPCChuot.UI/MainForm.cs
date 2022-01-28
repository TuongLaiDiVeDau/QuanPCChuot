using System;
using System.Windows.Forms;

namespace QuanPCChuot.UI
{
    public partial class MainForm : Form
    {
        bool initialize = false;

        public MainForm()
        {
            InitializeComponent();

            pLogin.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            billPanel.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            billManager.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inventoryManager.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupManager.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            accountManager.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            logManager.BringToFront();
        }

        private void LoadData(bool isAdmin)
        {
            initialize = false;

            accountManager.LoadData();
            billManager.LoadData();

            button4.Visible = isAdmin;
            button5.Visible = isAdmin;
            button6.Visible = isAdmin;
            button7.Visible = isAdmin;

            if (isAdmin)
            {
                groupManager.LoadData();
                inventoryManager.LoadData();
                logManager.LoadData();
            }

            initialize = true;

            button3_Click(btnRefresh, new EventArgs());
        }

        private void cbIDList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!initialize)
                return;

            if (cbIDList.SelectedIndex != -1)
                billMainForm1.LoadBill(Convert.ToInt64(cbIDList.SelectedItem));
        }

        private void login1_LoginReturn(object sender, Controls.LoginEventArgs e)
        {
            switch (e.State)
            {
                case BUS.Account.LoginState.CorrectPassword:
                    pLogin.SendToBack();
                    login1.ClearPassword();
                    billPanel.BringToFront();
                    LoadData(BUS.Account.LoggedInAccount.IsAdmin);
                    button8.Text = String.Format("Logout\n({0})", BUS.Account.LoggedInAccount.Username);
                    break;
                case BUS.Account.LoginState.IncorrentPassword:
                    MessageBox.Show(
                        "Password is not correct!\nCheck your account and try again.",
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
                case BUS.Account.LoginState.NotFound:
                    MessageBox.Show(
                        "Username does not exist!\nCheck your account and try again.",
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
                case BUS.Account.LoginState.Unknown:
                    MessageBox.Show(
                        "An error was occurred and this program can't log you in.\nTry again later or contact developer for assistance",
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var listID = BUS.BillManager.GetPendingBill();
            cbIDList.Items.Clear();

            if (listID.Count > 0)
            {
                foreach (long id in listID)
                {
                    cbIDList.Items.Add(id);
                }

                cbIDList.SelectedIndex = 0;
                cbIDList_SelectedIndexChanged(cbIDList, new EventArgs());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show(
                String.Format("Are you sure you want to logout?\nYou have logged in as {0}", BUS.Account.LoggedInAccount.Username),
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                billMainForm1.Clear();
                BUS.Account.Logout();
                button8.Text = "Logout";
                pLogin.BringToFront();
            }
        }

        private void btnNewBill_Click(object sender, EventArgs e)
        {
            var id = BUS.BillManager.AddEmptyBill();
            button3_Click(btnRefresh, new EventArgs());
            billMainForm1.LoadBill(id);
        }

    }
}
