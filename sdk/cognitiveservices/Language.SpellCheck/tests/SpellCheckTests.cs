using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Language.SpellCheck;
using Microsoft.Azure.CognitiveServices.Language.SpellCheck.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace SpellCheckSDK.Tests
{
    public class SpellCheckTests
    {
        private static string SubscriptionKey = "fake";

        [Fact]
        public void SpellCheck()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "SpellCheck");

                ISpellCheckClient client = new SpellCheckClient(new ApiKeyServiceClientCredentials(SubscriptionKey), HttpMockServer.CreateInstance());

                var resp = client.SpellCheckerAsync(text: "Bill Gatas").Result;
                Assert.NotNull(resp);
                Assert.NotNull(resp.FlaggedTokens);
                Assert.Equal(1, resp.FlaggedTokens.Count);

                // verify token
                var flaggedToken = resp.FlaggedTokens.First();
                Assert.NotNull(flaggedToken);
                Assert.NotNull(flaggedToken.Token);
                Assert.Equal("Gatas", flaggedToken.Token);
                Assert.Equal("UnknownToken", flaggedToken.Type);

                // verify suggestions
                Assert.Equal(1, flaggedToken.Suggestions.Count);

                var suggestion = flaggedToken.Suggestions.First();
                Assert.NotNull(suggestion);
                Assert.Equal(0.887992481895458, suggestion.Score);
                Assert.Equal("Gates", suggestion.Suggestion);
            }
        }
    }
}
