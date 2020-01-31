using ElStore.Database;
using ElStore.Database.Orders;
using ElStore.Logs;
using ElStore.Models;
using ElStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ElStore.Controllers
{
    public class ProductController : Controller
    {
        readonly ProductOrder order = new ProductOrder();

        public ActionResult Index()
        {

            ProductsViewModel products = new ProductsViewModel
            {
                Products = order.GetAllProducts()
            };


            return View(products);
        }

        public ActionResult GPBCID(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductsViewModel products = new ProductsViewModel
            {
                Products = order.GetProductsByCategory(id)
            };

            return View(products);
        }

        public ActionResult GetProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductViewModel product = new ProductViewModel
            {
                Product = order.GetProductById(id)
            };

            if (product.Product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct([Bind(Include = "ProductName, ProductPrice, ProductDescription, ProductImg, CategoryId")]Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    order.AddProduct(product);
                }
            }
            catch (DataException dex)
            {
                ShopDB db = new ShopDB();
                db.Logs.Add(new Log { LogDesc = dex.ToString() });
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = order.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPut(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopDB db = new ShopDB();
            var productToUpdate = db.Products.Find(id);
            if (TryUpdateModel(productToUpdate, "",
                new string[] { "ProductName", "ProductPrice", "ProductDescription", "ProductImg", "CategoryId" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception dex)
                {
                    db.Logs.Add(new Log { LogDesc = dex.ToString() });
                }
            }
            return View(productToUpdate);
        }

        public ActionResult DeleteProduct(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Ошибка удаления. Повторите попытку, если ошибка повторяется, позовите сис. админ-а";
            }
            var product = order.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = order.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            order.DeleteProduct(product);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ShopDB db = new ShopDB();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}