using MongoDB.Driver;
using ProyectoMongoDB.Models;

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

        public async Task<Usuario> ValidarCredencialesUsuario (string idUsuario, string contrasena)
        {
            var usuariosColeccion = db.GetCollection<Usuario>("usuarios");

            return await usuariosColeccion.Find(
                usuario => usuario.IdUsuario == idUsuario && usuario.Contrasena == contrasena
            ).FirstOrDefaultAsync();

        }
    }
}