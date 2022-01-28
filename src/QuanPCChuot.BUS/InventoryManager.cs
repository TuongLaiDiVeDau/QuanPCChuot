using QuanPCChuot.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace QuanPCChuot.BUS
{
    public static class InventoryManager
    {
        public static DataTable GetAllInventories(string name = null)
        {
            using (var db = new Model1())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(long));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Manufacturer", typeof(string));
                dt.Columns.Add("Group Name", typeof(string));
                dt.Columns.Add("Count", typeof(long));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Cost Price", typeof(decimal));
                dt.Columns.Add("Sell Price", typeof(decimal));
                dt.Columns.Add("Warranty", typeof(int));
                dt.Columns.Add("Unit", typeof(string));
                dt.Columns.Add("Last Add Date", typeof(string));

                db.Inventories.Load();
                var d = db.Inventories.Local.ToList();
                if (name != null)
                    d = d.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();

                foreach (var dr in d)
                {
                    var row = dt.NewRow();
                    row["ID"] = dr.ID;
                    row["Name"] = dr.Name;
                    row["Manufacturer"] = dr.Manufacturer;
                    row["Group Name"] = dr.ItemGroup.Name;
                    row["Count"] = dr.Count;
                    row["Description"] = dr.Description;
                    row["Cost Price"] = dr.CostPrice;
                    row["Sell Price"] = dr.SellPrice;
                    row["Warranty"] = dr.Warranty;
                    row["Unit"] = dr.Unit;
                    row["Last Add Date"] = dr.LastAddDate;
                    dt.Rows.Add(row);
                }

                return dt;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static DTO.Inventory GetInventory(long ID)
        {
            using (var db = new Model1())
            {
                db.ItemGroups.Load();
                db.Inventories.Load();
                var data = db.Inventories.Local.Where(p => p.ID == ID).FirstOrDefault();
                if (data == null)
                    throw new Exception("Inventory by this ID isn't found.");
                return data;
            }
        }

        public static DTO.Inventory GetInventory(string name)
        {
            using (var db = new Model1())
            {
                db.ItemGroups.Load();
                db.Inventories.Load();
                var data = db.Inventories.Local.Where(p => p.Name == name).FirstOrDefault();
                if (data == null)
                    throw new Exception("Inventory by this name query isn't found.");
                return data;
            }
        }

        public static void AddInventory(DTO.Inventory item)
        {
            using (var db = new Model1())
            {
                db.Inventories.Add(item);
                db.SaveChanges();
                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Added an item to inventory: {0} - {1}", item.ID, item.Name));
            }
        }

        public static void EditInventory(DTO.Inventory item)
        {
            using (var db = new Model1())
            {
                var data = db.Inventories.Where(p => p.ID == item.ID).FirstOrDefault();
                if (data == null)
                    throw new Exception("Inventory by this ID isn't found.");

                data.Name = item.Name;
                data.Manufacturer = item.Manufacturer;
                data.GroupID = item.GroupID;
                data.Count = item.Count;
                data.Description = item.Description;
                data.CostPrice = item.CostPrice;
                data.SellPrice = item.SellPrice;
                data.Warranty = item.Warranty;
                data.Unit = item.Unit;
                
                db.SaveChanges();
                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Made changes to an inventory: {0} - {1}", item.ID, item.Name));
            }
        }

        public static void DeleteInventory(long[] ID)
        {
            using (var db = new Model1())
            {
                List<long> list = new List<long>();

                foreach (long id in ID)
                {
                    var data = db.Inventories.Where(p => p.ID == id).FirstOrDefault();
                    if (data == null)
                        list.Add(id);
                    else
                    {
                        db.Inventories.Remove(data);
                        BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Deleted an inventory: {0} - {1}", data.ID, data.Name));
                        db.SaveChanges();
                    }
                }

                if (list.Count > 0)
                {
                    string error = "Some inventories by ID cannot be deleted.\nID: ";
                    foreach (int id in list)
                        error += id.ToString() + ' ';
                    MessageBox.Show(error, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
