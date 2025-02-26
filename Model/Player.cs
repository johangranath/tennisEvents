using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

// Player Collection
public class Player
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}

// Match Collection
public class Match
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string SeasonId { get; set; } = string.Empty;
    public string DivisionId { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public List<string> Team1 { get; set; } = new List<string>(); // Two player IDs
    public List<string> Team2 { get; set; } = new List<string>(); // Two player IDs
    public MatchResult? Result { get; set; }
}

// Match Result
public class MatchResult
{
    public int Set1Team1 { get; set; }
    public int Set1Team2 { get; set; }
    public int Set2Team1 { get; set; }
    public int Set2Team2 { get; set; }
    public int Set3Team1 { get; set; }
    public int Set3Team2 { get; set; }
}

// Season Collection
public class Season
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<string> DivisionIds { get; set; } = new List<string>();
}

// Division Collection
public class Division
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string SeasonId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<string> PlayerIds { get; set; } = new List<string>();
    public List<string> MatchIds { get; set; } = new List<string>();
}
