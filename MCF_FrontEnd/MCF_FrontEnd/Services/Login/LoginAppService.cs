using System.Text;
using System;
using Newtonsoft.Json;
using MCF_FrontEnd.Models.Account;
using System.Net.Http;

namespace MCF_FrontEnd.Services.Login
{
    public class LoginAppService : ILoginAppService
    {
        private readonly IHttpContextAccessor _context;

        public LoginAppService(IHttpContextAccessor context)
        {
            _context = context;
        }
        public async Task<bool> Login(LoginViewModel model)
        {
            bool isTrue = false;

            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await client.GetAsync($"https://localhost:7057/api/Login/Login?userName={model.User}&password={model.Password}");

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var login = JsonConvert.DeserializeObject<LoginModel>(result);

                _context.HttpContext.Session.SetString("User", login.UserName);
                _context.HttpContext.Session.SetString("UserType", login.UserType);

                isTrue = true;
            }
            else
            {
                isTrue = false;
            }

            return isTrue;
        }
    }
}
