using System;

namespace EmployeePerfomance.DataAccessLayer.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
