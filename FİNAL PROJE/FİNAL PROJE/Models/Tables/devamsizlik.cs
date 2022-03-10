using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FİNAL_PROJE.Models.Tables
{
    [Table("devamsizlik")]
    public class devamsizlik
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int devamsizlik_ID { get; set; }


        public int ogretmen_ID { get; set; }

        [StringLength(10)]
        public string teorik { get; set; }

        [StringLength(10)]
        public string uygulama { get; set; }

        public int ogrencino { get; set; }

        public virtual ogretmen ogretmen { get; set; }
    }

}