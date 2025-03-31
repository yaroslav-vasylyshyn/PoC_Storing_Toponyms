using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Toponym
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Oblast { get; set; }
        public string? AdminRegionOld { get; set; }
        public string? AdminRegionNew { get; set; }
        public string? Gromada { get; set; }
        public string? Community { get; set; }
        public string? StreetName { get; set; }
        public string? StreetType { get; set; }
        public Coordinate? Coordinate { get; set; }
    }

    public class Coordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }