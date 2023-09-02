using Microsoft.AspNetCore.Mvc;
using Moq;
using news_api;
using news_api.Controllers;

namespace news_api_tests
{
    public class NewsControllerTests
    {
        [Fact]
        public async Task GetLatestNews_ReturnsOkResult()
        {

            var newsSourceMock = new Mock<INewsSource>();
            var controller = new NewsController(newsSourceMock.Object);
            var newsSnippet = new List<NewsSnippet>
            {
                new NewsSnippet { Title = "News 1" },
                new NewsSnippet { Title = "News 2" },
            };
            newsSourceMock
                .Setup(source => source.GetLatestNewsAsync()).ReturnsAsync(newsSnippet);

            // Act
            var result = await controller.GetLatestNews() as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var model = result.Value as IEnumerable<NewsSnippet>;
            Assert.NotNull(model);
            Assert.Equal(newsSnippet, model);
        }
    }
}