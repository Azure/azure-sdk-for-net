using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using Microsoft.Azure.CognitiveServices.Search.WebSearch.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace SearchSDK.Tests
{
    public class WebSearchTests
    {
        private static string SubscriptionKey = "fake";

        [Fact]
        public void WebSearch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "WebSearch");

                IWebSearchClient client = new WebSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.Web.SearchAsync(query: "tom cruise").Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.WebPages);
                Assert.NotNull(resp.WebPages.WebSearchUrl);

                Assert.NotNull(resp.WebPages.Value);
                Assert.NotNull(resp.WebPages.Value[0].DisplayUrl);

                Assert.NotNull(resp.Images);
                Assert.NotNull(resp.Images.Value);
                Assert.NotNull(resp.Images.Value[0].HostPageUrl);
                Assert.NotNull(resp.Images.Value[0].WebSearchUrl);
                Assert.NotNull(resp.Videos);
                Assert.NotNull(resp.News);
            }
        }
    }
}
