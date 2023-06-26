using Microsoft.EntityFrameworkCore;
using MonopolyTest.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System;

namespace MonopolyTest.EF
{
    public class ApplicationContext : DbContext
    {
        private string dataSource = @"DESKTOP-O98QPDO\SQLEXPRESS";
        private string dataBase = "Monopoly";
        private string userName = "DESKTOP-O98QPDO\\User";
        private string connectionString;
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.connectionString = @"Data Source=" + dataSource + ";Initial Catalog="
                        + dataBase + ";Persist Security Info=True;User ID=" + userName + ";Trusted_Connection=True;" + ";TrustServerCertificate=True;" + "Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pallet>()
            .Property(p => p.Expiration_date)
            .IsRequired(false);

            modelBuilder.Entity<Box>().HasKey(b => new { b.PalletId, b.Id });
            modelBuilder.Entity<Pallet>().HasMany(p => p.Boxes).WithOne(b => b.Pallet).HasForeignKey(b => b.PalletId);
        }
    }
}
