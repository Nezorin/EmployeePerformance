using EmployeePerfomance.DataAccessLayer.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.BusinessLogic.Contracts
{
    public interface IParameterService
    {
        public Task CreateAsync(Parameter parameter);
        public IQueryable<Parameter> GetAll();
        public Task UpdateAsync(Parameter parameter);
        public Task DeleteByIdAsync(Guid id);
    }
}
