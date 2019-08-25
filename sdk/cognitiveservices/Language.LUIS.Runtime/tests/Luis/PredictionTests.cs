namespace LUIS.Runtime.Tests
{
    using System;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
    using Microsoft.Rest;
    using Newtonsoft.Json.Linq;
    using Xunit;

    public class PredictionTests : BaseTest
    {
        [Fact]
        public void Prediction_Slot()
        {
            UseClientFor(async client =>
            {
                Prediction prediction = new Prediction((LUISRuntimeClient)client);
                string utterance = "today this is a test with post";
                double timezoneOffset = -360;
                bool verbose = true;
                bool isStaging = false;

                LuisResult luisResult = await PredictionExtensions.ResolveAsync(
                    prediction,
                    Guid.Parse(appId),
                    utterance,
                    timezoneOffset,
                    verbose,
                    isStaging);

                Assert.Equal(utterance, luisResult.Query);
                Assert.Equal("intent", luisResult.TopScoringIntent.Intent);
                Assert.Equal(2, luisResult.Intents.Count);
                Assert.Equal(2, luisResult.Entities.Count);
                Assert.Equal("simple", luisResult.Entities.ToArray()[0].Type);
                Assert.Equal("builtin.datetimeV2.date", luisResult.Entities.ToArray()[1].Type);

                var topIntent = luisResult.TopScoringIntent;
                Assert.True(topIntent.Score > 0.5);

                Assert.Equal("positive", luisResult.SentimentAnalysis.Label);
                Assert.True(luisResult.SentimentAnalysis.Score > 0.5);
            });
        }

        [Fact]
        public void Prediction_AppNotFound_ThrowsAPIErrorException()
        {
            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<APIErrorException>(async () =>
                {
                    Prediction prediction = new Prediction((LUISRuntimeClient)client);
                    var luisResult = await PredictionExtensions.ResolveAsync(
                        prediction,
                        Guid.Parse("7555b7c1-e69c-4580-9d95-1abd6dfa8291"),
                        "this is a test with post");
                });

                Assert.Equal("Operation returned an invalid status code 'Gone'", ex.Message);
            });
        }

        [Fact]
        public void Prediction_NullQuery_ThrowsValidationException()
        {
            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<ValidationException>(async () =>
                {
                    Prediction prediction = new Prediction((LUISRuntimeClient)client);
                    var luisResult = await PredictionExtensions.ResolveAsync(
                        prediction,
                        Guid.Parse(appId),
                        null);
                });

                Assert.Equal("query", ex.Target);
            });
        }
    }
}
