
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication8
{




    public class movielist
    {
        public List<movie> results { get; set; } = new List<movie>();

    }


    public class movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Int32 id { get; set; }
        [BsonElement]
        public string title { get; set; } = string.Empty;

        [BsonElement]
        public string release_date { get; set; } = string.Empty;
        [BsonElement]
        public double vote_average { get; set; }
        [BsonElement]
        public string poster_path { get; set; } = string.Empty;

    }

    public class tvshow
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int id { get; set; }
        [BsonElement]
        public string name { get; set; } = string.Empty;
        [BsonElement]
        public double vote_average { get; set; }
        [BsonElement]
        public string? poster_path { get; set; } = string.Empty;



    }

}