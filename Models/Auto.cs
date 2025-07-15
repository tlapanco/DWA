using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoMongoDB.Models
{
    public class Auto 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string  ID { get; set; }

        [BsonElement("modelo")]
        public string? Modelo { get; set; }

        [BsonElement("marca")]
        public string? Marca { get; set; }

        [BsonElement("precio")]
        public decimal Precio { get; set; }

        [BsonElement("motor")]
        public string? Motor { get; set; }

        [BsonElement("descripcion")]
        public string? Descripcion { get; set; }
        
        [BsonElement("imagen")]
        public string? Imagen { get; set; }
    }
}