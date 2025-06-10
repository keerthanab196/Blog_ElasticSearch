namespace Blog_ElasticSearch.Api.DTOs
{
    public class ArticleResponseDTO
    {
        public string? Title { get; set; } 
        public string? Content { get; set; } 
        public DateTime? PublishedDate { get; set; }
        public string? Author { get; set; }
    }
}
