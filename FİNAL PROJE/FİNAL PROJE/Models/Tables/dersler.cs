using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("dersler")]
    public class dersler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_ders { get; set; }

        [StringLength(100)]
        public string dersadi { get; set; }
      
        public int kredi { get; set; }
      
        [StringLength(100)]
        public string ders_donemi { get; set; }

        public int akts { get; set; }

        public int ogrencino { get; set; }

        [StringLength(100)]
        public string ogretmen_ID { get; set; }

        public virtual ogrenci ogrenci { get; set; }
        public virtual List<ogretmen> ogretmen { get; set; }
        public virtual List<notlar> notlar { get; set; }
        public virtual  List<alders> alders { get; set; }
        public virtual List<duyuru> duyuru { get; set; }


    }
}