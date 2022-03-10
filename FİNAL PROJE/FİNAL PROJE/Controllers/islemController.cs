using FİNAL_PROJE.Models;
using FİNAL_PROJE.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FİNAL_PROJE.Controllers
{
    public class islemController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Sil(int? DuyuruID)
        {
            duyuru duyuruN = null;
            if(DuyuruID != null)
            {
                duyuruN = db.DuyuruTablosu.Where(x => x.duyuru_ID == DuyuruID).FirstOrDefault();
            }
            return View(duyuruN);
        }

        [HttpPost,ActionName("Sil")]
        public ActionResult SilOk(int? DuyuruID)
        {
            duyuru duyuruN = db.DuyuruTablosu.Where(x => x.duyuru_ID == DuyuruID).FirstOrDefault();
            // Kişi kaydını silmeden önce ilişkili tablolardaki kayıtları silmeliyiz
            List<ogretmen> ogretmenList = db.OgretmenTablosu.Where(y => y.duyuru_ID== DuyuruID).ToList();
            foreach (var item in ogretmenList)
            {
                db.OgretmenTablosu.Remove(item);
            }
            db.DuyuruTablosu.Remove(duyuruN);
            db.SaveChanges();
            return RedirectToAction("Duyuru", "obs");
        }

        public ActionResult guncelle(int? OgrncNo)
        {
            ogrenci OgrenciNesnesi = null;
            if (OgrncNo != null)
            {
                OgrenciNesnesi = db.OgrenciTablosu.Where(x => x.ogrencino == OgrncNo).FirstOrDefault();
            }
            return View(OgrenciNesnesi);
        }


        [HttpPost]
        public ActionResult guncelle(int? OgrncNo, ogrenci model)
        {
            int sonuc = 0;
            ogrenci OgrenciNesnesi = db.OgrenciTablosu.Where(x => x.ogrencino == OgrncNo).FirstOrDefault(); ;
            if (OgrenciNesnesi != null)
            {
                OgrenciNesnesi.aile_adres = model.aile_adres;
                OgrenciNesnesi.aile_il = model.aile_il;
                OgrenciNesnesi.aile_postakodu = model.aile_postakodu;
                OgrenciNesnesi.aile_ilce = model.aile_ilce;

                OgrenciNesnesi.ikamet_adres = model.ikamet_adres;
                OgrenciNesnesi.ikamet_il = model.ikamet_il;
                OgrenciNesnesi.ikamet_ilce = model.ikamet_ilce;

                OgrenciNesnesi.cep1 = model.cep1;
                OgrenciNesnesi.cep2 = model.cep2;
                OgrenciNesnesi.cep3 = model.cep3;
                OgrenciNesnesi.eposta1 = model.eposta1;
                OgrenciNesnesi.eposta2 = model.eposta2;

                OgrenciNesnesi.banka_adi = model.banka_adi;
                OgrenciNesnesi.sube_adi = model.sube_adi;
                OgrenciNesnesi.iban = model.iban;
                OgrenciNesnesi.sube_kodu = model.sube_kodu;
                OgrenciNesnesi.hesap_numarasi = model.hesap_numarasi;
                OgrenciNesnesi.hesap_adi_soyadi = model.hesap_adi_soyadi;

                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("profil", "obs");
            }
            else
            {
                return View();

            }
        }

        public ActionResult DersSil(int? DersID)
        {
            alders aldersN = null;
            if (DersID != null)
            {
                aldersN = db.AlinandersTablosu.Where(x => x.ID_alinandersler == DersID).FirstOrDefault();
            }
            return View(aldersN);
        }


        [HttpPost, ActionName("DersSil")]
        public ActionResult DersSilOk(int? DersID)
        {
            alders aldersN = db.AlinandersTablosu.Where(x => x.ID_alinandersler == DersID).FirstOrDefault();
            db.AlinandersTablosu.Remove(aldersN);
            db.SaveChanges();
            return RedirectToAction("derskaldir", "obs");
        }
    }
}