using EmployeePerfomance.BusinessLogic.Contracts;
using EmployeePerfomance.DataAccessLayer;
using EmployeePerfomance.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.BusinessLogic.Implementations
{
    public class UserService : IUserService
    {
        private readonly IDbRepository _db;

        public UserService(IDbRepository db)
        {
            _db = db;
        }
        public async Task CreateAsync(User user)
        {
            await _db.Add(user);
            await _db.SaveChangesAsync();
        }
        public async Task<User> GetByLoginAsync(string login)
        {
            return await _db.Get<User>().FirstOrDefaultAsync(u => u.Login == login);
        }
        public IQueryable<User> GetAll()
        {
            return _db.Get<User>().Include(u => u.Role).Include(u => u.Status).Include(u => u.Department);
        }
        public async Task UpdateAsync(User user)
        {
            await _db.Update(user);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteByIdAsync(Guid id)
        {
            await _db.Delete<User>(id);
            await _db.SaveChangesAsync();
        }
    }
}
