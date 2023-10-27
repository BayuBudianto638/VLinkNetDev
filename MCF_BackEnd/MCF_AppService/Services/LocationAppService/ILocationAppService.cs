using MCF_AppService.Helpers;
using MCF_AppService.Services.BpkbAppService.Dto;
using MCF_AppService.Services.LocationAppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppService.Services.LocationAppService
{
    public interface ILocationAppService
    {
        void Create(LocationModel model, string userType);
        void Update(LocationModel model, string userType);
        void Delete(int id, string userType);
        PagedResult<LocationModel> GetAll(PageInfo pageInfo, string userType);
        LocationModel GetById(int id, string userType);
    }
}
