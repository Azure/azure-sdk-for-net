# Sample using `Indexes` in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `.indexes` methods.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `INDEX_NAME`: The name of the index to create.
  - `INDEX_VERSION`: The version of the index to create.
  - `AI_SEARCH_CONNECTION_NAME`: The name of the AI Search Connection to use.
  - `AI_SEARCH_INDEX_NAME`: The name of the AI Search Index to use.

## Synchronous Sample

```C# Snippet:AI_Projects_IndexesExampleSync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var indexName = Environment.GetEnvironmentVariable("INDEX_NAME") ?? "my-index";
var indexVersion = Environment.GetEnvironmentVariable("INDEX_VERSION") ?? "1.0";
var aiSearchConnectionName = Environment.GetEnvironmentVariable("AI_SEARCH_CONNECTION_NAME") ?? "my-ai-search-connection-name";
var aiSearchIndexName = Environment.GetEnvironmentVariable("AI_SEARCH_INDEX_NAME") ?? "my-ai-search-index-name";
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Indexes indexesClient = projectClient.GetIndexesClient();

RequestContent content = RequestContent.Create(new
{
    connectionName = aiSearchConnectionName,
    indexName = aiSearchIndexName,
    indexVersion = indexVersion,
    type = "AzureSearch",
    description = "Sample Index for testing",
    displayName = "Sample Index"
});

Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
var index = indexesClient.CreateOrUpdate(
    name: indexName,
    version: indexVersion,
    content: content
);
Console.WriteLine(index);

Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
var retrievedIndex = indexesClient.GetIndex(name: indexName, version: indexVersion);
Console.WriteLine(retrievedIndex);

Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
foreach (var version in indexesClient.GetVersions(name: indexName))
{
    Console.WriteLine(version);
}

Console.WriteLine($"Listing all Indices:");
foreach (var version in indexesClient.GetIndices())
{
    Console.WriteLine(version);
}

Console.WriteLine("Delete the Index version created above:");
indexesClient.Delete(name: indexName, version: indexVersion);
```
