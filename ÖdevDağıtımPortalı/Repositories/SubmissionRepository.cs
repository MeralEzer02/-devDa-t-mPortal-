using ÖdevDağıtım.API.Data;
using ÖdevDağıtım.API.Models;
namespace ÖdevDağıtım.API.Repositories
{
    public class SubmissionRepository : GenericRepository<Submission>, ISubmissionRepository
    {
        public SubmissionRepository(AppDbContext context) : base(context) { }
    }
}