using MVCSatisTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSatisTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        SatisTakipEntities db = new SatisTakipEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var musteriler = db.tbl_Musteri.ToList().ToPagedList(sayfa, 7);
            return View(musteriler);
        }
        public ActionResult MusteriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MusteriEkle(tbl_Musteri p1)
        {
            if (!ModelState.IsValid)
            {
                return View("MusteriEkle");
            }
            var must = db.tbl_Musteri.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var musteri = db.tbl_Musteri.Find(id);
            db.tbl_Musteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musterigetir(int id)
        {
            var must = db.tbl_Musteri.Find(id);
            return View("musterigetir", must);
        }
        
        public ActionResult Guncelle(tbl_Musteri p1)
        {
            var must = db.tbl_Musteri.Find(p1.musteriId);
            must.musteriTc = p1.musteriTc;
            must.musteriAd = p1.musteriAd;
            must.musteriMeslek = p1.musteriMeslek;
            must.musteriSehir = p1.musteriSehir;
            must.musteriTel = p1.musteriTel;
            must.musteriAdres = p1.musteriAdres;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}