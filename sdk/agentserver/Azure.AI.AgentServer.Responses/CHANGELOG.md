# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.4 (2026-04-22)

### Features Added

- Foundry storage logging now includes the `traceparent` header (W3C distributed trace ID) in all
  log messages, enabling correlation between SDK log entries and backend distributed traces.
- All endpoints now return the `x-request-id` response header for request correlation (via Core
  `RequestIdMiddleware`). Value is resolved from OTEL trace ID → incoming `x-request-id` header → GUID.
- Error responses (`ApiErrorResponse`) are automatically enriched with `error.additionalInfo.request_id`
  matching the `x-request-id` response header value, enabling client-side error correlation.
- Persistence failure resilience — when storage operations fail, responses now complete gracefully
  with `status: "failed"` and `error.code: "storage_error"` instead of crashing or leaving responses
  permanently stuck at `in_progress`. Covers all execution modes (streaming, background+streaming,
  background+non-streaming, synchronous). For streaming responses, terminal SSE events are buffered,
  persistence is attempted, and on failure the terminal event is replaced with `response.failed`
  carrying `error_code="storage_error"`. Synchronous persistence failures return HTTP 500 with the
  storage error details.

### Bugs Fixed

- Fixed `InvalidOperationException: Response was not set` crash in `FoundryStorageLoggingPolicy` when
  a transport-level failure (DNS resolution, connection refused, timeout) occurs before any HTTP
  response is received. These failures are now logged at `Error` level without triggering the
  logging crash, and the original transport exception continues to propagate.
- Fixed `GetInputExpanded` not normalizing string content shorthand on `ItemMessage`. When
  `content` is a plain JSON string (e.g., `"Hello"`), it is now auto-expanded to the canonical
  array form (`[{"type":"input_text","text":"Hello"}]`) so that `ItemMessage.Content` BinaryData
  is always consistent regardless of input format.

### Other Changes

- Removed `x-ms-request-id` from Foundry storage logging (unused service header).
- Migrated header name constants to use `PlatformHeaders` from Core package instead of
  local `private const` declarations.

## 1.0.0-beta.3 (2026-04-20)

### Features Added

- `previous_response_id` and `conversation.id` are now validated against the provider before
  the handler is invoked. Invalid references return HTTP 404/400 immediately instead of being
  silently ignored. The resolved history item IDs are cached — handlers calling
  `GetHistoryAsync()` reuse the prefetched result without a second storage lookup.

### Bugs Fixed

- Foundry storage error responses now preserve the full error body (`code`, `message`, `param`, `type`)
  when returned to the client. Previously only the `message` field was forwarded; `param` was lost.
- Non-400/404/409 error status codes from Foundry storage are no longer proxied as-is; they are
  normalized to HTTP 500 to avoid leaking upstream infrastructure details.

## 1.0.0-beta.2 (2026-04-17)

### Features Added

- Added chat isolation key enforcement across all endpoints. When a response is created with
  `x-agent-chat-isolation-key`, all subsequent GET, Cancel, DELETE, and InputItems calls must
  include the same key. Mismatched or missing keys return 404 (indistinguishable from not-found)
  to ensure tenant isolation.
- Added `x-agent-session-id` response header on all protocol endpoints (POST, GET, Cancel,
  Delete, InputItems). The resolved session ID is echoed as a response header per spec §8,
  with fallback to the `FOUNDRY_AGENT_SESSION_ID` environment variable for error responses.
- Added validation for malformed response IDs in both the `response_id` path parameter and the
  `previous_response_id` request body field. IDs that do not match the expected format (prefix
  and length) are rejected with 400 and a descriptive error message.
- Added metadata constraint validation: metadata maps are limited to 16 keys with key length ≤ 64
  and value length ≤ 512 characters, enforced via the validator pipeline.
- Added deterministic `agent_session_id` derivation: SHA-256 hash of
  `"{agent_name}:{agent_version}:{partition_hint}"` truncated to 63 lowercase hex chars.
  Falls back to random hex when no conversational context is available.
- Added eager eviction of completed `ResponseExecution` entries from the in-flight tracker,
  reducing memory pressure for long-running servers.
- Added `FoundryStorageLoggingPolicy` — an Azure.Core per-retry pipeline policy that logs every
  outbound Foundry storage API call with HTTP method, URI, status code, duration, and correlation
  headers (`x-ms-client-request-id`, `x-ms-request-id`, `x-request-id`, `apim-request-id`).
- Added structured `Information`-level logging to all Responses API endpoints (GET, Cancel, Delete,
  InputItems) with response ID context. The POST `/responses` creation log now includes response ID,
  conversation ID, previous response ID, and store flag for full request traceability.
- Added isolation key presence logging (`HasUserIsolationKey`, `HasChatIsolationKey`) to all
  endpoint handler logs and outbound Foundry storage request logs. Key values are never logged.
- Added startup configuration logging: storage provider type, default model, fetch history count,
  and event stream TTL are logged at `Information` level when the host starts.
- Added server version `User-Agent` header on all outbound Foundry storage API requests. The
  composed identity from `ServerVersionRegistry` (including developer-registered segments) is
  prepended to the standard Azure.Core user-agent, read lazily per-request.
- Added Foundry storage URL masking in diagnostic logs: everything before `/storage` is redacted
  and query parameters are stripped (except `api-version`) to prevent leaking account and project
  information.
- Added inbound request logging for Tier 1 and Tier 2 setups (via `ResponsesServer.Run()` or
  `AgentHost.CreateBuilder()`). All incoming HTTP requests are logged with method, path, status
  code, duration, and correlation headers (`x-request-id`, `x-ms-client-request-id`).

### Breaking Changes

- Made `ResponsesActivitySource` internal. The activity source is managed by
  the framework; handlers do not need to create tracing activities directly.
- Made `ResponsesTracingConstants` internal. The tracing tag, baggage, and log scope
  constants are implementation details not needed by handler authors.

### Bugs Fixed

- Fixed error response shapes to match the container specification: `invalid_request_error` type
  for 400 errors and `not_found` message format.
- Fixed cancel-after-terminal to return `invalid_request_error` type with the correct error shape
  per the specification.
- Fixed DELETE endpoint to return 404 (not 400) when the response ID does not exist, aligning
  with the specification.
- Fixed cancel-after-delete to return 404 (not-found) per the specification.

## 1.0.0-beta.1 (2026-04-14)

### Features Added

- Initial release of the Azure.AI.AgentServer.Responses library.
- ASP.NET Core server library implementing the Azure AI Responses API.
- `ResponseHandler` abstract class for custom response handling with `CreateAsync` returning `IAsyncEnumerable<ResponseStreamEvent>`.
- `TextResponse` convenience class for simple text-only responses with a single delegate.
- `ResponseEventStream` builder for full control over SSE event generation with automatic `sequenceNumber`, `outputIndex`, `contentIndex`, and `itemId` tracking.
- `ResponseEventStream` convenience generators for emitting complete output items in one call:
  - `OutputItemMessage(string text)` — emits a full text message output item (handles all inner SSE events automatically)
  - `OutputItemMessage(string text, IEnumerable<Annotation> annotations)` — emits a text message with file annotations
  - `OutputItemMessage(IAsyncEnumerable<string> tokens, CancellationToken)` — streams tokens as `response.output_text.delta` events
  - `OutputItemFunctionCall(name, callId, arguments)` — emits a complete function call output item
  - `OutputItemFunctionCallOutput(callId, output)` — emits a function call output (no deltas)
  - `OutputItemReasoningItem(...)` — emits a reasoning output item
  - `OutputItemImageGenCall(resultBase64)` — emits an image generation result with status transitions
  - `OutputItemStructuredOutputs(output)` — emits an arbitrary structured JSON output item
  - One-liner convenience generators for all remaining simple output item types: computer calls, local shell calls, function shell calls, apply-patch calls, custom tool call outputs, MCP approval requests/responses, and compaction
- `ResponseContext` with `GetInputItemsAsync()` (returns `IReadOnlyList<Item>`) and `GetInputTextAsync()` convenience for accessing resolved input items and text content.
- `IEnumerable<Item>.GetInputText()` extension method for extracting text from any sequence of input items.
- `CreateResponse.GetInputExpanded()` extension for advanced access to expanded input items as `OutputItem` types.
- Built-in in-memory response provider and execution tracking.
- Support for default, streaming, background, and streaming+background response modes.
- `AgentHostBuilder` convenience methods for zero-config server startup via `ResponsesServer.Run<T>()`.
- Protocol identity registration with `ServerVersionRegistry` during route mapping.
- `x-agent-response-id` header validation matching the Responses API specification.
- Conversation ID round-trip support in both synchronous and SSE streaming modes.
- OpenTelemetry distributed tracing via `Azure.AI.AgentServer.Responses` activity source.
