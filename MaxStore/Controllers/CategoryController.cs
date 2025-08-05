using MaxStore.DataAccess.Data;
using MaxStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace MaxStore.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ApplicationDbContext _db;
        public CategoryController( ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(Category obj )
        //{
        //    _db.Categories.Add(obj);
        //    _db.SaveChanges();         
        //    Notify("Category",ActionType.Created, NotificationType.Success);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            
            if (_db.Categories.Any(c => c.Name.ToLower() == obj.Name.ToLower()))
            {
                ModelState.AddModelError("Name", "A category with this name already exists.");
                Notify("A category with this name already exists.", NotificationType.Error);
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                Notify("Category", ActionType.Created, NotificationType.Success);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null) {
                return NotFound();
            }
            Category? objCategory = _db.Categories.FirstOrDefault(c => c.Id == Id);
            if (objCategory == null)
            {
                return NotFound();
            }
            return View(objCategory);
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {      
            if (_db.Categories.Any(c => c.Name.ToLower() == obj.Name.ToLower() && c.Id != obj.Id))
            {
                ModelState.AddModelError("Name", "A category with this name already exists.");
                Notify("A category with this name already exists.", NotificationType.Error);
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                Notify("Category", ActionType.Updated, NotificationType.Success);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

            [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id ==0)
            {
                return NotFound();
            }
            Category? objCategory = _db.Categories.FirstOrDefault(c => c.Id == Id);
            if (objCategory == null)
            {
                return NotFound();
            }
            return View(objCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {         
                Category? objCategory = _db.Categories.FirstOrDefault(c => c.Id == Id);

            if (objCategory == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(objCategory);
                _db.SaveChanges();
            Notify("Category", ActionType.Deleted, NotificationType.Success);
            return RedirectToAction("Index");        
        }
    }
}
