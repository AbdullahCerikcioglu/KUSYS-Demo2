using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Courses.CreateCourse
{
    public class CreateCourseCommand : IRequest<CourseDto>
    {
          public string Name { get; set; }
    }
}
