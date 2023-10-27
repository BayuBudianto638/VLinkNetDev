using MCF_AppService.Helpers;
using MCF_AppService.Services.BpkbAppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppService.Services.BpkbAppService
{
    public interface IBpkbAppService
    {
        void Create(TrBpkbModel model, string userType);
        void Update(TrBpkbModel model, string userType);
        void Delete(string AgreementNumber, string userType);
        PagedResult<TrBpkbModel> GetAll(PageInfo pageInfo, string userType);
        TrBpkbModel GetById(string AgreementNumber, string userType);
    }
}
