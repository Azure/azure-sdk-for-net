using Microsoft.Azure.CognitiveServices.Language.LUIS;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.LUIS.Tests.Luis
{
    public class PredictionTests: BaseTest
    {
        [Fact]
        public void PredictionGet()
        {
            UseClientFor(async client => {
                var utterance = "this is a test";
                var result = await client.Prediction.GetPredictionsFromEndpointViaGetAsync(region, appId, utterance);

                Assert.Equal("None", result.TopScoringIntent.Intent);
                Assert.Equal(utterance, result.Query);
            });
        }

        [Fact]
        public void PredictionInvalidKey()
        {
            var headers = new Dictionary<string, List<string>> { ["Ocp-Apim-Subscription-Key"] = new List<string> { "invalid-key" } };

            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<APIErrorException>(async () => {
                    await client.Prediction.GetPredictionsFromEndpointViaGetWithHttpMessagesAsync(region, appId, "test", customHeaders: headers);
                });

                Assert.Equal("401", ex.Body.StatusCode);
            });
        }

        [Fact]
        public void PredictionPost()
        {
            UseClientFor(async client => {
                var utterance = "this is a test with post";
                var result = await client.Prediction.GetPredictionsFromEndpointViaPostAsync(region, appId, utterance);

                Assert.Equal("None", result.TopScoringIntent.Intent);
                Assert.Equal(utterance, result.Query);
            });
        }
    }
}
