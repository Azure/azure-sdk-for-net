# Knowledge Base Preview Configuration

This sample demonstrates how to configure preview features on a knowledge base, including CORS options for cross-origin access, Azure OpenAI GPT-5.4 model configuration, retrieval instructions, answer instructions, output mode, and reasoning effort.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a Knowledge Base with Preview Configuration

Create a knowledge base with CORS options, an Azure OpenAI GPT-5.4 model, retrieval and answer instructions, output mode, and reasoning effort.

```C# Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a knowledge source referencing a search index
string knowledgeSourceName = "my-hotels-source";
SearchIndexKnowledgeSource knowledgeSource = new SearchIndexKnowledgeSource(
    knowledgeSourceName,
    new SearchIndexKnowledgeSourceParameters(indexName));
await indexClient.CreateKnowledgeSourceAsync(knowledgeSource);

// Create a knowledge base with preview configuration options
string knowledgeBaseName = "my-preview-knowledge-base";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(knowledgeSourceName)
    })
{
    Description = "Knowledge base with preview configuration",

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

    // Set reasoning effort level
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
};

// Add an Azure OpenAI model using a GPT-5.4 deployment
string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");
    knowledgeBase.Models.Add(
        new KnowledgeBaseAzureOpenAIModel(
            new AzureOpenAIVectorizerParameters
            {
                ResourceUri = new Uri(openAIEndpoint),
                ApiKey = openAIKey,
                DeploymentName = "gpt-54-mini",
                ModelName = AzureOpenAIModelName.Gpt54Mini
            }));

KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Created knowledge base '{createdBase.Name}'");
Console.WriteLine($"  CORS allowed origins: {string.Join(", ", createdBase.CorsOptions?.AllowedOrigins ?? Array.Empty<string>())}");
Console.WriteLine($"  Output mode: {createdBase.OutputMode}");
Console.WriteLine($"  Retrieval instructions: {createdBase.RetrievalInstructions}");
```

## Update Preview Configuration

Get an existing knowledge base and update its preview configuration settings, such as CORS origins, output mode, and retrieval instructions.

```C# Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Update
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get the existing knowledge base
KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);

// Update preview configuration: add CORS options and change output mode
knowledgeBase.CorsOptions = new CorsOptions(new[] { "*" })
{
    MaxAgeInSeconds = 600
};
knowledgeBase.OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData;
knowledgeBase.RetrievalInstructions = "Return raw data without summarization.";

KnowledgeBase updatedBase = await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Updated knowledge base '{updatedBase.Name}'");
Console.WriteLine($"  Output mode: {updatedBase.OutputMode}");
```
