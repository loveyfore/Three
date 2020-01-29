using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Three.Models
{
    public class CompanySummary
    {
        public int EmployeeCount { get; set; }

        //每个部门平均员工数目
        public int AverageDepartmentEmployeeCount { get; set; }
    }
}
