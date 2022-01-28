namespace QuanPCChuot.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory()
        {
            
        }

        public long ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public long Count { get; set; }

        public string Description { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellPrice { get; set; }

        public int Warranty { get; set; }

        public long GroupID { get; set; }

        public string Unit { get; set; }

        public DateTime LastAddDate { get; set; }

        public virtual ItemGroup ItemGroup { get; set; }
    }
}
