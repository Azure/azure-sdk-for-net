# Vector Semantic Hybrid Search

This sample will show you how to perform vector semantic hybrid search.

## Create a Vector Index

Let's consider the example of a `Hotel`. First, we need to create an index for storing hotel information. In this index, we will define vector fields called `DescriptionVector` and `CategoryVector`. To configure these vector fields, you need to specify the model dimensions, indicating the size of the embeddings generated for each field and the name of the vector search profile, which specifies the algorithm configuration and any optional search parameters for these vector fields. In addition to that, you also need to configure semantic settings for the index. You can find detailed instructions on how to create a vector index in the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-create-index).

We will create an instace of `SearchIndex` and define `Hotel` fields.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Semantic_Hybrid_Search_Index
string vectorSearchProfile = "my-vector-profile";
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
        new SearchField("DescriptionVector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
        {
            IsSearchable = true,
            VectorSearchDimensions = modelDimensions,
            VectorSearchProfile = vectorSearchProfile
        },
        new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
        new SearchField("CategoryVector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
        {
            IsSearchable = true,
            VectorSearchDimensions = modelDimensions,
            VectorSearchProfile = vectorSearchProfile
        },
    },
    VectorSearch = new()
    {
        Profiles =
        {
            new VectorSearchProfile(vectorSearchProfile, vectorSearchHnswConfig)
        },
        Algorithms =
        {
            new HnswVectorSearchAlgorithmConfiguration(vectorSearchHnswConfig)
        }
    },
    SemanticSettings = new()
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
    }
};
```

After creating an instance of the `SearchIndex`, we need to instantiate the `SearchIndexClient` and call the `CreateIndex` method to create the search index. 

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Semantic_Hybrid_Search_Create_Index
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
    public IReadOnlyList<float> CategoryVector { get; set; }
}
```

Next, we will create sample hotel documents. The vector field requires submitting text input to an embedding model that converts human-readable text into a vector representation. To convert a text query string provided by a user into a vector representation, your application should utilize an embedding library that offers this functionality. For more details about how to generate embeddings, refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-generate-embeddings). Here's an example of how you can get embeddings using [Azure.AI.OpenAI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/README.md) library. 

### Get Embeddings using `Azure.AI.OpenAI`

```C# Snippet:Azure_Search_Tests_Samples_Readme_GetEmbeddings
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("OpenAI_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("OpenAI_API_KEY");
AzureKeyCredential credential = new AzureKeyCredential(key);

OpenAIClient openAIClient = new OpenAIClient(endpoint, credential);
string description = "Very popular hotel in town.";
EmbeddingsOptions embeddingsOptions = new("EmbeddingsModelName", new string[] { description });

Embeddings embeddings = await openAIClient.GetEmbeddingsAsync(embeddingsOptions);
ReadOnlyMemory<float> descriptionVector = embeddings.Data[0].Embedding;
```

In the sample code below, we are using hardcoded embeddings for the vector fields named `DescriptionVector` and `CategoryVector`:

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
            CategoryVector = VectorSearchEmbeddings.LuxuryVectorizeCategory
        },
        new Hotel()
        {
            HotelId = "2",
            HotelName = "Roach Motel",
            Description = "Cheapest hotel in town. Infact, a motel.",
            DescriptionVector = VectorSearchEmbeddings.Hotel2VectorizeDescription,
            Category = "Budget",
            CategoryVector = VectorSearchEmbeddings.BudgetVectorizeCategory
        },
         // Add more hotel documents here...
    };
}
```

Now, we can instantiate the `SearchClient` and upload the documents to the `Hotel` index we created earlier:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Semantic_Hybrid_Search_Upload_Documents
SearchClient searchClient = new(endpoint, indexName, credential);
Hotel[] hotelDocuments = GetHotelDocuments();
await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
```

## Query Vector Data

When using `RawVectorQuery`, the query for a vector field must also be a vector. To convert a text query string provided by a user into a vector representation, your application must call an embedding library that provides this capability. Use the same embedding library that you used to generate embeddings in the source documents. For more details on how to generate embeddings, please refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-generate-embeddings). In the sample codes below, we are using hardcoded embeddings to query vector field.

Let's query the index and make sure everything works as implemented. You can also refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-query?tabs=portal-vector-query#query-syntax-for-hybrid-search) for more information on querying vector data.

### Vector Semantic Hybrid Query

In a vector semantic hybrid query, the `VectorQueries` collection contains the vectors representing the query input. The `Fields` property specifies which vector fields to search within. The `KNearestNeighborsCount` property dictates the number of nearest neighbors to return as top hits. With the semantic configuration added, we can proceed to execute a semantic hybrid query.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Semantic_Hybrid_Search
IReadOnlyList<float> vectorizedResult = VectorSearchEmbeddings.SearchVectorizeDescription; // "Top hotels in town"

SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    "Is there any hotel located on the main commercial artery of the city in the heart of New York?",
    new SearchOptions
    {
        VectorQueries = { new RawVectorQuery() { Vector = vectorizedResult, KNearestNeighborsCount = 3, Fields = { "DescriptionVector" } } },
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
