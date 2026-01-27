# Sample of using `MemorySearchTool` with Agent in Azure.AI.Projects.OpenAI.

In this example we will demonstrate how to use `MemorySearchTool`. We will create `MemoryStoreObject` and store the conversaton there. Then we will create another Agent, capable to read it.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_MemoryTool
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var embeddingDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
```

2. Use the client to create the versioned agent object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_MemoryTool_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_MemoryTool_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

4. Create get the `ResponseResult` object.

Synchronous sample:
```C# Snippet:Sample_CreateConversation_MemoryTool_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

ResponseItem request = ResponseItem.CreateUserMessageItem("Hello, tell me a joke.");
ResponseResult response = responseClient.CreateResponse([request]);
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversation_MemoryTool_Async
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
ResponseItem request = ResponseItem.CreateUserMessageItem("Hello, tell me a joke.");
ResponseResult response = await responseClient.CreateResponseAsync([request]);
```

5. Make sure the repone has completed, create new response item with the agent response and put it to the `MemoryUpdateOptions` object.

Synchronous sample:
```C# Snippet:Sample_WriteOutput_MemoryTool_Sync
string scope = "Joke";
MemoryUpdateOptions memoryOptions = new(scope);
memoryOptions.Items.Add(request);
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
// We cannot use the output items as an input so we will need to
// create a new user item.
memoryOptions.Items.Add(ResponseItem.CreateUserMessageItem($"Agent answered: {response.GetOutputText()}"));
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_WriteOutput_MemoryTool_Async
string scope = "Joke";
MemoryUpdateOptions memoryOptions = new(scope);
memoryOptions.Items.Add(request);
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
// We cannot use the output items as an input so we will need to
// create a new user item.
memoryOptions.Items.Add(ResponseItem.CreateUserMessageItem($"Agent answered: {response.GetOutputText()}"));
Console.WriteLine(response.GetOutputText());
```

6. Create `MemoryStore` and add the memory related to previous conversation, stored in `MemoryUpdateOptions`. If the operation fails, throw the appropriate error.

Synchronous sample:
```C# Snippet:CreateMemoryStore_MemoryTool_Sync
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
);
memoryStoreDefinition.Options = new(userProfileEnabled: true, chatSummaryEnabled: true);
MemoryStore memoryStore = projectClient.MemoryStores.CreateMemoryStore(
    name: "jokeMemory",
    definition: memoryStoreDefinition,
    description: "Memory store for conversation."
);
MemoryUpdateResult updateResult = projectClient.MemoryStores.WaitForMemoriesUpdate(memoryStoreName: memoryStore.Name, options: memoryOptions, pollingInterval: 500);
if (updateResult.Status == MemoryStoreUpdateStatus.Failed)
{
    throw new InvalidOperationException(updateResult.ErrorDetails);
}
```

Asynchronous sample:
```C# Snippet:CreateMemoryStore_MemoryTool_Async
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
);
memoryStoreDefinition.Options = new(userProfileEnabled: true, chatSummaryEnabled: true);
MemoryStore memoryStore = await projectClient.MemoryStores.CreateMemoryStoreAsync(
    name: "jokeMemory",
    definition: memoryStoreDefinition,
    description: "Memory store for conversation."
);
MemoryUpdateResult updateResult = await projectClient.MemoryStores.WaitForMemoriesUpdateAsync(memoryStoreName: memoryStore.Name, options: memoryOptions, pollingInterval: 500);
if (updateResult.Status == MemoryStoreUpdateStatus.Failed)
{
    throw new InvalidOperationException(updateResult.ErrorDetails);
}
```

7. Check that the memory store contain the relevant memories.

Synchronous sample:
```C# Snippet:Sample_CheckMemorySearch_Sync
MemorySearchOptions searchOptions = new(scope)
{
    Items = { ResponseItem.CreateUserMessageItem("What was the joke?") },
};
MemoryStoreSearchResponse resp = projectClient.MemoryStores.SearchMemories(
    memoryStoreName: memoryStore.Name,
    options: searchOptions
);
Console.WriteLine("==The output from memory search tool.==");
foreach (Azure.AI.Projects.MemorySearchItem item in resp.Memories)
{
    Console.WriteLine(item.MemoryItem.Content);
}
Console.WriteLine("==End of memory search tool output.==");
```

Asynchronous sample:
```C# Snippet:Sample_CheckMemorySearch_Async
MemorySearchOptions searchOptions = new(scope)
{
    Items = { ResponseItem.CreateUserMessageItem("What was the joke?") },
};
MemoryStoreSearchResponse resp = await projectClient.MemoryStores.SearchMemoriesAsync(
    memoryStoreName: memoryStore.Name,
    options: searchOptions
);
Console.WriteLine("==The output from memory tool.==");
foreach (Azure.AI.Projects.MemorySearchItem item in resp.Memories)
{
    Console.WriteLine(item.MemoryItem.Content);
}
Console.WriteLine("==End of memory tool output.==");
```

8. Create another Agent capable to use `MemorySearchTool`.

Synchronous sample:
```C# Snippet:Sample_CreateAgentWithTool_MemoryTool_Sync
agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent capable to access memorized conversation.",
};
agentDefinition.Tools.Add(new MemorySearchPreviewTool(memoryStoreName: memoryStore.Name, scope: scope));
AgentVersion agentVersion2 = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent2",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentWithTool_MemoryTool_Async
agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent capable to access memorized conversation.",
};
agentDefinition.Tools.Add(new MemorySearchPreviewTool(memoryStoreName: memoryStore.Name, scope: scope));
AgentVersion agentVersion2 = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent2",
    options: new(agentDefinition));
```

9. Get the response about memorized answers.

Synchronous sample:
```C# Snippet:Sample_AnotherConversation_MemoryTool_Sync
responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion2.Name);

response = responseClient.CreateResponse(
    [ResponseItem.CreateUserMessageItem("Please explain me the meaning of the joke from the previous conversation.")]);
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_AnotherConversation_MemoryTool_Async
responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion2.Name);

response = await responseClient.CreateResponseAsync(
    "Please explain me the meaning of the joke from the previous conversation.");
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

10. Clean up resources by deleting conversations and Agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_MemoryTool_Sync
projectClient.MemoryStores.DeleteMemoryStore(name: memoryStore.Name);
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_MemoryTool_Async
await projectClient.MemoryStores.DeleteMemoryStoreAsync(name: memoryStore.Name);
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
```
