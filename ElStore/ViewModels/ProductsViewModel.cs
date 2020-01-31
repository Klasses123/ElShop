using ElStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElStore.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}