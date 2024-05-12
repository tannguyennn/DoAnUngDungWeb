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
    public class DanhGiasController : Controller
    {
        private homestayEntities db = new homestayEntities();

        // GET: DanhGias
        public ActionResult Index()
        {
            var danhGias = db.DanhGias.Include(d => d.Homestay).Include(d => d.KhachHang);
            return View(danhGias.ToList());
        }

        // GET: DanhGias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }

        // GET: DanhGias/Create
        public ActionResult Create()
        {
            ViewBag.IDHomestay = new SelectList(db.Homestays, "IDHomestay", "TenHomestay");
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH");
            return View();
        }

        // POST: DanhGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDanhGia,IDHomestay,IDKH,NoiDung,NgayDanhGia")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                db.DanhGias.Add(danhGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDHomestay = new SelectList(db.Homestays, "IDHomestay", "TenHomestay", danhGia.IDHomestay);
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH", danhGia.IDKH);
            return View(danhGia);
        }

        // GET: DanhGias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHomestay = new SelectList(db.Homestays, "IDHomestay", "TenHomestay", danhGia.IDHomestay);
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH", danhGia.IDKH);
            return View(danhGia);
        }

        // POST: DanhGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDanhGia,IDHomestay,IDKH,NoiDung,NgayDanhGia")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDHomestay = new SelectList(db.Homestays, "IDHomestay", "TenHomestay", danhGia.IDHomestay);
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH", danhGia.IDKH);
            return View(danhGia);
        }

        // GET: DanhGias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }

        // POST: DanhGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhGia danhGia = db.DanhGias.Find(id);
            db.DanhGias.Remove(danhGia);
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
