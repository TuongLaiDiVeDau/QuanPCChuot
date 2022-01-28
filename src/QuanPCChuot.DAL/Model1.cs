using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanPCChuot.DAL
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base(@"data source=(LocalDB)\MSSQLLocalDB;initial catalog=QuanPCChuot;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<DTO.Account> Accounts { get; set; }
        public virtual DbSet<DTO.Bill> Bills { get; set; }
        public virtual DbSet<DTO.Inventory> Inventories { get; set; }
        public virtual DbSet<DTO.ItemGroup> ItemGroups { get; set; }
        public virtual DbSet<DTO.Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO.Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<DTO.Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<DTO.Account>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<DTO.Account>()
                .HasMany(e => e.Bills)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.StaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DTO.Account>()
                .HasMany(e => e.Logs)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.StaffID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DTO.Bill>()
                .Property(e => e.CustomerTelephone)
                .IsUnicode(false);

            modelBuilder.Entity<DTO.Bill>()
                .Property(e => e.DiscountValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DTO.Inventory>()
                .Property(e => e.CostPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DTO.Inventory>()
                .Property(e => e.SellPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DTO.ItemGroup>()
                .HasMany(e => e.Inventories)
                .WithRequired(e => e.ItemGroup)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);
        }
    }
}
