using Microsoft.AspNetCore.Mvc;
using VillaMVC.Models;
using VillaMVC.Services;
using VillaMVC.ViewModels;

namespace VillaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VillaController : Controller
    {
        private readonly VillaService _villaService;

        public VillaController(VillaService villaService)
        {
            _villaService = villaService;
        }
        public IActionResult Index()
        {
            List<Villa> villa = _villaService.GetAllVilla();
            return View(villa);
        }


        [HttpGet]
        public IActionResult Info(int id)
        {
            Villa collections = _villaService.GetVillaById(id);
            return View(collections);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VillaVM villaVM) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _villaService.CreateVilla(villaVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id) 
        {
            Villa villa = _villaService.GetVillaById(id);

            var viewModel = new VillaVM
            {

                CategoryName = villa.CategoryName,
                Price = villa.Price,
                Place=villa.Place,
                Bedrooms=villa.Bedrooms,
                Bathrooms=villa.Bathrooms,
                Area=villa.Area,
                Floor=villa.Floor,
                Parking=villa.Parking

            };

            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Update(int id, VillaVM villaVM) 
        {
            _villaService.UpdateVilla(id, villaVM);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            _villaService.DeleteVilla(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
