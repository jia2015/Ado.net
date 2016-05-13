using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OnlineStore.Models;

namespace OnlineStore.ViewModels
{
    public class GatherProductVM
    {
       // public List<GatherModel> Activities { get; set; }

      //  public List<ProductModel> Products { get; set; }

        public GatherModel Activities { get; set; }

        public ProductModel Products { get; set; }

        public GatherProductVM()
        {
            Activities = new GatherModel();
            Products = new ProductModel();
        }
    }
}