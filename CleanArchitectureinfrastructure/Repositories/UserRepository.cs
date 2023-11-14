using CleanArchitectureDomain.Entities;
using CleanArchitectureDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CleanArchitectureInfrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(SqlServerDbContext dbContext) : base(dbContext)
        {
        }

        public List<User> GetList(DateTime? From, DateTime? To)

        {
            var query = _dbContext.Set<User>()
                .Include(x => x.Role).Where(x => x.Role != null);

            if (From.HasValue)
            {
                query = query.Where(x => x.Role.Created >= From);
            }

            if (To.HasValue)
            {
                query = query.Where(x => x.Role.Created <= To);
            }

            var users = query.ToList();

            return users;
        }
    }
}