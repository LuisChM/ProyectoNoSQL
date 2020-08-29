using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Model
{
    [BsonIgnoreExtraElements]
    public class Alumnos
    {
        [BsonId]
        public ObjectId _Id { get; set; }



        [BsonElement("id")]
        public int id { get; set; }



        [BsonElement("first_name")]
        public string first_name { get; set; }



        [BsonElement("last_name")]
        public string last_name { get; set; }



        [BsonElement("email")]
        public string email { get; set; }



        [BsonElement("birth")]
        public string birth { get; set; }

        [BsonElement("Cursos")]
        public string[] cursos { get; set; }



        [BsonElement("country")]
        public string country { get; set; }



        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }




    }
}