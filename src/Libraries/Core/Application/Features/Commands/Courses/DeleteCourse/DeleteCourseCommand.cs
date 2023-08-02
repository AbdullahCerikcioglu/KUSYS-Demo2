using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Courses.DeleteCourse
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCourseCommand()
        {

        }

        public DeleteCourseCommand(Guid id)
        {
            Id = id;
        }
    }
}
