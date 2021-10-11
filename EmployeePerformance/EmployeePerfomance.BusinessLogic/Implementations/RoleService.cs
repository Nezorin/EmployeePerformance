using EmployeePerfomance.BusinessLogic.Contracts;
using EmployeePerfomance.DataAccessLayer;
using EmployeePerfomance.DataAccessLayer.Entities;
using System.Linq;

namespace EmployeePerfomance.BusinessLogic.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IDbRepository _db;

        public RoleService(IDbRepository db)
        {
            _db = db;
        }
        public IQueryable<Role> GetAll()
        {
            return _db.Get<Role>();
        }
    }
}
