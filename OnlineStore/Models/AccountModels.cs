using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class AccountModel
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ComfirmPassword { get; set; }

        public string UserRole { get; set; }

        public AccountModel()
        {
        }
        public AccountModel(string name, string pass)
        {
            Username = name;
            Password = pass;
        }
    }

}