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
    public class Information
    {
        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("city")]
        public string city { get; set; }

        [BsonElement("contacto")]
        public Contacto contacto { get; set; }

        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }
    }
}
