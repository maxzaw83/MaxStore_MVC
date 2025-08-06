using MaxStore.DataAccess.Data;
using MaxStore.DataAccess.Repository.IRepository;
using MaxStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace MaxStore.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork UnitOfWork;
        public CategoryController(IUnitOfWork _UnitOfWork)
        {
            UnitOfWork = _UnitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = UnitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
                        
            if (ModelState.IsValid)
            {
                UnitOfWork.Category.Add(obj);
                UnitOfWork.Save();
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
            Category? objCategory = UnitOfWork.Category.Get(c => c.Id == Id);
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
            
            if (ModelState.IsValid)
            {
                UnitOfWork.Category.Update(obj);
                UnitOfWork.Save();
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
            Category? objCategory = UnitOfWork.Category.Get(c => c.Id == Id);
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
                Category? objCategory = UnitOfWork.Category.Get(c => c.Id == Id);

            if (objCategory == null)
            {
                return NotFound();
            }
            UnitOfWork.Category.Remove(objCategory);
            UnitOfWork.Save();
            Notify("Category", ActionType.Deleted, NotificationType.Success);
            return RedirectToAction("Index");        
        }
    }
}
