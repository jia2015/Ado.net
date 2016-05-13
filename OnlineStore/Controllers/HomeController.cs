using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;

using OnlineStore.ViewModels;
using OnlineStore.App_Code.Managers;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CateActivityVM vm = new CateActivityVM();
            vm.Activities = ActivityManager.PullActivity();
            vm.Categories = CategoryManager.PullCategory();
           
            return View(vm);
        }

        public ActionResult Activities(int categoryId)
        {
            
            CateActivityVM vm = new CateActivityVM();
            vm.Categories = CategoryManager.PullCategory();
            vm.Activities = ActivityManager.PullActivityByCategory(categoryId);
            return View("Index", vm);                     
        }

    }
}
