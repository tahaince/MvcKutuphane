using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    
    public class IslemlerController : Controller
    {
        KutuphaneSitesiEntities db = new KutuphaneSitesiEntities();
        // GET: Islemler
        public ActionResult Index()
        {
            var hrkt = db.TBL_HAREKET.Where(x=>x.ISLEMDURUM==true).ToList();
            return View(hrkt);
        }
    }
}