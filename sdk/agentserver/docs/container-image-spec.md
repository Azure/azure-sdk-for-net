# Agent Server Container / Image Specification

> **Purpose:** This document describes the infrastructure and protocol
> requirements for an Azure AI Agent Server container image. It is organised
> into **protocol-agnostic infrastructure** (§1–§5) and **protocol-specific
> sections** (§6+). Today the only protocol is the **Responses API**
> (§6). Future protocols — A1A, Activity Protocol, Invocations, etc. — will
> be added as new top-level sections following the same structure.

---

## Table of Contents

- [Part I — Infrastructure (Protocol-Agnostic)](#part-i--infrastructure-protocol-agnostic)
  - [1. Network & Transport](#1-network--transport)
  - [2. Health Probes](#2-health-probes)
  - [3. Observability](#3-observability)
  - [4. Graceful Shutdown](#4-graceful-shutdown)
  - [5. Server Identity Header](#5-server-identity-header)
- [Part II — Protocols](#part-ii--protocols)
  - [6. Responses API Protocol](#6-responses-api-protocol)
- [Part III — Checklist](#part-iii--checklist)
  - [7. Container Image Checklist](#7-container-image-checklist)

---

# Part I — Infrastructure (Protocol-Agnostic)

These requirements apply to the container regardless of which protocol(s)
it exposes.

---

## 1. Network & Transport

| Property | Value |
|----------|-------|
| **Protocol** | HTTP/1.1 |
| **Default port** | `8088` (overridable via `DEFAULT_AD_PORT`) |
| **Bind address** | `0.0.0.0` (all interfaces) |

The container **MUST** listen on the configured port over plain HTTP/1.1.
TLS termination is handled by the hosting infrastructure (reverse proxy /
sidecar). The port is configured via `DEFAULT_AD_PORT` (§3.3).

### SSE Keep-Alive (Recommended)

Protocols that return Server-Sent Event (SSE) streams **SHOULD**
support periodic keep-alive comment frames (`: keep-alive\n\n`) to prevent
proxy and load-balancer idle-timeout disconnections. The interval is
configured via the `SSE_KEEPALIVE_INTERVAL` environment variable
(value in seconds). When the variable is absent or zero, keep-alive is
disabled. Programmatic configuration (if supported by the SDK) takes
precedence over the environment variable.

---

## 2. Health Probes

| Endpoint | Purpose | Expected Response |
|----------|---------|-------------------|
| `GET /liveness` | Kubernetes liveness probe | `200 OK` |
| `GET /readiness` | Kubernetes readiness probe | `200 OK` |

Return `200` with an empty or minimal body when the process is alive and
ready. Return a non-`200` status to signal the orchestrator should restart
or stop routing to this instance.

---

## 3. Observability

This section covers the shared observability infrastructure.
Protocol-specific trace spans and tags are defined within each protocol
module (e.g., §6.7 for the Responses API).

### 3.1 Log Levels

The container **MUST** read the `AGENT_LOG_LEVEL` variable (§3.3) and
map it to the logging framework's level. Valid values: `Trace`, `Debug`,
`Information`, `Warning`, `Error`, `Critical`. Default: `Information`.

### 3.2 Exporter Configuration

The container supports two telemetry exporters. Both can be active
simultaneously; if neither is configured, telemetry is silently disabled.

**Azure Monitor / Application Insights** — exports traces, metrics, and
logs to Azure Application Insights via the Azure Monitor OpenTelemetry
exporter. Enabled by default (`AGENT_APP_INSIGHTS_ENABLED=true`). Requires
a connection string, which can be set explicitly via
`APPLICATIONINSIGHTS_CONNECTION_STRING` or auto-discovered from the Foundry
project (§3.4).

**OTLP (OpenTelemetry Protocol)** — exports traces, metrics, and logs to
an OTLP-compatible collector. Set `OTEL_EXPORTER_ENDPOINT` to the collector's endpoint
(e.g., `http://localhost:4317`).
When the endpoint is empty, the OTLP exporter is not registered.

All exporter variables are listed in the consolidated table at §3.3.

### 3.3 Platform Environment Variables

The Azure AI Foundry platform injects the following environment variables
into every agent container at startup. These are **read-only** — the
container should consume but never override them.

#### Agent Identity & Project

| Variable | Type | Default | Description |
|----------|------|---------|-------------|
| `AGENT_NAME` | string | — | The agent's name (e.g., `my-weather-agent`) |
| `AGENT_VERSION` | string | — | The agent's version |
| `AGENT_PROJECT_NAME` | string | `""` | Foundry project in `account@project` format |
| `AZURE_TENANT_ID` | string | `""` | Azure AD tenant ID |
| `AGENT_SUBSCRIPTION_ID` | string | `""` | Azure subscription ID |
| `AGENT_RESOURCE_GROUP` | string | `""` | Azure resource group name |

Use `AGENT_NAME` and `AGENT_VERSION` to populate the `gen_ai.agent.id`
span attribute (`"{AGENT_NAME}:{AGENT_VERSION}"`) and the server identity
header (§5).

#### Network

| Variable | Type | Default | Description |
|----------|------|---------|-------------|
| `DEFAULT_AD_PORT` | integer | `8088` | TCP port the server listens on (§1) |
| `SSE_KEEPALIVE_INTERVAL` | integer (seconds) | Disabled | SSE keep-alive comment interval (§1) |

#### Observability

| Variable | Type | Default | Description |
|----------|------|---------|-------------|
| `AGENT_LOG_LEVEL` | string | `Information` | Log verbosity: `Trace`, `Debug`, `Information`, `Warning`, `Error`, `Critical` (§3.1) |
| `AGENT_APP_INSIGHTS_ENABLED` | boolean | `true` | Master switch for the Azure Monitor exporter (§3.2) |
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | string | `""` | App Insights connection string. If empty and `AGENT_PROJECT_NAME` is set, auto-discover (§3.4) |
| `OTEL_EXPORTER_ENDPOINT` | string | `""` | OTLP collector endpoint, e.g. `http://localhost:4317` (§3.2) |

### 3.4 Azure Identity & Foundry Auto-Discovery

**App Insights auto-discovery:** When `APPLICATIONINSIGHTS_CONNECTION_STRING`
is empty and `AGENT_PROJECT_NAME` (§3.3) is set, the server resolves the
project endpoint
(`https://{account}.services.ai.azure.com/api/projects/{project}`) and
queries the Foundry telemetry API using Azure default credentials to
retrieve the App Insights connection string. Failures are swallowed —
telemetry is best-effort.

### 3.5 Platform Request Headers

The Azure AI Foundry platform sets the following headers on every request
it forwards to the agent container. These are protocol-agnostic — they
appear on requests to any protocol endpoint.

| Header | Description |
|--------|-------------|
| `traceparent` | [W3C Trace Context](https://www.w3.org/TR/trace-context/) parent span. Extract and use as the parent context for your span to join the platform's distributed trace. |
| `tracestate` | [W3C Trace Context](https://www.w3.org/TR/trace-context/) vendor-specific state, propagated from the caller. |
| `baggage` | [W3C Baggage](https://www.w3.org/TR/baggage/) for cross-service context propagation. |
| `x-request-id` | Platform-assigned request correlation ID. Protocols **SHOULD** propagate this into span baggage for end-to-end correlation. |

### 3.6 W3C Trace Context Propagation

The container **MUST** extract the `traceparent` and `tracestate` headers
from incoming requests and use them as the parent context when creating
spans. This connects the agent's spans to the platform's distributed trace
so the full call chain renders correctly in Application Insights and other
trace viewers.

### 3.7 Trace Provider Registration

The container **MUST** register one or more OTel instrumentation scopes
(trace providers) so that spans are captured by configured exporters.

| Scope | Instrumentation Scope Name | Description |
|-------|---------------------------|-------------|
| Infrastructure | `Azure.AI.AgentServer` | Shared infrastructure-level spans (health, startup, etc.) |
| Responses protocol | `Azure.AI.AgentServer.Responses` | Spans for `POST /responses` |
| User / handler spans | Custom (ex: `"Agents"`) | Spans created by the developer's handler code |

Future protocols will register their own instrumentation scope.

### 3.8 Baggage-to-Log Propagation (Recommended)

For full observability, implement an OpenTelemetry log record processor
that copies all baggage key-value pairs from the current span into every
log record's attribute map. This ensures that baggage values
(response ID, conversation ID, streaming flag, request ID) appear in every
log record even when the log call site does not explicitly include them.

---

## 4. Graceful Shutdown

When the host signals shutdown (e.g., `SIGTERM`):

1. Stop accepting new requests.
2. Signal all in-flight handlers that shutdown is occurring.
3. Allow a grace period for in-flight work to complete.
4. Persist final state for in-flight operations.
5. Exit cleanly.

---

## 5. Server Identity Header

All HTTP responses **SHOULD** include a server identity header to aid
debugging and version tracking:

```
x-platform-server: {sdk-or-server-name}/{version} ({language}/{runtime})
```

Replace the placeholders with values appropriate to your implementation
(e.g., `azure-ai-agentserver-responses/1.0.0 (python/3.12)`).
If another middleware has already set the header, append with `; `.

---

# Part II — Protocols

Each protocol defines its own endpoints, wire format, error shapes,
and handler contract. Protocols are additive — a single container can serve
multiple protocols by mapping each to a distinct route prefix (or root).

---

## 6. Responses API Protocol

The Responses API is a rich, full-featured protocol with streaming (SSE),
background processing, cancellation, conversation history, and input item
pagination.

> **SDK available:** The
> `Azure.AI.AgentServer.Responses`
> package (currently .NET) implements the full protocol. If an SDK exists
> for your language, prefer it over a from-scratch implementation — it
> handles mode negotiation, event processing, error recovery, persistence,
> and correctness guarantees automatically.

> **Full API reference:**
> [Azure AI Foundry — Responses API](https://learn.microsoft.com/en-us/azure/foundry/reference/foundry-project#responses-94)

### 6.1 Endpoints

| Method | Path | Summary |
|--------|------|---------|
| `POST` | `/responses` | Create a new response |
| `GET` | `/responses/{id}` | Retrieve response (JSON snapshot) |
| `GET` | `/responses/{id}?stream=true` | SSE event replay (background+streaming only) |
| `POST` | `/responses/{id}/cancel` | Cancel a background response |
| `DELETE` | `/responses/{id}` | Delete a stored response |
| `GET` | `/responses/{id}/input_items` | List input items (paginated) |

All routes support an optional configurable prefix (e.g., `/openai/v1`).

### 6.2 Response Modes

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

### 6.3 SSE Streaming

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

### 6.4 Error Shapes

HTTP errors use a standard envelope:

```json
{ "error": { "message": "...", "type": "...", "param": "...", "code": "..." } }
```

The `Response.error` field on a failed response uses a simpler shape
(`code` + `message` only). Internal exception details are never exposed.

> **Complete error taxonomy:**
> [`responses-api-behaviour-contract.md` — Error Shapes](responses-api-behaviour-contract.md#error-shapes)

### 6.5 ID Generation

Resource IDs use the format `{prefix}_{partitionKey}{entropy}` (50-char
body). The partition key (18 chars) is shared across related resources
within a request for storage co-location. Entropy (32 chars) is
cryptographically random.

The response prefix is `caresp`. Other prefixes (`msg`, `fc`, `rs`, `fs`,
`ws`, `ci`, `ig`, `mcp`, etc.) are used for sub-resources within a
response.

### 6.6 JSON Serialization

- Property naming: **snake_case**
- Null properties: **omit**
- Unknown request properties: **preserve** (round-trip)
- All paths (JSON responses, SSE `data:` lines) use the same serializer

### 6.7 Distributed Tracing

The `POST /responses` endpoint **MUST** emit a distributed trace span
following the
[OTel GenAI semantic conventions](https://opentelemetry.io/docs/specs/semconv/gen-ai/).
Read, cancel, delete, and health endpoints are **not** instrumented.

> The `Azure.AI.AgentServer.Responses`
> package (.NET) implements all tracing requirements below automatically.

#### 6.7.1 Span Name

The span display name **MUST** follow the OTel GenAI convention:

```
{operation_name} {model}
```

| Pattern | Example |
|---------|---------|
| `create_response {Model}` | `create_response gpt-4o` |
| `create_response` | *(when model is empty or omitted)* |

#### 6.7.2 Required Span Tags

Every `POST /responses` span **MUST** include the following tags.

##### Identity & GenAI Convention Tags

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

##### Namespaced Tags

These tags carry response-level metadata for correlation and dashboards:

| Tag Key | Value | Required |
|---------|-------|----------|
| `azure.ai.agentserver.responses.response_id` | `{ResponseId}` | Always |
| `azure.ai.agentserver.responses.conversation_id` | `{ConversationId}` or `""` | Always |
| `azure.ai.agentserver.responses.streaming` | `true` / `false` (boolean) | Always |

##### Error Tags

When the handler throws an exception, the span **MUST** record:

| Tag Key | Value |
|---------|-------|
| `azure.ai.agentserver.responses.error.code` | Error code from the exception |
| `azure.ai.agentserver.responses.error.message` | Error message from the exception |

In addition, set the span status to `ERROR` and record an OTel exception
event per the
[OTel exception semantic conventions](https://opentelemetry.io/docs/specs/semconv/exceptions/).

#### 6.7.3 Required Baggage Keys

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

#### 6.7.4 Structured Log Scope

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

<!-- Future protocols go here:
## 7. A1A Protocol
## 8. Activity Protocol
## 9. Invocations Protocol
-->

---

# Part III — Checklist

## 7. Container Image Checklist

### Infrastructure (Protocol-Agnostic)

- [ ] Listen on `0.0.0.0:${DEFAULT_AD_PORT:-8088}` over HTTP/1.1
- [ ] Expose `GET /liveness` and `GET /readiness` returning `200`
- [ ] Read log level from `AGENT_LOG_LEVEL`
- [ ] Support App Insights and/or OTLP telemetry exporters (§3.2)
- [ ] Consume platform env vars: `AGENT_NAME`, `AGENT_VERSION`, `AGENT_PROJECT_NAME` (§3.3)
- [ ] Auto-discover App Insights connection string from Foundry project (§3.4)
- [ ] Extract `traceparent`/`tracestate` headers for W3C Trace Context propagation (§3.6)
- [ ] Register OTel instrumentation scopes / trace providers (§3.7)
- [ ] Handle graceful shutdown (§4)
- [ ] (Recommended) Implement baggage-to-log propagation processor (§3.8)
- [ ] (Recommended) SSE keep-alive via `SSE_KEEPALIVE_INTERVAL` (§1)
- [ ] (Recommended) `x-platform-server` server identity header (§5)

### Responses API Protocol

> An SDK is available for .NET:
> `Azure.AI.AgentServer.Responses`.
> If an SDK exists for your language, it implements all of the below.

- [ ] Expose all 6 endpoints (§6.1)
- [ ] Support all response mode combinations (§6.2)
- [ ] SSE streaming with correct headers, sequence numbers, keep-alive (§6.3)
- [ ] Structured error envelopes (§6.4)
- [ ] Correct ID generation (`{prefix}_{partitionKey}{entropy}`) (§6.5)
- [ ] snake_case JSON serialization (§6.6)
- [ ] Distributed tracing span with GenAI semantic convention tags (§6.7)
- [ ] Required span tags: identity, namespaced, and error tags (§6.7.2)
- [ ] Required baggage keys set before handler invocation (§6.7.3)
- [ ] Structured log scope with `ResponseId`, `ConversationId`, `Streaming` (§6.7.4)


