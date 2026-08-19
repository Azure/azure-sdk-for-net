# Sample for use of an Agent with Fabric IQ Preview Tool in Azure.AI.Extensions.OpenAI.

This sample demonstrates how to create and run a Prompt Agent that uses the Fabric IQ preview tool. The Fabric IQ tool enables the agent to query data sources connected through Microsoft Fabric IQ.

**Note:** This feature is in preview.

## Prerequisites

You will need the name of a Fabric IQ project connection configured in your Microsoft Foundry project. Set the following environment variables:

- `FOUNDRY_PROJECT_ENDPOINT` - The Azure AI Project endpoint, as found in the Overview page of your Microsoft Foundry portal.
- `FOUNDRY_MODEL_NAME` - The deployment name of the AI model.
- `FABRIC_IQ_PROJECT_CONNECTION_NAME` - The name of the Fabric IQ project connection.

## Run the sample

1. First, create the project client and read the environment variables. Resolve the Fabric IQ connection name to its connection ID.

```C# Snippet:Sample_CreateAgentClient_FabricIQ
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var fabricIQProjectConnectionName = System.Environment.GetEnvironmentVariable("FABRIC_IQ_PROJECT_CONNECTION_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
string fabricIQProjectConnectionId = (await projectClient.Connections.GetConnectionAsync(fabricIQProjectConnectionName)).Value.Id;
```

2. Create a `FabricIQPreviewTool` using the project connection ID and set `RequireApproval` to `"never"` so the agent can execute queries without manual approval. Then define the agent and create a version.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_FabricIQ_Sync
FabricIQPreviewTool fabricIQTool = new(projectConnectionId: fabricIQProjectConnectionId)
{
    RequireApproval = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.NeverRequireApproval),
};
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "Use the available Fabric IQ tools to answer questions and perform tasks.",
    Tools = { fabricIQTool },
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myFabricIQAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_FabricIQ_Async
FabricIQPreviewTool fabricIQTool = new(projectConnectionId: fabricIQProjectConnectionId)
{
    RequireApproval = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.NeverRequireApproval),
};
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "Use the available Fabric IQ tools to answer questions and perform tasks.",
    Tools = { fabricIQTool },
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myFabricIQAgent",
    options: new(agentDefinition));
```

3. Create a response by sending a user message to the agent.

Synchronous sample:
```C# Snippet:Sample_CreateResponse_FabricIQ_Sync
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("Tell me weather history in London, Ohio.") },
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateResponse_FabricIQ_Async
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
    InputItems = { ResponseItem.CreateUserMessageItem("Tell me weather history in London, Ohio.") },
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
```

4. Print the agent output.

```C# Snippet:Sample_PrintResponse_FabricIQ
Console.WriteLine(response.GetOutputText());
```

5. After the sample is completed, delete the agent version we have created.

Synchronous sample:
```C# Snippet:Sample_Cleanup_FabricIQ_Sync
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_FabricIQ_Async
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
