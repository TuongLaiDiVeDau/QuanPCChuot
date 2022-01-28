using QuanPCChuot.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace QuanPCChuot.BUS
{
    public static partial class AccountManager
    {
        public static DataTable GetAllAccounts(string name = null)
        {
            using (var db = new Model1())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(long));
                dt.Columns.Add("Display Name", typeof(string));
                dt.Columns.Add("Username", typeof(string));
                dt.Columns.Add("Telephone", typeof(string));
                dt.Columns.Add("Is Administrator", typeof(bool));
                dt.Columns.Add("Created Date", typeof(DateTime));

                db.Accounts.Load();
                var d = db.Accounts.Local.ToList();
                if (name != null)
                    d = d.Where(p => p.Username.ToLower().Contains(name.ToLower())).ToList();

                foreach (var dr in d)
                {
                    var row = dt.NewRow();
                    row["ID"] = dr.ID;
                    row["Display Name"] = dr.Name;
                    row["Username"] = dr.Username;
                    row["Telephone"] = dr.Telephone;
                    row["Is Administrator"] = dr.IsAdmin;
                    row["Created Date"] = dr.CreatedDate;
                    dt.Rows.Add(row);
                }

                return dt;
            }
        }

        public static DTO.Account GetAccountByID(long ID)
        {
            using (var db = new Model1())
            {
                db.Accounts.Load();
                var data = db.Accounts.Local.Where(p => p.ID == ID).FirstOrDefault();
                if (data == null)
                    MessageBox.Show("Account by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }
        }

        public static void AddAccount(DTO.Account acc)
        {
            using (var db = new Model1())
            {
                acc.Password = BUS.Account.MD5Hash(acc.Password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Added a account with ID: {0}", acc.ID));
            }
        }

        public static void EditAccount(DTO.Account acc)
        {
            using (var db = new Model1())
            {
                var data = db.Accounts.Where(p => p.ID == acc.ID).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("Account by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                data.Name = acc.Name;
                data.Username = acc.Username;
                data.Telephone = acc.Telephone;
                data.IsAdmin = acc.IsAdmin;

                db.SaveChanges();
                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Made changes to account ID: {0}", acc.ID));
            }
        }

        public static void DeleteAccountsByID(long[] ID)
        {
            using (var db = new Model1())
            {
                List<long> list = new List<long>();

                foreach (long id in ID)
                {
                    var data = db.Accounts.Where(p => p.ID == id).FirstOrDefault();
                    if (data == null)
                        list.Add(id);
                    else if (data.ID == BUS.Account.LoggedInAccount.ID)
                    {
                        MessageBox.Show(
                            "You can't delete your account when you logged in.\nTo do this, ask another administrator to delete your account.",
                            "Warnring",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                            );
                        list.Add(id);
                    }
                    else
                    {
                        db.Accounts.Remove(data);
                        BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Deleted account with old ID: {0}", data.ID));
                        db.SaveChanges();
                    }
                }

                if (list.Count > 0)
                {
                    string error = "Some accounts by ID cannot be deleted.\nID: ";
                    foreach (int id in list)
                        error += id.ToString() + ' ';
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static bool ChangePassword(string username, string newPassword, string oldPassword = null)
        {
            using (var db = new Model1())
            {
                var data = db.Accounts.Where(p => p.Username == username).FirstOrDefault();

                if (data.IsAdmin)
                {
                    if (oldPassword == null)
                    {
                        MessageBox.Show("Administrator must be enter its current password before change account password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (BUS.Account.MD5Hash(oldPassword) != data.Password)
                    {
                        MessageBox.Show("Incorrent current password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                data.Password = BUS.Account.MD5Hash(newPassword);
                db.SaveChanges();
                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Change password for acconunt ID: {0}", data.ID));
                return true;
            }
        }
    }
}
