# Semantic Search

Semantic search is a collection of query-related capabilities that improve the quality of search results for text-based queries. When you enable semantic search on your service, it performs two primary functions:
* **Improves Search Results**: It adds a secondary ranking over an initial search result set by using advanced algorithms that consider the context and meaning of the query, resulting in more relevant search outcomes.
* **Provides Additional Information**: It also extracts and displays concise captions and answers from the search results, which can be used on a search page to improve the user's search experience.

You can find detailed instructions on semantic search in the [documentation](https://learn.microsoft.com/azure/search/semantic-search-overview). It's important to note that semantic search is disabled by default for all services. To enable semantic search at the service level, please follow the steps outlined [here](https://learn.microsoft.com/azure/search/semantic-how-to-enable-disable).

This sample demonstrates how to create an index, upload data, and perform a query for semantic search.

## Create an Index

Let's consider the example of a `Hotel`. First, we need to create an index for storing hotel information. In this index, we will define `Hotel` fields. In addition to that, we will configure semantic settings that define a specific configuration to be used in the context of semantic capabilities.

To accomplish this, we will create an instace of `SearchIndex` and define `Hotel` fields.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Index
string indexName = "hotel";
SearchIndex searchIndex = new(indexName)
{
    Fields =
    {
        new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
        new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
        new SearchableField("Description") { IsFilterable = true },
        new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
    },
    SemanticSearch = new()
    {
        Configurations =
        {
            new SemanticConfiguration("my-semantic-config", new()
            {
                TitleField = new SemanticField("HotelName"),
                ContentFields =
                {
                    new SemanticField("Description")
                },
                KeywordsFields =
                {
                    new SemanticField("Category")
                }
            })
        }
    }
};
```

After creating an instance of the `SearchIndex`, we need to instantiate the `SearchIndexClient` and call the `CreateIndex` method to create the search index. 

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Create_Index
Uri endpoint = new(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
AzureKeyCredential credential = new(key);

SearchIndexClient indexClient = new(endpoint, credential);
await indexClient.CreateIndexAsync(searchIndex);
```

## Add documents to your index

Let's create a simple model type for `Hotel`:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Model
public class Hotel
{
    public string HotelId { get; set; }
    public string HotelName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
```

Next, we will create sample hotel documents:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Hotel_Document
public static Hotel[] GetHotelDocuments()
{
    return new[]
    {
        new Hotel()
        {
            HotelId = "1",
            HotelName = "Fancy Stay",
            Description =
                "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                "the tourist attractions. We highly recommend this hotel.",
            Category = "Luxury",
        },
        new Hotel()
        {
            HotelId = "2",
            HotelName = "Roach Motel",
            Description = "Cheapest hotel in town. Infact, a motel.",
            Category = "Budget",
        },
         // Add more hotel documents here...
    };
}
```

Now, we can instantiate the `SearchClient` and upload the documents to the `Hotel` index we created earlier:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Upload_Documents
SearchClient searchClient = new(endpoint, indexName, credential);
Hotel[] hotelDocuments = GetHotelDocuments();
await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
```

## Querying Data

To perform a semantic search query, we'll specify `SemanticSearch.SemanticConfigurationName` as `SearchQueryType.Semantic` in the `SearchOptions`. We'll use the same `SemanticConfigurationName` that we defined when creating the index. Additionally, we've enabled `SemanticSearch.QueryCaption` and `SemanticSearch.QueryAnswer` in the `SearchOptions` to retrieve the caption and answer in the response. With these settings in place, we're ready to execute a semantic search query.

### Using QueryType

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Search_Query
SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
    new SearchOptions
    {
        SemanticSearch = new()
        {
            SemanticConfigurationName = "my-semantic-config",
            QueryCaption = new(QueryCaptionType.Extractive),
            QueryAnswer = new(QueryAnswerType.Extractive)
        },
        QueryLanguage = QueryLanguage.EnUs,
        QueryType = SearchQueryType.Semantic
    });

int count = 0;
Console.WriteLine($"Semantic Search Results:");

Console.WriteLine($"\nQuery Answer:");
foreach (QueryAnswerResult result in response.SemanticSearch.Answers)
{
    Console.WriteLine($"Answer Highlights: {result.Highlights}");
    Console.WriteLine($"Answer Text: {result.Text}");
}

await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");

    if (result.SemanticSearch.Captions != null)
    {
        var caption = result.SemanticSearch.Captions.FirstOrDefault();
        if (caption.Highlights != null && caption.Highlights != "")
        {
            Console.WriteLine($"Caption Highlights: {caption.Highlights}");
        }
        else
        {
            Console.WriteLine($"Caption Text: {caption.Text}");
        }
    }
}
Console.WriteLine($"Total number of search results:{count}");
```

### Using SemanticQuery

You can also use `SemanticSearch.SemanticQuery` for semantic search. This feature allows you to set a separate search query that will be used exclusively for semantic reranking, semantic captions, and semantic answers. It is beneficial for scenarios where different queries are required between the base retrieval and ranking phase, and the L2 semantic phase.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample08_Semantic_Query
SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    "Luxury hotel",
    new SearchOptions
    {
        SemanticSearch = new()
        {
            SemanticConfigurationName = "my-semantic-config",
            QueryCaption = new(QueryCaptionType.Extractive),
            QueryAnswer = new(QueryAnswerType.Extractive),
            SemanticQuery = "Is there any hotel located on the main commercial artery of the city in the heart of New York?"
        },
        QueryLanguage = QueryLanguage.EnUs,
    });

int count = 0;
Console.WriteLine($"Semantic Search Results:");

Console.WriteLine($"\nQuery Answer:");
foreach (QueryAnswerResult result in response.SemanticSearch.Answers)
{
    Console.WriteLine($"Answer Highlights: {result.Highlights}");
    Console.WriteLine($"Answer Text: {result.Text}");
}

await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");

    if (result.SemanticSearch.Captions != null)
    {
        var caption = result.SemanticSearch.Captions.FirstOrDefault();
        if (caption.Highlights != null && caption.Highlights != "")
        {
            Console.WriteLine($"Caption Highlights: {caption.Highlights}");
        }
        else
        {
            Console.WriteLine($"Caption Text: {caption.Text}");
        }
    }
}
Console.WriteLine($"Total number of search results:{count}");
```
