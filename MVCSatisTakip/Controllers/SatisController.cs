using MVCSatisTakip.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSatisTakip.Controllers
{
    public class SatisController : Controller
    {
        SatisTakipEntities db = new SatisTakipEntities();
        // GET: Satis
        public ActionResult Index(int sayfa = 1)
        {
            var satis = db.tbl_Satis.ToList().ToPagedList(sayfa, 7);
            return View(satis);
        }
        public ActionResult Sil(int id)
        {
            var satis = db.tbl_Satis.Find(id);
            db.tbl_Satis.Remove(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult satisekle()
        {
            List<SelectListItem> musteriler = (from i in db.tbl_Musteri.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.musteriAd,
                                                   Value = i.musteriId.ToString(),
                                               }).ToList();
            List<SelectListItem> urunler = (from i in db.tbl_Urun.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.urunAd,
                                                Value = i.urunId.ToString(),
                                            }).ToList();
            ViewBag.mus = musteriler;
            ViewBag.urn = urunler;
            return View();
        }
        [HttpPost]
        public ActionResult satisekle(tbl_Satis s)
        {
            var prod = db.tbl_Urun.Find(s.tbl_Urun.urunId);

            if (s.satisAdet <= prod.stok)
            {
                if (s.satisAdet == null || s.satisFiyat == null || s.satisTarih == null)
                {

                    List<SelectListItem> musteriler = (from i in db.tbl_Musteri.ToList()
                                                       select new SelectListItem
                                                       {
                                                           Text = i.musteriAd,
                                                           Value = i.musteriId.ToString(),
                                                       }).ToList();
                    List<SelectListItem> urunler = (from i in db.tbl_Urun.ToList()
                                                    select new SelectListItem
                                                    {
                                                        Text = i.urunAd,
                                                        Value = i.urunId.ToString(),
                                                    }).ToList();
                    ViewBag.mus = musteriler;
                    ViewBag.urn = urunler;
                    return View();
                }
                else
                {
                    var must = db.tbl_Musteri.Where(x => x.musteriId == s.tbl_Musteri.musteriId).FirstOrDefault();
                    s.tbl_Musteri = must;
                    var urn = db.tbl_Urun.Where(x => x.urunId == s.tbl_Urun.urunId).FirstOrDefault();
                    s.tbl_Urun = urn;
                    db.tbl_Satis.Add(s);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(s);
        }
        public ActionResult satisgetir(int id)
        {
            var sts = db.tbl_Satis.Find(id);
            List<SelectListItem> musteriler = (from i in db.tbl_Musteri.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.musteriAd,
                                                   Value = i.musteriId.ToString(),
                                               }).ToList();
            List<SelectListItem> urunler = (from i in db.tbl_Urun.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.urunAd,
                                                Value = i.urunId.ToString(),
                                            }).ToList();
            ViewBag.mus = musteriler;
            ViewBag.urn = urunler;

            return View("satisgetir", sts);
        }
        public ActionResult Guncelle(tbl_Satis p1)
        {
            var sts = db.tbl_Satis.Find(p1.satisId);
            var must = db.tbl_Musteri.Where(x => x.musteriId == p1.tbl_Musteri.musteriId).FirstOrDefault();
            sts.musteriId = must.musteriId;

            var urn = db.tbl_Urun.Where(x => x.urunId == p1.tbl_Urun.urunId).FirstOrDefault();
            sts.urunId = urn.urunId;
            sts.satisAdet = p1.satisAdet;
            sts.satisFiyat= p1.satisFiyat;
            sts.satisTarih= p1.satisTarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public int GetFiyat(int id)
        {
            int fiyat = (int)db.tbl_Urun.Find(id).fiyat;
            return fiyat;
        }
    }
}