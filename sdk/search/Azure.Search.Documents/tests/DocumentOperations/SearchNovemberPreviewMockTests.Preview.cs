// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

// search-preview:2026-11-01-preview {
namespace Azure.Search.Documents.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class SearchNovemberPreviewMockTests : ClientTestBase
    {
        public SearchNovemberPreviewMockTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task GraphPreservesRequestAndDiagnostics()
        {
            var response = new MockResponse(200);
            response.SetContent("""
                {"@odata.count":1,"value":[{"name":"Ada"}],"@search.graphDiagnostics":[{"code":"GQL001","severity":"warning","phase":"execution","message":"Bounded evidence"}],"@search.graphStats":{}}
                """);
            var transport = new MockTransport(response);
            var client = InstrumentClient(new SearchClient(
                new Uri("https://fake-search.search.windows.net"),
                "graph-index",
                new AzureKeyCredential("fake-api-key"),
                new SearchClientOptions { Transport = transport }));

            Response<GraphQueryResult> result = await client.GraphAsync(
                "MATCH (n) RETURN n.name AS name",
                filter: "category eq 'person'",
                includeDiagnostics: true,
                querySourceAuthorization: "source-token",
                enableElevatedRead: true);

            Assert.AreEqual(1, result.Value.Count);
            Assert.AreEqual("Ada", result.Value.Value.Single().AdditionalProperties["name"].ToObjectFromJson<string>());
            Assert.AreEqual("GQL001", result.Value.Diagnostics.Single().Code);
            Assert.AreEqual("Bounded evidence", result.Value.Diagnostics.Single().Message);
            var request = transport.Requests.Single();
            Assert.That(request.Uri.ToString(), Does.Contain("api-version=2026-11-01-preview"));
            Assert.That(request.Uri.ToString(), Does.Contain("/docs/search.graph"));
            Assert.IsTrue(request.Headers.TryGetValue("x-ms-query-source-authorization", out string authorization));
            Assert.AreEqual("source-token", authorization);
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            Assert.AreEqual("MATCH (n) RETURN n.name AS name", body.RootElement.GetProperty("gql").GetString());
            Assert.IsTrue(body.RootElement.GetProperty("includeDiagnostics").GetBoolean());
            Assert.AreEqual("category eq 'person'", body.RootElement.GetProperty("filter").GetString());
        }

        [TestCase("none", typeof(NoneVectorQueryTopicGraph))]
        [TestCase("diverse", typeof(DiverseVectorQueryTopicGraph))]
        [TestCase("balanced", typeof(BalancedVectorQueryTopicGraph))]
        public void TopicGraphUsesDiscriminator(string kind, Type expectedType)
        {
            var value = ModelReaderWriter.Read<VectorQueryTopicGraph>(
                BinaryData.FromString($"{{\"kind\":\"{kind}\"}}"));
            Assert.AreEqual(expectedType, value.GetType());
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(value));
            Assert.AreEqual(kind, json.RootElement.GetProperty("kind").GetString());
        }

        [Test]
        public void RandomScoringOmitsLegacyBaseProperties()
        {
            ScoringFunction function = new RandomScoringFunction
            {
                Parameters = new RandomScoringParameters("randomSeed")
            };
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(function, new ModelReaderWriterOptions("W")));
            Assert.AreEqual("random", json.RootElement.GetProperty("type").GetString());
            Assert.AreEqual("randomSeed", json.RootElement.GetProperty("random").GetProperty("seedParameter").GetString());
            Assert.IsFalse(json.RootElement.TryGetProperty("boost", out _));
            Assert.IsFalse(json.RootElement.TryGetProperty("fieldName", out _));
        }

        [Test]
        public void ClassicScoringRetainsBaseContract()
        {
            ScoringFunction function = new MagnitudeScoringFunction("rating", 2, new MagnitudeScoringParameters(0, 5));
            Assert.AreEqual("rating", function.FieldName);
            Assert.AreEqual(2, function.Boost);
            function.Boost = 3;
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(function, new ModelReaderWriterOptions("W")));
            Assert.AreEqual(3, json.RootElement.GetProperty("boost").GetDouble());
            Assert.AreEqual("rating", json.RootElement.GetProperty("fieldName").GetString());
            Assert.AreEqual(1, json.RootElement.EnumerateObject().Count(p => p.Name == "boost"));
        }

        [Test]
        public void UnknownScoringRetainsLegacyFieldAndBoost()
        {
            var function = ModelReaderWriter.Read<ScoringFunction>(
                BinaryData.FromString("""{"type":"future","fieldName":"rating","boost":2,"futureOption":true}"""));
            Assert.AreEqual("rating", function.FieldName);
            Assert.AreEqual(2, function.Boost);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(function));
            Assert.AreEqual("rating", json.RootElement.GetProperty("fieldName").GetString());
            Assert.AreEqual(2, json.RootElement.GetProperty("boost").GetDouble());
            Assert.IsTrue(json.RootElement.GetProperty("futureOption").GetBoolean());
        }

        [Test]
        public void LegacyScoringFactoryAcceptsNullMockValues()
        {
            ScoringFunction function = SearchModelFactory.ScoringFunction(null, null, 2, null);
            Assert.IsNull(function.FieldName);
            Assert.AreEqual(2, function.Boost);
        }

        [Test]
        public void NativeStreamModelRetainsEventName()
        {
            var value = ModelReaderWriter.Read<KnowledgeBaseAnswerCompletedStreamEvent>(
                BinaryData.FromString("""{"value":{}}"""));
            Assert.AreEqual("answer.completed", value.EventName);
        }

        [Test]
        public void FacetFilterHintAutoConfigurationRoundtrips()
        {
            var hint = new SearchIndexKnowledgeSourceFilterHint("category")
            {
                AutoConfiguration = new SearchIndexKnowledgeSourceFilterHintAutoConfiguration
                {
                    CacheTtl = 300,
                    MaxFacetValueCount = 32
                }
            };
            BinaryData data = ModelReaderWriter.Write(hint, new ModelReaderWriterOptions("W"));
            using JsonDocument json = JsonDocument.Parse(data);
            Assert.IsFalse(json.RootElement.TryGetProperty("fieldValues", out _));
            var read = ModelReaderWriter.Read<SearchIndexKnowledgeSourceFilterHint>(data);
            Assert.AreEqual(300, read.AutoConfiguration.CacheTtl);
            Assert.AreEqual(32, read.AutoConfiguration.MaxFacetValueCount);
        }

        [Test]
        public void CacheRetainsReprocessingAndIdentity()
        {
            var cache = new KnowledgeSourceCache("ResourceId=/subscriptions/fake/resourceGroups/fake/providers/Microsoft.Storage/storageAccounts/fake")
            {
                EnableReprocessing = true,
                Identity = new SearchIndexerDataNoneIdentity()
            };
            var read = ModelReaderWriter.Read<KnowledgeSourceCache>(ModelReaderWriter.Write(cache));
            Assert.IsTrue(read.EnableReprocessing);
            Assert.IsInstanceOf<SearchIndexerDataNoneIdentity>(read.Identity);
        }

        [Test]
        public void AllSupportedVersionsRoundtripAndPreviewIsDefault()
        {
            Assert.AreEqual(SearchClientOptions.ServiceVersion.V2026_11_01_Preview, new SearchClientOptions().Version);
            foreach (SearchClientOptions.ServiceVersion version in Enum.GetValues(typeof(SearchClientOptions.ServiceVersion)))
            {
                Assert.AreEqual(version, new SearchClientOptions(version).Version);
                Assert.AreEqual(version, version.ToVersionString().ToServiceVersion());
                Assert.IsTrue(SearchClientOptions.TryGetServiceVersion(version.ToVersionString(), out var parsed));
                Assert.AreEqual(version, parsed);
            }
        }
    }
}
// search-preview:2026-11-01-preview }
