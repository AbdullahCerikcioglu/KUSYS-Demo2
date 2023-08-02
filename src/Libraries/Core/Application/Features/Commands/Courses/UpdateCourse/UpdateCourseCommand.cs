using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Courses.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<CourseDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
