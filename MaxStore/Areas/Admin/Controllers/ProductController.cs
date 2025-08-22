using MaxStore.Controllers;
using MaxStore.DataAccess.Repository;
using MaxStore.DataAccess.Repository.IRepository;
using MaxStore.Models;
using MaxStore.Models.ViewModels;
using MaxStore.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol;

namespace MaxStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles= SD.Role_Admin)]
    public class ProductController : BaseController
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IWebHostEnvironment WebHostEnvironment;
        public ProductController(IUnitOfWork _UnitOfWork, IWebHostEnvironment _WebHostEnvironment)
        {
            UnitOfWork = _UnitOfWork;
            WebHostEnvironment = _WebHostEnvironment;
        }
        public IActionResult Index()
        {

            List<Product> objProductList = UnitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return View(objProductList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.CategoryList = UnitOfWork.Category.GetAll().Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.Id.ToString()
            //});
            //ViewData["CategoryList"] = UnitOfWork.Category.GetAll().Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = u.Id.ToString()
            //});
          
            ProductVM productvm = new()
            {
                CategoryList = UnitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
                ),
                Product = new Product()
            };
            return View(productvm);
        }

        //Update And Insert Together
        public IActionResult Upsert(int? id)
        {

            ProductVM productVM = new()
            {
                CategoryList = UnitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                //create
                return View(productVM);
            }
            else
            {
                //update
                productVM.Product = UnitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = WebHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath,@"images\product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageURL))
                        {
                        var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                  using ( var fileStream = new FileStream(Path.Combine(productPath,fileName),FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageURL = @"\images\product\" + fileName;

                }
                if (productVM.Product.Id == 0)
                {
                    UnitOfWork.Product.Add(productVM.Product);
                    UnitOfWork.Save();
                    Notify("Product", ActionType.Created, NotificationType.Success);
                    return RedirectToAction("Index");
                }
                else
                {
                    UnitOfWork.Product.Update(productVM.Product);
                    UnitOfWork.Save();
                    Notify("Product", ActionType.Updated, NotificationType.Success);
                    return RedirectToAction("Index");
                }             
            }

            ProductVM productvm = new()
            {
                CategoryList = UnitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
                ),
                Product = new Product()
            };
            if (productVM.Product.Id == 0)
            {
                return View(productvm);
            }
            else
            {
                productvm.Product = UnitOfWork.Product.Get(u => u.Id == productVM.Product.Id);
                return View(productvm);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM obj)
        {
            
            if (ModelState.IsValid)
            {
                UnitOfWork.Product.Add(obj.Product);
                UnitOfWork.Save();
                Notify("Product", ActionType.Created, NotificationType.Success);
                return RedirectToAction("Index");
            }
            else
            {
                ProductVM productvm = new()
                {
                    CategoryList = UnitOfWork.Category.GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }
                              ),
                    Product = new Product()
                };
            }
                //ViewBag.CategoryList = UnitOfWork.Category.GetAll().Select(u => new SelectListItem
                //{
                //    Text = u.Name,
                //    Value = u.Id.ToString()

                return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
           
            if (Id == null)
            {
                return NotFound();
            }
            Product? objProduct = UnitOfWork.Product.Get(c => c.Id == Id);
            if (objProduct == null)
            {
                return NotFound();
            }
            // This creates the list of Categories for the dropdown
            ViewBag.CategoryList = UnitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(objProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                UnitOfWork.Product.Update(obj);
                UnitOfWork.Save();
                Notify("Product", ActionType.Updated, NotificationType.Success);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //[HttpGet]
        //public IActionResult Delete(int? Id)
        //{
        //    if (Id == null || Id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product? objProduct = UnitOfWork.Product.Get(c => c.Id == Id);
        //    if (objProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(objProduct);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePost(int? Id)
        //{
        //    Product? objProduct = UnitOfWork.Product.Get(c => c.Id == Id);

        //    if (objProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    UnitOfWork.Product.Remove(objProduct);
        //    UnitOfWork.Save();
        //    Notify("Product", ActionType.Deleted, NotificationType.Success);
        //    return RedirectToAction("Index");
        //}

        #region API Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductlist = UnitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objProductlist });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = UnitOfWork.Product.Get(c => c.Id == id);

            if ( productToBeDeleted == null)
            {
                return Json(new { success= false, message= "Error while deleting" });
            }

            var oldImagePath = Path.Combine(WebHostEnvironment.WebRootPath, productToBeDeleted.ImageURL.TrimStart('\\'));

            if (Directory.Exists(oldImagePath))
            {
                 Directory.Delete(oldImagePath);
            }

            UnitOfWork.Product.Remove(productToBeDeleted);
            UnitOfWork.Save();
            Notify("Product", ActionType.Deleted, NotificationType.Success);
            return Json(new { success = true, message = "Deleted successfully." });
        }
        #endregion
    }

}

