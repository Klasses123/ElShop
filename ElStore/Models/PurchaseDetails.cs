using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElStore.Models
{
    public class PurchaseDetails
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int PurchaseId { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}