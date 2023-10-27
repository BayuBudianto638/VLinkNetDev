using MCF_AppService.Services.LoginAppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCF_AppService.Services.LoginAppService
{
    public interface ILoginAppService
    {
        LoginModel Login(string username, string password);
        void Create(LoginModel model);
        void Logout();
    }
}
