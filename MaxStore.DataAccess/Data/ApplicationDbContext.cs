
using MaxStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MaxStore.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "မုန့်ဟင်းခါး၊ အုန်းနို့ခေါက်ဆွဲ၊ ရခိုင်မုန့်တီ နဲ့ အသုပ်အမျိုးမျိုး", DisplayOrder = 1 },
                new Category { Id = 2, Name = "ရှမ်းအစားအသောက်များ", DisplayOrder = 2 },
                new Category { Id = 3, Name = "ကော်ဖီ၊ လက်ဖက်ရည် နဲ့ လက်ဖက်ခြောက်", DisplayOrder = 3 },
                new Category { Id = 4, Name = "အသင့်စားစည်သွပ်ဘူးများ", DisplayOrder = 4 },
                new Category { Id = 5, Name = "အရံဟင်းလျာများ", DisplayOrder = 5 },
                new Category { Id = 6, Name = "လက်ဖက် နဲ့ အကြော်စုံ", DisplayOrder = 6 },
                  new Category { Id = 7, Name = "ငါးပိ၊ ငါးခြောက် နဲ့ ပုဇွန်ခြောက်", DisplayOrder = 7 },
                   new Category { Id = 8, Name = "Medicine", DisplayOrder = 8 }

                );
          
        modelBuilder.Entity<Product>().HasData(
                new Product { Id=1,Title = "Product a", Description = "a Description", ListPrice= 4.0, DiscountPrice=0, CategoryId = 1, ImageURL="" },
 new Product { Id = 2, Title = "Product b", Description = "b Description", ListPrice = 5.0, DiscountPrice = 0, CategoryId = 2, ImageURL = "" }

                );
        }
    }
}
