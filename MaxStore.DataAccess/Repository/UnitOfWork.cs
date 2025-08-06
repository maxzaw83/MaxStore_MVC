using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxStore.DataAccess.Repository.IRepository;
using MaxStore.DataAccess.Data;

namespace MaxStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext _db)
        {
            db= _db;
            Category= new CategoryRepository(db);
        }
      

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
