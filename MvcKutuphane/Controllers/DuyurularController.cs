using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyurularController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Duyurular
        public ActionResult Index()
        {
            var duyuru = db.TBL_DUYURU.ToList();

            return View(duyuru);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(TBL_DUYURU p)
        {
            db.TBL_DUYURU.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}