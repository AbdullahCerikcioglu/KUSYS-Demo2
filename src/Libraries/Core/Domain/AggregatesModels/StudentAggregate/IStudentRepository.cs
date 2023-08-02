using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModels.StudentAggregate
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
