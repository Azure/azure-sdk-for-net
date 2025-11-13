# Sample for basic use of a versioned agent in Azure.AI.Projects.OpenAI.

In this example we will demonstrate creation and basic use of an agent step by step.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create the versioned agent object.

Synchronous sample:
```C# Snippet:Sample_CreateAgentVersion_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentVersion_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

3. List all agents named "myAgent".

Synchronous sample:
```C# Snippet:Sample_ListAgentVersions_Sync
var agentVersions = projectClient.Agents.GetAgentVersions(agentName: "myAgent");
foreach (AgentVersion oneAgentVersion in agentVersions)
{
    Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListAgentVersions_Async
var agentVersions = projectClient.Agents.GetAgentVersionsAsync(agentName: "myAgent");
await foreach (AgentVersion oneAgentVersion in agentVersions)
{
    Console.WriteLine($"Agent: {oneAgentVersion.Id}, Name: {oneAgentVersion.Name}, Version: {oneAgentVersion.Version}");
}
```

4. To communicate with the agent, we will need to create a conversation.

Synchronous sample:
```C# Snippet:Sample_CreateCoversation_Sync
AgentConversation conversation = projectClient.OpenAI.Conversations.CreateAgentConversation();
ModelReaderWriterOptions options = new("W");
BinaryData conversationBin = ((IPersistableModel<AgentConversation>)conversation).Write(options);
```

Asynchronous sample:
```C# Snippet:Sample_CreateCoversation_Async
AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();
ModelReaderWriterOptions options = new("W");
BinaryData conversationBin = ((IPersistableModel<AgentConversation>)conversation).Write(options);
```

5. Ask question for an agent.

Synchronous sample:
```C# Snippet:Sample_GetResponse_Sync
OpenAIResponseClient responsesClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);

OpenAIResponseClient responseClient = projectClient.OpenAI.GetProjectOpenAIResponseClientForAgent("myAgent", conversation.Id);

OpenAIResponse response = responsesClient.CreateResponse("Hello, tell me a joke.");
```

Asynchronous sample:
```C# Snippet:Sample_GetResponse_Async
OpenAIResponseClient responseClient = projectClient.OpenAI.GetOpenAIResponseClient(modelDeploymentName);

ResponseCreationOptions responseOptions = new()
{
    Agent = agentVersion,
    AgentConversationId = conversation,
};

OpenAIResponse response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");
```

6. Wait for the agent to respond and print out the output; raise the error if the request was not successful.

Synchronous sample:
```C# Snippet:Sample_WriteOutput_Sync
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    response = responsesClient.GetResponse(responseId: response.Id);
}

Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_WriteOutput_Async
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed){
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    response = await responseClient.GetResponseAsync(responseId:  response.Id);
}

Console.WriteLine(response.GetOutputText());
```

7. Clean up resources by deleting conversation and agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_Sync
projectClient.OpenAI.Conversations.DeleteConversation(conversationId: conversation.Id);
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_Async
await projectClient.OpenAI.Conversations.DeleteConversationAsync(conversationId: conversation.Id);
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
```
