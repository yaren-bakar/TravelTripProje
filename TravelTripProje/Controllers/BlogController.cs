using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelTripProje.Models.Siniflar;
using System.Web.Mvc;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        public ActionResult Index()
        {

            var bloglar = c.Blogs.ToList();
            ViewBag.SonBloglar = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(bloglar);
        }
        BlogYorum by = new BlogYorum();
        public ActionResult BlogDetay(int id)
        {
            //var bloglar = c.Blogs.Where(x=>x.ID==id).ToList();
  
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(y => y.Blogid == id).ToList();
            ViewBag.SonBloglar = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();

            return View(by);
        }



        public ActionResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return View();
        }
        [HttpPost]
        public ActionResult YorumYap(Yorumlar y)
        {
            if (y != null && !string.IsNullOrEmpty(y.Yorum))
            {
                c.Yorumlars.Add(y);
                c.SaveChanges();
            }
            return RedirectToAction("BlogDetay", new { id = y.Blogid });
        }

   
    }
}