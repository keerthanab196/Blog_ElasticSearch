
using Nest;

var builder = WebApplication.CreateBuilder(args);

var elasticSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("BlogArticles");
var client = new ElasticClient(elasticSettings);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
