# Sample 3: Durable state store

`FoundryStateStore` is a durable, server-backed store for agent state. Each store holds items — keyed JSON values — that you read, write, and list by key. Use it to persist checkpoints, conversation state, counters, or any small state your agent needs to survive across requests and restarts.

> **Note:** State store operations require a Foundry storage endpoint and a token credential. When running as a hosted agent in Azure AI Foundry, the endpoint is resolved from the `FOUNDRY_PROJECT_ENDPOINT` environment variable and the credential is typically a managed identity.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Core --prerelease
dotnet add package Azure.Identity
```

## Overview

A `FoundryStateStore` is **bound to one caller-chosen store name**. That store name is the main scoping tool for your data:

- Use one store per conversation or thread when you need conversation isolation — encode the identity into the name, for example `checkpoints/thread-abc`.
- Set `userIsolation: true` when the store name is shared across many users and the platform should partition items per user.
- Set `itemTtlSeconds` once at store creation when you want idle items to age out automatically.

## Getting started

`GetOrCreateAsync` is the recommended entry point: it fetches the store, or creates it if it does not exist, in a single call — so you can read and write items right away.

```C# Snippet:Core_Sample3_GetOrCreate
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
```

## Typed models

Every request and response is a typed model, so you get IDE completion and compile-time checking. They live in the `Azure.AI.AgentServer.Core.Storage` namespace:

| Returned by | Model |
|---|---|
| `GetOrCreateAsync()`, `GetAsync()`, `UpdateAsync()` | `StateStore` |
| `DeleteAsync()` | `DeletedStateStore` |
| `CreateItemAsync()`, `SetItemAsync()` | `StateStoreItemRef` |
| `GetItemAsync(key)` | `StateStoreItem?` |
| `DeleteItemAsync(key)` | `DeletedStateStoreItem` |
| `ListKeysAsync()` | `StateStoreItemKeyPage` (of `StateStoreItemKey`) |

An item value is a dictionary of JSON fields (`IDictionary<string, BinaryData>`). Write it with `BinaryData.FromObjectAsJson(...)` and read it back with `BinaryData.ToObjectFromJson<T>()`; the service stores and returns the value as-is.

## Store name is scope

To scope data to a conversation or thread, encode it directly into the store name. Names may contain `/`, so you can use it as a hierarchy separator:

```csharp
await FoundryStateStore.GetOrCreateAsync("checkpoints/thread-abc", credential);
await FoundryStateStore.GetOrCreateAsync("workflow-state/run-42", credential);
await FoundryStateStore.GetOrCreateAsync("user-prefs/defaults", credential, userIsolation: true);
```

Because the store name is its identity, choose a stable naming scheme up front. There is no separate session-isolation knob.

## Store lifecycle

Store-level operations (`GetAsync`, `UpdateAsync`, `DeleteAsync`) act on the bound store itself; the `*Item` methods act on individual items within it.

```C# Snippet:Core_Sample3_StoreLifecycle
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
```

Key points:

- `GetOrCreateAsync` fetches the store first, or creates it when it is absent (falling back to a fetch if another caller created it in the meantime). It does **not** update `userIsolation`, `itemTtlSeconds`, `description`, or `tags` on a store that already exists — those are only applied on first creation.
- `UpdateAsync` only changes `Description` and `Tags`.
- `userIsolation` and `itemTtlSeconds` are fixed at create time.
- `DeleteAsync` cascades to every item under that store name.

## User isolation and delegated user IDs

Set `userIsolation: true` when the same store name should fan out per user:

```csharp
FoundryStateStore store = await FoundryStateStore.GetOrCreateAsync(
    "user-prefs/defaults",
    credential,
    userIsolation: true,
    userId: "aad-user-42");
```

- For direct callers, the platform derives user identity from the token.
- For trusted callers acting on behalf of an end user, pass `userId` so the client sends the delegated `x-ms-user-id` header on item operations.
- Store-management calls (`GetOrCreateAsync`, `GetAsync`, `UpdateAsync`, `DeleteAsync`) stay store-scoped and do not send the delegated user header.

## Single-item operations

`CreateItemAsync`, `SetItemAsync`, `GetItemAsync`, and `DeleteItemAsync` operate on individual items. `CreateItemAsync` fails with a `409` conflict when the key already exists; `SetItemAsync` creates the item, or replaces it if the key already exists; `GetItemAsync` returns `null` when the item is missing; deletes are idempotent.

```C# Snippet:Core_Sample3_Items
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
```

## Values, tags, and TTL

Each item value is a dictionary of JSON fields. Tags are simple string labels used only for filtering `ListKeysAsync`.

TTL is **store-level**, not per-item — set it once via `itemTtlSeconds` at store creation:

- Default: 30 days (`FoundryStateStore.DefaultItemTtlSeconds`).
- `-1`: never expire.
- Any item write renews the TTL window for that item; reads do **not** renew it.

## Optimistic concurrency

Use `ifMatch` for a guarded update or delete. When the etag no longer matches, the call throws `FoundryStoragePreconditionException`, whose `CurrentETag` reports the server's current value. Use `requireExists: true` for a strict update that only succeeds when the item already exists.

```C# Snippet:Core_Sample3_Concurrency
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
```

## Listing keys

`ListKeysAsync` returns a keys-only page within the bound store. Filter with `tags` (AND-matched), size the page with `limit` (1–100, default 20), page with the `after`/`before` cursors, and choose `ListRequestOrder.Desc` (default) or `ListRequestOrder.Asc`.

```C# Snippet:Core_Sample3_ListKeys
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
```

## Error handling

All storage errors derive from `FoundryStorageException` (itself an `Azure.RequestFailedException`, so `Status` and `ErrorCode` are available). Catch the specific subtypes for known failures and the base type for everything else.

| Exception | HTTP | Meaning |
|---|---|---|
| `FoundryStoragePreconditionException` | 412 | `If-Match` failed; `CurrentETag` may be populated. |
| `FoundryStorageNotFoundException` | 404 | Store or resource path not found. |
| `FoundryStorageConflictException` | 409 | A `CreateItemAsync` duplicated an existing key. |
| `FoundryStorageBadRequestException` | 400 | Invalid request; `Param` names the offending field. |
| `FoundryStorageApiException` | other 4xx/5xx | Server-side failure. |

```C# Snippet:Core_Sample3_ErrorHandling
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
```

## Best practices

1. **Prefer `GetOrCreateAsync`.** It is the only lifecycle call you need for the common case; do not assume item writes will create the store for you.
2. **Encode conversation scope in the store name.** There is no separate session-isolation knob.
3. **Use `userIsolation: true` only when needed.** Prefer a stable store naming scheme first, then add per-user partitioning when the store name is shared.
4. **Use `ifMatch` for read-modify-write flows.** Counters and checkpoints are race-prone without it.
5. **Keep values as JSON.** Serialize your own models explicitly with `BinaryData.FromObjectAsJson`.
