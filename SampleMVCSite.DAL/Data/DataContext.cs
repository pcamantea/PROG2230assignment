﻿using SampleMVCSite.Models;
using System.Data.Entity;

namespace SampleMVCSite.DAL.Data
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<SampleMVCSite.Models.Basket> Baskets { get; set; }

        public System.Data.Entity.DbSet<SampleMVCSite.Models.BasketItem> BasketItems { get; set; }

    }
}
