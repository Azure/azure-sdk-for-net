# Responses API — Protocol Specification

> **Parent document:** [container-image-spec.md](container-image-spec.md)
> — infrastructure requirements (networking, health, observability, shutdown,
> identity header) that apply to all protocols.

> **SDK available:** The `Azure.AI.AgentServer.Responses` package (currently
> .NET) implements the full protocol. If an SDK exists for your language,
> prefer it over a from-scratch implementation — it handles mode negotiation,
> event processing, error recovery, persistence, and correctness guarantees
> automatically.

> **Full API reference:**
> [Azure AI Foundry — Responses API](https://learn.microsoft.com/en-us/azure/foundry/reference/foundry-project#responses-94)

---

## Table of Contents

- [1. Endpoints](#1-endpoints)
- [2. Response Modes](#2-response-modes)
- [3. SSE Streaming](#3-sse-streaming)
- [4. Error Shapes](#4-error-shapes)
- [5. ID Generation](#5-id-generation)
- [6. JSON Serialization](#6-json-serialization)
- [7. Distributed Tracing](#7-distributed-tracing)
- [8. Checklist](#8-checklist)

---

## 1. Endpoints

| Method | Path | Summary |
|--------|------|---------|
| `POST` | `/responses` | Create a new response |
| `GET` | `/responses/{id}` | Retrieve response (JSON snapshot) |
| `GET` | `/responses/{id}?stream=true` | SSE event replay (background+streaming only) |
| `POST` | `/responses/{id}/cancel` | Cancel a background response |
| `DELETE` | `/responses/{id}` | Delete a stored response |
| `GET` | `/responses/{id}/input_items` | List input items (paginated) |

All routes support an optional configurable prefix (e.g., `/openai/v1`).

---

## 2. Response Modes

The `store`, `background`, and `stream` request flags combine to produce
8 behaviour modes:

| store | background | stream | Behaviour |
|-------|------------|--------|-----------|
| true | false | false | Synchronous — blocks, returns JSON. Retrievable via GET after completion. |
| true | false | true | Synchronous streaming — blocks, streams SSE. Retrievable via GET after completion. |
| true | true | false | Background poll — returns immediately, poll via GET. |
| true | true | true | Background streaming — returns immediately, streams SSE. Supports replay and cancel. |
| false | false | false | Ephemeral — blocks, returns JSON. NOT retrievable. |
| false | false | true | Ephemeral streaming — blocks, streams SSE. NOT retrievable. |
| false | true | * | **Rejected (HTTP 400)** — `background=true` requires `store=true`. |

> **Detailed mode matrix and behavioural rules:**
> [`responses-api-behaviour-contract.md`](responses-api-behaviour-contract.md)

---

## 3. SSE Streaming

Streaming responses use `text/event-stream; charset=utf-8` with these
headers: `Cache-Control: no-cache`, `Connection: keep-alive`,
`X-Accel-Buffering: no`.

Each event is written as:

```
event: {event_type}\ndata: {json_payload}\n\n
```

Key protocol points:
- 0-based, monotonically increasing `sequence_number` in each event payload
- Keep-alive via `: keep-alive\n\n` comment frames (opt-in)
- Exactly one terminal event per lifecycle (`response.completed`,
  `response.failed`, `response.incomplete`, or standalone `error`)
- No `[DONE]` sentinel

> **Full SSE event contract, event ordering, and terminal event guarantees:**
> [`responses-api-behaviour-contract.md` — SSE Event Contract](responses-api-behaviour-contract.md#sse-event-contract)

---

## 4. Error Shapes

HTTP errors use a standard envelope:

```json
{ "error": { "message": "...", "type": "...", "param": "...", "code": "..." } }
```

The `Response.error` field on a failed response uses a simpler shape
(`code` + `message` only). Internal exception details are never exposed.

> **Complete error taxonomy:**
> [`responses-api-behaviour-contract.md` — Error Shapes](responses-api-behaviour-contract.md#error-shapes)

---

## 5. ID Generation

Resource IDs use the format `{prefix}_{partitionKey}{entropy}` (50-char
body). The partition key (18 chars) is shared across related resources
within a request for storage co-location. Entropy (32 chars) is
cryptographically random.

The response prefix is `caresp`. Other prefixes (`msg`, `fc`, `rs`, `fs`,
`ws`, `ci`, `ig`, `mcp`, etc.) are used for sub-resources within a
response.

---

## 6. JSON Serialization

- Property naming: **snake_case**
- Null properties: **omit**
- Unknown request properties: **preserve** (round-trip)
- All paths (JSON responses, SSE `data:` lines) use the same serializer

---

## 7. Distributed Tracing

The `POST /responses` endpoint **MUST** emit a distributed trace span
following the
[OTel GenAI semantic conventions](https://opentelemetry.io/docs/specs/semconv/gen-ai/).
Read, cancel, delete, and health endpoints are **not** instrumented.

> The `Azure.AI.AgentServer.Responses` package (.NET) implements all
> tracing requirements below automatically.

### 7.1 Span Name

The span display name **MUST** follow the OTel GenAI convention:

```
{operation_name} {model}
```

| Pattern | Example |
|---------|---------|
| `create_response {Model}` | `create_response gpt-4o` |
| `create_response` | *(when model is empty or omitted)* |

### 7.2 Required Span Tags

Every `POST /responses` span **MUST** include the following tags.

#### Identity & GenAI Convention Tags

| Tag Key | Value | Required |
|---------|-------|----------|
| `service.name` | `"azure.ai.agentserver"` | Always |
| `gen_ai.system` | `"azure.ai.agentserver"` | Always |
| `gen_ai.provider.name` | `"AzureAI Hosted Agents"` | Always |
| `gen_ai.operation.name` | `"create_response"` | Always |
| `gen_ai.response.id` | `{ResponseId}` (e.g. `caresp_…`) | Always |
| `gen_ai.request.model` | Resolved model name | When non-empty |
| `gen_ai.conversation.id` | Conversation ID | When non-empty |
| `gen_ai.agent.id` | `"{Name}:{Version}"` or `""` (empty string when agent is null) | Always |
| `gen_ai.agent.name` | Agent name | When agent is present |
| `gen_ai.agent.version` | Agent version | When agent has a version |

#### Namespaced Tags

These tags carry response-level metadata for correlation and dashboards:

| Tag Key | Value | Required |
|---------|-------|----------|
| `azure.ai.agentserver.responses.response_id` | `{ResponseId}` | Always |
| `azure.ai.agentserver.responses.conversation_id` | `{ConversationId}` or `""` | Always |
| `azure.ai.agentserver.responses.streaming` | `true` / `false` (boolean) | Always |

#### Error Tags

When the handler throws an exception, the span **MUST** record:

| Tag Key | Value |
|---------|-------|
| `azure.ai.agentserver.responses.error.code` | Error code from the exception |
| `azure.ai.agentserver.responses.error.message` | Error message from the exception |

In addition, set the span status to `ERROR` and record an OTel exception
event per the
[OTel exception semantic conventions](https://opentelemetry.io/docs/specs/semconv/exceptions/).

### 7.3 Required Baggage Keys

Baggage **MUST** be set on the span **before** the handler is invoked
so that downstream code can read it from the current span context.

| Baggage Key | Value | Required |
|-------------|-------|----------|
| `azure.ai.agentserver.response_id` | `{ResponseId}` | Always |
| `azure.ai.agentserver.conversation_id` | `{ConversationId}` or `""` | Always |
| `azure.ai.agentserver.streaming` | `"True"` / `"False"` (PascalCase) | Always |
| `azure.ai.agentserver.x-request-id` | Value of `X-Request-Id` header (truncated to 256 chars) | When header is present |

> **Note:** Use whichever OTel baggage API your language provides
> (e.g., `Activity.AddBaggage()` in .NET, `set_attribute` on baggage
> in Python). The key requirement is that baggage is readable from
> the current span context during handler execution.

### 7.4 Structured Log Scope

Wrap handler execution in a structured logging scope with at least these
keys (e.g., `ILogger.BeginScope()` in .NET, `structlog.bind()` in Python,
`MDC.put()` in Java):

| Scope Key | Value |
|-----------|-------|
| `ResponseId` | `{ResponseId}` |
| `ConversationId` | `{ConversationId}` or `""` |
| `Streaming` | `true` / `false` |

This ensures every log line emitted during request processing includes
these fields without manual plumbing.

---

## 8. Checklist

> An SDK is available for .NET: `Azure.AI.AgentServer.Responses`.
> If an SDK exists for your language, it implements all of the below.

- [ ] Expose all 6 endpoints (§1)
- [ ] Support all response mode combinations (§2)
- [ ] SSE streaming with correct headers, sequence numbers, keep-alive (§3)
- [ ] Structured error envelopes (§4)
- [ ] Correct ID generation (`{prefix}_{partitionKey}{entropy}`) (§5)
- [ ] snake_case JSON serialization (§6)
- [ ] Distributed tracing span with GenAI semantic convention tags (§7)
- [ ] Required span tags: identity, namespaced, and error tags (§7.2)
- [ ] Required baggage keys set before handler invocation (§7.3)
- [ ] Structured log scope with `ResponseId`, `ConversationId`, `Streaming` (§7.4)
