# Guide for migrating to the new Azure.AI.AgentServer package architecture

This guide helps you migrate from the earlier `Azure.AI.AgentServer.Core` (any version prior to 1.0.0-beta.21) and `Azure.AI.AgentServer.Contracts` packages to the new three-package architecture introduced in `Azure.AI.AgentServer.Core` 1.0.0-beta.21.

## Table of contents

- [Migration benefits](#migration-benefits)
- [Package changes](#package-changes)
- [API changes](#api-changes)
  - [Non-streaming handler](#non-streaming-handler)
  - [Streaming handler](#streaming-handler)
  - [Server startup](#server-startup)
- [Namespace changes](#namespace-changes)
- [Deprecation of Azure.AI.AgentServer.Contracts](#deprecation-of-azureaiagentservercontracts)
- [Additional information](#additional-information)

## Migration benefits

The new package architecture provides:

- **Separation of concerns** — protocol implementations (Responses API, Invocations) are in dedicated packages rather than bundled into a monolithic Core package.
- **Dramatically simpler API** — the old approach required manually constructing SSE events, tracking sequence numbers, and building response objects from raw model types. The new API provides a `ResponseHandler` base class with builder methods that handle all of this automatically.
- **Type-safe builder pattern** — `ResponseEventStream` and its child builders manage event sequencing, output indices, and content indices. You cannot accidentally emit events in the wrong order.
- **Built-in convenience methods** — common patterns like "emit a text message" or "stream tokens" are one-liners via `ResponseEventStream` convenience generators.
- **Zero-config startup** — `ResponsesServer.Run<T>()` or `InvocationsServer.Run<T>()` replaces `AgentServerApplication.RunAsync()` with sensible defaults including OpenTelemetry, health endpoints, and server version headers.
- **Multi-protocol support** — a single server can host both Responses and Invocations endpoints via `AgentHostBuilder`.

## Package changes

| Before | After | Notes |
|--------|-------|-------|
| `Azure.AI.AgentServer.Core` < 1.0.0-beta.21 | `Azure.AI.AgentServer.Core` 1.0.0-beta.21 | Stripped to hosting foundation only |
| `Azure.AI.AgentServer.Contracts` (any version) | _(removed)_ | Models are now built into `Azure.AI.AgentServer.Responses` |
| _(n/a)_ | `Azure.AI.AgentServer.Responses` 1.0.0-beta.1 | New — Responses API protocol |
| _(n/a)_ | `Azure.AI.AgentServer.Invocations` 1.0.0-beta.1 | New — Invocations protocol |

Update your package references:

```dotnetcli
# Remove the old packages
dotnet remove package Azure.AI.AgentServer.Contracts

# Install the new packages (Responses transitively brings in Core)
dotnet add package Azure.AI.AgentServer.Responses --prerelease

# If you also need the Invocations protocol:
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

> **Note:** `Azure.AI.AgentServer.Responses` and `Azure.AI.AgentServer.Invocations` both depend on `Azure.AI.AgentServer.Core`, so you do not need to install Core separately.

## API changes

### Non-streaming handler

**Before (prior to beta.21):**

```csharp
using Azure.AI.AgentServer.Contracts.Generated.OpenAI;
using Azure.AI.AgentServer.Contracts.Generated.Responses;
using Azure.AI.AgentServer.Responses.Invocation;

public class MyAgent : IAgentInvocation
{
    public Task<Response> InvokeAsync(
        CreateResponseRequest request,
        AgentInvocationContext context,
        CancellationToken cancellationToken = default)
    {
        // Manually extract input text from raw JSON
        var items = request.Input.ToObject<IList<ItemParam>>();
        var inputText = /* ... manual extraction ... */;

        // Manually construct content, output items, and response
        IList<ItemContent> contents = [new ItemContentOutputText(text: "Hello", annotations: [])];
        IList<ItemResource> outputs = [
            new ResponsesAssistantMessageItemResource(
                id: Guid.NewGuid().ToString(),
                status: ResponsesMessageItemResourceStatus.Completed,
                content: contents)
        ];
        return Task.FromResult(request.ToResponse(context: context, output: outputs));
    }
}
```

**After (beta.21):**

```csharp
using Azure.AI.AgentServer.Responses;

public class MyAgent : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        ResponseContext context,
        CreateResponse request,
        CancellationToken cancellationToken = default)
    {
        // Input text extraction is built-in
        string inputText = await context.GetInputTextAsync(cancellationToken: cancellationToken);

        // One-liner for a complete text message with all SSE events
        var stream = new ResponseEventStream(context, request);
        yield return stream.EmitCreated();
        await foreach (var e in stream.OutputItemMessage("Hello"))
            yield return e;
        yield return stream.EmitCompleted();
    }
}
```

Or, for the simplest case, use `TextResponse`:

```csharp
ResponsesServer.Run<TextResponse>(async context => "Hello!");
```

### Streaming handler

**Before (prior to beta.21):**

```csharp
public async IAsyncEnumerable<ResponseStreamEvent> InvokeStreamAsync(
    CreateResponseRequest request,
    AgentInvocationContext context,
    CancellationToken cancellationToken = default)
{
    var seq = -1;

    // Manually emit every SSE event, track sequence numbers, build model objects
    yield return new ResponseCreatedEvent(++seq, ToResponse(request, context, ResponseStatus.InProgress));

    var itemId = context.IdGenerator.GenerateMessageId();
    yield return new ResponseOutputItemAddedEvent(++seq, 0,
        new ResponsesAssistantMessageItemResource(id: itemId, ...));
    yield return new ResponseContentPartAddedEvent(++seq, itemId, 0, 0,
        new ItemContentOutputText(text: "", annotations: []));

    foreach (var token in tokens)
    {
        yield return new ResponseTextDeltaEvent(++seq, itemId, 0, 0, token);
    }

    yield return new ResponseTextDoneEvent(++seq, itemId, 0, 0, fullText);
    yield return new ResponseContentPartDoneEvent(++seq, itemId, 0, 0, content);
    yield return new ResponseOutputItemDoneEvent(++seq, 0, item);
    yield return new ResponseCompletedEvent(++seq, ToResponse(...));
}
```

**After (beta.21):**

```csharp
public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
    ResponseContext context,
    CreateResponse request,
    CancellationToken cancellationToken = default)
{
    var stream = new ResponseEventStream(context, request);
    yield return stream.EmitCreated();
    yield return stream.EmitInProgress();

    // Stream tokens — sequence numbers, indices, and all inner events are automatic
    await foreach (var e in stream.OutputItemMessage(GetTokens(cancellationToken), cancellationToken))
        yield return e;

    yield return stream.EmitCompleted();
}
```

### Server startup

**Before (prior to beta.21):**

```csharp
await AgentServerApplication.RunAsync(new ApplicationOptions(
    ConfigureServices: services => services.AddSingleton<IAgentInvocation, MyAgent>()
));
```

**After (beta.21):**

```csharp
// One-liner startup with built-in OpenTelemetry, health endpoint, and server version
ResponsesServer.Run<MyAgent>();
```

Or, for multi-protocol composition:

```csharp
var builder = AgentHost.CreateBuilder();
builder.AddResponses<MyResponseHandler>();
builder.AddInvocations<MyInvocationHandler>();
var app = builder.Build();
app.Run();
```

## Namespace changes

| Before | After |
|--------|-------|
| `Azure.AI.AgentServer.Contracts.Generated.OpenAI` | `Azure.AI.AgentServer.Responses` |
| `Azure.AI.AgentServer.Contracts.Generated.Responses` | `Azure.AI.AgentServer.Responses` |
| `Azure.AI.AgentServer.Core.Common.Http.Json` | _(no longer needed — serialization is built-in)_ |
| `Azure.AI.AgentServer.Core.Common.Id` | _(no longer needed — ID generation is automatic)_ |
| `Azure.AI.AgentServer.Responses.Invocation` | `Azure.AI.AgentServer.Responses` |

## Deprecation of Azure.AI.AgentServer.Contracts

The `Azure.AI.AgentServer.Contracts` package is deprecated and will not receive further updates. All model types that were previously in Contracts are now generated directly into `Azure.AI.AgentServer.Responses` from TypeSpec definitions.

To migrate: remove the `Azure.AI.AgentServer.Contracts` package reference and add `Azure.AI.AgentServer.Responses` instead. Update `using` directives as shown in the [namespace changes](#namespace-changes) table above.

## Additional information

- [Azure.AI.AgentServer.Core README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md)
- [Azure.AI.AgentServer.Responses README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/README.md)
- [Azure.AI.AgentServer.Invocations README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md)
- [Responses samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples)
- [Invocations samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples)
