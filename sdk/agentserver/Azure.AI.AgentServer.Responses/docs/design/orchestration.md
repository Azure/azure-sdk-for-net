# Orchestration — .NET Implementation

> .NET-specific implementation details for request orchestration. For language-agnostic library behavioural rules, see [Library Behavioural Specification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md).

---

## Request Pipeline Overview

The `ResponseOrchestrator` class is the central coordination point for processing `POST /responses` requests. It implements the abstract pipeline defined in [S-001](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#request-processing-pipeline) using these .NET components:

```
HTTP Request → ResponseEndpointHandler → ResponseOrchestrator
  → PayloadValidator (S-002 enforcement)
  → IResponseHandler.HandleAsync()
  → ProcessEventsAsync() loop
  → IResponsesProvider persistence
  → IAsyncObserver<ResponseStreamEvent> publishing
  → SseWriter / JSON serialization
```

The orchestrator has three entry points corresponding to the three response modes ([S-003](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#request-processing-pipeline)):

| Mode | Entry Method | Return Type |
|------|-------------|-------------|
| Default (sync) | `ProcessDefaultAsync()` | `Response` JSON |
| Streaming | `ProcessStreamingAsync()` | `IAsyncEnumerable<ResponseStreamEvent>` |
| Background | `ProcessBackgroundAsync()` | Immediate `Response` + background `Task` |

---

## Event Processing Loop

`ProcessEventsAsync()` is the core `IAsyncEnumerable<ResponseStreamEvent>` that iterates handler-yielded events. For each event:

1. **First-event validation** — Checks FR-006, FR-007 (S-007, S-008, S-009)
2. **Output count validation** — Checks FR-008a (S-012)
3. **Mutation** — `ResponseMutations` applies auto-stamping, response replacement, output accumulation
4. **Snapshot** — `ModelReaderWriter` round-trip creates an immutable `Response` snapshot (S-011)
5. **Sequence number injection** — 0-based incrementing counter assigned (S-010)
6. **Publish** — Event pushed to `IAsyncObserver<ResponseStreamEvent>` for SSE and replay

The loop is shared across all three modes — the difference is in how the yielded events are consumed (written to SSE, collected for JSON, or published to replay).

---

## Handler Validation Rules

The orchestrator enforces the following rules during event processing, as defined in the [Library Behavioural Specification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#event-processing-rules):

| Rule | Library Rule | Check | .NET Enforcement |
|------|----------|-------|------------------|
| FR-006 | S-007 | First event must be `response.created` | `ProcessEventsAsync` checks first iteration |
| FR-006 | S-008 | `Response.Id` must match `ResponseContext.ResponseId` | Compared in first-event validation |
| FR-007 | S-009 | `Response.Status` must be non-terminal on `response.created` | `IsTerminalStatus()` check |
| FR-008a | S-012 | Output count must match tracked `output_item.added` events | `ResponseExecution.OutputItemCount` counter |
| FR-009 | S-021 | Handler must emit terminal event or throw | `FinalizeExecutionAsync` detects missing terminal |

All validation failures before `response.created` result in HTTP 500. Failures after `response.created` emit `response.failed`.

---

## Auto-Stamping Implementation

The `ResponseMutations` class implements [S-015](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#response-state-management) and [S-016](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#response-state-management):

- **`response_id`**: Set on every `OutputItem` to `ResponseExecution.ResponseId`. Handler-set values take precedence (checked via null/empty guard).
- **`agent_reference`**: Propagated from `CreateResponse.AgentReference` on the original request. Handler-set values take precedence.

Both are applied in the mutation phase of each event iteration, before snapshot creation.

---

## Response Replacement Mechanism

`ResponseMutations` implements [S-013](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#response-state-management) and [S-014](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#response-state-management):

- On any `response.*` event: `ResponseExecution.Response` is fully replaced with a deep clone of the event's embedded `Response`
- Between `response.*` events: `output_item.added`/`output_item.done` events accumulate on `ResponseExecution.Response.Output`
- After replacement, `AgentReference` is re-stamped (the sole library-managed property on `Response`)

---

## Snapshot Serialization

Implements [S-011](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#event-processing-rules) using `ModelReaderWriter`:

1. Serialize the `ResponseStreamEvent` to `BinaryData` via `ModelReaderWriter.Write()`
2. Deserialize back to a new `ResponseStreamEvent` via `ModelReaderWriter.Read()`
3. The round-trip produces an immutable copy — mutations to `ResponseExecution.Response` after this point do not affect the emitted event

Three snapshot points per event: pre-mutation original, post-mutation tracked response, and the serialized snapshot written to the stream.

---

## Sequence Number Injection

Implements [S-010](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#event-processing-rules):

- `ResponseExecution` maintains a `SequenceNumber` counter (0-based `int`)
- Each event processed by `ProcessEventsAsync` receives the current counter value
- Counter increments after assignment (post-increment)
- The `sequence_number` field is set on the serialized JSON payload before writing to the SSE stream

---

## Terminal Event Authority

Implements [S-018](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#terminal-event-authority) through [S-022](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#terminal-event-authority):

- **Cancellation path** (`CancelRequested` or `ClientDisconnected`): `EmitTerminalCancellationAsync()` clears output, sets `status: "cancelled"`, emits `response.failed`
- **Shutdown path** (`ShutdownRequested`): `EmitTerminalFailureAsync()` — handler may have chosen its own terminal state
- **Unknown OCE**: Treated as handler failure → `EmitTerminalFailureAsync()`
- **Non-OCE exception**: `EmitTerminalFailureAsync()` sets `status: "failed"`, emits `response.failed`

The classification uses `ResponseExecution` flags (`CancelRequested`, `ClientDisconnected`, `ShutdownRequested`) which are set by the corresponding `CancellationTokenSource` inspection.

---

## Missing Terminal Event Detection

Implements [S-021](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#terminal-event-authority):

- After `ProcessEventsAsync` completes (handler's `IAsyncEnumerable` is exhausted), `FinalizeExecutionAsync` checks if `ResponseExecution.Response.Status` is non-terminal
- If non-terminal: logs error with handler type name and request ID, calls `EmitTerminalFailureAsync()`
- Applies to both background and default (non-streaming) modes

---

## Cross-References

- [API Behaviour Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) — Observable outcomes of each mechanism
- [Error Handling](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md) — Exception paths and error classification
- [Provider Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) — When provider methods are called
