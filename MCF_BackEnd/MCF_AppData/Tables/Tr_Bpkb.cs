using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppData.Tables
{
    [Table("TR_BPKB")]
    public class Tr_Bpkb
    {
        [Key]
        [StringLength(100)]
        public string AgreementNumber { get; set; }

        [StringLength(100)]
        public string Bpkb_No { get; set; }

        public DateTime Bpkb_Date { get; set; }

        [StringLength(100)]
        public string Faktur_No { get;set; }

        public DateTime Faktur_Date { get; set; }

        public int LocationId { get; set; }

        [StringLength(20)]
        public string Police_No { get; set; }

        public DateTime Bpkb_Date_In { get;set; }

        public virtual Location Location { get; set; }
    }
}
