# Populate and query a graph index with provenance

Use the [common preview setup](Sample23_NovemberPreview.md). The complete
`GraphIndexRelationshipsAndProvenance` flow is in
[`Sample27_GraphIndexPreview.cs`](../tests/Samples/Sample27_GraphIndexPreview.cs).
It needs graph-query support but no customer model deployment.

## Define the provenance and edge-list indexes

Use unique `sourceIndexName` and `graphIndexName`. Supporting source text is
indexed separately from graph assertions.

```C# Snippet:Azure_Search_Documents_Sample27_ProvenanceIndex
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
```

```C# Snippet:Azure_Search_Documents_Sample27_GraphIndex_Schema
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
        IsKey = fieldName == "id", IsFilterable = true, IsFacetable = true, IsSortable = true
    });
}
foreach (string fieldName in new[] { "object_double", "edge_confidence", "s_confidence", "p_confidence", "o_confidence" })
{
    graphIndex.Fields.Add(new SimpleField(fieldName, SearchFieldDataType.Double)
    {
        IsFilterable = true, IsFacetable = true, IsSortable = true
    });
}
graphIndex.Fields.Add(new SimpleField("object_bool", SearchFieldDataType.Boolean) { IsFilterable = true });
graphIndex.Fields.Add(new SimpleField("object_datetime", SearchFieldDataType.DateTimeOffset) { IsFilterable = true });
await indexClient.CreateIndexAsync(graphIndex);
```

## Upload a supporting chunk and a hotel/operator assertion

```C# Snippet:Azure_Search_Documents_Sample27_GraphIndex_Data
SearchDocument chunk = new SearchDocument
{
    ["uid"] = "harbor-operator",
    ["snippet"] = "Historic Harbor Hotel is operated by Contoso Hospitality.",
    ["snippet_parent_id"] = "harbor-brochure"
};
SearchDocument assertion = new SearchDocument
{
    ["id"] = "assertion-1", ["edge_hash"] = "fact-1",
    ["subject"] = "Historic Harbor Hotel", ["subject_type"] = "Hotel", ["subject_id"] = "hotel:harbor",
    ["predicate"] = "operatedBy", ["object"] = "Contoso Hospitality", ["object_string"] = "Contoso Hospitality",
    ["object_type"] = "Organization", ["object_id"] = "organization:contoso", ["graph_name"] = "hotels",
    ["edge_confidence"] = 1.0, ["s_confidence"] = 1.0, ["p_confidence"] = 1.0, ["o_confidence"] = 1.0,
    ["chunk_id"] = "harbor-operator", ["parent_id"] = "harbor-brochure",
    ["subject_id_display_name"] = "Historic Harbor Hotel", ["object_id_display_name"] = "Contoso Hospitality"
};
SearchClient sourceClient = new SearchClient(endpoint, sourceIndexName, credential);
SearchClient graphClient = new SearchClient(endpoint, graphIndexName, credential);
await UploadPreviewDocumentsAsync(sourceClient, new[] { chunk });
await UploadPreviewDocumentsAsync(graphClient, new[] { assertion });
```

## Explain, execute and inspect evidence

```C# Snippet:Azure_Search_Documents_Sample27_GraphIndex_Query
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
```

The sample verifies the actual Contoso relationship and its assertion, chunk and
parent identifiers. It checks plan-only execution separately from execution
statistics. Use typed diagnostic severity/phase and stable codes, not parsed
human-readable messages. Explain plans are diagnostics, not executable contracts.
Delete the graph index before its provenance index.

For model-extracted relationships and graph-backed KB retrieval, see the
[managed graph walkthrough](Sample30_GraphExtractionPreview.md).
