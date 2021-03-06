﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using QualityCaps.Models;

namespace QualityCaps.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: This is a partial view
        public ActionResult Index()
        {
           ShoppingCartItemViewModel model = new ShoppingCartItemViewModel();
            List<ShoppingCartItemViewModel> dbSession = new List<ShoppingCartItemViewModel>();
            if (Session["ShoppingCartProducts"] != null)
            {
                dbSession = (List<ShoppingCartItemViewModel>)Session["ShoppingCartProducts"];
            }
            ViewBag.Session = dbSession;
            return PartialView("Index", model);
        }


        // Add to cart
        public ActionResult AddToCart(string productID, string colorID)
        {
            List<ShoppingCartItemViewModel> dbSession = new List<ShoppingCartItemViewModel>();
            ShoppingCartItemViewModel item = new ShoppingCartItemViewModel();

            // Item only has ProductID and ColorID info
            var product = db.ProductColors
                .Single(p => p.ProductID.Equals(productID) && p.ColorID.Equals(colorID));

            item.ProductID = productID;
            item.ColorID = colorID;
            item.ProductName = product.Product.ProductName;
            item.UnitPrice = product.Product.UnitPrice;
            item.GstPercentage = product.Product.GstPercentage;
            item.ColorName = product.Color.ColorName;
            item.Category = product.Product.Category.CategoryName;
            item.ImageUrl = product.ImageUrl;

            // Check if session exists
            if (Session["ShoppingCartProducts"] == null||( Session["ShoppingCartProducts"] as List<ShoppingCartItemViewModel>).Count==0)
            {
                item.Quantity = 1;
                Session["ShoppingCartProducts"] = new List<ShoppingCartItemViewModel>() { item };
                dbSession = (List<ShoppingCartItemViewModel>)Session["ShoppingCartProducts"];
            }
            else
            {
                dbSession = (List<ShoppingCartItemViewModel>)Session["ShoppingCartProducts"];
                // Check if item is already in the list, if so , increment the quantity
                ShoppingCartItemViewModel cartItem = (dbSession.Where(p => p.ProductID.Equals(productID) && p.ColorID.Equals(colorID))).SingleOrDefault();
                if (cartItem != null)
                {
                    cartItem.Quantity++;

                }
                else
                {
                    item.Quantity = 1;
                    dbSession.Add(item);
                }

                //Add item to session
                Session["ShoppingCartProducts"] = dbSession;


            }
            int quantity = dbSession.Sum(p => p.Quantity);

            return Json(quantity);
        }

        // Get the cartTotal amount of items in cart
        public ActionResult GetItemsTotalAmount() {
            int quantity = 0 ;
            if (Session["ShoppingCartProducts"] != null)
            {
                quantity = (Session["ShoppingCartProducts"] as List<ShoppingCartItemViewModel>).Sum(p => p.Quantity);
            }

            return Json(quantity);
        }

        public ActionResult ClearCart() {
            int leftItemsTotalQty = 0;
            Session.Abandon();

            return Json(leftItemsTotalQty);
        }

        public ActionResult DeleteItem(string productID, string colorID)
        {
            int leftItemsTotalQty = 0;
            List<ShoppingCartItemViewModel> dbSession = new List<ShoppingCartItemViewModel>();
            if (Session["ShoppingCartProducts"] != null)
            {
                dbSession = (List<ShoppingCartItemViewModel>)Session["ShoppingCartProducts"];
                // Get this item
                var item = dbSession.Where(p => p.ProductID.Equals(productID) && p.ColorID.Equals(colorID)).FirstOrDefault();
                dbSession.Remove(item);
                Session["ShoppingCartProducts"] = dbSession;

                // success: Return how many items left
                leftItemsTotalQty = dbSession.Sum(p => p.Quantity);
            }

            return Json(leftItemsTotalQty);
        }


        public ActionResult ModifyItemQuantity(string productID, string colorID, string quantity)
        {
            int cartTotalQty = 0;
            decimal cartSubTotal=0;
            decimal cartGst=0;
            decimal cartTotal=0;
            decimal itemTotal = 0;
             
            List<ShoppingCartItemViewModel> dbSession = new List<ShoppingCartItemViewModel>();
            if (Session["ShoppingCartProducts"] != null)
            {
                dbSession = (List<ShoppingCartItemViewModel>)Session["ShoppingCartProducts"];
                // Get this item
                var item = dbSession.Where(p => p.ProductID.Equals(productID) && p.ColorID.Equals(colorID)).FirstOrDefault();
                if (Convert.ToInt32(quantity) > 0)
                {
                    item.Quantity = Convert.ToInt32(quantity);
                    itemTotal = item.TotalPrice;
                }
                else
                {
                    dbSession.Remove(item);
                }

                // success: Return json
                cartTotalQty = dbSession.Sum(p => p.Quantity);
                cartSubTotal = dbSession.Sum(p => p.TotalPrice);
                cartGst=dbSession.Sum(
                     p =>
                         p.TotalPrice*
                         Convert.ToDecimal(p.GstPercentage * 0.01));
                cartTotal = cartSubTotal + cartGst;
                

                Session["ShoppingCartProducts"] = dbSession;
            }

            string returnJson= new JavaScriptSerializer().Serialize(new
            {
                CartTotalQty = cartTotalQty,
                CartSubTotal = cartSubTotal.ToString("C2", CultureInfo.CurrentCulture),
                CartGst = cartGst.ToString("C2", CultureInfo.CurrentCulture),
                CartTotal = cartTotal.ToString("C2", CultureInfo.CurrentCulture),
                ItemTotal= itemTotal.ToString("C2", CultureInfo.CurrentCulture)
            });

            return Json(returnJson);
        }



        // GET: ProductColors/Details/5
        public ActionResult Details(string productID, string colorID)
        {
            if (productID == null || colorID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.ProductColors.Find(productID, colorID);
            if (productColor == null)
            {
                return HttpNotFound();
            }

            // Get all the products sharing same productID but with differnt color
            var productColors = db.ProductColors.Include(p => p.Color).Include(p => p.Product);

            // Color List
            var colorList = new List<Color>();
            var colorQry = from p in productColors where p.ProductID.Equals(productID) orderby p.ColorID select p.Color;
            colorList.AddRange(colorQry.Distinct());
            ViewBag.colorID = new SelectList(colorList, "ColorID", "ColorName");

            return View(productColor);
        }

        // GET: ProductColors/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "SupplierID");
            return View();
        }

        // POST: ProductColors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ColorID,QuantityInStock,ImageUrl")] ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                db.ProductColors.Add(productColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productColor.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "SupplierID", productColor.ProductID);
            return View(productColor);
        }

        // GET: ProductColors/Edit/5
        public ActionResult Edit(string productID, string colorID)
        {
            if (productID == null || colorID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.ProductColors.Find(productID, colorID);
            if (productColor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productColor.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "SupplierID", productColor.ProductID);
            return View(productColor);
        }

        // POST: ProductColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ColorID,QuantityInStock,ImageUrl")] ProductColor productColor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productColor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productColor.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "SupplierID", productColor.ProductID);
            return View(productColor);
        }

        // GET: ProductColors/Delete/5
        public ActionResult Delete(string productID, string colorID)
        {
            if (productID == null || colorID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductColor productColor = db.ProductColors.Find(productID, colorID);
            if (productColor == null)
            {
                return HttpNotFound();
            }
            return View(productColor);
        }

        // POST: ProductColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string productID, string colorID)
        {
            ProductColor productColor = db.ProductColors.Find(productID, colorID);
            db.ProductColors.Remove(productColor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
