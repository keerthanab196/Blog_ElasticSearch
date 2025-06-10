using Blog_ElasticSearch.Api.DTOs;
using Blog_ElasticSearch.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Blog_ElasticSearch.Api.Extensions
{
    public static class ArticleMapping
    {
        public static ArticleResponseDTO MapToArticleResponseDTO(this Article a) => new()
        {
            Title = a.Title,
            Content = a.Content,
            PublishedDate = a.PublishedDate,
            Author=a.Author
        };
    }
}
