using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OnlineStore.Models;

namespace OnlineStore.ViewModels
{
    public class CateActivityVM
    {
        public List<CategoryModel> Categories { get; set; }

        public List<GatherModel> Activities { get; set; }

        public CateActivityVM()
        {
            Categories = new List<CategoryModel>();
            Activities = new List<GatherModel>();
        }
    }
}