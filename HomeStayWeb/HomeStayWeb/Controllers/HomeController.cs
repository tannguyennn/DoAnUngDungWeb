using HomeStayWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeStayWeb.Controllers
{
    public class HomeController : Controller
    {
        private homestayEntities2 db = new homestayEntities2();
        public ActionResult Index()
        {
            return View(db.Phongs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {

            var data = db.NhanViens.Where(s => s.EmailNV.Equals(email) && s.MKNV.Equals(password));
            if (data.Count() > 0)
            {
                //add session
                Session["tennv"] = data.FirstOrDefault().TenNV;
                Session["emailnv"] = data.FirstOrDefault().EmailNV;
                Session["id"] = data.FirstOrDefault().IDNV;
                return RedirectToAction("Index", "Admin/NhanViens");
            }
            var data2 = db.KhachHangs.Where(s => s.EmailKH.Equals(email) && s.MKKH.Equals(password));
            if (data2.Count() > 0)
            {
                //add session
                Session["tenkh"] = data2.FirstOrDefault().TenKH;
                Session["emailkh"] = data2.FirstOrDefault().EmailKH;
                Session["id"] = data2.FirstOrDefault().IDKH;
                Session["sdtkh"] = data2.FirstOrDefault().SDTKH;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.error = "Tên đăng nhập hoặc mật khẩu không đúng";
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.KhachHangs.FirstOrDefault(s => s.EmailKH == _user.EmailKH);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(_user);
                    db.SaveChanges();
                    Session["tenkh"] = _user.TenKH;
                    Session["emailkh"] = _user.EmailKH;
                    Session["id"] = _user.IDKH;
                    ViewBag.SuccessMessage = "Đăng ký thành công!";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }
    }
}