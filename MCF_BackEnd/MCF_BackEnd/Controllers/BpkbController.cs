using MCF_AppData.Database;
using MCF_AppService.Helpers;
using MCF_AppService.Models;
using MCF_AppService.Services;
using MCF_AppService.Services.BpkbAppService;
using MCF_AppService.Services.BpkbAppService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MCF_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpkbController : ControllerBase
    {
        private readonly IBpkbAppService _bpkbAppService;

        public BpkbController(IBpkbAppService bpkbAppService)
        {
            _bpkbAppService = bpkbAppService;
        }

        [HttpGet("GetAllBpkb")]
        [Produces("application/json")]
        public IActionResult GetAllBpkb([FromQuery] PageInfo pageInfo, string userType)
        {
            try
            {
                var bpkbList = _bpkbAppService.GetAll(pageInfo, userType);

                return Requests.Response(this, new ApiStatus(200), bpkbList, "");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPost("SaveBpkb")]
        public IActionResult SaveBpkb([FromBody] TrBpkbModel model, string userType)
        {
            try
            {
                _bpkbAppService.Create(model, userType);

                return Requests.Response(this, new ApiStatus(200), "Success", "Success");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPost("UpdateBpkb")]
        public IActionResult UpdateBpkb([FromBody] TrBpkbModel model, string userType)
        {
            try
            {
                _bpkbAppService.Update(model, userType);

                return Requests.Response(this, new ApiStatus(200), "Success", "Success");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPost("DeleteBpkb")]
        public IActionResult DeleteBpkb(string agreementNo, string userType)
        {
            try
            {
                _bpkbAppService.Delete(agreementNo, userType);

                return Requests.Response(this, new ApiStatus(200), "Success", "Success");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }
    }
}
