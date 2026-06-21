using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApp.API.MVCS.Models.DBM.Collections;

public sealed class Author
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Bio { get; set; }
}
