using System.Text.Json;
using System.Text.Json.Nodes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Description = "Mock api configured by api-schema.json file",
        Title = "Mock Api",
        Version = "v1"
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

const string SchemaFile = "api-schema.json";

var schema = await ReadJsonApiSchema(SchemaFile);
if (schema == null)
{
    Console.WriteLine("Unable to read schema from {0}", SchemaFile);
    return;
}

foreach (var (path, httpMethod, name) in GetAllEndPointsQuery(schema))
{
    app.MapMethods(path, new[] { httpMethod.Key }, (ILogger<Program> logger) =>
    {
        logger.LogInformation("Endpoint Name: {name}", name);
        return httpMethod.Value;
    }).WithName(name);
}

await app.RunAsync();


async Task<Dictionary<string, Dictionary<string, JsonNode>>?> ReadJsonApiSchema(string filePath) =>
    await JsonSerializer.DeserializeAsync<Dictionary<string, Dictionary<string, JsonNode>>>(File.OpenRead(filePath));

IEnumerable<(string, KeyValuePair<string, JsonNode>, string)> GetAllEndPointsQuery(Dictionary<string, Dictionary<string, JsonNode>> apiSchema) =>
    from path in apiSchema.Keys
    from httpMethod in apiSchema[path]
    let name = $"{httpMethod.Key} {path}"
    select (path, httpMethod, name);