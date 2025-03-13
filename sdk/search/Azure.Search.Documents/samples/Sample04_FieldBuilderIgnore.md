# Azure.Search.Documents Samples - Using FieldBuilderIgnoreAttribute

The `FieldBuilder` class allows you to define a Search index from a model type,
though not all property types are supported by a Search index without workarounds.

If when using `FieldBuilder` you see the following exception, use the following workaround:

> Property 'Genre' is of type 'MovieGenre', which does not map to an
> Azure Search data type. Please use a supported data type or mark the property with \[FieldBuilderIgnore\]
> and define the field by creating a SearchField object. See https://aka.ms/azsdk/net/search/fieldbuilder for more information.";

## Model

Consider the following model, which declares a property of an `enum` type,
which are not currently supported.

```C# Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_Types
public class Movie
{
    [SimpleField(IsKey = true)]
    public string Id { get; set; }

    [SearchableField(IsSortable = true, AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
    public string Name { get; set; }

    [FieldBuilderIgnore]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MovieGenre Genre { get; set; }

    [SimpleField(IsFacetable = true, IsFilterable = true, IsSortable = true)]
    public int Year { get; set; }

    [SimpleField(IsFilterable = true, IsSortable = true)]
    public double Rating { get; set; }
}

public enum MovieGenre
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

Declaring enum property types will throw an exception if not ignored using either the
`[FieldBuilderIgnore]` attribute, or another attribute like `[JsonIgnore]` of
`System.Text.Json`, `Newtonsoft.Json`, or any other method of ignoring a property entirely
for the serializer you've specified in `SearchClientOptions.Serializer`. Enum property types
are not supported by default because you may instead want to serialize them as their
integer values to save space in an index.

The `Genre` property is attributed with `[FieldBuilderIgnore]` so that `FieldBuilder` will ignore it
when generating fields for a Search index. You can then define a field manually as shown below.

## Create an index

After creating the index using `FieldBuilder`, you can add fields manually.
For the `Genre` property we declare that the serializer should convert the `MovieGenre` enum
to a string, and define the `genre` index field ourselves.

```C# Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_CreateIndex
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

// Define client options to use camelCase when serializing property names.
SearchClientOptions options = new SearchClientOptions(ServiceVersion)
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
    NormalizerName = LexicalNormalizerName.Lowercase,
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

```C# Snippet:Azure_Search_Tests_Sample2_FieldBuilderIgnore_UploadDocument
Movie movie = new Movie
{
    Id = Guid.NewGuid().ToString("n"),
    Name = "The Lord of the Rings: The Return of the King",
    Genre = MovieGenre.Fantasy,
    Year = 2003,
    Rating = 9.1
};

// Add a movie to the index.
SearchClient searchClient = indexClient.GetSearchClient(index.Name);
searchClient.UploadDocuments(new[] { movie });
```

Similarly, deserializing converts it from a string back into a `MovieGenre` enum value.
