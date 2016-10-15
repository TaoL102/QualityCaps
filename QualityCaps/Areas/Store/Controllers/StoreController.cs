using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using Microsoft.Ajax.Utilities;
using QualityCaps.Models;
using PagedList;

namespace QualityCaps.Controllers
{
    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Search for Products based on category & color
        public ActionResult Index(string search, string[] chkBoxesCategoryIDs, string[] chkBoxesColorIDs, string[] chkBoxesSupplierIDs, int? page)
        {


            var productColors = db.ProductColors.Include(p => p.Color).Include(p => p.Product);
            var supplers = db.Suppliers;
            // Search key word
            ViewBag.search = search;

            // Category List
            var categoryList = new List<Category>();
            var categoryQry = from p in productColors orderby p.Product.CategoryID select p.Product.Category;
            categoryList.AddRange(categoryQry.Distinct());
            ViewBag.categoryList = categoryList;

            // Color List
            var colorList = new List<Color>();
            var colorQry = from p in productColors orderby p.ColorID select p.Color;
            colorList.AddRange(colorQry.Distinct());
            ViewBag.colorList = colorList;

            // Supllier List
            var supllierList = new List<Supplier>();
            supllierList.AddRange(supplers.Distinct());
            ViewBag.supplierList = supllierList;


            // Search 
            if (!String.IsNullOrEmpty(search))
            {
                productColors = productColors.Where(s => s.Product.ProductName.Contains(search));
            }
            if (chkBoxesColorIDs != null)
            {
                productColors = productColors.Where(s => chkBoxesColorIDs.Contains(s.ColorID));
            }
            if (chkBoxesCategoryIDs != null)
            {
                productColors = productColors.Where(s => chkBoxesCategoryIDs.Contains(s.Product.CategoryID));
            }
            if (chkBoxesSupplierIDs != null)
            {
                productColors = productColors.Where(s => chkBoxesSupplierIDs.Contains(s.Product.SupplierID));
            }

            // 
            ViewBag.chkBoxesCategoryIDs = chkBoxesCategoryIDs ?? new string[0];
            ViewBag.chkBoxesColorIDs = chkBoxesColorIDs ?? new string[0];
            ViewBag.chkBoxesSupplierIDs = chkBoxesSupplierIDs ?? new string[0];

            int pageSize = 9;

            int pageNumber = (page ?? 1);

            return View(productColors.OrderBy(p => p.Product.ProductName).ToPagedList(pageNumber, pageSize));
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
            ViewBag.colorID = colorList;

            // Current Product color
            ViewBag.currentColorID = colorID;

            return PartialView("Details", productColor);
        }

        /// <summary>
        /// Get Product Picture
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="colorID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetProductPic(string productID, string colorID)
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

            string imageUrl = null;

            // Get the picURL
            var item = db.ProductColors.FirstOrDefault(p => p.ProductID.Equals(productID) && p.ColorID.Equals(colorID));
            if (item != null)
            {
                imageUrl = item.ImageUrl;

            }

            return Json(imageUrl);
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
