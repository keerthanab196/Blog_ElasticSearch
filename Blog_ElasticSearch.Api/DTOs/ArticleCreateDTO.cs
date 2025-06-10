using System.ComponentModel.DataAnnotations;

namespace Blog_ElasticSearch.Api.DTOs
{
    public class ArticleCreateDTO
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
    }
}
