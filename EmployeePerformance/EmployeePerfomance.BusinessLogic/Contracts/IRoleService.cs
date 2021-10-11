using EmployeePerfomance.DataAccessLayer.Entities;
using System.Linq;

namespace EmployeePerfomance.BusinessLogic.Contracts
{
    public interface IRoleService
    {
        public IQueryable<Role> GetAll();
    }
}
