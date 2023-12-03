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

            //IEnumerable<SelectListItem> list = _context.Houses.ToList().Select(h => new SelectListItem
            //{
            //    Text = h.Name,
            //    Value = h.Id.ToString()
            //});

            //ViewBag.List = list;


            HouseNumberVM houseNumberVM = new HouseNumberVM  {
                HouseList = _context.Houses.ToList().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                })
            };
            return View(houseNumberVM);


        }
        [HttpPost]
        public IActionResult Create(HouseNumberVM obj) 
        {
            //ModelState.Remove("House");

            bool checkExists = _context.HousesNumbers.Any(h=>h.House_Number.Equals(obj.HouseNumber.House_Number));
            
           
            if (ModelState.IsValid && !checkExists)
            {
                try
                {
                    _context.HousesNumbers.Add(obj.HouseNumber);
                    _context.SaveChanges();
                    TempData["success"] = "The house number has been created successfully.";
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex) {
                    TempData["error"] = "error somthing";
                    return View();
                }
            }
            if (checkExists)
            {
                TempData["error"] = "The house number already exists!";
                
            }
            obj.HouseList = _context.Houses.ToList().Select(h => new SelectListItem
            {
                Text = h.Name,
                Value = h.Id.ToString()
            });
            return View(obj);
        }

        public IActionResult Update(int houseNumberId) 
        {
            
            HouseNumberVM houseNumberVM = new()
            {
                HouseList = _context.Houses.ToList().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                }),
                HouseNumber = _context.HousesNumbers.FirstOrDefault(x => x.House_Number.Equals(houseNumberId))


            };
            if (houseNumberVM.HouseList == null || houseNumberVM.HouseNumber ==null) {
                return RedirectToAction("Error", "Home");
            }
            return View(houseNumberVM);
        }
        [HttpPost]
        public IActionResult Update(HouseNumberVM obj)
        {
          
            if (ModelState.IsValid )
            {
               
                    _context.HousesNumbers.Update(obj.HouseNumber);
                    _context.SaveChanges();
                    TempData["success"] = "The house number has been updated successfully.";
                    return RedirectToAction(nameof(Index));
              
            }

            obj.HouseList = _context.Houses.ToList().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
            });
            
            return View(obj);

        }

        public IActionResult Delete(int houseNumberId)
        {

            HouseNumberVM houseNumberVM = new()
            {
                HouseList = _context.Houses.ToList().Select(h => new SelectListItem
                {
                    Text = h.Name,
                    Value = h.Id.ToString()
                }),
                HouseNumber = _context.HousesNumbers.FirstOrDefault(x => x.House_Number.Equals(houseNumberId))
            };
            if (houseNumberVM.HouseList == null || houseNumberVM.HouseNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(houseNumberVM);
        }
        [HttpPost]
        public IActionResult Delete(HouseNumberVM houseNumberVM)
        {
            HouseNumber objFromDb = _context.HousesNumbers.FirstOrDefault(u => u.House_Number.Equals(houseNumberVM.HouseNumber));
           
            if(objFromDb is not null) { 
                _context.HousesNumbers.Remove(houseNumberVM.HouseNumber);
                _context.SaveChanges();
                TempData["success"] = "The house number has been removed successfully.";
                return RedirectToAction(nameof(Index));
            };

            TempData["error"] = "The house number could not removed successfully.";

            return View();
        }
    }
}
