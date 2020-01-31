using ElStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElStore.Database
{
    public class ShopInitializer : DropCreateDatabaseIfModelChanges<ShopDB>
    {
        protected override void Seed(ShopDB context)
        {
            var cart = new Cart();
            context.Carts.Add(cart);
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category{ CategoryName = "Компьютеры" },
                new Category{ CategoryName = "Телефоны" },
                new Category{ CategoryName = "Роутеры" }
            };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product
                {
                    ProductName = "Apple MacBook Pro 13 TB i5",
                    ProductDescription = "Серия: MacBook Pro, процессор Intel Core i5 2.5 ГГц, оперативная память 8гб",
                    ProductImg = "https://img.mvideo.ru/Pdb/30043985b.jpg",
                    ProductPrice = 159990,
                    CategoryId = 1
                },
                new Product
                {
                    ProductName = "Ноутбук игровой HP 15-cx0008ur",
                    ProductDescription = "Серия: Pavilion 15, процессор Intel Core i7 2,2 ГГц, 8 ГБ оперативной памяти",
                    ProductImg = "https://img.mvideo.ru/Pdb/30038905b.jpg",
                    ProductPrice = 87990,
                    CategoryId = 1
                },
                new Product
                {
                    ProductName = "Apple iPhone 11 Pro",
                    ProductDescription = "Серия: iPhone 11 Pro, Диагональ/разрешение 5.8/2436x1125 пикс.,  Тип процессора A13 Bionic, встроенная память: 64 GB",
                    ProductImg = "https://img.mvideo.ru/Pdb/30045435b.jpg",
                    ProductPrice = 89990,
                    CategoryId = 2
                },
                new Product
                {
                    ProductName = "Samsung A10",
                    ProductDescription = "my tel",
                    ProductImg = "https://cdn1.technopark.ru/technopark/photos_resized/product/600_600/153323/1_153323.jpg",
                    ProductPrice = 10000,
                    CategoryId = 2
                },
                new Product
                {
                    ProductName = "Ультрабук ASUS UX303UB",
                    ProductDescription = "Серия: ZenBook UX 303 (13), процессор Intel Core i5 2.3 ГГц, оперативная память 8гб",
                    ProductImg = "https://img.mvideo.ru/Pdb/30025879b2.jpg",
                    ProductPrice = 61990,
                    CategoryId = 1
                },
                new Product
                {
                    ProductName = "Samsung Galaxy S10+",
                    ProductDescription = "Серия: Samsung Galaxy S10+, Разрешение экрана 3040x1440 Пикс., Диагональ 6.4 , Встроенная память 1тб",
                    ProductImg = "https://img.mvideo.ru/Pdb/30045435b.jpg",
                    ProductPrice = 79990,
                    CategoryId = 2
                },
                new Product
                {
                    ProductName = "Wi-Fi роутер TP-Link 450Mbps",
                    ProductDescription = "Скорость передачи данных (Wi-Fi) до 450 МБит/сек Скорость передачи данных (LAN) 100 МБит/ сек",
                    ProductImg = "https://img.mvideo.ru/Pdb/50044791b.jpg",
                    ProductPrice = 1590,
                    CategoryId = 3
                },
                new Product
                {
                    ProductName = "Wi-Fi роутер TP-Link TL-WR841N V14.0",
                    ProductDescription = "Скорость передачи данных (Wi-Fi) до 300 МБит/сек Скорость передачи данных (LAN) 100 МБит/ сек",
                    ProductImg = "https://img.mvideo.ru/Pdb/50123335b.jpg",
                    ProductPrice = 1290,
                    CategoryId = 3
                },
                new Product
                {
                    ProductName = "Wi-Fi роутер TP-Link Archer C60",
                    ProductDescription = "Скорость передачи данных (Wi-Fi) до 450/867 МБит/сек Скорость передачи данных (LAN) 100 МБит/ сек",
                    ProductImg = "https://img.mvideo.ru/Pdb/50049119b.jpg",
                    ProductPrice = 2990,
                    CategoryId = 3
                }
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}