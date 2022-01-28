using Newtonsoft.Json;
using QuanPCChuot.DAL;
using QuanPCChuot.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanPCChuot.BUS
{
    public static class BillManager
    {
        public static DataTable GetAllBills()
        {
            return GetBillsFromDate(new DateTime(), DateTime.Now);
        }

        public static DataTable GetBillsFromDate(Nullable<DateTime> dateFrom = null, Nullable<DateTime> dateTo = null)
        {
            using (var db = new Model1())
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(long));
                dt.Columns.Add("Customer name", typeof(string));
                dt.Columns.Add("Customer address", typeof(string));
                dt.Columns.Add("Customer telephone", typeof(string));
                dt.Columns.Add("Staff name", typeof(string));
                dt.Columns.Add("Total amount", typeof(decimal));
                dt.Columns.Add("Discount", typeof(string));
                dt.Columns.Add("Purchase Status", typeof(string));
                dt.Columns.Add("Created Date", typeof(DateTime));

                db.Bills.Load();
                var d = db.Bills.Local.ToList();
                if (dateFrom != null && dateTo != null)
                {
                    DateTime dateFrom1 = new DateTime(dateFrom.Value.Year, dateFrom.Value.Month, dateFrom.Value.Day, 0, 0, 0);
                    DateTime dateTo1 = new DateTime(dateTo.Value.Year, dateTo.Value.Month, dateTo.Value.Day, 23, 59, 59);
                    d = d.Where(p => p.CreatedDate >= dateFrom1).Where(p => p.CreatedDate <= dateTo1).ToList();
                }

                foreach (var item in d)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = item.ID;
                    row["Customer name"] = item.CustomerAddress;
                    row["Customer address"] = item.CustomerAddress;
                    row["Customer telephone"] = item.CustomerTelephone;
                    row["Staff name"] = item.Account.Name;
                    row["Created date"] = item.CreatedDate;

                    switch (item.Purchased)
                    {
                        case 0:
                            row["Purchase Status"] = "Not purchased";
                            break;
                        case 1:
                            row["Purchase Status"] = "Cancelled";
                            break;
                        case 2:
                            row["Purchase Status"] = "Purchased";
                            break;
                        default:
                            row["Purchase Status"] = "Unknown";
                            break;
                    }

                    var purchasedList = GetListItemsByID(item.ID);
                    decimal tongtien = 0;
                    foreach (DTO.PurchasedItem purchasedItem in purchasedList)
                    {
                        tongtien += purchasedItem.TotalAmount;
                    }
                    row["Total amount"] = tongtien;

                    switch (item.DiscountEnabled)
                    {
                        case false:
                            row["Discount"] = "No";
                            break;
                        case true:
                            switch (item.DiscountType)
                            {
                                case false:
                                    row["Discount"] = item.DiscountValue;
                                    break;
                                case true:
                                    row["Discount"] = tongtien * (item.DiscountValue / 100);
                                    break;
                            }
                            break;
                    }

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
        public static int CheckBillStatusByID(long ID)
        {
            using (var db = new Model1())
            {
                db.Bills.Load();
                var data = db.Bills.Where(p => p.ID == ID).FirstOrDefault();
                if (data == null)
                    MessageBox.Show("Bill by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data.Purchased;
            }
        }

        public static long AddEmptyBill()
        {
            using (var db = new Model1())
            {
                DTO.Bill bill = new DTO.Bill();
                bill.StaffID = BUS.Account.LoggedInAccount.ID;
                bill.CreatedDate = DateTime.Now;
                bill.ServiceIDs = "[]";
                db.Bills.Add(bill);
                db.SaveChanges();
                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Added a bill with ID: {0}", bill.ID));

                return bill.ID;
            }
        }

        public static DTO.Bill GetBillByID(long ID)
        {
            using (var db = new Model1())
            {
                db.Bills.Load();
                db.Accounts.Load();
                db.Inventories.Load();
                var data = db.Bills.Local.Where(p => p.ID == ID).FirstOrDefault();
                if (data == null)
                    MessageBox.Show("Bill by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return data;
            }
        }

        public static void EditBill(DTO.Bill bill)
        {
            using (var db = new Model1())
            {
                db.Bills.Load();
                var data = db.Bills.Where(p => p.ID == bill.ID).FirstOrDefault();
                if (data == null)
                    MessageBox.Show("Bill by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                data.CustomerName = bill.CustomerName;
                data.CustomerAddress = bill.CustomerAddress;
                data.CustomerTelephone = bill.CustomerTelephone;
                data.StaffID = bill.StaffID;
                data.DiscountEnabled = bill.DiscountEnabled;
                data.DiscountType = bill.DiscountType;
                data.DiscountValue = bill.DiscountValue;
                data.Purchased = bill.Purchased;

                db.SaveChanges();

                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Made changes to a bill with ID: {0}", bill.ID));
            }
        }

        public static List<DTO.PurchasedItem> GetListItemsByID(long ID)
        {
            using (var db = new Model1())
            {
                db.Bills.Load();
                var data = db.Bills.Local.Where(p => p.ID == ID).FirstOrDefault();

                if (data == null)
                {
                    MessageBox.Show("List of purchased item by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return JsonConvert.DeserializeObject<List<PurchasedItem>>(data.ServiceIDs);
            }
        }

        public static void UpdateBillFromID(long billID)
        {
            using (var db = new Model1())
            {
                // Load previous service information
                db.Bills.Load();
                var data = db.Bills.Local.Where(p => p.ID == billID).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("List of purchased item by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If purchased/cancelled purchase, return.
                if (data.Purchased != 0)
                {
                    MessageBox.Show("This bill has already purchased/cancelled. You don't have to update them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get list of services id.
                var list = JsonConvert.DeserializeObject<List<PurchasedItem>>(data.ServiceIDs);

                for (int i = 0; i < list.Count; i++)
                {
                    var inventoryItem = BUS.InventoryManager.GetInventory(list[i].ID);
                    list[i].Name = inventoryItem.Name;
                    list[i].Unit = inventoryItem.Unit;
                    list[i].UnitPrice = inventoryItem.SellPrice;
                    list[i].TotalAmount = list[i].UnitPrice * list[i].Count;
                }

                // Save changes to bill
                data.ServiceIDs = JsonConvert.SerializeObject(list);
                db.SaveChanges();
            }
        }

        public static void AddItemFromID(long billID, long inventoryID, int count = 1)
        {
            using (var db = new Model1())
            {
                // Load previous service information
                var data = db.Bills.Where(p => p.ID == billID).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("List of purchased item by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If purchased/cancelled purchase, return.
                if (data.Purchased != 0)
                {
                    MessageBox.Show("This bill has already purchased/cancelled. You don't have to update them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get inventory to add
                var addItem = db.Inventories.Where(p => p.ID == inventoryID).FirstOrDefault();
                if (addItem == null)
                {
                    MessageBox.Show("Inventory by this id isn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Minus count of items
                addItem.Count -= count;

                // Get list of services id.
                var list = JsonConvert.DeserializeObject<List<PurchasedItem>>(data.ServiceIDs);
                // Add to item list.
                var list2 = list.Where(p => p.ID == inventoryID).FirstOrDefault();
                if (list2 != null)
                {
                    list2.Count += count;
                    list2.TotalAmount = list2.UnitPrice * list2.Count;
                }
                else list.Add(new PurchasedItem()
                     {
                         ID = addItem.ID,
                         Name = addItem.Name,
                         Unit = addItem.Unit,
                         Count = count,
                         UnitPrice = addItem.SellPrice,
                         TotalAmount = addItem.SellPrice * count
                     });

                // Save changes to bill
                data.ServiceIDs = JsonConvert.SerializeObject(list);
                db.SaveChanges();

                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Add a item to bill with ID: {0}", data.ID));
            }
        }

        public static void DeleteItemFromID(long billID, long inventoryID)
        {
            using (var db = new Model1())
            {
                // Load previous service information
                db.Bills.Load();
                var data = db.Bills.Local.Where(p => p.ID == billID).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("List of purchased item by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If purchased/cancelled purchase, return.
                if (data.Purchased != 0)
                {
                    MessageBox.Show("This bill has already purchased/cancelled. You don't have to update them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get list of services id.
                var list = JsonConvert.DeserializeObject<List<PurchasedItem>>(data.ServiceIDs);

                // Get item to remove
                var list2 = list.Where(p => p.ID == inventoryID).FirstOrDefault();
                if (list2 != null)
                {
                    // Add to inventory first, before remove this item.
                    var inventoryItem = db.Inventories.Where(p => p.ID == inventoryID).FirstOrDefault();
                    if (inventoryItem != null)
                        inventoryItem.Count += list2.Count;
                }

                // Remove
                list.Remove(list2);

                // Save changes to bill
                data.ServiceIDs = JsonConvert.SerializeObject(list);
                db.SaveChanges();

                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Deleted a item from bill with ID: {0}", data.ID));
            }
        }

        public static void DeleteAllItemsFromID(long billID)
        {
            using (var db = new Model1())
            {
                // Load previous service information
                db.Bills.Load();
                var data = db.Bills.Local.Where(p => p.ID == billID).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("List of purchased item by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If purchased/cancelled purchase, return.
                if (data.Purchased != 0)
                {
                    MessageBox.Show("This bill has already purchased/cancelled. You don't have to update them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get list of services id.
                var list = JsonConvert.DeserializeObject<List<PurchasedItem>>(data.ServiceIDs);
                // Add to inventory first, before remove this item.
                foreach (var item in list)
                {
                    var inventoryItem = db.Inventories.Where(p => p.ID == item.ID).FirstOrDefault();
                    if (inventoryItem == null)
                        continue;
                    inventoryItem.Count += item.Count;
                }
                // Remove
                list.Clear();

                // Save changes to bill
                data.ServiceIDs = JsonConvert.SerializeObject(list);
                db.SaveChanges();

                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Deleted all items from bill with ID: {0}", data.ID));

            }
        }

        public static void MarkThisBillByID(long billID, bool purchase)
        {
            using (var db = new Model1())
            {
                // Load previous service information
                db.Bills.Load();
                var data = db.Bills.Local.Where(p => p.ID == billID).FirstOrDefault();
                if (data == null)
                {
                    MessageBox.Show("List of purchased item by this ID isn't found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (purchase)
                    data.Purchased = 2;
                else
                {
                    data.Purchased = 1;

                    // Get list of services id.
                    var list = JsonConvert.DeserializeObject<List<PurchasedItem>>(data.ServiceIDs);
                    foreach (var item in list)
                    {
                        var inventoryItem = db.Inventories.Where(p => p.ID == item.ID).FirstOrDefault();
                        if (inventoryItem == null)
                            continue;
                        inventoryItem.Count += item.Count;
                    }
                }

                // Save changes to bill
                db.SaveChanges();

                BUS.LogManager.AddLog(Account.LoggedInAccount.ID, String.Format("Mark bill with ID = {0} is {1}", data.ID, purchase ? "purchased" : "cancelled"));
            }
        }

        public static List<long> GetPendingBill()
        {
            using (var db = new Model1())
            {
                // Load previous service information
                db.Bills.Load();
                var list = db.Bills.Local.ToList();

                List<long> listID = new List<long>();

                foreach (var item in list)
                {
                    if (item.Purchased == 0)
                        listID.Add(item.ID);
                }

                return listID;
            }
        }
    }
}
