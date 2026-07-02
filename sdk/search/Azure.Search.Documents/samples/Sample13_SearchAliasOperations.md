# Search Alias Operations

This sample demonstrates CRUD (Create, Read, Update, Delete) operations for search aliases in Azure AI Search. A **search alias** provides a stable, alternative name for an index. You can point an alias at any index, and later redirect it to a different index — allowing zero-downtime index swaps and simplified client configuration.

For more information, see the [alias documentation](https://learn.microsoft.com/azure/search/search-aliases).

## Required Namespaces

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
```

## Create an Alias

Create a new alias that maps to an existing index. The alias name can then be used in place of the index name for search and document operations.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create an alias that maps to the given index
string aliasName = "my-alias";
SearchAlias alias = new SearchAlias(aliasName, new[] { indexName });

SearchAlias createdAlias = await indexClient.CreateAliasAsync(alias);
Console.WriteLine($"Created alias '{createdAlias.Name}' pointing to index '{createdAlias.Indexes[0]}'");
```

## Get an Alias

Retrieve a specific alias by name to inspect which index it maps to.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Get
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string aliasName = Environment.GetEnvironmentVariable("ALIAS_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get a specific alias by name
SearchAlias retrievedAlias = await indexClient.GetAliasAsync(aliasName);
Console.WriteLine($"Alias '{retrievedAlias.Name}' points to index '{retrievedAlias.Indexes[0]}'");
```

## List Aliases

Enumerate all aliases defined in the search service.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_List
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// List all aliases in the search service
await foreach (SearchAlias searchAlias in indexClient.GetAliasesAsync())
{
    Console.WriteLine($"Alias '{searchAlias.Name}' -> Index '{searchAlias.Indexes[0]}'");
}
```

## Update an Alias

Redirect an existing alias to point to a different index. This is the primary mechanism for zero-downtime index swaps: build a new index, then update the alias to point to it.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Update
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string aliasName = Environment.GetEnvironmentVariable("ALIAS_NAME");
string newIndexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Update the alias to point to a different index
SearchAlias updatedAlias = new SearchAlias(aliasName, new[] { newIndexName });
SearchAlias result = await indexClient.CreateOrUpdateAliasAsync(updatedAlias);
Console.WriteLine($"Updated alias '{result.Name}' now points to '{result.Indexes[0]}'");
```

## Delete an Alias

Delete an alias by name. The underlying index is unaffected.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_Delete
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string aliasName = Environment.GetEnvironmentVariable("ALIAS_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Delete an alias by name
await indexClient.DeleteAliasAsync(aliasName);
Console.WriteLine($"Deleted alias '{aliasName}'");
```

## Search Using an Alias

Use the alias name wherever an index name is accepted — for example, when constructing a `SearchClient`.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample13_SearchAlias_SearchUsing
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string aliasName = Environment.GetEnvironmentVariable("ALIAS_NAME");

// Use the alias name instead of the index name to search
SearchClient searchClient = new SearchClient(endpoint, aliasName, credential);

SearchResults<SearchDocument> results = await searchClient.SearchAsync<SearchDocument>("luxury");
await foreach (SearchResult<SearchDocument> result in results.GetResultsAsync())
{
    Console.WriteLine(result.Document["HotelName"]);
}
```
