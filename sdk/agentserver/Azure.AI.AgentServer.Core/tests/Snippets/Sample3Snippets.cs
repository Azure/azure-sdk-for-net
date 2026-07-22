// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Storage;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample3_StateStore.md. Compiled to prevent rot but
    /// require a running Foundry storage endpoint to execute.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running Foundry storage endpoint to execute.")]
    public class Sample3Snippets
    {
        [Test]
        public async Task GetOrCreate()
        {
            #region Snippet:Core_Sample3_GetOrCreate

            TokenCredential credential = new DefaultAzureCredential();

            // GetOrCreateAsync fetches the store, or creates it if it does not exist,
            // in a single call — so you can read and write items right away.
            // When endpoint is null it is resolved from the FOUNDRY_PROJECT_ENDPOINT
            // environment variable.
            FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
                "checkpoints/thread-abc",
                credential,
                userIsolation: true,
                itemTtlSeconds: 3600,
                description: "Checkpoint store for thread abc");

            await store.SetItemAsync(
                "step-1",
                new Dictionary<string, BinaryData> { ["done"] = BinaryData.FromObjectAsJson(false) });

            StateStoreItem? item = await store.GetItemAsync("step-1");
            if (item is not null)
            {
                bool done = item.Value["done"].ToObjectFromJson<bool>();
                Console.WriteLine($"{item.Key}: done={done}, etag={item.Etag}");
            }

            #endregion
        }

        [Test]
        public async Task StoreLifecycle()
        {
            TokenCredential credential = new DefaultAzureCredential();
            FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync("checkpoints/thread-abc", credential);

            #region Snippet:Core_Sample3_StoreLifecycle

            // Store-level operations act on the bound store itself; the *Item methods
            // act on individual items within it.
            StateStore? info = await store.GetAsync();          // the store's metadata; null when absent
            Console.WriteLine(info?.Name);

            StateStore updated = await store.UpdateAsync(new StateStoreUpdateOptions
            {
                Description = "Checkpoint store for prod traffic",
                Tags = new Dictionary<string, string> { ["env"] = "prod", ["team"] = "agents" },
            });
            Console.WriteLine(updated.Description);

            DeletedStateStore deleted = await store.DeleteAsync();   // cascades to every item
            Console.WriteLine(deleted.Deleted);

            #endregion
        }

        [Test]
        public async Task Items()
        {
            TokenCredential credential = new DefaultAzureCredential();
            FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync("checkpoints/thread-abc", credential);

            #region Snippet:Core_Sample3_Items

            var tags = new Dictionary<string, string> { ["kind"] = "checkpoint" };

            // CreateItemAsync fails with a 409 conflict when the key already exists.
            StateStoreItemRef created = await store.CreateItemAsync(
                "step-1",
                new Dictionary<string, BinaryData> { ["done"] = BinaryData.FromObjectAsJson(false) },
                tags);
            Console.WriteLine(created.Etag);

            // SetItemAsync creates the item, or replaces it if the key already exists.
            StateStoreItemRef replaced = await store.SetItemAsync(
                "step-1",
                new Dictionary<string, BinaryData> { ["done"] = BinaryData.FromObjectAsJson(true) },
                tags);
            Console.WriteLine(replaced.Etag);

            // GetItemAsync returns null when the item is missing.
            StateStoreItem? item = await store.GetItemAsync("step-1");
            if (item is not null)
            {
                Console.WriteLine($"{item.Id} {item.Key} {item.Etag}");
            }

            // Deletes are idempotent.
            DeletedStateStoreItem deleted = await store.DeleteItemAsync("step-1");
            Console.WriteLine(deleted.Deleted);

            #endregion
        }

        [Test]
        public async Task Concurrency()
        {
            TokenCredential credential = new DefaultAzureCredential();
            FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync("counters/thread-abc", credential);

            #region Snippet:Core_Sample3_Concurrency

            StateStoreItem? current = await store.GetItemAsync("counter");
            if (current is null)
            {
                return;
            }

            int next = current.Value["value"].ToObjectFromJson<int>() + 1;

            try
            {
                // if-Match guards the write: it only succeeds while the etag is unchanged.
                await store.SetItemAsync(
                    "counter",
                    new Dictionary<string, BinaryData> { ["value"] = BinaryData.FromObjectAsJson(next) },
                    ifMatch: current.Etag);
            }
            catch (FoundryStoragePreconditionException ex)
            {
                Console.WriteLine($"Item changed; current etag is {ex.CurrentETag}");
            }

            // requireExists: true fails instead of creating the item when the key is absent.
            await store.SetItemAsync(
                "counter",
                new Dictionary<string, BinaryData> { ["value"] = BinaryData.FromObjectAsJson(next) },
                requireExists: true);

            #endregion
        }

        [Test]
        public async Task ListKeys()
        {
            TokenCredential credential = new DefaultAzureCredential();
            FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync("checkpoints/thread-abc", credential);

            #region Snippet:Core_Sample3_ListKeys

            var filter = new Dictionary<string, string> { ["kind"] = "checkpoint" };

            StateStoreItemKeyPage page = await store.ListKeysAsync(
                tags: filter,
                limit: 50,
                order: ListRequestOrder.Asc);

            foreach (StateStoreItemKey key in page.Keys)
            {
                Console.WriteLine($"{key.Id} {key.Key} {key.Etag}");
            }

            // Cursor paging by item id.
            while (page.HasMore && page.LastId is not null)
            {
                page = await store.ListKeysAsync(
                    tags: filter,
                    after: page.LastId,
                    limit: 50,
                    order: ListRequestOrder.Asc);
            }

            #endregion
        }

        [Test]
        public async Task ErrorHandling()
        {
            TokenCredential credential = new DefaultAzureCredential();
            FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync("checkpoints/thread-abc", credential);

            #region Snippet:Core_Sample3_ErrorHandling

            try
            {
                await store.SetItemAsync(
                    "step-1",
                    new Dictionary<string, BinaryData> { ["done"] = BinaryData.FromObjectAsJson(true) },
                    ifMatch: "\"stale-etag\"");
            }
            catch (FoundryStoragePreconditionException ex)   // 412
            {
                Console.WriteLine($"Precondition failed; current etag is {ex.CurrentETag}");
            }
            catch (FoundryStorageConflictException ex)        // 409
            {
                Console.WriteLine($"Conflict on {ex.Param}");
            }
            catch (FoundryStorageBadRequestException ex)      // 400
            {
                Console.WriteLine($"Invalid request field: {ex.Param}");
            }
            catch (FoundryStorageNotFoundException)           // 404
            {
                Console.WriteLine("Store or item not found");
            }
            catch (FoundryStorageException ex)                // base type for all storage errors
            {
                Console.WriteLine($"Storage call failed with status {ex.Status}: {ex.Message}");
            }

            #endregion
        }
    }
}
