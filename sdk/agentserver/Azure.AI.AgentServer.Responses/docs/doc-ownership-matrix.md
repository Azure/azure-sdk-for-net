# Documentation Ownership Matrix

> **Purpose**: Maps every library topic to its **canonical document** — the single source of truth. Secondary mentions in other documents must cross-link to the canonical source, never duplicate facts.

---

## Document Set Overview

The documentation follows a **4-layer architecture**. The first three layers form the **authoritative trio** — sufficient to generate a conforming library in any language.

| Layer | Document | Audience | Portable? |
|-------|----------|----------|-----------|
| **API** | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | API consumers, protocol implementers | Yes |
| **Library Behaviour** | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | Multi-language library teams, library architects | Yes |
| **Handler** | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | Handler authors (library consumers) | Conceptually |
| **Design (.NET)** | [design/](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design) | .NET library contributors | No |
| **Governance** | This matrix, [top-level AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md) + [Responses AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/AGENTS.md) | All contributors | N/A |

---

## How to Use This Matrix

1. **Before writing documentation**: Look up the topic below to find where it belongs.
2. **Layer test**: Ask — (1) Can an HTTP client observe this? → API contract. (2) Must any conforming library do this regardless of language? → library behavioural spec. (3) Does a handler author need to act on this? → Handler guide. (4) Is this specific to .NET? → Design docs.
3. **Cross-linking**: If your document mentions a topic owned by another document, link to it — don't re-explain.
4. **Adding new topics**: Add a row here when introducing a new feature or concept.

---

## Topic-to-Document Mapping

### Layer 1: Protocol & Observable Behaviour (API Contract)

| Topic | Canonical Document | Section | Audience |
|-------|-------------------|---------|----------|
| API defaults (`store`, `background`, `stream`) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [API Defaults](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#api-defaults) | Protocol implementers |
| Constraint dependencies | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Constraint Dependencies](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#constraint-dependencies) | Protocol implementers |
| Endpoint behaviour (POST, GET, cancel) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Endpoints](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#endpoints) | Protocol implementers |
| Cancel winddown observable (B11) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Cancel Winddown](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#cancel-winddown-behaviour-rule-b11) | Protocol implementers |
| Cancellation scenario matrix | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Cancellation Scenario Matrix](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#cancellation-scenario-matrix) | Protocol implementers |
| Response status lifecycle (B6) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Response Status Lifecycle](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#response-status-lifecycle) | Protocol implementers |
| SSE event contract (ordering B8, sequence B9) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [SSE Event Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#sse-event-contract) | Protocol implementers |
| Snapshot semantics (B23) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Snapshot Semantics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#snapshot-semantics-rule-b23) | Protocol implementers |
| Terminal event guarantees | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Terminal Event Guarantees](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#terminal-event-guarantees) | Protocol implementers |
| Response replacement semantics (B37) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Response Replacement Semantics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#response-replacement-semantics) | Protocol implementers |
| Error shapes & error types | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Error Shapes](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#error-shapes) | Protocol implementers |
| Terminal SSE events (B26) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Terminal SSE Events](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#terminal-sse-events-rule-b26) | Protocol implementers |
| SSE wire format (B27) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [SSE Wire Format](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#sse-wire-format-rule-b27) | Protocol implementers |
| SSE keep-alive protocol (B28) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [SSE Keep-Alive](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#sse-keep-alive-rule-b28) | Protocol implementers |
| Request payload validation (B29) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Request Payload Validation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#request-payload-validation-rule-b29) | Protocol implementers |
| Response validation (B30) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Response Validation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#response-validation-rule-b30) | Protocol implementers |
| Required response fields (B31) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Required Response Fields](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#required-response-fields-rule-b31) | Protocol implementers |
| Terminal event guarantee (B32) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Behavioural Rules Index](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#behavioural-rules-index) | Protocol implementers |
| Token usage reporting (B33) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Token Usage Reporting](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#token-usage-reporting-rule-b33) | Protocol implementers |
| Distributed tracing (B34) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Observability Requirements](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#observability-requirements) | library implementers |
| Event stream replay availability (B35) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Event Stream Replay Availability](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#event-stream-replay-availability-rule-b35) | Protocol implementers |
| Response persistence timing (B36) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Persistence Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract) | library implementers |
| HTTP 499 on client disconnect | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Known Error Types](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#known-error-types-and-codes) | Protocol implementers |
| Behavioural rules index (B1–B37) | [api-behaviour-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md) | [Behavioural Rules Index](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#behavioural-rules-index) | Protocol implementers |

### Layer 2: Library Behavioural Specification (Language-Agnostic)

| Topic | Canonical Document | Section | Audience |
|-------|-------------------|---------|----------|
| Request processing pipeline (S-001–S-003) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Request Processing Pipeline](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#request-processing-pipeline) | library teams (all languages) |
| Handler contract — abstract interface (S-004–S-006) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Handler Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#handler-contract) | library teams (all languages) |
| Event processing rules (S-007–S-012) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Event Processing Rules](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#event-processing-rules) | library teams (all languages) |
| Response state management (S-013–S-017) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Response State Management](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#response-state-management) | library teams (all languages) |
| Terminal event authority rules (S-018–S-022) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Terminal Event Authority](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#terminal-event-authority) | library teams (all languages) |
| Cancellation mechanism — abstract (S-023–S-026) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Cancellation Mechanism](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#cancellation-mechanism) | library teams (all languages) |
| Error handling pipeline — abstract (S-027–S-030) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Error Handling Pipeline](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#error-handling-pipeline) | library teams (all languages) |
| Validation enforcement (S-031–S-033) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Validation Enforcement](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#validation-enforcement) | library teams (all languages) |
| Persistence contract — abstract provider (S-034–S-038) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Persistence Contract](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#persistence-contract) | library teams (all languages) |
| Configuration requirements (S-039–S-042) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Configuration Requirements](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#configuration-requirements) | library teams (all languages) |
| Observability requirements (S-043–S-045) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Observability Requirements](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#observability-requirements) | library teams (all languages) |
| Library behavioural rules index (S-001–S-045) | [library-behaviour-spec.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md) | [Library Behavioural Rules Index](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#library-behavioural-rules-index) | library teams (all languages) |

### Layer 3: Handler Development (Handler Guide)

| Topic | Canonical Document | Section | Audience |
|-------|-------------------|---------|----------|
| `IResponseHandler` interface | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [IResponseHandler](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#iresponsehandler) | Handler authors |
| `ResponseEventStream` | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [ResponseEventStream](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#responseeventstream) | Handler authors |
| `IResponseContext` | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [IResponseContext](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#iresponsecontext) | Handler authors |
| Builder pattern | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Builder Pattern](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#builder-pattern) | Handler authors |
| Emitting output (text, function calls, etc.) | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Emitting Output](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#emitting-output) | Handler authors |
| Handling input | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Handling Input](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#handling-input) | Handler authors |
| Cancellation (handler-side) | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Cancellation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#cancellation) | Handler authors |
| Graceful shutdown (handler-side) | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Graceful Shutdown](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#graceful-shutdown) | Handler authors |
| Error handling (handler-side) | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Error Handling](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#error-handling) | Handler authors |
| Signalling incomplete | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Signalling Incomplete](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#signalling-incomplete) | Handler authors |
| Server registration | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Server Registration](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#server-registration) | Handler authors |
| Configuration options | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Configuration](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#configuration) | Handler authors |
| Best practices | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Best Practices](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#best-practices) | Handler authors |
| Common mistakes | [handler-implementation-guide.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md) | [Common Mistakes](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#common-mistakes) | Handler authors |

**Handler-perspective summaries** (canonical fact lives elsewhere; handler guide provides 1–2 sentence actionable summary + cross-link):

| Topic | Summary in Handler Guide | Canonical Source |
|-------|------------------------|-----------------|
| Sequence numbers | "Auto-assigned, never set manually" | API contract §B9 |
| Snapshot semantics | "Safe to mutate between yields" | API contract §B23 |
| Cancel winddown | "Let OCE propagate; server handles winddown" | API contract §B11 |
| Validation pipeline | "Bad input → 400, bad output → 500; don't catch" | API contract §B29/B30 |
| Terminal event requirement | "Must emit exactly one; server auto-fails if missing" | API contract §B32 |
| Token usage reporting | Code sample; cross-links for protocol details | API contract §B33 |
| Library identity header | "Auto-added; append custom identity via options" | API contract §B19 |
| Distributed tracing | Code sample (ActivitySource registration) | API contract §B34 |
| TTL eviction | Config code sample | API contract §B35 |
| SSE keep-alive | Config code sample | API contract §B28 |
| Client headers (`ClientHeaders`) | "Forwarded `x-client-*` headers from the original request" | Handler guide §IResponseContext |
| Query parameters (`QueryParameters`) | "All query parameters from the original request" | Handler guide §IResponseContext |
| Custom response provider | Cross-link to library spec + design doc | library spec §Persistence Contract, design/provider-contract.md |
| Error shapes | "Throw BadRequestException for 400; unhandled → 500" | API contract §Error Shapes |

### Layer 4: .NET Design Documentation (NOT Portable)

| Topic | Canonical Document | Section | Audience |
|-------|-------------------|---------|----------|
| Design docs overview | [design/OVERVIEW.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/OVERVIEW.md) | (index) | .NET library contributors |
| Request pipeline implementation | [design/orchestration.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | [Request Pipeline Overview](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md#request-pipeline-overview) | .NET library contributors |
| Event processing loop | [design/orchestration.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | [Event Processing Loop](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md#event-processing-loop) | .NET library contributors |
| Handler validation enforcement | [design/orchestration.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | [Handler Validation Rules](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md#handler-validation-rules) | .NET library contributors |
| Auto-stamping implementation | [design/orchestration.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | [Auto-Stamping Implementation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md#auto-stamping-implementation) | .NET library contributors |
| Response replacement mechanism | [design/orchestration.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | [Response Replacement Mechanism](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md#response-replacement-mechanism) | .NET library contributors |
| Snapshot serialization (ModelReaderWriter) | [design/orchestration.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | [Snapshot Serialization](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md#snapshot-serialization) | .NET library contributors |
| Terminal event authority (.NET) | [design/orchestration.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md) | [Terminal Event Authority](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/orchestration.md#terminal-event-authority) | .NET library contributors |
| ExceptionFilter class | [design/error-handling.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md) | [ResponsesExceptionFilter](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md#responsesexceptionfilter) | .NET library contributors |
| ApiErrorFactory class | [design/error-handling.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md) | [ApiErrorFactory](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md#apierrorfactory) | .NET library contributors |
| OCE classification (CTS inspection) | [design/error-handling.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md) | [OCE Classification](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md#oce-classification-implementation) | .NET library contributors |
| Validation exception classes | [design/error-handling.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md) | [Validation Exception Classes](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/error-handling.md#validation-exception-classes) | .NET library contributors |
| IResponsesProvider interface | [design/provider-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) | [IResponsesProvider Interface](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md#iresponsesprovider-interface) | .NET library contributors |
| IAsyncObserver event streaming | [design/provider-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) | [IAsyncObserver Event Streaming](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md#iasyncobserver-event-streaming) | .NET library contributors |
| InMemoryResponsesProvider | [design/provider-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) | [InMemoryResponsesProvider](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md#inmemoryresponsesprovider) | .NET library contributors |
| InMemoryProviderOptions | [design/provider-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) | [InMemoryProviderOptions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md#inmemoryprovideroptions) | .NET library contributors |
| Persistence timing implementation | [design/provider-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) | [Persistence Timing](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md#persistence-timing-implementation) | .NET library contributors |
| CancellationTokenSource management | [design/provider-contract.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md) | [CTS Management](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/provider-contract.md#cancellationtokensource-management) | .NET library contributors |

### Cross-Package: Hosting Concepts

| Topic | Canonical Document | Section | Audience |
|-------|-------------------|---------|----------|
| `AgentHost` (static entry point) | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | [AgentHost](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md#agenthost) | Library consumers |
| `AgentHostBuilder` | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | [AgentHostBuilder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md#agenthostbuilder) | Library consumers |
| `AgentHostApp` | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | [AgentHostApp](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md#agenthostapp) | Library consumers |
| `AgentHostOptions` | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | Key concepts | Library consumers |
| `FoundryEnvironment` | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | [FoundryEnvironment](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md#foundryenvironment) | Library consumers |
| Health endpoint (`/healthy`) | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | [Health endpoint](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md#health-endpoint) | Library consumers |
| OpenTelemetry configuration | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | [Telemetry](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md#telemetry) | Library consumers |
| `ServerUserAgentMiddleware` (server user-agent) | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | Key concepts | Library consumers |
| `ServerUserAgentRegistry` (protocol identity) | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | Key concepts | Library consumers |
| `RequestIdBaggagePropagator` | [Hosting README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md) | Key concepts | Library consumers |

### Cross-Package: Invocations Concepts

| Topic | Canonical Document | Section | Audience |
|-------|-------------------|---------|----------|
| `InvocationHandler` (abstract class) | [Invocations README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md) | [InvocationHandler](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md#invocationhandler) | Library consumers |
| `InvocationContext` | [Invocations README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md) | [InvocationContext](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md#invocationcontext) | Library consumers |
| `SessionIdResolver` | [Invocations README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md) | [Session resolution](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md#session-resolution) | Library consumers |
| `ClientHeaderForwarder` | [Invocations README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md) | [Client header forwarding](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md#client-header-forwarding) | Library consumers |
| `InvocationsActivitySource` | [Invocations README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md) | Key concepts | Library consumers |
| `InvocationsServerOptions` | [Invocations README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/README.md) | Key concepts | Library consumers |

### Project Governance

| Topic | Canonical Document | Section | Audience |
|-------|-------------------|---------|----------|
| Core principles (constitution) | [AGENTS.md (top-level)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md) | [Section 0: Core Principles](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md#0-core-principles-constitution) | All contributors |
| Build & test commands | [AGENTS.md (top-level)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md) | [Build, Test & Finalize](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md#3-build-test--finalize) | All contributors |
| Project structure | [AGENTS.md (top-level)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md) | [Architecture](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md#1-project-architecture) | All contributors |
| Do NOT (universal prohibitions) | [AGENTS.md (top-level)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md) | [Do NOT](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md#4-do-not) | All contributors |
| Governance & amendments | [AGENTS.md (top-level)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md) | [Governance](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md#5-governance) | All contributors |
| Responses contract compliance | [AGENTS.md (Responses)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/AGENTS.md) | [Contract Compliance](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/AGENTS.md#1-contract-compliance-mandatory) | Responses contributors |
| Responses package rules | [AGENTS.md (Responses)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/AGENTS.md) | [Package Rules](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/AGENTS.md#3-package-rules) | Responses contributors |
| Responses testing requirements | [AGENTS.md (Responses)](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/AGENTS.md) | [Testing Requirements](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/AGENTS.md#4-testing-requirements) | Responses contributors |
| Doc ownership (this matrix) | [doc-ownership-matrix.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/doc-ownership-matrix.md) | (this document) | Contributors |
| Getting started (consumer) | [README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/README.md) | (entire document) | library consumers |
| Samples | [samples/README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/README.md) | (entire document) | library consumers |

---

## Previously-Duplicated Topics — Resolution

These 12 topics were duplicated between documents prior to the layer separation. Each now has a single canonical location; other documents provide a handler-perspective summary + cross-link.

| # | Topic | Canonical Document | Non-Canonical Treatment |
|---|-------|--------------------|------------------------|
| 1 | Cancel winddown | API contract (B11) | library spec: abstract mechanism (S-019); Handler: "Let OCE propagate" + cross-link |
| 2 | Response replacement (B37) | API contract | library spec: enforcement rules (S-013–S-014); Handler: builder-perspective note + cross-link |
| 3 | TTL eviction | API contract (B35) | library spec: abstract TTL contract (S-038); Handler: config code sample + cross-link |
| 4 | SSE keep-alive | API contract (B28) | Handler: config code sample + cross-link |
| 5 | Distributed tracing | API contract (B34) | library spec: required spans/tags (S-043–S-045); Handler: registration code sample + cross-link |
| 6 | Terminal events | API contract | library spec: terminal event authority (S-018–S-022); Handler: "must emit exactly one" + cross-link |
| 7 | Handler validation rules | library spec (S-007–S-012) | Handler: "bad handler consequences" summary + cross-link |
| 8 | Validation pipeline | API contract (B29/B30) | library spec: enforcement rules (S-031–S-033); Handler: "don't catch" guidance + cross-link |
| 9 | Sequence numbers | API contract (B9) | library spec: injection rule (S-010); Handler: "auto-assigned, don't set" + cross-link |
| 10 | Snapshot semantics | API contract (B23) | library spec: immutability guarantee (S-011); Handler: "safe to mutate between yields" + cross-link |
| 11 | Token usage | API contract (B33) | Handler: code sample + cross-link |
| 12 | Error shapes | API contract | library spec: error mapping (S-027–S-030); Handler: "throw BadRequestException" + cross-link |

---

## Cross-Link Conventions

- **API Contract → Handler Guide**: `> **For handler developers**: See [Section](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/handler-implementation-guide.md#section) for implementation guidance.`
- **API Contract → library Spec**: `> **For library implementers**: See [S-XXX](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#section) for the library behavioural rule.`
- **API Contract → Design Doc**: `> **For .NET contributors**: See [Section](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/file.md#section) for implementation details.`
- **Handler Guide → API Contract**: `See [Rule BXX](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#section-anchor) for the protocol-level behaviour.`
- **Handler Guide → library Spec**: `See [S-XXX](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/library-behaviour-spec.md#section) for the library behavioural requirement.`
- **Handler Guide → Design Doc**: `See [Section](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/design/file.md#section) for .NET implementation details.`
- **library Spec → API Contract**: `See [BXX](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/docs/api-behaviour-contract.md#section) for the observable protocol behaviour.`
- **library Spec → Design Doc**: Not linked (library spec is language-agnostic — .NET design docs are supplementary)
- **Design Doc → library Spec**: `Implements [S-XXX](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/library-behaviour-spec.md#section).`
- **Design Doc → API Contract**: `See [BXX](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/api-behaviour-contract.md#section) for observable outcomes.`
- **Core Principles → Docs**: The constitution is in the top-level AGENTS.md Section 0. Cross-link: `../../AGENTS.md#0-core-principles-constitution`.
- **Responses AGENTS.md → Docs**: Use relative paths from the Responses project root (e.g., `docs/api-behaviour-contract.md`).
- **Top-level AGENTS.md → Protocol AGENTS.md**: Use relative project paths (e.g., `Azure.AI.AgentServer.Responses/AGENTS.md`).

---

## Maintenance

- **When adding a feature**: Add a row to the appropriate layer table above.
- **Portability test**: If the topic applies to any library regardless of language → library behavioural spec. If .NET-specific → design docs.
- **When creating a new document**: Add it to the appropriate layer table and update this governance section.
- **When retiring a section**: Remove the row and update any cross-links.
- **When adding an S-rule**: Add to library behavioural spec index table AND update Layer 2 table here.
- **When adding a B-rule**: Add to API contract index AND update Layer 1 table here.
