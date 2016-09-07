using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QualityCaps.Models;

namespace QualityCaps.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Search for Products based on name
        //public ActionResult Index(string search)
        //{
        //    var productColors = db.ProductColors.Include(p => p.Color).Include(p => p.Product);
        //    if (!String.IsNullOrEmpty(search))
        //    {
        //        productColors = productColors.Where(s => s.Product.ProductName.Contains(search));
        //    }
        //    return View(productColors.ToList());
        //}

        // GET: Search for Products based on category & color
        public ActionResult Index(string search, string categoryID, string colorID)
        {
            var productColors = db.ProductColors.Include(p => p.Color).Include(p => p.Product);

            // Category List
            var categoryList = new List<Category>();
            var categoryQry = from p in productColors orderby p.Product.CategoryID select p.Product.Category;
            categoryList.AddRange(categoryQry.Distinct());
            ViewBag.categoryID = new SelectList(categoryList, "CategoryID", "CategoryName");

            // Color List
            var colorList = new List<Color>();
            var colorQry = from p in productColors orderby p.ColorID select p.Color;
            colorList.AddRange(colorQry.Distinct());
            ViewBag.colorID = new SelectList(colorList, "ColorID", "ColorName");


            // Search 
            if (!String.IsNullOrEmpty(search))
            {
                productColors = productColors.Where(s => s.Product.ProductName.Contains(search));
            }
            if (!String.IsNullOrEmpty(categoryID))
            {
                productColors = productColors.Where(p => p.Product.CategoryID.Equals(categoryID));
            }

            if (!String.IsNullOrEmpty(colorID))
            {
                productColors = productColors.Where(p => p.ColorID.Equals(colorID));
            }
            return View(productColors.ToList());
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
