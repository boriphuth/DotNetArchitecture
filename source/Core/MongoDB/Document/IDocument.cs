using MongoDB.Bson;

namespace Solution.Core.MongoDB
{
    public interface IDocument
    {
        ObjectId Id { get; set; }
    }
}
