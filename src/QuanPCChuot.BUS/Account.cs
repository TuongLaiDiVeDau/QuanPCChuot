using QuanPCChuot.DAL;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace QuanPCChuot.BUS
{
    public static partial class Account
    {
        public static DTO.Account LoggedInAccount { get; set; }

        public enum LoginState
        {
            Unknown = -1,
            NotFound = 0,
            IncorrentPassword = 1,
            CorrectPassword = 2
        }

        public static LoginState Login(string username, string password)
        {
            try
            {
                using (var db = new Model1())
                {
                    db.Accounts.Load();
                    var acc = db.Accounts.Local.Where(p => p.Username.ToUpper() == username.ToUpper()).FirstOrDefault();
                    if (acc == null)
                    {
                        return LoginState.NotFound;
                    }
                    else if (acc.Password != MD5Hash(password))
                    {
                        // BUS.LogManager.AddLog(LoggedInAccount.ID, "Login failed: Incorrect password");
                        return LoginState.IncorrentPassword;
                    }
                    else
                    {
                        LoggedInAccount = acc;
                        BUS.LogManager.AddLog(LoggedInAccount.ID, "Login successful");
                        return LoginState.CorrectPassword;
                    }
                }
            }
            catch
            {
                return LoginState.Unknown;
            }
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        public static void Logout()
        {
            BUS.LogManager.AddLog(LoggedInAccount.ID, "Logged out");
            LoggedInAccount = null;
        }
    }
}
