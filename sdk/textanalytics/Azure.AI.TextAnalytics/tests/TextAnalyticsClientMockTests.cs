// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public TextAnalyticsClientMockTests(bool isAsync) : base(isAsync)
        {
        }

        private TextAnalyticsClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new TextAnalyticsClientOptions
            {
                Transport = transport
            };

            var client = InstrumentClient(new TextAnalyticsClient(new Uri(s_endpoint), new AzureKeyCredential(s_apiKey), options));

            return client;
        }

        [Test]
        public async Task RecognizeEntitiesResultsSorted_NoErrors()
        {
            var mockResults = new List<RecognizeEntitiesResult>()
            {
                TextAnalyticsModelFactory.RecognizeEntitiesResult("1", new TextDocumentStatistics(),
                    new CategorizedEntityCollection
                    (
                        new List<CategorizedEntity>
                        {
                            new CategorizedEntity("EntityText0", "EntityCategory0", "EntitySubCategory0", 0.5),
                            new CategorizedEntity("EntityText1", "EntityCategory1", "EntitySubCategory1", 0.5),
                        },
                        new List<TextAnalyticsWarning>()
                    )),

                TextAnalyticsModelFactory.RecognizeEntitiesResult("2", new TextDocumentStatistics(),
                    new CategorizedEntityCollection
                    (
                        new List<CategorizedEntity>
                        {
                            new CategorizedEntity("EntityText0", "EntityCategory0", "EntitySubCategory0", 0.5),
                            new CategorizedEntity("EntityText1", "EntityCategory1", "EntitySubCategory1", 0.5),
                        },
                        new List<TextAnalyticsWarning>()
                    )),
            };
            var mockResultCollection = new RecognizeEntitiesResultCollection(mockResults,
                new TextDocumentBatchStatistics(2, 2, 0, 2),
                "modelVersion");

            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(mockResultCollection, SerializeRecognizeEntitiesResultCollection));

            var mockTransport = new MockTransport(mockResponse);
            TextAnalyticsClient client = CreateTestClient(mockTransport);

            var documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", "TextDocument1"),
                new TextDocumentInput("2", "TextDocument2"),
            };

            var response = await client.RecognizeEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions());
            var resultCollection = response.Value;

            Assert.AreEqual("1", resultCollection[0].Id);
            Assert.AreEqual("2", resultCollection[1].Id);
        }

        [Test]
        public async Task RecognizeEntitiesResultsSorted_WithErrors()
        {
            var mockResults = new List<RecognizeEntitiesResult>()
            {
                TextAnalyticsModelFactory.RecognizeEntitiesResult("2", new TextDocumentStatistics(),
                    new CategorizedEntityCollection
                    (
                        new List<CategorizedEntity>
                        {
                            new CategorizedEntity("EntityText0", "EntityCategory0", "EntitySubCategory0", 0.5),
                            new CategorizedEntity("EntityText1", "EntityCategory1", "EntitySubCategory1", 0.5),
                        },
                        new List<TextAnalyticsWarning>()
                    )),
                TextAnalyticsModelFactory.RecognizeEntitiesResult("3", new TextDocumentStatistics(),
                    new CategorizedEntityCollection
                    (
                        new List<CategorizedEntity>
                        {
                            new CategorizedEntity("EntityText0", "EntityCategory0", "EntitySubCategory0", 0.5),
                            new CategorizedEntity("EntityText1", "EntityCategory1", "EntitySubCategory1", 0.5),
                        },
                        new List<TextAnalyticsWarning>()
                    )),
                new RecognizeEntitiesResult("4", new TextAnalyticsError("InvalidDocument", "Document is invalid.")),
                new RecognizeEntitiesResult("5", new TextAnalyticsError("InvalidDocument", "Document is invalid.")),
            };
            var mockResultCollection = new RecognizeEntitiesResultCollection(mockResults,
                new TextDocumentBatchStatistics(2, 2, 2, 2),
                "modelVersion");

            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(mockResultCollection, SerializeRecognizeEntitiesResultCollection));

            var mockTransport = new MockTransport(mockResponse);
            TextAnalyticsClient client = CreateTestClient(mockTransport);

            var documents = new List<TextDocumentInput>()
            {
                new TextDocumentInput("4", "TextDocument1"),
                new TextDocumentInput("5", "TextDocument2"),
                new TextDocumentInput("2", "TextDocument3"),
                new TextDocumentInput("3", "TextDocument4"),
            };

            var response = await client.RecognizeEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions());
            var resultCollection = response.Value;

            Assert.AreEqual("4", resultCollection[0].Id);
            Assert.AreEqual("5", resultCollection[1].Id);
            Assert.AreEqual("2", resultCollection[2].Id);
            Assert.AreEqual("3", resultCollection[3].Id);
        }

        private void SerializeRecognizeEntitiesResultCollection(ref Utf8JsonWriter json, RecognizeEntitiesResultCollection resultCollection)
        {
            json.WriteStartObject();
            json.WriteStartArray("documents");
            if (resultCollection.FirstOrDefault(r => r.Entities.Count > 0) != default)
            {
                foreach (var result in resultCollection)
                {
                    if (!result.HasError)
                    {
                        json.WriteStartObject();
                        json.WriteString("id", result.Id);
                        json.WriteStartArray("entities");
                        foreach (var entity in result.Entities)
                        {
                            json.WriteStartObject();
                            json.WriteString("text", entity.Text);
                            json.WriteString("category", JsonSerializer.Serialize(entity.Category));
                            json.WriteString("subcategory", JsonSerializer.Serialize(entity.SubCategory));
                            json.WriteNumber("confidenceScore", entity.ConfidenceScore);
                            json.WriteEndObject();
                        }
                        json.WriteEndArray();
                        json.WriteStartArray("warnings");
                        foreach (var warning in result.Entities.Warnings)
                        {
                            json.WriteStartObject();
                            json.WriteString("code", warning.WarningCode.ToString());
                            json.WriteString("message", warning.Message);
                            json.WriteEndObject();
                        }
                        json.WriteEndArray();
                        json.WriteEndObject();
                    }
                }
            }
            json.WriteEndArray();

            json.WriteStartArray("errors");
            if (resultCollection.FirstOrDefault(r => r.HasError) != default)
            {
                foreach (var result in resultCollection)
                {
                    if (result.HasError)
                    {
                        json.WriteStartObject();
                        json.WriteString("id", result.Id);
                        json.WriteStartObject("error");
                        json.WriteStartObject("innererror");
                        json.WriteString("code", result.Error.ErrorCode.ToString());
                        json.WriteString("message", result.Error.Message);
                        json.WriteEndObject();
                        json.WriteEndObject();
                        json.WriteEndObject();
                    }
                }
            }
            json.WriteEndArray();

            json.WriteString("modelVersion", resultCollection.ModelVersion);
            json.WriteEndObject();

            // TODO: add statistics if needed
        }
    }
}
