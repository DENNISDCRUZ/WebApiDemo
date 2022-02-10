using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        
        public IActionResult GetEmployees()
        {
           return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with Id:{id} was not found");
        }

        [HttpPost] 
        public IActionResult CreateEmployees(Employees emp)
        {
            if(emp!=null)
            {
                var outEmp = _employeeService.AddEmployee(emp);
                return Ok(outEmp);
            }
             
            return NotFound($"Employee Not Created");
        }

        [HttpDelete]
        public IActionResult DeleteEmployees(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if ( employee!= null)
            {
                _employeeService.DeleteEmployee(employee);
                return Ok(employee);
            }

            return NotFound($"Employee with Id:{id} was not found");
        }

        [HttpPut]
        public IActionResult EditEmployees(Employees emp,Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                emp.EmpID = employee.EmpID;
                _employeeService.EditEmployee(emp);
                return Ok(employee);
            }

            return NotFound($"Employee with Id:{id} was not found");
        }



    }
}
