using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagementASPNetCoreMVC.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> employeeList = new List<Employee>();
        private readonly IConfiguration config;

        public EmployeeRepository(IConfiguration configuration)
        {
            config = configuration;

            employeeList.Add(new Employee() { Id = 1, FirstName = "Mary", LastName = "Parker", Email = "mary.parker@mymail.com", DateOfBirth = new DateTime(1980, 8, 8) });
            employeeList.Add(new Employee() { Id = 2, FirstName = "Alicia", LastName = "Spinnet", Email = "Alicia.Spinnet@mymail.com", DateOfBirth = new DateTime(1980, 9, 23) });
            employeeList.Add(new Employee() { Id = 3, FirstName = "Ron", LastName = "Malfoy", Email = "Ron.Malfoy@mymail.com", DateOfBirth = new DateTime(1975, 2, 8) });
            
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            using (IDbConnection connection = new SqlConnection(config.GetConnectionString("EmployeeDB")))
            {
                return connection.Query<Employee>("dbo.uspEmployees_GetAllEmployees").ToList();
            }
        }

       
        public Employee GetById(int id)
        {
            using (IDbConnection connection = new SqlConnection(config.GetConnectionString("EmployeeDB")))
            {
                var employees = connection.Query<Employee>("dbo.uspEmployees_GetEmployeeById @Id", new { Id = id }).ToList();
                return employees[0];
            }

        }

        public void InsertEmployee()
        {
            using (IDbConnection connection = new SqlConnection(config.GetConnectionString("EmployeeDB")))
            {

                foreach(var employee in employeeList)
                {
                    connection.Execute("dbo.uspEmployees_InsertEmployeeInfo @FirstName, @LastName, @Email, @DateOfBirth", employee);
                }
            }
        }
    }
}
