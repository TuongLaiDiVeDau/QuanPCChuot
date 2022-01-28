using System;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class AccountChangePassword : Form
    {
        public AccountChangePassword(DTO.Account acc)
        {
            InitializeComponent();

            LoadData(acc);
        }

        private void LoadData(DTO.Account acc)
        {
            tbUsername.Text = acc.Username;
            if (!acc.IsAdmin)
                tbCurPass.ReadOnly = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var data = BUS.AccountManager.ChangePassword(tbUsername.Text, tbNewPass.Text, tbCurPass.Text);
            if (data)
                this.DialogResult = DialogResult.OK;
        }
    }
}
