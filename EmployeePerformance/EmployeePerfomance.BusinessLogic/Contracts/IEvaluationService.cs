using EmployeePerfomance.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePerfomance.BusinessLogic.Contracts
{
    public interface IEvaluationService
    {
        public IEnumerable<Evaluation> GetEvaluations();
        public IEnumerable<Evaluation> GetEvaluationFromUser(Guid id);
        public Task CreateEvaluation(Evaluation evaluation);
    }
}
