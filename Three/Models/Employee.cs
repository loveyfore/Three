using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Three.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        //是否被解雇
        public bool Fired { get; set; }
    }

    public enum Gender
    {
        女 = 0,
        男 = 1
    }
}
