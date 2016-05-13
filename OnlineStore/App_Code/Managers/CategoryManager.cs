using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using OnlineStore.App_Code.DataProvider;
using OnlineStore.Models;
using System.Data;

namespace OnlineStore.App_Code.Managers
{
    public static class CategoryManager
    {
        public static List<CategoryModel> PullCategory()
        {
            List<CategoryModel> Categories = new List<CategoryModel>();
            DataTable dt = CategoryDataProvider.GetCategories();

            foreach (DataRow dr in dt.Rows)
            {
                CategoryModel cate = new CategoryModel();
                cate.CateID = int.Parse(dr[0].ToString());
                cate.CateName = dr[1].ToString();
              
                Categories.Add(cate);
            }
            return Categories;
        }
    }
}