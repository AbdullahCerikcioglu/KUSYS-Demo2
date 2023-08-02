using Domain.AggregatesModels.CourseAggregate;
using Domain.SeedWork;

namespace Domain.AggregatesModels.StudentAggregate
{
    public class StudentCourse : Entity
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

        public StudentCourse()
        {

        }
        public StudentCourse(Guid studentId, Guid courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }

        

        public virtual Course Course { get; set;}
        public virtual Student Student { get; set;}
    }



}
