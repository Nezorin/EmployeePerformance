using EmployeePerfomance.BusinessLogic.Contracts;
using EmployeePerfomance.DataAccessLayer;
using EmployeePerfomance.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.BusinessLogic.Implementations
{
    public class ParameterService : IParameterService
    {
        private readonly IDbRepository _db;

        public ParameterService(IDbRepository db)
        {
            _db = db;
        }
        public async Task CreateAsync(Parameter parameter)
        {
            await _db.Add(parameter);
            await _db.SaveChangesAsync();
        }
        public IQueryable<Parameter> GetAll()
        {
            return _db.Get<Parameter>().Include( p => p.Department);
        }
        public async Task UpdateAsync(Parameter parameter)
        {
            await _db.Update(parameter);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            await _db.Delete<Parameter>(id);
            await _db.SaveChangesAsync();
        }
    }
}
