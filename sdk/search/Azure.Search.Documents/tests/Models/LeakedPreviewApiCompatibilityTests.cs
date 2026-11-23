// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class LeakedPreviewApiCompatibilityTests : ClientTestBase
    {
        public LeakedPreviewApiCompatibilityTests(bool isAsync) : base(isAsync)
        {
        }

#pragma warning disable CS0618 // Verify requests built with obsolete compatibility models.
        [Test]
        public async Task CreateIndexRequestCarriesAmlVectorizer()
        {
            MockResponse response = new MockResponse(201);
            response.SetContent("""{"name":"idx","fields":[]}""");
            MockTransport transport = new MockTransport(response);
            SearchIndexClient client = InstrumentClient(new SearchIndexClient(
                new Uri("https://fake-search.search.windows.net/"),
                new AzureKeyCredential("fake"),
                new SearchClientOptions { Transport = transport }));
            SearchIndex index = new SearchIndex("idx")
            {
                VectorSearch = new VectorSearch
                {
                    Vectorizers =
                    {
                        new AzureMachineLearningVectorizer("aml")
                        {
                            AMLParameters = new AzureMachineLearningParameters(new Uri("https://example.com/score"))
                            {
                                ModelName = AIFoundryModelCatalogName.CohereEmbedV4
                            }
                        }
                    }
                }
            };

            await client.CreateIndexAsync(index);

            using JsonDocument body = ReadRequest(transport);
            JsonElement vectorizer = body.RootElement.GetProperty("vectorSearch").GetProperty("vectorizers")[0];
            Assert.AreEqual("aml", vectorizer.GetProperty("kind").GetString());
            Assert.AreEqual("https://example.com/score", vectorizer.GetProperty("amlParameters").GetProperty("uri").GetString());
            Assert.AreEqual("Cohere-embed-v4", vectorizer.GetProperty("amlParameters").GetProperty("modelName").GetString());
        }

        [Test]
        public void ImageQueriesReachTransportAndPreserveServiceRejection()
        {
            MockTransport transport = new MockTransport(new MockResponse(400));
            SearchClient client = InstrumentClient(new SearchClient(
                new Uri("https://fake-search.search.windows.net/"),
                "idx",
                new AzureKeyCredential("fake"),
                new SearchClientOptions { Transport = transport }));
            SearchOptions options = new SearchOptions
            {
                VectorSearch = new VectorSearchOptions
                {
                    Queries =
                    {
                        new VectorizableImageUrlQuery
                        {
                            Url = new Uri("https://example.com/image.png"),
                            KNearestNeighborsCount = 3,
                            Fields = { "imageVector" }
                        },
                        new VectorizableImageBinaryQuery
                        {
                            Base64Image = "aW1hZ2U=",
                            Fields = { "imageVector" }
                        }
                    }
                }
            };

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.SearchAsync<SearchDocument>("*", options));
            Assert.AreEqual(400, exception.Status);
            using JsonDocument body = ReadRequest(transport);
            JsonElement queries = body.RootElement.GetProperty("vectorQueries");
            Assert.AreEqual("imageUrl", queries[0].GetProperty("kind").GetString());
            Assert.AreEqual("https://example.com/image.png", queries[0].GetProperty("url").GetString());
            Assert.AreEqual(3, queries[0].GetProperty("k").GetInt32());
            Assert.AreEqual("imageVector", queries[0].GetProperty("fields").GetString());
            Assert.AreEqual("imageBinary", queries[1].GetProperty("kind").GetString());
            Assert.AreEqual("aW1hZ2U=", queries[1].GetProperty("base64Image").GetString());
        }
#pragma warning restore CS0618

        private static JsonDocument ReadRequest(MockTransport transport)
        {
            using MemoryStream stream = new MemoryStream();
            transport.Requests.Single().Content.WriteTo(stream, CancellationToken.None);
            stream.Position = 0;
            return JsonDocument.Parse(stream);
        }
    }
}
