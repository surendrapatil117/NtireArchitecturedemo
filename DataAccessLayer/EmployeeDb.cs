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
        public IEnumerable<Employee> GetAll()
        {
           return db.Employees.ToList();
        
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
        public void Update(Employee emp)
        {
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            Savetodb();
        }
        public void Delete(int id)
        {
            Employee empobj = db.Employees.Find(id);
            db.Employees.Remove(empobj);
        
        }
        public void Savetodb()
        {
            db.SaveChanges();
        }
    }
}
