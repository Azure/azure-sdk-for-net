# Search Address Samples

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

## Search Address

Most of the time, we only want to search for a specific address. We can call `SearchAddress` (or `SearchAddressAsync` for asynchronous call) to get the coordinate of the address:

```C# Snippet:SearchAddress
Response<SearchAddressResult> searchResult = await client.SearchAddressAsync("Seattle");

SearchAddressResultItem resultItem = searchResult.Value.Results[0];
Console.WriteLine("First result - Coordinate: {0}, Address: {1}",
    resultItem.Position, resultItem.Address.FreeformAddress);
```

You can also search multiple addresses. If the queries are less than 100, use `GetImmediateSearchAddressBatch` (or `GetImmediateSearchAddressBatchAsync` for asynchronous call). The API will return the results immediately:

```C# Snippet:GetImmediateSearchAddressBatch
List<SearchAddressQuery> queries = new List<SearchAddressQuery>
{
    new SearchAddressQuery("1301 Alaskan Way, Seattle, WA 98101"),
    new SearchAddressQuery("350 S 5th St, Minneapolis, MN 55415")
};
SearchAddressBatchResult searchResults = client.GetImmediateSearchAddressBatch(queries);

foreach (SearchAddressBatchItemResponse searchResult in searchResults.Results)
{
    Console.WriteLine("Result for query: \"{0}\"", searchResult.Query);
    foreach (SearchAddressResultItem result in searchResult.Results)
    {
        Console.WriteLine("Coordinate (Lat, Lon): ({0}, {1})",
            result.Position.Latitude, result.Position.Longitude);
    }
}
```

If you want to search more than 100 addresses, you can use `SearchAddressBatch` (or `SearchAddressBatchAsync` for asynchronous call), which is a long-running operation (LRO) and accepts up to 10000 queries. It will return `SearchAddressBatchOperation` object. You can get the results from the operation object.

```C# Snippet:SearchAddressBatch
List<SearchAddressQuery> queries = new List<SearchAddressQuery>
{
    new SearchAddressQuery("1301 Alaskan Way, Seattle, WA 98101"),
    new SearchAddressQuery("350 S 5th St, Minneapolis, MN 55415")
};

// Invoke asynchronous search address batch request, we can get the result later via assigning `WaitUntil.Started`
SearchAddressBatchOperation operation = client.SearchAddressBatch(WaitUntil.Started, queries);

// After a while, get the result back
Response<SearchAddressBatchResult> result = operation.WaitForCompletion();
```

The search address batch result will be cached for 14 days. You can fetch the result from server via a `SearchAddressBatchOperation` with the same `Id`:

```C# Snippet:SearchAddressBatchWithOperationId
List<SearchAddressQuery> queries = new List<SearchAddressQuery>
{
    new SearchAddressQuery("1301 Alaskan Way, Seattle, WA 98101"),
    new SearchAddressQuery("350 S 5th St, Minneapolis, MN 55415")
};

// Invoke asynchronous search address batch request, we can get the result later via assigning `WaitUntil.Started`
SearchAddressBatchOperation operation = client.SearchAddressBatch(WaitUntil.Started, queries);

// Get the operation ID and store somewhere
string operationId = operation.Id;
```

Within 14 days, you can use the same operation ID to fetch the same result. Precondition is the client endpoint should be the same:

```C# Snippet:SearchAddressBatchWithOperationId2
// Within 14 days, users can retrive the cached result with operation ID
// The `endpoint` argument in `clientOptions` should be the same!
SearchAddressBatchOperation newSearchAddressBatchOperation = new SearchAddressBatchOperation(client, operationId);
Response<SearchAddressBatchResult> searchResults = newSearchAddressBatchOperation.WaitForCompletion();

// Show the results
foreach (SearchAddressBatchItemResponse searchResult in searchResults.Value.Results)
{
    Console.WriteLine("Result for query: \"{0}\"", searchResult.Query);
    foreach (SearchAddressResultItem result in searchResult.Results)
    {
        Console.WriteLine("Coordinate (Lat, Lon): ({0}, {1})",
            result.Position.Latitude, result.Position.Longitude);
    }
}
```

## Structured Search Address

We also provide structured address search API. You can use `StructuredAddress` to input the address information you want to search.

```C# Snippet:SearchStructuredAddress
var address = new StructuredAddress
{
    CountryCode = "US",
    StreetNumber = "15127",
    StreetName = "NE 24th Street",
    Municipality = "Redmond",
    CountrySubdivision = "WA",
    PostalCode = "98052"
};
Response<SearchAddressResult> searchResult = await client.SearchStructuredAddressAsync(address);

SearchAddressResultItem resultItem = searchResult.Value.Results[0];
Console.WriteLine("First result - Coordinate: {0}, Address: {1}",
    resultItem.Position, resultItem.Address.FreeformAddress);
```

## Search Point Of Interests

Search point of interests allows you to request POI results by name.

```C# Snippet:SearchPointOfInterest
Response<SearchAddressResult> searchResult = client.SearchPointOfInterest("juice bars");

SearchAddressResultItem resultItem = searchResult.Value.Results[0];
Console.WriteLine("First result - Coordinate: {0}, Address: {1}",
    resultItem.Position, resultItem.Address.FreeformAddress);
```
