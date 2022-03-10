using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("ogrenci")]
    public class ogrenci
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ogrencino { get; set; }

        [StringLength(40)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(50)]
        public  string anne_adi { get; set; }

        [StringLength(50)]
        public string baba_adi { get; set; }

        [StringLength(50)]
        public string dogumtarihi { get; set; }

        [StringLength(50)]
        public string cinsiyet { get; set; }

        [StringLength(50)]
        public string uyruk{ get; set; }

        [StringLength(50)]
        public string tc { get; set; }

        [StringLength(100)]
        public string aile_adres{ get; set; }

        [StringLength(10)]
        public string aile_postakodu { get; set; }

        [StringLength(50)]
        public string aile_il { get; set; }

        [StringLength(50)]
        public string aile_ilce { get; set; }

        [StringLength(100)]
        public string ikamet_adres { get; set; }

        [StringLength(10)]
        public string ikamet_postakodu { get; set; }

        [StringLength(50)]
        public string ikamet_il { get; set; }

        [StringLength(50)]
        public string ikamet_ilce{ get; set; }

        [StringLength(10)]
        public string cep1 { get; set; }

        [StringLength(10)]
        public string cep2 { get; set; }

        [StringLength(10)]
        public string cep3 { get; set; }

        [StringLength(100)]
        public string eposta1 { get; set; }

        [StringLength(100)]
        public string eposta2 { get; set; }

        [StringLength(100)]
        public string banka_adi { get; set; }

        [StringLength(20)]
        public string sube_kodu { get; set; }

        [StringLength(100)]
        public string sube_adi{ get; set; }

        [StringLength(100)]
        public string hesap_numarasi{ get; set; }

        [StringLength(100)]
        public string iban { get; set; }

        [StringLength(100)]
        public string hesap_adi_soyadi { get; set; }

        [StringLength(20)]
        public string sifre { get; set; }

        [StringLength(20)]
        public string kullaniciAdi { get; set; }

        public virtual List<alders> alders { get; set; }
        public virtual List<dersler> dersler { get; set; }
        public virtual List<yoksis> yoksis { get; set; }
    }
}