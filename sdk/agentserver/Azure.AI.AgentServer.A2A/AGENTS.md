# AGENTS.md - Azure.AI.AgentServer.A2A

For repository conventions, public API rules, and validation workflows, follow
the [parent instructions](../AGENTS.md). User-facing behavior and configuration
are documented in the [README](README.md).

## Library boundary

This library hosts native A2A applications in Foundry. The application owns the
Agent Card and agent execution logic. The native A2A library owns protocol
models, JSON-RPC validation, serialization, task lifecycle, and SSE transport.
This package owns the Foundry hosting integration, request context, task-store
selection, and semantic tracing.

Do not introduce a parallel A2A model hierarchy, translate requests into another
protocol, or move application business logic into the host. Verify native API
changes against the restored assembly or its matching upstream source.

## Protocol contracts

- The [A2A v1.0 specification](https://github.com/a2aproject/A2A/blob/v1.0.1/docs/specification.md)
  defines the native wire protocol.
- `a2a-protocol-spec.md` in the Foundry container-spec documents defines the
  platform-to-container A2A integration. Locate it alongside the
  `container-image-spec.md` and `package-architecture.md` references in the
  parent instructions.
- Read the relevant contract before changing endpoints, identity propagation,
  error behavior, task storage, or tracing. Contract requirements take precedence
  over existing implementation behavior.

Canonical routes are `POST /a2a` and
`GET /a2a/.well-known/agent-card.json`. Do not add alternate protocol routes,
silently enable another binding, or advertise unsupported features.
Preserve native JSON-RPC results and errors, including errors returned with HTTP
200. Do not buffer a complete SSE response.

## Source layout and public API

| Location | Responsibility |
| --- | --- |
| `src/Hosting/` | Server entry points, Core builder extensions, service registration, and endpoint mapping. |
| `src/FoundryTaskStore.cs` | Native `ITaskStore` implementation backed by Core storage. |
| `src/Internal/` | Transport execution, request scope, response observation, and capability restrictions. |
| `tests/` | Hosting, HTTP, storage, and tracing contracts. |
| `tests/Snippets/` | Compiled source for README and sample code. |
| `samples/` | Customer-facing usage examples. |
| `api/` | Generated public API listings for supported target frameworks. |

Keep the public API in `Azure.AI.AgentServer.A2A` and implementation types in
`Azure.AI.AgentServer.A2A.Internal`. Public service methods must remain virtual
and mockable. Static extension classes do not need mock constructors. Export API
listings with the repository tooling; do not hand-edit them.

## Hosting and storage

Preserve explicitly registered native handlers and task stores. Externally
constructed handlers and stores remain application-owned. Native handlers are
singletons; keep request-specific data out of mutable instance state.

Keep Foundry identity request-scoped and restore ambient scope in `finally`.
Only the platform call ID is forwarded to Foundry services. Treat user, task,
message, tenant, context, and session identifiers as opaque values.

Hosted task operations must require usable caller context and verify
server-side user isolation. Never replace a failed hosted store with local or
in-memory storage. Keep missing records distinct from corrupt snapshots,
authorization failures, and storage-service failures. Task persistence does not
imply executor recovery or durable subscriptions.

## Observability

Native operation spans describe the Agent Card; hosted invocation spans describe
the deployment. Keep spans open through complete response transmission and
propagate cancellation. Response observation must remain bounded, handle split
SSE framing, and forward the original response bytes unchanged.

Do not record prompts, artifacts, application metadata, credentials, or tokens in
semantic spans. Use structured `ILogger` diagnostics for failures.

## Tests and examples

- Public argument contracts need unit tests. Endpoint, response-header, error,
  and streaming changes require tests through the real ASP.NET Core pipeline.
- Test the canonical route surface, explicit handler/store preservation,
  caller isolation, task serialization, streaming completion, and trace lifetime.
- Every sample handler requires a compiled snippet and a corresponding HTTP
  test in `tests/SampleEndToEndTests.cs`. Edit snippet source, then regenerate
  Markdown with the repository snippet script.
- Use deterministic async gates and bounded waits. Mark real-service tests live
  and obtain their configuration from environment variables.
- Restore test-owned environment variables and dispose test hosts, listeners,
  streams, and stores. Keep offline tests independent of Azure credentials.

## Build and dependencies

Use the repository target-framework properties and central package management.
Native A2A dependency versions are scoped in
`eng/centralpackagemanagement/overrides/Azure.AI.AgentServer.A2A.Packages.props`.
Do not add blanket analyzer suppressions or change unrelated package versions.

Run the smallest relevant tests during development. For public API or sample
changes, also export API listings, regenerate snippets, and compile with
`BuildSnippets=true`, following the validation order in the parent instructions.
