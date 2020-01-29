using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Models;

namespace Three.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();

        public EmployeeService()
        {
            _employees.Add(new Employee
            {
                Id = 1,
                DepartmentId = 1,
                FirstName = "Nick",
                LastName = "Carter",
                Gender = Gender.男
            });

            _employees.Add(new Employee
            {
                Id = 2,
                DepartmentId = 1,
                FirstName = "Michael",
                LastName = "Jackson",
                Gender = Gender.男
            });

            _employees.Add(new Employee
            {
                Id = 3,
                DepartmentId = 1,
                FirstName = "Mariah",
                LastName = "Carey",
                Gender = Gender.女
            });
        }
        public Task Add(Employee employee)
        {
            employee.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(() => {
                //如果删除这一段，直接返回null，则无法编译通过......，解决办法就是对null进行强转
                var employee = _employees.FirstOrDefault(e => e.Id == id);
                if (employee != null)
                {
                    employee.Fired = true;
                    return employee;
                }


                return null;
            });
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            //Where里边是lambda表达式！
            return Task.Run(() => _employees.Where(x => x.DepartmentId == departmentId).AsEnumerable());
        }
    }
}
