# Sample for basic use of a versioned agent in Azure.AI.Extensions.OpenAI.

In this example we will demonstrate creation and basic use of an agent step by step.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create the versioned agent object.

Synchronous sample:
```C# Snippet:Sample_CreateAgentVersion_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentVersion_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. List all agents named "myAgent".

Synchronous sample:
```C# Snippet:Sample_ListAgentVersions_Sync
var agentVersions = projectClient.AgentAdministrationClient.GetAgentVersions(agentName: "myAgent");
foreach (ProjectsAgentVersion oneAgentVersion in agentVersions)
{
    Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListAgentVersions_Async
var agentVersions = projectClient.AgentAdministrationClient.GetAgentVersionsAsync(agentName: "myAgent");
await foreach (ProjectsAgentVersion oneAgentVersion in agentVersions)
{
    Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
}
```

4. To automatically store history, we can optionally create a conversation to use with the agent:

Synchronous sample:
```C# Snippet:Sample_CreateConversation_Sync
ProjectConversation conversation
    = projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversation();
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversation_Async
ProjectConversation conversation
    = await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().CreateProjectConversationAsync();
```

5. Ask question for an agent.

Synchronous sample:
```C# Snippet:Sample_CreateSimpleResponse_Sync
ProjectResponsesClient responseClient
    = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version), conversation.Id);

ResponseResult response = responseClient.CreateResponse("Hello, tell me a joke.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateSimpleResponse_Async
ProjectResponsesClient responseClient
    = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(new(name: agentVersion.Name, version: agentVersion.Version), conversation.Id);

ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");
```

6. Print the output; raise the error if the request was not successful.

Synchronous sample:
```C# Snippet:Sample_WriteOutput_Sync
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_WriteOutput_Async
Console.WriteLine(response.GetOutputText());
```

7. Clean up resources by deleting conversation and agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_Sync
projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversation(conversationId: conversation.Id);
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_Async
await projectClient.ProjectOpenAIClient.GetProjectConversationsClient().DeleteConversationAsync(conversationId: conversation.Id);
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
