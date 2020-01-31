using ElStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElStore.Database.Orders
{
    public class CartOrder
    {
        ShopDB db = new ShopDB();

        public IEnumerable<CartItem> GetAllItems()
        {
            return db.CartItems.ToList();
        }

        public CartItem GetCartItemById(int? id)
        {
            return db.CartItems.Where(x => x.CartItemId == id).FirstOrDefault();
        }

        public void DeleteCartItem(CartItem item)
        {
            db.CartItems.Remove(item);
            db.SaveChanges();
        }

        public void AddItem(CartItem item)
        {
            db.CartItems.Add(item);
            db.SaveChanges();
        }
    }
}