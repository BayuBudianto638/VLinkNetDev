using MCF_AppService.Helpers;
using MCF_AppService.Services.BpkbFirstDbAppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppService.Services.BpkbSecondDbAppService
{
    public interface ISecondDbAppService
    {
        void Create(TrBpkbModel model);
        void Update(TrBpkbModel model);
        void Delete(string AgreementNumber);
        PagedResult<TrBpkbModel> GetAll(PageInfo pageInfo);
        TrBpkbModel GetById(string AgreementNumber);
    }
}
