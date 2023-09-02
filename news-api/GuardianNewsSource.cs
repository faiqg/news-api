using System.Net.Http;

namespace news_api
{
    public class GuardianNewsSource : INewsSource
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUri;
        public GuardianNewsSource(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["APIKey"];
            _apiUri = configuration["APIUri"];
        }

        public async Task<IEnumerable<NewsSnippet>> GetLatestNewsAsync()
        {
            string apiUrl = $"{_apiUri}/search?api-key={_apiKey}&order-by=newest";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();

                var newsSnippets = DeserializeNewsSnippets(jsonContent);
                return newsSnippets;
            }
            else
            {
                throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
            }
        }

        private IEnumerable<NewsSnippet> DeserializeNewsSnippets(string jsonContent)
        {
            throw new NotImplementedException();
        }

        public Task<NewsArticle> GetNewsByIdAsync(string newsId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NewsSnippet>> SearchNewsAsync(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
