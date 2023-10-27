using MCF_FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MCF_FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _context;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var pass = _context.HttpContext.Session.GetString("UserType");

            _context.HttpContext.Session.SetString("UserProfile", "");
            _context.HttpContext.Session.SetString("UserType", "");

            if ((user != null) && (user != ""))
            {
                _context.HttpContext.Session.SetString("UserProfile", user);
                _context.HttpContext.Session.SetString("UserType", pass);
            }
            else
            {
                _context.HttpContext.Session.SetString("UserProfile", "");
                _context.HttpContext.Session.SetString("UserType", "");

                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}