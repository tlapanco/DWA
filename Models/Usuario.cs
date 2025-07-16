using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoMongoDB.Models;
public class Usuario
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]    
    public required string  ID { get; set; }
    [BsonElement("contrasena")]
    public string Contrasena { get; set; } = string.Empty;
    [BsonElement("idUsuario")]
    public string IdUsuario { get; set; } = string.Empty;
    [BsonElement("nombre")]
    public string Nombre { get; set; } = string.Empty;
}
