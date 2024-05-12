using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeStayWeb.Models;

namespace HomeStayWeb.Controllers
{
    public class HomestaysController : Controller
    {
        private homestayEntities db = new homestayEntities();

        // GET: Homestays
        public ActionResult Index()
        {
            return View(db.Homestays.ToList());
        }

        // GET: Homestays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homestay homestay = db.Homestays.Find(id);
            if (homestay == null)
            {
                return HttpNotFound();
            }
            return View(homestay);
        }

        // GET: Homestays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homestays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHomestay,TenHomestay,TrangThai,HinhAnh")] Homestay homestay)
        {
            if (ModelState.IsValid)
            {
                db.Homestays.Add(homestay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homestay);
        }

        // GET: Homestays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homestay homestay = db.Homestays.Find(id);
            if (homestay == null)
            {
                return HttpNotFound();
            }
            return View(homestay);
        }

        // POST: Homestays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHomestay,TenHomestay,TrangThai,HinhAnh")] Homestay homestay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homestay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homestay);
        }

        // GET: Homestays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homestay homestay = db.Homestays.Find(id);
            if (homestay == null)
            {
                return HttpNotFound();
            }
            return View(homestay);
        }

        // POST: Homestays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Homestay homestay = db.Homestays.Find(id);
            db.Homestays.Remove(homestay);
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
