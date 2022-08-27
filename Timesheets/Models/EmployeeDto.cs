using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models 
{ public class EmployeeDto 
    { 
        public int Id { get; set; } 
        public int DepartmentId { get; set; } 
        public int EmployeeTypeId { get; set; } 
        public int FirstName { get; set; } 
        public int Surname { get; set; } 
        public int Patronymic { get; set; } 
        public int Salary { get; set; } 
    } 
}
