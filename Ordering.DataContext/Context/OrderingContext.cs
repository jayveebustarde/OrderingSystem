using Ordering.DataContext.Entities;
using System.Data.Entity;

namespace Ordering.DataContext.Context
{
    public class OrderingContext : DbContext
    {
        public OrderingContext() : base("name=OrderingContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
