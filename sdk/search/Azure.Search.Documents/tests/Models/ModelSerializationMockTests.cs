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

            // --- 2026-05-01-preview: new knowledge source polymorphic subtypes ---
            // Each carries the discriminator ("kind") and a nested parameters object; roundtrip exercises
            // the polymorphic dispatch in the KnowledgeSource base type plus the subtype's own serializer.

            // McpServerKnowledgeSource — MCP server with stored-headers auth and a tool that uses auto output parsing.
            yield return new TestCaseData(
                typeof(McpServerKnowledgeSource),
                @"{""name"":""mcp-ks"",""kind"":""mcpServer"",""mcpServerParameters"":{""serverURL"":""https://learn.microsoft.com/api/mcp"",""authentication"":{""kind"":""storedHeaders"",""storedHeadersParameters"":{""headers"":{""Authorization"":""Bearer fake""}}},""tools"":[{""name"":""microsoft_docs_search"",""outputParsing"":{""kind"":""auto""},""inclusionMode"":""always""}]}}")
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
