# Knowledge Base Preview Configuration

This sample demonstrates how to configure preview features on a knowledge base, including CORS options for cross-origin access, Azure OpenAI GPT-5.4 model configuration, retrieval instructions, answer instructions, output mode, and reasoning effort.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
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

    // Use automatic reasoning when a request does not override it.
    RetrievalReasoningEffort = new KnowledgeRetrievalAutoReasoningEffort(),

    // Persist request-wide defaults on the knowledge base.
    RetrieveDefaults = new KnowledgeBaseRetrieveDefaults
    {
        MaxRuntimeInSeconds = 60,
        MaxOutputDocuments = 5,
        // Stored defaults use a token limit. The request-level MaxOutputSize
        // property uses a different name and unit.
        MaxOutputSizeInTokens = 5000
    }
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
                DeploymentName = "gpt-5.4-mini",
                ModelName = AzureOpenAIModelName.Gpt54Mini
            }));

KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Created knowledge base '{createdBase.Name}'");
Console.WriteLine($"  CORS allowed origins: {string.Join(", ", createdBase.CorsOptions?.AllowedOrigins ?? Array.Empty<string>())}");
Console.WriteLine($"  Output mode: {createdBase.OutputMode}");
Console.WriteLine($"  Reasoning effort: {createdBase.RetrievalReasoningEffort.GetType().Name}");
Console.WriteLine($"  Default maximum documents: {createdBase.RetrieveDefaults?.MaxOutputDocuments}");
Console.WriteLine($"  Default maximum output tokens: {createdBase.RetrieveDefaults?.MaxOutputSizeInTokens}");
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

## Override Stored Defaults for One Request

Persisted retrieve defaults apply when a request omits those settings. Request-level values take precedence for that call and do not mutate the knowledge base. Stored output defaults use `MaxOutputSizeInTokens`, while the request also exposes `MaxOutputSize` for its request-specific limit.

```C# Snippet:Azure_Search_Tests_Samples_Sample13_KBPreviewConfig_RequestOverride
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

// Persist defaults on the knowledge base. These apply only when a
// retrieve request omits the corresponding settings.
KnowledgeBase knowledgeBase = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
knowledgeBase.RetrievalReasoningEffort = new KnowledgeRetrievalAutoReasoningEffort();
knowledgeBase.RetrieveDefaults = new KnowledgeBaseRetrieveDefaults
{
    MaxOutputDocuments = 5,
    MaxOutputSizeInTokens = 5000
};
await indexClient.CreateOrUpdateKnowledgeBaseAsync(knowledgeBase);

// Request-level values take precedence without changing the stored defaults.
KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true,
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort(),
    MaxOutputDocuments = 2,
    // MaxOutputSize is a request property; the persisted default uses
    // RetrieveDefaults.MaxOutputSizeInTokens.
    MaxOutputSize = 5000
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("Which hotels offer luxury amenities?"));

KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(request);
KnowledgeBaseAgenticReasoningActivityRecord reasoning = response.Activity
    .OfType<KnowledgeBaseAgenticReasoningActivityRecord>()
    .FirstOrDefault();

Console.WriteLine($"Effective request reasoning: {reasoning?.RetrievalReasoningEffort?.GetType().Name}");
Console.WriteLine($"References returned: {response.References.Count}");

KnowledgeBase persisted = await indexClient.GetKnowledgeBaseAsync(knowledgeBaseName);
Console.WriteLine($"Stored reasoning remains: {persisted.RetrievalReasoningEffort.GetType().Name}");
Console.WriteLine($"Stored maximum documents remains: {persisted.RetrieveDefaults.MaxOutputDocuments}");
```
