using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlineStore.App_Code.DataProvider;
using OnlineStore.Models;
using OnlineStore.ViewModels;

namespace OnlineStore.App_Code.Managers
{
    public static class UserManager
    {
        public static bool CreateAndEditUser(AccountModel user)
        {
            if (user == null)
            {
                return false;
            }
            if (user.UserID > 0)
            {
                return UserDataProvider.EditUser(user);
            }
            if (UserDataProvider.ExistsUser(user))
            {
                return false;
            }
            return UserDataProvider.CreateUser(user);
        }

        public static bool HasUser(AccountVM user)
        {
            if (user == null)
            {
                return false;
            }
            return UserDataProvider.ExistsUser(user);
        }
    }
}
