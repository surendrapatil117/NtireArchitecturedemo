using ObjectBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    //Database logic for CRUD operation
    public class EmployeeDb
    {
        private MvcCRUDDB1Context db;
        public EmployeeDb()
        {
            db = new MvcCRUDDB1Context();
        }
        public List<Employee> GetAll()
        {
            //  List<Employee> obj = new List<Employee>();
            var employee = db.Employees.ToList();
            //switch (SortBy) 
            //{
            //    case "Name":
            //        switch (SortOrder)
            //        {
            //            case "Asc":
            //                employee = employee.OrderBy(x => x.Name).ToList();
            //                break;

            //            case "Desc":
            //                employee = employee.OrderByDescending(x => x.Name).ToList();
            //                break;
            //            default:
            //                employee = employee.OrderBy(x => x.Name).ToList();
            //                break;

            //        }
            //        break;

            //    case "Salary":
            //        switch (SortOrder)
            //        {
            //            case "Asc":
            //                employee = employee.OrderBy(x => x.Salary).ToList();
            //                break;

            //            case "Desc":
            //                employee = employee.OrderByDescending(x => x.Salary).ToList();
            //                break;
            //            default:
            //                employee = employee.OrderBy(x => x.Salary).ToList();
            //                break;
            //        }
            //        break;

            //    case "Office":
            //        switch (SortOrder)
            //        {
            //            case "Asc":
            //                employee = employee.OrderBy(x => x.Office).ToList();
            //                break;

            //            case "Desc":
            //                employee = employee.OrderByDescending(x => x.Office).ToList();
            //                break;
            //            default:
            //                employee = employee.OrderBy(x => x.Office).ToList();
            //                break;
            //        }
            //        break;
            //    case "Position":
            //        switch (SortOrder)
            //        {
            //            case "Asc":
            //                employee = employee.OrderBy(x => x.Position).ToList();
            //                break;

            //            case "Desc":
            //                employee = employee.OrderByDescending(x => x.Position).ToList();
            //                break;
            //            default:
            //                employee = employee.OrderBy(x => x.Position).ToList();
            //                break;
            //        }
            //        break;

            //    case "PF":
            //        switch (SortOrder)
            //        {
            //            case "Asc":
            //                employee = employee.OrderBy(x => x.PF).ToList();
            //                break;

            //            case "Desc":
            //                employee = employee.OrderByDescending(x => x.PF).ToList();
            //                break;
            //            default:
            //                employee = employee.OrderBy(x => x.PF).ToList();
            //                break;
            //        }
            //        break;

            //    case "Age":
            //        switch (SortOrder)
            //        {
            //            case "Asc":
            //                employee = employee.OrderBy(x => x.Age).ToList();
            //                break;

            //            case "Desc":
            //                employee = employee.OrderByDescending(x => x.Age).ToList();
            //                break;
            //            default:
            //                employee = employee.OrderBy(x => x.Age).ToList();
            //                break;
            //        }
            //        break;
            //    case "Entrydate":
            //        switch (SortOrder)
            //        {
            //            case "Asc":
            //                employee = employee.OrderBy(x => x.Entrydate).ToList();
            //                break;

            //            case "Desc":
            //                employee = employee.OrderByDescending(x => x.Entrydate).ToList();
            //                break;
            //            default:
            //                employee = employee.OrderBy(x => x.Entrydate).ToList();
            //                break;
            //        }
            //        break;

            //    default:
            //        switch (SortOrder)
            //        {
            //            case "Asc":
            //                employee = employee.OrderBy(x => x.Entrydate).ToList();
            //                break;

            //            case "Desc":
            //                employee = employee.OrderByDescending(x => x.Entrydate).ToList();
            //                break;
            //            default:
            //                employee = employee.OrderBy(x => x.Entrydate).ToList();
            //                break;
            //        }
            //        break;

            //}

           // employee = employee.Skip((PageNumber - 1) * 5).Take(5).ToList();

            return employee;

        }
        public IEnumerable<Employee> GetEmployeedata(string searchtext)
        {
            string numString = searchtext; //"1287543.0" will return false for a long
            int number1 = 0;
            bool canConvert = int.TryParse(numString, out number1);
            if (canConvert == true)
            {
                return db.Employees.Where(x => x.Name.Contains(searchtext) || x.Office.Contains(searchtext) || x.Position.Contains(searchtext) || x.Salary == number1 || x.PF == number1);

            }
            else
            {

                return db.Employees.Where(x => x.Name.Contains(searchtext) || x.Office.Contains(searchtext) || x.Position.Contains(searchtext));

            }

        }

        public int Getrowcount()
        {
            return db.Employees.Count();       
        }
        public Employee GetbyId(int Id)
        {
            return db.Employees.Find(Id);
        
        }

        public void Insert(Employee emp)
        {
            db.Employees.Add(emp);
            Savetodb();
        }
        public Boolean Update(Employee emp)
        {
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            Savetodb();
            return true;
        }
        public Boolean Delete(int id)
        {
            Employee empobj = db.Employees.Find(id);
            db.Employees.Remove(empobj);
            db.SaveChanges();
            return true;
        
        }
        public void Savetodb()
        {
            db.SaveChanges();
        }
    }
}
