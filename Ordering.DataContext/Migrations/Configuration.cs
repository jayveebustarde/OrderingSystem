namespace Ordering.DataContext.Migrations
{
    using Ordering.DataContext.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ordering.DataContext.Context.OrderingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Ordering.DataContext.Context.OrderingContext";
        }

        protected override void Seed(Ordering.DataContext.Context.OrderingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Products.AddOrUpdate( x=>x.Id,
                new Product() { Id = 1, IsPopular = false, Name = "Regular Product", Price = 100},
                new Product() { Id = 2, IsPopular = false, Name = "Ordinary Product", Price = 200},
                new Product() { Id = 3, IsPopular = false, Name = "Special Product", Price = 201}
                );

            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = 1, Email = "user@example.com", FirstName = "Test", LastName = "User", Password = "", Role = "" },
                new User() { Id = 2, Email = "user2@example.com", FirstName = "Test", LastName = "User", Password = "", Role = ""}
                );
        }
    }
}
