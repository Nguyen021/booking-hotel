using Microsoft.AspNetCore.Mvc;
using Novotel.Domain.Entities;
using Novotel.Infrastructure.Data;

namespace Novotel.Controllers
{
    public class HouseController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HouseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var houses = _context.Houses.ToList();
            return View(houses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(House house) 
        {   
            if(house.Name == house.Description)
            {
                ModelState.AddModelError("", "The description cannot exactly match the Name! ");
                //ModelState.AddModelError("name", "The description cannot exactly match the Name! ");
                //it will show span input name
            }
            if(ModelState.IsValid)
            {
                _context.Houses.Add(house);
                _context.SaveChanges();
                return RedirectToAction("Index", "House");
            }
            return View();
        }
    }
}
