using APARTEMENT_VISIT_MANAGEMENT_SYS.Data;
using APARTEMENT_VISIT_MANAGEMENT_SYS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace APARTEMENT_VISIT_MANAGEMENT_SYS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        AptData _apartmentData = new AptData();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListApt()
        {
            List<ApartmentModel> oApt = _apartmentData.ListApartments();
            if (ModelState.IsValid)
            {
                return View(oApt);
            }
            else
            {
                return View();
            }
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