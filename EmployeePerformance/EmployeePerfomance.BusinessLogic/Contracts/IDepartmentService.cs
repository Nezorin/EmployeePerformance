using EmployeePerfomance.DataAccessLayer.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.BusinessLogic.Contracts
{
    public interface IDepartmentService
    {
        public Task CreateAsync(Department department);
        public IQueryable<Department> GetAll();
        public Task UpdateAsync(Department department);
        public Task RemoveByIdAsync(Guid id);
    }
}
