namespace ElStore.Database
{
    using ElStore.Logs;
    using ElStore.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopDB : DbContext
    {
        public ShopDB()
            : base("name=ShopDB")
        {
            Database.SetInitializer(new ShopInitializer());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
    }
}