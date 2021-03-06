﻿using System;
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
    [Authorize(Roles = "Admin")]
    public class DepartmentsController : Controller
    {
        private TaxesContext db = new TaxesContext();

        // GET: Departments
        public ActionResult Index()
        {

            var departments = db.Departments.ToList();
            var view = new List<DepartmentView>();
            foreach (var department in departments)
            {
                view.Add(new DepartmentView()
                {
                    DepartmentId = department.DepartmentId,
                    MunicipalityList = department.Municipalities.ToList(),
                    Name = department.Name
                });
            }
            return View(view);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }

            var view = new DepartmentView()
            {
                DepartmentId = department.DepartmentId,
                MunicipalityList = department.Municipalities.OrderBy(m=>m.Name).ToList(),
                Name = department.Name
            };
            return View(view);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception exception)
                {
                    if (exception.InnerException != null &&
                        exception.InnerException.InnerException != null &&
                        exception.InnerException.InnerException.Message.Contains("Index"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same descripction");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, exception.Message);
                    }

                    return View(department);
                }

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception exception)
                {
                    if (exception.InnerException != null &&
                        exception.InnerException.InnerException != null &&
                        exception.InnerException.InnerException.Message.Contains("Index"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same descripction");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, exception.Message);
                    }

                    return View(department);
                }
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var department = db.Departments.Find(id);
            db.Departments.Remove(department);
            try
            {
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                if (exception.InnerException?.InnerException != null &&
                    exception.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    ModelState.AddModelError(string.Empty, "The record can't be deleted because has related records");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
                return View(department);
            }
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

        public ActionResult AddMunicipality(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            var view = new Municipality()
            {
                DepartmentId = department.DepartmentId
            };

            return View(view);
        }

        [HttpPost]
        public ActionResult AddMunicipality(Municipality view)
        {
            if (ModelState.IsValid)
            {
                db.Municipalities.Add(view);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception exception)
                {
                    if (exception.InnerException != null &&
                        exception.InnerException.InnerException != null &&
                        exception.InnerException.InnerException.Message.Contains("Index"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same descripction");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, exception.Message);
                    }
                    return View(view);
                }
                return RedirectToAction($"Details/{view.DepartmentId}");
            }
            return View(view);
        }

        public ActionResult DeleteMunicipality(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var municipality = db.Municipalities.Find(id);
            if (municipality == null)
            {
                return HttpNotFound();
            }
            db.Municipalities.Remove(municipality);
            try
            {
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }
            return RedirectToAction($"Details/{municipality.DepartmentId}");
        }

        public ActionResult EditMunicipality(int? municipalityId, int? departmentId)
        {
            if (municipalityId == null || departmentId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var municipality = db.Municipalities.Find(municipalityId);
            if (municipality == null)
            {
                return HttpNotFound();
            }
            return View(municipality);
        }

        [HttpPost]
        public ActionResult EditMunicipality(Municipality view)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view).State=EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                    return View(view);
                }
                return RedirectToAction($"Details/{view.DepartmentId}");
            }
            return View(view);
        }
    }
}
