using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Proyecto1.Model
{
     public class Profesores
    {

        [BsonIgnoreExtraElements]
        public class Alumnos
        {
            [BsonId]
            public ObjectId _Id { get; set; }


            [BsonElement("id")]
            public int id { get; set; }



            [BsonElement("teacher")]
            public string teacher { get; set; }



            [BsonElement("email")]
            public string email { get; set; }



            [BsonElement("country")]
            public string country { get; set; }



            [BsonElement("work")]
            public string work { get; set; }



            [BsonElement("phone_number")]
            public string phone_number { get; set; }



            [BsonElement("Languages")]
            public string[] Languages { get; set; }



            [BsonExtraElements]
            public BsonDocument Metadata { get; set; }


        }

    }
}
