using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SoftwareLicense.Models
{
    public partial class HKEX_InventoryContext : DbContext
    {
        public HKEX_InventoryContext()
        {
        }

        public HKEX_InventoryContext(DbContextOptions<HKEX_InventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomSccm> CustomSccm { get; set; }
        public virtual DbSet<IancustomSccm> IancustomSccm { get; set; }
        public virtual DbSet<Licenses> Licenses { get; set; }
        public virtual DbSet<MatchingTable> MatchingTable { get; set; }
        public virtual DbSet<SamliteInv> SamliteInv { get; set; }
        public virtual DbSet<SoftwareFilterList> SoftwareFilterList { get; set; }
        public virtual DbSet<SoftwareInventory> SoftwareInventory { get; set; }
        public virtual DbSet<SoftwareLicenseBridge> SoftwareLicenseBridge { get; set; }
        public virtual DbSet<Softwares> Softwares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=HKEX_Inventory;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomSccm>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<IancustomSccm>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SamliteInv>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SoftwareFilterList>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SoftwareInventory>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<SoftwareLicenseBridge>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.LicenseFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LicenseFk)
                    .HasConstraintName("FK_SoftwareLicense_License");

                entity.HasOne(d => d.SoftwareFkNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.SoftwareFk)
                    .HasConstraintName("FK_SoftwareLicense_Software");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
