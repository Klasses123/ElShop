using ElStore.Database;
using ElStore.Database.Orders;
using ElStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElStore.Controllers
{
    public class PurchaseController : Controller
    {
        ShopDB db = new ShopDB();
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(Purchase purchase)
        {
            List<CartItem> cartItems = db.CartItems.Where(x => x.CartId == 1).ToList();
            purchase.PurchasePrice = cartItems.Sum(x => x.CartItemPrice);
            purchase.Date = DateTime.Now;

            if (cartItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары для покупки");
            }

            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                db.SaveChanges();

                for (int i = 0; i < cartItems.Count; i++)
                {
                    db.PurchaseDetails.Add(new PurchaseDetails{
                        ProductId = cartItems[i].ProductId,
                        PurchaseId = purchase.PurchaseId
                    });
                    db.SaveChanges();

                    db.CartItems.Remove(cartItems[i]);
                    db.SaveChanges();
                }

                return RedirectToAction("Complete");
            }

            return View(purchase);
        }

        public ActionResult Complete()
        {
            ViewBag.Massage = "Заказ успешно оформлен!";
            return View();
        }
    }
}