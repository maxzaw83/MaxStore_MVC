using MaxStore.DataAccess.Data;
using MaxStore.DataAccess.Repository.IRepository;
using MaxStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(r => r.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.DiscountPrice = obj.DiscountPrice;

                if(!string.IsNullOrEmpty(obj.ImageURL))
                {
                    objFromDb.ImageURL = obj.ImageURL;
                }
            }
            
        }

      
    }
}
