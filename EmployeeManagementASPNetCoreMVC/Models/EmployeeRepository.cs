using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementASPNetCoreMVC.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employeeList = new List<Employee>();
        public EmployeeRepository()
        {
            employeeList.Add(new Employee() { Id = 1, FirstName = "Mary", LastName = "Parker", Email = "mary.parker@mymail.com", DateOfBirth = new DateTime(1980, 8, 8) });
            employeeList.Add(new Employee() { Id = 2, FirstName = "Alicia", LastName = "Spinnet", Email = "Alicia.Spinnet@mymail.com", DateOfBirth = new DateTime(1980, 8, 8) });
            employeeList.Add(new Employee() { Id = 3, FirstName = "Ron", LastName = "Malfoy", Email = "Ron.Malfoy@mymail.com", DateOfBirth = new DateTime(1975, 2, 8) });
            
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeList;
        }

       
        public Employee GetById(int id)
        {
            return employeeList.FirstOrDefault(e => e.Id == id);
        }
    }
}
