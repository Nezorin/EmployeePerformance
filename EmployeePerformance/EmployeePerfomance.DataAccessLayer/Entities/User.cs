using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerfomance.DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
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
        public Guid? RoleId { get; set; }
        public Role Role { get; set; }
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }
        public Guid? StatusId { get; set; }
        public Status Status { get; set; }
    }
}
