using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSatisTakip.Models;
using PagedList;

namespace MVCSatisTakip.Controllers
{
    public class KategoriController : Controller
    {
        SatisTakipEntities db = new SatisTakipEntities();
        // GET: Kategori
        public ActionResult Index(int sayfa=1)
        {
            var kategori = db.tbl_Kategori.ToList().ToPagedList(sayfa, 7);
            return View(kategori);
        }
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(tbl_Kategori p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yeniiiiiiiii   Kategori");
            }
            var ktg= db.tbl_Kategori.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.tbl_Kategori.Find(id);
            db.tbl_Kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.tbl_Kategori.Find(id);
            return View("kategorigetir", kategori);
        }
        public ActionResult Guncelle(tbl_Kategori p1)
        {
            var ktg = db.tbl_Kategori.Find(p1.kategoriId);
            ktg.kategoriAd = p1.kategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}