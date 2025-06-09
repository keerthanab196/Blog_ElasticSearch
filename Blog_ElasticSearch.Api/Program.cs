
using Blog_ElasticSearch.Infrastructure.Interfaces;
using Blog_ElasticSearch.Infrastructure.Services;
using Blog_ElasticSearch.Application.Interfaces;
using Blog_ElasticSearch.Application.Services;
using Nest;


var builder = WebApplication.CreateBuilder(args);

var elasticSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("BlogArticles");
var client = new ElasticClient(elasticSettings);

builder.Services.AddSingleton<IElasticClient>(client);
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
