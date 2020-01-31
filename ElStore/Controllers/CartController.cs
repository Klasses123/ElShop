using ElStore.Database;
using ElStore.Database.Orders;
using ElStore.Models;
using ElStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ElStore.Controllers
{
    public class CartController : Controller
    {
        readonly CartOrder cartOrder = new CartOrder();
        readonly ProductOrder productOrder = new ProductOrder();

        public ActionResult Index()
        {
            CartViewModel cart = new CartViewModel
            {
                CartItems = cartOrder.GetAllItems()
            };

            return View(cart);
        }

        public ActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = productOrder.GetProductById(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            cartOrder.AddItem(new CartItem
            {
                CartItemImg = product.ProductImg,
                CartItemName = product.ProductName,
                CartItemPrice = product.ProductPrice,
                ProductId = product.ProductId,
                CartId = 1
            });

            return RedirectToAction("Index", "Product");
        }

        public ActionResult DeleteFromCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            cartOrder.DeleteCartItem(cartOrder.GetCartItemById(id));
            return RedirectToAction("Index");
        }
    }
}