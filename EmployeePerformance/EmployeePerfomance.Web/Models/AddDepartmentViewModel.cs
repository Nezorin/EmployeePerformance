using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerfomance.Web.Models
{
    public class AddDepartmentViewModel
    {
        [MaxLength(20)]
        [Required]
        [Remote(action: "CheckDepartment", controller: "Department", ErrorMessage = "Department with such name is already exist")]
        public string DepartmentName { get; set; }
    }
}
