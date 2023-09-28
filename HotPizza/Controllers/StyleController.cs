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

        [HttpPost] //Http post for create method
        public IActionResult Create(Style newStyle)
        {
            if(ModelState.IsValid) {
                _context.Styles.Add(newStyle); //add new style and save it. Then redirect to index
                _context.SaveChanges();
                return RedirectToAction("Index", "Style");
            }
            else //invaild inputs
            {
                return View();
            }
        }

    }
}
