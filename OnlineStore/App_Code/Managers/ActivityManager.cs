using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using OnlineStore.App_Code.DataProvider;
using OnlineStore.Models;

namespace OnlineStore.App_Code.Managers
{
    public static class ActivityManager
    {
        public static List<GatherModel> PullActivity()
        {
            List<GatherModel> activities = new List<GatherModel>();
            DataTable dt = ActivityDataProvider.GetActivities();

            foreach (DataRow dr in dt.Rows)
            {
                GatherModel gather = new GatherModel();
                gather.GatherID = int.Parse(dr[0].ToString());
                gather.GatherTitle = dr[1].ToString();
                gather.Price = decimal.Parse(dr[2].ToString());
                gather.StartTime = Convert.ToDateTime(dr[3]);
                gather.EndTime = Convert.ToDateTime(dr[4]);
                gather.MinBuyers = int.Parse(dr[5].ToString());
                gather.CurrentBuyers = int.Parse(dr[6].ToString());
                gather.CateID = int.Parse(dr[7].ToString());
                activities.Add(gather);
            }
            return activities;
        }

        public static List<GatherModel> PullActivityByCategory(int cateID)
        {
            List<GatherModel> activities = new List<GatherModel>();
            DataTable dt = ActivityDataProvider.GetActivityByCategory(cateID);

            foreach (DataRow dr in dt.Rows)
            {
                GatherModel gather = new GatherModel();
                gather.GatherID = int.Parse(dr[0].ToString());
                gather.GatherTitle = dr[1].ToString();
                gather.Price = decimal.Parse(dr[2].ToString());
                gather.StartTime = Convert.ToDateTime(dr[3]);
                gather.EndTime = Convert.ToDateTime(dr[4]);
                gather.MinBuyers = int.Parse(dr[5].ToString());
                gather.CurrentBuyers = int.Parse(dr[6].ToString());
                gather.CateID = int.Parse(dr[7].ToString());
                activities.Add(gather);
            }
            return activities;
        }


    }
}


