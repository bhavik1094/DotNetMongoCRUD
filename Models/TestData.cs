using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApp1.Models
{
    public class TestData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("position")]
        public string Position { get; set; } = string.Empty;

        [BsonElement("salary")]
        public double Salary { get; set; }
    }
}

