# Sample of using `MemoryStore` in Azure.AI.Projects.

In this example we will demonstrate how to create, update, list and delete memory stores and scopes inside them.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_MemoryStore
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var embeddingDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
```

2. Use the client to create the `MemoryStore`. Memory store requires two models, one for embedding and another for chat completion.

Synchronous sample:
```C# Snippet:Sample_Create_MemoryStore_Sync
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
);
memoryStoreDefinition.Options = new(userProfileEnabled: true, chatSummaryEnabled: true);
MemoryStore memoryStore = projectClient.MemoryStores.CreateMemoryStore(
    name: "testMemoryStore",
    definition: memoryStoreDefinition,
    description: "Memory store demo."
);
Console.WriteLine($"Memory store with id {memoryStore.Id}, name {memoryStore.Name} and description {memoryStore.Description} was created.");
```

Asynchronous sample:
```C# Snippet:Sample_Create_MemoryStore_Async
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
);
memoryStoreDefinition.Options = new(userProfileEnabled: true, chatSummaryEnabled: true);
MemoryStore memoryStore = await projectClient.MemoryStores.CreateMemoryStoreAsync(
    name: "testMemoryStore",
    definition: memoryStoreDefinition,
    description: "Memory store demo."
);
Console.WriteLine($"Memory store with id {memoryStore.Id}, name {memoryStore.Name} and description {memoryStore.Description} was created.");
```

4. Update the description of memory store we have just created.

Synchronous sample:
```C# Snippet:Sample_Update_MemoryStore_Sync
memoryStore = projectClient.MemoryStores.UpdateMemoryStore(name: memoryStore.Name, description: "New description for memory store demo.");
Console.WriteLine($"Memory store with id {memoryStore.Id}, name {memoryStore.Name} now has description: {memoryStore.Description}.");
```

Asynchronous sample:
```C# Snippet:Sample_Update_MemoryStore_Async
memoryStore = await projectClient.MemoryStores.UpdateMemoryStoreAsync(name: memoryStore.Name, description: "New description for memory store demo.");
Console.WriteLine($"Memory store with id {memoryStore.Id}, name {memoryStore.Name} now has description: {memoryStore.Description}.");
```

5. Get the memory store.

Synchronous sample:
```C# Snippet:Sample_Get_MemoryStore_Sync
memoryStore = projectClient.MemoryStores.GetMemoryStore(name: memoryStore.Name);
Console.WriteLine($"Returned Memory store with id {memoryStore.Id}, name {memoryStore.Name} and description {memoryStore.Description}.");
```

Asynchronous sample:
```C# Snippet:Sample_Get_MemoryStore_Async
memoryStore = await projectClient.MemoryStores.GetMemoryStoreAsync(name: memoryStore.Name);
Console.WriteLine($"Returned Memory store with id {memoryStore.Id}, name {memoryStore.Name} and description {memoryStore.Description}.");
```

6. List all memory stores in our Microsoft Foundry.

Synchronous sample:
```C# Snippet:Sample_List_MemoryStore_Sync
foreach (MemoryStore store in projectClient.MemoryStores.GetMemoryStores())
{
    Console.WriteLine($"Memory store id: {store.Id}, name: {store.Name}, description: {store.Description}.");
}
```

Asynchronous sample:
```C# Snippet:Sample_List_MemoryStore_Async
await foreach (MemoryStore store in projectClient.MemoryStores.GetMemoryStoresAsync())
{
    Console.WriteLine($"Memory store id: {store.Id}, name: {store.Name}, description: {store.Description}.");
}
```

7. Create a scope in the `MemoryStore` and add one item.

Synchronous sample:
```C# Snippet:Sample_AddMemories_MemoryStore_Sync
string scope = "Flower";
MemoryUpdateOptions memoryOptions = new(scope);
memoryOptions.Items.Add(ResponseItem.CreateUserMessageItem("My favourite flower is Cephalocereus euphorbioides."));
MemoryUpdateResult updateResult = projectClient.MemoryStores.WaitForMemoriesUpdate(memoryStoreName: memoryStore.Name, options: memoryOptions, pollingInterval: 500);
if (updateResult.Status == MemoryStoreUpdateStatus.Failed)
{
    throw new InvalidOperationException(updateResult.ErrorDetails);
}
Console.WriteLine($"The update operation {updateResult.UpdateId} has finished with {updateResult.Status} status.");
```

Asynchronous sample:
```C# Snippet:Sample_AddMemories_MemoryStore_Async
string scope = "Flower";
MemoryUpdateOptions memoryOptions = new(scope);
memoryOptions.Items.Add(ResponseItem.CreateUserMessageItem("My favourite flower is Cephalocereus euphorbioides."));
MemoryUpdateResult updateResult = await projectClient.MemoryStores.WaitForMemoriesUpdateAsync(memoryStoreName: memoryStore.Name, options: memoryOptions, pollingInterval: 500);
if (updateResult.Status == MemoryStoreUpdateStatus.Failed)
{
    throw new InvalidOperationException(updateResult.ErrorDetails);
}
Console.WriteLine($"The update operation {updateResult.UpdateId} has finished with {updateResult.Status} status.");
```

8. Ask the question about the memorized item.

Synchronous sample:
```C# Snippet:Sample_MemorySearch_Sync
MemorySearchOptions opts = new(scope)
{
    Items = { ResponseItem.CreateUserMessageItem("What was is your favourite flower?") },
};
MemoryStoreSearchResponse resp = projectClient.MemoryStores.SearchMemories(
    memoryStoreName: memoryStore.Name,
    options: new(scope)
);
Console.WriteLine("==The output from memory tool.==");
foreach (Azure.AI.Projects.MemorySearchItem item in resp.Memories)
{
    Console.WriteLine(item.MemoryItem.Content);
}
Console.WriteLine("==End of memory tool output.==");
```

Asynchronous sample:
```C# Snippet:Sample_MemorySearch_Async
MemorySearchOptions opts = new(scope)
{
    Items = { ResponseItem.CreateUserMessageItem("What was is your favourite flower?") },
};
MemoryStoreSearchResponse resp = await projectClient.MemoryStores.SearchMemoriesAsync(
    memoryStoreName: memoryStore.Name,
    options: new(scope)
);
Console.WriteLine("==The output from memory tool.==");
foreach (Azure.AI.Projects.MemorySearchItem item in resp.Memories)
{
    Console.WriteLine(item.MemoryItem.Content);
}
Console.WriteLine("==End of memory tool output.==");
```

9. Remove the scope we have created from `MemoryStore`.

Synchronous sample:
```C# Snippet:Sample_DeleteScope_MemoryStore_Sync
MemoryStoreDeleteScopeResponse deleteScopeResponse = projectClient.MemoryStores.DeleteScope(name: memoryStore.Name, scope: "Flower");
string status = deleteScopeResponse.Deleted ? "" : " not";
Console.WriteLine($"The scope {deleteScopeResponse.Name} was{status} deleted.");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteScope_MemoryStore_Async
MemoryStoreDeleteScopeResponse deleteScopeResponse = await projectClient.MemoryStores.DeleteScopeAsync(name: memoryStore.Name, scope: "Flower");
string status = deleteScopeResponse.Deleted ? "" : " not";
Console.WriteLine($"The scope {deleteScopeResponse.Name} was{status} deleted.");
```

10. Finally, delete `MemoryStore`.

Synchronous sample:
```C# Snippet:Sample_Cleanup_MemoryStore_Sync
DeleteMemoryStoreResponse deleteResponse = projectClient.MemoryStores.DeleteMemoryStore(name: memoryStore.Name);
status = deleteResponse.Deleted ? "" : " not";
Console.WriteLine($"The memory store {deleteResponse.Name} was{status} deleted.");
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_MemoryStore_Async
DeleteMemoryStoreResponse deleteResponse = await projectClient.MemoryStores.DeleteMemoryStoreAsync(name: memoryStore.Name);
status = deleteResponse.Deleted ? "" : " not";
Console.WriteLine($"The memory store {deleteResponse.Name} was{status} deleted.");
```
