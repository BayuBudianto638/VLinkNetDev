using AutoMapper;
using MCF_FrontEnd.Models.Bpkb;
using MCF_FrontEnd.Services.Bpkb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MCF_FrontEnd.Controllers
{
    public class BpkbController : Controller
    {
        private readonly IHttpContextAccessor _context;
        private readonly IBpkbAppService _bpkbAppService;
        private readonly IMapper _mapper;
        public BpkbController(IHttpContextAccessor context, IBpkbAppService bpkbAppService)
        {
            _context = context;
            _bpkbAppService = bpkbAppService;
        }

        public IActionResult Index()
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var userType = _context.HttpContext.Session.GetString("UserType");

            if (userType == null)
                return RedirectToAction("AccessDenied", "Account");

            var model = _bpkbAppService.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var userType = _context.HttpContext.Session.GetString("UserType");

            if (userType == null)
                return RedirectToAction("AccessDenied", "Account");

            var model = new BpkbModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BpkbModel model)
        {
            try
            {
                var userType = _context.HttpContext.Session.GetString("UserType");

                var newBpkb = _mapper.Map<BpkbModel>(model);
                _bpkbAppService.Create(newBpkb, userType);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var user = _context.HttpContext.Session.GetString("UserProfile");
            var userType = _context.HttpContext.Session.GetString("UserType");

            if (userType == null)
                return RedirectToAction("AccessDenied", "Account");
                       
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BpkbModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userType = _context.HttpContext.Session.GetString("UserType");

                    var editModel = _mapper.Map<BpkbModel>(model);
                    _bpkbAppService.Update(editModel, userType);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
