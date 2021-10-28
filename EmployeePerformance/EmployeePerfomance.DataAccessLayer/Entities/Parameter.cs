using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeePerfomance.DataAccessLayer.Entities
{
    public class Parameter : BaseEntity
    {
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public int Coefficient { get; set; }
        public Department Department { get; set; }
        public Guid? DepartmentId { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }
}
