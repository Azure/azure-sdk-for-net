# Vector Search Using Reduced Embeddings

This sample demonstrates how to create a vector fields index with reduced dimensions, upload reduced embeddings into the index, and query the documents. To accomplish this, you can utilize Azure OpenAI embedding models: a smaller and highly efficient `text-embedding-3-small` model or a larger and more powerful `text-embedding-3-large` model. These models are significantly more efficient and require less storage space.

## Creating a Vector Index

Let's consider the example of a `Hotel`. First, we need to create an index for storing hotel information. In this index, we will define vector fields called `DescriptionVector` and `CategoryVector`. To configure the vector field, you need to provide the model dimensions, which indicate the size of the embeddings generated for this field. You can pass reduced dimensions and the name of the vector search profile that specifies the algorithm configuration, along with `Vectorizer`.

In order to get the reduced embeddings using either the `text-embedding-3-small` or `text-embedding-3-large` models, it is necessary to include the `Dimensions` parameter. This parameter configures the desired number of dimensions for the output vector. Therefore, for `AzureOpenAIVectorizer`, we will retrieve the `VectorSearchDimensions` that is already specified in the corresponding index field definition. However, to ensure that dimensions are only passed along in the vectorizer for a model that supports it, we need to pass a required property named `ModelName`. This property enables the service to determine which model we are using, and dimensions will only be passed along when it is for a known supported model name.

We will create an instace of `SearchIndex` and define `Hotel` fields.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Reduced_Vector_Search_Index
string vectorSearchProfileName = "my-vector-profile";
string vectorSearchHnswConfig = "my-hsnw-vector-config";
string deploymentName = "my-text-embedding-3-small";
int modelDimensions = 256; // Here's the reduced model dimensions

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
            {
                VectorizerName = "openai"
            }
        },
        Algorithms =
        {
            new HnswAlgorithmConfiguration(vectorSearchHnswConfig)
        },
        Vectorizers =
        {
            new AzureOpenAIVectorizer("openai")
            {
                Parameters  = new AzureOpenAIVectorizerParameters()
                {
                    ResourceUri = new Uri(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT")),
                    ApiKey = Environment.GetEnvironmentVariable("OPENAI_KEY"),
                    DeploymentName = deploymentName,
                    ModelName = AzureOpenAIModelName.TextEmbedding3Small
                }
            }
        }
    },
};
```

After creating an instance of the `SearchIndex`, we need to instantiate the `SearchIndexClient` and call the `CreateIndex` method to create the search index. 

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Reduced_Vector_Search_Create_Index
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

Next, we will create sample hotel documents. The vector field requires submitting text input to an embedding model that converts human-readable text into a vector representation. To convert a text query string provided by a user into a vector representation, your application should utilize an embedding library that offers this functionality.

### Get Embeddings using `Azure.AI.OpenAI`

You can use Azure OpenAI embedding models, `text-embedding-3-small` or `text-embedding-3-large`, to get the reduced embeddings. With these models, you can specify the desired number of dimensions for the output vector by passing the `Dimensions` property. This enables you to customize the output according to your needs.

For more details about how to generate embeddings, refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-generate-embeddings). Here's an example of how you can get embeddings using [Azure.AI.OpenAI](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/openai/Azure.AI.OpenAI/README.md) library.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_GetEmbeddings_WithDimensions
public static ReadOnlyMemory<float> GetEmbeddings(string input)
{
    Uri endpoint = new Uri(Environment.GetEnvironmentVariable("OpenAI_ENDPOINT"));
    string key = Environment.GetEnvironmentVariable("OpenAI_API_KEY");
    AzureKeyCredential credential = new AzureKeyCredential(key);

    AzureOpenAIClient openAIClient = new AzureOpenAIClient(endpoint, credential);
    EmbeddingClient embeddingClient = openAIClient.GetEmbeddingClient("my-text-embedding-3-small");

    EmbeddingGenerationOptions embeddingsOptions = new EmbeddingGenerationOptions()
    {
        Dimensions = 256
    };
    OpenAIEmbedding embedding = embeddingClient.GenerateEmbedding(input, embeddingsOptions);
    return embedding.ToFloats();
}
```

In the sample code below, we are using `GetEmbeddings` method mentioned above to get embeddings for the vector fields named `DescriptionVector` and `CategoryVector`:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Documents
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

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Reduced_Vector_Search_Upload_Documents
SearchClient searchClient = new(endpoint, indexName, credential);
Hotel[] hotelDocuments = GetHotelDocuments();
await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotelDocuments));
```

## Query Vector Data

When using `VectorizableTextQuery`, the query for a vector field should be the text that will be vectorized based on the `Vectorizer` configuration in order to perform a vector search.

Let's query the index and make sure everything works as implemented. You can also refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-how-to-query) for more information on querying vector data.

### Vector Search

In this vector query, the `VectorQueries` contains the vectorizable text of the query input. The `Fields` property specifies which vector fields are searched. The `KNearestNeighborsCount` property specifies the number of nearest neighbors to return as top hits.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Reduced_Vector_Search
SearchResults<Hotel> response = await searchClient.SearchAsync<Hotel>(
    new SearchOptions
    {
        VectorSearch = new()
        {
            Queries = { new VectorizableTextQuery("Luxury hotels in town") {
            KNearestNeighborsCount = 3,
            Fields = { "DescriptionVector" } } },
        }
    });

int count = 0;
Console.WriteLine($"Vector Search Results:");
await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    count++;
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.HotelId}: {doc.HotelName}");
}
Console.WriteLine($"Total number of search results:{count}");
```
