using QuanPCChuot.DAL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace QuanPCChuot.BUS
{
    public static class GroupManager
    {
        public static DataTable GetAllGroups(string name = null)
        {
            using (var db = new Model1())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(long));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Created Date", typeof(DateTime));

                db.ItemGroups.Load();
                var d = db.ItemGroups.Local.ToList();
                if (name != null)
                    d = d.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();

                foreach (var dr in d)
                {
                    var row = dt.NewRow();
                    row["ID"] = dr.ID;
                    row["Name"] = dr.Name;
                    row["Description"] = dr.Description;
                    row["Created Date"] = dr.CreatedDate;
                    dt.Rows.Add(row);
                }

                return dt;
            }
        }

        public static DTO.ItemGroup GetGroupByID(long ID)
        {
            using (var db = new Model1())
            {
                db.ItemGroups.Load();
                var data = db.ItemGroups.Local.Where(p => p.ID == ID).FirstOrDefault();
                if (data == null)
                    MessageBox.Show("Group by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }
        }

        public static DTO.ItemGroup GetGroupByName(string name)
        {
            using (var db = new Model1())
            {
                db.ItemGroups.Load();
                var data = db.ItemGroups.Local.Where(p => p.Name == name).FirstOrDefault();
                if (data == null)
                    MessageBox.Show("Group by this name query isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }
        }

        public static void AddGroup(DTO.ItemGroup item)
        {
            using (var db = new Model1())
            {
                db.ItemGroups.Add(item);
                db.SaveChanges();
                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Added a group: {0} - {1}", item.ID, item.Name));
            }
        }

        public static void EditGroup(DTO.ItemGroup item)
        {
            using (var db = new Model1())
            {
                var data = db.ItemGroups.Where(p => p.ID == item.ID).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("Group by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                data.Name = item.Name;
                data.Description = item.Description;

                db.SaveChanges();
                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Made changes to a group: {0} - {1}", item.ID, item.Name));
            }
        }

        public static void DeleteGroupsByID(long[] ID)
        {
            using (var db = new Model1())
            {
                List<long> list = new List<long>();

                foreach (long id in ID)
                {
                    try
                    {
                        var data = db.ItemGroups.Where(p => p.ID == id).FirstOrDefault();
                        if (data == null)
                        {
                            MessageBox.Show("Group by this id isn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            db.ItemGroups.Remove(data);
                            BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Deleted a group: {0} - {1}", data.ID, data.Name));
                            db.SaveChanges();
                        }
                    }
                    catch
                    {
                        list.Add(id);
                    }
                }

                if (list.Count > 0)
                {
                    string error = "Some group by ID cannot be deleted.\nIDs: ";
                    foreach (int id in list)
                        error += id.ToString() + ' ';
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
