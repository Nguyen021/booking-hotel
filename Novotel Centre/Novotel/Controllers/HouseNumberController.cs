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

            //// Truyền danh sách nhà vào ViewData
            //ViewData["Houses"] = houses;

            //IEnumerable<SelectListItem> list = _context.Houses.ToList().Select(
            //    u => new SelectListItem{
            //    Text=u.Name,
            //    Value = u.Id.ToString()
            //});
            //ViewBag.HouseList = list;

            //return View();


            HouseNumberVM houseNumberVM = new()
            {
                HouseList = _context.Houses.ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                })
            };
                
            return View(houseNumberVM);



        }
        [HttpPost]
        public IActionResult Create(HouseNumber houseNumber) 
        {   
            
            if(ModelState.IsValid)
            {
                _context.HousesNumbers.Add(houseNumber);
                _context.SaveChanges();
                TempData["success"] = "The house number has been created successfully.";
                return RedirectToAction("Index", "HouseNumber");
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
                return RedirectToAction("Index", "House");
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
                return RedirectToAction("Index");
            }
            TempData["error"] = "The house could not been be deleted.";
            return View();
        }
    }
}
