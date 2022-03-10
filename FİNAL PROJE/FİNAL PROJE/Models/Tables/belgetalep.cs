using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    public class belgetalep
    {
        [StringLength(100)]
        public string talepeden_kurum { get; set; }


        [StringLength(100)]
        public string talep_neden { get; set; }

        [StringLength(50)]
        public string belge_türü { get; set; }

        [StringLength(50)]
        public string belge_tipi { get; set; }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int belgeid { get; set; }

        [StringLength(50)]
        public string tarih { get; set; }


    }
}