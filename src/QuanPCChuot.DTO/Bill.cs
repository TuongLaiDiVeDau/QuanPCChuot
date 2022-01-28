namespace QuanPCChuot.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            
        }

        public long ID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        [StringLength(20)]
        public string CustomerTelephone { get; set; }

        public long StaffID { get; set; }

        public string ServiceIDs { get; set; }

        public bool DiscountEnabled { get; set; }

        public bool DiscountType { get; set; }

        public decimal DiscountValue { get; set; }

        public int Purchased { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
