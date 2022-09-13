using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIDependencyInjectionTest.EmployeeData;
using WebAPIDependencyInjectionTest.Models;

namespace WebAPIDependencyInjectionTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeData _employeeData;
        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        //[Produces("application/xml")]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            try
            {
                return _employeeData.GetAllEmployees();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{name}")]
        public ActionResult<Employee> GetPersonByName(string name)
        {
            try
            {
                return _employeeData.GetEmployeeName(name);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Employee> UpdatePerson(int id, Employee employee)
        {
            try
            {
                return _employeeData.UpdateEmployee(id, employee);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Employee> Delete(int id)
        {
            try
            {
                return _employeeData.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
