using EmployeePerfomance.BusinessLogic.Contracts;
using EmployeePerfomance.DataAccessLayer;
using EmployeePerfomance.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePerfomance.BusinessLogic.Implementations
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IDbRepository _db;
        public EvaluationService(IDbRepository evaluationRepository)
        {
            _db = evaluationRepository;
        }
        public Task CreateEvaluation(Evaluation evaluation)
        {
            return _db.Add(evaluation);
        }

        public IEnumerable<Evaluation> GetEvaluationFromUser(Guid id)
        {
            return _db.Get<Evaluation>().Where(t => t.UserId == id).ToList();
        }

        public IEnumerable<Evaluation> GetEvaluations()
        {
            return _db.Get<Evaluation>();
        }
    }
}
