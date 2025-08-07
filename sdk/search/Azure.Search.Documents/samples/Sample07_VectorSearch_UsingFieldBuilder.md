# Vector Search Using Field Builder

The `FieldBuilder` class allows you to define a Search index from a model type. This sample demonstrates how to create a vector fields index using the field builder.

## Model Creation

Consider the following model, which includes a property named `DescriptionVector` that represents a vector field. To configure a vector field, you must provide the model dimensions, indicating the size of the embeddings generated for this field, as well as the name of the vector search profile that specifies the algorithm configuration in the `VectorSearchField` attribute.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_FieldBuilder_Model
public class MyDocument
{
    [SimpleField(IsKey = true, IsFilterable = true, IsSortable = true)]
    public string Id { get; set; }

    [SearchableField(IsFilterable = true, IsSortable = true)]
    public string Name { get; set; }

    [SearchableField(AnalyzerName = "en.microsoft")]
    public string Description { get; set; }

    [VectorSearchField(VectorSearchDimensions = 1536, VectorSearchProfileName = "my-vector-profile")]
    public IReadOnlyList<float> DescriptionVector { get; set; }
}
```

## Create an Index using `FieldBuilder`

We will create an instace of `SearchIndex` and use `FieldBuilder` to define fields based on the `MyDocument` model class.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Index_UsingFieldBuilder
string vectorSearchProfileName = "my-vector-profile";
string vectorSearchHnswConfig = "my-hsnw-vector-config";

string indexName = "my-document";
// Create Index
SearchIndex searchIndex = new SearchIndex(indexName)
{
    Fields = new FieldBuilder().Build(typeof(MyDocument)),
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

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample07_Vector_Search_Create_Index_FieldBuilder
Uri endpoint = new(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
AzureKeyCredential credential = new(key);

SearchIndexClient indexClient = new(endpoint, credential);
await indexClient.CreateIndexAsync(searchIndex);
```

To perform vector search please refer to the [Vector Search Using Vectorized Query](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizedQuery.md) sample or [Vector Search Using Vectorizable Text Query](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch_UsingVectorizableTextQuery.md) samples.
