using Microsoft.AspNetCore.Mvc;
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
    }
}
