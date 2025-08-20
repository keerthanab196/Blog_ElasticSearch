
using Blog_ElasticSearch.Infrastructure.Interfaces;
using Blog_ElasticSearch.Infrastructure.Services;
using Blog_ElasticSearch.Application.Interfaces;
using Blog_ElasticSearch.Application.Services;
using Nest;
using Blog_ElasticSearch.Domain.Entities;
using Blog_ElasticSearch.Api.DTOs;
using Blog_ElasticSearch.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var elasticSettings = new ConnectionSettings(new Uri("http://localhost:9200"))
    .DefaultIndex("blogarticles");
var client = new ElasticClient(elasticSettings);

builder.Services.AddSingleton<IElasticClient>(client);
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapPost("/articlesUpload", async (ArticleCreateDTO articleDto, IArticleService service) =>
{
    var article = new Article
    {
        Id = Guid.NewGuid().ToString(),
        Title = articleDto.Title,
        Content = articleDto.Content,
        Author = articleDto.Author,
        PublishedDate = DateTime.UtcNow
    };
    await service.ArticleIndexingAsync(article);
    return Results.Created($"/articlesUpload/{article.Id}", article);
}
);

app.MapGet("/articles/search", async (string q, IArticleService service) =>
{
    var results = await service.SearchForArticlesAsync(q);
    var response = results.Select(a => a.MapToArticleResponseDTO());
    return Results.Ok(response);
});

app.MapGet("/articles/searchAnArticle", async (string q, IArticleService service) =>
{
    var results = await service.SearchForArticlesAsync(q);
    var response = results.Select(a => a.MapToArticleResponseDTO());
    return Results.Ok(response);
});

app.Run();
