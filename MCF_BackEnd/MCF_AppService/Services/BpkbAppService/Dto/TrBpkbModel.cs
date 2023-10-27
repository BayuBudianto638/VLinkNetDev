using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppService.Services.BpkbAppService.Dto
{
    public class TrBpkbModel
    {
        public string AgreementNumber { get; set; }
        public string Bpkb_No { get; set; }
        public DateTime Bpkb_Date { get; set; }
        public string Faktur_No { get; set; }
        public DateTime Faktur_Date { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Police_No { get; set; }
        public DateTime Bpkb_Date_In { get; set; }
    }
}
