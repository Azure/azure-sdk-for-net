namespace LUIS.Runtime.Tests
{
    using System.Collections.Generic;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
    using Microsoft.Rest;
    using Xunit;

    public class PredictionTests : BaseTest
    {
        [Fact]
        public void Prediction_Post()
        {
            UseClientFor(async client =>
            {
                var utterance = "this is a test with post";
                var result = await client.Prediction.ResolveAsync(appId, utterance);

                Assert.Equal("None", result.TopScoringIntent.Intent);
                Assert.Equal(utterance, result.Query);
            });
        }

        [Fact]
        public void Prediction_WithSpellCheck()
        {
            UseClientFor(async client =>
            {
                var utterance = "helo, what dai is todey?";
                var result = await client.Prediction.ResolveAsync(appId, utterance, spellCheck: true, bingSpellCheckSubscriptionKey: "00000000000000000000000000000000");

                Assert.True(!string.IsNullOrWhiteSpace(result.AlteredQuery));
                Assert.Equal("hello, what day is today?", result.AlteredQuery);
                Assert.Equal(utterance, result.Query);
            });
        }

        [Fact]
        public void Prediction_InvalidKey_ThrowsAPIErrorException()
        {
            var headers = new Dictionary<string, List<string>> { ["Ocp-Apim-Subscription-Key"] = new List<string> { "invalid-key" } };

            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<APIErrorException>(async () =>
                {
                    await client.Prediction.ResolveWithHttpMessagesAsync(appId, "this is a test with post", customHeaders: headers);
                });

                Assert.Equal("401", ex.Body.StatusCode);
            });
        }

        [Fact]
        public void Prediction_QueryTooLong_ThrowsValidationException()
        {
            UseClientFor(async client =>
            {
                var query = string.Empty.PadLeft(501, 'x');
                var ex = await Assert.ThrowsAsync<ValidationException>(async () =>
                {
                    await client.Prediction.ResolveWithHttpMessagesAsync(appId, query);
                });

                Assert.Equal("query", ex.Target);
            });
        }
    }
}
