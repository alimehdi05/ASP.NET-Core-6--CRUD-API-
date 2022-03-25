using Microsoft.AspNetCore.Mvc;
using MVC1.Data;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DBContext _db;

        public CategoryController(DBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;// select all the data from the table no sql statements are required
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET(UPDATE)
        public IActionResult Edit(int? id)
        {
            var categoryId = _db.Categories.Find(id);
            //var categoryIdFirst = _db.Categories.FirstOrDefault(u=>u.Equals Id==id);
            //var categoryIdSingle = _db.Categories.SingleOrDefault(u=>u.Equals Id==id);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            if (categoryId == null)
            {
                return NotFound();
            }
            return View(categoryId);
        }

        //Update
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit (Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot match the Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET(Delete)

        public IActionResult Delete(int? id)
        {
            var categoryId = _db.Categories.Find(id);
            //var categoryIdFirst = _db.Categories.FirstOrDefault(u=>u.Equals Id==id);
            //var categoryIdSingle = _db.Categories.SingleOrDefault(u=>u.Equals Id==id);

            if (id == null || id == 0)
            {
                return NotFound();
            }

            if (categoryId == null)
            {
                return NotFound();
            }
            return View(categoryId);
        }

        //Delete
        [HttpPost,ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Categories.Find(id);

            if( obj == null)
            {
                return NotFound();
            }
           
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
           
           
        }
    }
}
