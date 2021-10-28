using EmployeePerfomance.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerfomance.Web.Models
{
    public class ParameterViewModel
    {
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public int Coefficient { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
