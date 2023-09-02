using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace news_api.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsSource _newsSource;

        public NewsController(INewsSource newsSource)
        {
            _newsSource = newsSource;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestNews()
        {
            var latestNews = await _newsSource.GetLatestNewsAsync();
            return Ok(latestNews);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchNews([FromQuery] string keyword)
        {
            var newsResults = await _newsSource.SearchNewsAsync(keyword);
            return Ok(newsResults);
        }

        [HttpGet("{newsId}")]
        public async Task<IActionResult> GetNewsById(string newsId)
        {
            var newsArticle = await _newsSource.GetNewsByIdAsync(newsId);
            if (newsArticle == null)
            {
                return NotFound();
            }
            return Ok(newsArticle);
        }
    }
}
