using EmployeePerfomance.BusinessLogic.Contracts;
using EmployeePerfomance.DataAccessLayer;
using EmployeePerfomance.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.BusinessLogic.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDbRepository _db;

        public DepartmentService(IDbRepository db)
        {
            _db = db;
        }
        public async Task CreateAsync(Department department)
        {
            await _db.Add(department);
            await _db.SaveChangesAsync();
        }
        public IQueryable<Department> GetAll()
        {
            return _db.Get<Department>();
        }
        public async Task UpdateAsync(Department department)
        {
            await _db.Update(department);
            await _db.SaveChangesAsync();
        }
        public async Task RemoveByIdAsync(Guid id)
        {
            var departmentToRemove = await _db.GetAll<Department>().FirstOrDefaultAsync(d => d.Id == id);
            await _db.Remove(departmentToRemove);
            await _db.SaveChangesAsync();
        }
    }
}
