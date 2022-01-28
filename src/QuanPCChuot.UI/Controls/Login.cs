using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanPCChuot.UI.Controls
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        public void ClearPassword()
        {
            tbPassword.Clear();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (tbUsername.Text.Length == 0 ||
                tbPassword.Text.Length == 0)
            {
                label3.Text = "Username or password cannot be empty!";
                return;
            }
            else
            {
                progressBar1.Visible = true;
                label3.Text = "Logging in...";
                bwLogin.RunWorkerAsync();
            }
        }

        public event EventHandler<LoginEventArgs> LoginReturn;

        private void bwLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = BUS.Account.Login(tbUsername.Text, tbPassword.Text);
        }

        private void bwLogin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BUS.Account.LoginState result = (BUS.Account.LoginState)e.Result;
            LoginReturn(this, new LoginEventArgs() { State = result });

            progressBar1.Visible = false;
            label3.Text = "Type your account and click 'Login' to continue.";
        }

        private void TextBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin_Click(btnLogin, new EventArgs());
            }
        }
    }

    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs() { }

        public BUS.Account.LoginState State { get; set; } = BUS.Account.LoginState.Unknown;
    }
}
