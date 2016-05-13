using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class GatherModel
    {
        [Key]
        public int GatherID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Name")]
        public string GatherTitle { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Minimum number of people is required.")]
        public int MinBuyers { get; set; }

        public int CurrentBuyers { get; set; }

        public int CateID { get; set; }


        public GatherModel()
        {

        }
    }
}