using Microsoft.AspNetCore.Mvc;
using Umoozi.Domain.Entities;
using Umoozi.Structure.DbData;

namespace Umoozi.Web.Controllers
{
    public class HouseController : Controller
    {
        //using with dot.net
        //ApplicationDbContext context = new ApplicationDbContext()
        //{

        //}

        //using with dot net core
        // implementation connection DB context in Program cs by DI
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
                ModelState.AddModelError("description", "The Description cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Houses.Add(house);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Processing failed: {ex.Message}");
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
