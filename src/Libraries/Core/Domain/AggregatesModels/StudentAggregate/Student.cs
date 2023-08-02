using Domain.Exceptions;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModels.StudentAggregate
{
    public class Student : Entity, IAggregateRoot
    {
        public Student()
        {
            StudentCourses = new List<StudentCourse>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual IList<StudentCourse> StudentCourses { get; set; }

        public void AddCourse(Guid courseId)
        {
            var existsStudentCourse = StudentCourses.FirstOrDefault(x => x.StudentId == Id && x.CourseId == courseId);

            if (existsStudentCourse is not null)
            {
                throw new StudentDomainException("Student Already Added In Course");
            }

            var studentCourse = new StudentCourse { StudentId = Id, CourseId = courseId };
            StudentCourses.Add(studentCourse);
        }
    }
}
