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
        public List<Employee>GetAll()
        {
            List<Employee> emp = dbobj.GetAll();
            return emp;
        // return ApplySorting(SortOrder, SortBy, emp);

        }
        public List<Employee> ApplySorting(string SortOrder, string SortBy, List<Employee> employee)
        {
            switch (SortBy)
            {
                case "Name":
                    switch (SortOrder)
                    {
                        case "Asc":
                            employee = employee.OrderBy(x => x.Name).ToList();
                            break;

                        case "Desc":
                            employee = employee.OrderByDescending(x => x.Name).ToList();
                            break;
                        default:
                            employee = employee.OrderBy(x => x.Name).ToList();
                            break;

                    }
                    break;

                case "Salary":
                    switch (SortOrder)
                    {
                        case "Asc":
                            employee = employee.OrderBy(x => x.Salary).ToList();
                            break;

                        case "Desc":
                            employee = employee.OrderByDescending(x => x.Salary).ToList();
                            break;
                        default:
                            employee = employee.OrderBy(x => x.Salary).ToList();
                            break;
                    }
                    break;

                case "Office":
                    switch (SortOrder)
                    {
                        case "Asc":
                            employee = employee.OrderBy(x => x.Office).ToList();
                            break;

                        case "Desc":
                            employee = employee.OrderByDescending(x => x.Office).ToList();
                            break;
                        default:
                            employee = employee.OrderBy(x => x.Office).ToList();
                            break;
                    }
                    break;
                case "Position":
                    switch (SortOrder)
                    {
                        case "Asc":
                            employee = employee.OrderBy(x => x.Position).ToList();
                            break;

                        case "Desc":
                            employee = employee.OrderByDescending(x => x.Position).ToList();
                            break;
                        default:
                            employee = employee.OrderBy(x => x.Position).ToList();
                            break;
                    }
                    break;

                case "PF":
                    switch (SortOrder)
                    {
                        case "Asc":
                            employee = employee.OrderBy(x => x.PF).ToList();
                            break;

                        case "Desc":
                            employee = employee.OrderByDescending(x => x.PF).ToList();
                            break;
                        default:
                            employee = employee.OrderBy(x => x.PF).ToList();
                            break;
                    }
                    break;

                case "Age":
                    switch (SortOrder)
                    {
                        case "Asc":
                            employee = employee.OrderBy(x => x.Age).ToList();
                            break;

                        case "Desc":
                            employee = employee.OrderByDescending(x => x.Age).ToList();
                            break;
                        default:
                            employee = employee.OrderBy(x => x.Age).ToList();
                            break;
                    }
                    break;
                case "Entrydate":
                    switch (SortOrder)
                    {
                        case "Asc":
                            employee = employee.OrderBy(x => x.Entrydate).ToList();
                            break;

                        case "Desc":
                            employee = employee.OrderByDescending(x => x.Entrydate).ToList();
                            break;
                        default:
                            employee = employee.OrderBy(x => x.Entrydate).ToList();
                            break;
                    }
                    break;

                default:
                    switch (SortOrder)
                    {
                        case "Asc":
                            employee = employee.OrderBy(x => x.Entrydate).ToList();
                            break;

                        case "Desc":
                            employee = employee.OrderByDescending(x => x.Entrydate).ToList();
                            break;
                        default:
                            employee = employee.OrderBy(x => x.Entrydate).ToList();
                            break;
                    }
                    break;

            }

            return employee;
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
        public Boolean Update(Employee emp)
        {
          return dbobj.Update(emp);
        }
        public Boolean Delete(int id)
        {
          return  dbobj.Delete(id);

        }
    }
}
