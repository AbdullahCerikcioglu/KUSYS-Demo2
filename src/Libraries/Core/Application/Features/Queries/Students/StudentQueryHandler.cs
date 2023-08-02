using AutoMapper;
using Domain.AggregatesModels.CourseAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Students
{
    public class StudentQueryHandler : IRequestHandler<StudentQuery, IList<StudentViewModel>>
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public StudentQueryHandler(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<StudentViewModel>> Handle(StudentQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Table.ToListAsync();

            return _mapper.Map<List<StudentViewModel>>(result);
        }
    }
}
