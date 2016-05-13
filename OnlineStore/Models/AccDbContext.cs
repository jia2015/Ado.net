using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineStore.Models
{
    public class AccDbContext : DbContext
    {
        public DbSet<AccountModel> Users { get; set; }

        public System.Data.Entity.DbSet<OnlineStore.Models.GatherModel> GatherModels { get; set; }

    }
}