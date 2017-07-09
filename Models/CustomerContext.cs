using Microsoft.EntityFrameworkCore;

namespace rest_api.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options): base(options){ }
        public DbSet<Customer> CustomerBase { get; set; }
    }
}