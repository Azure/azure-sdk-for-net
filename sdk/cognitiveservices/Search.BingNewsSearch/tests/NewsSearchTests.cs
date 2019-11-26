using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch;
using Microsoft.Azure.CognitiveServices.Search.NewsSearch.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace SearchSDK.Tests
{
    public class NewsSearchTests
    {
        private static string SubscriptionKey = "fake";

        [Fact]
        public void NewsSearch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "NewsSearch");

                INewsSearchClient client = new NewsSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.News.SearchAsync(query: "tom cruise").Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.Value);
                Assert.True(resp.Value.Count > 0);

                var news = resp.Value[0];
                Assert.NotNull(news.Name);
                Assert.NotNull(news.Url);
                Assert.NotNull(news.Description);
                Assert.NotNull(news.DatePublished);
                Assert.NotNull(news.Provider);
                Assert.NotNull(news.Provider[0].Name);
            }
        }

        [Fact]
        public void NewsCategory()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "NewsCategory");

                INewsSearchClient client = new NewsSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.News.CategoryAsync(category: "sports").Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.Value);
                Assert.True(resp.Value.Count > 0);

                var news = resp.Value[0];
                Assert.NotNull(news.Name);
                Assert.NotNull(news.Url);
                Assert.NotNull(news.Description);
                Assert.NotNull(news.DatePublished);
                Assert.NotNull(news.Provider);
                Assert.NotNull(news.Category);
                Assert.NotNull(news.Provider[0].Name);
            }
        }

        [Fact]
        public void NewsTrending()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "NewsTrending");

                INewsSearchClient client = new NewsSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.News.TrendingAsync().Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.Value);
                Assert.True(resp.Value.Count > 0);

                var trendingTopic = resp.Value[0];
                Assert.NotNull(trendingTopic.Name);
                Assert.NotNull(trendingTopic.WebSearchUrl);
                Assert.NotNull(trendingTopic.NewsSearchUrl);
                Assert.NotNull(trendingTopic.Image);
                Assert.NotNull(trendingTopic.Image.Url);
                Assert.NotNull(trendingTopic.Query);
                Assert.NotNull(trendingTopic.Query.Text);
            }
        }
    }
}
