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
        public ActionResult Sil(int id)
        {
            var urun = db.tbl_Urun.Find(id);
            db.tbl_Urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult urungetir(int id)
        {
            var urun = db.tbl_Urun.Find(id);
            List<SelectListItem> urungetir = (from i in db.tbl_Kategori.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.kategoriAd,
                                                    Value = i.kategoriId.ToString(),
                                                }).ToList();
            ViewBag.ktgr = urungetir;
            return View("urungetir",urun);
        }
        public ActionResult Guncelle(tbl_Urun p)
        {
            var urn = db.tbl_Urun.Find(p.urunId);
            urn.urunAd = p.urunAd;
            urn.marka = p.marka;
            urn.stok = p.stok;
            urn.fiyat = p.fiyat;

            var ktg = db.tbl_Kategori.Where(m => m.kategoriId == p.tbl_Kategori.kategoriId).FirstOrDefault();
            urn.kategoriId = ktg.kategoriId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }       
    }  
}