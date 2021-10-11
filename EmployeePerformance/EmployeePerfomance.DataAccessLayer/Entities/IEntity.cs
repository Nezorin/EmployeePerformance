using System;

namespace EmployeePerfomance.DataAccessLayer.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool IsActive { get; set; }
    }
}
