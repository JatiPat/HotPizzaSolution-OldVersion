using HotPizza.Data;
using HotPizza.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotPizza.Controllers
{
    public class StyleController : Controller
    {
        private readonly PizzaContext _context;

        public StyleController(PizzaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           List<Style> styleList = _context.Styles.ToList();
            return View(styleList);
        }

        public IActionResult Create() //scaffold Create Page
        {
            return View();
        }
    }
}
