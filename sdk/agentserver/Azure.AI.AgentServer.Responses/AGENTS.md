# AGENTS.md — Azure.AI.AgentServer.Responses

> This file contains **Responses-protocol-specific** rules.
> For core principles, build commands, and governance, see the parent [AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/AGENTS.md).

---

## 1. Contract Compliance (MANDATORY)

The Responses SDK has three **authoritative contract documents** that define all required behaviour. Any code change to this project **must** be verified against these contracts before committing.

### Authoritative trio (read before ANY code change)

| Document | Path | Defines |
|----------|------|---------|
| **API Behaviour Contract** | `docs/api-behaviour-contract.md` | Observable HTTP behaviour, endpoint matrices, error shapes, SSE contract, behavioural rules (B1–B37) |
| **SDK Behaviour Spec** | `docs/sdk-behaviour-spec.md` | Language-agnostic SDK requirements: event processing, state management, terminal authority, cancellation, persistence, observability (S-001–S-046) |
| **Handler Implementation Guide** | `docs/handler-implementation-guide.md` | Handler contract, builder pattern, cancellation, error handling, configuration |

### Supporting design docs (.NET-specific)

| Document | Path | Defines |
|----------|------|---------|
| Error handling | `docs/design/error-handling.md` | Exception hierarchy, error mapping |
| Provider contract | `docs/design/provider-contract.md` | `IResponsesProvider`, `IResponsesCancellationSignalProvider`, `IResponsesStreamProvider` |
| Orchestration | `docs/design/orchestration.md` | `ResponseOrchestrator` pipeline, event processing |
| Doc ownership matrix | `docs/doc-ownership-matrix.md` | Topic-to-document mapping, canonical sources |

### Compliance workflow

1. **Before implementing**: Read the relevant sections of the authoritative trio for the feature/endpoint being changed.
2. **Key rules to check**: Endpoint behaviour matrices (B1–B37), SDK processing rules (S-001–S-046), terminal event authority (S-018–S-022), cancellation categories (S-023–S-026), persistence timing (S-034–S-036).
3. **After implementing**: Audit the change against the contracts. Pay special attention to:
   - **B16**: Non-background in-flight responses are NOT findable (GET/DELETE/Cancel → 404).
   - **B2**: SSE replay requires `background=true` AND `stream=true` AND `store=true`.
   - **S-022**: SDK MUST NOT emit `response.incomplete` (handler-driven only).
   - **S-036**: Non-background cancelled responses are ephemeral (not persisted).
   - **S-019**: Cancellation winddown — SDK is sole authority on terminal event.
4. **Tests**: Any behavioural change MUST include protocol tests in `tests/Protocol/`. Unit tests alone are insufficient.
5. **If in doubt**: The contract document wins over the code. Fix the code, not the contract.

## 2. Key Namespaces

- `Azure.AI.AgentServer.Responses` — public API surface
- `Azure.AI.AgentServer.Responses.Models` — model types (from Contracts)
- `Azure.AI.AgentServer.Responses.Internal` — internal implementation (e.g., `SeekableReplaySubject`)

## 3. Package Rules

### Dependency isolation

- **Responses** depends only on **Responses.Contracts** (project reference) plus `Microsoft.AspNetCore.App` (framework reference). No additional NuGet packages in production.
- **Responses.Contracts** has zero NuGet dependencies.
- Test dependencies are managed via central package management (no per-package version overrides needed).

### ASP.NET target framework

`Responses` uses `$(RequiredRunnableTargetFrameworks)` (resolves to `net10.0;net8.0`) because it references `Microsoft.AspNetCore.App`. Standard `$(RequiredTargetFrameworks)` is used for Contracts and Tests.

### Generated code suppressions

Analyzer suppressions for generated code are scoped to `Azure.AI.AgentServer.Responses.Contracts/src/Generated/Directory.Build.props` — **not** in the root `Directory.Build.props`. Do not add blanket suppressions at higher levels.

### Generation pipeline

The TypeSpec generation pipeline is in `scripts/Generate-Contracts.ps1`:

1. `npx tsp-client sync` — fetch upstream TypeSpec sources
2. `npx tsp compile .` — compile TypeSpec → C# models + OpenAPI
3. Copy `Models/` and `Internal/` into `Contracts/src/Generated/`
4. `python3 generate-validators.py` — generate validators from OpenAPI spec
5. Clean intermediate `tsp-output/`

The Python validator generator (`scripts/generate-validators.py`) emits copyright-stamped C# files.

## 4. Testing Requirements

### E2E protocol tests

Any API behaviour change **must** include protocol tests in `tests/Protocol/`. These test the full HTTP pipeline via `TestWebApplicationFactory`. Unit tests alone are insufficient.

### Deterministic test synchronization

Never use blind `Task.Delay()` for async synchronization. Use `TaskCompletionSource`, `WaitAsync(TimeSpan)`, or polling loops with explicit timeout assertions. `Task.Delay` is acceptable only to simulate slow work in handlers.

### Model factory

`ResponsesModelFactory` provides static factory methods for constructing model types that have no public constructors, enabling consumer test scenarios.

## 5. ASP.NET Core Integration Pattern

Integration follows standard ASP.NET Core conventions:

- `IServiceCollection` extensions for registration: `AddResponsesServer()`
- `IEndpointRouteBuilder` extensions for routing: `MapResponsesServer()`
- The SDK owns protocol concerns (request/response models, routing, serialization, error shapes)
- The consumer owns business logic (tool implementations, agent behaviour via `IResponseHandler`)
