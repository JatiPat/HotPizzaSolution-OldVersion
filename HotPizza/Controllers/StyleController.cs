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
            var dupCheck = _context.Styles.Find(newStyle.DisplayOrder);
            if (dupCheck is not null) //stops users from adding same display order numbers
            { //this counts as server-side validation
                ModelState.AddModelError("displayOrder", "No duplicates for display order");
            }

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

        public IActionResult Edit(int? id) //Can take in id of Style that's nullable
        {
            if(id is null || id == 0) //is null is better ==, and can also say //is not
            {
                return NotFound();
            }

            Style? styleFromDb = _context.Styles.Find(id); //find can only look for the primary key
            //Style? styleFromDb1 = _context.Styles.FirstOrDefault(u => u.Id == id); //firstordeafault using LINQ and can search for other varaibles 
            //Style? styleFromDb2 = _context.Styles.Where(u => u.Id == id).FirstOrDefault(); //Where is used for calculation 
            if (styleFromDb == null)
            {
                return NotFound();
            }
            return View(styleFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Style editStyle)
        {
            if (editStyle != null && ModelState.IsValid) 
            {
                _context.Styles.Update(editStyle); //only thing needed here is to update the object and save changes
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Style");
        }


        public IActionResult Delete(int? id) //Can take in id of Style that's nullable
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Style? styleFromDb = _context.Styles.Find(id); //find can only look for the primary key
            //Style? styleFromDb1 = _context.Styles.FirstOrDefault(u => u.Id == id); //firstordeafault using LINQ and can search for other varaibles 
            //Style? styleFromDb2 = _context.Styles.Where(u => u.Id == id).FirstOrDefault(); //Where is used for calculation 
            if (styleFromDb == null)
            {
                return NotFound();
            }
            return View(styleFromDb);
        }


        [HttpPost, ActionName("Delete")] //telling EF Core this is the delete method even if it's called DeletePOST
        public IActionResult DeletePOST(int? id)
        {
            Style? style = _context.Styles.Find(id);
            if (style == null)
            {
                return BadRequest();
            }
            _context.Styles.Remove(style); //removing object
            _context.SaveChanges();
            return RedirectToAction("Index", "Style");
        }
    }


}

