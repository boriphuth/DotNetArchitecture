using Solution.Core.Databases;
using Solution.Model.Entities;

namespace Solution.Infrastructure.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }
}
