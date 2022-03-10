using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("duyuru")]
    public class duyuru
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int duyuru_ID { get; set; }

        [StringLength(300)]
        public string duyuruicerik { get; set; }

        [StringLength(15)]
        public string tarih { get; set; }

        public int ogretmen_ID { get; set; }

        [StringLength(30)]
        public string baslik { get; set; }

        public int ID_alinandersler { get; set; }

        public int ID_ders { get; set; }

        public virtual alders alders { get; set; }
        public virtual ogretmen ogretmen { get; set; }
        public virtual dersler dersler { get; set; }
    }
}