using Domain.AggregatesModels.CourseAggregate;

namespace Persistence.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(EfDbContext context) : base(context)
        {
        }
    }
}
