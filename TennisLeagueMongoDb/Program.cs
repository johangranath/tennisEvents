using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container
builder.Services.AddSingleton<MongoDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/health", () => Results.Json(new { status = "ok" }));

app.MapGet("/test-mongo", async (MongoDbContext dbContext) =>
{
    var collection = dbContext.GetCollection<BsonDocument>("TestCollection");

    // Insert a dummy document
    var document = new BsonDocument { { "Name", "Test Document" } };
    await collection.InsertOneAsync(document);

    // Retrieve the dummy document
    var result = await collection.Find(new BsonDocument { { "Name", "Test Document" } }).FirstOrDefaultAsync();

    return result.ToString();
});

app.Run();
