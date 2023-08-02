using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Students.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStudentCommand()
        {

        }

        public DeleteStudentCommand(Guid id)
        {
            Id = id;
        }
    }
}
