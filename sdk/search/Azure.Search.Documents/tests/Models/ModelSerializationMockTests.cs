// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
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
            // search-preview:2026-11-01-preview {
            yield return new TestCaseData(
                typeof(SearchIndex),
                """
                {
                  "name":"topics",
                  "fields":[
                    {"name":"id","type":"Edm.String","key":true},
                    {"name":"embedding","type":"Collection(Edm.Single)","searchable":true,"dimensions":2,"vectorSearchProfile":"vector-profile","topicGraphProfile":"topic-profile"}
                  ],
                  "vectorSearch":{
                    "profiles":[{"name":"vector-profile","algorithm":"hnsw"}],
                    "algorithms":[{"name":"hnsw","kind":"hnsw"}],
                    "topicGraphProfiles":[{"name":"topic-profile","indexName":"topic-index","defaultKind":"diverse","defaultDiversityFactor":0.5,"defaultMinDiversityPoolSize":1000}]
                  }
                }
                """)
                .SetName("Roundtrip_SearchIndex_TopicGraphProfile");

            yield return new TestCaseData(
                typeof(SearchIndex),
                """
                {
                  "name":"graph",
                  "fields":[{"name":"id","type":"Edm.String","key":true}],
                  "graphProfile":{
                    "kind":"edgeList","provenanceIndexName":"chunks",
                    "fields":{
                      "assertionIdField":"id","factIdField":"fact","subjectField":"subject","predicateField":"predicate",
                      "objectField":"object","objectStringField":"objectString","objectDoubleField":"objectDouble",
                      "objectBoolField":"objectBool","objectDateTimeField":"objectDateTime","subjectTypeField":"subjectType",
                      "subjectIdField":"subjectId","objectTypeField":"objectType","objectIdField":"objectId",
                      "confidenceField":"confidence","subjectConfidenceField":"subjectConfidence",
                      "predicateConfidenceField":"predicateConfidence","objectConfidenceField":"objectConfidence",
                      "sourceChunkIdField":"chunkId","sourceParentIdField":"parentId","graphNameField":"graphName",
                      "subjectIdDisplayNameField":"subjectName","objectIdDisplayNameField":"objectName"
                    }
                  }
                }
                """)
                .SetName("Roundtrip_SearchIndex_GraphRoleMappings");

            yield return new TestCaseData(
                typeof(KnowledgeSource),
                """
                {
                  "name":"index-source","kind":"searchIndex",
                  "searchIndexParameters":{"searchIndexName":"chunks","topicGraph":{"kind":"balanced","minDiversityPoolSize":1000}}
                }
                """)
                .SetName("Roundtrip_KnowledgeSource_IndexTopicGraph");

            yield return new TestCaseData(
                typeof(KnowledgeSource),
                """
                {
                  "name":"blob-source","kind":"azureBlob",
                  "azureBlobParameters":{
                    "connectionString":"ResourceId=/subscriptions/fake/storageAccounts/source;","containerName":"documents",
                    "topicGraph":{"kind":"diverse","diversityFactor":0.5,"minDiversityPoolSize":1000},
                    "graphExtraction":{
                      "graphName":"entities",
                      "ontology":{"kind":"inline","name":"customer-ontology","value":"{\"@context\":{},\"@graph\":[]}"},
                      "grounding":{"kind":"searchIndex","index":{"indexName":"grounding","vectorFieldName":"embedding"}},
                      "pageDegreeOfParallelism":8
                    },
                    "ingestionParameters":{
                      "cache":{"storageConnectionString":"ResourceId=/subscriptions/fake/storageAccounts/cache;","enableReprocessing":true,"identity":null},
                      "chatCompletionModel":{"kind":"azureOpenAI","azureOpenAIParameters":{"resourceUri":"https://model.example.com/","deploymentId":"chat","modelName":"gpt-5-mini"}}
                    }
                  }
                }
                """)
                .SetName("Roundtrip_KnowledgeSource_GraphExtractionAndCache");

            yield return new TestCaseData(
                typeof(SearchIndex),
                """
                {
                  "name":"secured",
                  "fields":[
                    {"name":"id","type":"Edm.String","key":true},
                    {"name":"folders","type":"Collection(Edm.String)","filterable":true,"permissionFilter":"oneLakeParentFolders"},
                    {"name":"lakehouse","type":"Edm.String","filterable":true,"permissionFilter":"oneLakeLakehouseId"}
                  ],
                  "oneLakeSecuritySource":{"fabricWorkspaceId":"11111111-1111-1111-1111-111111111111","lakehouseId":"22222222-2222-2222-2222-222222222222"}
                }
                """)
                .SetName("Roundtrip_SearchIndex_OneLakePermissions");

            yield return new TestCaseData(
                typeof(KnowledgeSource),
                """
                {
                  "name":"onelake-source","kind":"indexedOneLake",
                  "indexedOneLakeParameters":{
                    "fabricWorkspaceId":"11111111-1111-1111-1111-111111111111","lakehouseId":"22222222-2222-2222-2222-222222222222",
                    "targetPath":"Files/documents",
                    "ingestionParameters":{"ingestionPermissionOptions":["oneLakeParentFolders","oneLakeLakehouseId"]}
                  }
                }
                """)
                .SetName("Roundtrip_KnowledgeSource_OneLakePermissionIngestion");

            yield return new TestCaseData(
                typeof(KnowledgeBase),
                """
                {
                  "name":"kb","knowledgeSources":[{"name":"source"}],
                  "models":[{"kind":"microsoftRetriever1"}],
                  "tools":[{
                    "name":"company-docs","description":"Search company documents",
                    "knowledgeSources":[{"name":"source","alwaysQuerySource":true,"filterAddOn":"category eq 'company'","rerankerThreshold":2.5,"maxOutputDocuments":50,"failOnError":true}],
                    "retrievalReasoningEffort":{"kind":"minimal"},
                    "retrieveDefaults":{"maxRuntimeInSeconds":30,"maxOutputDocuments":50,"maxOutputSizeInTokens":2000}
                  }]
                }
                """)
                .SetName("Roundtrip_KnowledgeBase_RetrieverAndTools");

            yield return new TestCaseData(
                typeof(KnowledgeBase),
                """
                {
                  "name":"kb","knowledgeSources":[{"name":"source"}],
                  "models":[{"kind":"openAICompatible","openAICompatibleParameters":{
                    "uri":"https://gateway.example.com/responses?route=chat","modelName":"gpt-6-sol",
                    "headers":{"Authorization":"Bearer fake-test-token","X-Route":"chat"}
                  }}]
                }
                """)
                .SetName("Roundtrip_KnowledgeBase_OpenAICompatibleHeaders");

            yield return new TestCaseData(
                typeof(SearchIndex),
                """
                {
                  "name":"apim","fields":[{"name":"id","type":"Edm.String","key":true}],
                  "vectorSearch":{"vectorizers":[{
                    "name":"embeddings","kind":"openAICompatible",
                    "openAICompatibleParameters":{"uri":"https://gateway.example.com/embeddings?route=small","modelName":"text-embedding-3-small","dimensions":256,"headers":{"api-key":"fake-test-key"}}
                  }]}
                }
                """)
                .SetName("Roundtrip_SearchIndex_OpenAICompatibleVectorizer");

            yield return new TestCaseData(
                typeof(KnowledgeSource),
                """
                {
                  "name":"file-source","kind":"file","fileParameters":{"ingestionParameters":{
                    "embeddingModel":{"kind":"openAICompatible","openAICompatibleParameters":{
                      "uri":"https://gateway.example.com/embeddings?route=large","modelName":"text-embedding-3-large","dimensions":1024,
                      "managedIdentityAudience":"11111111-1111-1111-1111-111111111111",
                      "authIdentity":{"@odata.type":"#Microsoft.Azure.Search.DataUserAssignedIdentity","userAssignedIdentity":"/subscriptions/fake/resourceGroups/fake/providers/Microsoft.ManagedIdentity/userAssignedIdentities/ingestion"}
                    }},
                    "chatCompletionModel":{"kind":"openAICompatible","openAICompatibleParameters":{
                      "uri":"https://gateway.example.com/chat/completions?route=images","modelName":"gpt-5-mini",
                      "managedIdentityAudience":"11111111-1111-1111-1111-111111111111"
                    }}
                  }}
                }
                """)
                .SetName("Roundtrip_KnowledgeSource_OpenAICompatibleManagedIdentity");

            yield return new TestCaseData(
                typeof(SearchIndexerSkill),
                """
                {
                  "@odata.type":"#Microsoft.Skills.Custom.ChatCompletionSkill","name":"gateway-chat",
                  "inputs":[{"name":"text","source":"/document/content"}],"outputs":[{"name":"response","targetName":"summary"}],
                  "uri":"https://gateway.example.com/chat/completions?api-version=2026-11-01",
                  "apiKey":"fake-test-key","commonModelParameters":{"model":"gpt-5-mini"},
                  "extraParameters":{"max_completion_tokens":256}
                }
                """)
                .SetName("Roundtrip_Skill_GatewayChatCompletion");
            // search-preview:2026-11-01-preview }

            // --- Preview knowledge source polymorphic subtypes ---
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
                typeof(KnowledgeSourceFreshnessPolicy),
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

        [Test]
        public void AgenticReasoningFactorySupportsGaOptionalArguments()
        {
            KnowledgeBaseAgenticReasoningActivityRecord record = SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord();
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
        }

        [Test]
        public void AgenticReasoningFactorySupportsGaNullArguments()
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
        public void AgenticReasoningFactoryPreservesGaAndPreviewFields()
        {
            var effort = new KnowledgeRetrievalMinimalReasoningEffort();
            var record = SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, null, null, 12, effort);
            Assert.AreSame(effort, record.RetrievalReasoningEffort);
            Assert.AreSame(effort, SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(retrievalReasoningEffort: effort).RetrievalReasoningEffort);
            using (JsonDocument serialized = JsonDocument.Parse(ModelReaderWriter.Write(record, SearchTestHelpers.WireOptions)))
            {
                Assert.AreEqual("minimal", serialized.RootElement.GetProperty("retrievalReasoningEffort").GetProperty("kind").GetString());
                Assert.AreEqual(12, serialized.RootElement.GetProperty("reasoningTokens").GetInt32());
            }

            DateTimeOffset startedOn = new DateTimeOffset(2026, 10, 1, 1, 0, 0, TimeSpan.Zero);
            DateTimeOffset completedOn = startedOn.AddMilliseconds(100);
            record = SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, startedOn, completedOn, 100, null, "warning", 12);
            Assert.AreEqual(startedOn, record.StartedOn);
            Assert.AreEqual(completedOn, record.CompletedOn);
            Assert.AreEqual(100, record.ElapsedMs);
            Assert.AreEqual("warning", record.Warning);
            Assert.AreEqual(12, record.ReasoningTokens);

            record = SearchModelFactory.KnowledgeBaseAgenticReasoningActivityRecord(1, startedOn, completedOn, 100, null, "warning", 12, effort, effort);
            Assert.AreSame(effort, record.RetrievalReasoningEffort);
            Assert.AreSame(effort, record.LogicalReasoningEffort);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("future-value")]
        public void NullableEnumConversionsPreserveNullAndUnknownValues(string value)
        {
            AzureOpenAIModelName? modelName = value;
            KnowledgeSourceResultsProcessing? resultsProcessing = value;

            Assert.AreEqual(value, modelName?.ToString());
            Assert.AreEqual(value, resultsProcessing?.ToString());
        }

        [Test]
        public void VectorQueryFactorySupportsOmittedAndNamedArguments()
        {
            VectorQuery query = SearchModelFactory.VectorQuery(kNearestNeighborsCount: 3, fieldsRaw: "vector", kind: "vector");

            Assert.AreEqual(3, query.KNearestNeighborsCount);
            CollectionAssert.AreEqual(new[] { "vector" }, query.Fields);
            Assert.IsNull(query.Exhaustive);
            Assert.IsNull(query.Weight);
        }

        [Test]
        public void KnowledgeSourceFactorySupportsOmittedAndNamedArguments()
        {
            KnowledgeSource source = SearchModelFactory.KnowledgeSource(name: "hotels-ks", kind: "searchIndex");

            Assert.AreEqual("hotels-ks", source.Name);
            Assert.IsNull(source.Description);
            Assert.IsNull(source.EncryptionKey);
        }

        [Test]
        public void FacetResultFactoriesSupportOmittedCount()
        {
            FacetResult objectFacet = SearchModelFactory.FacetResult(
                additionalProperties: new Dictionary<string, object> { ["value"] = "Luxury" });
            FacetResult binaryFacet = SearchModelFactory.FacetResult(
                additionalProperties: new Dictionary<string, BinaryData> { ["value"] = BinaryData.FromObjectAsJson("Luxury") });

            foreach (FacetResult facet in new[] { objectFacet, binaryFacet })
            {
                Assert.IsNull(facet.Count);
                Assert.AreEqual("Luxury", facet.Value);
            }
        }

        [Test]
        public void FacetResultFactoryPreservesPreviewShortCallsAndMetrics()
        {
            Assert.IsNull(SearchModelFactory.FacetResult().Count);
            Assert.AreEqual(2, SearchModelFactory.FacetResult(count: 2).Count);
            FacetResult metrics = SearchModelFactory.FacetResult(avg: 3, min: 1, max: 5);
            Assert.AreEqual(3, metrics.Avg);
            Assert.AreEqual(1, metrics.Min);
            Assert.AreEqual(5, metrics.Max);
        }

        [Test]
        public void SearchIndexFactorySupportsEnumerableFieldsWithOmittedArguments()
        {
            SearchField field = new SearchField("id", SearchFieldDataType.String) { IsKey = true };
            IEnumerable<SearchField> fields = new[] { field, null }.Where(f => f != null);
            ScoringProfile profile = new ScoringProfile("default");
            IEnumerable<ScoringProfile> profiles = new[] { profile }.Where(p => p != null);

            SearchIndex index = SearchModelFactory.SearchIndex(name: "hotels", fields: fields, scoringProfiles: profiles);

            Assert.AreEqual("hotels", index.Name);
            CollectionAssert.AreEqual(new[] { field }, index.Fields);
            Assert.IsNull(index.Description);
            CollectionAssert.AreEqual(new[] { profile }, index.ScoringProfiles);
        }

        [Test]
        public void KnowledgeSourceFactoriesSupportGaPartialPositionalArguments()
        {
            ETag eTag = new ETag("etag");
            KnowledgeSource[] sources =
            {
                SearchModelFactory.AzureBlobKnowledgeSource("source", "description", eTag),
                SearchModelFactory.IndexedOneLakeKnowledgeSource("source", "description", eTag),
                SearchModelFactory.SearchIndexKnowledgeSource("source", "description", eTag),
                SearchModelFactory.WebKnowledgeSource("source", "description", eTag)
            };

            foreach (KnowledgeSource source in sources)
            {
                Assert.AreEqual("source", source.Name);
                Assert.AreEqual("description", source.Description);
                Assert.AreEqual(eTag, source.ETag);
                Assert.IsNull(source.ResultsProcessing);
                Assert.IsNull(source.EncryptionKey);
            }
        }

        [Test]
        public void SynchronizationFactoriesSupportGaPartialPositionalArguments()
        {
            DateTimeOffset started = DateTimeOffset.Parse("2026-11-01T00:00:00Z");
            DateTimeOffset completed = started.AddMinutes(1);
            SynchronizationState state = SearchModelFactory.SynchronizationState(started, 3);
            CompletedSynchronizationState completedState = SearchModelFactory.CompletedSynchronizationState(started, completed, 3);

            Assert.AreEqual(started, state.StartTime);
            Assert.AreEqual(3, state.ItemsUpdatesProcessed);
            Assert.AreEqual(0, state.ItemsUpdatesFailed);
            Assert.IsNull(state.GraphStatistics);
            Assert.AreEqual(started, completedState.StartTime);
            Assert.AreEqual(completed, completedState.EndTime);
            Assert.AreEqual(3, completedState.ItemsUpdatesProcessed);
            Assert.IsNull(completedState.GraphStatistics);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ScoringFunctionsSupportGaNamedConstructors(string format)
        {
            ScoringFunction[] functions =
            {
                new DistanceScoringFunction(fieldName: "field", boost: 2.0,
                    parameters: new DistanceScoringParameters("referencePoint", 10)),
                new FreshnessScoringFunction(fieldName: "field", boost: 2.0,
                    parameters: new FreshnessScoringParameters(TimeSpan.FromDays(7))),
                new MagnitudeScoringFunction(fieldName: "field", boost: 2.0,
                    parameters: new MagnitudeScoringParameters(0, 5)),
                new TagScoringFunction(fieldName: "field", boost: 2.0,
                    parameters: new TagScoringParameters("preferredTags"))
            };

            foreach (ScoringFunction function in functions)
            {
                function.Interpolation = ScoringFunctionInterpolation.Linear;
                var options = new ModelReaderWriterOptions(format);
                BinaryData json = ModelReaderWriter.Write(function, options);
                using JsonDocument document = JsonDocument.Parse(json);
                Assert.AreEqual("field", document.RootElement.GetProperty("fieldName").GetString());
                Assert.AreEqual(2.0, document.RootElement.GetProperty("boost").GetDouble());
                Assert.AreEqual(1, document.RootElement.EnumerateObject().Count(property => property.Name == "fieldName"));
                Assert.AreEqual(1, document.RootElement.EnumerateObject().Count(property => property.Name == "boost"));
                Assert.AreEqual("linear", document.RootElement.GetProperty("interpolation").GetString());
                ScoringFunction roundtrip = ModelReaderWriter.Read<ScoringFunction>(json, options);
                Assert.AreEqual(function.GetType(), roundtrip.GetType());
                Assert.AreEqual(function.FieldName, roundtrip.FieldName);
                Assert.AreEqual(function.Boost, roundtrip.Boost);
                Assert.AreEqual(function.Interpolation, roundtrip.Interpolation);
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void CustomerScoringFunctionPreservesCommonFields(string format)
        {
            ScoringFunction function = new CustomerScoringFunction();
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<ScoringFunction>)function).Write(writer, new ModelReaderWriterOptions(format));
            }
            using JsonDocument document = JsonDocument.Parse(stream.ToArray());
            JsonElement root = document.RootElement;
            Assert.AreEqual("rating", root.GetProperty("fieldName").GetString());
            Assert.AreEqual(2.0, root.GetProperty("boost").GetDouble());
            Assert.AreEqual("magnitude", root.GetProperty("type").GetString());
            Assert.AreEqual(5, root.GetProperty("magnitude").GetProperty("boostingRangeEnd").GetInt32());
            Assert.AreEqual(1, root.EnumerateObject().Count(property => property.Name == "fieldName"));
            Assert.AreEqual(1, root.EnumerateObject().Count(property => property.Name == "boost"));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void RandomScoringFunctionPersistsLegacyFieldsButOmitsThemOnWire(string format)
        {
            ScoringFunction function = new RandomScoringFunction { FieldName = "rating", Boost = 2.0 };
            using JsonDocument document = JsonDocument.Parse(
                ModelReaderWriter.Write(function, new ModelReaderWriterOptions(format)));
            Assert.AreEqual("random", document.RootElement.GetProperty("type").GetString());
            if (format == "W")
            {
                Assert.IsFalse(document.RootElement.TryGetProperty("fieldName", out _));
                Assert.IsFalse(document.RootElement.TryGetProperty("boost", out _));
            }
            else
            {
                Assert.AreEqual("rating", document.RootElement.GetProperty("fieldName").GetString());
                Assert.AreEqual(2.0, document.RootElement.GetProperty("boost").GetDouble());
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void PersistedRandomScoringRetainsLegacyValuesWithoutStaleJson(string format)
        {
            BinaryData data = BinaryData.FromString(
                """{"type":"random","fieldName":"rating","boost":2,"interpolation":"linear","random":{"seedParameter":"seed"},"future":{"enabled":true}}""");
            var options = new ModelReaderWriterOptions(format);
            foreach (ScoringFunction function in new ScoringFunction[]
            {
                ModelReaderWriter.Read<ScoringFunction>(data, options),
                ModelReaderWriter.Read<RandomScoringFunction>(data, options)
            })
            {
                Assert.IsInstanceOf<RandomScoringFunction>(function);
                Assert.AreEqual("rating", function.FieldName);
                Assert.AreEqual(2, function.Boost);
                Assert.AreEqual(ScoringFunctionInterpolation.Linear, function.Interpolation);
                Assert.AreEqual("seed", ((RandomScoringFunction)function).Parameters.SeedParameter);
                function.FieldName = "updated";
                function.Boost = 3;

                BinaryData persisted = ModelReaderWriter.Write(function);
                using JsonDocument json = JsonDocument.Parse(persisted);
                Assert.AreEqual("updated", json.RootElement.GetProperty("fieldName").GetString());
                Assert.AreEqual(3, json.RootElement.GetProperty("boost").GetDouble());
                Assert.AreEqual(1, json.RootElement.EnumerateObject().Count(property => property.Name == "fieldName"));
                Assert.AreEqual(1, json.RootElement.EnumerateObject().Count(property => property.Name == "boost"));
                Assert.AreEqual(format == "J", json.RootElement.TryGetProperty("future", out _));
                ScoringFunction roundtrip = ModelReaderWriter.Read<ScoringFunction>(persisted);
                Assert.AreEqual("updated", roundtrip.FieldName);
                Assert.AreEqual(3, roundtrip.Boost);

                using JsonDocument wire = JsonDocument.Parse(ModelReaderWriter.Write(function, SearchTestHelpers.WireOptions));
                Assert.IsFalse(wire.RootElement.TryGetProperty("fieldName", out _));
                Assert.IsFalse(wire.RootElement.TryGetProperty("boost", out _));
                Assert.IsFalse(wire.RootElement.TryGetProperty("future", out _));
                Assert.AreEqual("seed", wire.RootElement.GetProperty("random").GetProperty("seedParameter").GetString());
            }
        }

        [TestCase("J")]
        [TestCase("W")]
        public void McpServerUriPreservesWireProperty(string format)
        {
            Uri uri = new Uri("https://example.com/mcp?api-version=preview");
            var parameters = new McpServerKnowledgeSourceParameters(uri, new[] { new McpServerTool { Name = "search" } });
            var options = new ModelReaderWriterOptions(format);
            BinaryData data = ModelReaderWriter.Write(parameters, options);
            using JsonDocument json = JsonDocument.Parse(data);
            Assert.AreEqual(uri.AbsoluteUri, json.RootElement.GetProperty("serverURL").GetString());
            Assert.IsFalse(json.RootElement.TryGetProperty("serverUri", out _));
            Assert.AreEqual(uri, ModelReaderWriter.Read<McpServerKnowledgeSourceParameters>(data, options).ServerUri);
        }

        private sealed class CustomerScoringFunction : ScoringFunction
        {
            public CustomerScoringFunction() : base("rating", 2.0, "magnitude")
            {
            }

            protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            {
                base.JsonModelWriteCore(writer, options);
                writer.WritePropertyName("magnitude");
                writer.WriteStartObject();
                writer.WriteNumber("boostingRangeStart", 0);
                writer.WriteNumber("boostingRangeEnd", 5);
                writer.WriteEndObject();
            }
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
