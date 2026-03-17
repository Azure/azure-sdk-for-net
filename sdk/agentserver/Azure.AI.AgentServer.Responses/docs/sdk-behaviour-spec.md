# SDK Behavioural Specification

> **Language-agnostic specification** defining what any conforming SDK implementation MUST do to correctly bridge handler logic to the API behaviour defined in [api-behaviour-contract.md](api-behaviour-contract.md). This document, together with the [API Behaviour Contract](api-behaviour-contract.md) and [Handler Implementation Guide](handler-implementation-guide.md), forms the **authoritative trio** — sufficient to generate a conforming SDK in any language without reading the .NET source code.

**Language-specific implementation details are NOT part of this spec.** For the .NET implementation, see [.NET Design Documentation](design/README.md).

---

## Table of Contents

- [Language Conventions](#language-conventions)
- [Request Processing Pipeline](#request-processing-pipeline)
- [Handler Contract](#handler-contract)
- [Event Processing Rules](#event-processing-rules)
- [Response State Management](#response-state-management)
- [Terminal Event Authority](#terminal-event-authority)
- [Cancellation Mechanism](#cancellation-mechanism)
- [Error Handling Pipeline](#error-handling-pipeline)
- [Validation Enforcement](#validation-enforcement)
- [Persistence Contract](#persistence-contract)
- [Configuration Requirements](#configuration-requirements)
- [Observability Requirements](#observability-requirements)
- [SDK Behavioural Rules Index](#sdk-behavioural-rules-index)

---

## Language Conventions

This specification uses abstract terminology to remain language-agnostic. The following terms apply throughout:

| Term | Meaning |
|------|---------|
| "the SDK" | Any conforming SDK implementation |
| "the handler" | The developer-provided request handler |
| "the provider" | The pluggable storage/persistence backend |
| "the request" | An incoming `POST /responses` HTTP request |
| "the response" | The `Response` object being constructed |
| "terminal event" | `response.completed`, `response.failed`, or `response.incomplete` |
| MUST | Absolute requirement for conformance |
| SHOULD | Recommended but not required for conformance |
| MAY | Optional behaviour |

---

## Request Processing Pipeline

- **S-001**: The SDK MUST process `POST /responses` through the following abstract pipeline: validate request → deserialize → invoke handler → process events → persist → respond. Each stage is a distinct responsibility; a conforming SDK MAY structure the code differently, but the logical ordering MUST be preserved.

- **S-002**: The SDK MUST validate request payloads against the API schema before invoking the handler. Invalid payloads MUST be rejected with HTTP 400 and a structured error response (see [B29](api-behaviour-contract.md#request-payload-validation-rule-b29)). The handler MUST NOT be invoked for invalid requests.

- **S-003**: The SDK MUST support three response modes, determined by the `stream` and `background` flags in the request:

  | Mode | `stream` | `background` | Behaviour |
  |------|----------|-------------|-----------|
  | **Default (synchronous)** | `false` | `false` | Block until handler completes; return `Response` JSON |
  | **Streaming** | `true` | `false` | Block; stream SSE events until handler completes |
  | **Background** | any | `true` | Return immediately; handler runs asynchronously |

  The handler MUST produce the same event sequence regardless of mode. Mode negotiation is the SDK's responsibility — the handler is mode-agnostic.

---

## Handler Contract

- **S-004**: The SDK MUST define a handler interface with a single method that accepts a request, a response context, and a cancellation signal, and produces an asynchronous stream of SSE events. The handler is the sole integration point for application logic.

- **S-005**: The SDK MUST provide the handler with:
  - The deserialized request object (model, input, tools, instructions, metadata, store/stream/background flags)
  - A unique response ID (format: `resp_*`)
  - A cancellation signal (triggered on explicit cancel, client disconnect, or host shutdown)
  - A facility for emitting SSE events (the event stream)

- **S-006**: The SDK SHOULD provide a builder pattern for constructing output items (text messages, function calls, tool calls, reasoning items) to reduce handler boilerplate and enforce correct event ordering. Builders SHOULD track lifecycle state (not started → added → done) and reject out-of-order emissions at development time.

---

## Event Processing Rules

The SDK validates and transforms handler-emitted events before writing them to the client. These rules ensure protocol conformance regardless of handler behaviour.

- **S-007**: The SDK MUST validate that the first event yielded by the handler is `response.created`. If it is not, the SDK MUST reject the handler output with HTTP 500, cancel the handler's execution, and skip persistence. See [B8](api-behaviour-contract.md#sse-event-contract).

- **S-008**: The SDK MUST validate that the `response.created` event contains a `Response.Id` matching the SDK-assigned response ID. Mismatches MUST be rejected with HTTP 500 and the handler cancelled (FR-006).

- **S-009**: The SDK MUST validate that the `response.created` event's `Response.Status` is non-terminal (`queued` or `in_progress`). A terminal status on the created event MUST be rejected with HTTP 500 (FR-007).

- **S-010**: The SDK MUST inject a 0-based, monotonically increasing `sequence_number` into every SSE event payload before writing it to the client. The first event (`response.created`) MUST have `sequence_number: 0`. See [B9](api-behaviour-contract.md#behavioural-rules-index).

- **S-011**: The SDK MUST create an immutable point-in-time snapshot of the `Response` for each SSE event. Events written to the stream MUST reflect the response state at emission time, not the current (possibly mutated) state. See [B23](api-behaviour-contract.md#behavioural-rules-index).

- **S-012**: The SDK MUST validate that output item counts match tracked `output_item.added` events (FR-008a). Direct manipulation of the output list (bypassing the event stream) MUST be detected and treated as a handler error — HTTP 500 if pre-creation, `response.failed` if post-creation.

---

## Response State Management

The SDK maintains a tracked `Response` object that evolves through the lifecycle. These rules govern how state is managed.

- **S-013**: Every `response.*` event (`response.created`, `response.queued`, `response.in_progress`, `response.completed`, `response.failed`, `response.incomplete`) MUST fully replace the SDK's tracked `Response` object with the event's embedded `Response` (deep clone/snapshot). The handler's event response is the single source of truth. See [B37](api-behaviour-contract.md#behavioural-rules-index).

- **S-014**: Output items from `output_item.added` and `output_item.done` events MUST accumulate on the tracked response between `response.*` events. When the next `response.*` event arrives, the accumulated list is replaced by the event's output list. Handlers MUST include desired output items in their terminal `response.*` event if they want them in the final result.

- **S-015**: The SDK MUST auto-stamp `response_id` on every output item to the current response ID. Handler-set values MUST take precedence. See [B20](api-behaviour-contract.md#behavioural-rules-index).

- **S-016**: The SDK MUST propagate `agent_reference` from the original request to all output items. Handler-set values MUST take precedence. This is the sole SDK-managed property on the `Response` object. See [B21](api-behaviour-contract.md#behavioural-rules-index).

- **S-017**: The SDK MUST validate that terminal event types match the `Response.Status` field. Mismatches (e.g., `response.completed` event with status != `completed`) MUST be treated as a handler error — the SDK MUST emit `response.failed` instead.

---

## Terminal Event Authority

The SDK guarantees exactly one terminal event per response lifecycle. The rules depend on whether the termination is caused by cancellation or non-cancellation errors.

- **S-018**: The SDK MUST guarantee exactly one terminal event (`response.completed`, `response.failed`, or `response.incomplete`) per response lifecycle. No response may end without a terminal event; no response may emit more than one.

- **S-019** *(Cancellation path)*: When cancellation is triggered (explicit cancel via `POST /responses/{id}/cancel` per [B11](api-behaviour-contract.md#behavioural-rules-index), or client disconnect per [B17](api-behaviour-contract.md#behavioural-rules-index)), the SDK is the **sole authority** on the terminal event. The SDK MUST:
  1. Signal the handler to stop (via the cancellation signal)
  2. Start a grace period timer (SHOULD be configurable, default 10 seconds — see S-042)
  3. Override any handler-emitted terminal event during the winddown (the handler cannot override the cancelled outcome)
  4. Clear output items (0 items in terminal response)
  5. Set status to `cancelled`
  6. Emit `response.failed` with `status: "cancelled"` as the terminal SSE event

  If the handler has already completed before cancellation is triggered, the cancel request MUST be rejected (see [B12](api-behaviour-contract.md#behavioural-rules-index)).

- **S-020** *(Non-cancellation error path)*: Throwing an exception is a valid way for the handler to terminate. If the handler throws a non-cancellation error and has NOT already emitted a terminal event (status is still `in_progress`), the SDK MUST:
  1. Classify the exception against the SDK's known exception types (bad request, not found, validation — see S-028)
  2. Map recognised exceptions to the corresponding HTTP status code and structured error fields (`code`, `message`)
  3. For unrecognised exceptions, use HTTP 500 with `code: "server_error"` and a generic message — actual exception details MUST be logged but MUST NOT be exposed to the caller
  4. Set `status: "failed"`, populate `ResponseError`, and emit `response.failed`

  If the handler HAS already emitted a terminal event, the SDK MUST respect the handler's terminal status.

- **S-021**: If the handler's asynchronous event stream completes **without** emitting a terminal event **and without** throwing an exception, and the response status is non-terminal, the SDK MUST treat this as a handler programming error — log a diagnostic message (handler identifier, request ID), set `status: "failed"`, and emit `response.failed`. A conforming handler MUST either emit a terminal event or throw an exception; silently completing the stream is never valid. See [B32](api-behaviour-contract.md#behavioural-rules-index).

- **S-022**: The SDK MUST NOT emit `response.incomplete`. The `incomplete` status is handler-driven only — the handler must explicitly yield `response.incomplete`. The SDK's error-handling paths MUST never produce `incomplete`. This ensures `incomplete` always represents a deliberate handler decision (e.g., max output tokens reached), not an SDK-level failure.

---

## Cancellation Mechanism

The SDK classifies cancellation signals by source and applies different winddown strategies.

- **S-023**: The SDK MUST classify cancellation exceptions into four categories:

  | Category | Trigger | Source |
  |----------|---------|--------|
  | **Explicit cancel** | `POST /responses/{id}/cancel` | API endpoint ([B11](api-behaviour-contract.md#behavioural-rules-index)) |
  | **Client disconnect** | Connection terminated during non-background request | Transport layer ([B17](api-behaviour-contract.md#behavioural-rules-index)) |
  | **Shutdown** | Host application shutting down | Runtime signal ([B24](api-behaviour-contract.md#behavioural-rules-index)) |
  | **Unknown** | Cancellation exception not matching any known source | Handler or runtime |

- **S-024**: Explicit cancel and client disconnect MUST follow the cancellation winddown path (S-019). Unknown cancellation exceptions MUST be treated as handler errors (S-020 — non-cancellation error path).

- **S-025**: Shutdown cancellation SHOULD allow the handler to choose its own terminal state if it checks the shutdown signal. If the handler does not emit a terminal event before the cancellation signal fires, the SDK MUST emit `response.failed`. The SDK itself MUST NOT emit `response.incomplete` for shutdown (see S-022).

- **S-026**: Background responses (`background=true`) MUST NOT be cancelled by client disconnect ([B18](api-behaviour-contract.md#behavioural-rules-index)). Only explicit cancel via the cancel endpoint is honoured for background responses. Client disconnect during a background streaming connection simply closes the SSE stream without affecting the handler's execution.

---

## Error Handling Pipeline

The SDK maps handler errors and internal failures to standardised HTTP error responses and response error fields.

- **S-027**: The SDK MUST map all errors to the standard HTTP error envelope: `{ error: { message, type, param, code } }`. This envelope is used for HTTP 4xx and 5xx error responses.

- **S-028**: The SDK MUST classify errors and map them to HTTP status codes:

  | Error Category | HTTP Status | `error.type` | `error.code` |
  |----------------|-------------|--------------|--------------|
  | Bad request (validation, malformed) | 400 | `invalid_request_error` | varies |
  | Not found (unknown ID, `store=false`) | 404 | `invalid_request_error` | `null` |
  | Handler error (unhandled exception) | 500 | `server_error` | `null` |
  | Client disconnect | 499 | *(no body)* | *(no body)* |

  See [Error Shapes](api-behaviour-contract.md#error-shapes) for the complete error catalogue.

- **S-029**: The SDK MUST populate `ResponseError` (code + message) on the `Response` object when `status: "failed"`. The `ResponseError` shape has only `code` and `message` — it differs from the HTTP error envelope (which also has `type` and `param`).

- **S-030**: Validation error details (field paths, specific violations) from response validation (S-032) MUST be logged but MUST NOT be exposed in the API response. Request validation details (S-031) ARE exposed in the `details[]` array per [B29](api-behaviour-contract.md#behavioural-rules-index).

---

## Validation Enforcement

The SDK validates both incoming requests and handler-produced output.

- **S-031**: The SDK MUST validate incoming request payloads against the API schema before invoking the handler. Failures MUST return HTTP 400 with a `details[]` array of individual validation errors. Each detail MUST include `type`, `code`, `param` (field path), and `message`. See [B29](api-behaviour-contract.md#behavioural-rules-index).

- **S-032**: The SDK MUST validate handler-produced output at construction time. Invalid output (e.g., zero content parts in a text message) MUST be treated as a handler error: HTTP 500 (non-streaming) or `response.failed` (streaming). See [B30](api-behaviour-contract.md#behavioural-rules-index).

- **S-033**: Validation error details for response validation MUST be logged at error level but MUST NOT be exposed to API callers. This separates observability (logs) from the API surface (error responses). Request validation details ARE exposed per S-031.

---

## Persistence Contract

The SDK delegates state persistence to a pluggable provider interface.

- **S-034**: The SDK MUST delegate state persistence to a pluggable provider interface. The abstract provider MUST support the following operations:

  | Operation | Purpose |
  |-----------|---------|
  | Create response record | Persist the initial response state |
  | Update response record | Persist the terminal response state |
  | Retrieve response by ID | Support `GET /responses/{id}` |
  | Manage cancellation signal per response | Support `POST /responses/{id}/cancel` |
  | Provide event stream observer | Support SSE replay via `GET /responses/{id}?stream=true` |

- **S-035**: Persistence timing MUST follow the handler-driven model — no response is persisted before the handler yields `response.created`:

  | Mode | Create | Update |
  |------|--------|--------|
  | `background=true` | At `response.created` event | At terminal state (SDK-guaranteed, MUST run even on error) |
  | `background=false` | At terminal state only (single create) | N/A |

  See [B36](api-behaviour-contract.md#behavioural-rules-index).

- **S-036**: Non-background cancelled/disconnected responses MUST be ephemeral (not persisted). Only background responses that have already been created are updated on cancellation.

- **S-037**: The SDK MUST provide a default in-memory provider implementation. This enables zero-configuration usage for development and testing.

- **S-038**: The default provider MUST support TTL-based eviction of event stream replay buffers (default: 10 minutes). Response data (envelopes, items, history, conversation membership) is retained indefinitely. After event stream eviction, SSE replay (`?stream=true`) fails but JSON GET still works. See [B35](api-behaviour-contract.md#behavioural-rules-index).

---

## Configuration Requirements

The SDK MUST support the following configuration options.

- **S-039**: The SDK MUST support model resolution with fallback: `request.model → default_model → ""`. The resolved model MUST be propagated to the `Response.Model` field. See [B22](api-behaviour-contract.md#behavioural-rules-index).

- **S-040**: The SDK MUST support configurable SSE keep-alive interval (default: disabled). When enabled, the SDK MUST send periodic keep-alive comments (`: keep-alive\n\n`) during SSE streaming to prevent proxy/load-balancer timeouts. See [B28](api-behaviour-contract.md#behavioural-rules-index).

- **S-041**: The SDK MUST include an identity header on all responses: `x-platform-server: {sdk_name}/{version} ({language}/{runtime})`. The header value MUST support composable append via `; ` separator. See [B19](api-behaviour-contract.md#behavioural-rules-index).

- **S-042**: The SDK SHOULD support configurable cancel winddown grace period (default: 10 seconds).

- **S-046**: The SDK MUST expose a configurable `AdditionalServerIdentity` option (default: `null`). When set, the SDK MUST append the value to the `x-platform-server` header using a `; ` separator (e.g., `azure-ai-responses-server-sdk/0.1.0-preview (dotnet/8.0); my-app/1.0`). See S-041, [B19](api-behaviour-contract.md#behavioural-rules-index).

---

## Observability Requirements

The SDK MUST instrument request processing for distributed tracing.

- **S-043**: The SDK MUST expose a named trace source for distributed tracing integration. The trace source name SHOULD be stable across versions.

- **S-044**: The SDK MUST create a span for each `POST /responses` request with the following tags:

  | Tag | Value |
  |-----|-------|
  | `response.id` | The SDK-assigned response ID |
  | `response.mode` | The combination of `stream` and `background` flags |
  | `response.model` | The resolved model name |
  | `response.status` | The terminal status (set in finalization path, always reflects final state) |

  See [B34](api-behaviour-contract.md#behavioural-rules-index).

- **S-045**: The SDK MUST NOT create spans for GET or cancel endpoints. Only `POST /responses` (create) is instrumented.

---

## SDK Behavioural Rules Index

Quick-reference index of all S-rules:

| # | Section | One-Liner |
|---|---------|-----------|
| S-001 | Request Processing Pipeline | `POST /responses` pipeline: validate → deserialize → invoke handler → process events → persist → respond |
| S-002 | Request Processing Pipeline | Validate request payload against API schema before invoking handler; invalid → HTTP 400 |
| S-003 | Request Processing Pipeline | Three response modes: default (synchronous), streaming (SSE), background (async) |
| S-004 | Handler Contract | Single handler method: request + context + cancellation signal → async event stream |
| S-005 | Handler Contract | Handler receives: deserialized request, response ID, cancellation signal, event stream |
| S-006 | Handler Contract | Builder pattern SHOULD be provided for output item construction |
| S-007 | Event Processing Rules | First event MUST be `response.created`; otherwise HTTP 500 and handler cancelled |
| S-008 | Event Processing Rules | `response.created` response ID MUST match SDK-assigned ID |
| S-009 | Event Processing Rules | `response.created` status MUST be non-terminal (`queued` or `in_progress`) |
| S-010 | Event Processing Rules | 0-based monotonically increasing `sequence_number` injected into every SSE event |
| S-011 | Event Processing Rules | Immutable point-in-time snapshot of `Response` created for each SSE event |
| S-012 | Event Processing Rules | Output item count MUST match tracked `output_item.added` events |
| S-013 | Response State Management | Every `response.*` event fully replaces the tracked `Response` object |
| S-014 | Response State Management | Output items accumulate between `response.*` events; replaced on next `response.*` |
| S-015 | Response State Management | Auto-stamp `response_id` on every output item; handler-set values take precedence |
| S-016 | Response State Management | Propagate `agent_reference` from request to all output items; handler-set values take precedence |
| S-017 | Response State Management | Terminal event type MUST match `Response.Status`; mismatch → `response.failed` |
| S-018 | Terminal Event Authority | Exactly one terminal event per response lifecycle guaranteed |
| S-019 | Terminal Event Authority | Cancellation path: SDK is sole authority — winddown, clear output, status cancelled, emit `response.failed` |
| S-020 | Terminal Event Authority | Handler exception: SDK classifies against known types, maps to structured error, emits `response.failed` |
| S-021 | Terminal Event Authority | Silent completion (no terminal event, no exception): SDK auto-fails with diagnostic log (B32) |
| S-022 | Terminal Event Authority | SDK MUST NOT emit `response.incomplete` — `incomplete` is handler-driven only |
| S-023 | Cancellation Mechanism | Four cancellation categories: explicit cancel, client disconnect, shutdown, unknown |
| S-024 | Cancellation Mechanism | Explicit cancel + disconnect → winddown (S-019); unknown → handler error (S-020) |
| S-025 | Cancellation Mechanism | Shutdown: handler may choose terminal state; otherwise SDK emits `response.failed` |
| S-026 | Cancellation Mechanism | Background responses immune to client disconnect; only explicit cancel honoured |
| S-027 | Error Handling Pipeline | Map all errors to standard HTTP error envelope: `{ error: { message, type, param, code } }` |
| S-028 | Error Handling Pipeline | Error classification: 400 (bad request), 404 (not found), 500 (handler error), 499 (disconnect) |
| S-029 | Error Handling Pipeline | `ResponseError` (code + message) on `Response` object when `status: "failed"` |
| S-030 | Error Handling Pipeline | Response validation details logged but not exposed; request validation details exposed |
| S-031 | Validation Enforcement | Validate request payloads before handler; invalid → HTTP 400 with `details[]` |
| S-032 | Validation Enforcement | Validate handler-produced output at construction; invalid → HTTP 500 or `response.failed` |
| S-033 | Validation Enforcement | Response validation error details logged, not exposed to callers |
| S-034 | Persistence Contract | Pluggable provider: create, update, retrieve, cancellation signal, event stream observer |
| S-035 | Persistence Contract | Handler-driven persistence: background creates at `response.created`, non-background at terminal |
| S-036 | Persistence Contract | Non-background cancelled/disconnected responses are ephemeral (not persisted) |
| S-037 | Persistence Contract | Default in-memory provider implementation MUST be provided |
| S-038 | Persistence Contract | TTL-based eviction with independently configurable response and event stream TTLs |
| S-039 | Configuration Requirements | Model resolution fallback: `request.model → default_model → ""` |
| S-040 | Configuration Requirements | Configurable SSE keep-alive interval (default: disabled) |
| S-041 | Configuration Requirements | Identity header: `x-platform-server: {sdk_name}/{version} ({language}/{runtime})` |
| S-042 | Configuration Requirements | Configurable cancel winddown grace period (default: 10 seconds) |
| S-043 | Observability Requirements | Named trace source for distributed tracing integration |
| S-044 | Observability Requirements | Span per `POST /responses` with tags: `response.id`, `response.mode`, `response.model`, `response.status` |
| S-045 | Observability Requirements | No spans for GET or cancel endpoints |
| S-046 | Configuration Requirements | Configurable `AdditionalServerIdentity` appended to `x-platform-server` header |
