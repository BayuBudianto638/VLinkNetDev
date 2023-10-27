using MCF_FrontEnd.Models.Account;
using MCF_FrontEnd.Services.Login;
using Microsoft.AspNetCore.Mvc;

namespace MCF_FrontEnd.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _context;
        private readonly ILoginAppService _loginAppService;

        public AccountController(IHttpContextAccessor context, ILoginAppService loginAppService)
        {
            _context = context;
            _loginAppService = loginAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login(LoginViewModel model)
        {
            //var model = new LoginViewModel();
            if (model.User != null)
            {
                bool IsExist = await _loginAppService.Login(model);
                if (!IsExist)
                {
                    return RedirectToAction("AccessDenied", "Account");
                }
                else
                {
                    _context.HttpContext.Session.SetString("UserProfile", model.User);
                    _context.HttpContext.Session.SetString("UserType", model.Password);

                    return RedirectToAction("Index", "Bpkb");
                }
            }
            else
            {
                model = new LoginViewModel();
            }

            return View(model);
        }
    }
}
