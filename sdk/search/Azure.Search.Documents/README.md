# Azure Cognitive Search client library for .NET

[Azure Cognitive Search](https://docs.microsoft.com/azure/search/) is a
search-as-a-service cloud solution that gives developers APIs and tools for
adding a rich search experience over private, heterogeneous content in web,
mobile, and enterprise applications.

The **Azure Cognitive Search service** is well suited for the following
application scenarios:

- Consolidate varied content types into a single searchable index. Populate the
  index with your own JSON documents or, if your content is already in Azure,
  you can create an indexer to pull in data automatically.
- Import raw content such as text, images, or Office files from Azure Blob
  Storage or Cosmos DB.
- Easily implement your own search capabilities similar to commercial web search
  engines.  Azure Cognitive Search APIs simplify query construction, faceted
  navigation, filters (including geo-spatial search), synonym mapping, typeahead
  queries, and relevance tuning.
- Index unstructured text and extract both text and information from images. AI
  enrichment enables capabilities such as OCR, entity recognition, key phrase
  extraction, language detection, text translation, and sentiment analysis.

Use the **Azure.Search.Documents client library** to:

- Create and manage search indexes.
- Upload and update documents in the search index.
- Manage indexers that pull data from a data source into an index.
- Query documents in the index with a powerful set of search APIs that support
  faceted navigation, typeahead queries, suggestions, and geo-spatial search.
- Enrich your search index with AI skills that add structure or extract meaning
  from raw documents during indexing.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Cognitive Search client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Search.Documents --version 1.0.0-preview.5
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
your search service endpoint.](https://docs.microsoft.com/azure/search/search-security-api-keys)  You can obtain your api-key from the
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

```C# Snippet:Azure_Search_Tests_Samples_Readme_Authenticate
string indexName = "nycjobs";

// Get the service endpoint and API key from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

// Create a client
AzureKeyCredential credential = new AzureKeyCredential(key);
SearchClient client = new SearchClient(endpoint, indexName, credential);
```

### Send your first search query

To get running immediately, we're going to connect to a well known sandbox
Search service provided by Microsoft.  This means you do not need an Azure
subscription or Azure Cognitive Search service to try out this query.

```C# Snippet:Azure_Search_Tests_Samples_Readme_FirstQuery
// We'll connect to the Azure Cognitive Search public sandbox and send a
// query to its "nycjobs" index built from a public dataset of available jobs
// in New York.
string serviceName = "azs-playground";
string indexName = "nycjobs";
string apiKey = "252044BE3886FE4A8E3BAA4F595114BB";

// Create a SearchClient to send queries
Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
AzureKeyCredential credential = new AzureKeyCredential(apiKey);
SearchClient client = new SearchClient(serviceEndpoint, indexName, credential);

// Let's get the top 5 jobs related to Microsoft
SearchResults<SearchDocument> response = client.Search<SearchDocument>("Microsoft", new SearchOptions { Size = 5 });
foreach (SearchResult<SearchDocument> result in response.GetResults())
{
    // Print out the title and job description (we'll see below how to
    // use C# objects to make accessing these fields much easier)
    string title = (string)result.Document["business_title"];
    string description = (string)result.Document["job_description"];
    Console.WriteLine($"{title}\n{description}\n");
}
```

You can paste that into a new console app,
[install the Azure.Search.Documents package](#Install-the-package), add a
`using Azure.Search.Documents;` statement, and then hit F5 to run.

## Key concepts

An Azure Cognitive Search service contains one or more indexes that provide
persistent storage of searchable data in the form of JSON documents.  _(If
you're brand new to search, you can make a very rough analogy between
indexes and database tables.)_  The Azure.Search.Documents client library
exposes operations on these resources through two main client types.

- `SearchClient` helps with:
  - [Searching](https://docs.microsoft.com/azure/search/search-lucene-query-architecture)
    your indexed documents using
    [rich queries](https://docs.microsoft.com/azure/search/search-query-overview)
    and [powerful data shaping](https://docs.microsoft.com/azure/search/search-filters)
  - [Autocompleting](https://docs.microsoft.com/rest/api/searchservice/autocomplete)
    partially typed search terms based on documents in the index
  - [Suggesting](https://docs.microsoft.com/rest/api/searchservice/suggestions)
   the most likely matching text in documents as a user types
  - [Adding, Updating or Deleting Documents](https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents)
    documents from an index

- `SearchIndexClient` allows you to:
  - [Create, delete, update, or configure a search index](https://docs.microsoft.com/rest/api/searchservice/index-operations)
  - [Declare custom synonym maps to expand or rewrite queries](https://docs.microsoft.com/rest/api/searchservice/synonym-map-operations)
  - Most of the `SearchServiceClient` functionality is not yet available in our current preview

- `SearchIndexerClient` allows you to:
  - [Start indexers to automatically crawl data sources](https://docs.microsoft.com/rest/api/searchservice/indexer-operations)
  - [Define AI powered Skillsets to transform and enrich your data](https://docs.microsoft.com/rest/api/searchservice/skillset-operations)

_The `Azure.Search.Documents` client library (v1) is a brand new offering for
.NET developers who want to use search technology in their applications.  There
is an older, fully featured `Microsoft.Azure.Search` client library (v10) with
many similar looking APIs, so please be careful to avoid confusion when
exploring online resources.  A good rule of thumb is to check for the namespace
`using Azure.Search.Documents;` when you're looking for us._

## Examples

The following examples all use a simple [Hotel data set](https://docs.microsoft.com/samples/azure-samples/azure-search-sample-data/azure-search-sample-data/)
that you can [import into your own index from the Azure portal.](https://docs.microsoft.com/azure/search/search-get-started-portal#step-1---start-the-import-data-wizard-and-create-a-data-source)
These are just a few of the basics - please [check out our Samples][samples] for
much more.

### Querying

Let's start by importing our namespaces.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Namespace
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
```

We'll then create a `SearchClient` to access our hotels search index.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Client
// Get the service endpoint and API key from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");
string indexName = "hotels";

// Create a client
AzureKeyCredential credential = new AzureKeyCredential(key);
SearchClient client = new SearchClient(endpoint, indexName, credential);
```

There are two ways to interact with the data returned from a search query.
Let's explore them with a search for a "luxury" hotel.

#### Use `SearchDocument` like a dictionary

`SearchDocument` is the default type returned from queries when you don't
provide your own.  Here we perform the search, enumerate over the results, and
extract data using `SearchDocument`'s dictionary indexer.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Dict
SearchResults<SearchDocument> response = client.Search<SearchDocument>("luxury");
foreach (SearchResult<SearchDocument> result in response.GetResults())
{
    SearchDocument doc = result.Document;
    string id = (string)doc["hotelId"];
    string name = (string)doc["hotelName"];
    Console.WriteLine("{id}: {name}");
}
```

#### Use C# types

We can also decorate our own types with [attributes from `System.Text.Json`](https://docs.microsoft.com/dotnet/standard/serialization/system-text-json-how-to):

```C# Snippet:Azure_Search_Tests_Samples_Readme_StaticType
public class Hotel
{
    [JsonPropertyName("hotelId")]
    public string Id { get; set; }

    [JsonPropertyName("hotelName")]
    public string Name { get; set; }
}
```

And use them in place of `SearchDocument` when querying.

```C# Snippet:Azure_Search_Tests_Samples_Readme_StaticQuery
SearchResults<Hotel> response = client.Search<Hotel>("luxury");
foreach (SearchResult<Hotel> result in response.GetResults())
{
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.Id}: {doc.Name}");
}
```

If you're working with a search index and know the schema, creating C# types
is recommended.

#### SearchOptions

The `SearchOptions` provide powerful control over the behavior of our queries.
Let's search for the top 5 luxury hotels with a good rating.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Options
int stars = 4;
SearchOptions options = new SearchOptions
{
    // Filter to only ratings greater than or equal our preference
    Filter = SearchFilter.Create($"rating ge {stars}"),
    Size = 5, // Take only 5 results
    OrderBy = new[] { "rating desc" } // Sort by rating from high to low
};
SearchResults<Hotel> response = client.Search<Hotel>("luxury", options);
// ...
```

### Creating an index

You can use the `SearchIndexClient` to create a search index. Fields can be
defined using convenient `SimpleField`, `SearchableField`, or `ComplexField`
classes. Indexes can also define suggesters, lexical analyzers, and more.

```C# Snippet:Azure_Search_Tests_Samples_Readme_CreateIndex
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

// Create a service client
AzureKeyCredential credential = new AzureKeyCredential(key);
SearchIndexClient client = new SearchIndexClient(endpoint, credential);

// Create the index
SearchIndex index = new SearchIndex("hotels")
{
    Fields =
    {
        new SimpleField("hotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
        new SearchableField("hotelName") { IsFilterable = true, IsSortable = true },
        new SearchableField("description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
        new SearchableField("tags", collection: true) { IsFilterable = true, IsFacetable = true },
        new ComplexField("address")
        {
            Fields =
            {
                new SearchableField("streetAddress"),
                new SearchableField("city") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("stateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("country") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("postalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true }
            }
        }
    },
    Suggesters =
    {
        // Suggest query terms from both the hotelName and description fields.
        new SearchSuggester("sg", "hotelName", "description")
    }
};

client.CreateIndex(index);
```

### Adding documents to your index

You can `Upload`, `Merge`, `MergeOrUpload`, and `Delete` multiple documents from
an index in a single batched request.  There are
[a few special rules for merging](https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents#document-actions)
to be aware of.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Index
IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Create(
IndexDocumentsAction.Upload(new Hotel { Id = "783", Name = "Upload Inn" }),
IndexDocumentsAction.Merge(new Hotel { Id = "12", Name = "Renovated Ranch" }));

IndexDocumentsOptions options = new IndexDocumentsOptions { ThrowOnAnyError = true };
client.IndexDocuments(batch, options);
```

The request will succeed even if any of the individual actions fail and
return an `IndexDocumentsResult` for inspection.  There's also a `ThrowOnAnyError`
option if you only care about success or failure of the whole batch.

### Async APIs

All of the examples so far have been using synchronous APIs, but we provide full
support for async APIs as well.  You'll generally just add an `Async` suffix to
the name of the method and `await` it.

```C# Snippet:Azure_Search_Tests_Samples_Readme_StaticQueryAsync
SearchResults<Hotel> response = await client.SearchAsync<Hotel>("luxury");
await foreach (SearchResult<Hotel> result in response.GetResultsAsync())
{
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.Id}: {doc.Name}");
}
```

## Troubleshooting

Any Azure.Search.Documents operation that fails will throw a
[`RequestFailedException`][RequestFailedException] with
helpful [`Status` codes][status_codes].  Many of these errors are recoverable.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Troubleshooting
try
{
    return client.GetDocument<Hotel>("12345");
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("We couldn't find the hotel you are looking for!");
    Console.WriteLine("Please try selecting another.");
    return null;
}
```

You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig
deeper into the requests you're making against the service.

## Next steps

- [Go further with Azure.Search.Documents and our samples][samples]
- [Watch a demo or deep dive video](https://azure.microsoft.com/resources/videos/index/?services=search)
- [Read more about the Azure Cognitive Search service](https://docs.microsoft.com/azure/search/search-what-is-azure-search)

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
[samples]: samples/
[search_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
