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
    public class DatPhongsController : Controller
    {
        private homestayEntities2 db = new homestayEntities2();

        // GET: DatPhongs
        public ActionResult Index()
        {
            var datPhongs = db.DatPhongs.Include(d => d.KhachHang).Include(d => d.Phong);
            return View(datPhongs.ToList());
        }

        // GET: DatPhongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatPhong datPhong = db.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return HttpNotFound();
            }
            return View(datPhong);
        }

        // GET: DatPhongs/Create
        public ActionResult Create()
        {
            return View(db.Phongs.ToList());
        }

        // POST: DatPhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DatPhong datPhong, DateTime? checkin, DateTime? checkout)
        {
            // Kiểm tra các tham số và xử lý yêu cầu
            if (ModelState.IsValid && checkin != null && checkout != null)
            {
                int idkh = Convert.ToInt32(Session["id"]);
                datPhong.NgayDat = DateTime.Now;
                datPhong.NgayCheckIn = (DateTime)checkin;
                datPhong.NgayCheckOut = (DateTime)checkout;
                datPhong.TrangThaiDatPhong = "Pending";
                datPhong.IDKH = idkh;
                db.DatPhongs.Add(datPhong);
                db.SaveChanges();

                return RedirectToAction("Create");
            }

            // Nếu ModelState không hợp lệ, trả về view với dữ liệu hiện tại
            return View();
        }
        // GET: DatPhongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatPhong datPhong = db.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH", datPhong.IDKH);
            ViewBag.IDPhong = new SelectList(db.Phongs, "IDPhong", "SoPhong", datPhong.IDPhong);
            return View(datPhong);
        }

        // POST: DatPhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDP,IDKH,IDPhong,NgayDat,NgayCheckIn,NgayCheckOut,TrangThaiDatPhong")] DatPhong datPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKH = new SelectList(db.KhachHangs, "IDKH", "TenKH", datPhong.IDKH);
            ViewBag.IDPhong = new SelectList(db.Phongs, "IDPhong", "SoPhong", datPhong.IDPhong);
            return View(datPhong);
        }

        // GET: DatPhongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatPhong datPhong = db.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return HttpNotFound();
            }
            return View(datPhong);
        }

        // POST: DatPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatPhong datPhong = db.DatPhongs.Find(id);
            db.DatPhongs.Remove(datPhong);
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
