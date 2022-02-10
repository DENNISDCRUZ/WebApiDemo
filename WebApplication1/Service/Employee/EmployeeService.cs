using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.AppContext;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class EmployeeService : IEmployeeService
    {

        private AppDbContext _appDbContext;
        public EmployeeService( AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Employees AddEmployee(Employees emp)
        {
            emp.EmpID = Guid.NewGuid();
            _appDbContext.Employees.Add(emp);
            _appDbContext.SaveChanges();
            return _appDbContext.Employees.Where(a => a.EmpID == emp.EmpID).FirstOrDefault();

        }

        public void DeleteEmployee(Employees emp)
        {
            _appDbContext.Remove(emp);
            _appDbContext.SaveChanges();
        }

        public Employees EditEmployee(Employees emp)
        {
            var existingEmployees = _appDbContext.Employees.Find(emp.EmpID);
            if(existingEmployees!= null)
            {
                existingEmployees.Name = emp.Name;
                existingEmployees.Age = emp.Age;
                _appDbContext.Update(existingEmployees);
                _appDbContext.SaveChanges();
            }
           
            return (emp);

        }
         
        public IList<Employees> GetAllEmployees()
        {
            return _appDbContext.Employees.ToList();
        }

        public Employees GetEmployeeById(Guid id)
        {
            return (_appDbContext.Employees.Where(a=>a.EmpID == id).FirstOrDefault());
        }
    }
}
