using EmployeePerfomance.DataAccessLayer.Entities;
using System.Linq;

namespace EmployeePerfomance.BusinessLogic.Contracts
{
    public interface IStatusService
    {
        public IQueryable<Status> GetAll();
    }
}
