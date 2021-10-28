using System;

namespace EmployeePerfomance.DataAccessLayer.Entities
{
    public class Evaluation : BaseEntity
    {
        public int Mark { get; set; }
        public string MarkDescription { get; set; }
        public Guid? AssessorId { get; set; }
        public Guid ParameterId { get; set; }
        public Guid UserId { get; set; }
        public DateTime AssessmentDate { get; set; }
        public int AssessmentNumber { get; set; }
        public User Assessor { get; set; }
        public Parameter Parameter { get; set; }
        public User User { get; set; }
    }
}
