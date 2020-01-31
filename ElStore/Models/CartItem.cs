using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElStore.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public string CartItemName { get; set; }
        public string CartItemImg { get; set; }
        public int CartItemPrice { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}