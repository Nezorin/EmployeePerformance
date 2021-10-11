using EmployeePerfomance.DataAccessLayer.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.BusinessLogic.Contracts
{
    public interface IUserService
    {
        public Task CreateAsync(User user);
        public Task<User> GetByLoginAsync(string login);
        public IQueryable<User> GetAll();
        public Task UpdateAsync(User user);
        public Task DeleteByIdAsync(Guid id);
        
    }
}
