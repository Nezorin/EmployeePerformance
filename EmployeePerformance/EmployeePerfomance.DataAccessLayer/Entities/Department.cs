using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerfomance.DataAccessLayer.Entities
{
    public class Department : BaseEntity
    {
        [MaxLength(20)]
        [Required]
        public string DepartmentName { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Parameter> Parameters { get; set; }
    }
}
