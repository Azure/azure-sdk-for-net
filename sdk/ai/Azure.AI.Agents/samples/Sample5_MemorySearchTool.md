# Sample of using `MemorySearchTool` with Agent in Azure.AI.Agents.

In this example we will demonstrate how to use `MemorySearchTool`. We will create `MemoryStoreObject` and store the conversaton there. Then we will create another agent, capable to read it.

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_MemoryTool
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var embeddingDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create the versioned agent object.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_MemoryTool_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion = client.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_MemoryTool_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion = await client.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
```

4. Create a conversation and get the `OpenAIResponse` object.

Synchronous sample:
```C# Snippet:Sample_CreateConversation_MemoryTool_Sync
OpenAIClient openAIClient = client.GetOpenAIClient();
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

ResponseCreationOptions responseOptions = new();
responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

ResponseItem request = ResponseItem.CreateUserMessageItem("Hello, tell me a joke.");
OpenAIResponse response = responseClient.CreateResponse(
    [request],
    responseOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversation_MemoryTool_Async
OpenAIClient openAIClient = client.GetOpenAIClient();
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

ResponseCreationOptions responseOptions = new();
responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

ResponseItem request = ResponseItem.CreateUserMessageItem("Hello, tell me a joke.");
OpenAIResponse response = await responseClient.CreateResponseAsync(
    [request],
    responseOptions);
```

5. Wait for the response to complete and record the responses to `MemoryUpdateOptions` object.

Synchronous sample:
```C# Snippet:Sample_WriteOutput_MemoryTool_Sync
string scope = "Joke from conversation";
List<ResponseItem> updateItems = [request];
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    response = responseClient.GetResponse(responseId: response.Id);
}
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));

foreach (ResponseItem item in response.OutputItems)
{
    updateItems.Add(item);
}
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_WriteOutput_MemoryTool_Async
string scope = "Joke from conversation";
List<ResponseItem> updateItems = [request];
while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed){
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    response = await responseClient.GetResponseAsync(responseId:  response.Id);
}
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));

foreach (ResponseItem item in response.OutputItems)
{
    updateItems.Add(item);
}
Console.WriteLine(response.GetOutputText());
```

6. Create `MemoryStoreObject` and add the memory related to previous conversation, stored in `MemoryUpdateOptions`.

Synchronous sample:
```C# Snippet:CreateMemoryStore_MemoryTool_Sync
MemoryStoreClient memoryClient = client.GetMemoryStoreClient();
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
);
MemoryStore memoryStore = memoryClient.CreateMemoryStore(
    name: "jokeMemory",
    definition: memoryStoreDefinition,
    description: "Memory store for conversation."
);
memoryClient.UpdateMemories(memoryStore.Id, scope, updateItems);
```

Asynchronous sample:
```C# Snippet:CreateMemoryStore_MemoryTool_Async
MemoryStoreClient memoryClient = client.GetMemoryStoreClient();
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
);
MemoryStore memoryStore = await memoryClient.CreateMemoryStoreAsync(
    name: "jokeMemory",
    definition: memoryStoreDefinition,
    description: "Memory store for conversation."
);
memoryClient.UpdateMemories(memoryStore.Id, scope, updateItems);
```

7. Check that the memory store contain the relevant memories.

Synchronous sample:
```C# Snippet:Sample_CheckMemorySearch_Sync
MemorySearchOptions opts = new()
{
    MaxMemories = 1,
    Items = { ResponseItem.CreateUserMessageItem("What was the joke?") },
};
MemoryStoreSearchResponse resp = memoryClient.SearchMemories(
    memoryStoreId: memoryStore.Id,
    scope: scope,
    options: opts
);
Console.WriteLine("==The output from memory search tool.==");
foreach (MemorySearchItem item in resp.Memories)
{
    Console.WriteLine(item.MemoryItem.Content);
}
Console.WriteLine("==End of memory search tool output.==");
```

Asynchronous sample:
```C# Snippet:Sample_CheckMemorySearch_Async
MemorySearchOptions opts = new()
{
    MaxMemories = 1,
    Items = { ResponseItem.CreateUserMessageItem("What was the joke?") },
};
MemoryStoreSearchResponse resp = await memoryClient.SearchMemoriesAsync(
    memoryStoreId: memoryStore.Id,
    scope: scope,
    options: opts
);
Console.WriteLine("==The output from memory tool.==");
foreach (MemorySearchItem item in resp.Memories)
{
    Console.WriteLine(item.MemoryItem.Content);
}
Console.WriteLine("==End of memory tool output.==");
```

8. Create another agent capable to use `MemorySearchTool`.

Synchronous sample:
```C# Snippet:Sample_CreateAgentWithTool_MemoryTool_Sync
agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent capable to access memorised conversation.",
};
agentDefinition.Tools.Add(new MemorySearchTool(memoryStoreName: memoryStore.Name, scope: scope));
AgentVersion agentVersion2 = client.CreateAgentVersion(
    agentName: "myAgent2",
    options: new(agentDefinition));
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentWithTool_MemoryTool_Async
agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent capable to access memorised conversation.",
};
agentDefinition.Tools.Add(new MemorySearchTool(memoryStoreName: memoryStore.Name, scope: scope));
AgentVersion agentVersion2 = await client.CreateAgentVersionAsync(
    agentName: "myAgent2",
    options: new(agentDefinition));
```

9. Create a new conversation and get the response about memorized answers.

Synchronous sample:
```C# Snippet:Sample_AnotherConversation_MemoryTool_Sync
responseOptions = new();
responseOptions.SetAgentReference(new AgentReference(name: agentVersion2.Name));

response = responseClient.CreateResponse(
    [ResponseItem.CreateUserMessageItem("Please explain me the meaning of the joke from the previous conversation.")],
    responseOptions);
while (response.Status != ResponseStatus.Incomplete || response.Status != ResponseStatus.Failed || response.Status != ResponseStatus.Completed)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    response = responseClient.GetResponse(responseId: response.Id);
}
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_AnotherConversation_MemoryTool_Async
responseOptions = new();
responseOptions.SetAgentReference(new AgentReference(name: agentVersion2.Name));

response = await responseClient.CreateResponseAsync(
    [ResponseItem.CreateUserMessageItem("Please explain me the meaning of the joke from the previous conversation.")],
    responseOptions);
while (response.Status != ResponseStatus.Incomplete || response.Status != ResponseStatus.Failed || response.Status != ResponseStatus.Completed)
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    response = await responseClient.GetResponseAsync(responseId: response.Id);
}
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

10. Clean up resources by deleting conversations and agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_MemoryTool_Sync
memoryClient.DeleteMemoryStore(name: memoryStore.Name);
client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
client.DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_MemoryTool_Async
await memoryClient.DeleteMemoryStoreAsync(name: memoryStore.Name);
await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
await client.DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
```
