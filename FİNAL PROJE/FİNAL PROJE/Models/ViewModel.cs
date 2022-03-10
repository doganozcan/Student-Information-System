using FİNAL_PROJE.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models
{
    public class ViewModel
    {
        public List<dersler> DersListesi { get; set; }
        public List<notlar> NotlarListesi { get; set; }
        public List<ogrenci> OgrenciListesi { get; set; }
        public List<ogretmen> OgretmenListesi { get; set; }
        public List<duyuru> DuyuruListesi { get; set; }
        public List<yoksis> YoksisListesi { get; set; }
        public List<belgetalep> BelgeListesi { get; set; }
        public List<alders> AlinandersListesi { get; set; }
        public List<devamsizlik> DevamsizlikListesi { get; set; }
        public List<Admin> AdminListesi { get; set; }
    }
}