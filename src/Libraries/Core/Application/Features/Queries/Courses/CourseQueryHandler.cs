using Application.Features.Queries.Students;
using AutoMapper;
using Domain.AggregatesModels.CourseAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Courses
{
    public class CourseQueryHandler : IRequestHandler<CourseQuery, IList<CourseViewModel>>
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseQueryHandler(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<CourseViewModel>> Handle(CourseQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Table.ToListAsync();

            return _mapper.Map<List<CourseViewModel>>(result);
        }
    }
}
