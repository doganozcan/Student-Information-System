using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("notlar")]
    public class notlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_not { get; set; }

        public int ogrencino { get; set; }

        public int ID_ders  { get; set; }

        [StringLength(5)]
        public string vize { get; set; }

        [StringLength(5)]
        public string final { get; set; }

        public virtual dersler dersler { get; set; }
    }
}