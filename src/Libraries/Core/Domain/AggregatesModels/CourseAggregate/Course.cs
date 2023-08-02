using Domain.AggregatesModels.StudentAggregate;
using Domain.SeedWork;

namespace Domain.AggregatesModels.CourseAggregate
{
    public class Course : Entity, IAggregateRoot
    {
        public Course()
        {
            StudentCourses = new List<StudentCourse>();
        }
        public string Name { get; set; }

        public virtual IList<StudentCourse> StudentCourses { get; set; }
    }



}
