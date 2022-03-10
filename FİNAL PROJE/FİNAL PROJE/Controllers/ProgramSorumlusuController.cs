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
    public class ProgramSorumlusuController : Controller
    {
        DataContext db = new DataContext();
        ViewModel model = new ViewModel();


        [AllowAnonymous]
        public ActionResult PS_giris()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult PS_giris(Admin GelenAdmin)
        {
            Admin Adminkisi = db.AdminTablosu.Where(d => d.admin_Kullanici_adi == GelenAdmin.admin_Kullanici_adi && d.admin_sifre == GelenAdmin.admin_sifre).FirstOrDefault();
            if (Adminkisi != null)
            {
                FormsAuthentication.SetAuthCookie(GelenAdmin.admin_Kullanici_adi, false);
                return RedirectToAction("Admin_anasayfa");
            }
            else
            {
                ViewBag.hata = "Hatalı Kullanıcı Adı Veya Şifre";
                return View();

            }
        }

        public ActionResult Admin_anasayfa()
        {
            string GirenUye = HttpContext.User.Identity.Name;
            model.AdminListesi = db.AdminTablosu.Where(x=>x.admin_Kullanici_adi ==GirenUye).ToList();
            return View(model);
        }

        [HttpPost, ActionName("Admin_anasayfa")]
        public ActionResult anasayfaOK()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("giris","obs");
        }

        public ActionResult Admin_profil()
        {
            model.AdminListesi = db.AdminTablosu.ToList();
            return View(model);
        }


        public ActionResult Ogretmen_sil()
        {
            model.OgretmenListesi = db.OgretmenTablosu.ToList();
            return View(model);
        }


        public ActionResult Ogretmensil(int? OgretmenID)
        {
            ogretmen ogretmenN = null;
            if (OgretmenID != null)
            {
                ogretmenN = db.OgretmenTablosu.Where(x => x.ogretmen_ID == OgretmenID).FirstOrDefault();
            }
            return View(ogretmenN);
        }

        [HttpPost, ActionName("Ogretmensil")]
        public ActionResult OgretmensilOk(int? OgretmenID)
        {
            ogretmen ogretmenN = db.OgretmenTablosu.Where(x => x.ogretmen_ID == OgretmenID).FirstOrDefault();
            List<alders> aldersList = db.AlinandersTablosu.Where(y => y.ogretmen_ID == OgretmenID).ToList();
            foreach (var item in aldersList)
            {
                db.AlinandersTablosu.Remove(item);
            }

            List<dersler> dersList = db.DersTablosu.Where(y =>y.ogretmen_ID == OgretmenID.ToString()).ToList();
            foreach (var item2 in dersList)
            {
                db.DersTablosu.Remove(item2);
            }

            List<devamsizlik> devamsizlikList = db.DevamsizlikTablosu.Where(y => y.ogretmen_ID == OgretmenID).ToList();
            foreach (var item3 in devamsizlikList)
            {
                db.DevamsizlikTablosu.Remove(item3);
            }

            List<duyuru> duyuruList = db.DuyuruTablosu.Where(y => y.ogretmen_ID == OgretmenID).ToList();
            foreach (var item4 in duyuruList)
            {
                db.DuyuruTablosu.Remove(item4);
            }


            db.OgretmenTablosu.Remove(ogretmenN);
            db.SaveChanges();
            return RedirectToAction("Ogretmen_sil", "ProgramSorumlusu");
        }

        public ActionResult OgrtGuncelle()
        {
            model.OgretmenListesi = db.OgretmenTablosu.ToList();
            return View(model);
        }


        public ActionResult Ogrt_guncelle(int? OgretmenID)
        {
            ogretmen OgretmenNesnesi = null;
            if (OgretmenID != null)
            {
                OgretmenNesnesi = db.OgretmenTablosu.Where(x => x.ogretmen_ID == OgretmenID).FirstOrDefault();
            }
            return View(OgretmenNesnesi);
        }

        [HttpPost]
        public ActionResult Ogrt_guncelle(int? OgretmenID, ogretmen model)
        {
            int sonuc = 0;
            ogretmen OgretmenNesnesi = db.OgretmenTablosu.Where(x => x.ogretmen_ID == OgretmenID).FirstOrDefault(); ;
            if (OgretmenNesnesi != null)
            {
                OgretmenNesnesi.ad = model.ad;
                OgretmenNesnesi.soyad = model.soyad;
                OgretmenNesnesi.verdigidersadi = model.verdigidersadi;
                OgretmenNesnesi.ID_ders = model.ID_ders;
                OgretmenNesnesi.telefon = model.telefon;
                OgretmenNesnesi.eposta = model.eposta;

                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("OgrtGuncelle", "ProgramSorumlusu");
            }
            else
            {
                return View();

            }
        }


        public ActionResult OgrtEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgrtEkle(ogretmen OgrtKaydet)
        {
            db.OgretmenTablosu.Add(OgrtKaydet);
            int sonuc = db.SaveChanges();

            if (sonuc > 0)
            {
                return RedirectToAction("Admin_anasayfa", "ProgramSorumlusu");
            }
            else
            {
                return View();
            }
        }


        public ActionResult OgrncEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OgrncEkle(ogrenci OgrncKaydet)
        {
            db.OgrenciTablosu.Add(OgrncKaydet);
            int sonuc = db.SaveChanges();

            if (sonuc > 0)
            {
                return RedirectToAction("Admin_anasayfa", "ProgramSorumlusu");
            }
            else
            {
                return View();
            }
        }

        public ActionResult OgrncGuncelle()
        {
            model.OgrenciListesi = db.OgrenciTablosu.ToList();
            return View(model);
        }


        public ActionResult Ogrnc_Guncelle(int? OgrenciNo)
        {
            ogrenci OgrenciNesnesi = null;
            if (OgrenciNo != null)
            {
                OgrenciNesnesi = db.OgrenciTablosu.Where(x => x.ogrencino == OgrenciNo).FirstOrDefault();
            }
            return View(OgrenciNesnesi);
        }

        [HttpPost]
        public ActionResult Ogrnc_Guncelle(int? OgrenciNo, ogrenci model)
        {
            int sonuc = 0;
            ogrenci OgrenciNesnesi = db.OgrenciTablosu.Where(x => x.ogrencino == OgrenciNo).FirstOrDefault(); ;
            if (OgrenciNesnesi != null)
            {
                OgrenciNesnesi.ad = model.ad;
                OgrenciNesnesi.soyad = model.soyad;
                OgrenciNesnesi.anne_adi = model.anne_adi;
                OgrenciNesnesi.baba_adi = model.baba_adi;
                OgrenciNesnesi.dogumtarihi = model.dogumtarihi;
                OgrenciNesnesi.cinsiyet = model.cinsiyet;
                OgrenciNesnesi.uyruk = model.uyruk;
                OgrenciNesnesi.tc = model.tc;

                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("OgrncGuncelle", "ProgramSorumlusu");
            }
            else
            {
                return View();

            }
        }


        public ActionResult OgrnciSil()
        {
            model.OgrenciListesi = db.OgrenciTablosu.ToList();
            return View(model);
        }

        public ActionResult Ogrnci_Sil(int? OgrenciNo)
        {
            ogrenci OgrenciN = null;
            if (OgrenciNo != null)
            {
                OgrenciN = db.OgrenciTablosu.Where(x => x.ogrencino == OgrenciNo).FirstOrDefault();
            }
            return View(OgrenciN);
        }

        [HttpPost, ActionName("Ogrnci_Sil")]
        public ActionResult Ogrnci_SilOk(int? OgrenciNo)
        {
            ogrenci OgrenciN = db.OgrenciTablosu.Where(x => x.ogrencino == OgrenciNo).FirstOrDefault();
            List<alders> aldersList = db.AlinandersTablosu.Where(y => y.ogrencino == OgrenciNo).ToList();
            foreach (var item in aldersList)
            {
                db.AlinandersTablosu.Remove(item);
            }

            List<dersler> dersList = db.DersTablosu.Where(y => y.ogrencino == OgrenciNo).ToList();
            foreach (var item2 in dersList)
            {
                db.DersTablosu.Remove(item2);
            }

            List<yoksis> YoksisList = db.YoksisTablosu.Where(y => y.ogrencino == OgrenciNo).ToList();
            foreach (var item3 in YoksisList)
            {
                db.YoksisTablosu.Remove(item3);
            }

            db.OgrenciTablosu.Remove(OgrenciN);
            db.SaveChanges();
            return RedirectToAction("OgrnciSil", "ProgramSorumlusu");
        }

        public ActionResult DersEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DersEkle(dersler DersKaydet)
        {
            db.DersTablosu.Add(DersKaydet);
            int sonuc = db.SaveChanges();

            if (sonuc > 0)
            {
                return RedirectToAction("Admin_anasayfa", "ProgramSorumlusu");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Ders_GS()
        {
            model.DersListesi = db.DersTablosu.ToList();
            return View(model);
        }

        public ActionResult Ders_Sil(int? DersID)
        {
            dersler DersN = null;
            if (DersID != null)
            {
                DersN = db.DersTablosu.Where(x => x.ID_ders == DersID).FirstOrDefault();
            }
            return View(DersN);
        }

        [HttpPost, ActionName("Ders_Sil")]
        public ActionResult Ders_SilOK(int? DersID)
        {
            dersler DersN = db.DersTablosu.Where(x => x.ID_ders == DersID).FirstOrDefault();

            List<alders> aldersList = db.AlinandersTablosu.Where(y => y.ID_ders == DersID).ToList();
            foreach (var item in aldersList)
            {
                db.AlinandersTablosu.Remove(item);
            }

            List<duyuru> DuyuruList = db.DuyuruTablosu.Where(y => y.ID_ders == DersID).ToList();
            foreach (var item2 in DuyuruList)
            {
                db.DuyuruTablosu.Remove(item2);
            }

            List<ogretmen> OgretmenList = db.OgretmenTablosu.Where(y => y.ID_ders == DersID).ToList();
            foreach (var item3 in OgretmenList)
            {
                db.OgretmenTablosu.Remove(item3);
            }

            List<notlar> NotlarList = db.NotlarTablosu.Where(y => y.ID_ders == DersID).ToList();
            foreach (var item4 in NotlarList)
            {
                db.NotlarTablosu.Remove(item4);
            }

            db.DersTablosu.Remove(DersN);
            db.SaveChanges();
            return RedirectToAction("Ders_GS", "ProgramSorumlusu");
        }

        public ActionResult Ders_Guncelle(int? DersID)
        {
            dersler DersNesnesi = null;
            if (DersID != null)
            {
                DersNesnesi = db.DersTablosu.Where(x => x.ID_ders == DersID).FirstOrDefault();
            }
            return View(DersNesnesi);
        }

        [HttpPost]
        public ActionResult Ders_Guncelle(int? DersID, dersler model)
        {
            int sonuc = 0;
            dersler DersNesnesi = db.DersTablosu.Where(x => x.ID_ders == DersID).FirstOrDefault(); ;
            if (DersNesnesi != null)
            {
                DersNesnesi.dersadi = model.dersadi;
                DersNesnesi.kredi = model.kredi;
                DersNesnesi.ders_donemi = model.ders_donemi;
                DersNesnesi.akts = model.akts;
                DersNesnesi.ogrencino = model.ogrencino;
                DersNesnesi.ogretmen_ID = model.ogretmen_ID;

                sonuc = db.SaveChanges();
            }
            if (sonuc > 0)
            {
                return RedirectToAction("Admin_anasayfa", "ProgramSorumlusu");
            }
            else
            {
                return View();

            }
        }

        public ActionResult YoksisEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YoksisEkle(yoksis YoksisEkle)
        {
            db.YoksisTablosu.Add(YoksisEkle);
            int sonuc = db.SaveChanges();

            if (sonuc > 0)
            {
                return RedirectToAction("Admin_anasayfa", "ProgramSorumlusu");
            }
            else
            {
                return View();
            }
        }

    }
}
