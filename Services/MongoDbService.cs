using MongoDB.Driver;

namespace ProyectoMongoDB.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase db;

        public MongoDbService (IConfiguration configAppsettings)
        {
            var configMongo = configAppsettings.GetSection("MongoDB");
            var clienteMongo = new MongoClient(configMongo["CadenaDeConexion"]);
            db = clienteMongo.GetDatabase(configMongo["BaseDeDatos"]);
        }

        public IMongoCollection<TipoDocumento> ObtenerColeccion<TipoDocumento> (string nombreColeccion)
        {
            return db.GetCollection<TipoDocumento>(nombreColeccion);
        }
    }
}