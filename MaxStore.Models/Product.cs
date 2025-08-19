using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [Display(Name ="List Price")]
        public double ListPrice { get; set; }

        [Display(Name = "Discount Price")]
        public double DiscountPrice { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever] 
        public Category Category { get; set; }

        [Display(Name = "Image")]
        [ValidateNever]
        public string ImageURL { get; set; }


    }
}
