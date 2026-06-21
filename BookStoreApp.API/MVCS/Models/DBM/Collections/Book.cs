using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApp.API.MVCS.Models.DBM.Collections;

public sealed class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Year { get; set; }
    public string? ISBN { get; set; }
    public string? Summary { get; set; }
    public string? Image { get; set; }
    public float? Price { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    public string? AuthorId { get; set; }
}
