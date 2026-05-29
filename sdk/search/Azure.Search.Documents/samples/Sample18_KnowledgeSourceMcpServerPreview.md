# MCP Server Knowledge Source

This sample demonstrates how to create and use an MCP (Model Context Protocol) Server knowledge source. MCP Server sources connect a knowledge base to an external MCP server that exposes tools for data retrieval. You can configure tool definitions with output parsing.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create an MCP Server Knowledge Source

Create an MCP Server knowledge source with a tool definition and auto output parsing.

```C# Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Create
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create an MCP Server knowledge source.
// This connects the knowledge base to an external MCP (Model Context Protocol) server
// that exposes tools for data retrieval.
string knowledgeSourceName = "my-mcp-server-source";

// Define the tools available on the MCP server
McpServerTool searchTool = new McpServerTool
{
    Name = "microsoft_docs_search",
    OutputParsing = new McpServerAutoOutputParsing()
};

// Configure the MCP server parameters
McpServerKnowledgeSourceParameters mcpParams = new McpServerKnowledgeSourceParameters(
    serverURL: "https://learn.microsoft.com/api/mcp",
    tools: new[] { searchTool });

McpServerKnowledgeSource mcpSource = new McpServerKnowledgeSource(
    knowledgeSourceName, mcpParams)
{
    Description = "MCP server knowledge source for Microsoft documentation"
};

KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(mcpSource);
Console.WriteLine($"Created MCP server knowledge source '{createdSource.Name}'");
```

## Get and List MCP Server Knowledge Sources

Retrieve the MCP Server knowledge source and inspect its server URL and tool configuration.

```C# Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_GetAndList
// Get the MCP server knowledge source back
KnowledgeSource retrievedSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
Console.WriteLine($"Retrieved: '{retrievedSource.Name}'");

if (retrievedSource is McpServerKnowledgeSource retrievedMcp)
{
    Console.WriteLine($"  Server URL: {retrievedMcp.McpServerParameters.ServerURL}");
    Console.WriteLine($"  Tools: {retrievedMcp.McpServerParameters.Tools.Count}");
    foreach (McpServerTool tool in retrievedMcp.McpServerParameters.Tools)
    {
        Console.WriteLine($"    - {tool.Name} (inclusion: {tool.InclusionMode})");
    }
}

// List all knowledge sources
await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
{
    Console.WriteLine($"  Source: {source.Name} ({source.GetType().Name})");
}
```

## Attach to a Knowledge Base

Create a knowledge base that uses the MCP Server source with answer synthesis output mode and a GPT-5.4 model.

```C# Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_AttachToKB
// Create a knowledge base that uses the MCP server source
string knowledgeBaseName = "my-mcp-kb";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(knowledgeSourceName)
    })
{
    Description = "Knowledge base backed by MCP server tools",
    OutputMode = KnowledgeRetrievalOutputMode.AnswerSynthesis,
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
Console.WriteLine($"Created knowledge base '{createdBase.Name}' with MCP server source");
```

## Retrieve from the Knowledge Base

Retrieve content from the knowledge base. The MCP server tools are invoked as needed during retrieval. Use `MaxRuntimeInSeconds` to allow sufficient time for external tool calls.

```C# Snippet:Azure_Search_Tests_Samples_Sample18_McpServerKS_Retrieve
// Retrieve from the knowledge base — the MCP server tools are invoked as needed
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true,
    MaxRuntimeInSeconds = 120
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What products are in stock?"));

Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
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

// Activity records show which MCP tools were invoked
foreach (KnowledgeBaseActivityRecord activity in retrievalResponse.Activity)
{
    Console.WriteLine($"Activity ID: {activity.Id}, Elapsed: {activity.ElapsedMs}ms");
}

foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}");
}
```
