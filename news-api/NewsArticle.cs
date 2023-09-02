namespace news_api
{
    public class NewsArticle
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ContentHtml { get; set; }
        public string? ImageUrl { get; set; }
    }
}
