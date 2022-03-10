using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FİNAL_PROJE.Models.Tables;

namespace FİNAL_PROJE.Models
{
    public class DataContext: DbContext
    {
        public DbSet<dersler> DersTablosu { get; set; }
        public DbSet<ogrenci> OgrenciTablosu { get; set; }
        public DbSet<ogretmen> OgretmenTablosu { get; set; }
        public DbSet<notlar> NotlarTablosu { get; set; }
        public DbSet<duyuru> DuyuruTablosu { get; set; }
        public DbSet<yoksis> YoksisTablosu { get; set; }
        public DbSet<belgetalep> BelgeTablosu { get; set; }
        public DbSet<alders> AlinandersTablosu { get; set; }
        public DbSet<devamsizlik> DevamsizlikTablosu { get; set; }
        public DbSet<Admin> AdminTablosu { get; set; }
    }
}