using MCF_FrontEnd.Models.Account;

namespace MCF_FrontEnd.Services.Login
{
    public interface ILoginAppService
    {
        Task<bool> Login(LoginViewModel model);   
    }
}
