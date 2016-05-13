using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;
using OnlineStore.ViewModels;
using OnlineStore.App_Code.Managers;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //public ActionResult Index()
        //{
        //    if (Session["username"] != null || Request.Cookies["userInfo"] != null)
        //    {
        //        //using (AccDbContext db = new AccDbContext())
        //        //{
        //        //    return View(db.Users.ToList());
        //        //}
        //    }
        //    else
        //    {
        //        return View("Login");
        //    }
        //}

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AccountModel user)
        {
            if (ModelState.IsValid)
            {
                //using (AccDbContext db = new AccDbContext())
                //{
                //    db.Users.Add(user);
                //    db.SaveChanges();
                //}
                //ModelState.Clear();
                //ViewBag.Message = user.Username + " Successfully Registered.";

                if (UserManager.CreateAndEditUser(user))
                {
                    ModelState.Clear();
                    ViewBag.Message = user.Username + " Successfully Registered.";
                }
                else
                {
                    ModelState.AddModelError("", "Username already exists.");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountVM user)
        {
            //using (AccDbContext db = new AccDbContext())
            //{
            //    var usr = db.Users.Where(u => u.Username == user.Account.Username && u.Password == user.Account.Password).FirstOrDefault();
            //    if (usr != null)
            //    {
            //        Session["userID"] = usr.UserID.ToString();
            //        Session["username"] = usr.Username.ToString();
            //        if (user.RememberMe)
            //        {
            //            HttpCookie userCookie = new HttpCookie("userInfo");
            //            userCookie.Values["username"] = usr.Username.ToString();
            //            userCookie.Values["password"] = usr.Password.ToString();
            //            userCookie.Expires = DateTime.Now.AddSeconds(3600);
            //            Response.Cookies.Add(userCookie);
            //        }
            //        return RedirectToAction("LoggedIn");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Invalid Username or Password");
            //    }
            //}
         
                if (UserManager.HasUser(user))
                {
                    Session["userID"] = user.Account.UserID.ToString();
                    Session["username"] = user.Account.Username.ToString();
                    if (user.RememberMe)
                    {
                        HttpCookie userCookie = new HttpCookie("userInfo");
                        //userCookie.Values.Add("username", user.Account.Username.ToString());
                        //userCookie.Values.Add("password", user.Account.Password.ToString());
                        userCookie.Values["username"] = user.Account.Username.ToString();
                        userCookie.Values["password"] = user.Account.Password.ToString();
                        userCookie.Expires = DateTime.Now.AddSeconds(3600);
                        Response.Cookies.Add(userCookie);
                    }
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["username"] != null || Request.Cookies["userInfo"] != null)
            {
                ViewBag.username = Session["username"].ToString();
              
                if (Request.Cookies["userInfo"] != null)
                    ViewBag.username = Request.Cookies["userInfo"]["username"];
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userCookie = new HttpCookie("userInfo");              
                userCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(userCookie);
            }
            return RedirectToAction("Login");
        }

    }
}