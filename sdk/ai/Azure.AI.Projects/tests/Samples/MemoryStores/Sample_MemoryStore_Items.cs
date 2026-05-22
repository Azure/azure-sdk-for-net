// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects.Memory;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples;

public class Sample_MemoryStoreItems : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task MemoryStoreItemsAsync()
    {
        #region Snippet:Sample_MemoryStoreItems
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MEMORY_STORE_CHAT_MODEL_DEPLOYMENT_NAME");
        var embeddingDeploymentName = System.Environment.GetEnvironmentVariable("MEMORY_STORE_EMBEDDING_MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MEMORY_STORE_CHAT_MODEL_DEPLOYMENT_NAME;
        var embeddingDeploymentName = TestEnvironment.MEMORY_STORE_EMBEDDING_MODEL_DEPLOYMENT_NAME;
#endif
        AIProjectClientOptions opts = new();
        opts.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential(), options: opts);
        #endregion
        try
        {
            await projectClient.MemoryStores.DeleteMemoryStoreAsync("testMemoryStore");
        }
        catch
        {
            // Nothing here.
        }
        #region Snippet:Sample_CreateMemoryStore_MemoryStoreItems_Async
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
        #endregion
        #region Snippet:Sample_CreateItems_MemoryStoreItems_Async
        MemoryItem customerData = await projectClient.MemoryStores.CreateMemoryAsync(name: memoryStore.Name, scope: scope, content: "The lover of oranges.", kind: MemoryItemKind.UserProfile);
        MemoryItem orangeSKU = await projectClient.MemoryStores.CreateMemoryAsync(name: memoryStore.Name, scope: scope, content: "Orange SKU is 658954.", kind: MemoryItemKind.ChatSummary);
        Console.WriteLine($"Created memory store item {customerData.MemoryId}: {customerData.Content}");
        Console.WriteLine($"Created memory store item {orangeSKU.MemoryId}: {orangeSKU.Content}");
        #endregion
        #region Snippet:Sample_UpdateItem_MemoryStoreItems_Async
        MemoryItem item = await projectClient.MemoryStores.UpdateMemoryAsync(name: memoryStore.Name, memoryId: orangeSKU.MemoryId, "Apple SKU is 786545.");
        Console.WriteLine($"Updated memory store item {item.MemoryId}, new content: {item.Content}");
        #endregion
        #region Snippet:Sample_GetItems_MemoryStoreItems_Async
        item = await projectClient.MemoryStores.GetMemoryAsync(name: memoryStore.Name, memoryId: customerData.MemoryId);
        Console.WriteLine($"Retrieved memory store item {item.MemoryId}: {item.Content}");
        #endregion
        #region Snippet:Sample_ListItems_MemoryStoreItems_Async
        Console.WriteLine($"Listing memory store items from {memoryStore.Name}");
        await foreach (MemoryItem oneItem in projectClient.MemoryStores.GetMemoriesAsync(name: memoryStore.Name, scope: scope))
        {
            Console.WriteLine($"    item {item.MemoryId}: {item.Content}");
        }
        #endregion
        #region Snippet:Sample_Delete_UpdateStoreItems_Async
        DeleteMemoryResponse response = await projectClient.MemoryStores.DeleteMemoryAsync(name: memoryStore.Name, memoryId: customerData.MemoryId);
        Console.WriteLine($"Memory Item with ID {response.MemoryId} was{(response.Deleted ? " " : " not ")}removed.");
        response = await projectClient.MemoryStores.DeleteMemoryAsync(name: memoryStore.Name, memoryId: orangeSKU.MemoryId);
        Console.WriteLine($"Memory Item with ID {response.MemoryId} was{(response.Deleted ? " " : " not ")}removed.");
        #endregion
        #region Snippet:Sample_DeleteMemoryStore_UpdateStoreItems_Async
        await projectClient.MemoryStores.DeleteMemoryStoreAsync(memoryStore.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void MemoryStoreItemsSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MEMORY_STORE_CHAT_MODEL_DEPLOYMENT_NAME");
        var embeddingDeploymentName = System.Environment.GetEnvironmentVariable("MEMORY_STORE_EMBEDDING_MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MEMORY_STORE_CHAT_MODEL_DEPLOYMENT_NAME;
        var embeddingDeploymentName = TestEnvironment.MEMORY_STORE_EMBEDDING_MODEL_DEPLOYMENT_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(projectEndpoint), new DefaultAzureCredential());
        try
        {
            projectClient.MemoryStores.DeleteMemoryStore("testMemoryStore");
        }
        catch
        {
            // Nothing here.
        }
        #region Snippet:Sample_CreateMemoryStore_MemoryStoreItems_Sync
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
        #endregion
        #region Snippet:Sample_CreateItems_MemoryStoreItems_Sync
        MemoryItem customerData = projectClient.MemoryStores.CreateMemory(name: memoryStore.Name, scope: scope, content: "The lover of oranges.", kind: MemoryItemKind.UserProfile);
        MemoryItem orangeSKU = projectClient.MemoryStores.CreateMemory(name: memoryStore.Name, scope: scope, content: "Orange SKU is 658954.", kind: MemoryItemKind.ChatSummary);
        Console.WriteLine($"Created memory store item {customerData.MemoryId}: {customerData.Content}");
        Console.WriteLine($"Created memory store item {orangeSKU.MemoryId}: {orangeSKU.Content}");
        #endregion
        #region Snippet:Sample_UpdateItem_MemoryStoreItems_Sync
        MemoryItem item = projectClient.MemoryStores.UpdateMemory(name: memoryStore.Name, memoryId: orangeSKU.MemoryId, "Apple SKU is 786545.");
        Console.WriteLine($"Updated memory store item {item.MemoryId}, new content: {item.Content}");
        #endregion
        #region Snippet:Sample_GetItems_MemoryStoreItems_Sync
        item = projectClient.MemoryStores.GetMemory(name: memoryStore.Name, memoryId: customerData.MemoryId);
        Console.WriteLine($"Retrieved memory store item {item.MemoryId}: {item.Content}");
        #endregion
        #region Snippet:Sample_ListItems_MemoryStoreItems_Sync
        Console.WriteLine($"Listing memory store items from {memoryStore.Name}");
        foreach (MemoryItem oneItem in projectClient.MemoryStores.GetMemories(name: memoryStore.Name, scope: scope))
        {
            Console.WriteLine($"    item {item.MemoryId}: {item.Content}");
        }
        #endregion
        #region Snippet:Sample_Delete_UpdateStoreItems_Sync
        DeleteMemoryResponse response = projectClient.MemoryStores.DeleteMemory(name: memoryStore.Name, memoryId: customerData.MemoryId);
        Console.WriteLine($"Memory Item with ID {response.MemoryId} was{(response.Deleted ? " " : " not ")}removed.");
        response = projectClient.MemoryStores.DeleteMemory(name: memoryStore.Name, memoryId: orangeSKU.MemoryId);
        Console.WriteLine($"Memory Item with ID {response.MemoryId} was{(response.Deleted ? " " : " not ")}removed.");
        #endregion
        #region Snippet:Sample_DeleteMemoryStore_UpdateStoreItems_Sync
        projectClient.MemoryStores.DeleteMemoryStore(memoryStore.Id);
        #endregion
    }

    public Sample_MemoryStoreItems(bool isAsync) : base(isAsync)
    { }
}
