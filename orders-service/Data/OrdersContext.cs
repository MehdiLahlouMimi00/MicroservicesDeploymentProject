using Microsoft.EntityFrameworkCore;
using OrdersService.Models;


namespace OrdersService.Data
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
