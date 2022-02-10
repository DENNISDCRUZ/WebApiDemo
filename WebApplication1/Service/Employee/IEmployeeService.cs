using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public interface IEmployeeService
    {
        IList<Employees> GetAllEmployees();
        Employees GetEmployeeById(Guid id);
        Employees AddEmployee(Employees emp);
        void DeleteEmployee(Employees emp);
        Employees EditEmployee(Employees emp);

    }
}
