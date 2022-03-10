using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("alders")]
    public class alders
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_alinandersler { get; set; }

        [StringLength(50)]
        public string alinan_dersadi { get; set; }

        [StringLength(10)]
        public string alinan_kredi { get; set; }

        [StringLength(10)]
        public string alinan_ders_donemi { get; set; }

        [StringLength(10)]
        public string alinan_akts { get; set; }


        [StringLength(50)]
        public string ogrt_elemani { get; set; }

        public int ogrencino { get; set; }


        public int ID_ders { get; set; }

        public int ogretmen_ID { get; set; }

        public virtual ogretmen ogretmen { get; set; }
        public virtual ogrenci ogrenci { get; set; }
        public virtual dersler dersler { get; set; }
       
    }
}