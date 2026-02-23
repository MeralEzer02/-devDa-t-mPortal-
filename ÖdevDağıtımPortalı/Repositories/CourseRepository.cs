using ÖdevDağıtım.API.Data;
using ÖdevDağıtım.API.Models;
namespace ÖdevDağıtım.API.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context) { }
    }
}