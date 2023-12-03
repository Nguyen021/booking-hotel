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
                TempData["success"] = "The house has been created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update(int houseId)
        {       
            House? house = _context.Houses.FirstOrDefault(u => u.Id.Equals(houseId));

            House? houseList = _context.Houses.Where(u=> u.Price > 50 && u.Occupancy >0).FirstOrDefault();
            if(house == null)
            {
                return RedirectToAction("Error","Home");
            }
            return View(house);
        }

        [HttpPost]
        public IActionResult Update(House house)
        {
            if (ModelState.IsValid)
            {
                _context.Houses.Update(house);
                _context.SaveChanges();
                TempData["success"] = "The house has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int houseId)
        {
            House? house = _context.Houses.FirstOrDefault(u => u.Id.Equals(houseId));

            if (house is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(house);
        }

        [HttpPost]
        public IActionResult Delete(House house)
        {
            House? houseFromDb = _context.Houses.FirstOrDefault(u => u.Id.Equals(house.Id));
            if (houseFromDb is not null)
            {
                _context.Houses.Remove(houseFromDb);
                _context.SaveChanges();
                TempData["success"] = "The house has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The house could not been be deleted.";
            return View();
        }
    }
}
