using AutoMapper;
using Domain.AggregatesModels.CourseAggregate;
using Domain.AggregatesModels.StudentAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Students.CreateStudent
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDto>
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public CreateStudentHandler(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Student>(request);

            var response = await _repository.CreateAsync(entity, cancellationToken);

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<StudentDto>(response);

        }
    }
}
