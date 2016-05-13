using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }

        public int GatherID { get; set; }

        public int CateID { get; set; }

        public string Username { get; set; }

        public DateTime OrderDate { get; set; }

        public bool OrderShipped { get; set; }

        public OrderModel()
        {

        }
    }
}