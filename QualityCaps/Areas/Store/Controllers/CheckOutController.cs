using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QualityCaps.Models;
using Microsoft.AspNet.Identity;


namespace QualityCaps.Controllers
{
    // This Authorize Attribute controls the permission
    [Authorize]
    public class CheckOutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        // GET: Orders/Details/5
        public ActionResult Index()
        {
            // Get cart info from session
            List<ShoppingCartItemViewModel> dbSession = new List<ShoppingCartItemViewModel>();

            Order order = new Order();
            if (Session["ShoppingCartProducts"] != null)
            {
                dbSession = (List<ShoppingCartItemViewModel>)Session["ShoppingCartProducts"];

                // Customer Information
                string usrID = User.Identity.GetUserId();
                order.CustomerID = db.Customers.Where(c => c.AccountID.Equals(usrID)).SingleOrDefault().CustomerID;
                order.Customer = db.Customers.Find(order.CustomerID);

                // Total info
                order.SubTotal = dbSession.Sum(p => p.UnitPrice * p.Quantity);
                order.Gst =
                    dbSession.Sum(
                        p =>
                            p.UnitPrice * p.Quantity *
                            Convert.ToDecimal(p.GstPercentage * 0.01));

                // Items in order
                List<OrderProduct> items = new List<OrderProduct>();
                foreach (ShoppingCartItemViewModel model in dbSession)
                {
                    OrderProduct item = new OrderProduct()
                    {
                        ProductID = model.ProductID,
                        ColorID = model.ColorID,
                        OrderID = order.OrderID,
                        Quantity = model.Quantity,

                    };
                    items.Add(item);
                }
            }

            // Session
            ViewBag.Session = Session["ShoppingCartProducts"];
            Session[order.CustomerID]= dbSession;
            return View(order);
        }



        // POST: Order Check Out
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm()
        {
            string message;
            Order order = new Order();

            // Get current usr(customer)
            string usrID = User.Identity.GetUserId();
            order.CustomerID = db.Customers.Where(c => c.AccountID.Equals(usrID)).SingleOrDefault().CustomerID;

            // Get cart info from session
            List<ShoppingCartItemViewModel> dbSession = new List<ShoppingCartItemViewModel>();

            if (Session[order.CustomerID] != null)
            {
                dbSession = (List<ShoppingCartItemViewModel>) Session[order.CustomerID];

                // Assign order id
                order.OrderID = CultureInfo.CurrentCulture.Name.Substring(3) + DateTime.Today.ToString("yyMMdd")+new Random().Next(10000000, 99999999) +"-"+Guid.NewGuid().ToString();

                // Order Date
                order.OrderDate = DateTime.Now;

                // Total info
                order.SubTotal = dbSession.Sum(p => p.UnitPrice*p.Quantity);
                order.Gst =
                    dbSession.Sum(
                        p =>
                            p.UnitPrice*p.Quantity*
                            Convert.ToDecimal(p.GstPercentage*0.01));

                // Status
                order.OrderStatusID = "Status001";

                // Items in order
                List<OrderProduct> items = new List<OrderProduct>();
                foreach (ShoppingCartItemViewModel model in dbSession)
                {
                    OrderProduct item = new OrderProduct()
                    {
                        ProductID = model.ProductID,
                        ColorID = model.ColorID,
                        OrderID = order.OrderID,
                        Quantity = model.Quantity,

                    };
                    items.Add(item);
                }
                order.OrderProducts = items;

                // Save to database
                db.Orders.Add(order);
                db.SaveChanges();

                // Clear session
                Session.Abandon();
                message = "Your order has been placed.";
            }
            else
            {
                message = "Error: Your order has been placed.";
            }

       

            return RedirectToAction("ManageOrders", "Manage", new { Message = message, area = "Account" });


        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstMidName", order.CustomerID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,Status,SubTotal,Gst,GrandTotal")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstMidName", order.CustomerID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
