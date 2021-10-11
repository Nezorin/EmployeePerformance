using EmployeePerfomance.BusinessLogic.Contracts;
using EmployeePerfomance.DataAccessLayer;
using EmployeePerfomance.DataAccessLayer.Entities;
using System.Linq;

namespace EmployeePerfomance.BusinessLogic.Implementations
{
    public class StatusService : IStatusService
    {
        private readonly IDbRepository _db;

        public StatusService(IDbRepository db)
        {
            _db = db;
        }
        public IQueryable<Status> GetAll()
        {
            return _db.Get<Status>();
        }
    }
}
