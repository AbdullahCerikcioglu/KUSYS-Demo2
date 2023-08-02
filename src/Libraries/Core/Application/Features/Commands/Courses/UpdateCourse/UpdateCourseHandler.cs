using AutoMapper;
using Domain.AggregatesModels.CourseAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Courses.UpdateCourse
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, CourseDto>
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCourseHandler(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CourseDto> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Course>(request);

            var response = await _repository.UpdateAsync(entity, cancellationToken);

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CourseDto>(response);
        }
    }
}
