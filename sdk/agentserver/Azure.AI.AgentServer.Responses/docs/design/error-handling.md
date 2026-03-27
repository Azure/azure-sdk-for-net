# Error Handling — .NET Implementation

> .NET-specific error handling implementation details. For language-agnostic error rules, see [Library Behavioural Specification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#error-handling-pipeline) (S-027–S-030) and [Cancellation Mechanism](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#cancellation-mechanism) (S-023–S-026).

---

## ResponsesExceptionFilter

`ResponsesExceptionFilter` is an ASP.NET Core `IExceptionFilter` registered in the middleware pipeline. It catches unhandled exceptions from endpoint handlers and delegates to `ApiErrorFactory` for error response generation.

**Placement**: Registered via `AddResponsesServer()` on `MvcOptions.Filters`. Runs after the endpoint handler but before the response is written.

**Behaviour**:

1. Catches the exception
2. Delegates to `ApiErrorFactory.CreateErrorResponse()` for HTTP status code and error envelope
3. Writes the JSON error envelope to the response
4. Marks the exception as handled (suppresses default ASP.NET error page)

---

## ApiErrorFactory

`ApiErrorFactory` is a static internal class that maps .NET exception types to the standard HTTP error envelope ([S-027](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#error-handling-pipeline)).

### Exception-to-Error Mapping

| .NET Exception Type | HTTP Status | `error.type` | `error.code` | Notes |
|---------------------|-------------|--------------|--------------|-------|
| `PayloadValidationException` | 400 | `invalid_request_error` | `null` | Includes `details[]` array ([S-031](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#validation-enforcement)) |
| `BadRequestException` | 400 | `invalid_request_error` | varies | `code` and `param` from exception properties |
| `ResourceNotFoundException` | 404 | `invalid_request_error` | `null` | Unknown response ID, `store=false` lookup |
| `ResponsesApiException` | from exception | from exception | from exception | Generic API exception with explicit error fields |
| `ResponseValidationException` | 500 | `server_error` | `null` | Details logged, not exposed ([S-033](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#validation-enforcement)) |
| Any other `Exception` | 500 | `server_error` | `null` | Generic "An internal error occurred." |

### ResponseError Population

When the orchestrator transitions a response to `status: "failed"`, `ApiErrorFactory` also populates the `ResponseError` field on the `Response` object ([S-029](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#error-handling-pipeline)). The `ResponseError` has only `code` and `message` — no `type` or `param`.

---

## OCE Classification Implementation

The `ResponseOrchestrator` classifies `OperationCanceledException` instances by inspecting `ResponseExecution` flags ([S-023](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#cancellation-mechanism)):

```
OperationCanceledException caught
  └─ execution.CancelRequested?  → Explicit cancel (S-019 path)
  └─ execution.ClientDisconnected? → Client disconnect (S-019 path)
  └─ execution.ShutdownRequested?  → Shutdown (S-025 path)
  └─ else → Unknown OCE (S-020 path — treated as handler error)
```

### CancellationTokenSource Inspection

The classification relies on three separate `CancellationTokenSource` instances managed by `ResponseExecution`:

| Source | Set By | Flag |
|--------|--------|------|
| Cancel CTS | `IResponsesProvider.CancelResponseAsync()` → `GetResponseCancellationTokenAsync()` | `CancelRequested` |
| HTTP context `RequestAborted` | ASP.NET Core transport layer | `ClientDisconnected` |
| `IHostApplicationLifetime.ApplicationStopping` | .NET host | `ShutdownRequested` |

These are linked into a combined `CancellationToken` passed to the handler via `ResponseContext`. When any source fires, the combined token is cancelled. The orchestrator then inspects which source fired to classify the OCE.

---

## Validation Exception Classes

### RequestPayloadValidationException → `PayloadValidationException`

- **Assembly**: `Azure.AI.AgentServer.Responses`
- **Visibility**: `public sealed` (extends `BadRequestException`)
- **Purpose**: Wraps request validation failures from `PayloadValidator`
- **Properties**: `Errors` — list of `ValidationError` (path + message)
- **API exposure**: Full `details[]` array in HTTP 400 response ([S-031](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#validation-enforcement))

### ResponseValidationException

- **Assembly**: `Azure.AI.AgentServer.Responses`
- **Visibility**: `internal sealed` (extends `Exception`)
- **Purpose**: Wraps handler output validation failures from builders
- **Properties**: `Errors` — list of `ValidationError` (path + message)
- **API exposure**: Details logged at `LogError` level, never exposed to API callers ([S-033](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#validation-enforcement))

The separation ensures request validation details help API callers fix their input, while response validation details remain internal (handler bugs should not leak implementation details to clients).

---

## Cross-References

- [Library Behavioural Specification — Error Handling Pipeline](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#error-handling-pipeline) — Abstract error classification rules (S-027–S-030)
- [Library Behavioural Specification — Cancellation Mechanism](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#cancellation-mechanism) — Abstract cancellation categories (S-023–S-026)
- [API Behaviour Contract — Error Shapes](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#error-shapes) — Error envelope format and known error types
- [Orchestration](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) — Where exceptions are caught and classified
