using Blog_ElasticSearch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_ElasticSearch.Application.Interfaces
{
    internal interface IArticleService
    {
        Task ArticleIndexingAsync(Article article);
        Task<List<Article>> SearchForArticlesAsync(string query);
    }
}
