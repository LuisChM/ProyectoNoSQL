using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Proyecto1.Model;

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

        public void InsertarAdministrativo(Administrativos losAdministrativos)
        {
            var laBaseDeDatos = ConectarDB();
            var collection = laBaseDeDatos.GetCollection<Administrativos>("Administrativos");
            collection.InsertOne(losAdministrativos);
        }

        public IList<Administrativos> ListarAdministrativosPorNombre(string elNombreDelAdministrativos)
        {
            var laBaseDeDatos = ConectarDB();
            var collection = laBaseDeDatos.GetCollection<Administrativos>("Administrativos");
            var expresssionFilter = Builders<Administrativos>.Filter.Regex(x => x.information.name, elNombreDelAdministrativos);
            var elResultado = collection.Find(expresssionFilter).ToList();
            return elResultado;
        }
        public void ActualizarCityAdministrativo(ObjectId AdminId, string laNuevaCiudad)
        {
            var laBaseDeDatos = ConectarDB();
            var collection = laBaseDeDatos.GetCollection<Administrativos>("Administrativos");
            var filter = Builders<Administrativos>.Filter.Eq("_id", AdminId);
            var update = Builders<Administrativos>.Update.Set("information.city", laNuevaCiudad);
            collection.UpdateOne(filter, update);
        }

        
    }
}
