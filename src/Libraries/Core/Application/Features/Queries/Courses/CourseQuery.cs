using Domain.AggregatesModels.CourseAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Courses
{
    public class CourseQuery : IRequest<IList<CourseViewModel>>
    {
        public string Name { get; set; }
    }
}
