using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Novotel.Domain.Entities;
using Novotel.Infrastructure.Data;
using Novotel.ViewModels;

namespace Novotel.Controllers
{
    public class HouseNumberController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HouseNumberController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var houseNumbers = _context.HousesNumbers.Include(u=>u.House).ToList();
            return View(houseNumbers);
        }
        public IActionResult Create()
        {
            //var houses = _context.Houses.ToList();

            //ViewData["Houses"] = houses;

            IEnumerable<SelectListItem> list = _context.Houses.ToList().Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            });

            ViewData["HouseList"] = list;
            return View();


        }
        [HttpPost]
        public IActionResult Create(HouseNumber houseNumber) 
        {
            //ModelState.Remove("House");
            if(ModelState.IsValid)
            {
                _context.HousesNumbers.Add(houseNumber);
                _context.SaveChanges();
                TempData["success"] = "The house number has been created successfully.";
                return RedirectToAction("Index", "HouseNumber");
            }

            //TempData["error"] = "Something error try again!";
            //var houses = _context.Houses.ToList();
            //ViewData["Houses"] = houses;

            return View();
        }

        
    }
}
