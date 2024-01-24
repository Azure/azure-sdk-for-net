# Azure AI Search client library for .NET

[Azure AI Search](https://docs.microsoft.com/azure/search/) (formerly known as "Azure Cognitive Search") is an AI-powered information retrieval platform that helps developers build rich search experiences and generative AI apps that combine large language models with enterprise data.

The Azure AI Search service is well suited for the following application scenarios:

* Consolidate varied content types into a single searchable index.
  To populate an index, you can push JSON documents that contain your content,
  or if your data is already in Azure, create an indexer to pull in data
  automatically.
* Attach skillsets to an indexer to create searchable content from images
  and unstructured documents. A skillset leverages APIs from Azure AI Services
  for built-in OCR, entity recognition, key phrase extraction, language
  detection, text translation, and sentiment analysis. You can also add
  custom skills to integrate external processing of your content during
  data ingestion.
* In a search client application, implement query logic and user experiences
  similar to commercial web search engines and chat-style apps.

Use the Azure.Search.Documents client library to:

* Submit queries using vector, keyword, and hybrid query forms.
* Implement filtered queries for metadata, geospatial search, faceted navigation, 
  or to narrow results based on filter criteria.
* Create and manage search indexes.
* Upload and update documents in the search index.
* Create and manage indexers that pull data from Azure into an index.
* Create and manage skillsets that add AI enrichment to data ingestion.
* Create and manage analyzers for advanced text analysis or multi-lingual content.
* Optimize results through semantic ranking and scoring profiles to factor in business logic or freshness.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs] | [Samples][samples]

## Getting started

### Install the package

Install the Azure AI Search client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Search.Documents
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

To interact with the search service, you'll need to create an instance of the appropriate client class: `SearchClient` for searching indexed documents, `SearchIndexClient` for managing indexes, or `SearchIndexerClient` for crawling data sources and loading search documents into an index. To instantiate a client object, you'll need an **endpoint** and **Azure roles** or an **API key**. You can refer to the documentation for more information on [supported authenticating approaches](https://learn.microsoft.com/azure/search/search-security-overview#authentication) with the search service.

#### Get an API Key

An API key can be an easier approach to start with because it doesn't require pre-existing role assignments.

You can get the **endpoint** and an **API key** from the search service in the [Azure portal](https://portal.azure.com/). Please refer the [documentation](https://docs.microsoft.com/azure/search/search-security-api-keys) for instructions on how to get an API key.

Alternatively, you can use the following [Azure CLI](https://learn.microsoft.com/cli/azure/) command to retrieve the API key from the search service:

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

#### Create a SearchClient

To instantiate the `SearchClient`, you'll need the **endpoint**, **API key** and **index name**:

```C# Snippet:Azure_Search_Tests_Samples_Readme_Authenticate
string indexName = "nycjobs";

// Get the service endpoint and API key from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

// Create a client
AzureKeyCredential credential = new AzureKeyCredential(key);
SearchClient client = new SearchClient(endpoint, indexName, credential);
```

#### Create a client using Microsoft Entra ID authentication

You can also create a `SearchClient`, `SearchIndexClient`, or `SearchIndexerClient` using Microsoft Entra ID authentication. Your user or service principal must be assigned the "Search Index Data Reader" role.
Using the [DefaultAzureCredential](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential) you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more all without changing code. Please refer the [documentation](https://learn.microsoft.com/azure/search/search-security-rbac?tabs=config-svc-portal%2Croles-portal%2Ctest-portal%2Ccustom-role-portal%2Cdisable-keys-portal) for instructions on how to connect to Azure AI Search using Azure role-based access control (Azure RBAC).

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md), you'll first need to [install the Azure.Identity package](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#install-the-package).

To use `DefaultAzureCredential` with a client ID and secret, you'll need to set the `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_CLIENT_SECRET` environment variables; alternatively, you can pass those values
to the `ClientSecretCredential` also in Azure.Identity.

Make sure you use the right namespace for `DefaultAzureCredential` at the top of your source file:

```C# Snippet:Azure_Search_Readme_Identity_Namespace
using Azure.Identity;
```

Then you can create an instance of `DefaultAzureCredential` and pass it to a new instance of your client:

```C# Snippet:Azure_Search_Readme_CreateWithDefaultAzureCredential
string indexName = "nycjobs";

// Get the service endpoint from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
DefaultAzureCredential credential = new DefaultAzureCredential();

// Create a client
SearchClient client = new SearchClient(endpoint, indexName, credential);
```

### ASP.NET Core
To inject `SearchClient` as a dependency in an ASP.NET Core app, first install the package `Microsoft.Extensions.Azure`. Then register the client in the `Startup.ConfigureServices` method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAzureClients(builder =>
    {
        builder.AddSearchClient(Configuration.GetSection("SearchClient"));
    });

    services.AddControllers();
}
```
To use the preceding code, add this to your configuration:

```json
{
    "SearchClient": {
      "endpoint": "https://<resource-name>.search.windows.net",
      "indexname": "nycjobs"
    }
}
```
You'll also need to provide your resource key to authenticate the client, but you shouldn't be putting that information in the configuration. Instead, when in development, use [User-Secrets](https://docs.microsoft.com/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows#how-the-secret-manager-tool-works). Add the following to `secrets.json`:

```json
{
    "SearchClient": {
      "credential": { "key": "<you resource key>" }
    }
}
```
When running in production, it's preferable to use [environment variables](https://docs.microsoft.com/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows#environment-variables):

```
SEARCH__CREDENTIAL__KEY="..."
```
Or use other secure ways of storing secrets like [Azure Key Vault](https://docs.microsoft.com/aspnet/core/security/key-vault-configuration?view=aspnetcore-5.0).

For more details about Dependency Injection in ASP.NET Core apps, see [Dependency injection with the Azure SDK for .NET](https://docs.microsoft.com/dotnet/azure/sdk/dependency-injection).

## Key concepts

An Azure AI Search service contains one or more indexes that provide
persistent storage of searchable data in the form of JSON documents.  _(If
you're brand new to search, you can make a very rough analogy between
indexes and database tables.)_  The Azure.Search.Documents client library
exposes operations on these resources through three main client types.

* `SearchClient` helps with:
  * [Searching](https://docs.microsoft.com/azure/search/search-lucene-query-architecture)
    your indexed documents using [vector queries](https://learn.microsoft.com/azure/search/vector-search-how-to-query),
    [keyword queries](https://learn.microsoft.com/azure/search/search-query-create)
    and [hybrid queries](https://learn.microsoft.com/azure/search/hybrid-search-how-to-query)
  * [Vector query filters](https://learn.microsoft.com/azure/search/vector-search-filters) and [Text query filters](https://learn.microsoft.com/azure/search/search-filters)
  * [Semantic ranking](https://learn.microsoft.com/azure/search/semantic-how-to-query-request) and [scoring profiles](https://learn.microsoft.com/azure/search/index-add-scoring-profiles) for boosting relevance
  * [Autocompleting](https://docs.microsoft.com/rest/api/searchservice/autocomplete)
    partially typed search terms based on documents in the index
  * [Suggesting](https://docs.microsoft.com/rest/api/searchservice/suggestions)
    the most likely matching text in documents as a user types
  * [Adding, Updating or Deleting Documents](https://docs.microsoft.com/rest/api/searchservice/addupdate-or-delete-documents)
    documents from an index

* `SearchIndexClient` allows you to:
  * [Create, delete, update, or configure a search index](https://docs.microsoft.com/rest/api/searchservice/index-operations)
  * [Declare custom synonym maps to expand or rewrite queries](https://docs.microsoft.com/rest/api/searchservice/synonym-map-operations)

* `SearchIndexerClient` allows you to:
  * [Create indexers to automatically crawl data sources](https://docs.microsoft.com/rest/api/searchservice/indexer-operations)
  * [Define AI powered Skillsets to transform and enrich your data](https://docs.microsoft.com/rest/api/searchservice/skillset-operations)

Azure AI Search provides two powerful features:

#### Semantic ranking

Semantic ranking enhances the quality of search results for text-based queries. By enabling semantic ranking on your search service, you can improve the relevance of search results in two ways:
- It applies secondary ranking to the initial result set, promoting the most semantically relevant results to the top.
- It extracts and returns captions and answers in the response, which can be displayed on a search page to enhance the user's search experience.

To learn more about Semantic Search, you can refer to the [sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample08_SemanticSearch.md).

Additionally, for more comprehensive information about Semantic Search, including its concepts and usage, you can refer to the [documentation](https://learn.microsoft.com/azure/search/semantic-search-overview). The documentation provides in-depth explanations and guidance on leveraging the power of Semantic Search in Azure Cognitive Search.

#### Vector search

Vector search is an information retrieval technique that overcomes the limitations of traditional keyword-based search. Instead of relying solely on lexical analysis and matching individual query terms, vector search uses algorithms for similarity and concept search. It represents documents and queries as vectors in a high-dimensional space called an embedding. By searching on vector representations of content, a vector query can find relevant matches, even if the exact terms of the query are not present in the index. Moreover, vector search can be applied to various types of content, including images and videos and translated text, not just same-language text.

To learn how to index vector fields and perform vector search, you can refer to the [sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample07_VectorSearch.md). This sample provides detailed guidance on indexing vector fields and demonstrates how to perform vector search.

Additionally, for more comprehensive information about vector search, including its concepts and usage, you can refer to the [documentation](https://learn.microsoft.com/azure/search/vector-search-overview). The documentation provides in-depth explanations and guidance on leveraging the power of vector search in Azure AI Search.

_The `Azure.Search.Documents` client library (v11) provides APIs for data plane operations. The
previous `Microsoft.Azure.Search` client library (v10) is now retired. It has many similar looking APIs, so please be careful to avoid confusion when
exploring online resources.  A good rule of thumb is to check for the namespace
`using Azure.Search.Documents;` when you're looking for API reference._

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following examples all use a simple [Hotel data set](https://github.com/Azure-Samples/azure-search-sample-data)
that you can [import into your own index from the Azure portal.](https://docs.microsoft.com/azure/search/search-get-started-portal#step-1---start-the-import-data-wizard-and-create-a-data-source)
These are just a few of the basics - please [check out our Samples][samples] for
much more.

* [Querying](#querying)
  * [Use C# types for search results](#use-c-types-for-search-results)
  * [Use `SearchDocument` like a dictionary for search results](#use-searchdocument-like-a-dictionary-for-search-results)
  * [SearchOptions](#searchoptions)
* [Creating an index](#creating-an-index)
* [Adding documents to your index](#adding-documents-to-your-index)
* [Retrieving a specific document from your index](#retrieving-a-specific-document-from-your-index)
* [Async APIs](#async-apis)

### Advanced authentication

- [Create a client that can authenticate in a national cloud](#authenticate-in-a-national-cloud)

### Querying

Let's start by importing our namespaces.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Namespace
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Core.GeoJson;
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

#### Use C# types for search results

We can decorate our own C# types with [attributes from `System.Text.Json`](https://docs.microsoft.com/dotnet/standard/serialization/system-text-json-how-to):

```C# Snippet:Azure_Search_Tests_Samples_Readme_StaticType
public class Hotel
{
    [JsonPropertyName("HotelId")]
    [SimpleField(IsKey = true, IsFilterable = true, IsSortable = true)]
    public string Id { get; set; }

    [JsonPropertyName("HotelName")]
    [SearchableField(IsFilterable = true, IsSortable = true)]
    public string Name { get; set; }

    [SimpleField(IsFilterable = true, IsSortable = true)]
    public GeoPoint GeoLocation { get; set; }

    // Complex fields are included automatically in an index if not ignored.
    public HotelAddress Address { get; set; }
}

public class HotelAddress
{
    public string StreetAddress { get; set; }

    [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
    public string City { get; set; }

    [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
    public string StateProvince { get; set; }

    [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
    public string Country { get; set; }

    [SimpleField(IsFilterable = true, IsSortable = true, IsFacetable = true)]
    public string PostalCode { get; set; }
}
```

Then we use them as the type parameter when querying to return strongly-typed search results:

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

#### Use `SearchDocument` like a dictionary for search results

If you don't have your own type for search results, `SearchDocument` can be
used instead.  Here we perform the search, enumerate over the results, and
extract data using `SearchDocument`'s dictionary indexer.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Dict
SearchResults<SearchDocument> response = client.Search<SearchDocument>("luxury");
foreach (SearchResult<SearchDocument> result in response.GetResults())
{
    SearchDocument doc = result.Document;
    string id = (string)doc["HotelId"];
    string name = (string)doc["HotelName"];
    Console.WriteLine($"{id}: {name}");
}
```

#### SearchOptions

The `SearchOptions` provide powerful control over the behavior of our queries.
Let's search for the top 5 luxury hotels with a good rating.

```C# Snippet:Azure_Search_Tests_Samples_Readme_Options
int stars = 4;
SearchOptions options = new SearchOptions
{
    // Filter to only Rating greater than or equal our preference
    Filter = SearchFilter.Create($"Rating ge {stars}"),
    Size = 5, // Take only 5 results
    OrderBy = { "Rating desc" } // Sort by Rating from high to low
};
SearchResults<Hotel> response = client.Search<Hotel>("luxury", options);
// ...
```

### Creating an index

You can use the `SearchIndexClient` to create a search index. Fields can be
defined from a model class using `FieldBuilder`. Indexes can also define
suggesters, lexical analyzers, and more.

Using the [`Hotel` sample](#use-c-types-for-search-results) above,
which defines both simple and complex fields:

```C# Snippet:Azure_Search_Tests_Samples_Readme_CreateIndex
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
string key = Environment.GetEnvironmentVariable("SEARCH_API_KEY");

// Create a service client
AzureKeyCredential credential = new AzureKeyCredential(key);
SearchIndexClient client = new SearchIndexClient(endpoint, credential);

// Create the index using FieldBuilder.
SearchIndex index = new SearchIndex("hotels")
{
    Fields = new FieldBuilder().Build(typeof(Hotel)),
    Suggesters =
    {
        // Suggest query terms from the HotelName field.
        new SearchSuggester("sg", "HotelName")
    }
};

client.CreateIndex(index);
```

In scenarios when the model is not known or cannot be modified, you can
also create fields explicitly using convenient `SimpleField`,
`SearchableField`, or `ComplexField` classes:

```C# Snippet:Azure_Search_Tests_Samples_Readme_CreateManualIndex
// Create the index using field definitions.
SearchIndex index = new SearchIndex("hotels")
{
    Fields =
    {
        new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
        new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
        new SearchableField("Description") { AnalyzerName = LexicalAnalyzerName.EnLucene },
        new SearchableField("Tags", collection: true) { IsFilterable = true, IsFacetable = true },
        new ComplexField("Address")
        {
            Fields =
            {
                new SearchableField("StreetAddress"),
                new SearchableField("City") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("StateProvince") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("Country") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                new SearchableField("PostalCode") { IsFilterable = true, IsSortable = true, IsFacetable = true }
            }
        }
    },
    Suggesters =
    {
        // Suggest query terms from the hotelName field.
        new SearchSuggester("sg", "HotelName")
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

### Retrieving a specific document from your index

In addition to querying for documents using keywords and optional filters,
you can retrieve a specific document from your index if you already know the
key. You could get the key from a query, for example, and want to show more
information about it or navigate your customer to that document.

```C# Snippet:Azure_Search_Tests_Samples_Readme_GetDocument
Hotel doc = client.GetDocument<Hotel>("1");
Console.WriteLine($"{doc.Id}: {doc.Name}");
```

### Async APIs

All of the examples so far have been using synchronous APIs, but we provide full
support for async APIs as well.  You'll generally just add an `Async` suffix to
the name of the method and `await` it.

```C# Snippet:Azure_Search_Tests_Samples_Readme_StaticQueryAsync
SearchResults<Hotel> searchResponse = await client.SearchAsync<Hotel>("luxury");
await foreach (SearchResult<Hotel> result in searchResponse.GetResultsAsync())
{
    Hotel doc = result.Document;
    Console.WriteLine($"{doc.Id}: {doc.Name}");
}
```

### Authenticate in a National Cloud

To authenticate in a [National Cloud](https://docs.microsoft.com/azure/active-directory/develop/authentication-national-cloud), you will need to make the following additions to your client configuration:

- Set the `AuthorityHost` in the credential options or via the `AZURE_AUTHORITY_HOST` environment variable
- Set the `Audience` in `SearchClientOptions`

```C#
// Create a SearchClient that will authenticate through AAD in the China national cloud
string indexName = "nycjobs";
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
SearchClient client = new SearchClient(endpoint, indexName,
    new DefaultAzureCredential(
        new DefaultAzureCredentialOptions()
        {
            AuthorityHost = AzureAuthorityHosts.AzureChina
        }),
    new SearchClientOptions()
    {
        Audience = SearchAudience.AzureChina
    });
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

You can also easily [enable console logging](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md#logging) if you want to dig
deeper into the requests you're making against the service.

See our [troubleshooting guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/TROUBLESHOOTING.md) for details on how to diagnose various failure scenarios.

## Next steps

* Go further with Azure.Search.Documents and our [samples][samples]
* Read more about the [Azure AI Search service](https://docs.microsoft.com/azure/search/search-what-is-azure-search)

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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/search/Azure.Search.Documents/src
[package]: https://www.nuget.org/packages/Azure.Search.Documents/
[docs]: https://docs.microsoft.com/dotnet/api/Azure.Search.Documents
[rest_docs]: https://docs.microsoft.com/rest/api/searchservice/
[product_docs]: https://docs.microsoft.com/azure/search/
[nuget]: https://www.nuget.org/
[create_search_service_docs]: https://docs.microsoft.com/azure/search/search-create-service-portal
[create_search_service_ps]: https://docs.microsoft.com/azure/search/search-manage-powershell#create-or-delete-a-service
[create_search_service_cli]: https://docs.microsoft.com/cli/azure/search/service?view=azure-cli-latest#az-search-service-create
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[status_codes]: https://docs.microsoft.com/rest/api/searchservice/http-status-codes
[samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/
[search_contrib]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/search/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
