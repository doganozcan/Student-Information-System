using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("yoksis")]
    public class yoksis
    { 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int yoksis_ID { get; set; }

        [StringLength(40)]
        public string fakulte { get; set; }

        [StringLength(50)]
        public string bolum { get; set; }

        [StringLength(50)]
        public string ogrenim_turu { get; set; }

        [StringLength(50)]
        public string birim_turu { get; set; }

        [StringLength(50)]
        public string ogrsuresi { get; set; }

        [StringLength(50)]
        public string ogrdili { get; set; }

        [StringLength(5)]
        public string sinif { get; set; }

        [StringLength(50)]
        public string ogr_statusu { get; set; }

        [StringLength(50)]
        public string hazirlikdurumu { get; set; }

        [StringLength(10)]
        public string kayittarihi { get; set; }

        [StringLength(50)]
        public string ogr_hakki { get; set; }

        [StringLength(20)]
        public string giris_puanturu { get; set; }

        [StringLength(20)]
        public string giristuru { get; set; }

        [StringLength(10)]
        public string giris_puan { get; set; }

        [StringLength(5)]
        public string notsistemi { get; set; }

        [StringLength(5)]
        public string not_ort { get; set; }

        [StringLength(5)]
        public string aktif_donem { get; set; }


        public int ogrencino { get; set; }



        public virtual ogrenci ogrenci { get; set; }
    }
}