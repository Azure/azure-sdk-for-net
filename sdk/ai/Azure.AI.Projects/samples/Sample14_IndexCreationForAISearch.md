# Creating and Using an AzureAI Search Index

This sample demonstrates how to create an Index for use as an Agent's AI Search tool

## Prerequisites

- Install the Azure.AI.Projects and Azure.AI.Agents.Persistent package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.

## Execution

Start by initializing the necessary local variables based on preset environment variables, and initialize the `AIProjectClient`.

```C# Snippet:AI_Projects_AzureAISearchInitializeProjectClient
var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var indexName = Environment.GetEnvironmentVariable("INDEX_NAME");
var indexVersion = Environment.GetEnvironmentVariable("INDEX_VERSION");
var aiSearchIndexName = Environment.GetEnvironmentVariable("AI_SEARCH_INDEX_NAME");

AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
```

Using the default Connection to the Azure AI Search resource connected to the Project, create a pointer to an existing AI Search Index (`aiSearchIndexName`), then link that pointer to the Project with a provided name (`indexName`) and version (`indexVersion`).

```C# Snippet:AI_Projects_AzureAISearchIndexCreation
AIProjectConnection aiSearchConnection = projectClient.Connections.GetDefaultConnection(ConnectionType.AzureAISearch);

Console.WriteLine("Create a local AzureAISearchIndex with configurable data, referencing an existing AI Search resource");
AzureAISearchIndex searchIndex = new AzureAISearchIndex(aiSearchConnection.Name, aiSearchIndexName)
{
    Description = "Sample Index for testing"
};

Console.WriteLine($"Create the Project Index named `{indexName}` using the previously created local object");
searchIndex = (AzureAISearchIndex)projectClient.Indexes.CreateOrUpdate(
    name: indexName,
    version: indexVersion,
    index: searchIndex
);
```

Finally, initialize the Agent client, create the Search Tool using the Project Connection and Index, and create the agent with the Tool.

```C# Snippet:AI_Projects_AzureAISearchToolUsingConnections
var agentsClient = projectClient.GetPersistentAgentsClient();

Console.WriteLine("Initialize agent AI search tool using the default connection and created index");
var aiSearchToolResource = new AzureAISearchToolResource(
    indexConnectionId: aiSearchConnection.Id,
    indexName: indexName,
    queryType: AzureAISearchQueryType.Simple,
    topK: 3,
    filter: ""
);
ToolResources toolResource = new()
{
    AzureAISearch = aiSearchToolResource
};

Console.WriteLine("Create agent with AI search tool");
var agent = agentsClient.Administration.CreateAgent(
    model: modelDeploymentName,
    name: "my-agent",
    instructions: "You are a helpful agent",
    tools: [new AzureAISearchToolDefinition()],
    toolResources: toolResource
);
```
