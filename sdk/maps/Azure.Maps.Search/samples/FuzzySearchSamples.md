# Fuzzy Search Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search#getting-started) for details.

## Import the namespaces

```C# Snippet:SearchImportNamespaces
using Azure.Core.GeoJson;
using Azure.Maps.Search;
using Azure.Maps.Search.Models;
```

## Create Search Client

Before searching addresses, create a `MapsSearchClient` first. Either use subscription key or AAD.

Instantiate search client with subscription key:

```C# Snippet:InstantiateSearchClientViaSubscriptionKey
// Create a SearchClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsSearchClient client = new MapsSearchClient(credential);
```

Instantiate route client via AAD authentication:

```C# Snippet:InstantiateSearchClientViaAAD
// Create a MapsSearchClient that will authenticate through AAD
DefaultAzureCredential credential = new DefaultAzureCredential();
string clientId = "<My Map Account Client Id>";
MapsSearchClient client = new MapsSearchClient(credential, clientId);
```

## Fuzzy Search

Sometimes, we want to search some point of interests, entities, or addresses.  `FuzzySearch` (or `FuzzySearchAsync` for asynchronous call) can help you accomplish the free form search. The example below search the starbucks nearby specific coordinate:

```C# Snippet:FuzzySearch
Response<SearchAddressResult> fuzzySearchResponse = await client.FuzzySearchAsync("coffee", new FuzzySearchOptions
{
    Coordinates = new GeoPosition(121.56, 25.04),
    Language = SearchLanguage.EnglishUsa
});

// Print out the possible results
Console.WriteLine("The possible results for coffee shop:");
foreach (SearchAddressResultItem result in fuzzySearchResponse.Value.Results)
{
    Console.WriteLine("Coordinate: {0}, Address: {1}",
        result.Position, result.Address.FreeformAddress);
}
```

You can also search multiple free form searches at one time. If the queries are less than 100, use `GetImmediateFuzzyBatchSearch` (or `GetImmediateFuzzyBatchSearchAsync` for asynchronous call). The API will return the results immediately:

```C# Snippet:GetImmediateFuzzyBatchSearch
List<FuzzySearchQuery> queries = new List<FuzzySearchQuery>
{
    new FuzzySearchQuery("coffee", new FuzzySearchOptions()
    {
        BoundingBox = new GeoBoundingBox(121.53, 25.0, 121.56, 25.04)
    }),
    new FuzzySearchQuery("amusement park", new FuzzySearchOptions()
    {
        BoundingBox = new GeoBoundingBox(121.5, 25.0, 121.6, 25.1)
    }),
};
Response<SearchAddressBatchResult> fuzzySearchResults = client.GetImmediateFuzzyBatchSearch(queries);

// Print out the results for all queries
foreach (SearchAddressBatchItemResponse resultItemResponse in fuzzySearchResults.Value.Results)
{
    Console.WriteLine("The possible results for {0}:", resultItemResponse.Query);
    SearchAddressResultItem resultItem = resultItemResponse.Results[0];
    Console.WriteLine("Coordinate: {0}, Address: {1}",
        resultItem.Position, resultItem.Address.FreeformAddress);
}
```

If you want to search more than 100 addresses, you can use `FuzzyBatchSearch` (or `FuzzyBatchSearchAsync` for asynchronous call), which is a long-running operation (LRO) and accepts up to 10000 queries. It will return `FuzzyBatchSearchOperation` object. You can get the results from the operation object.

```C# Snippet:FuzzyBatchSearch
List<FuzzySearchQuery> queries = new List<FuzzySearchQuery>
{
    new FuzzySearchQuery("coffee", new FuzzySearchOptions()
    {
        BoundingBox = new GeoBoundingBox(121.53, 25.0, 121.56, 25.04)
    }),
    new FuzzySearchQuery("amusement park", new FuzzySearchOptions()
    {
        BoundingBox = new GeoBoundingBox(121.5, 25.0, 121.6, 25.1)
    }),
};
FuzzySearchBatchOperation operation = client.FuzzyBatchSearch(WaitUntil.Started, queries);

// After a while, get the result back
Response<SearchAddressBatchResult> result = operation.WaitForCompletion();
```

The search address batch result will be cached for 14 days. You can fetch the result from server via a `FuzzyBatchSearchOperation` with the same `Id`:

```C# Snippet:FuzzyBatchSearchWithOperationId
List<FuzzySearchQuery> queries = new List<FuzzySearchQuery>
{
    new FuzzySearchQuery("coffee", new FuzzySearchOptions()
    {
        BoundingBox = new GeoBoundingBox(121.53, 25.0, 121.56, 25.04)
    }),
    new FuzzySearchQuery("amusement park", new FuzzySearchOptions()
    {
        BoundingBox = new GeoBoundingBox(121.5, 25.0, 121.6, 25.1)
    }),
};
FuzzySearchBatchOperation operation = client.FuzzyBatchSearch(WaitUntil.Started, queries);

// Get the operation ID and store somewhere
string operationId = operation.Id;
```

Within 14 days, you can use the same operation ID to fetch the same result. Precondition is the client endpoint should be the same:

```C# Snippet:FuzzyBatchSearchWithOperationId2
// Within 14 days, users can retrive the cached result with operation ID
// The `endpoint` argument in `clientOptions` should be the same!
FuzzySearchBatchOperation newFuzzySearchBatchOperation = new FuzzySearchBatchOperation(client, operationId);
Response<SearchAddressBatchResult> searchResults = newFuzzySearchBatchOperation.WaitForCompletion();

// Show the results
foreach (SearchAddressBatchItemResponse searchResult in searchResults.Value.Results)
{
    Console.WriteLine("Result for query: \"{0}\"", searchResult.Query);
    SearchAddressResultItem result = searchResult.Results[0];
    Console.WriteLine("Coordinate: {0}, Address: {1}",
        result.Position, result.Address.FreeformAddress);
}
```
