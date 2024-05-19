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
    public class ThanhToansController : Controller
    {
        private homestayEntities1 db = new homestayEntities1();

        // GET: ThanhToans
        public ActionResult Index()
        {
            var thanhToans = db.ThanhToans.Include(t => t.DatPhong).Include(t => t.NhanVien);
            return View(thanhToans.ToList());
        }

        // GET: ThanhToans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thanhToan);
        }

        // GET: ThanhToans/Create
        public ActionResult Create()
        {
            ViewBag.IDDP = new SelectList(db.DatPhongs, "IDDP", "TrangThaiDatPhong");
            ViewBag.IDNV = new SelectList(db.NhanViens, "IDNV", "TenNV");
            return View();
        }

        // POST: ThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDThanhToan,IDDP,IDNV,NgayThanhToan,Sotien")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                db.ThanhToans.Add(thanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDP = new SelectList(db.DatPhongs, "IDDP", "TrangThaiDatPhong", thanhToan.IDDP);
            ViewBag.IDNV = new SelectList(db.NhanViens, "IDNV", "TenNV", thanhToan.IDNV);
            return View(thanhToan);
        }

        // GET: ThanhToans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDP = new SelectList(db.DatPhongs, "IDDP", "TrangThaiDatPhong", thanhToan.IDDP);
            ViewBag.IDNV = new SelectList(db.NhanViens, "IDNV", "TenNV", thanhToan.IDNV);
            return View(thanhToan);
        }

        // POST: ThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDThanhToan,IDDP,IDNV,NgayThanhToan,Sotien")] ThanhToan thanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDP = new SelectList(db.DatPhongs, "IDDP", "TrangThaiDatPhong", thanhToan.IDDP);
            ViewBag.IDNV = new SelectList(db.NhanViens, "IDNV", "TenNV", thanhToan.IDNV);
            return View(thanhToan);
        }

        // GET: ThanhToans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            if (thanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thanhToan);
        }

        // POST: ThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThanhToan thanhToan = db.ThanhToans.Find(id);
            db.ThanhToans.Remove(thanhToan);
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
