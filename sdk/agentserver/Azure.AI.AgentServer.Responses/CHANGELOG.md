# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of Azure.AI.AgentServer.Responses.
- ASP.NET Core server library implementing the Azure AI Responses API.
- `ResponseHandler` abstract class for custom response handling with `CreateAsync` returning `IAsyncEnumerable<ResponseStreamEvent>`.
- `TextResponse` convenience class for simple text-only responses with a single delegate.
- `ResponseEventStream` builder for full control over SSE event generation with automatic `sequenceNumber`, `outputIndex`, `contentIndex`, and `itemId` tracking.
- `ResponseEventStream` convenience generators for emitting complete output items in one call:
  - `OutputItemMessage(string text)` — emits a full text message output item (handles all inner SSE events automatically)
  - `OutputItemMessage(IAsyncEnumerable<string> tokens, CancellationToken)` — streams tokens as `response.output_text.delta` events
  - `OutputItemFunctionCall(name, callId, arguments)` — emits a complete function call output item
  - `OutputItemReasoningItem(...)` — emits a reasoning output item
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
