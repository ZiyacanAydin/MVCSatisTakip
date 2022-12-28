using MVCSatisTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCSatisTakip.Controllers
{
    public class UrunController : Controller
    {
        SatisTakipEntities db = new SatisTakipEntities();
        // GET: Urun
        public ActionResult Index(int sayfa=1)
        {
            var urunler = db.tbl_Urun.ToList().ToPagedList(sayfa, 7);
            return View(urunler);
        }
        public ActionResult Urunekle() 
        {
            List<SelectListItem> kategoriler =(from i in db.tbl_Kategori.ToList() select new SelectListItem
            {
                Text = i.kategoriAd,
                Value = i.kategoriId.ToString(),
            }).ToList();
            ViewBag.ktgr = kategoriler;
            return View(); 
        }
        [HttpPost]
        public ActionResult Urunekle(tbl_Urun p1)
        {
            if (p1.urunAd==null || p1.fiyat==null || p1.stok==null||p1.marka==null)
            {
                List<SelectListItem> kategoriler = (from i in db.tbl_Kategori.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.kategoriAd,
                                                        Value = i.kategoriId.ToString(),
                                                    }).ToList();
                ViewBag.ktgr = kategoriler;
                return View();
            }
            else
            {
                var ktg=db.tbl_Kategori.Where(m=>m.kategoriId==p1.kategoriId).FirstOrDefault();
                p1.tbl_Kategori=ktg;
                db.tbl_Urun.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}