// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://contoso-textanalytics.cognitiveservices.azure.com/";
        private static readonly string s_subscriptionKey = "FakeSubscriptionKey";

        public TextAnalyticsClientTests(bool isAsync) : base(isAsync)
        {
        }

        private TextAnalyticsClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new TextAnalyticsClientOptions
            {
                Transport = transport
            };

            var client = InstrumentClient(new TextAnalyticsClient(new Uri(s_endpoint), s_subscriptionKey, options));

            return client;
        }

        [Test]
        public async Task RecognizeEntitiesResultsSorted_NoErrors()
        {
            var mockResults = new List<RecognizeEntitiesResult>()
            {
                new RecognizeEntitiesResult("1", new TextDocumentStatistics(), new List<NamedEntity>()
                {
                    new NamedEntity("EntityText0", "EntityType0", "EntitySubType0", 0, 1, 0.5),
                    new NamedEntity("EntityText1", "EntityType1", "EntitySubType1", 0, 1, 0.5),
                }),
                new RecognizeEntitiesResult("2", new TextDocumentStatistics(), new List<NamedEntity>()
                {
                    new NamedEntity("EntityText0", "EntityType0", "EntitySubType0", 0, 1, 0.5),
                    new NamedEntity("EntityText1", "EntityType1", "EntitySubType1", 0, 1, 0.5),
                }),
            };
            var mockResultCollection = new RecognizeEntitiesResultCollection(mockResults,
                new TextDocumentBatchStatistics(2, 2, 0, 2),
                "modelVersion");

            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(mockResultCollection, SerializeRecognizeEntitiesResultCollection));

            var mockTransport = new MockTransport(mockResponse);
            TextAnalyticsClient client = CreateTestClient(mockTransport);

            var inputs = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", "TextDocument1"),
                new TextDocumentInput("2", "TextDocument2"),
            };

            var response = await client.RecognizeEntitiesAsync(inputs, new TextAnalyticsRequestOptions());
            var resultCollection = response.Value;

            Assert.AreEqual("1", resultCollection[0].Id);
            Assert.AreEqual("2", resultCollection[1].Id);
        }

        [Test]
        public async Task RecognizeEntitiesResultsSorted_WithErrors()
        {
            var mockResults = new List<RecognizeEntitiesResult>()
            {
                new RecognizeEntitiesResult("2", new TextDocumentStatistics(), new List<NamedEntity>()
                {
                    new NamedEntity("EntityText0", "EntityType0", "EntitySubType0", 0, 1, 0.5),
                    new NamedEntity("EntityText1", "EntityType1", "EntitySubType1", 0, 1, 0.5),
                }),
                new RecognizeEntitiesResult("3", new TextDocumentStatistics(), new List<NamedEntity>()
                {
                    new NamedEntity("EntityText0", "EntityType0", "EntitySubType0", 0, 1, 0.5),
                    new NamedEntity("EntityText1", "EntityType1", "EntitySubType1", 0, 1, 0.5),
                }),
                new RecognizeEntitiesResult("4", "Document is invalid."),
                new RecognizeEntitiesResult("5", "Document is invalid."),
            };
            var mockResultCollection = new RecognizeEntitiesResultCollection(mockResults,
                new TextDocumentBatchStatistics(2, 2, 2, 2),
                "modelVersion");

            var mockResponse = new MockResponse(200);
            mockResponse.SetContent(SerializationHelpers.Serialize(mockResultCollection, SerializeRecognizeEntitiesResultCollection));

            var mockTransport = new MockTransport(mockResponse);
            TextAnalyticsClient client = CreateTestClient(mockTransport);

            var inputs = new List<TextDocumentInput>()
            {
                new TextDocumentInput("4", "TextDocument1"),
                new TextDocumentInput("5", "TextDocument2"),
                new TextDocumentInput("2", "TextDocument3"),
                new TextDocumentInput("3", "TextDocument4"),
            };

            var response = await client.RecognizeEntitiesAsync(inputs, new TextAnalyticsRequestOptions());
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
            if (resultCollection.FirstOrDefault(r => r.NamedEntities.Count > 0) != default)
            {
                foreach (var result in resultCollection)
                {
                    if (result.NamedEntities.Count > 0)
                    {
                        json.WriteStartObject();
                        json.WriteString("id", result.Id);
                        json.WriteStartArray("entities");
                        foreach (var entity in result.NamedEntities)
                        {
                            json.WriteStartObject();
                            json.WriteString("text", entity.Text);
                            json.WriteString("type", entity.Type);
                            json.WriteString("subtype", entity.SubType);
                            json.WriteNumber("offset", entity.Offset);
                            json.WriteNumber("length", entity.Length);
                            json.WriteNumber("score", entity.Score);
                            json.WriteEndObject();
                        }
                        json.WriteEndArray();
                        json.WriteEndObject();
                    }
                }
            }
            json.WriteEndArray();

            json.WriteStartArray("errors");
            if (resultCollection.FirstOrDefault(r => r.ErrorMessage != default) != default)
            {
                foreach (var result in resultCollection)
                {
                    if (result.ErrorMessage != null)
                    {
                        json.WriteStartObject();
                        json.WriteString("id", result.Id);
                        json.WriteStartObject("error");
                        json.WriteStartObject("innerError");
                        json.WriteString("message", result.ErrorMessage);
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
