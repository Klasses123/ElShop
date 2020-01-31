using ElStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElStore.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }

        public int SummPrice()
        {
            return CartItems.Sum(x => x.CartItemPrice);
        }
    }
}