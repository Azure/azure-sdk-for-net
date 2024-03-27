# Vector Search Using Vectorized Query

This sample demonstrates how to create a vector fields index, upload data into the index, and perform various types of vector searches using vectorized queries.

## Create a Vector Index

Let's consider the example of a `Hotel`. First, we need to create an index for storing hotel information. In this index, we will define vector fields called `DescriptionVector` and `CategoryVector`. To configure the vector field, you need to provide the model dimensions, which indicate the size of the embeddings generated for this field, and the name of the vector search profile that specifies the algorithm configuration and any optional parameters for searching the vector field. You can find detailed instructions on how to create a vector index in the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-create-index).

We will create an instace of `SearchIndex` and define `Hotel` fields.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Index_UsingVectorizedQuery
string vectorSearchProfileName = "my-vector-profile";
string vectorSearchHnswConfig = "my-hsnw-vector-config";
int modelDimensions = 1536;

string indexName = "hotel";
SearchIndex searchIndex = new(indexName)
{
    Fields =
    {
        new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
        new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
        new SearchableField("Description") { IsFilterable = true },
        new VectorSearchField("DescriptionVector", modelDimensions, vectorSearchProfileName),
        new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
        new VectorSearchField("CategoryVector", modelDimensions, vectorSearchProfileName),
    },
    VectorSearch = new()
    {
        Profiles =
        {
            new VectorSearchProfile(vectorSearchProfileName, vectorSearchHnswConfig)
        },
        Algorithms =
        {
            new HnswAlgorithmConfiguration(vectorSearchHnswConfig)
        }
    },
};
```

After creating an instance of the `SearchIndex`, we need to instantiate the `SearchIndexClient` and call the `CreateIndex` method to create the search index. 

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Create_Index_UsingVectorizedQuery
Uri endpoint = new(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
AzureKeyCredential credential = new(key);

SearchIndexClient indexClient = new(endpoint, credential);
await indexClient.CreateIndexAsync(searchIndex);
```

## Add documents to your index

Let's create a simple model type for `Hotel`:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Model
public class Hotel
{
    public string HotelId { get; set; }
    public string HotelName { get; set; }
    public string Description { get; set; }
    public ReadOnlyMemory<float> DescriptionVector { get; set; }
    public string Category { get; set; }
    public ReadOnlyMemory<float> CategoryVector { get; set; }
}
```

Next, we will create sample hotel documents. The vector field requires submitting text input to an embedding model that converts human-readable text into a vector representation. To convert a text query string provided by a user into a vector representation, your application should utilize an embedding library that offers this functionality. For more details about how to generate embeddings, refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-generate-embeddings). Here's an example of how you can get embeddings using [Azure.AI.OpenAI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/README.md) library. 

### Get Embeddings using `Azure.AI.OpenAI`

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_GetEmbeddings
public static ReadOnlyMemory<float> GetEmbeddings(string input)
{
    Uri endpoint = new Uri(Environment.GetEnvironmentVariable("OpenAI_ENDPOINT"));
    string key = Environment.GetEnvironmentVariable("OpenAI_API_KEY");
    AzureKeyCredential credential = new AzureKeyCredential(key);

    OpenAIClient openAIClient = new OpenAIClient(endpoint, credential);
    EmbeddingsOptions embeddingsOptions = new("EmbeddingsModelName", new string[] { input });

    Embeddings embeddings = openAIClient.GetEmbeddings(embeddingsOptions);
    return embeddings.Data[0].Embedding;
}
```

In the sample code below, we are using `GetEmbeddings` method mentioned above to get embeddings for the vector fields named `DescriptionVector` and `CategoryVector`:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Hotel_Document
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
            DescriptionVector = GetEmbeddings(
                "Best hotel in town if you like luxury hotels. They have an amazing infinity pool, a spa, " +
                "and a really helpful concierge. The location is perfect -- right downtown, close to all " +
                "the tourist attractions. We highly recommend this hotel."),
            Category = "Luxury",
            CategoryVector = GetEmbeddings("Luxury")
        },
        new Hotel()
        {
            HotelId = "2",
            HotelName = "Roach Motel",
            Description = "Cheapest hotel in town. Infact, a motel.",
            DescriptionVector = GetEmbeddings("Cheapest hotel in town. Infact, a motel."),
            Category = "Budget",
            CategoryVector = GetEmbeddings("Budget")
        },
        // Add more hotel documents here...
    };
}
```

Now, we can instantiate the `SearchClient` and upload the documents to the `Hotel` index we created earlier:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Upload_Documents_UsingVectorizedQuery
SearchClient searchClient = new(endpoint, indexName, credential);
Hotel[] hotelDocuments = GetHotelDocuments();
await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
```

## Query Vector Data

When using `VectorizedQuery`, the query for a vector field must also be a vector. To convert a text query string provided by a user into a vector representation, your application must call an embedding library that provides this capability. Use the same embedding library that you used to generate embeddings in the source documents. For more details on how to generate embeddings, please refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-generate-embeddings). In the sample codes below, we are using `GetEmbeddings` method mentioned above to get embeddings to query vector field.

Let's query the index and make sure everything works as implemented. You can also refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-query) for more information on querying vector data.

### Single Vector Search

In this vector query, the `Queries` collection contains the vectors representing the query input. The `Fields` property specifies which vector fields are searched. The `KNearestNeighborsCount` property specifies the number of nearest neighbors to return as top hits.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Single_Vector_Search_UsingVectorizedQuery
ReadOnlyMemory<float> vectorizedResult = GetEmbeddings("Top hotels in town");

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    new SearchOptions
    {
        VectorSearch = new()
        {
            Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } }
        }
    });

int count = 0;
Console.WriteLine($"Single Vector Search Results:");
await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
}
Console.WriteLine($"Total number of search results:{count}");
```

### Single Vector Search With Filter

In addition to the vector query mentioned above, we can also apply a filter to narrow down the search results.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Filter_UsingVectorizedQuery
ReadOnlyMemory<float> vectorizedResult = GetEmbeddings("Top hotels in town");

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    new SearchOptions
    {
        VectorSearch = new()
        {
            Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } }
        },
        Filter = "Category eq 'Luxury'"
    });

int count = 0;
Console.WriteLine($"Single Vector Search With Filter Results:");
await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
}
Console.WriteLine($"Total number of search results:{count}");
```

### Hybrid Search

A hybrid query combines full text search, semantic search (reranking), and vector search. The search engine runs full text and vector queries in parallel. Semantic ranking is applied to the results from the text search. A single result set is returned in the response.

#### Simple Hybrid Search

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Simple_Hybrid_Search_UsingVectorizedQuery
ReadOnlyMemory<float> vectorizedResult = GetEmbeddings("Top hotels in town");

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
        "Top hotels in town",
        new SearchOptions
        {
            VectorSearch = new()
            {
                Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } }
            },
        });

int count = 0;
Console.WriteLine($"Simple Hybrid Search Results:");
await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
}
Console.WriteLine($"Total number of search results:{count}");
```

### Multi-vector Search

You can search containing multiple query vectors using the `SearchOptions.VectorSearch.Queries` property. These queries will be executed concurrently in the search index, with each one searching for similarities in the target vector fields. The result set will be a combination of documents that matched both vector queries. One common use case for this query request is when using models like CLIP for a multi-modal vector search, where the same model can vectorize both image and non-image content.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Multi_Vector_Search_UsingVectorizedQuery
ReadOnlyMemory<float> vectorizedDescriptionQuery = GetEmbeddings("Top hotels in town");
ReadOnlyMemory<float> vectorizedCategoryQuery = GetEmbeddings("Luxury hotels in town");

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    new SearchOptions
    {
        VectorSearch = new()
        {
            Queries = {
                new VectorizedQuery(vectorizedDescriptionQuery) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } },
                new VectorizedQuery(vectorizedCategoryQuery) { KNearestNeighborsCount = 3, Fields = { "CategoryVector" } } }
        },
    });

int count = 0;
Console.WriteLine($"Multi Vector Search Results:");
await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
}
Console.WriteLine($"Total number of search results:{count}");
```

### Multi-field Vector Search

You can set the `SearchOptions.VectorSearch.Queries.Fields` property to multiple vector fields. For example, we have vector fields named `DescriptionVector` and `CategoryVector`. Your vector query executes over both the `DescriptionVector` and `CategoryVector` fields, which must have the same embedding space since they share the same query vector.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Multi_Fields_Vector_Search_UsingVectorizedQuery
ReadOnlyMemory<float> vectorizedResult = GetEmbeddings("Top hotels in town");

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    new SearchOptions
    {
        VectorSearch = new()
        {
            Queries = { new VectorizedQuery(vectorizedResult) { KNearestNeighborsCount = 3, Fields = { "DescriptionVector", "CategoryVector" } } }
        }
    });

int count = 0;
Console.WriteLine($"Multi Fields Vector Search Results:");
await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
}
Console.WriteLine($"Total number of search results:{count}");
```
