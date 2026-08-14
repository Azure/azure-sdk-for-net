# Knowledge Base Operations

This sample demonstrates CRUD (Create, Read, Update, Delete) operations for knowledge bases in Azure AI Search. A knowledge base orchestrates retrieval from one or more knowledge sources.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
```

## Create a Knowledge Base

Create a knowledge base that references one or more knowledge sources and optionally includes an Azure OpenAI model for query planning.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
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
string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");
    knowledgeBase.Models.Add(
        new KnowledgeBaseAzureOpenAIModel(
            new AzureOpenAIVectorizerParameters
            {
                ResourceUri = new Uri(openAIEndpoint),
                ApiKey = openAIKey,
                DeploymentName = "gpt-5-mini",
                ModelName = AzureOpenAIModelName.Gpt5Mini
            }));

KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Created knowledge base '{createdBase.Name}' with {createdBase.KnowledgeSources.Count} source(s)");
```

## Get a Knowledge Base

Retrieve a specific knowledge base by name and inspect its properties.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Get
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
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

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_List
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// List all knowledge bases
await foreach (KnowledgeBase kb in indexClient.GetKnowledgeBasesAsync())
{
    Console.WriteLine($"Knowledge base: {kb.Name} (sources: {kb.KnowledgeSources.Count})");
}
```

## Update a Knowledge Base

Get an existing knowledge base, modify it, and save the changes back.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Update
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get the existing knowledge base
KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);

// Update its description
knowledgeBase.Description = "Updated description for hotel knowledge base";

KnowledgeBase updatedBase = await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Updated knowledge base '{updatedBase.Name}': {updatedBase.Description}");
```

## Delete a Knowledge Base

Delete a knowledge base by name.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample12_KnowledgeBase_Delete
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Delete a knowledge base by name
await indexClient.DeleteKnowledgeBaseAsync(knowledgeBaseName);
Console.WriteLine($"Deleted knowledge base '{knowledgeBaseName}'");
```
