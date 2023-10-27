using MCF_AppService.Helpers;
using MCF_AppService.Models;
using MCF_AppService.Services.LocationAppService;
using MCF_AppService.Services.LocationAppService.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCF_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationAppService _locationAppService;

        public LocationController(ILocationAppService locationAppService)
        {
            _locationAppService = locationAppService;
        }

        [HttpGet("GetAllLocation")]
        [Produces("application/json")]
        public IActionResult GetAlllocation([FromBody] PageInfo pageInfo, string userType)
        {
            try
            {
                var locationList = _locationAppService.GetAll(pageInfo, userType);

                return Requests.Response(this, new ApiStatus(200), locationList, "");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPost("SaveLocation")]
        public IActionResult Savelocation([FromBody] LocationModel model, string userType)
        {
            try
            {
                _locationAppService.Create(model, userType);

                return Requests.Response(this, new ApiStatus(200), "Success", "Success");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPost("UpdateLocation")]
        public IActionResult Updatelocation([FromBody] LocationModel model, string userType)
        {
            try
            {
                _locationAppService.Update(model, userType);

                return Requests.Response(this, new ApiStatus(200), "Success", "Success");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }

        [HttpPost("DeleteLocation")]
        public IActionResult Deletelocation(int id, string userType)
        {
            try
            {
                _locationAppService.Delete(id, userType);

                return Requests.Response(this, new ApiStatus(200), "Success", "Success");
            }
            catch (Exception ex)
            {
                return Requests.Response(this, new ApiStatus(500), null, ex.Message);
            }
        }
    }
}
