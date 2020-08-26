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
    public class Contacto
    {

        [BsonElement("email")]
        public string email { get; set; }

        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }
    }
}
