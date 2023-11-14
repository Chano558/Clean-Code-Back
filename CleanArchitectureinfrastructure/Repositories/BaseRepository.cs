using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureInfrastructure.Repositories
{
    public class BaseRepository
    {
        internal readonly SqlServerDbContext _dbContext;

        public BaseRepository(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}