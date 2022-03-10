using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("Admin")]
    public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_admin { get; set; }

        [StringLength(100)]
        public string admin_ad { get; set; }

        [StringLength(100)]
        public string admin_soyad { get; set; }

        [StringLength(100)]
        public string admin_Kullanici_adi { get; set; }

        [StringLength(100)]
        public string admin_sifre { get; set; }

        [StringLength(100)]
        public string telefon { get; set; }

        [StringLength(100)]
        public string eposta { get; set; }



    }
}