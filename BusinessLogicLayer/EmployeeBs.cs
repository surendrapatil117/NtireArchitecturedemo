using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ObjectBusinessLayer;

namespace BusinessLogicLayer
{
    // We will perform only Business logc only Database related code is not allowed.
    public class EmployeeBs
    {
        private EmployeeDb dbobj;
        public EmployeeBs()
        {
            dbobj = new EmployeeDb();
        }
        public IEnumerable<Employee> GetAll(string SortOrder,string SortBy,int PageNumber)
        {
            return dbobj.GetAll(SortOrder, SortBy,PageNumber);

        }
        public IEnumerable<Employee> GetEmployeedata(string searchtext)
        {
           return dbobj.GetEmployeedata(searchtext);
        }
            public int Getrowcount()
        {
            return dbobj.Getrowcount();


        }
        public Employee GetbyId(int Id)
        {
            return dbobj.GetbyId(Id);

        }

        public void Insert(Employee emp)
        {
            dbobj.Insert(emp);
        }
        public void Update(Employee emp)
        {
            dbobj.Update(emp);
        }
        public void Delete(int id)
        {
            dbobj.Delete(id);

        }
    }
}
