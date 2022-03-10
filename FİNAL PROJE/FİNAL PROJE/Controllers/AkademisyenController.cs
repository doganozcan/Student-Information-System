using FİNAL_PROJE.Models;
using FİNAL_PROJE.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FİNAL_PROJE.Controllers
{
    public class AkademisyenController : Controller
    {
        DataContext db = new DataContext();
        ViewModel model = new ViewModel();

        [AllowAnonymous]
        public ActionResult Akademisyen_giris()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Akademisyen_giris(ogretmen GelenAkademisyen)
        {
            ogretmen Akisi = db.OgretmenTablosu.Where(d => d.Akullanici_adi == GelenAkademisyen.Akullanici_adi && d.Asifre == GelenAkademisyen.Asifre).FirstOrDefault();
            if (Akisi != null)
            {
                FormsAuthentication.SetAuthCookie(GelenAkademisyen.Akullanici_adi, false);
                return RedirectToAction("Akademisyen_anasayfa");
            }
            else
            {
                ViewBag.hata = "Hatalı Kullanıcı Adı Veya Şifre";
                return View();

            }
        }

        public ActionResult Akademisyen_anasayfa()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            model.OgretmenListesi = db.OgretmenTablosu.Where(x=>x.Akullanici_adi ==GirenUye).ToList();
            return View(model);
        }

        [HttpPost, ActionName("Akademisyen_anasayfa")]
        public ActionResult Akademisyen_anasayfaOK()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Akademisyen_giris");
        }

        public ActionResult A_KullanimKilavuzu()
        {
           
            return View();
        }

        public ActionResult Akademik_Takvim()
        {
            return View();
        }

        public ActionResult verilenders()
        {
            model.OgretmenListesi = db.OgretmenTablosu.ToList();
            return View(model);
        }

        public ActionResult notgiris()
        {
            string GirenAka = User.Identity.Name;
            model.AlinandersListesi = db.AlinandersTablosu.Where(x=>x.ogretmen_ID.ToString()==GirenAka).ToList();
            model.OgretmenListesi = db.OgretmenTablosu.ToList();
            return View(model);
        }

        public ActionResult NOTGİRİS()
        {  
            return View();
        }

        [HttpPost]
        public ActionResult NOTGİRİS(notlar alinan_notlar)
        {
            db.NotlarTablosu.Add(alinan_notlar);
            int sonuc = db.SaveChanges();

            if (sonuc > 0)
            {
                return RedirectToAction("notgiris", "Akademisyen");
            }
            else
            {
                return View();
            }
        }

        public ActionResult devamsizlik_giris()
        {
            string GirenAka = User.Identity.Name;
            model.AlinandersListesi = db.AlinandersTablosu.Where(x=>x.ogretmen_ID.ToString() == GirenAka).ToList();
            return View(model);
        }

        public ActionResult DEVAMSİZLİK_giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DEVAMSİZLİK_giris(devamsizlik Devamsizlik)
        {
            db.DevamsizlikTablosu.Add(Devamsizlik);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("devamsizlik_giris", "Akademisyen");
            }
            else
            {
                return View();
            }
        }

        public ActionResult A_profil()
        {
            model.OgretmenListesi = db.OgretmenTablosu.Where(x => x.ogretmen_ID.ToString() == User.Identity.Name).ToList();
            return View(model);
        }

        public ActionResult A_sifre_degistir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult A_sifre_degistir(int? OgrtmID, ogretmen model)
        {
            int sonuc = 0;
            ogretmen OgretmenNesnesi = db.OgretmenTablosu.Where(x => x.ogretmen_ID.ToString() == User.Identity.Name).FirstOrDefault(); 
            if (OgretmenNesnesi != null)
            {
                OgretmenNesnesi.Asifre = model.Asifre;
                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("Akademisyen_anasayfa", "Akademisyen");
            }
            else
            {
                return View();

            }
        }

        public ActionResult A_duyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult A_duyuru(duyuru Duyuru)
        {
            db.DuyuruTablosu.Add(Duyuru);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("Akademisyen_anasayfa", "Akademisyen");
            }
            else
            {
                return View();
            }
        }

      
    }
}