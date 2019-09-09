using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.CustomImageSearch;
using Microsoft.Azure.CognitiveServices.Search.CustomImageSearch.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;
using System.Net.Http;

namespace SearchSDK.Tests
{
    public class CustomImageSearchTests
    {
        private static string SubscriptionKey = "fake";

        [Fact]
        public void CustomImageSearch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CustomImageSearch");
                
                var client = new CustomImageSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());
                var resp = client.CustomInstance.ImageSearchAsync(query: "tom cruise", customConfig: "0").Result;

                Assert.NotNull(resp);
                Assert.NotNull(resp.Value);
                Assert.NotNull(resp.ReadLink);
                Assert.NotNull(resp.Value[0]);

                Assert.NotNull(resp.Value[0].Thumbnail);
                Assert.NotNull(resp.Value[0].ThumbnailUrl);
                Assert.NotNull(resp.Value[0].ContentUrl);
            }
        }
    }
}
