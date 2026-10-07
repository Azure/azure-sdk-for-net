# Fabric Data Agent Knowledge Source

This sample demonstrates how to create and use a Fabric Data Agent knowledge source. This source connects a knowledge base to a Microsoft Fabric Data Agent, enabling retrieval from Fabric data pipelines and analytics. A workspace ID and data agent ID identify the Fabric resource.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a Fabric Data Agent Knowledge Source

Create a Fabric Data Agent knowledge source by providing the Fabric workspace ID and data agent ID.

```C# Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a Fabric Data Agent knowledge source.
// This connects the knowledge base to a Microsoft Fabric Data Agent,
// enabling retrieval from Fabric data pipelines and analytics.
string knowledgeSourceName = "my-fabric-data-agent-source";

// Provide the Fabric workspace ID and data agent ID
string fabricWorkspaceId = Environment.GetEnvironmentVariable("FABRIC_WORKSPACE_ID");
string fabricDataAgentId = Environment.GetEnvironmentVariable("FABRIC_DATA_AGENT_ID");

FabricDataAgentKnowledgeSource fabricDataAgentSource = new FabricDataAgentKnowledgeSource(
    knowledgeSourceName,
    new FabricDataAgentKnowledgeSourceParameters(
        workspaceId: fabricWorkspaceId,
        dataAgentId: fabricDataAgentId))
{
    Description = "Fabric Data Agent knowledge source for analytics data"
};

KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(fabricDataAgentSource);
Console.WriteLine($"Created Fabric Data Agent knowledge source '{createdSource.Name}'");
```

## Get and List Fabric Data Agent Knowledge Sources

Retrieve the Fabric Data Agent knowledge source and inspect its workspace and agent identifiers.

```C# Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_GetAndList
// Get the Fabric Data Agent knowledge source back
KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

if (retrievedSource is FabricDataAgentKnowledgeSource retrievedAgent)
{
    Console.WriteLine($"  Kind: Fabric Data Agent");
    Console.WriteLine($"  Workspace ID: {retrievedAgent.FabricDataAgentParameters.WorkspaceId}");
    Console.WriteLine($"  Data Agent ID: {retrievedAgent.FabricDataAgentParameters.DataAgentId}");
}

// List all knowledge sources
await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
{
    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
}
```

## Attach to a Knowledge Base

Create a knowledge base that uses the Fabric Data Agent source with a GPT-5.4 model and extractive data output mode.

```C# Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_AttachToKB
// Create a knowledge base that uses the Fabric Data Agent source
string knowledgeBaseName = "my-fabric-agent-kb";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(knowledgeSourceName)
    })
{
    Description = "Knowledge base with Fabric Data Agent",
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
};

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
Console.WriteLine($"Created knowledge base '{createdBase.Name}' with Fabric Data Agent source");
```

## Retrieve from the Knowledge Base

Retrieve content from the knowledge base. Fabric Data Agent references include workspace and agent identifiers. Use `FabricDataAgentKnowledgeSourceParams` to enable references.

```C# Snippet:Azure_Search_Tests_Samples_Sample21_FabricDataAgentKS_Retrieve
// Retrieve from the knowledge base — the Fabric Data Agent handles data queries
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the latest sales trends?"));

// Add per-source runtime parameters with references enabled
request.KnowledgeSourceParams.Add(
    new FabricDataAgentKnowledgeSourceParams(knowledgeSourceName)
    {
        IncludeReferences = true,
        IncludeReferenceSourceData = true
    });

// Fabric sources require a query source authorization token.
// Obtain an access token scoped to the search service:
// az account get-access-token --resource https://search.azure.com
string querySourceAuthorization = Environment.GetEnvironmentVariable("SEARCH_QUERY_SOURCE_AUTH");

Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(
    request, querySourceAuthorization);
KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

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

// Fabric Data Agent references include workspace and agent identifiers
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}");

    if (reference is KnowledgeBaseFabricDataAgentReference dataAgentRef)
    {
        Console.WriteLine($"  Workspace ID: {dataAgentRef.WorkspaceId}");
        Console.WriteLine($"  Data Agent ID: {dataAgentRef.DataAgentId}");
    }
}
```
