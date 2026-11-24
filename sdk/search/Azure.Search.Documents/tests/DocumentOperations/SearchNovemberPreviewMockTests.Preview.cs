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
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
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
                {"@odata.count":1,"value":[{"name":"Ada"}],"@search.graphDiagnostics":[{"code":"GQL001","severity":"warning","phase":"execution","message":"Bounded evidence"}],"@search.graphStats":{"executionMode":"execute","queryCount":2,"documentsFetched":3,"isEstimated":false,"totalMs":12,"searchMs":8,"planningMs":4}}
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
                includeStatistics: true,
                provenance: new GraphQueryProvenanceParameters(GraphQueryProvenanceKind.Hydrate)
                {
                    MaxEvidencePerRow = 5,
                    HydrateDocuments = new GraphQueryProvenanceHydrateDocumentsParameters { Select = "id,title" }
                },
                querySourceAuthorization: "source-token",
                enableElevatedRead: true);

            Assert.AreEqual(1, result.Value.Count);
            Assert.AreEqual("Ada", result.Value.Value.Single().AdditionalProperties["name"].ToObjectFromJson<string>());
            Assert.AreEqual("GQL001", result.Value.Diagnostics.Single().Code);
            Assert.AreEqual("Bounded evidence", result.Value.Diagnostics.Single().Message);
            Assert.AreEqual(GraphQueryDiagnosticSeverity.Warning, result.Value.Diagnostics.Single().Severity);
            Assert.AreEqual(GraphQueryDiagnosticPhase.Execution, result.Value.Diagnostics.Single().Phase);
            Assert.AreEqual(GraphQueryExecutionMode.Execute, result.Value.Statistics.ExecutionMode);
            Assert.AreEqual(2, result.Value.Statistics.QueryCount);
            Assert.AreEqual(3, result.Value.Statistics.DocumentsFetched);
            Assert.IsFalse(result.Value.Statistics.IsEstimated);
            Assert.AreEqual(12, result.Value.Statistics.TotalMs);
            Assert.AreEqual(8, result.Value.Statistics.SearchMs);
            Assert.AreEqual(4, result.Value.Statistics.PlanningMs);
            var request = transport.Requests.Single();
            Assert.That(request.Uri.ToString(), Does.Contain("api-version=2026-11-01-preview"));
            Assert.That(request.Uri.ToString(), Does.Contain("/docs/search.graph"));
            Assert.IsTrue(request.Headers.TryGetValue("x-ms-query-source-authorization", out string authorization));
            Assert.AreEqual("source-token", authorization);
            Assert.IsTrue(request.Headers.TryGetValue("x-ms-enable-elevated-read", out string elevatedRead));
            Assert.AreEqual("true", elevatedRead);
            using var stream = new MemoryStream();
            request.Content.WriteTo(stream, CancellationToken.None);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            Assert.AreEqual("MATCH (n) RETURN n.name AS name", body.RootElement.GetProperty("gql").GetString());
            Assert.IsTrue(body.RootElement.GetProperty("includeDiagnostics").GetBoolean());
            Assert.AreEqual("category eq 'person'", body.RootElement.GetProperty("filter").GetString());
            Assert.IsTrue(body.RootElement.GetProperty("includeStatistics").GetBoolean());
            JsonElement provenance = body.RootElement.GetProperty("provenance");
            Assert.AreEqual("hydrate", provenance.GetProperty("kind").GetString());
            Assert.AreEqual(5, provenance.GetProperty("maxEvidencePerRow").GetInt32());
            Assert.AreEqual("id,title", provenance.GetProperty("hydrateDocuments").GetProperty("select").GetString());
        }

        [TestCase("modelStopped")]
        [TestCase("maxRuntimeExceeded")]
        [TestCase("modelFailed")]
        public async Task AgenticSearchPreservesUsageAndTermination(string terminationReason)
        {
            var response = new MockResponse(200);
            response.SetContent($$$$"""
                {"value":[{"@search.score":1,"id":"document-1"}],"@search.debug":{"agentic":{
                  "terminationReason":"{{{{terminationReason}}}}","subQueries":[{"search":"company documents","iteration":2}],
                  "usage":{"agenticPlanningTokens":17,"reasoningTokens":31}
                }}}
                """);
            var transport = new MockTransport(response);
            var client = InstrumentClient(new SearchClient(
                new Uri("https://fake-search.search.windows.net"), "documents", new AzureKeyCredential("fake-api-key"),
                new SearchClientOptions { Transport = transport }));

            var result = await client.SearchAsync<SearchDocument>("Find company documents", new SearchOptions
            {
                QueryType = SearchQueryType.Agentic,
                Debug = QueryDebugMode.Agentic,
                AgenticOptions = new AgenticSearchOptions { MaxRuntimeInSeconds = 30 }
            });

            Assert.AreEqual("document-1", result.Value.GetResults().Single().Document["id"]);
            AgenticSearchDebugInfo agentic = result.Value.DebugInfo.Agentic;
            Assert.AreEqual(terminationReason, agentic.TerminationReason.ToString());
            Assert.AreEqual(17, agentic.Usage.AgenticPlanningTokens);
            Assert.AreEqual(31, agentic.Usage.ReasoningTokens);
            Assert.AreEqual("company documents", agentic.SubQueries.Single().Search);
            Assert.AreEqual(2, agentic.SubQueries.Single().Iteration);
        }

        [Test]
        public async Task RetrievalPreservesToolGraphOverridesAndReasoningActivity()
        {
            var response = new MockResponse(200);
            response.SetContent("""
                {"response":[],"activity":[
                  {"id":0,"type":"graphSearch","knowledgeSourceName":"blob-source","graphSearchArguments":{
                    "naturalLanguageQuery":"Find Ada","graphIndexName":"entities","gql":"MATCH (n) RETURN n",
                    "outcome":"Success","attempts":2,"inputTokens":11,"outputTokens":7,"modelElapsedMs":9,"modelName":"gpt-5-mini"
                  }},
                  {"id":1,"type":"agenticReasoning","reasoningTokens":23,"retrievalReasoningEffort":{"kind":"minimal"},"logicalReasoningEffort":{"kind":"low"}}
                ],"references":[{"id":"ref-1","type":"graphSearch","activitySource":0,"graphIndexName":"entities"}]}
                """);
            var transport = new MockTransport(response);
            var client = InstrumentClient(new KnowledgeBaseRetrievalClient(
                new Uri("https://fake-search.search.windows.net"), "kb", new AzureKeyCredential("fake-api-key"),
                new SearchClientOptions { Transport = transport }));
            var request = ModelReaderWriter.Read<KnowledgeBaseRetrievalRequest>(BinaryData.FromString("""
                {"messages":[{"role":"user","content":[{"type":"text","text":"Find Ada"}]}],"toolName":"company-docs",
                  "knowledgeSourceParams":[{"kind":"azureBlob","knowledgeSourceName":"blob-source",
                    "graphParameters":{"includeQuery":true,"provenance":{"kind":"hydrate","hydrateDocuments":{"select":"id,title","top":3}}}
                  }]}
                """));

            var result = await client.RetrieveAsync(request);

            var graph = (KnowledgeBaseGraphSearchActivityRecord)result.Value.Activity[0];
            Assert.AreEqual("entities", graph.GraphSearchArguments.GraphIndexName);
            Assert.AreEqual("MATCH (n) RETURN n", graph.GraphSearchArguments.Gql);
            Assert.AreEqual("Success", graph.GraphSearchArguments.Outcome);
            Assert.AreEqual(2, graph.GraphSearchArguments.Attempts);
            Assert.AreEqual(11, graph.GraphSearchArguments.InputTokens);
            Assert.AreEqual(7, graph.GraphSearchArguments.OutputTokens);
            Assert.AreEqual(9, graph.GraphSearchArguments.ModelElapsedMs);
            var reasoning = (KnowledgeBaseAgenticReasoningActivityRecord)result.Value.Activity[1];
            Assert.AreEqual(23, reasoning.ReasoningTokens);
            Assert.IsInstanceOf<KnowledgeRetrievalMinimalReasoningEffort>(reasoning.RetrievalReasoningEffort);
            Assert.IsInstanceOf<KnowledgeRetrievalLowReasoningEffort>(reasoning.LogicalReasoningEffort);
            Assert.AreEqual("entities", ((KnowledgeBaseGraphSearchReference)result.Value.References.Single()).GraphIndexName);

            using var stream = new MemoryStream();
            transport.Requests.Single().Content.WriteTo(stream, CancellationToken.None);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            Assert.AreEqual("company-docs", body.RootElement.GetProperty("toolName").GetString());
            Assert.IsFalse(body.RootElement.TryGetProperty("toolNames", out _));
            JsonElement parameters = body.RootElement.GetProperty("knowledgeSourceParams")[0].GetProperty("graphParameters");
            Assert.IsTrue(parameters.GetProperty("includeQuery").GetBoolean());
            Assert.AreEqual("hydrate", parameters.GetProperty("provenance").GetProperty("kind").GetString());
            Assert.AreEqual("id,title", parameters.GetProperty("provenance").GetProperty("hydrateDocuments").GetProperty("select").GetString());
            Assert.AreEqual(3, parameters.GetProperty("provenance").GetProperty("hydrateDocuments").GetProperty("top").GetInt32());
        }

        [Test]
        public async Task KnowledgeSourceStatusPreservesGraphSynchronizationStatistics()
        {
            var response = new MockResponse(200);
            response.SetContent("""
                {"kind":"azureBlob","synchronizationStatus":"active",
                  "currentSynchronizationState":{"startTime":"2026-11-01T00:00:00Z","itemsUpdatesProcessed":3,"itemsUpdatesFailed":0,"itemsSkipped":0,"graphStatistics":{"ontologyName":"new-ontology","triplesWritten":3000000000}},
                  "lastSynchronizationState":{"startTime":"2026-10-31T00:00:00Z","endTime":"2026-10-31T01:00:00Z","itemsUpdatesProcessed":2,"itemsUpdatesFailed":1,"itemsSkipped":0,"graphStatistics":{"ontologyName":"old-ontology","triplesWritten":2}}
                }
                """);
            var client = InstrumentClient(new SearchIndexClient(
                new Uri("https://fake-search.search.windows.net"), new AzureKeyCredential("fake-api-key"),
                new SearchClientOptions { Transport = new MockTransport(response) }));

            var result = await client.GetKnowledgeSourceStatusAsync("blob-source");

            Assert.AreEqual("new-ontology", result.Value.CurrentSynchronizationState.GraphStatistics.OntologyName);
            Assert.AreEqual(3000000000L, result.Value.CurrentSynchronizationState.GraphStatistics.TriplesWritten);
            Assert.AreEqual("old-ontology", result.Value.LastSynchronizationState.GraphStatistics.OntologyName);
            Assert.AreEqual(2, result.Value.LastSynchronizationState.GraphStatistics.TriplesWritten);
        }

        [Test]
        public async Task KnowledgeSourceReadsRedactedGraphCacheAndModelCredentials()
        {
            var response = new MockResponse(200);
            response.SetContent("""
                {"name":"blob-source","kind":"azureBlob","azureBlobParameters":{
                  "connectionString":"ResourceId=/subscriptions/fake/storageAccounts/source;","containerName":"documents",
                  "ingestionParameters":{
                    "cache":{"enableReprocessing":true,"identity":null},
                    "chatCompletionModel":{"kind":"openAICompatible","openAICompatibleParameters":{"uri":"https://gateway.example.com/responses?route=chat","modelName":"gpt-6-sol"}}
                  }
                }}
                """);
            var client = InstrumentClient(new SearchIndexClient(
                new Uri("https://fake-search.search.windows.net"), new AzureKeyCredential("fake-api-key"),
                new SearchClientOptions { Transport = new MockTransport(response) }));

            var result = await client.GetKnowledgeSourceAsync("blob-source");

            var ingestion = ((AzureBlobKnowledgeSource)result.Value).AzureBlobParameters.IngestionParameters;
            Assert.IsTrue(ingestion.Cache.EnableReprocessing);
            Assert.IsNull(ingestion.Cache.StorageConnectionString);
            var model = (KnowledgeBaseOpenAICompatibleModel)ingestion.ChatCompletionModel;
            Assert.IsEmpty(model.OpenAICompatibleParameters.Headers);
            Assert.AreEqual("https://gateway.example.com/responses?route=chat", model.OpenAICompatibleParameters.Uri.AbsoluteUri);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task KnowledgeBaseSendsConfiguredAndExplicitlyClearedTools(bool clear)
        {
            var knowledgeBase = ModelReaderWriter.Read<KnowledgeBase>(BinaryData.FromString("""
                {"name":"kb","knowledgeSources":[{"name":"source"}],
                  "tools":[{"name":"company-docs","description":"Search company documents","knowledgeSources":[{"name":"source","filterAddOn":"category eq 'company'"}]}]}
                """));
            if (clear)
            {
                knowledgeBase.Tools.Clear();
            }
            var response = new MockResponse(201);
            response.SetContent(ModelReaderWriter.Write(knowledgeBase, SearchTestHelpers.WireOptions).ToString());
            var transport = new MockTransport(response);
            var client = InstrumentClient(new SearchIndexClient(
                new Uri("https://fake-search.search.windows.net"), new AzureKeyCredential("fake-api-key"),
                new SearchClientOptions { Transport = transport }));

            await client.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);

            using var stream = new MemoryStream();
            transport.Requests.Single().Content.WriteTo(stream, CancellationToken.None);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            JsonElement tools = body.RootElement.GetProperty("tools");
            Assert.AreEqual(clear ? 0 : 1, tools.GetArrayLength());
            if (!clear)
            {
                Assert.AreEqual("company-docs", tools[0].GetProperty("name").GetString());
                Assert.AreEqual("category eq 'company'", tools[0].GetProperty("knowledgeSources")[0].GetProperty("filterAddOn").GetString());
            }
        }

        [Test]
        public void DeferredGraphExtractionDistinguishesOmittedAndNullOntology()
        {
            var parameters = new KnowledgeSourceGraphExtractionParameters("entities");
            using JsonDocument omitted = JsonDocument.Parse(ModelReaderWriter.Write(parameters, SearchTestHelpers.WireOptions));
            Assert.IsFalse(omitted.RootElement.TryGetProperty("ontology", out _));

            parameters.Ontology = null;
            BinaryData data = ModelReaderWriter.Write(parameters, SearchTestHelpers.WireOptions);
            using JsonDocument explicitNull = JsonDocument.Parse(data);
            Assert.AreEqual(JsonValueKind.Null, explicitNull.RootElement.GetProperty("ontology").ValueKind);
            var read = ModelReaderWriter.Read<KnowledgeSourceGraphExtractionParameters>(data);
            using JsonDocument roundtrip = JsonDocument.Parse(ModelReaderWriter.Write(read, SearchTestHelpers.WireOptions));
            Assert.AreEqual(JsonValueKind.Null, roundtrip.RootElement.GetProperty("ontology").ValueKind);
        }

        [TestCase("gpt-6-astra")]
        [TestCase("gpt-6-sol")]
        [TestCase("gpt-6-luna")]
        [TestCase("gpt-6.1-sol")]
        public async Task KnowledgeBaseSendsGpt6ModelConfiguration(string modelName)
        {
            var model = new KnowledgeBaseAzureOpenAIModel(new AzureOpenAIVectorizerParameters
            {
                ResourceUri = new Uri("https://model.example.com"),
                DeploymentName = "responses-model",
                ModelName = new AzureOpenAIModelName(modelName)
            });
            var knowledgeBase = new KnowledgeBase("kb", new[] { new KnowledgeSourceReference("source") })
            {
                Models = { model }
            };
            var response = new MockResponse(201);
            response.SetContent(ModelReaderWriter.Write(knowledgeBase, SearchTestHelpers.WireOptions).ToString());
            var transport = new MockTransport(response);
            var client = InstrumentClient(new SearchIndexClient(
                new Uri("https://fake-search.search.windows.net"), new AzureKeyCredential("fake-api-key"),
                new SearchClientOptions { Transport = transport }));

            var result = await client.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);

            var returned = (KnowledgeBaseAzureOpenAIModel)result.Value.Models.Single();
            Assert.AreEqual(modelName, returned.AzureOpenAIParameters.ModelName.ToString());
            using var stream = new MemoryStream();
            transport.Requests.Single().Content.WriteTo(stream, CancellationToken.None);
            using JsonDocument body = JsonDocument.Parse(stream.ToArray());
            Assert.AreEqual(modelName, body.RootElement.GetProperty("models")[0].GetProperty("azureOpenAIParameters").GetProperty("modelName").GetString());
            Assert.AreEqual("responses-model", body.RootElement.GetProperty("models")[0].GetProperty("azureOpenAIParameters").GetProperty("deploymentId").GetString());
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

        [TestCase("J", null)]
        [TestCase("J", "linear")]
        [TestCase("W", null)]
        [TestCase("W", "linear")]
        public void UnknownScoringRetainsLegacyFieldAndBoost(string format, string interpolation)
        {
            var options = new ModelReaderWriterOptions(format);
            var function = ModelReaderWriter.Read<ScoringFunction>(
                BinaryData.FromString($$$"""{"type":"future","fieldName":"rating","boost":2,"interpolation":{{{JsonSerializer.Serialize(interpolation)}}},"futureOption":{"enabled":true}}"""),
                options);
            Assert.IsInstanceOf<UnknownScoringFunction>(function);
            Assert.AreEqual("rating", function.FieldName);
            Assert.AreEqual(2, function.Boost);
            Assert.AreEqual(interpolation, function.Interpolation?.ToSerialString());

            BinaryData data = ModelReaderWriter.Write(function, options);
            using JsonDocument json = JsonDocument.Parse(data);
            JsonElement root = json.RootElement;
            Assert.AreEqual("future", root.GetProperty("type").GetString());
            Assert.AreEqual("rating", root.GetProperty("fieldName").GetString());
            Assert.AreEqual(2, root.GetProperty("boost").GetDouble());
            Assert.AreEqual(1, root.EnumerateObject().Count(p => p.Name == "fieldName"));
            Assert.AreEqual(1, root.EnumerateObject().Count(p => p.Name == "boost"));
            if (interpolation is null)
            {
                Assert.IsFalse(root.TryGetProperty("interpolation", out _));
            }
            else
            {
                Assert.AreEqual(interpolation, root.GetProperty("interpolation").GetString());
            }
            if (format == "J")
            {
                Assert.IsTrue(root.GetProperty("futureOption").GetProperty("enabled").GetBoolean());
            }
            else
            {
                Assert.IsFalse(root.TryGetProperty("futureOption", out _));
            }

            ScoringFunction roundtrip = ModelReaderWriter.Read<ScoringFunction>(data, options);
            Assert.IsInstanceOf<UnknownScoringFunction>(roundtrip);
            Assert.AreEqual(function.FieldName, roundtrip.FieldName);
            Assert.AreEqual(function.Boost, roundtrip.Boost);
            Assert.AreEqual(function.Interpolation, roundtrip.Interpolation);
        }

        [Test]
        public void LegacyScoringFactoryAcceptsNullMockValues()
        {
            ScoringFunction function = SearchModelFactory.ScoringFunction(null, null, 2, null);
            Assert.IsNull(function.FieldName);
            Assert.AreEqual(2, function.Boost);
        }

        [Test]
        public void NativeStreamModelRetainsEnvelopePayload()
        {
            var value = ModelReaderWriter.Read<KnowledgeBaseAnswerCompletedStreamEvent>(
                BinaryData.FromString("""{"value":{}}"""));
            Assert.IsNotNull(value.Value);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(value));
            Assert.AreEqual(JsonValueKind.Object, json.RootElement.GetProperty("value").ValueKind);
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
