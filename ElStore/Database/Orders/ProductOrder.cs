using ElStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElStore.Database.Orders
{
    public class ProductOrder
    {
        readonly ShopDB db = new ShopDB();
        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(int? categoryId)
        {
            return db.Products.Where(x => x.CategoryId == categoryId);
        }

        public Product GetProductById(int? id)
        {
            return db.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            db.Entry(product).State = EntityState.Deleted;
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}