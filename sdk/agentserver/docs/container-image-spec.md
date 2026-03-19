# Agent Server Container / Image Specification

> **Purpose:** This document describes the **protocol-agnostic
> infrastructure** requirements for an Azure AI Agent Server container
> image. Protocol-specific requirements live in their own documents
> (see §6).

---

## Table of Contents

- [1. Network & Transport](#1-network--transport)
- [2. Health Probes](#2-health-probes)
- [3. Observability](#3-observability)
- [4. Graceful Shutdown](#4-graceful-shutdown)
- [5. Server Identity Header](#5-server-identity-header)
- [6. Protocols](#6-protocols)
- [7. Infrastructure Checklist](#7-infrastructure-checklist)

---

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
Protocol-specific trace spans and tags are defined within each protocol's
spec document (e.g.,
[`responses-protocol-spec.md` §7](responses-protocol-spec.md#7-distributed-tracing)
for the Responses API).

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

## 6. Protocols

Each protocol defines its own endpoints, wire format, error shapes,
and tracing contract. Protocols are additive — a single container can
serve multiple protocols by mapping each to a distinct route prefix
(or root).

| Protocol | Spec | SDK (.NET) | Status |
|----------|------|------------|--------|
| **Responses API** | [`responses-protocol-spec.md`](responses-protocol-spec.md) | `Azure.AI.AgentServer.Responses` | Available |
| A2A | — | — | Planned |
| Activity Protocol | — | — | Planned |
| Invocations | — | — | Planned |

---

## 7. Infrastructure Checklist

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

> Protocol-specific checklists are in each protocol's spec document.


