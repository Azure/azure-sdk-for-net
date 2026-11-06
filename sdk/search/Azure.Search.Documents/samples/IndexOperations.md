# Azure.Search.Documents Samples - Index Operations

## Get Count

Retrieve a count of the number of documents in this search index.

```C# Snippet:Azure_Search_Tests_Samples_GetCountAsync
// Create a SearchClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");
SearchClient searchClient = new SearchClient(endpoint, indexName, credential);

// Get and report the number of documents in the index
Response<long> count = await searchClient.GetDocumentCountAsync();
Console.WriteLine($"Search index {indexName} has {count.Value} documents.");
```

## Find Similar Documents

Use `MoreLikeThis` with a document key to find related documents without supplying search text. Replace `"1"` with a key from your index.

Set `SearchFields` to top-level searchable text fields. When omitted, all searchable fields are considered, including complex fields such as the hotel index's `Address` and `Rooms`, which `MoreLikeThis` does not support.

```C# Snippet:Azure_Search_Tests_Samples_FindSimilarDocuments
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");
SearchClient searchClient = new SearchClient(endpoint, indexName, credential);

// Find documents similar to hotel "1" without supplying search text.
SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    options: new SearchOptions
    {
        MoreLikeThis = "1",
        SearchFields = { "HotelName", "Description" },
        Size = 5
    });

int resultCount = 0;
await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    resultCount++;
    Console.WriteLine($"{result.Document.HotelId}: {result.Document.HotelName}");
}
```
