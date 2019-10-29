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
                var utterance = "today this is a test with post";
                var slotName = "production";

                var requestOptions = new PredictionRequestOptions
                {
                    DatetimeReference = DateTime.Parse("2019-01-01"),
                    PreferExternalEntities = true
                };

                var externalResolution = JObject.FromObject(new { text = "post", external = true });
                var externalEntities = new[]
                {
                    new ExternalEntity
                    {
                        EntityName = "simple",
                        StartIndex = 26,
                        EntityLength = 4,
                        Resolution = externalResolution,
                        Score = 0.86
                    }
                };

                var dynamicLists = new[]
                {
                    new DynamicList
                    {
                        ListEntityName = "list",
                        RequestLists = new[]
                        {
                            new RequestList
                            {
                                Name = "test",
                                CanonicalForm = "testing",
                                Synonyms = new[] { "this" }
                            }
                        }
                    }
                };

                var predictionRequest = new PredictionRequest
                {
                    Query = utterance,
                    Options = requestOptions,
                    ExternalEntities = externalEntities,
                    DynamicLists = dynamicLists 
                };

                var result = await client.Prediction.GetSlotPredictionAsync(
                    Guid.Parse(appId),
                    slotName,
                    predictionRequest,
                    verbose: true,
                    showAllIntents: true);

                var prediction = result.Prediction;
                Assert.Equal(utterance, result.Query);
                Assert.Equal("intent", prediction.TopIntent);
                Assert.Equal(2, prediction.Intents.Count);
                Assert.Equal(4, prediction.Entities.Count);
                Assert.Contains("datetimeV2", prediction.Entities.Keys);
                Assert.Contains("simple", prediction.Entities.Keys);
                Assert.Contains("list", prediction.Entities.Keys);
                Assert.Contains("$instance", prediction.Entities.Keys);

                // Test external resolution
                var actualResolution = (prediction.Entities["simple"] as JArray).Single();
                Assert.True(JToken.DeepEquals(externalResolution, actualResolution));

                var topIntent = prediction.Intents[prediction.TopIntent];
                Assert.True(topIntent.Score > 0.5);

                Assert.Equal("positive", prediction.Sentiment.Label);
                Assert.True(prediction.Sentiment.Score > 0.5);

                // dispatch
                var child = topIntent.ChildApp;
                Assert.Equal("None", child.TopIntent);
                Assert.Equal(1, child.Intents.Count);
                Assert.Equal(2, child.Entities.Count);
                Assert.Contains("datetimeV2", child.Entities.Keys);
                Assert.Contains("$instance", child.Entities.Keys);

                var dispatchTopIntent = child.Intents[child.TopIntent];
                Assert.True(dispatchTopIntent.Score > 0.5);

                Assert.Equal("positive", child.Sentiment.Label);
                Assert.True(child.Sentiment.Score > 0.5);
            });
        }

        [Fact]
        public void Prediction_Version()
        {
            UseClientFor(async client =>
            {
                var utterance = "today this is a test with post";
                var versionId = "0.1";

                var requestOptions = new PredictionRequestOptions
                {
                    DatetimeReference = DateTime.Parse("2019-01-01"),
                    PreferExternalEntities = true
                };

                var externalResolution = JObject.FromObject(new { text = "post", external = true });
                var externalEntities = new[]
                {
                    new ExternalEntity
                    {
                        EntityName = "simple",
                        StartIndex = 26,
                        EntityLength = 4,
                        Score = 0.9,
                        Resolution = externalResolution
                    }
                };

                var dynamicLists = new[]
                {
                    new DynamicList
                    {
                        ListEntityName = "list",
                        RequestLists = new[]
                        {
                            new RequestList
                            {
                                Name = "test",
                                CanonicalForm = "testing",
                                Synonyms = new[] { "this" }
                            }
                        }
                    }
                };

                var predictionRequest = new PredictionRequest
                {
                    Query = utterance,
                    Options = requestOptions,
                    ExternalEntities = externalEntities,
                    DynamicLists = dynamicLists
                };

                var result = await client.Prediction.GetVersionPredictionAsync(
                    Guid.Parse(appId),
                    versionId,
                    predictionRequest,
                    verbose: true,
                    showAllIntents: true);

                var prediction = result.Prediction;
                Assert.Equal(utterance, result.Query);
                Assert.Equal("intent", prediction.TopIntent);
                Assert.Equal(2, prediction.Intents.Count);
                Assert.Equal(4, prediction.Entities.Count);
                Assert.Contains("datetimeV2", prediction.Entities.Keys);
                Assert.Contains("simple", prediction.Entities.Keys);
                Assert.Contains("list", prediction.Entities.Keys);
                Assert.Contains("$instance", prediction.Entities.Keys);

                // Test external resolution
                var actualResolution = (prediction.Entities["simple"] as JArray).Single();
                Assert.True(JToken.DeepEquals(externalResolution, actualResolution));

                var topIntent = prediction.Intents[prediction.TopIntent];
                Assert.True(topIntent.Score > 0.5);

                Assert.Equal("positive", prediction.Sentiment.Label);
                Assert.True(prediction.Sentiment.Score > 0.5);

                // dispatch
                var child = topIntent.ChildApp;
                Assert.Equal("None", child.TopIntent);
                Assert.Equal(1, child.Intents.Count);
                Assert.Equal(2, child.Entities.Count);
                Assert.Contains("datetimeV2", child.Entities.Keys);
                Assert.Contains("$instance", child.Entities.Keys);

                var dispatchTopIntent = child.Intents[child.TopIntent];
                Assert.True(dispatchTopIntent.Score > 0.5);

                Assert.Equal("positive", child.Sentiment.Label);
                Assert.True(child.Sentiment.Score > 0.5);
            });
        }

        [Fact]
        public void Prediction_AppNotFound_ThrowsAPIErrorException()
        {
            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<ErrorException>(async () =>
                {
                    await client.Prediction.GetSlotPredictionAsync(
                        Guid.Parse("7555b7c1-e69c-4580-9d95-1abd6dfa8291"),
                        "production",
                        new PredictionRequest
                        {
                            Query = "this is a test with post"
                        });
                });

                Assert.Equal("NotFound", ex.Body.ErrorProperty.Code);
            });
        }

        [Fact]
        public void Prediction_NullQuery_ThrowsValidationException()
        {
            UseClientFor(async client =>
            {
                var ex = await Assert.ThrowsAsync<ValidationException>(async () =>
                {
                    await client.Prediction.GetSlotPredictionAsync(Guid.Parse(appId), "production", new PredictionRequest());
                });

                Assert.Equal("Query", ex.Target);
            });
        }
    }
}
