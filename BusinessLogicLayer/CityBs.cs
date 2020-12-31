using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ObjectBusinessLayer;

namespace BusinessLogicLayer
{
   public class CityBs
    {
        private CityDb dbobj;
        public CityBs()
        {
            dbobj= new CityDb();

        }

        public List<tbl_city> GetAll()
        {
            List<tbl_city> citybs = dbobj.GetAll();
            return citybs;
            // return ApplySorting(SortOrder, SortBy, emp);

        }

    }
}
