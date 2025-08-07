# Newtonsoft.Json support for Azure Core shared client library for .NET

The [Azure.Core package][azure_core_package] contains types shared by the latest Azure SDK client libraries. This `Newtonsoft.Json` compatibility library:

- Contains converters dependent upon the [Newtonsoft.Json][newtonsoft_json_package] package.
- Enables serialization and deserialization of custom model types using `Newtonsoft.Json`. Those custom model types may then be used with the following client libraries:
  - [Azure.DigitalTwins.Core][azure_digital_twins_core_package]
  - [Azure.Search.Documents][azure_search_documents_package]

## Getting started

### Install the package

Install this package from [NuGet] using the .NET CLI:

```dotnetcli
dotnet add package Microsoft.Azure.Core.NewtonsoftJson
```

## Key concepts

This support package contains the `NewtonsoftJsonObjectSerializer` class which can be passed to some Azure SDKs' client options classes, as shown in the examples below.

The following converters are added automatically to the `NewtonsoftJsonObjectSerializer` if you do not pass your own `JsonSerializerSettings`:

- `NewtonsoftJsonETagConverter` to convert `Azure.ETag` properties.

See the example [Using default converters](#using-default-converters) below for getting an instance of `JsonSerializerSettings` with this default list you can then modify as needed.

## Examples

The [Azure.Search.Documents package][azure_search_documents_package] is used in examples to show how search results can be deserialized. For more information and examples using Azure.Search.Documents, see its [README][azure_search_documents_readme].

### Deserializing models

Consider a custom model class containing information about movies:

```C# Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_Model
public class Movie
{
    [JsonProperty("uuid")]
    public string Id { get; private set; } = Guid.NewGuid().ToString();

    public string Title { get; set; }

    public string Description { get; set; }

    public float Rating { get; set; }
}
```

Our Azure Cognitive Search index is defined using camelCase fields, and the `Id` field is actually defined as "uuid"; however, we can provide an idiomatic model without having to attribute all properties by setting the `JsonSerializerSettings.ContractResolver` property as shown below:

```C# Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_SearchSample
// Get the Azure Cognitive Search endpoint and read-only API key.
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

// Create serializer options with default converters for Azure SDKs.
JsonSerializerSettings serializerSettings = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();

// Serialize property names using camelCase by default.
serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

SearchClientOptions clientOptions = new SearchClientOptions
{
    Serializer = new NewtonsoftJsonObjectSerializer(serializerSettings)
};

SearchClient client = new SearchClient(endpoint, "movies", credential, clientOptions);
Response<SearchResults<Movie>> results = client.Search<Movie>("Return of the King");

foreach (SearchResult<Movie> result in results.Value.GetResults())
{
    Movie movie = result.Document;

    Console.WriteLine(movie.Title);
    Console.WriteLine(movie.Description);
    Console.WriteLine($"Rating: {movie.Rating}\n");
}
```

If searching an index full of movies, the following may be printed:
<!-- cspell:word Aragorn Sauron's -->
```text
The Lord of the Rings: The Return of the King
Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.
Rating: 9.1
```

### Using default converters

If you instantiate a `NewtonsoftJsonObjectSerializer` using the default constructor, some converters for common Azure SDKs are added automatically as listed above in [Key concepts](#key-concepts). To modify these default settings, you can create a new `JsonSerializerSettings` like in the following example:

```C# Snippet:Microsoft_Azure_Core_NewtonsoftJson_Samples_Readme_DefaultSerializerSettings
JsonSerializerSettings serializerSettings = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();

// Serialize property names using camelCase by default.
serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

// Add converters as needed, for example, to convert movie genres to an enum.
serializerSettings.Converters.Add(new StringEnumConverter());

SearchClientOptions clientOptions = new SearchClientOptions
{
    Serializer = new NewtonsoftJsonObjectSerializer(serializerSettings)
};
```

You can add or remove converters, set the `ContractResolver`, or any other members of `JsonSerializerSettings` you need.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

[azure_core_package]: https://www.nuget.org/packages/Azure.Core/
[azure_digital_twins_core_package]: https://www.nuget.org/packages/Azure.DigitalTwins.Core
[azure_search_documents_package]: https://www.nuget.org/packages/Azure.Search.Documents/
[azure_search_documents_readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/README.md
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[newtonsoft_json_package]: https://www.nuget.org/packages/Newtonsoft.Json/
[NuGet]: https://www.nuget.org
