using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller

    {

        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog newblog)
        {


            if (!ModelState.IsValid)
            {
                return View(newblog);
            }
            c.Blogs.Add(newblog);
            c.SaveChanges();
            TempData["Mesaj"] = "Blog başarıyla eklendi!";
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var kayit = c.Blogs.Find(id);
            if (kayit == null)
            {
                TempData["Mesaj"] = "Silinmek istenen blog bulunamadı.";
                return RedirectToAction("Index");
            }
            c.Blogs.Remove(kayit);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        public ActionResult BlogGuncelle(Blog b)
        {

            if (!ModelState.IsValid)
            {
                return View("BlogGetir", b);
            }

            var blg = c.Blogs.Find(b.ID);
            if (blg == null)
            {
                return HttpNotFound();
            }
            blg.Açiklama = b.Açiklama;
            blg.Baslik = b.Baslik;
            blg.Tarih = b.Tarih;
            blg.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListele()
        {
            var degerler = c.Yorumlars.ToList();
            return View(degerler);

        }

        public ActionResult YorumSil(int id)
        {
            var kayitlar = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(kayitlar);
            c.SaveChanges();
            return RedirectToAction("YorumListele");
        }
        public ActionResult YorumGetir(int id)
        {
            var b = c.Yorumlars.Find(id);
            return View(b);
        }
        public ActionResult YorumGuncelle(Yorumlar b)
        {
            var blg = c.Yorumlars.Find(b.ID);
            blg.KullaniciAdi = b.KullaniciAdi;
            blg.Mail = b.Mail;
            blg.Yorum = b.Yorum;
            blg.Blogid = b.Blogid;
            c.SaveChanges();
            return RedirectToAction("YorumListele");
        }
        public ActionResult Iletisim()
        {
            return View();
        }
    }
}
