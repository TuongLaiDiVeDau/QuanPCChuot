using QuanPCChuot.DTO;
using System;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class AccountInfo : Form
    {
        bool modified = false;
        bool initialized = false;

        public AccountInfo(DTO.Account acc = null)
        {
            InitializeComponent();

            LoadData(acc);

            initialized = true;
        }

        private void LoadData(Account acc = null)
        {
            if (acc != null)
            {
                tbID.Text = acc.ID.ToString();
                tbName.Text = acc.Name == null ? null : acc.Name.ToString();
                tbUsername.Text = acc.Username == null ? null : acc.Username.ToString();
                tbPassword.Text = acc.Password == null ? null : acc.Password.ToString();
                tbTelephone.Text = acc.Telephone == null ? null : acc.Telephone.ToString();
                cbIsAdmin.Checked = acc.IsAdmin;
                dtpCreatedDate.Value = acc.CreatedDate;

                label1.Text = "Edit Account";
            }
            else
            {
                tbPassword.ReadOnly = false;
                label1.Text = "Create new Account";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (modified)
            {
                DTO.Account acc = new DTO.Account();
                
                acc.Name = tbName.Text;
                acc.Username = tbUsername.Text;
                acc.Password = tbPassword.Text;
                acc.Telephone = tbTelephone.Text;
                acc.IsAdmin = cbIsAdmin.Checked;
                acc.CreatedDate = dtpCreatedDate.Value;

                if (tbID.Text.Length > 0)
                {
                    acc.ID = Convert.ToInt64(tbID.Text);
                    BUS.AccountManager.EditAccount(acc);
                }
                else
                {
                    BUS.AccountManager.AddAccount(acc);
                }

                this.DialogResult = DialogResult.OK;
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CloseForm())
                this.DialogResult = DialogResult.Cancel;
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
    }
}
