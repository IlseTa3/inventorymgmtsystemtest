using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestInventoryMgmtSystem.Models;
using TestInventoryMgmtSystem.ViewModels.Registrations;


namespace TestInventoryMgmtSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LocationStock> LocationStocks { get; set; }
        
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ProductLocationStock> ProductLocationsStocks { get; set; }
        public DbSet<TestInventoryMgmtSystem.ViewModels.Registrations.IndexViewModel> IndexViewModel { get; set; } = default!;
    }
}
