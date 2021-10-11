using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerfomance.DataAccessLayer.Entities
{
    public class Role : BaseEntity
    {
        [MaxLength(20)]
        [Required]
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
