using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _OrnekProje.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}