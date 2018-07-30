using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Search.AutoSuggest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Reflection;
using Xunit;

namespace SearchSDK.Tests
{
    public class AutoSuggestTests
    {
        private static string SubscriptionKey = "fake";

        [Fact]
        public void AutoSuggest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "AutoSuggest");

                var client = new AutoSuggestSearchAPI(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());
                var resp = client.AutoSuggestMethod(query: "tom cruise", market: "en-us");

                Assert.NotNull(resp);
                Assert.NotNull(resp.QueryContext);
                Assert.NotNull(resp.SuggestionGroups);
                Assert.NotNull(resp.SuggestionGroups[0]);
                var suggestions = resp.SuggestionGroups[0].SearchSuggestions;
                Assert.NotNull(suggestions);
                Assert.True(suggestions.Count == 8);
                foreach (var suggestion in suggestions)
                {
                    Assert.NotNull(suggestion);
                    Assert.NotEmpty(suggestion.Url);
                    Assert.NotEmpty(suggestion.DisplayText);
                    Assert.NotEmpty(suggestion.SearchKind);
                    Assert.NotEmpty(suggestion.Query);
                }
            }
        }
    }
}
