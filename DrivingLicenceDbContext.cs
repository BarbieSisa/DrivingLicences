using Microsoft.EntityFrameworkCore;
using System;
using BusinessLayer;

namespace DataLayer
{
    public class DrivingLicenceDbContext : DbContext
    {
        public DrivingLicenceDbContext()
        {

        }
        public DrivingLicenceDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HAD030U\\SQLEXPRESS01;Database=ShopDb11J;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DrLicence>().Property(o => o.LicenceStatus).HasConversion<string>();
            modelBuilder.Entity<User>().Property(o => o.Location).HasConversion<string>();
            modelBuilder.Entity<DrLicence>().Property(o => o.Type).HasConversion<string>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<DrLicence> DrLicences { get; set; }
    }
}
