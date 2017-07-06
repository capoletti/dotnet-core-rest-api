using Microsoft.EntityFrameworkCore;

namespace rest_api.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options): base(options){ }
        public DbSet<Client> ClientBase { get; set; }
    }
}