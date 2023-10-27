using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MCF_AppData.Database;
using System.Security.Cryptography;
using MCF_AppService.Services.LoginAppService.Dto;
using MCF_AppService.Services.LoginAppService;

namespace MCF_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        [HttpGet("Login")]
        public ActionResult Login(string userName, string password)
        {
            var md5 = MD5.Create();
            var passwordHash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            var passwordHashConvert = BitConverter.ToString(passwordHash).Replace("-", "").ToLower();

            var user = _loginAppService.Login(userName, passwordHashConvert);

            if (!user.Password.Equals(passwordHashConvert))
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("SaveUser")]
        public void SaveUser([FromBody] LoginModel model)
        {
            var md5 = MD5.Create();
            var passwordHash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(model.Password));
            var passwordHashConvert = BitConverter.ToString(passwordHash).Replace("-", "").ToLower();

            model.Password = passwordHashConvert; 

            _loginAppService.Create(model);
        }
    }
}
