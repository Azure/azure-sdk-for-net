# Newtonsoft.Json support for Microsoft.Spatial library for .NET

The [Microsoft.Spatial package][microsoft_spatial_package] contains classes and methods that support geographic and geometric operations. This library contains converters dependent on the [Newtonsoft.Json package][newtonsoft_json_package] for use with Microsoft.Spatial when using the Azure SDK for .NET.

## Getting started

Install this package if you use the Microsoft.Spatial package in your application and want to serialize supported classes with Newtonsoft.Json.

### Install the package

Install this package from [NuGet] using the .NET CLI:

```bash
dotnet add package Microsoft.Azure.Core.Spatial.NewtonsoftJson
```

## Key concepts

This support package contains the `NewtonsoftJsonMicrosoftSpatialGeoJsonConverter` class which can be added to [JsonSerializerSettings] to deserialize geographic objects like `GeographyPoint`. This converter can be used with Azure SDK client libraries as shown in examples below.

## Examples

The [Azure.Search.Documents package][azure_search_documents_package] is used in examples to show how search results containing geographic points can be deserialized. For more information and examples using Azure.Search.Documents, see its [README][azure_search_documents_readme].

### Deserializing documents

Consider a model class containing information about mountains:

```C# Snippet:Microsoft_Azure_Core_Spatial_NewtonsoftJson_Samples_Readme_Model
public class Mountain
{
    [SimpleField(IsKey = true)]
    public string Id { get; set; }

    [SearchableField(IsSortable = true, AnalyzerName = LexicalAnalyzerName.Values.EnLucene)]
    public string Name { get; set; }

    [SimpleField(IsFacetable = true, IsFilterable = true)]
    public GeographyPoint Summit { get; set; }
}
```

Adding the `NewtonsoftJsonMicrosoftSpatialGeoJsonConverter` class to serializer options will correctly deserialize the summit location:

```C# Snippet:Microsoft_Azure_Core_Spatial_NewtonsoftJson_Samples_Readme_SearchSample
// Get the Azure Cognitive Search endpoint and read-only API key.
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

// Create serializer options with our converter to deserialize geographic points.
JsonSerializerSettings serializerSettings = new JsonSerializerSettings
{
    ContractResolver = new CamelCasePropertyNamesContractResolver(),
    Converters =
    {
        new NewtonsoftJsonMicrosoftSpatialGeoJsonConverter()
    }
};

SearchClientOptions clientOptions = new SearchClientOptions
{
    Serializer = new NewtonsoftJsonObjectSerializer(serializerSettings)
};

SearchClient client = new SearchClient(endpoint, "mountains", credential, clientOptions);
Response<SearchResults<Mountain>> results = client.Search<Mountain>("Rainier");

foreach (SearchResult<Mountain> result in results.Value.GetResults())
{
    Mountain mountain = result.Document;
    Console.WriteLine("https://www.bing.com/maps?cp={0}~{1}&sp=point.{0}_{1}_{2}",
        mountain.Summit.Latitude,
        mountain.Summit.Longitude,
        Uri.EscapeUriString(mountain.Name));
}
```

If searching an index full of mountains, the following may be printed:

```text
https://www.bing.com/maps?cp=46.85287~-121.76044&sp=point.46.85287_-121.76044_Mount%20Rainier
```

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fcore%2FMicrosoft.Azure.Core.NewtonsoftJson%2FREADME.png)

[azure_search_documents_package]: https://www.nuget.org/packages/Azure.Search.Documents/
[azure_search_documents_readme]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/search/Azure.Search.Documents/README.md
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[JsonSerializerSettings]: https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonSerializerSettings.htm
[microsoft_spatial_package]: https://www.nuget.org/packages/Microsoft.Spatial/
[newtonsoft_json_package]: https://www.nuget.org/packages/Newtonsoft.Json/
[NuGet]: https://www.nuget.org
