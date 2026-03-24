# Provider Contract — .NET Implementation

> .NET-specific `IResponsesProvider` interface and `InMemoryResponsesProvider` implementation details. For language-agnostic persistence rules, see [Library Behavioural Specification — Persistence Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract) (S-034–S-038).

---

## IResponsesProvider Interface

`IResponsesProvider`, `IResponsesCancellationSignalProvider`, and `IResponsesStreamProvider` are the three pluggable provider interfaces that the library delegates state persistence, cancellation signalling, and event streaming to ([S-034](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract)).

The provider contract is split into three focused interfaces. `IResponsesProvider` handles state persistence:

| Method | Signature | Purpose |
|--------|-----------|---------|
| `CreateResponseAsync` | `Task CreateResponseAsync(Response, IEnumerable<OutputItem>?, IEnumerable<string>?, CancellationToken)` | Persist initial response state with input items and history IDs |
| `GetResponseAsync` | `Task<Response> GetResponseAsync(string id, CancellationToken)` | Retrieve current response state; throws `ResourceNotFoundException` if not found |
| `UpdateResponseAsync` | `Task UpdateResponseAsync(Response, CancellationToken)` | Persist updated response state after mutations |
| `DeleteResponseAsync` | `Task DeleteResponseAsync(string id, CancellationToken)` | Delete a response; throws `ResourceNotFoundException` if not found |
| `GetInputItemsAsync` | `Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string id, int, bool, string?, string?, CancellationToken)` | Retrieve paginated input items for a response |
| `GetItemsAsync` | `Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string>, CancellationToken)` | Batch lookup output items by ID |
| `GetHistoryItemIdsAsync` | `Task<IEnumerable<string>> GetHistoryItemIdsAsync(string?, string?, int, CancellationToken)` | Retrieve history item IDs for a conversation chain |

`IResponsesCancellationSignalProvider` handles cancellation coordination:

| Method | Signature | Purpose |
|--------|-----------|---------|
| `CancelResponseAsync` | `Task CancelResponseAsync(string id, CancellationToken)` | Signal cancellation (fire-and-forget) |
| `GetResponseCancellationTokenAsync` | `Task<CancellationToken> GetResponseCancellationTokenAsync(string id, CancellationToken)` | Return a token that fires when cancel is requested |

`IResponsesStreamProvider` handles SSE event streaming:

| Method | Signature | Purpose |
|--------|-----------|---------|
| `CreateEventPublisherAsync` | `Task<IAsyncObserver<ResponseStreamEvent>> CreateEventPublisherAsync(string id, CancellationToken)` | Return an observer for pushing events |
| `SubscribeToEventsAsync` | `Task<IAsyncDisposable> SubscribeToEventsAsync(string id, IAsyncObserver<ResponseStreamEvent>, int?, CancellationToken)` | Subscribe to events with optional cursor-based resume |

**Registration**: Consumers register a custom implementation before `AddResponsesServer()` — the library uses `TryAddSingleton`, so a pre-registered implementation takes precedence over the default.

```csharp
// Register custom provider before AddResponsesServer — TryAddSingleton skips the default
builder.Services.AddSingleton<IResponsesProvider, MyRedisResponsesProvider>();
builder.Services.AddResponsesServer();
```

---

## IAsyncObserver Event Streaming

Event streaming uses a custom `IAsyncObserver<ResponseStreamEvent>` interface defined in the library (see `IAsyncObserver.cs`):

| Method | Purpose |
|--------|---------|
| `OnNextAsync(ResponseStreamEvent)` | Push a single event to subscribers |
| `OnCompletedAsync()` | Signal that the event stream is complete |
| `OnErrorAsync(Exception)` | Signal an error on the event stream |

The `InMemoryResponsesProvider` uses a `SeekableReplaySubject<ResponseStreamEvent>` which buffers events and supports cursor-based replay for SSE reconnection ([B4](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#behavioural-rules-index)).

---

## InMemoryResponsesProvider

The default in-memory provider implementation ([S-037](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract)):

- **Thread-safety**: Uses `ConcurrentDictionary` for response storage
- **Cancellation**: Per-response `CancellationTokenSource` stored alongside responses
- **Event streaming**: `SeekableReplaySubject` per response for buffering and replay

### TTL Eviction

Implements [S-038](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract) with a periodic timer:

- **Completion tracking**: Records `DateTimeOffset` when a response reaches any terminal status (`completed`, `failed`, `incomplete`, `cancelled`)
- **Timer interval**: `max(min(eventStreamTtl / 4, 30s), 1s)` — based on `EventStreamTtl`
- **Event stream eviction**: Removes `SeekableReplaySubject` and `CancellationTokenSource` after `EventStreamTtl` elapses (SSE replay becomes unavailable, but JSON GET still works)
- **Response retention**: Response data (envelopes, items, history, conversation membership) is retained indefinitely

### Eviction Effects

| After | Observable Effect |
|-------|-------------------|
| Event stream eviction | JSON GET still works; SSE replay (`?stream=true`) fails |

---

## InMemoryProviderOptions

Configuration for the default in-memory provider:

| Property | Type | Default | Description |
|----------|------|---------|-------------|
| `EventStreamTtl` | `TimeSpan` | 10 minutes | Per-event SSE replay buffer retention. Each event is available for replay for this duration from when it was emitted |

```csharp
services.Configure<InMemoryProviderOptions>(opts =>
{
    opts.EventStreamTtl = TimeSpan.FromMinutes(5);  // SSE replay buffers
});
```

Custom `IResponsesProvider` implementations manage their own retention and eviction strategy — `InMemoryProviderOptions` only affects the built-in in-memory provider.

---

## Persistence Timing Implementation

Implements [S-035](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract):

| Mode | When `CreateResponseAsync` is called | When `UpdateResponseAsync` is called |
|------|--------------------------------------|--------------------------------------|
| `background=true` | In `ProcessEventsAsync` after first `response.created` event | In `FinalizeExecutionAsync` (`finally` block — guaranteed) |
| `background=false` | In `FinalizeExecutionAsync` (single create at terminal state) | N/A |

The `FinalizeExecutionAsync` method runs in a `finally` block, ensuring persistence even when exceptions occur. Non-background cancelled/disconnected responses are ephemeral — `CreateResponseAsync` is never called ([S-036](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract)).

---

## CancellationTokenSource Management

Per-response cancellation management:

1. **Creation**: A `CancellationTokenSource` (CTS) is created for each response via `GetResponseCancellationTokenAsync`
2. **Linking**: The response CTS is linked to the handler's combined `CancellationToken` (which also includes HTTP abort and shutdown tokens)
3. **Signalling**: `CancelResponseAsync` fires the response CTS, which cascades to the linked handler token
4. **Cleanup**: CTS is disposed in `FinalizeExecutionAsync` after the cancel winddown completes
5. **Eviction**: CTS reference is removed during TTL eviction

---

## Cross-References

- [Library Behavioural Specification — Persistence Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract) — Abstract persistence rules (S-034–S-038)
- [API Behaviour Contract — Event Stream Replay Availability](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#event-stream-replay-availability-rule-b35) — Observable eviction effects (B35)
- [API Behaviour Contract — Response Persistence Timing](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#handler-driven-persistence-rule-b36) — Observable persistence behaviour (B36)
- [Orchestration](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) — When provider methods are called in the pipeline
