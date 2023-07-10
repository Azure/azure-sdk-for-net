# Azure.Search.Documents Samples - Vector Search

Vector search is a method of information retrieval technique that aims to overcome the limitations of traditional keyword-based search. Instead of relying solely on lexical analysis and matching individual query terms, vector search utilizes machine learning models to capture the contextual meaning of words and phrases. This is achieved by representing documents and queries as vectors in a high-dimensional space known as an embedding. By understanding the intent behind the query, vector search can provide more relevant results that align with the user's requirements, even if the exact terms are not present in the document. Additionally, vector search can be applied to different types of content, such as images and videos, not just text.

Cognitive Search doesn't host vectorization models. This presents a challenge in creating embeddings for query inputs and outputs. To address this, you need to ensure that the documents you push to your search service include vectors within the payload. To generate vectorized data, you have the flexibility to use any embedding model of your choice. However, we recommend utilizing the [Azure OpenAI Embeddings models](https://learn.microsoft.com/azure/cognitive-services/openai/how-to/embeddings) for this purpose. You can leverage the [Azure.AI.OpenAI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/README.md) library to generate text embeddings.

Please refer the [documentation](https://learn.microsoft.com/azure/search/vector-search-overview) to learn more about Vector Search.

This sample will show you how to index a vector field and perform vector search using .NET SDK.

## Create a Vector Index

Let's consider the example of a `Hotel`. First, we need to create an index for storing hotel information. In this index, we will define a field called `DescriptionVector` as a vector field. To configure the vector field, you need to provide the model dimensions, which indicate the size of the embeddings generated for this field, and the name of the vector search algorithm configuration that specifies the algorithm and any optional parameters for searching the vector field. You can find detailed instructions on how to create a vector index in the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-create-index).

We will create an instace of `SearchIndex` and define `Hotel` fields.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Index
string vectorSearchConfigName = "my-vector-config";
int modelDimensions = 1536;

string indexName = "Hotel";
SearchIndex searchIndex = new(indexName)
{
    Fields =
    {
        new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true, IsFacetable = true },
        new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
        new SearchableField("Description") { IsFilterable = true },
        new SearchField("DescriptionVector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
        {
            IsSearchable = true,
            VectorSearchDimensions = modelDimensions,
            VectorSearchConfiguration = vectorSearchConfigName
        },
        new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true }
    },
    VectorSearch = new()
    {
        AlgorithmConfigurations =
        {
            new HnswVectorSearchAlgorithmConfiguration(vectorSearchConfigName)
        }
    }
};
```

After creating an instance of the `SearchIndex`, we need to instantiate the `SearchIndexClient` and call the `CreateIndex` method to create the search index. 

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Create_Index
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
    public IReadOnlyList<float> DescriptionVector { get; set; }
    public string Category { get; set; }
}
```

Next, we will create sample hotel documents. The vector field requires submitting text input to an embedding model that converts human-readable text into a vector representation. To convert a text query string provided by a user into a vector representation, your application should utilize an embedding library that offers this functionality. For more details about how to generate embeddings, refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-generate-embeddings). Here's an example of how you can get embeddings using [Azure.AI.OpenAI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/README.md) library. 

#### Get Embeddings using `Azure.AI.OpenAI`

```C# Snippet:Azure_Search_Tests_Samples_Readme_GetEmbeddings
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("OpenAI_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("OpenAI_API_KEY");
AzureKeyCredential credential = new AzureKeyCredential(key);

OpenAIClient openAIClient = new OpenAIClient(endpoint, credential);
string description = "Very popular hotel in town.";
EmbeddingsOptions embeddingsOptions = new(description);

Embeddings embeddings = await openAIClient.GetEmbeddingsAsync("EmbeddingsModelName", embeddingsOptions);
IReadOnlyList<float> descriptionVector = embeddings.Data[0].Embedding;
```

In the sample code below, we are using hardcoded embeddings for the `DescriptionVector` field:

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
            DescriptionVector = VectorSearchEmbeddings.Hotel1VectorizeDescription,
            Category = "Luxury",
        },
        new Hotel()
        {
            HotelId = "2",
            HotelName = "Roach Motel",
            Description = "Cheapest hotel in town. Infact, a motel.",
            DescriptionVector = VectorSearchEmbeddings.Hotel2VectorizeDescription,
            Category = "Budget",
        },
         // Add more hotel documents here...
    };
}
```

Now, we can instantiate the `SearchClient` and upload the documents to the `Hotel` index we created earlier:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Upload_Documents
SearchClient searchClient = new(endpoint, indexName, credential);
Hotel[] hotelDocuments = GetHotelDocuments();
await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
```

## Query Vector Data

To query a vector field, the query itself must be a vector. To convert a text query string provided by a user into a vector representation, your application must call an embedding library that provides this capability. Use the same embedding library that you used to generate embeddings in the source documents. For more details on how to generate embeddings, please refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-generate-embeddings). In the sample codes below, we are using hardcoded embeddings to query vector field.

Let's query the index and make sure everything works as implemented. You can also refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-query) for more information on querying vector data.

### Single Vector Search

In this vector query, the `Value` contains the vectorized text of the query input. The `Fields` property specifies which vector fields are searched. The "KNearestNeighborsCount" property specifies the number of nearest neighbors to return as top hits.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Single_Vector_Search
IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(null,
    new SearchOptions
    {
        Vector = new() { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = "DescriptionVector" },
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

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Filter
IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(null,
    new SearchOptions
    {
        Vector = new() { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = "DescriptionVector" },
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

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Simple_Hybrid_Search
IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
        "Top hotels in town",
        new SearchOptions
        {
            Vector = new() { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = "DescriptionVector" },
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

#### Semantic Hybrid Search

To use semantic search, we need to add a `SemanticConfiguration` to the index. In this example, we will update the previously created index and add the `SemanticConfiguration` to it.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Semantic_Index
string indexName = "Hotel";
SearchIndex createdIndex = await indexClient.GetIndexAsync(indexName);

createdIndex.SemanticSettings = new()
{
    Configurations =
    {
           new SemanticConfiguration("my-semantic-config", new()
           {
               TitleField = new(){ FieldName = "HotelName" },
               ContentFields =
               {
                   new() { FieldName = "Description" }
               },
               KeywordFields =
               {
                   new() { FieldName = "Category" }
               }
           })
    }
};

// Update index
await indexClient.CreateOrUpdateIndexAsync(createdIndex);
```
With the semantic configuration added, we can now execute a semantic hybrid query.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Semantic_Hybrid_Search
IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
    new SearchOptions
    {
        Vector = new SearchQueryVector { Value = vectorizedResult, KNearestNeighborsCount = 3, Fields = "descriptionVector" },
        QueryType = SearchQueryType.Semantic,
        QueryLanguage = QueryLanguage.EnUs,
        SemanticConfigurationName = "my-semantic-config",
        QueryCaption = QueryCaptionType.Extractive,
        QueryAnswer = QueryAnswerType.Extractive,
    });

int count = 0;
Console.WriteLine($"Semantic Hybrid Search Results:");

Console.WriteLine($"\nQuery Answer:");
foreach (AnswerResult result in response.Answers)
{
    Console.WriteLine($"Answer Highlights: {result.Highlights}");
    Console.WriteLine($"Answer Text: {result.Text}");
}

await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");

    if (result.Captions != null)
    {
        var caption = result.Captions.FirstOrDefault();
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
