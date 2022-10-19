# Reverse Search Address Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search#getting-started) for details.

## Import the namespaces

```C# Snippet:SearchImportNamespace
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

## Reverse Search Address

If we want to search the address of specific coordinate, we can call `ReverseSearchAddress` to get the coordinate of the address:

```C# Snippet:ReverseSearchAddressAsync
Response<ReverseSearchAddressResult> reverseResult = await client.ReverseSearchAddressAsync(new ReverseSearchOptions
{
    Coordinates = new GeoPosition(121.0, 24.0),
    Language = SearchLanguage.EnglishUsa
});
```

You can also search multiple addresses. If the queries are less than 100, use `GetImmediateReverseSearchAddressBatch` (or `GetImmediateReverseSearchAddressBatchAsync` for asynchronous call). The APIs will return the results immediately. The code snippet below demonstrate `GetImmediateReverseSearchAddressBatchAsync` asynchronous call:

```C# Snippet:GetImmediateReverseSearchAddressBatchAsync
var reverseResult = await client.GetImmediateReverseSearchAddressBatchAsync(new[] {
    new ReverseSearchAddressQuery(new ReverseSearchOptions { Coordinates = new GeoPosition(121.0, 24.0), Language = "en" }),
    new ReverseSearchAddressQuery(new ReverseSearchOptions { Coordinates = new GeoPosition(-122.333345, 47.606038) }),
});
```

If you want to reverse search more than 100 addresses, you can use `ReverseSearchAddressBatch` (or `ReverseSearchAddressBatchAsync` for asynchronous call), which is a long-running operation (LRO) and accepts up to 10000 queries. It will return `ReverseSearchAddressBatchOperation` object. You can get the results from the operation object.

```C# Snippet:ReverseSearchAddressBatchAsync
List<ReverseSearchAddressQuery> queries = new List<ReverseSearchAddressQuery>
{
    new ReverseSearchAddressQuery(new ReverseSearchOptions()
    {
        Coordinates = new GeoPosition(121.0, 24.0),
        Language = SearchLanguage.EnglishUsa
    }),
    new ReverseSearchAddressQuery(new ReverseSearchOptions()
    {
        Coordinates = new GeoPosition(-3.707, 40.4168),
        StreetNumber = 5
    })
};

// Reverse search address batch will return `ReverseSearchAddressBatchOperation` object
ReverseSearchAddressBatchOperation operation = await client.ReverseSearchAddressBatchAsync(WaitUntil.Started, queries);

// After a while, get the result back from `ReverseSearchAddressBatchOperation`
Response<ReverseSearchAddressBatchResult> result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
```

The search address batch result will be cached for 14 days. You can fetch the result from server via a `SearchAddressBatchOperation` with the same `Id`:

```C# Snippet:ReverseSearchAddressBatchAsyncWithOperationId
List<ReverseSearchAddressQuery> queries = new List<ReverseSearchAddressQuery>
{
    new ReverseSearchAddressQuery(new ReverseSearchOptions()
    {
        Coordinates = new GeoPosition(121.0, 24.0),
        Language = SearchLanguage.EnglishUsa
    }),
    new ReverseSearchAddressQuery(new ReverseSearchOptions()
    {
        Coordinates = new GeoPosition(-3.707, 40.4168),
        StreetNumber = 5
    })
};

// Reverse search address batch will return `ReverseSearchAddressBatchOperation` object
ReverseSearchAddressBatchOperation operation = await client.ReverseSearchAddressBatchAsync(WaitUntil.Started, queries);

// Get the operation ID and store somewhere
string operationId = operation.Id;
```

Within 14 days, you can use the same operation ID to fetch the same result. Precondition is the client endpoint should be the same:

```C# Snippet:ReverseSearchAddressBatchAsyncWithOperationId2
// Within 14 days, users can retrive the cached result with operation ID
// The `endpoint` argument in `clientOptions` should be the same!
ReverseSearchAddressBatchOperation newReverseSearchAddressBatchOperation = new ReverseSearchAddressBatchOperation(client, operationId);
Response<ReverseSearchAddressBatchResult> searchResults = newReverseSearchAddressBatchOperation.WaitForCompletion();

// Show the results
foreach (ReverseSearchAddressBatchItemResponse searchResult in searchResults.Value.Results)
{
    Console.WriteLine("Result for query: \"{0}\"", searchResult.Query);
    // Print out first result
    ReverseSearchAddressItem address = searchResult.Addresses[0];
    Console.WriteLine("Country: {0}", address.Address.Country);
    Console.WriteLine("Address: {0}", address.Address.FreeformAddress);
}
```

## Reverse Search Cross Street Address

There may be times when you need to translate a coordinate (example: -122.3862, 37.786505) into a human understandable cross street. Most often this is needed in tracking applications where you receive a GPS feed from the device or asset and wish to know what address where the coordinate is located. `ReverseSearchCrossStreetAddress` (or `ReverseSearchCrossStreetAddressAsync` for asynchronous call)  will return cross street information for a given coordinate.

```C# Snippet:ReverseSearchCrossStreetAddressAsync
Response<ReverseSearchCrossStreetAddressResult> searchResult = await client.ReverseSearchCrossStreetAddressAsync(new ReverseSearchCrossStreetOptions
{
    Coordinates = new GeoPosition(-121.89, 37.337),
    Language = SearchLanguage.EnglishUsa
});

ReverseSearchCrossStreetAddressResultItem address = searchResult.Value.Addresses[0];
Console.WriteLine("Coordinate {0} => Cross street address is: {1}",
    address.Position, address.Address.FreeformAddress);
```
