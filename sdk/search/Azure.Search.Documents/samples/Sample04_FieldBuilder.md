# Azure.Search.Documents Samples - FieldBuilder

The `FieldBuilder` class allows you to define a Search index from a model type,
though not all property types are supported by a Search index without workarounds.

## Model

Consider the following model, which declares a property of an `enum` type.

```C# Snippet:Azure_Search_Tests_Sample2_FieldBuilder_Types
public class Movie
{
    [SimpleField(IsKey = true)]
    public string Id { get; set; }

    [SearchableField(IsSortable = true, AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
    public string Name { get; set; }

    [FieldBuilderIgnore]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Genre Genre { get; set; }

    [SimpleField(IsFacetable = true, IsFilterable = true, IsSortable = true)]
    public int Year { get; set; }

    [SimpleField(IsFilterable = true, IsSortable = true)]
    public double Rating { get; set; }
}

public enum Genre
{
    Unknown,
    Action,
    Comedy,
    Drama,
    Fantasy,
    Horror,
    Romance,
    SciFi,
}
```

The property is attributed with `[FieldBuilderIgnore]` so that `FieldBuilder` will ignore it
when generating fields for a Search index.

Declaring enum property types will throw an exception if not ignored using either the
`[FieldBuilderIgnore]` attribute, or another attribute like `[JsonIgnore]` of
`System.Text.Json`, `Newtonsoft.Json`, or any other method of ignoring a property entirely
for the serializer you've specified in `SearchClientOptions.Serializer`. Enum property types
are not processed by default because you may instead want to serialize them as their
integer values to save space in an index.

## Create an index

After creating the index using `FieldBuilder`, you can add fields manually.
For the `Genre` property we declare that the serializer should convert the `Genre` enum
to a string, and define the `genre` index field ourselves.

```C# Snippet:Azure_Search_Tests_Sample2_FieldBuilder_CreateIndex
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

// Define client options to use camelCase when serializing property names.
SearchClientOptions options = new SearchClientOptions
{
    Serializer = new JsonObjectSerializer(
        new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        })
};

// Create a service client.
AzureKeyCredential credential = new AzureKeyCredential(key);
SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential, options);

// Create the FieldBuilder using the same serializer.
FieldBuilder fieldBuilder = new FieldBuilder
{
    Serializer = options.Serializer
};

// Create the index using FieldBuilder.
SearchIndex index = new SearchIndex("movies")
{
    Fields = fieldBuilder.Build(typeof(Movie)),
    Suggesters =
    {
        // Suggest query terms from the "name" field.
        new SearchSuggester("n", "name")
    }
};

// Define the "genre" field as a string.
SearchableField genreField = new SearchableField("genre")
{
    AnalyzerName = LexicalAnalyzerName.Values.EnLucene,
    IsFacetable = true,
    IsFilterable = true
};
index.Fields.Add(genreField);

// Create the index.
indexClient.CreateIndex(index);
```

## Upload a document

When a `Movie` is serialized, the `Genre` property is converted to a string and
populates the index's `genre` field.

```C# Snippet:Azure_Search_Tests_Sample2_FieldBuilder_UploadDocument
Movie movie = new Movie
{
    Id = Guid.NewGuid().ToString("n"),
    Name = "The Lord of the Rings: The Return of the King",
    Genre = Genre.Fantasy,
    Year = 2003,
    Rating = 9.1
};

// Add a movie to the index.
SearchClient searchClient = indexClient.GetSearchClient(index.Name);
searchClient.UploadDocuments(new[] { movie });
```

Similarly, deserializing converts it from a string back into a `Genre` enum value.
