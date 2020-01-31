using ElStore.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElStore.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public List<CartItem> Items { get; set; }
    }
}