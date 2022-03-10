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
    public class obsController : Controller
    {
        DataContext db = new DataContext();
        ViewModel model = new ViewModel();

        [AllowAnonymous]
        public ActionResult giris()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult giris(ogrenci Gelenkisi)
        {
            ogrenci kisi = db.OgrenciTablosu.Where(d => d.kullaniciAdi == Gelenkisi.kullaniciAdi && d.sifre == Gelenkisi.sifre).FirstOrDefault();
            if (kisi != null)
            {
                FormsAuthentication.SetAuthCookie(Gelenkisi.kullaniciAdi, false);
                return RedirectToAction("anasayfa");
            }
            else
            {
                ViewBag.hata = "Hatalı Kullanıcı Adı Veya Şifre";
                return View();

            }
        }


        public ActionResult sifre_degistir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult sifre_degistir(int? OgrncNo,ogrenci model)
        {
            int sonuc = 0;
            ogrenci OgrenciNesnesi = db.OgrenciTablosu.Where(x => x.ogrencino.ToString() == User.Identity.Name).FirstOrDefault(); ; ;
            if (OgrenciNesnesi!=null)
            {
                OgrenciNesnesi.sifre = model.sifre;
                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("anasayfa", "obs");
            }
            else
            {
                return View();

            }
        }


        public ActionResult derskaldir()
        {
            model.AlinandersListesi = db.AlinandersTablosu.ToList();
            return View(model);
        }


        public ActionResult transkript()
        {
            return View();
        }

        public ActionResult KullanimKilavuzu()
        {
            return View();
        }

        public ActionResult Akademik_Takvim()
        {
            return View();
        }


        public ActionResult profil()
        {
            model.OgrenciListesi = db.OgrenciTablosu.ToList();
            model.YoksisListesi = db.YoksisTablosu.ToList();
            return View(model);
        }


        public ActionResult derskayit()
        {
            model.OgretmenListesi = db.OgretmenTablosu.ToList();
            model.YoksisListesi = db.YoksisTablosu.ToList();
            model.NotlarListesi = db.NotlarTablosu.ToList();
            model.DersListesi = db.DersTablosu.ToList();
            return View(model);
        }
      
        public ActionResult DERS_KAYİT(int? DERS_ID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DERS_KAYİT(alders alinan_ders)
        {
            db.AlinandersTablosu.Add(alinan_ders);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("derskayit", "obs");
            }
            else
            {
                return View();
            }
        }


        public ActionResult belgetaleb()
        {
            return View();
        }

        [HttpPost]
        public ActionResult belgetaleb(belgetalep talep)
        {
            db.BelgeTablosu.Add(talep);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("BelgeTalepListe", "obs");
            }
            else
            {
                return View();
            }
        }

        public ActionResult BelgeTalepListe()
        {
            model.BelgeListesi = db.BelgeTablosu.ToList();
            return View(model);
        }

        public ActionResult alinanders()
        {

            model.AlinandersListesi = db.AlinandersTablosu.ToList();
            return View(model);
        }

        public ActionResult Duyuru()
        {
            model.DuyuruListesi = db.DuyuruTablosu.ToList();
            return View(model);
        }

        public ActionResult danisman()
        {
            model.YoksisListesi = db.YoksisTablosu.ToList();
            model.OgretmenListesi = db.OgretmenTablosu.ToList();
            return View(model);
        }

        public ActionResult anasayfa()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            model.OgrenciListesi = db.OgrenciTablosu.ToList();
            model.OgretmenListesi = db.OgretmenTablosu.ToList();
            model.DuyuruListesi = db.DuyuruTablosu.ToList();
            model.NotlarListesi = db.NotlarTablosu.ToList();
            model.YoksisListesi = db.YoksisTablosu.Where(y => y.ogrencino.ToString() == GirenUye).ToList();
            return View(model);
        }
      

        public ActionResult notlistesi()
        {
            model.DersListesi = db.DersTablosu.ToList();
            model.NotlarListesi = db.NotlarTablosu.ToList();
            //List<dersler> DersListesi = db.DersTablosu.ToList();
            return View(model);
        }

        public ActionResult Ders_Programi()
        {
            return View();
        }

        public ActionResult ogrenci()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            model.OgrenciListesi = db.OgrenciTablosu.Where(o => o.ogrencino.ToString() == GirenUye).ToList();
            model.YoksisListesi = db.YoksisTablosu.Where(y => y.ogrencino.ToString() == GirenUye).ToList();

            //model.OgrenciListesi = db.OgrenciTablosu.ToList();
            //model.YoksisListesi = db.YoksisTablosu.ToList();
            return View(model);
        }


        public int MesajSayi()
        {
            return db.DuyuruTablosu.Count((x => x.ID_alinandersler == x.ogretmen.ID_ders && x.dersler.ogrencino.ToString() == User.Identity.Name));
        }


        [HttpPost, ActionName("anasayfa")]
        public ActionResult anasayfaOK()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("giris");
        }

        public PartialViewResult _PartialPage1()
        {
            FormsAuthentication.SignOut();
            return PartialView("giris");
        }


        public ActionResult devamsizlik()
        {
            model.DevamsizlikListesi = db.DevamsizlikTablosu.ToList();
            return View(model);
        }
    }
}