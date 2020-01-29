using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);

        //根据部门id，查询获得该部门下的所有员工
        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);

        //解雇某员工
        Task<Employee> Fire(int id);
    }
}
