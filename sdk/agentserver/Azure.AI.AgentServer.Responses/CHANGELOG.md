# Release History

## 1.0.0-beta.2 (2026-05-05)

### Features Added

- Added chat isolation key enforcement across all endpoints. When a response is created with
  `x-agent-chat-isolation-key`, all subsequent GET, Cancel, DELETE, and InputItems calls must
  include the same key. Mismatched or missing keys return 404 (indistinguishable from not-found)
  to ensure tenant isolation.
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
- Protocol identity registration with `ServerUserAgentRegistry` during route mapping.
- `x-agent-response-id` header validation matching the Responses API specification.
- Conversation ID round-trip support in both synchronous and SSE streaming modes.
- OpenTelemetry distributed tracing via `Azure.AI.AgentServer.Responses` activity source.
