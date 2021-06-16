# Azure Cognitive Search client library for .NET

[Azure Cognitive Search](https://docs.microsoft.com/azure/search/) is a
search-as-a-service cloud solution that gives developers APIs and tools
for adding a rich search experience over private, heterogeneous content
in web, mobile, and enterprise applications.

The Azure Cognitive Search service is well suited for the following
 application scenarios:

* Consolidate varied content types into a single searchable index.
  To populate an index, you can push JSON documents that contain your content,
  or if your data is already in Azure, create an indexer to pull in data
  automatically.
* Attach skillsets to an indexer to create searchable content from images
  and large text documents. A skillset leverages AI from Cognitive Services
  for built-in OCR, entity recognition, key phrase extraction, language
  detection, text translation, and sentiment analysis. You can also add
  custom skills to integrate external processing of your content during
  data ingestion.
* In a search client application, implement query logic and user experiences
  similar to commercial web search engines.

Use the Azure.Search.Documents client library to:

* Submit queries for simple and advanced query forms that include fuzzy
  search, wildcard search, regular expressions.
* Implement filtered queries for faceted navigation, geospatial search,
  or to narrow results based on filter criteria.
* Create and manage search indexes.
* Upload and update documents in the search index.
* Create and manage indexers that pull data from Azure into an index.
* Create and manage skillsets that add AI enrichment to data ingestion.
* Create and manage analyzers for advanced text analysis or multi-lingual content.
* Optimize results through scoring profiles to factor in business logic or freshness.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Cognitive Search client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Search.Documents --version 11.2.0-beta.1
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[search service][create_search_service_docs] to use this package.

To create a new search service, you can use the [Azure portal][create_search_service_docs],
[Azure PowerShell][create_search_service_ps], or the [Azure CLI][create_search_service_cli].
Here's an example using the Azure CLI to create a free instance for getting started:

```Powershell
az search service create --name <mysearch> --resource-group <mysearch-rg> --sku free --location westus
```

See [choosing a pricing tier](https://docs.microsoft.com/azure/search/search-sku-tier)
 for more information about available options.

### Authenticate the client

All requests to a search service need an api-key that was generated specifically
for your service. [The api-key is the sole mechanism for authenticating access to
your search service endpoint.](https://docs.microsoft.com/azure/search/search-security-api-keys)
You can obtain your api-key from the
[Azure portal](https://portal.azure.com/) or via the Azure CLI:

```Powershell
az search admin-key show --service-name <mysearch> --resource-group <mysearch-rg>
```

There are two types of keys used to access your search service: **admin**
*(read-write)* and **query** *(read-only)* keys.  Restricting access and
operations in client apps is essential to safeguarding the search assets on your
service.  Always use a query key rather than an admin key for any query
originating from a client app.

*Note: The example Azure CLI snippet above retrieves an admin key so it's easier
to get started exploring APIs, but it should be managed carefully.*

We can use the api-key to create a new `SearchClient`.

## Next steps

* Go further with Azure.Search.Documents and our [samples][samples]
* Watch a [demo or deep dive video](https://azure.microsoft.com/resources/videos/index/?services=search)
* Read more about the [Azure Cognitive Search service](https://docs.microsoft.com/azure/search/search-what-is-azure-search)

## Contributing

See our [Search CONTRIBUTING.md][search_contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fsearch%2FAzure.Search.Documents%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/search/Azure.Search.Documents/src
[package]: https://www.nuget.org/packages/Azure.Search.Documents/
[docs]: https://docs.microsoft.com/dotnet/api/Azure.Search.Documents
[rest_docs]: https://docs.microsoft.com/rest/api/searchservice/
[product_docs]: https://docs.microsoft.com/azure/search/
[nuget]: https://www.nuget.org/
[create_search_service_docs]: https://docs.microsoft.com/azure/search/search-create-service-portal
[create_search_service_ps]: https://docs.microsoft.com/azure/search/search-manage-powershell#create-or-delete-a-service
[create_search_service_cli]: https://docs.microsoft.com/cli/azure/search/service?view=azure-cli-latest#az-search-service-create
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[status_codes]: https://docs.microsoft.com/rest/api/searchservice/http-status-codes
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/search/Azure.Search.Documents/samples/
[search_contrib]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/search/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
