# Random scoring from index creation to paging

Use the [common preview setup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample23_NovemberPreview.md). This flow needs no
OpenAI model. The complete compiled method is `RandomScoringEndToEnd` in
[`Sample24_RandomScoringPreview.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/tests/Samples/Sample24_RandomScoringPreview.cs).

## Create scoring profiles before querying

```C# Snippet:Azure_Search_Documents_Sample24_RandomScoring_Create
SearchIndex index = new SearchIndex(indexName)
{
    Fields =
    {
        new SimpleField("id", SearchFieldDataType.String) { IsKey = true, IsFilterable = true },
        new SearchableField("title"),
        new SimpleField("rating", SearchFieldDataType.Int32) { IsFilterable = true }
    },
    ScoringProfiles =
    {
        new ScoringProfile("randomUnseeded") { Functions = { new RandomScoringFunction() } },
        new ScoringProfile("randomSeeded")
        {
            Functions = { new RandomScoringFunction { Parameters = new RandomScoringParameters("randomSeed") } }
        }
    }
};
await indexClient.CreateIndexAsync(index);
```

Upload the sample's 20 synthetic hotels, then query the new index:

```C# Snippet:Azure_Search_Documents_Sample24_RandomScoring_Query
SearchOptions options = new SearchOptions
{
    ScoringProfile = "randomSeeded",
    ScoringParameters = { "randomSeed-12345" },
    Select = { "id", "rating" },
    Size = 20,
    IncludeTotalCount = true
};
SearchResults<SearchDocument> response = await searchClient.SearchAsync<SearchDocument>("hotel", options);
List<SearchResult<SearchDocument>> first = new List<SearchResult<SearchDocument>>();
await foreach (SearchResult<SearchDocument> result in response.GetResultsAsync())
{
    first.Add(result);
    Console.WriteLine($"{result.Document["id"]}: {result.Score}");
}
// Reuse a seed to keep ordering stable while paging an unchanged result set.
options.Size = 5;
options.Skip = 5;
SearchResults<SearchDocument> secondPage = await searchClient.SearchAsync<SearchDocument>("hotel", options);
```

Keep the seed and result set unchanged while paging. A different seed rotates
ordering; an omitted seed is valid only for the unseeded profile. Random scores
replace text/vector similarity scores, so do not interpret them as relevance.
A random profile cannot combine text weights or other scoring functions.

The executable sample checks repeatable keys and scores, filtering, paging,
rotation, negative seeds, signed 64-bit boundaries, unseeded result membership,
and rejection of a missing required seed. It deletes only its newly created index.
