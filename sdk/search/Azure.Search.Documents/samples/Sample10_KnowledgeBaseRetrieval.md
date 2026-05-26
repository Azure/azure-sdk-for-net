# Knowledge Base Retrieval (Agentic Retrieval)

Azure AI Search supports agentic retrieval through knowledge bases. A knowledge base orchestrates retrieval from one or more knowledge sources (such as a search index) and returns relevant content with references.

This sample demonstrates how to:
1. Create a search index and upload documents
2. Create a knowledge source referencing the index
3. Create a knowledge base for orchestrating retrieval
4. Retrieve relevant content from the knowledge base

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
```

## Create a Search Index

First, create a search index with semantic search configured. The semantic configuration helps the knowledge base understand field relevance.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateIndex
// Get the service endpoint and API key from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

// Create a SearchIndexClient
SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Define the index with semantic search
string indexName = "hotels-knowledge-base";
SearchIndex searchIndex = new SearchIndex(indexName)
{
    Fields =
    {
        new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
        new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
        new SearchableField("Description") { IsFilterable = true },
        new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
    },
    SemanticSearch = new Indexes.Models.SemanticSearch
    {
        Configurations =
        {
            new SemanticConfiguration("my-semantic-config", new SemanticPrioritizedFields
            {
                TitleField = new SemanticField("HotelName"),
                ContentFields =
                {
                    new SemanticField("Description")
                },
                KeywordsFields =
                {
                    new SemanticField("Category")
                }
            })
        }
    }
};

await indexClient.CreateIndexAsync(searchIndex);
```

## Upload Documents

Populate the index with documents that will serve as the knowledge base's data source.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_UploadDocuments
// Upload documents to the index
SearchClient searchClient = new SearchClient(endpoint, indexName, credential);

var hotels = new[]
{
    new { HotelId = "1", HotelName = "Fancy Stay", Description = "Best hotel in town if you like luxury hotels.", Category = "Luxury" },
    new { HotelId = "2", HotelName = "Roach Motel", Description = "Cheapest hotel in town.", Category = "Budget" },
    new { HotelId = "3", HotelName = "EconoStay", Description = "Very popular hotel in town.", Category = "Budget" },
    new { HotelId = "4", HotelName = "Modern Stay", Description = "Modern architecture, very polite staff and very clean.", Category = "Luxury" },
};

await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotels));
```

## Create a Knowledge Source

A knowledge source defines where the knowledge base retrieves data from. Here we create one that references our search index.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateKnowledgeSource
// Create a knowledge source that references the search index
string knowledgeSourceName = "hotels-knowledge-source";
SearchIndexKnowledgeSource knowledgeSource = new SearchIndexKnowledgeSource(
    knowledgeSourceName,
    new SearchIndexKnowledgeSourceParameters(indexName)
    {
        // Specify which fields should be included in references
        SourceDataFields =
        {
            new SearchIndexFieldReference("HotelId"),
            new SearchIndexFieldReference("HotelName"),
        }
    })
{
    Description = "Knowledge source for hotel data"
};

await indexClient.CreateKnowledgeSourceAsync(knowledgeSource);
```

## Create a Knowledge Base

A knowledge base orchestrates retrieval from one or more knowledge sources. You can optionally configure an Azure OpenAI model for query planning.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateKnowledgeBase
// Create a knowledge base that orchestrates retrieval from the knowledge source
string knowledgeBaseName = "hotels-knowledge-base";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(knowledgeSourceName)
    })
{
    Description = "Knowledge base for hotel information retrieval"
};

// Optionally add an Azure OpenAI model for query planning
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

await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
```

## Retrieve from the Knowledge Base

Use the `KnowledgeBaseRetrievalClient` to send a user message and retrieve relevant content.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_RetrieveFromKnowledgeBase
// Create a KnowledgeBaseRetrievalClient to query the knowledge base
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

// Build a retrieval request with a semantic intent
KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest();
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the best luxury hotels?"));

// Retrieve relevant content from the knowledge base
Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

// Display the response messages
foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
{
    foreach (KnowledgeBaseMessageContent content in message.Content)
    {
        if (content is KnowledgeBaseMessageTextContent textContent)
        {
            Console.WriteLine($"Response: {textContent.Text}");
        }
    }
}

// Display the references used in the response
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}");
}
```

## Quick Retrieval

If you already have a knowledge base set up, you can retrieve from it directly:

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_Retrieve
// Get the service endpoint and API key from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

// Create a KnowledgeBaseRetrievalClient to query the knowledge base
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

// Build a retrieval request with a semantic intent
KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest();
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the best luxury hotels?"));

// Retrieve relevant content from the knowledge base
Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

// Display the response messages
foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
{
    foreach (KnowledgeBaseMessageContent content in message.Content)
    {
        if (content is KnowledgeBaseMessageTextContent textContent)
        {
            Console.WriteLine($"Response: {textContent.Text}");
        }
    }
}

// Display the references used in the response
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}");
}
```
