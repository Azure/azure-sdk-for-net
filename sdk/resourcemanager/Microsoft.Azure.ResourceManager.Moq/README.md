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

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact opencode@microsoft.com with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fcore%2FMicrosoft.Azure.Core.NewtonsoftJson%2FREADME.png)

[azure_core_package]: https://www.nuget.org/packages/Azure.Core/
[azure_digital_twins_core_package]: https://www.nuget.org/packages/Azure.DigitalTwins.Core
[azure_search_documents_package]: https://www.nuget.org/packages/Azure.Search.Documents/
[azure_search_documents_readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/README.md
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[newtonsoft_json_package]: https://www.nuget.org/packages/Newtonsoft.Json/
[NuGet]: https://www.nuget.org
