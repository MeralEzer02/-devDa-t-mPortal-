using ÖdevDağıtım.API.Data;
using ÖdevDağıtım.API.Models;
namespace ÖdevDağıtım.API.Repositories
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(AppDbContext context) : base(context) { }
    }
}