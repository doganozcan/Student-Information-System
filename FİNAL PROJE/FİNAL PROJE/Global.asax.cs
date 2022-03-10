using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FİNAL_PROJE.Models;
using FİNAL_PROJE.Models.Tables;

namespace FİNAL_PROJE
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (DataContext db = new DataContext())
            {
                db.Database.CreateIfNotExists();

                Admin a = new Admin();
                a.admin_ad = "Doğan ";
                a.admin_soyad = "Özcan";
                a.eposta = "dogan@gmail.com";
                a.admin_Kullanici_adi = "admin";
                a.admin_sifre = "admin";
                db.AdminTablosu.Add(a);
                db.SaveChanges();


                ogrenci o = new ogrenci();
                o.ad = "Enes";
                o.soyad = "Yüksel";
                o.kullaniciAdi = "1";
                o.sifre = "1";
                db.OgrenciTablosu.Add(o);
                db.SaveChanges();

                ogretmen ogrt = new ogretmen();
                ogrt.ad = "seyrani";
                ogrt.Akullanici_adi = "seyrani";
                ogrt.Asifre = "1";
                ogrt.ID_ders = 1;
                db.OgretmenTablosu.Add(ogrt);
                db.SaveChanges();

                dersler d = new dersler();
                d.dersadi = "deneme";
                d.akts = 0;
                d.kredi = 0;
                d.ders_donemi = "1";
                d.ogretmen_ID = "1";
                d.ogrencino = 1;
                db.DersTablosu.Add(d);
                db.SaveChanges();
            }

            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
