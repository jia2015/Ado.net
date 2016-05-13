using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class CategoryModel
    {
        [Key]
        public int CateID { get; set; }

        [Required]
        [Display(Name="Categories")]
        public string CateName { get; set; }

        public CategoryModel()
        {

        }
    }
}