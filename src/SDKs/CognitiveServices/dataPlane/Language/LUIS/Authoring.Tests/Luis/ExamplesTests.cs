namespace LUIS.Authoring.Tests.Luis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
    using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
    using Xunit;

    public class ExamplesTests : BaseTest
    {
        private const string versionId = "0.1";
        
        [Fact]
        public void ListExamples()
        {
            UseClientFor(async client =>
            {
                var examples = await client.Examples.ListAsync(appId, versionId);

                Assert.NotEmpty(examples);
            });
        }

        [Fact]
        public void ListExamples_ForEmptyApplication_ReturnsEmpty()
        {
            UseClientFor(async client =>
            {
                var appId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "Examples Test App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                var examples = await client.Examples.ListAsync(appId, versionId);

                await client.Apps.DeleteAsync(appId);

                Assert.Empty(examples);
            });
        }

        [Fact]
        public void AddExample()
        {
            UseClientFor(async client =>
            {
                var appId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "Examples Test App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Model.AddIntentAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "WeatherInPlace"
                });

                await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "Place"
                });

                var example = new ExampleLabelObject
                {
                    Text = "whats the weather in buenos aires?",
                    IntentName = "WeatherInPlace",
                    EntityLabels = new List<EntityLabelObject>()
                    {
                        new EntityLabelObject()
                        {
                            EntityName = "Place",
                            StartCharIndex = 21,
                            EndCharIndex = 34
                        }
                    }
                };

                var result = await client.Examples.AddAsync(appId, versionId, example);

                await client.Apps.DeleteAsync(appId);

                Assert.Equal(example.Text, result.UtteranceText);
            });
        }

        [Fact]
        public void AddExamplesInBatch()
        {
            UseClientFor(async client =>
            {
                var appId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "Examples Test App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Model.AddIntentAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "WeatherInPlace"
                });

                await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "Place"
                });

                var examples = new List<ExampleLabelObject>() {
                    new ExampleLabelObject
                    {
                        Text = "whats the weather in seattle?",
                        IntentName = "WeatherInPlace",
                        EntityLabels = new List<EntityLabelObject>()
                        {
                            new EntityLabelObject()
                            {
                                EntityName = "Place",
                                StartCharIndex = 21,
                                EndCharIndex = 29
                            }
                        }
                    },
                    new ExampleLabelObject
                    {
                        Text = "whats the weather in buenos aires?",
                        IntentName = "WeatherInPlace",
                        EntityLabels = new List<EntityLabelObject>()
                        {
                            new EntityLabelObject()
                            {
                                EntityName = "Place",
                                StartCharIndex = 21,
                                EndCharIndex = 34
                            }
                        }
                    },
                };

                var result = await client.Examples.BatchAsync(appId, versionId, examples);

                await client.Apps.DeleteAsync(appId);

                Assert.Equal(examples.Count, result.Count);
                Assert.DoesNotContain(result, o => o.HasError.GetValueOrDefault());
                Assert.Contains(result, o => examples.Any(e => e.Text.Equals(o.Value.UtteranceText, StringComparison.OrdinalIgnoreCase)));
            });
        }

        [Fact]
        public void AddExamplesInBatch_SomeInvalidExamples_ReturnsSomeErrors()
        {
            UseClientFor(async client =>
            {
                var appId = await client.Apps.AddAsync(new ApplicationCreateObject
                {
                    Name = "Examples Test App",
                    Description = "New LUIS App",
                    Culture = "en-us",
                    Domain = "Comics",
                    UsageScenario = "IoT"
                });

                await client.Model.AddIntentAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "WeatherInPlace"
                });

                await client.Model.AddEntityAsync(appId, "0.1", new ModelCreateObject
                {
                    Name = "Place"
                });

                var examples = new List<ExampleLabelObject>() {
                    new ExampleLabelObject
                    {
                        Text = "whats the weather in seattle?",
                        IntentName = "InvalidIntent",
                        EntityLabels = new List<EntityLabelObject>()
                        {
                            new EntityLabelObject()
                            {
                                EntityName = "Place",
                                StartCharIndex = 21,
                                EndCharIndex = 29
                            }
                        }
                    },
                    new ExampleLabelObject
                    {
                        Text = "whats the weather in buenos aires?",
                        IntentName = "IntentDoesNotExist",
                        EntityLabels = new List<EntityLabelObject>()
                        {
                            new EntityLabelObject()
                            {
                                EntityName = "Place",
                                StartCharIndex = 21,
                                EndCharIndex = 34
                            }
                        }
                    },
                };

                var result = await client.Examples.BatchAsync(appId, versionId, examples);

                await client.Apps.DeleteAsync(appId);

                Assert.Equal(examples.Count, result.Count);
                Assert.Contains(result, o => o.HasError.GetValueOrDefault());
                Assert.Contains(result, o => o.HasError.GetValueOrDefault() && o.Error != null && o.Error.Code == "FAILED" && o.Error.Message.Contains("The intent classifier IntentDoesNotExist"));
            });
        }

        [Fact]
        public void DeleteExample()
        {
            UseClientFor(async client =>
            {
                var exampleId = -5313926;
                await client.Examples.DeleteAsync(appId, versionId, exampleId);
                var examples = await client.Examples.ListAsync(appId, versionId);

                Assert.DoesNotContain(examples, o => o.Id == exampleId);
            });
        }
    }
}
