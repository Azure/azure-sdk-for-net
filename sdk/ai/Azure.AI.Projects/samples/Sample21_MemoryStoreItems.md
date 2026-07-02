# Sample for management of `MemoryStoreItem` in Azure.AI.Projects.

**Note:** Memory stores is an experimental feature, to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

In this example we will demonstrate how to create, update, list and delete memory store items. Before running the sample, please follow the [instructions](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/memory-usage) to set up required permissions.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_MemoryStoreItems
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MEMORY_STORE_CHAT_MODEL_DEPLOYMENT_NAME");
var embeddingDeploymentName = System.Environment.GetEnvironmentVariable("MEMORY_STORE_EMBEDDING_MODEL_DEPLOYMENT_NAME");
AIProjectClientOptions opts = new();
opts.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);
AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential(), options: opts);
```

2. Use the client to create the `MemoryStore`. Memory store requires two models, one for embedding and another for chat completion.

Synchronous sample:
```C# Snippet:Sample_CreateMemoryStore_MemoryStoreItems_Sync
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
)
{
    Options = new(isUserProfileEnabled: true, isChatSummaryEnabled: true)
};
MemoryStore memoryStore = projectClient.MemoryStores.CreateMemoryStore(
    name: "testMemoryStore",
    definition: memoryStoreDefinition,
    description: "Memory store demo."
);
Console.WriteLine($"Memory store with id {memoryStore.Id}, name {memoryStore.Name} and description {memoryStore.Description} was created.");
string scope = "Store";
```

Asynchronous sample:
```C# Snippet:Sample_CreateMemoryStore_MemoryStoreItems_Async
MemoryStoreDefaultDefinition memoryStoreDefinition = new(
    chatModel: modelDeploymentName,
    embeddingModel: embeddingDeploymentName
)
{
    Options = new(isUserProfileEnabled: true, isChatSummaryEnabled: true)
};
MemoryStore memoryStore = await projectClient.MemoryStores.CreateMemoryStoreAsync(
    name: "testMemoryStore",
    definition: memoryStoreDefinition,
    description: "Memory store demo."
);
Console.WriteLine($"Memory store with id {memoryStore.Id}, name {memoryStore.Name} and description {memoryStore.Description} was created.");
string scope = "Store";
```

3. Create a couple of memory store items.

Synchronous sample:
```C# Snippet:Sample_CreateItems_MemoryStoreItems_Sync
MemoryItem customerData = projectClient.MemoryStores.CreateMemory(name: memoryStore.Name, scope: scope, content: "The lover of oranges.", kind: MemoryItemKind.UserProfile);
MemoryItem orangeSKU = projectClient.MemoryStores.CreateMemory(name: memoryStore.Name, scope: scope, content: "Orange SKU is 658954.", kind: MemoryItemKind.ChatSummary);
Console.WriteLine($"Created memory store item {customerData.MemoryId}: {customerData.Content}");
Console.WriteLine($"Created memory store item {orangeSKU.MemoryId}: {orangeSKU.Content}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateItems_MemoryStoreItems_Async
MemoryItem customerData = await projectClient.MemoryStores.CreateMemoryAsync(name: memoryStore.Name, scope: scope, content: "The lover of oranges.", kind: MemoryItemKind.UserProfile);
MemoryItem orangeSKU = await projectClient.MemoryStores.CreateMemoryAsync(name: memoryStore.Name, scope: scope, content: "Orange SKU is 658954.", kind: MemoryItemKind.ChatSummary);
Console.WriteLine($"Created memory store item {customerData.MemoryId}: {customerData.Content}");
Console.WriteLine($"Created memory store item {orangeSKU.MemoryId}: {orangeSKU.Content}");
```

4. Update a memory store item.

Synchronous sample:
```C# Snippet:Sample_UpdateItem_MemoryStoreItems_Sync
MemoryItem item = projectClient.MemoryStores.UpdateMemory(name: memoryStore.Name, memoryId: orangeSKU.MemoryId, content: "Apple SKU is 786545.");
Console.WriteLine($"Updated memory store item {item.MemoryId}, new content: {item.Content}");
```

Asynchronous sample:
```C# Snippet:Sample_UpdateItem_MemoryStoreItems_Async
MemoryItem item = await projectClient.MemoryStores.UpdateMemoryAsync(name: memoryStore.Name, memoryId: orangeSKU.MemoryId, content: "Apple SKU is 786545.");
Console.WriteLine($"Updated memory store item {item.MemoryId}, new content: {item.Content}");
```

5. Get the memory store item.

Synchronous sample:
```C# Snippet:Sample_GetItems_MemoryStoreItems_Sync
item = projectClient.MemoryStores.GetMemory(name: memoryStore.Name, memoryId: customerData.MemoryId);
Console.WriteLine($"Retrieved memory store item {item.MemoryId}: {item.Content}");
```

Asynchronous sample:
```C# Snippet:Sample_GetItems_MemoryStoreItems_Async
item = await projectClient.MemoryStores.GetMemoryAsync(name: memoryStore.Name, memoryId: customerData.MemoryId);
Console.WriteLine($"Retrieved memory store item {item.MemoryId}: {item.Content}");
```

6. List memory store items, named "Sample".

Synchronous sample:
```C# Snippet:Sample_ListItems_MemoryStoreItems_Sync
Console.WriteLine($"Listing memory store items from {memoryStore.Name}");
foreach (MemoryItem oneItem in projectClient.MemoryStores.GetMemories(name: memoryStore.Name, scope: scope))
{
    Console.WriteLine($"    item {oneItem.MemoryId}: {oneItem.Content}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListItems_MemoryStoreItems_Async
Console.WriteLine($"Listing memory store items from {memoryStore.Name}");
await foreach (MemoryItem oneItem in projectClient.MemoryStores.GetMemoriesAsync(name: memoryStore.Name, scope: scope))
{
    Console.WriteLine($"    item {oneItem.MemoryId}: {oneItem.Content}");
}
```

7. Finally, `MemoryStoreItem`-s we have created.

Synchronous sample:
```C# Snippet:Sample_Delete_UpdateStoreItems_Sync
MemoryDeletionResult response = projectClient.MemoryStores.DeleteMemory(name: memoryStore.Name, memoryId: customerData.MemoryId);
Console.WriteLine($"Memory Item with ID {response.MemoryId} was{(response.Deleted ? " " : " not ")}removed.");
response = projectClient.MemoryStores.DeleteMemory(name: memoryStore.Name, memoryId: orangeSKU.MemoryId);
Console.WriteLine($"Memory Item with ID {response.MemoryId} was{(response.Deleted ? " " : " not ")}removed.");
```

Asynchronous sample:
```C# Snippet:Sample_Delete_UpdateStoreItems_Async
MemoryDeletionResult response = await projectClient.MemoryStores.DeleteMemoryAsync(name: memoryStore.Name, memoryId: customerData.MemoryId);
Console.WriteLine($"Memory Item with ID {response.MemoryId} was{(response.Deleted ? " " : " not ")}removed.");
response = await projectClient.MemoryStores.DeleteMemoryAsync(name: memoryStore.Name, memoryId: orangeSKU.MemoryId);
Console.WriteLine($"Memory Item with ID {response.MemoryId} was{(response.Deleted ? " " : " not ")}removed.");
```

8. Delete memory store.

Synchronous sample:
```C# Snippet:Sample_DeleteMemoryStore_UpdateStoreItems_Sync
projectClient.MemoryStores.DeleteMemoryStore(memoryStore.Name);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteMemoryStore_UpdateStoreItems_Async
await projectClient.MemoryStores.DeleteMemoryStoreAsync(memoryStore.Name);
```
