# Azure Cognitive Search client library for .NET

Azure Cognitive Search ([formerly known as "Azure Search"](https://docs.microsoft.com/azure/search/whats-new#new-service-name))
is a search-as-a-service cloud solution that gives developers APIs and tools
for adding a rich search experience over private, heterogeneous content in web,
mobile, and enterprise applications. Your code or a tool invokes data ingestion
(indexing) to create and load an index. Optionally, you can add cognitive
skills to apply AI processes during indexing. Doing so can add new information
and structures useful for search and other scenarios.

On the other side of your service, your application code issues query requests
and handles responses.  The search experience is defined in your client using
functionality from Azure Cognitive Search, with query execution over a
persisted index that you create, own, and store in your service.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Cognitive Search client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Search --version 1.0.0-preview.1
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Search Service][create_search_service_docs] to use this package.

To create a new Search Service, you can use the [Azure Portal][create_search_service_docs],
[Azure PowerShell][create_search_service_ps], or the [Azure CLI][create_search_service_cli].
Here's an example using the Azure CLI to create a free instance for getting started:

```Powershell
az search service create --name mysearch --resource-group mysearch-rg --sku free --location westus
```

## Key concepts

Azure Cognitive Search is the only cloud search service with built-in AI
capabilities that enrich all types of information to easily identify and
explore relevant content at scale.

- Fully managed search as a service to reduce complexity and scale easily
- Auto-complete, geospatial search, filtering, and faceting capabilities for a rich user experience
- Built-in AI capabilities including OCR, key phrase extraction, and named entity recognition to unlock insights
- Flexible integration of custom models, classifiers, and rankers to fit your domain-specific needs

`Azure.Search` offers two types of resources:

- The _search service_ used via `SearchServiceClient` to create and manage search indexes
- A _search index_ in the search service used via `SearchIndexClient` to query and manage the documents in a search index

## Examples

### Getting service statistics

```C# Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
// Create a new SearchServiceClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
SearchApiKeyCredential credential = new SearchApiKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
SearchServiceClient search = new SearchServiceClient(endpoint, credential);

// Get and report the Search Service statistics
Response<SearchServiceStatistics> stats = await search.GetStatisticsAsync();
Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} of {stats.Value.Counters.IndexCounter.Quota} indexes.");
```

### Counting the documents in an index

```C# Snippet:Azure_Search_Tests_Samples_GetCountAsync
// Create a SearchIndexClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
SearchApiKeyCredential credential = new SearchApiKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");
SearchIndexClient index = new SearchIndexClient(endpoint, indexName, credential);

// Get and report the number of documents in the index
Response<long> count = await index.GetCountAsync();
Console.WriteLine($"Search index {indexName} has {count.Value} documents.");
```

### Async APIs

We fully support both synchronous and asynchronous APIs.
```C# Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
// Create a new SearchServiceClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
SearchApiKeyCredential credential = new SearchApiKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
SearchServiceClient search = new SearchServiceClient(endpoint, credential);

// Get and report the Search Service statistics
Response<SearchServiceStatistics> stats = await search.GetStatisticsAsync();
Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} of {stats.Value.Counters.IndexCounter.Quota} indexes.");
```

## Troubleshooting

All Search operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`Status` codes][status_codes].  Many of these errors are recoverable.

```C# Snippet:Azure_Search_Tests_Samples_HandleErrors
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
SearchApiKeyCredential credential = new SearchApiKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

// Create an invalid SearchIndexClientClient
string fakeIndexName = "doesnotexist";
SearchIndexClient index = new SearchIndexClient(endpoint, fakeIndexName, credential);
try
{
    index.GetCount();
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Index wasn't found.");
}
```

## Next steps

Get started with our [samples][samples]:

- Get started either [synchronously](samples/Sample01a_HelloWorld.md) or [asynchronously](samples/Sample01b_HelloWorldAsync.md).
- Perform [service level operations](samples/Sample02_Service.md).
- Perform [index level operations](samples/Sample03_Index.md).
 
## Contributing

See the [Search CONTRIBUTING.md][search_contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fsearch%2FAzure.Search%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/search/Azure.Search/src
[package]: https://www.nuget.org/packages/Azure.Search/
[docs]: https://docs.microsoft.com/dotnet/api/Azure.Search
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
[samples]: samples/
[search_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
