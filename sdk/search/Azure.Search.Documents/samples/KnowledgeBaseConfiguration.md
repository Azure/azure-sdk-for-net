# Knowledge Base Configuration

This sample demonstrates how to configure a knowledge base with an Azure OpenAI model, retrieval and answer instructions, output mode, and reasoning effort using the `2026-10-01` API version.

Set `SEARCH_ENDPOINT`, `SEARCH_INDEX`, and `OPENAI_ENDPOINT` before running the create example. The search index must already exist, contain hotel documents, and have a default semantic configuration. Deploy `gpt-5.4-mini` in the configured Azure OpenAI resource and grant the Search service's managed identity the **Cognitive Services OpenAI User** role on that resource. The caller needs **Search Service Contributor** on the Search service.

These settings define the defaults for subsequent retrievals. `AnswerSynthesis` uses the configured model to generate an answer; `ExtractiveData` returns retrieved content without answer synthesis. Retrieval instructions guide model-based query planning, while answer instructions guide synthesis. Requests with explicit intents bypass model query planning.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Namespaces
using Azure.Identity;
using Azure.Core;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a Knowledge Base

Create a knowledge base that synthesizes concise hotel answers with low reasoning effort and custom retrieval and answer instructions.

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a knowledge source referencing a search index
string knowledgeSourceName = "my-hotels-source";
SearchIndexKnowledgeSource knowledgeSource = new SearchIndexKnowledgeSource(
    knowledgeSourceName,
    new SearchIndexKnowledgeSourceParameters(indexName));
await indexClient.CreateKnowledgeSourceAsync(knowledgeSource);

// Create a knowledge base with retrieval configuration options
string knowledgeBaseName = "my-knowledge-base";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(knowledgeSourceName)
    })
{
    Description = "Knowledge base with retrieval configuration",

    // Configure CORS options for cross-origin access
    CorsOptions = new CorsOptions(new[] { "https://myapp.example.com", "https://dashboard.example.com" })
    {
        MaxAgeInSeconds = 300
    },

    // Set KB-level retrieval instructions and answer instructions
    RetrievalInstructions = "Focus on luxury hotel amenities and pricing information.",
    AnswerInstructions = "Provide concise answers with specific hotel details and ratings.",

    // Set default output mode for all retrievals from this KB
    OutputMode = KnowledgeRetrievalOutputMode.AnswerSynthesis,

    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
};

// The deployment must exist and allow the Search service's managed identity.
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
Console.WriteLine($"Created knowledge base '{createdBase.Name}'");
Console.WriteLine($"  CORS allowed origins: {string.Join(", ", createdBase.CorsOptions?.AllowedOrigins ?? Array.Empty<string>())}");
Console.WriteLine($"  Output mode: {createdBase.OutputMode}");
Console.WriteLine($"  Reasoning effort: {createdBase.RetrievalReasoningEffort.GetType().Name}");
Console.WriteLine($"  Retrieval instructions: {createdBase.RetrievalInstructions}");
```

## Update a Knowledge Base

Set `KNOWLEDGE_BASE_NAME` to an existing knowledge base. Change its default output mode to extracted content and update its query-planning instructions without replacing its knowledge sources or model configuration.

```C# Snippet:Azure_Search_Tests_Samples_KnowledgeBaseConfiguration_Update
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get the existing knowledge base
KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);

knowledgeBase.CorsOptions = new CorsOptions(new[] { "https://myapp.example.com" })
{
    MaxAgeInSeconds = 600
};
// Update the default retrieval mode and query-planning instructions.
knowledgeBase.OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData;
knowledgeBase.RetrievalInstructions = "Prioritize hotels with lower nightly rates.";

KnowledgeBase updatedBase = await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Updated knowledge base '{updatedBase.Name}'");
Console.WriteLine($"  Output mode: {updatedBase.OutputMode}");
```
