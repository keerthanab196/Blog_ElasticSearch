using Blog_ElasticSearch.Domain.Entities;
using Blog_ElasticSearch.Infrastructure.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_ElasticSearch.Infrastructure.Services
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly IElasticClient _elasticClient;
        public ArticleRepository(IElasticClient client) 
        {
            _elasticClient = client;
        }
        public async Task IndexAsync(Article article)
        {
            await _elasticClient.IndexDocumentAsync(article);
        }

        public async Task<List<Article>> SearchAsync(string query)
        {
            var result = await _elasticClient.SearchAsync<Article>(s => s.
            Query(q => q
            .MultiMatch(m => m
            .Fields(f => f
                    .Field(f1 => f1.Title)
                    .Field(f2 => f2.Content)
                    .Field(f3 => f3.Author)
                    )
            .Query(query)
            )
           )
          );

            return result.Documents.ToList();
        }

    }
}
