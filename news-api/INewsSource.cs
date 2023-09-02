namespace news_api
{
    public interface INewsSource
    {
        Task<IEnumerable<NewsSnippet>> GetLatestNewsAsync();
        Task<IEnumerable<NewsSnippet>> SearchNewsAsync(string keyword);
        Task<NewsArticle> GetNewsByIdAsync(string newsId);
    }
}
