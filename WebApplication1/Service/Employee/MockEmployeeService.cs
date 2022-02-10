using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class MockEmployeeService : IEmployeeService
    {

        private List<Employees> lstemp = new List<Employees>()
        {
            new Employees()
            {
                EmpID= Guid.NewGuid(),
                Name="Dennis",
                Age=28
            },
             new Employees()
            {
                EmpID= Guid.NewGuid(),
                Name="Dinna",
                Age=21
            }

        };
        public Employees AddEmployee(Employees emp)
        {
            emp.EmpID = Guid.NewGuid();
            lstemp.Add(emp);
            return (lstemp.Where(a => a.EmpID == emp.EmpID).FirstOrDefault());
        }

        public void DeleteEmployee(Employees emp)
        {
           lstemp.Remove(emp);
        }

        public Employees EditEmployee(Employees emp)
        {
            var existingemp = GetEmployeeById(emp.EmpID);
            existingemp.Name = emp.Name;
            existingemp.Age = emp.Age;
            return existingemp;
        }

        public IList<Employees> GetAllEmployees()
        {
            return lstemp;
        }

        public Employees GetEmployeeById(Guid id)
        {
           return (lstemp.Where(a => a.EmpID == id).FirstOrDefault());
        }
    }
}
