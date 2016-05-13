using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnlineStore.Models;

namespace OnlineStore.ViewModels
{
    public class AccountVM
    {
        public AccountModel Account { get; set; }


        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}