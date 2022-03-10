using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("ogretmen")]
    public class ogretmen
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ogretmen_ID { get; set; }

        [StringLength(40)]
        public string ad { get; set; }

        [StringLength(50)]
        public string soyad { get; set; }

        [StringLength(40)]
        public string verdigidersadi { get; set; }

        public int ID_ders { get; set; }

        [StringLength(11)]
        public string telefon { get; set; }

        [StringLength(100)]
        public string eposta { get; set; }

        
        public int duyuru_ID { get; set; }

        [StringLength(10)]
        public string Akullanici_adi { get; set; }

        [StringLength(10)]
        public string Asifre { get; set; }


        public virtual List<alders> alders { get; set; }
        public virtual dersler dersler { get; set; }
        public virtual List<duyuru> duyuru { get; set; }
        public virtual List<devamsizlik> devamsizlik { get; set; }
    }
}