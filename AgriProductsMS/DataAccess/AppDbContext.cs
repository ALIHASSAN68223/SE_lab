using AgriProductsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq;

namespace AgriProductsManagementSystem.DataAccess
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Purchaser> Purchasers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Deal> Deals { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Purchaser>().HasKey(p => p.PurchaserID);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeID);

            modelBuilder.Entity<Deal>()
       .HasKey(d => d.DealID);

           
        }

        // Additional methods for database operations
        public Purchaser GetPurchaserById(int purchaserId)
        {
            return Purchasers.FirstOrDefault(p => p.PurchaserID == purchaserId);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
        }

        public void AddPurchaser(Purchaser newPurchaser)
        {
            Purchasers.Add(newPurchaser);
            SaveChanges();
        }

        public void AddEmployee(Employee newEmployee)
        {
            Employees.Add(newEmployee);
            SaveChanges();
        }

        // Add more methods as needed for your application's requirements
    }
}
