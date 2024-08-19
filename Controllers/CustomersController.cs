using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCExamen.Models;

namespace MVCExamen.Controllers
{
    public class CustomersController : Controller
    {
        private CodigoDBEntities db = new CodigoDBEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.Where(x => x.IsActive == true).ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Where(x => x.CustomerID == id && x.IsActive == true).FirstOrDefault();
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Name,DocumentNumber,DocumentType")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                customers.IsActive = true;
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Where(x => x.CustomerID == id && x.IsActive == true).FirstOrDefault();
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Name,DocumentNumber,DocumentType")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                var customerModify = db.Customers.Where(x => x.CustomerID == customers.CustomerID).FirstOrDefault();
                db.Entry(customerModify).State = EntityState.Modified;
                customerModify.Name = customers.Name;
                customerModify.DocumentNumber = customers.DocumentNumber;
                customerModify.DocumentType = customers.DocumentType;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Where(x => x.CustomerID == id && x.IsActive == true).FirstOrDefault();
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Entry(customers).State = EntityState.Modified;
            customers.IsActive = false;
            //db.Customers.Remove(customers);
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

        // GET: Customers
        public ActionResult InactiveCustomers()
        {
            return View(db.Customers.Where(x => x.IsActive == false).ToList());
        }
    }
}
