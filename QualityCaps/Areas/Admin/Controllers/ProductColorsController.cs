using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using QualityCaps.Models;
using WebGrease.Activities;

namespace QualityCaps.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductColorsController : Controller
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
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductID");
            return View();
        }

        // POST: ProductColors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ColorID,QuantityInStock,ImageUrl")] ProductColor productColor, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                // Save picture to image folder
                if (upload != null && upload.ContentLength > 0)
                {
                    // Check file type
                    if (IsImage(upload))
                    {                    
                        // filename
                    string fileName = Path.GetFileName(upload.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        upload.SaveAs(path);

                        // Save to database
                        productColor.ImageUrl = fileName;
                        db.ProductColors.Add(productColor);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productColor.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductID", productColor.ProductID);
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
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductID", productColor.ProductID);
            return View(productColor);
        }

        // POST: ProductColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ColorID,QuantityInStock,ImageUrl")] ProductColor productColor, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                // Save picture to image folder
                if (upload != null && upload.ContentLength > 0)
                {
                    // Check file type
                    if (IsImage(upload))
                    {
                        // filename
                        string fileName = Path.GetFileName(upload.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        upload.SaveAs(path);

                        // Save to database
                        productColor.ImageUrl = fileName;
                        db.Entry(productColor).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }


               
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", productColor.ColorID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductID", productColor.ProductID);
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

        public const int ImageMinimumBytes = 512;

        public static bool IsImage(HttpPostedFileBase postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                        postedFile.ContentType.ToLower() != "image/jpeg" &&
                        postedFile.ContentType.ToLower() != "image/pjpeg" &&
                        postedFile.ContentType.ToLower() != "image/gif" &&
                        postedFile.ContentType.ToLower() != "image/x-png" &&
                        postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.InputStream.CanRead)
                {
                    return false;
                }

                if (postedFile.ContentLength < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[512];
                postedFile.InputStream.Read(buffer, 0, 512);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            //-------------------------------------------
            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image
            //-------------------------------------------

            try
            {
                using (var bitmap = new System.Drawing.Bitmap(postedFile.InputStream))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
