using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Solution.Core.MongoDB
{
    public abstract class Document : IDocument
    {
        [BsonExtraElements]
        public BsonDocument ExtraElements { get; set; }

        public ObjectId Id { get; set; }
    }
}
