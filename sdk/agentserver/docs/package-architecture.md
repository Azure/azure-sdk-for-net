# Agent Server SDK — Package Architecture

This document describes the packaging structure of the Azure AI Agent
Server SDK. Each package maps to a layer in the
[container image specification](container-image-spec.md).

Developers building hosted agents **compose** their container image by
selecting one or more protocol packages plus the Core package. The
developer owns the host process — they wire up the server, health probes,
graceful shutdown, and any cross-cutting middleware appropriate for their
chosen combination of protocols.

---

## Package Overview

| Package | Layer | Description |
|---------|-------|-------------|
| `Azure.AI.AgentServer.Core` | Shared utilities | Protocol-agnostic and server-stack-agnostic utilities: observability (telemetry exporters, trace context, baggage-to-log), platform environment variable helpers, Azure Identity & Foundry auto-discovery ([§3](container-image-spec.md#3-observability)) |
| `Azure.AI.AgentServer.Responses` | Protocol | [Responses API](responses-protocol-spec.md) implementation: endpoints, mode negotiation, SSE streaming, error handling, ID generation, distributed tracing |
| `Azure.AI.AgentServer.Invocations` | Protocol | Invocations protocol implementation *(planned)* |

> **Note:** Not every protocol requires a bespoke SDK package from this
> repo. Some protocols — such as **A2A** and **Activity Protocol** — have
> well-established SDKs maintained by first-party (1P) or third-party (3P)
> communities. When a mature SDK already exists, the recommendation is to
> use it directly rather than building a new wrapper. Only protocols that
> lack a suitable SDK (e.g., the Responses API) get a dedicated
> `Azure.AI.AgentServer.*` package.

---

## Dependency Graph

```
Azure.AI.AgentServer.Responses   (standalone — no dependency on Core)
Azure.AI.AgentServer.Invocations (standalone — no dependency on Core)
Azure.AI.AgentServer.Core        (standalone — shared utilities)
```

Packages are **independent** of each other. There is no forced dependency
between protocol packages or between a protocol package and Core.

`Core` is protocol-agnostic **and** server-stack-agnostic — it contains
no networking, HTTP, health probe, or graceful shutdown logic. Those
concerns are owned by each protocol package (which chooses its own server
stack).

---

## What Lives Where

| Concern | Owner |
|---------|-------|
| Telemetry exporters (App Insights, OTLP) | `Core` |
| Platform env var helpers (`AGENT_NAME`, etc.) | `Core` |
| Azure Identity & Foundry auto-discovery | `Core` |
| Baggage-to-log propagation | `Core` |
| Protocol endpoints, wire format, SSE streaming | Protocol package |
| Protocol-specific distributed tracing (spans, tags, baggage) | Protocol package |
| Trace provider / instrumentation scope registration | Protocol package |
| Server identity header | Protocol package |
| HTTP host, routing, health probes | **Developer** (host composition) |
| Graceful shutdown | **Developer** (host composition) |
| Port binding, TLS, middleware | **Developer** (host composition) |

---

## When to Use Each Package

| Scenario | Packages | Developer adds |
|----------|----------|----------------|
| Responses API agent | `Core` + `Responses` | Host, health probes, shutdown |
| Invocations agent | `Core` + `Invocations` | Host, health probes, shutdown |
| Multi-protocol agent | `Core` + `Responses` + `Invocations` | Host, health probes, shutdown, routing |
| A2A / Activity Protocol agent | `Core` + community SDK | Host, health probes, shutdown |
