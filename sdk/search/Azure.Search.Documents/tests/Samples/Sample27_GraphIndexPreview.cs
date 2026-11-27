// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [RecordedTest]
        public async Task GraphIndexRelationshipsAndProvenance()
        {
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            string graphIndexName = PreviewName();
            string sourceIndexName = graphIndexName + "-source";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;
            #region Snippet:Azure_Search_Documents_Sample27_ProvenanceIndex
            SearchIndex sourceIndex = new SearchIndex(sourceIndexName)
            {
                Fields =
                {
                    new SimpleField("uid", SearchFieldDataType.String) { IsKey = true, IsFilterable = true },
                    new SearchableField("snippet"),
                    new SimpleField("snippet_parent_id", SearchFieldDataType.String) { IsFilterable = true }
                }
            };
            await indexClient.CreateIndexAsync(sourceIndex);
            #endregion
            resources.TrackIndex(sourceIndexName);

            #region Snippet:Azure_Search_Documents_Sample27_GraphIndex_Schema
            GraphFieldMappings mappings = new GraphFieldMappings(
                assertionIdField: "id", factIdField: "edge_hash",
                subjectField: "subject", predicateField: "predicate", objectField: "object",
                objectStringField: "object_string", objectDoubleField: "object_double",
                objectBoolField: "object_bool", objectDateTimeField: "object_datetime",
                subjectTypeField: "subject_type", subjectIdField: "subject_id",
                objectTypeField: "object_type", objectIdField: "object_id",
                confidenceField: "edge_confidence", subjectConfidenceField: "s_confidence",
                predicateConfidenceField: "p_confidence", objectConfidenceField: "o_confidence",
                sourceChunkIdField: "chunk_id", sourceParentIdField: "parent_id",
                graphNameField: "graph_name", subjectIdDisplayNameField: "subject_id_display_name",
                objectIdDisplayNameField: "object_id_display_name");
            SearchIndex graphIndex = new SearchIndex(graphIndexName)
            {
                GraphProfile = new GraphProfile(GraphProfileKind.EdgeList, mappings)
                {
                    ProvenanceIndexName = sourceIndexName
                }
            };
            foreach (string fieldName in new[]
            {
                "id", "edge_hash", "subject", "predicate", "object", "object_string",
                "subject_type", "subject_id", "object_type", "object_id", "graph_name",
                "chunk_id", "parent_id", "subject_id_display_name", "object_id_display_name"
            })
            {
                graphIndex.Fields.Add(new SimpleField(fieldName, SearchFieldDataType.String)
                {
                    IsKey = fieldName == "id",
                    IsFilterable = true,
                    IsFacetable = true,
                    IsSortable = true
                });
            }
            foreach (string fieldName in new[] { "object_double", "edge_confidence", "s_confidence", "p_confidence", "o_confidence" })
            {
                graphIndex.Fields.Add(new SimpleField(fieldName, SearchFieldDataType.Double)
                {
                    IsFilterable = true,
                    IsFacetable = true,
                    IsSortable = true
                });
            }
            graphIndex.Fields.Add(new SimpleField("object_bool", SearchFieldDataType.Boolean) { IsFilterable = true });
            graphIndex.Fields.Add(new SimpleField("object_datetime", SearchFieldDataType.DateTimeOffset) { IsFilterable = true });
            await indexClient.CreateIndexAsync(graphIndex);
            #endregion
            resources.TrackIndex(graphIndexName);
            Assert.That((await indexClient.GetIndexAsync(graphIndexName)).Value.GraphProfile.ProvenanceIndexName,
                Is.EqualTo(sourceIndexName));

            #region Snippet:Azure_Search_Documents_Sample27_GraphIndex_Data
            SearchDocument chunk = new SearchDocument
            {
                ["uid"] = "harbor-operator",
                ["snippet"] = "Historic Harbor Hotel is operated by Contoso Hospitality.",
                ["snippet_parent_id"] = "harbor-brochure"
            };
            SearchDocument assertion = new SearchDocument
            {
                ["id"] = "assertion-1",
                ["edge_hash"] = "fact-1",
                ["subject"] = "Historic Harbor Hotel",
                ["subject_type"] = "Hotel",
                ["subject_id"] = "hotel:harbor",
                ["predicate"] = "operatedBy",
                ["object"] = "Contoso Hospitality",
                ["object_string"] = "Contoso Hospitality",
                ["object_type"] = "Organization",
                ["object_id"] = "organization:contoso",
                ["graph_name"] = "hotels",
                ["edge_confidence"] = 1.0,
                ["s_confidence"] = 1.0,
                ["p_confidence"] = 1.0,
                ["o_confidence"] = 1.0,
                ["chunk_id"] = "harbor-operator",
                ["parent_id"] = "harbor-brochure",
                ["subject_id_display_name"] = "Historic Harbor Hotel",
                ["object_id_display_name"] = "Contoso Hospitality"
            };
            SearchClient sourceClient = new SearchClient(endpoint, sourceIndexName, credential);
            SearchClient graphClient = new SearchClient(endpoint, graphIndexName, credential);
#if !SNIPPET
            sourceClient = CreatePreviewSearchClient(resources, sourceIndexName);
            graphClient = CreatePreviewSearchClient(resources, graphIndexName);
#endif
            await UploadPreviewDocumentsAsync(sourceClient, new[] { chunk });
            await UploadPreviewDocumentsAsync(graphClient, new[] { assertion });
            #endregion

            #region Snippet:Azure_Search_Documents_Sample27_GraphIndex_Query
            string gql = "MATCH (h:Hotel)-[r:operatedBy]->(o:Organization) " +
                "WHERE h.id = 'hotel:harbor' RETURN h.name AS hotel, o.name AS organization";
            GraphQueryResult plan = await graphClient.GraphAsync(gql,
                filter: "graph_name eq 'hotels'",
                executionMode: GraphQueryExecutionMode.PlanOnly,
                explain: new[] { GraphQueryExplainStage.PhysicalPlan },
                includeStatistics: true, includeDiagnostics: true);
            GraphQueryResult result = await graphClient.GraphAsync(gql,
                filter: "graph_name eq 'hotels'",
                provenance: new GraphQueryProvenanceParameters(GraphQueryProvenanceKind.Ids) { MaxEvidencePerRow = 5 },
                includeStatistics: true, includeDiagnostics: true);
            foreach (GraphQueryRow row in result.Value)
            {
                Console.WriteLine($"{row.AdditionalProperties["hotel"]}: {row.AdditionalProperties["organization"]}");
                foreach (GraphQueryEvidence evidence in row.Provenance.Evidence)
                {
                    Console.WriteLine($"Supporting chunk: {evidence.ChunkId}; parent: {evidence.ParentId}");
                }
            }
            foreach (GraphQueryDiagnostic diagnostic in result.Diagnostics)
            {
                Console.WriteLine($"{diagnostic.Severity}/{diagnostic.Phase}: {diagnostic.Code}");
            }
            #endregion
            Assert.That(plan.Value, Is.Empty);
            Assert.That(plan.Statistics.QueryCount, Is.Zero);
            Assert.That(result.Value.Single().AdditionalProperties["organization"].ToObjectFromJson<string>(),
                Is.EqualTo("Contoso Hospitality"));
            Assert.That(result.Value.Single().Provenance.Evidence.Any(evidence =>
                evidence.EdgeId == "assertion-1" && evidence.ChunkId == "harbor-operator" && evidence.ParentId == "harbor-brochure"), Is.True);
            Assert.That(result.Statistics.QueryCount, Is.GreaterThan(0));
        }
    }
}
