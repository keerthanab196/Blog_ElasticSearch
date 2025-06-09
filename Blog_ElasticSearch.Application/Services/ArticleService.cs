using Blog_ElasticSearch.Application.Interfaces;
using Blog_ElasticSearch.Domain.Entities;
using Blog_ElasticSearch.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_ElasticSearch.Application.Services
{
    public class ArticleService: IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository) {
            _articleRepository = articleRepository;
        }

        public Task ArticleIndexingAsync(Article article)
        {
           return _articleRepository.IndexAsync(article);
        }
        public Task<List<Article>> SearchForArticlesAsync(string query)
        {
            return _articleRepository.SearchAsync(query);
        }
    }
}
