namespace QuanPCChuot.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log
    {
        public long ID { get; set; }

        public long StaffID { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Account Account { get; set; }
    }
}
