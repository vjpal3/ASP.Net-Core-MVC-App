using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementASPNetCoreMVC.Models
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        List<Employee> GetAllEmployees();
    }
}
