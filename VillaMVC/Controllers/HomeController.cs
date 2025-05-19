using Microsoft.AspNetCore.Mvc;
using VillaMVC.Models;
using VillaMVC.Services;

namespace VillaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly VillaService _villaService;

        public HomeController(VillaService villaService)
        {
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            List<Villa> villa = _villaService.GetAllVilla();

            return View(villa);
        }
    }
}
