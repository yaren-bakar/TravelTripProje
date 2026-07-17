using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(Admin ad)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici &&
            x.Sifre == ad.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                Session["Kullanici"] = bilgiler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["Mesaj"] = "Kullanıcı Adı veya Şifre Hatalıı!!";
                return View();
            }
        }

        public ActionResult CıkısYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris", "Login");
        }
    }
}