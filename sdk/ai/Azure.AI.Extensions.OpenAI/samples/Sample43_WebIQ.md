# Sample for use of an Agent with Web IQ Preview Tool in Azure.AI.Extensions.OpenAI.

This sample demonstrates how to create and run a Prompt Agent that uses the Web IQ preview tool. The Web IQ tool enables the Agent to use less tokens for getting grounded results based on the Web search.

**Note:** This feature is in preview.

## Prerequisites

You will need the name of a Web IQ project connection configured in your Microsoft Foundry project. Please follow the [instructions](https://webiq.microsoft.ai/) to get the API key needed for connection. Set the following environment variables:

- `FOUNDRY_PROJECT_ENDPOINT` - The Azure AI Project endpoint, as found in the Overview page of your Microsoft Foundry portal.
- `FOUNDRY_MODEL_NAME` - The deployment name of the AI model.
- `WEB_IQ_PROJECT_CONNECTION_NAME` - The name of the Web IQ project connection.

## Run the sample

1. First, create the project client and read the environment variables.

```C# Snippet:Sample_CreateAgentClient_WebIQ
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var WebIQProjectConnectionName = System.Environment.GetEnvironmentVariable("WEB_IQ_PROJECT_CONNECTION_NAME");
AIProjectClientOptions options = new();
options.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new AzureCliCredential(), options: options);
```

2. Resolve the Web IQ connection name to its connection ID and create a `WebIQPreviewTool` using the project connection ID and set `RequireApproval` to `"never"` so the agent can execute queries without manual approval. Then define the agent and create a version.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_WebIQ_Sync
WebIQPreviewTool WebIQTool = new(projectConnectionId: WebIQProjectConnectionId)
{
    RequireApproval = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.NeverRequireApproval),
};
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "Use the available Web IQ tools to answer questions and perform tasks.",
    Tools = { WebIQTool },
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myWebIQAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_WebIQ_Async
string WebIQProjectConnectionId = (await projectClient.Connections.GetConnectionAsync(WebIQProjectConnectionName)).Value.Id;
WebIQPreviewTool WebIQTool = new(projectConnectionId: WebIQProjectConnectionId)
{
    RequireApproval = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.NeverRequireApproval),
};
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "Use the available Web IQ tools to answer questions and perform tasks.",
    Tools = { WebIQTool },
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myWebIQAgent",
    options: new(agentDefinition));
```

3. Create a response by sending a user message to the agent.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_WebIQ_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("Tell me weather history in London, Ohio.") },
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_WebIQ_Async
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("Tell me weather history in London, Ohio.") },
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
```

4. Print the agent output.

```C# Snippet:Sample_PrintResponse_WebIQ
Console.WriteLine(response.GetOutputText());
```

5. After the sample is completed, delete the agent version we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_WebIQ_Sync
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_WebIQ_Async
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
