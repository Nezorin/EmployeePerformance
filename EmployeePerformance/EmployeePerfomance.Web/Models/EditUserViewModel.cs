using EmployeePerfomance.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.Web.Models
{
    public class EditUserViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public Guid? RoleId { get; set; }
        public List<Role> Roles { get; set; }
        [Required]
        public Guid? StatusId { get; set; }
        public List<Status> Statuses { get; set; }
        [Required]
        public Guid? DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
    }
}
