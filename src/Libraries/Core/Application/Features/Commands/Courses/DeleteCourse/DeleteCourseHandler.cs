using Domain.AggregatesModels.CourseAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Courses.DeleteCourse
{
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, bool>
    {

        private readonly ICourseRepository _repository;

        public DeleteCourseHandler(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.Table.FirstOrDefaultAsync(course => course.Id == request.Id, cancellationToken);

            await _repository.DeleteAsync(entity, cancellationToken);

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
