using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using olottech_ci_cd.web.Models;

namespace olottech_ci_cd.web.Controllers
{
    [Route("")]
    [Route("home")]
    public class HomeController : Controller
    {
        #region Fields

        private readonly ILogger<HomeController> _logger;
        private readonly IAgeService _ageService;

        #endregion

        #region Constructor

        public HomeController(
            IAgeService ageService,
            ILogger<HomeController> logger)
        {
            _ageService = ageService;
            _logger = logger;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Route("")]
        [Route("index", Order = 1)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{age}/isadult")]
        public JsonResult IsAdult(int age)
        {
            return Json(_ageService.IsAdult(age));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
