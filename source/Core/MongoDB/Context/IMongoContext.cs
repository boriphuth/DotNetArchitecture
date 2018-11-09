using MongoDB.Driver;

namespace Solution.Core.MongoDB
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
