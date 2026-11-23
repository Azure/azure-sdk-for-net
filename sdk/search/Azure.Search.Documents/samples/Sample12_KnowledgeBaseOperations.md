# Knowledge Base Operations

This sample demonstrates CRUD (Create, Read, Update, Delete) operations for knowledge bases in Azure AI Search. A knowledge base orchestrates retrieval from one or more knowledge sources.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

Authenticate to Search using Microsoft Entra ID. The identity running the sample
needs the Search Service Contributor and Search Index Data Contributor roles.
For the Azure OpenAI model, enable the Search service's system-assigned managed
identity and grant it Cognitive Services OpenAI User on the OpenAI resource.
No Search or OpenAI API keys are required.

## Required Namespaces

```C# Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Namespaces
using Azure.Identity;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Newtonsoft.Json;
```

## Create a Knowledge Base

Create a knowledge base that references one or more knowledge sources and optionally includes an Azure OpenAI model for query planning.

```C# Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
DefaultAzureCredential credential = new DefaultAzureCredential();
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// First, create a knowledge source referencing a search index
string knowledgeSourceName = "my-hotels-source";
SearchIndexKnowledgeSource knowledgeSource = new SearchIndexKnowledgeSource(
    knowledgeSourceName,
    new SearchIndexKnowledgeSourceParameters(indexName));
await indexClient.CreateKnowledgeSourceAsync(knowledgeSource);

// Create a knowledge base that references the knowledge source
string knowledgeBaseName = "my-hotels-knowledge-base";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(knowledgeSourceName)
    })
{
    Description = "Knowledge base for hotel information"
};

// Add an Azure OpenAI model for query planning
string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
    knowledgeBase.Models.Add(
        new KnowledgeBaseAzureOpenAIModel(
            new AzureOpenAIVectorizerParameters
            {
                ResourceUri = new Uri(openAIEndpoint),
                DeploymentName = "gpt-5.4-mini",
                ModelName = AzureOpenAIModelName.Gpt54Mini
            }));

KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
```

## Get a Knowledge Base

Retrieve a specific knowledge base by name and inspect its properties.

```C# Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Get
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
DefaultAzureCredential credential = new DefaultAzureCredential();
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get a specific knowledge base by name
KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
Console.WriteLine($"Knowledge base '{knowledgeBase.Name}'");
Console.WriteLine($"  Description: {knowledgeBase.Description}");
Console.WriteLine($"  Knowledge sources: {knowledgeBase.KnowledgeSources.Count}");
foreach (KnowledgeSourceReference sourceRef in knowledgeBase.KnowledgeSources)
{
    Console.WriteLine($"    - {sourceRef.Name}");
}
```

## List Knowledge Bases

Enumerate all knowledge bases in a search service.

```C# Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_List
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
DefaultAzureCredential credential = new DefaultAzureCredential();

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// List all knowledge bases
await foreach (KnowledgeBase kb in indexClient.GetKnowledgeBasesAsync())
{
    Console.WriteLine($"Knowledge base: {kb.Name} (sources: {kb.KnowledgeSources.Count})");
}
```

## Update a Knowledge Base

Get an existing knowledge base, modify it, and save the changes back.

```C# Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Update
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
DefaultAzureCredential credential = new DefaultAzureCredential();
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get the existing knowledge base
KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);

// Update its description and application metadata.
knowledgeBase.Description = "Updated description for hotel knowledge base";

KnowledgeBase updatedBase = await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Updated knowledge base '{updatedBase.Name}': {updatedBase.Description}");
```

## Delete a Knowledge Base

Delete a knowledge base by name.

```C# Snippet:Azure_Search_Documents_Tests_Samples_KnowledgeBaseOperations_Delete
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
DefaultAzureCredential credential = new DefaultAzureCredential();
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Delete a knowledge base by name
await indexClient.DeleteKnowledgeBaseAsync(knowledgeBaseName);
Console.WriteLine($"Deleted knowledge base '{knowledgeBaseName}'");
```
