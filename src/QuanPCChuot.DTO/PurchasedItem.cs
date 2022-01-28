using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanPCChuot.DTO
{
    public class PurchasedItem
    {
        public long ID { get; set; }

        public string Name { get; set; }
        
        public int Count { get; set; }

        public string Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
