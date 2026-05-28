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

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
Console.WriteLine("Create a local Index with configurable data, referencing an existing AI Search resource");
AzureAISearchIndex searchIndex = new AzureAISearchIndex(aiSearchConnectionName, aiSearchIndexName)
{
    Description = "Sample Index for testing"
};

Console.WriteLine($"Create the Project Index named `{indexName}` using the previously created local object:");
searchIndex = (AzureAISearchIndex)projectClient.Indexes.CreateOrUpdate(
    name: indexName,
    version: indexVersion,
    index: searchIndex
);
Console.WriteLine(searchIndex);

Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
AIProjectIndex retrievedIndex = projectClient.Indexes.GetIndex(name: indexName, version: indexVersion);
Console.WriteLine(retrievedIndex);

Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
foreach (AIProjectIndex version in projectClient.Indexes.GetIndexVersions(name: indexName))
{
    Console.WriteLine(version);
}

Console.WriteLine($"Listing all Indices:");
foreach (AIProjectIndex version in projectClient.Indexes.GetIndexes())
{
    Console.WriteLine(version);
}

Console.WriteLine("Delete the Index version created above:");
projectClient.Indexes.Delete(name: indexName, version: indexVersion);
```

## Asynchronous Sample

```C# Snippet:AI_Projects_IndexesExampleAsync
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var indexName = Environment.GetEnvironmentVariable("INDEX_NAME") ?? "my-index";
var indexVersion = Environment.GetEnvironmentVariable("INDEX_VERSION") ?? "1.0";
var aiSearchConnectionName = Environment.GetEnvironmentVariable("AI_SEARCH_CONNECTION_NAME") ?? "my-ai-search-connection-name";
var aiSearchIndexName = Environment.GetEnvironmentVariable("AI_SEARCH_INDEX_NAME") ?? "my-ai-search-index-name";

AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
Console.WriteLine("Create a local Index with configurable data, referencing an existing AI Search resource");
AzureAISearchIndex searchIndex = new AzureAISearchIndex(aiSearchConnectionName, aiSearchIndexName)
{
    Description = "Sample Index for testing"
};

Console.WriteLine($"Create the Project Index named `{indexName}` using the previously created local object:");
searchIndex = (AzureAISearchIndex)await projectClient.Indexes.CreateOrUpdateAsync(
    name: indexName,
    version: indexVersion,
    index: searchIndex
);
Console.WriteLine(searchIndex);

Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
AIProjectIndex retrievedIndex = await projectClient.Indexes.GetIndexAsync(name: indexName, version: indexVersion);
Console.WriteLine(retrievedIndex);

Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
await foreach (AIProjectIndex version in projectClient.Indexes.GetIndexVersionsAsync(name: indexName))
{
    Console.WriteLine(version);
}

Console.WriteLine($"Listing all Indices:");
await foreach (AIProjectIndex version in projectClient.Indexes.GetIndexesAsync())
{
    Console.WriteLine(version);
}

Console.WriteLine("Delete the Index version created above:");
await projectClient.Indexes.DeleteAsync(name: indexName, version: indexVersion);
```
