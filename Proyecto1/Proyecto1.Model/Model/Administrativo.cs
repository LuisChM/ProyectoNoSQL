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
    public class Administrativo
    {
        [BsonId]
        public ObjectId AdminId { get; set; }
        [BsonElement("institution")]
        public string institution { get; set; }

        [BsonElement("information")]
        public Information information { get; set; }
        [BsonElement("lenguages")]
        public string[] lenguages { get; set; }

        [BsonElement("profession")]
        public string profession { get; set; }

        [BsonElement("age")]
        public int age { get; set; }

        [BsonElement("roles")]
        public string[] roles { get; set; }

        [BsonExtraElements]
        public BsonDocument Metadata { get; set; }


    }
}
