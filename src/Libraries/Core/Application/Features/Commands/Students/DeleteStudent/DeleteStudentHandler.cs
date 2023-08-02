using Domain.AggregatesModels.CourseAggregate;
using Domain.AggregatesModels.StudentAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Students.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {

        private readonly IStudentRepository _repository;

        public DeleteStudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Table.FirstOrDefaultAsync(student => student.Id == request.Id, cancellationToken);

            if (entity is null) { return false; }

            await _repository.DeleteAsync(entity, cancellationToken);

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
