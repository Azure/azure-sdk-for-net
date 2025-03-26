# Sample for Azure.AI.Projects with Search extension

In this example we will demonstrate how to use Azure AI Search resource using `Azure.Search.Documents` extension. To run this sample we will need the index named "index" with fields "HotelId", containing just a number in string format and "HotelName", containing hotel name, this field needs to be searchable. Please create the index following the [instructions](https://learn.microsoft.com/azure/ai-services/agents/how-to/tools/azure-ai-search).
In the example we will
 - Get the search client
 - Perform search 
 - And, finally, iterate over results and print them
 
Synchronous sample:
```C# Snippet:ExtensionsSearch
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
AIProjectClient client = new(connectionString);
SearchClient searchClient = client.GetSearchClient("index");

SearchResults<SearchDocument> response = searchClient.Search<SearchDocument>("luxury hotel");
foreach (SearchResult<SearchDocument> result in response.GetResults())
{
    SearchDocument doc = result.Document;
    string id = (string)doc["HotelId"];
    string name = (string)doc["HotelName"];
    Console.WriteLine($"{id}: {name}");
}
```

Asynchronous sample:
```C# Snippet:ExtensionsSearchAsync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
AIProjectClient client = new(connectionString);
SearchClient searchClient = client.GetSearchClient("index");

SearchResults<SearchDocument> response = await searchClient.SearchAsync<SearchDocument>("luxury hotel");
await foreach (SearchResult<SearchDocument> result in response.GetResultsAsync())
{
    SearchDocument doc = result.Document;
    string id = (string)doc["HotelId"];
    string name = (string)doc["HotelName"];
    Console.WriteLine($"{id}: {name}");
}
```