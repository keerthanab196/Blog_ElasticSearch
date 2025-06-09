using Blog_ElasticSearch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_ElasticSearch.Infrastructure.Interfaces
{
    public interface IArticleRepository
    {
        Task IndexAsync(Article article);
        Task<List<Article>> SearchAsync(string query);
    }
}
