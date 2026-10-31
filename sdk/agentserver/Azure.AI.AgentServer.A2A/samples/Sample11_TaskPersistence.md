# Sample 11: Task persistence

Persist native task snapshots and retrieve them after reconstructing the host.
Persistence stores task state and artifacts; it does not resume interrupted
agent execution.

## Prerequisites

Use `CreateCard` from [getting started](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample1_GettingStarted.md) and `TaskAgent`
from [tasks and artifacts](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.A2A/samples/Sample2_TasksAndArtifacts.md).
Import `A2A`, `Azure.AI.AgentServer.Core.Storage`, and
`Microsoft.Extensions.DependencyInjection`.

## Configure a local backing store

Outside Foundry hosting, Core uses its local file-backed state store. Use a
stable name and set the default item retention when creating it:

```C# Snippet:A2A_Sample11_LocalStore
public static async Task<FoundryTaskStore> CreateLocalStoreAsync(
    string name,
    CancellationToken cancellationToken = default)
{
    var backing = await FoundryStateStore.GetOrCreateAsync(
        name,
        itemTtlSeconds: 3600,
        cancellationToken: cancellationToken);
    return new FoundryTaskStore(backing);
}
```

## Run the task-producing agent

```C# Snippet:A2A_Sample11_LocalStart
using var store = await CreateLocalStoreAsync("echo/tasks");
var builder = AgentHost.CreateBuilder();
builder.Services.AddSingleton<ITaskStore>(store);
builder.AddA2A<TaskAgent>(CreateCard());
builder.Build().Run();
```

Send the Task sample's `SendMessage` request and keep its returned task ID.
Stop the server, restart it with the same store name and local state root,
then send `GetTask` for that ID. The completed Task and Echo artifact remain
available within their retention period.

The default local state root is `~/.agentserver`. Set `AGENTSERVER_STATE_ROOT`
before starting the process to use another directory. Local caller partitions
are not an authentication boundary.

## Supply a hosted credential and endpoint

For a Foundry-hosted application, pass the intended `Azure.Core.TokenCredential`
and project endpoint explicitly:

```C# Snippet:A2A_Sample11_HostedStore
public static FoundryTaskStore CreateHostedStore(
    TokenCredential credential,
    Uri projectEndpoint)
{
    return new FoundryTaskStore(
        "echo/tasks",
        credential: credential,
        endpoint: projectEndpoint,
        itemTtlSeconds: 3600);
}
```

Register the returned adapter as `ITaskStore` before building the host, using
the registration pattern above. Keep an application-owned adapter alive until
the host stops, then dispose it.

Hosted operations require usable request identity or brokered platform context,
and verify that the backing store enables server-side user isolation. Reads
must use the same caller scope as writes. Reusing a store without isolation
fails rather than silently changing its isolation settings.

The hosted configuration is compiled here; the automated reconstruction test
uses the local backend and does not claim a live hosted-storage round trip.

## Retention and lifecycle

- The one-hour retention applies when the backing store is created. Supplying
  another value does not update an existing store's descriptor.
- An in-memory `ITaskStore` does not persist snapshots across process restarts.
- Disposing `FoundryTaskStore` does not delete the backing store.
- A snapshot does not recover an interrupted executor or restore subscriptions.
- Task listing scans lightweight summaries before applying native filtering and
  pagination, then reads full snapshots for the selected page. Older records
  and records whose summary exceeds the storage tag limit require full reads
  during the scan. A page size bounds snapshot reads for records with summaries,
  not the number of listing-summary pages scanned.
- Long task IDs use bounded digest keys. The full original ID remains in the
  snapshot, and existing keys remain readable.
