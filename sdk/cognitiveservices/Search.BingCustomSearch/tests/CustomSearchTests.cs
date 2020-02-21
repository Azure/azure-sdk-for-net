using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.CustomSearch;
using Microsoft.Azure.CognitiveServices.Search.CustomSearch.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;
using System.Net.Http;

namespace SearchSDK.Tests
{
    public class CustomSearchTests
    {
        private static string SubscriptionKey = "fake";

        [Fact]
        public void CustomSearch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CustomSearch");
                
                ICustomSearchClient client = new CustomSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());
                var resp = client.CustomInstance.SearchAsync(query: "tom cruise", customConfig: "0").Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.WebPages);
                Assert.NotNull(resp.WebPages.WebSearchUrl);

                Assert.NotNull(resp.WebPages.Value);
                Assert.NotNull(resp.WebPages.Value[0].DisplayUrl);
            }
        }
    }
}
