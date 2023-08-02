using AutoMapper;
using Domain.AggregatesModels.CourseAggregate;
using Domain.AggregatesModels.StudentAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Students.UpdateStudent
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, StudentDto>
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateStudentHandler(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Student>(request);

            var response = await _repository.UpdateAsync(entity, cancellationToken);

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StudentDto>(response);

        }
    }
}
