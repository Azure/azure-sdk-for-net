# Azure.Search.Documents Samples - Query Session

To ensure more consistent and unique search results within a user's session, you can use session id. Simply include the sessionId parameter in your queries to create a unique identifier for each user session. This ensures a uniform experience for users throughout their "query session".

```C# Snippet:Azure_Search_Tests_Samples_QuerySession
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
        new SearchOptions
        {
            Filter = "Rating gt 2",
            SessionId = "Session-1"
        });

await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    Hotel hotel = result.Document;
    Console.WriteLine($"{hotel.HotelName} ({hotel.HotelId})");
}
```

By consistently using the same sessionId, the system makes a best-effort attempt to target the same replica, improving the overall consistency of search results for users within the specified session. This approach is useful for scenarios where maintaining result consistency throughout a user's session is essential. For more details, please refer the [documentation](https://learn.microsoft.com/azure/search/index-similarity-and-scoring#scoring-statistics-and-sticky-sessions).