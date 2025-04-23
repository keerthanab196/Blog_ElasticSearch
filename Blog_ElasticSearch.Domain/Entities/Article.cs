namespace Blog_ElasticSearch.Domain.Entities
{
    public class Article
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; }=string.Empty;
        public DateTime PublishedDate { get; set; }=DateTime.Now;
        public string Author { get; set; } = string.Empty;
    }
}
