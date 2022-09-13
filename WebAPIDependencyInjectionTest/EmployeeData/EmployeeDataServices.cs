using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDependencyInjectionTest.Models;

namespace WebAPIDependencyInjectionTest.EmployeeData
{
    public class EmployeeDataServices : IEmployeeData
    {
        public readonly IEnumerable<Employee> _iEmployeeData;

        public EmployeeDataServices(IEnumerable<Employee> iEmployeeData)
        {
            _iEmployeeData = iEmployeeData;
        }

        List<Employee> Employees = new List<Employee>
        {
            new Employee{Id=1, FirstName="John", MiddleName = "Ray", LastName="Doe" },
            new Employee{Id=2, FirstName="Ray", MiddleName = "Light", LastName="Charles" },
            new Employee{Id=3, FirstName="Sun",MiddleName = "Yet",  LastName="Lei" },
        };
        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        public Employee GetEmployeeName(string name)
        {
            Employee a;
            a = Employees.FirstOrDefault(x => x.FirstName.ToLower().ToUpper().Trim().Contains(name.ToLower().ToUpper().Trim()) || x.LastName.ToLower().ToUpper().Trim().Contains(name.ToLower().ToUpper().Trim()));
            return a;
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
            Employee a = (from x in Employees where x.Id == id select x).FirstOrDefault();
            a.FirstName = employee.FirstName;
            a.MiddleName = employee.MiddleName;
            a.LastName = employee.LastName;

            return a;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee a = (from x in Employees where x.Id == id select x).FirstOrDefault();
            Employees.Remove(a);
            return a;
        }
    }
}
