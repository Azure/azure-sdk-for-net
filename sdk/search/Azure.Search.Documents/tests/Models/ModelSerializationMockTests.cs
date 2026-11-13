// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    /// <summary>
    /// Data-driven JSON roundtrip tests for Search SDK model types.
    /// Uses <see cref="TestCaseSource"/> with (Type, JSON payload) pairs.
    ///
    /// Each entry:
    ///   1. Deserializes the JSON into the model type via ModelReaderWriter.Read()
    ///   2. Re-serializes via ModelReaderWriter.Write()
    ///   3. Asserts structural equivalence of the JSON
    ///
    /// No recordings, no live resources, no SearchTestBase.
    /// </summary>
    /// <remarks>
    /// <para><strong>Coverage Tiers — When to add models here:</strong></para>
    /// <para>
    /// This is Tier 3 (curated) coverage. It does NOT need to cover every model.
    /// The automated tiers handle broad coverage:
    /// </para>
    /// <list type="bullet">
    ///   <item>Tier 1: <c>ModelDiscoveryTests</c> — auto-discovers ALL IJsonModel types via reflection.
    ///     Validates builder exists and Read/Write don't fatally crash. Fully automatic.</item>
    ///   <item>Tier 2: <c>PolymorphicRoundtripTests</c> — auto-discovers ALL polymorphic subtypes.
    ///     Validates Read+Write don't throw. Fully automatic.</item>
    ///   <item>Tier 3: This file — curated list of models where you assert specific property
    ///     values survive the roundtrip (e.g., "does name=hotels come back as name=hotels?").</item>
    /// </list>
    /// <para><strong>Add a model here when:</strong></para>
    /// <list type="bullet">
    ///   <item>It's a new top-level resource type (SearchIndex, SearchIndexer, KnowledgeBase, etc.)</item>
    ///   <item>It has complex serialization logic (custom converters, polymorphic discriminators)</item>
    ///   <item>It has had a serialization bug before</item>
    ///   <item>It's a model that has multiple customizations or special behavior that needs explicit testing</item>
    /// </list>
    /// <para><strong>Do NOT add a model here when:</strong></para>
    /// <list type="bullet">
    ///   <item>It's a simple leaf/nested DTO — Tiers 1 and 2 already prove infrastructure works</item>
    ///   <item>It's already exercised by recorded integration tests (which implicitly roundtrip through the service). Unless,
    ///   it contains more values or paths that are not tested by recorded tests.</item>
    ///   <item>It's an options bag or response wrapper with no complex serialization</item>
    /// </list>
    /// </remarks>
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Category("ModelSerialization")]
    public class ModelSerializationMockTests
    {
#pragma warning disable CS0618 // Exercise obsolete compatibility models and factory methods.
        [TestCase("J", false)]
        [TestCase("W", false)]
        [TestCase("J", true)]
        [TestCase("W", true)]
        public void ImageQueryCompatibilityRoundtrips(string format, bool useFactory)
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            VectorizableImageBinaryQuery binary = useFactory
                ? SearchModelFactory.VectorizableImageBinaryQuery(3, "imageVector", true, 2, 0.5f, "aW1hZ2U=")
                : new VectorizableImageBinaryQuery
                {
                    KNearestNeighborsCount = 3,
                    Exhaustive = true,
                    Oversampling = 2,
                    Weight = 0.5f,
                    Base64Image = "aW1hZ2U="
                };
            VectorizableImageUrlQuery url = useFactory
                ? SearchModelFactory.VectorizableImageUrlQuery(3, "imageVector", true, 2, 0.5f, new Uri("https://example.com/image.png"))
                : new VectorizableImageUrlQuery
                {
                    KNearestNeighborsCount = 3,
                    Exhaustive = true,
                    Oversampling = 2,
                    Weight = 0.5f,
                    Url = new Uri("https://example.com/image.png")
                };
            if (!useFactory)
            {
                binary.Fields.Add("imageVector");
                url.Fields.Add("imageVector");
            }

            foreach (VectorQuery query in new VectorQuery[] { binary, url })
            {
                BinaryData data = ModelReaderWriter.Write(query, options);
                using JsonDocument document = JsonDocument.Parse(data);
                JsonElement json = document.RootElement;
                bool isBinary = query is VectorizableImageBinaryQuery;
                Assert.AreEqual(isBinary ? "imageBinary" : "imageUrl", json.GetProperty("kind").GetString());
                Assert.AreEqual(isBinary ? "aW1hZ2U=" : "https://example.com/image.png",
                    json.GetProperty(isBinary ? "base64Image" : "url").GetString());
                Assert.AreEqual(3, json.GetProperty("k").GetInt32());
                Assert.AreEqual("imageVector", json.GetProperty("fields").GetString());
                Assert.IsTrue(json.GetProperty("exhaustive").GetBoolean());
                Assert.AreEqual(2, json.GetProperty("oversampling").GetDouble());
                Assert.AreEqual(0.5f, json.GetProperty("weight").GetSingle());

                VectorQuery restored = ModelReaderWriter.Read<VectorQuery>(data, options);
                Assert.AreEqual("UnknownVectorQuery", restored.GetType().Name);
                Assert.AreEqual(query.KNearestNeighborsCount, restored.KNearestNeighborsCount);
                CollectionAssert.AreEqual(query.Fields, restored.Fields);
                Assert.AreEqual(query.Exhaustive, restored.Exhaustive);
                Assert.AreEqual(query.Oversampling, restored.Oversampling);
                Assert.AreEqual(query.Weight, restored.Weight);
                if (isBinary)
                {
                    Assert.AreEqual(binary.Base64Image, ModelReaderWriter.Read<VectorizableImageBinaryQuery>(data, options).Base64Image);
                    Assert.AreEqual(binary.Base64Image, ModelReaderWriter.Read<VectorizableImageBinaryQuery>(data, options, AzureSearchDocumentsContext.Default).Base64Image);
                }
                else
                {
                    Assert.AreEqual(url.Url, ModelReaderWriter.Read<VectorizableImageUrlQuery>(data, options).Url);
                    Assert.AreEqual(url.Url, ModelReaderWriter.Read<VectorizableImageUrlQuery>(data, options, AzureSearchDocumentsContext.Default).Url);
                }
            }

            SearchOptions searchOptions = new SearchOptions
            {
                VectorSearch = new VectorSearchOptions { Queries = { binary, url } }
            };
            using JsonDocument request = JsonDocument.Parse(ModelReaderWriter.Write(searchOptions, SearchTestHelpers.WireOptions));
            Assert.AreEqual("imageBinary", request.RootElement.GetProperty("vectorQueries")[0].GetProperty("kind").GetString());
            Assert.AreEqual("imageUrl", request.RootElement.GetProperty("vectorQueries")[1].GetProperty("kind").GetString());
        }

        [TestCase("J", "minimal")]
        [TestCase("W", "minimal")]
        [TestCase("J", "low")]
        [TestCase("W", "low")]
        [TestCase("J", "medium")]
        [TestCase("W", "medium")]
        [TestCase("J", "future")]
        [TestCase("W", "future")]
        public void AgenticReasoningEffortIsNotBoundToWire(string format, string kind)
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            BinaryData data = BinaryData.FromString($$$"""
                {"id":1,"type":"agenticReasoning","reasoningTokens":12,"retrievalReasoningEffort":{"kind":"{{{kind}}}"}}
                """);
            KnowledgeBaseAgenticReasoningActivityRecord record =
                (KnowledgeBaseAgenticReasoningActivityRecord)ModelReaderWriter.Read<KnowledgeBaseActivityRecord>(data, options);
            Assert.IsNull(record.RetrievalReasoningEffort);
            Assert.AreEqual(12, record.ReasoningTokens);

            using JsonDocument serialized = JsonDocument.Parse(ModelReaderWriter.Write(record, SearchTestHelpers.WireOptions));
            Assert.IsFalse(serialized.RootElement.TryGetProperty("retrievalReasoningEffort", out _));
            Assert.AreEqual(12, serialized.RootElement.GetProperty("reasoningTokens").GetInt32());
            KnowledgeBaseAgenticReasoningActivityRecord restored =
                ModelReaderWriter.Read<KnowledgeBaseAgenticReasoningActivityRecord>(ModelReaderWriter.Write(record, options), options);
            Assert.IsNull(restored.RetrievalReasoningEffort);
        }

        [TestCase("J", "")]
        [TestCase("W", "")]
        [TestCase("J", ",\"retrievalReasoningEffort\":null")]
        [TestCase("W", ",\"retrievalReasoningEffort\":null")]
        public void MissingAgenticReasoningEffortRemainsNull(string format, string effortJson)
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            BinaryData data = BinaryData.FromString("{\"id\":1,\"type\":\"agenticReasoning\"" + effortJson + "}");
            KnowledgeBaseAgenticReasoningActivityRecord record = ModelReaderWriter.Read<KnowledgeBaseAgenticReasoningActivityRecord>(data, options);
            Assert.IsNull(record.RetrievalReasoningEffort);
            using JsonDocument serialized = JsonDocument.Parse(ModelReaderWriter.Write(record, SearchTestHelpers.WireOptions));
            Assert.IsFalse(serialized.RootElement.TryGetProperty("retrievalReasoningEffort", out _));
        }

        [Test]
        public void AgenticReasoningFactoryPreservesEffort()
        {
            KnowledgeRetrievalMinimalReasoningEffort effort = new KnowledgeRetrievalMinimalReasoningEffort();
            KnowledgeBaseAgenticReasoningActivityRecord record =
                SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, null, null, 12, effort);
            Assert.AreSame(effort, record.RetrievalReasoningEffort);
            using JsonDocument serialized = JsonDocument.Parse(ModelReaderWriter.Write(record, SearchTestHelpers.WireOptions));
            Assert.IsFalse(serialized.RootElement.TryGetProperty("retrievalReasoningEffort", out _));
            Assert.AreEqual(12, serialized.RootElement.GetProperty("reasoningTokens").GetInt32());
        }

        [Test]
        public void AgenticReasoningFactorySupportsOmittedAndNamedArguments()
        {
            KnowledgeBaseAgenticReasoningActivityRecord record =
                SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord();
            Assert.AreEqual(0, record.Id);
            Assert.IsNull(record.ElapsedMs);
            Assert.IsNull(record.Error);
            Assert.IsNull(record.ReasoningTokens);
            Assert.IsNull(record.RetrievalReasoningEffort);

            Assert.AreEqual(1, SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1).Id);
            Assert.AreEqual(100, SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, 100).ElapsedMs);
            Assert.AreEqual(100, SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(elapsedMs: 100).ElapsedMs);
            Assert.AreEqual(12, SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(reasoningTokens: 12).ReasoningTokens);

            KnowledgeBaseErrorDetail error = SearchModelFactory.KnowledgeBaseErrorDetail("test", "message");
            record = SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, 100, error, 12);
            Assert.AreEqual(100, record.ElapsedMs);
            Assert.AreSame(error, record.Error);
            Assert.AreEqual(12, record.ReasoningTokens);

            KnowledgeRetrievalMinimalReasoningEffort effort = new KnowledgeRetrievalMinimalReasoningEffort();
            Assert.AreSame(effort, SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(retrievalReasoningEffort: effort).RetrievalReasoningEffort);
        }

        [Test]
        public void AgenticReasoningFactorySupportsNullArguments()
        {
            KnowledgeBaseAgenticReasoningActivityRecord[] records =
            {
                SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, null),
                SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, null, null),
                SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, null, null, null),
                SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, null, null, null, null)
            };

            foreach (KnowledgeBaseAgenticReasoningActivityRecord record in records)
            {
                Assert.AreEqual(1, record.Id);
                Assert.IsNull(record.ElapsedMs);
                Assert.IsNull(record.Error);
                Assert.IsNull(record.ReasoningTokens);
                Assert.IsNull(record.RetrievalReasoningEffort);
            }
        }

        [Test]
        public void AgenticReasoningFactoryPreservesTimestampAndWarningArguments()
        {
            DateTimeOffset startedOn = new DateTimeOffset(2026, 10, 1, 1, 0, 0, TimeSpan.Zero);
            DateTimeOffset completedOn = startedOn.AddMilliseconds(100);
            KnowledgeBaseErrorDetail error = SearchModelFactory.KnowledgeBaseErrorDetail("test", "message");
            KnowledgeBaseAgenticReasoningActivityRecord record =
                SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, startedOn, completedOn, 100, error, "warning", 12);

            Assert.AreEqual(1, record.Id);
            Assert.AreEqual(startedOn, record.StartedOn);
            Assert.AreEqual(completedOn, record.CompletedOn);
            Assert.AreEqual(100, record.ElapsedMs);
            Assert.AreSame(error, record.Error);
            Assert.AreEqual("warning", record.Warning);
            Assert.AreEqual(12, record.ReasoningTokens);
            Assert.IsNull(record.RetrievalReasoningEffort);
        }

        [TestCase("imageBinary", "base64Image", "aW1hZ2U=")]
        [TestCase("imageUrl", "url", "https://example.com/image.png")]
        public void ImageQueryPersistencePreservesUnknownProperties(string kind, string property, string value)
        {
            BinaryData data = BinaryData.FromString($$$"""
                {"kind":"{{{kind}}}","{{{property}}}":"{{{value}}}","futureProperty":{"value":42}}
                """);
            VectorQuery query = kind == "imageBinary"
                ? ModelReaderWriter.Read<VectorizableImageBinaryQuery>(data)
                : ModelReaderWriter.Read<VectorizableImageUrlQuery>(data);
            using JsonDocument persisted = JsonDocument.Parse(ModelReaderWriter.Write(query));
            Assert.AreEqual(42, persisted.RootElement.GetProperty("futureProperty").GetProperty("value").GetInt32());
            using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(query, SearchTestHelpers.WireOptions));
            Assert.IsFalse(wire.RootElement.TryGetProperty("futureProperty", out _));
            Assert.AreEqual(value, wire.RootElement.GetProperty(property).GetString());
        }

        [TestCase("J", false)]
        [TestCase("W", false)]
        [TestCase("J", true)]
        [TestCase("W", true)]
        public void AmlCompatibilityRoundtrips(string format, bool useFactory)
        {
            ModelReaderWriterOptions options = new ModelReaderWriterOptions(format);
            Uri scoringUri = new Uri("https://example.com/score");
            AzureMachineLearningParameters parameters = useFactory
                ? SearchModelFactory.AzureMachineLearningParameters(scoringUri, "test-key", "resource", TimeSpan.FromMinutes(1), "westus", AIFoundryModelCatalogName.CohereEmbedV4)
                : new AzureMachineLearningParameters(scoringUri)
                {
                    AuthenticationKey = "test-key",
                    ResourceId = "resource",
                    Timeout = TimeSpan.FromMinutes(1),
                    Region = "westus",
                    ModelName = AIFoundryModelCatalogName.CohereEmbedV4
                };
            AzureMachineLearningVectorizer vectorizer = useFactory
                ? SearchModelFactory.AzureMachineLearningVectorizer("aml", parameters)
                : new AzureMachineLearningVectorizer("aml") { AMLParameters = parameters };

            BinaryData data = ModelReaderWriter.Write(vectorizer, options, AzureSearchDocumentsContext.Default);
            using JsonDocument document = JsonDocument.Parse(data);
            JsonElement json = document.RootElement;
            Assert.AreEqual("aml", json.GetProperty("name").GetString());
            Assert.AreEqual("aml", json.GetProperty("kind").GetString());
            JsonElement aml = json.GetProperty("amlParameters");
            Assert.AreEqual(scoringUri.AbsoluteUri, aml.GetProperty("uri").GetString());
            Assert.AreEqual("test-key", aml.GetProperty("key").GetString());
            Assert.AreEqual("resource", aml.GetProperty("resourceId").GetString());
            Assert.AreEqual("PT1M", aml.GetProperty("timeout").GetString());
            Assert.AreEqual("westus", aml.GetProperty("region").GetString());
            Assert.AreEqual("Cohere-embed-v4", aml.GetProperty("modelName").GetString());

            foreach (bool useContext in new[] { false, true })
            {
                AzureMachineLearningVectorizer restored = useContext
                    ? ModelReaderWriter.Read<AzureMachineLearningVectorizer>(data, options, AzureSearchDocumentsContext.Default)
                    : ModelReaderWriter.Read<AzureMachineLearningVectorizer>(data, options);
                Assert.AreEqual(vectorizer.VectorizerName, restored.VectorizerName);
                BinaryData parameterData = ModelReaderWriter.Write(parameters, options);
                AzureMachineLearningParameters restoredParameters = useContext
                    ? ModelReaderWriter.Read<AzureMachineLearningParameters>(parameterData, options, AzureSearchDocumentsContext.Default)
                    : ModelReaderWriter.Read<AzureMachineLearningParameters>(parameterData, options);
                foreach (AzureMachineLearningParameters actual in new[] { restored.AMLParameters, restoredParameters })
                {
                    Assert.AreEqual(parameters.ScoringUri, actual.ScoringUri);
                    Assert.AreEqual(parameters.AuthenticationKey, actual.AuthenticationKey);
                    Assert.AreEqual(parameters.ResourceId, actual.ResourceId);
                    Assert.AreEqual(parameters.Timeout, actual.Timeout);
                    Assert.AreEqual(parameters.Region, actual.Region);
                    Assert.AreEqual(parameters.ModelName, actual.ModelName);
                }
            }

            VectorSearchVectorizer baseModel = ModelReaderWriter.Read<VectorSearchVectorizer>(data, options);
            Assert.AreEqual("UnknownVectorSearchVectorizer", baseModel.GetType().Name);
            Assert.AreEqual(vectorizer.VectorizerName, baseModel.VectorizerName);
        }
#pragma warning restore CS0618

        [Test]
        public void FileCapacityDeserializesAndPersists()
        {
            BinaryData data = BinaryData.FromString("""
                {
                  "kind": "file",
                  "synchronizationStatus": "active",
                  "fileCapacity": {
                    "maxFileCount": 100,
                    "remainingFileCount": 75,
                    "maxFileSizeBytes": 5000000000
                  }
                }
                """);

            KnowledgeSourceStatus status = ModelReaderWriter.Read<KnowledgeSourceStatus>(data, SearchTestHelpers.WireOptions);
            Assert.IsNotNull(status.FileCapacity);
            Assert.AreEqual(100, status.FileCapacity.MaxFileCount);
            Assert.AreEqual(75, status.FileCapacity.RemainingFileCount);
            Assert.AreEqual(5000000000L, status.FileCapacity.MaxFileSizeBytes);

            BinaryData persisted = ModelReaderWriter.Write(status, ModelReaderWriterOptions.Json);
            KnowledgeSourceStatus restored = ModelReaderWriter.Read<KnowledgeSourceStatus>(persisted, ModelReaderWriterOptions.Json);
            Assert.AreEqual(status.FileCapacity.MaxFileCount, restored.FileCapacity.MaxFileCount);
            Assert.AreEqual(status.FileCapacity.RemainingFileCount, restored.FileCapacity.RemainingFileCount);
            Assert.AreEqual(status.FileCapacity.MaxFileSizeBytes, restored.FileCapacity.MaxFileSizeBytes);
        }

        /// <summary>
        /// Data source for model serialization roundtrip tests.
        /// Each entry: (modelType, jsonPayload).
        ///
        /// To add coverage for a new model, add one yield return line with representative JSON.
        /// </summary>
        public static IEnumerable<TestCaseData> ModelJsonPairs()
        {
            // SearchIndex — basic index definition
            yield return new TestCaseData(
                typeof(SearchIndex),
                @"{""name"":""hotels"",""fields"":[{""name"":""hotelId"",""type"":""Edm.String"",""key"":true,""searchable"":false,""filterable"":true,""sortable"":true,""facetable"":true}]}")
                .SetName("Roundtrip_SearchIndex");

            // SearchField — single field
            yield return new TestCaseData(
                typeof(SearchField),
                @"{""name"":""rating"",""type"":""Edm.Int32"",""filterable"":true,""sortable"":true,""facetable"":true}")
                .SetName("Roundtrip_SearchField");

            // ScoringProfile — with functions
            yield return new TestCaseData(
                typeof(ScoringProfile),
                @"{""name"":""boostGenre"",""text"":{""weights"":{""genre"":5}},""functions"":[]}")
                .SetName("Roundtrip_ScoringProfile");

            // SynonymMap
            yield return new TestCaseData(
                typeof(SynonymMap),
                @"{""name"":""test-synonyms"",""format"":""solr"",""synonyms"":""USA, United States, United States of America""}")
                .SetName("Roundtrip_SynonymMap");

            // SearchIndexerDataSourceConnection — minimal
            yield return new TestCaseData(
                typeof(SearchIndexerDataSourceConnection),
                @"{""name"":""test-ds"",""type"":""azureblob"",""credentials"":{""connectionString"":""fake""},""container"":{""name"":""test-container""}}")
                .SetName("Roundtrip_DataSourceConnection");

            // SearchIndexer — minimal
            yield return new TestCaseData(
                typeof(SearchIndexer),
                @"{""name"":""test-indexer"",""dataSourceName"":""test-ds"",""targetIndexName"":""test-index""}")
                .SetName("Roundtrip_SearchIndexer");

            // CorsOptions
            yield return new TestCaseData(
                typeof(CorsOptions),
                @"{""allowedOrigins"":[""https://example.com""],""maxAgeInSeconds"":300}")
                .SetName("Roundtrip_CorsOptions");

#if AZURE_SEARCH_PREVIEW
            // --- 2026-08-01-preview: new knowledge source polymorphic subtypes ---
            // Each carries the discriminator ("kind") and a nested parameters object; roundtrip exercises
            // the polymorphic dispatch in the KnowledgeSource base type plus the subtype's own serializer.

            // McpServerKnowledgeSource — MCP server with stored-headers auth and a tool that uses auto output parsing.
            yield return new TestCaseData(
                typeof(McpServerKnowledgeSource),
                @"{""name"":""mcp-ks"",""kind"":""mcpServer"",""mcpServerParameters"":{""serverURL"":""https://learn.microsoft.com/api/mcp"",""authentication"":{""kind"":""storedHeaders"",""storedHeadersParameters"":{""headers"":{""Authorization"":""Bearer fake""}}},""tools"":[{""name"":""microsoft_docs_search"",""outputParsing"":{""kind"":""auto""},""resultsProcessing"":""rerank""}]}}")
                .SetName("Roundtrip_McpServerKnowledgeSource");

            // FabricDataAgentKnowledgeSource
            yield return new TestCaseData(
                typeof(FabricDataAgentKnowledgeSource),
                @"{""name"":""fda-ks"",""kind"":""fabricDataAgent"",""fabricDataAgentParameters"":{""workspaceId"":""ws-123"",""dataAgentId"":""agent-456""}}")
                .SetName("Roundtrip_FabricDataAgentKnowledgeSource");

            // FabricOntologyKnowledgeSource
            yield return new TestCaseData(
                typeof(FabricOntologyKnowledgeSource),
                @"{""name"":""fo-ks"",""kind"":""fabricOntology"",""fabricOntologyParameters"":{""workspaceId"":""ws-123"",""ontologyId"":""ont-789""}}")
                .SetName("Roundtrip_FabricOntologyKnowledgeSource");

            // FileKnowledgeSource — parameterless parameters object, but kind must roundtrip.
            yield return new TestCaseData(
                typeof(FileKnowledgeSource),
                @"{""name"":""file-ks"",""kind"":""file"",""fileParameters"":{}}")
                .SetName("Roundtrip_FileKnowledgeSource");

            // IndexedSqlKnowledgeSource — content/embedding column mappings exercise ContentColumnMapping + EmbeddingColumnMapping serializers.
            yield return new TestCaseData(
                typeof(IndexedSqlKnowledgeSource),
                @"{""name"":""sql-ks"",""kind"":""indexedSql"",""indexedSqlParameters"":{""connectionString"":""Server=fake;Database=fake;"",""tableOrView"":""dbo.Articles"",""highWaterMarkColumnName"":""rowVersion"",""contentColumns"":[{""name"":""body""}],""embeddingColumns"":[{""name"":""embedding"",""sourceField"":""field""}]}}")
                .SetName("Roundtrip_IndexedSqlKnowledgeSource");

            // WorkIQKnowledgeSource — no parameters object, exercises base-only payload with new kind.
            yield return new TestCaseData(
                typeof(WorkIQKnowledgeSource),
                @"{""name"":""wiq-ks"",""kind"":""workIQ""}")
                .SetName("Roundtrip_WorkIQKnowledgeSource");

            // FreshnessPolicy — new knowledge-base-level retrieval policy.
            yield return new TestCaseData(
                typeof(FreshnessPolicy),
                @"{""boostingDuration"":""P90D""}")
                .SetName("Roundtrip_FreshnessPolicy");

            // KnowledgeBaseImageContent — newly given a public constructor + settable Url property in 12.1.0-beta.1.
            yield return new TestCaseData(
                typeof(KnowledgeBaseImageContent),
                @"{""url"":""https://example.com/img.png""}")
                .SetName("Roundtrip_KnowledgeBaseImageContent");

            // SearchIndexKnowledgeSourceParams — exercises the three new KnowledgeSourceParams properties
            // (failOnError, maxOutputDocuments, enableImageServing) added in 12.1.0-beta.1. The structural
            // comparison fails if any of these are dropped during serialization.
            yield return new TestCaseData(
                typeof(SearchIndexKnowledgeSourceParams),
                @"{""knowledgeSourceName"":""idx-ks"",""kind"":""searchIndex"",""failOnError"":true,""maxOutputDocuments"":25,""enableImageServing"":true}")
                .SetName("Roundtrip_KnowledgeSourceParams_NewProperties");
#endif
        }

        /// <summary>
        /// Verifies that a model type can roundtrip through ModelReaderWriter:
        /// Read from JSON → Write back to JSON → structural equivalence.
        /// </summary>
        [TestCaseSource(nameof(ModelJsonPairs))]
        public void JsonRoundtripPreservesStructure(Type modelType, string jsonPayload)
        {
            var binaryData = new BinaryData(Encoding.UTF8.GetBytes(jsonPayload));

            // Deserialize
            object instance;
            try
            {
                instance = ModelReaderWriter.Read(binaryData, modelType, SearchTestHelpers.WireOptions);
            }
            catch (Exception ex)
            {
                Assert.Fail($"ModelReaderWriter.Read failed for curated model {modelType.Name}: {ex}");
                return;
            }

            Assert.IsNotNull(instance, $"ModelReaderWriter.Read returned null for {modelType.Name}.");

            // Re-serialize
            BinaryData written;
            try
            {
                written = ModelReaderWriter.Write(instance, SearchTestHelpers.WireOptions);
            }
            catch (Exception ex)
            {
                Assert.Fail($"ModelReaderWriter.Write failed for curated model {modelType.Name}: {ex}");
                return;
            }

            Assert.IsNotNull(written, $"ModelReaderWriter.Write returned null for {modelType.Name}.");

            // Structural comparison — parse both as JSON and compare
            using var originalDoc = JsonDocument.Parse(jsonPayload);
            using var roundtrippedDoc = JsonDocument.Parse(written.ToString());

            AssertJsonStructurallyEquivalent(originalDoc.RootElement, roundtrippedDoc.RootElement, modelType.Name);
        }

        /// <summary>
        /// Asserts that two JSON elements are structurally equivalent.
        /// Every property in <paramref name="expected"/> must appear in <paramref name="actual"/>
        /// with the same value. Extra properties in <paramref name="actual"/> are allowed
        /// (the SDK may add default values during serialization).
        /// </summary>
        private static void AssertJsonStructurallyEquivalent(
            JsonElement expected,
            JsonElement actual,
            string context)
        {
            if (expected.ValueKind != actual.ValueKind)
            {
                Assert.Fail($"[{context}] Expected {expected.ValueKind} but got {actual.ValueKind}.");
            }

            switch (expected.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (var prop in expected.EnumerateObject())
                    {
                        if (!actual.TryGetProperty(prop.Name, out var actualProp))
                        {
                            Assert.Fail($"[{context}] Missing property '{prop.Name}' in roundtripped JSON.");
                        }
                        AssertJsonStructurallyEquivalent(prop.Value, actualProp, $"{context}.{prop.Name}");
                    }
                    break;

                case JsonValueKind.Array:
                    var expectedArray = expected.EnumerateArray().ToList();
                    var actualArray = actual.EnumerateArray().ToList();
                    Assert.AreEqual(expectedArray.Count, actualArray.Count,
                        $"[{context}] Array length mismatch: expected {expectedArray.Count}, got {actualArray.Count}.");
                    for (int i = 0; i < expectedArray.Count; i++)
                    {
                        AssertJsonStructurallyEquivalent(expectedArray[i], actualArray[i], $"{context}[{i}]");
                    }
                    break;

                case JsonValueKind.String:
                    Assert.AreEqual(expected.GetString(), actual.GetString(), $"[{context}] String value mismatch.");
                    break;

                case JsonValueKind.Number:
                    Assert.AreEqual(expected.GetDecimal(), actual.GetDecimal(), $"[{context}] Number value mismatch.");
                    break;

                case JsonValueKind.True:
                case JsonValueKind.False:
                    Assert.AreEqual(expected.GetBoolean(), actual.GetBoolean(), $"[{context}] Boolean value mismatch.");
                    break;
            }
        }
    }
}
