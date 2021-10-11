using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerfomance.DataAccessLayer.Entities
{
    public class Status : BaseEntity
    {
        [MaxLength(20)]
        [Required]
        public string StatusName { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
