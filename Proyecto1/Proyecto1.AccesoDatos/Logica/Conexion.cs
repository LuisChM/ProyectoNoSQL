using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.AccesoDatos
{
    public class Conexion
    {
        public IMongoDatabase ConectarDB()
        {
            var client = new MongoClient("mongodb+srv://rwuser:12345@cluster0-u0ahm.gcp.mongodb.net/Proyecto1?retryWrites=true&w=majority");
            var database = client.GetDatabase("Proyecto1");
            return database;
        }

        public IAsyncCursor<BsonDocument> ListarTodasLasColeciones(IMongoDatabase laBaseDeDatos)
        {
            var elResultado = laBaseDeDatos.ListCollections();
            return elResultado;
        }
    }
}
