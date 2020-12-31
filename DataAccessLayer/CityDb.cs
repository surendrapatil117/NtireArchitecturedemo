using ObjectBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class CityDb
    {
        private MvcCRUDDB1Context db;
        public CityDb()
        {
            db = new MvcCRUDDB1Context();
        }
        public List<tbl_city> GetAll()
        {
            var city = db.tbl_city.ToList();
            
            return city;
           
        }
    }
}
