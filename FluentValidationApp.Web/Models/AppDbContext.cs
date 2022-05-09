using Microsoft.EntityFrameworkCore;

namespace FluentValidationApp.Web.Models
{
    public class AppDbContext : DbContext // Context olabilmesi için EntityFrameworkCore namespace i altındaki DbContext sınıfından türetilir.
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // base ile base class ın yani DbContext classının constructor ını options parametresi ile tetikleriz.
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
