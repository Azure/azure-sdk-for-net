# Execute a chat completion skill and inspect enriched hotel facts

Use the [common preview setup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample23_NovemberPreview.md). The complete
`ChatCompletionSkillIndexesGroundedHotelFacts` example is in
[`Sample32_ChatCompletionSkillPreview.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/tests/Samples/Sample32_ChatCompletionSkillPreview.cs).
It requires the approved one-file synthetic Blob fixture and approval variables
from the [compatible-ingestion walkthrough](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample31_CompatibleEmbeddingsPreview.md).
Upload [`data/hotel_graph.txt`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/data/hotel_graph.txt) as the only file under a
dedicated prefix in your own container; see the
[sample-data setup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample23_NovemberPreview.md#supply-your-own-resources-and-sample-data).
The sample reads the fixture; it does not upload/delete source files.

Set `SEARCH_SKILL_CHAT_URI` to the full existing HTTPS `/chat/completions` route
and `SEARCH_SKILL_CHAT_API_KEY` to its matching key. This public SDK type is
`ChatCompletionSkill`, not an older draft `GenAiPromptSkill`. Its authentication
contract is `ApiKey` or the supported Azure identity configuration, not compatible
provider `Headers`/`ManagedIdentityAudience`. Do not use a Responses-only GPT-6
deployment here.

## Connect the skill, indexer and output field

Use a unique `name`, the approved `folder`, and a `SearchIndexerClient indexers`:

```C# Snippet:Azure_Search_Documents_Sample32_ChatCompletionSkill
ChatCompletionSkill skill = new ChatCompletionSkill(
    new[]
    {
        new InputFieldMappingEntry("systemMessage") { Source = "='Extract only hotel facts explicitly in the text.'" },
        new InputFieldMappingEntry("userMessage") { Source = "='List each hotel with its city, founding year, operator and amenities, if given.'" },
        new InputFieldMappingEntry("text") { Source = "/document/content" }
    },
    new[] { new OutputFieldMappingEntry("response") { TargetName = "hotelFacts" } }, uri)
{
    Name = "hotel-facts",
    Context = "/document",
    ApiKey = RequiredPreviewSetting("SEARCH_SKILL_CHAT_API_KEY")
};
await indexClient.CreateIndexAsync(new SearchIndex(name)
{
    Fields =
    {
        new SimpleField("id", SearchFieldDataType.String) { IsKey = true },
        new SearchableField("content"),
        new SearchableField("hotelFacts")
    }
});
await indexers.CreateDataSourceConnectionAsync(new SearchIndexerDataSourceConnection(
    name, SearchIndexerDataSourceType.AzureBlob,
    RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_BLOB_CONNECTION_STRING"),
    new SearchIndexerDataContainer(RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_BLOB_CONTAINER")) { Query = folder }));
await indexers.CreateSkillsetAsync(new SearchIndexerSkillset(name, new[] { skill }));
await indexers.CreateIndexerAsync(new SearchIndexer(name, name, name)
{
    SkillsetName = name,
    Parameters = new IndexingParameters
    {
        BatchSize = 1,
        MaxFailedItems = 0,
        MaxFailedItemsPerBatch = 0,
        IndexingParametersConfiguration = new IndexingParametersConfiguration
        {
            IndexedFileNameExtensions = ".txt",
            FailOnUnsupportedContentType = true,
            FailOnUnprocessableDocument = true
        }
    },
    FieldMappings =
    {
        new FieldMapping("metadata_storage_path")
        {
            TargetFieldName = "id",
            MappingFunction = new FieldMappingFunction("base64Encode")
        }
    },
    OutputFieldMappings = { new FieldMapping("/document/hotelFacts") { TargetFieldName = "hotelFacts" } }
});
await WaitForPreviewSkillAsync(indexers, name);
SearchClient searchClient = new SearchClient(endpoint, name, credential);
await WaitForPreviewDocumentCountAsync(searchClient, 1);
SearchResults<SearchDocument> results = await searchClient.SearchAsync<SearchDocument>("*",
    new SearchOptions { Select = { "id", "content", "hotelFacts" } });
```

```C# Snippet:Azure_Search_Documents_Sample32_WaitForSkill
private static async Task WaitForPreviewSkillAsync(SearchIndexerClient indexers, string name)
{
    for (int attempt = 0; attempt < 120; attempt++)
    {
        SearchIndexerStatus status = await indexers.GetIndexerStatusAsync(name);
        IndexerExecutionResult result = status.LastResult;
        if (status.Status == IndexerStatus.Error || result?.Status == IndexerExecutionStatus.TransientFailure)
        {
            throw new InvalidOperationException("Run-owned skill execution failed; inspect indexer errors and provider access.");
        }
        if (result?.Status == IndexerExecutionStatus.Success)
        {
            if (result.ItemCount != 1 || result.FailedItemCount != 0 || result.Errors.Count != 0 || result.Warnings.Count != 0)
            {
                throw new InvalidOperationException("Skill execution must process exactly one fixture without errors or warnings.");
            }
            return;
        }
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
    throw new TimeoutException("Run-owned chat skill execution did not complete within ten minutes.");
}
```

The complete sample waits for actual indexer success and searchable output,
requires exactly one source document without indexing errors/warnings, and
checks generated facts against known hotel names, cities, founding years,
operators and amenities in the approved text. Merely creating/getting a skillset
does not validate model execution. Cleanup deletes the run's indexer before its
skillset/data source/index, never shared fixtures.
