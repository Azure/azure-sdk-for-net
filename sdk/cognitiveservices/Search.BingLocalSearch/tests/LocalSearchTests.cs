using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.LocalSearch;
using Microsoft.Azure.CognitiveServices.Search.LocalSearch.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace SearchSDK.Tests
{
    public class LocalSearchTests
    {
        private static string SubscriptionKey = "fake";

        // [Fact]
        public void LocalSearch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "LocalSearch");

                ILocalSearchClient client = new LocalSearchClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.Local.Search(query: "restaurants");

                Assert.NotNull(resp);
                Assert.NotNull(resp.QueryContext);
                Assert.NotNull(resp.Places);
                Assert.NotNull(resp.Places.Value);
            }
        }
    }
}

