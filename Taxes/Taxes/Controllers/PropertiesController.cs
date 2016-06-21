using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Taxes.Models;

namespace Taxes.Controllers
{
    public class PropertiesController : Controller
    {
        private TaxesContext db = new TaxesContext();

        // GET: Properties
        public ActionResult Index()
        {
            var properties = db.Properties.Include(p => p.Department).Include(p => p.Municipality).Include(p => p.PropertyType).Include(p => p.TaxPaer);
            return View(properties.ToList());
        }

        // GET: Properties/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            ViewBag.MunicipalityId = new SelectList(db.Municipalities, "MunicipalityId", "Name");
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "PropertyTypeId", "Description");
            ViewBag.TaxPaerId = new SelectList(db.TaxPaers, "TaxPaerId", "FirstName");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropertyId,TaxPaerId,Phone,DepartmentId,MunicipalityId,Address,PropertyTypeId,Stratus,Area")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", property.DepartmentId);
            ViewBag.MunicipalityId = new SelectList(db.Municipalities, "MunicipalityId", "Name", property.MunicipalityId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "PropertyTypeId", "Description", property.PropertyTypeId);
            ViewBag.TaxPaerId = new SelectList(db.TaxPaers, "TaxPaerId", "FirstName", property.TaxPaerId);
            return View(property);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", property.DepartmentId);
            ViewBag.MunicipalityId = new SelectList(db.Municipalities, "MunicipalityId", "Name", property.MunicipalityId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "PropertyTypeId", "Description", property.PropertyTypeId);
            ViewBag.TaxPaerId = new SelectList(db.TaxPaers, "TaxPaerId", "FirstName", property.TaxPaerId);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropertyId,TaxPaerId,Phone,DepartmentId,MunicipalityId,Address,PropertyTypeId,Stratus,Area")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", property.DepartmentId);
            ViewBag.MunicipalityId = new SelectList(db.Municipalities, "MunicipalityId", "Name", property.MunicipalityId);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "PropertyTypeId", "Description", property.PropertyTypeId);
            ViewBag.TaxPaerId = new SelectList(db.TaxPaers, "TaxPaerId", "FirstName", property.TaxPaerId);
            return View(property);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Property property = db.Properties.Find(id);
            db.Properties.Remove(property);
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
