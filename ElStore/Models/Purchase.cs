using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElStore.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string BuyerName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string BuyerPhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string BuyerEmail { get; set; }
        public DateTime Date { get; set; }
        public int PurchasePrice { get; set; }
        public virtual List<PurchaseDetails> Details { get; set; }
    }
}