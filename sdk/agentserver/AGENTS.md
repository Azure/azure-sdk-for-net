# AGENTS.md

## Project Overview

**Azure.AI.AgentServer.Responses** is a .NET 8 NuGet class library (SDK) that helps developers build ASP.NET Core servers implementing the Azure AI Responses API. This is NOT a standalone application — it is a library consumed by other projects.

## Architecture

- **`Azure.AI.AgentServer.Responses.Contracts/src/`** — TypeSpec-generated model contracts (output: `Azure.AI.AgentServer.Responses.Contracts.dll`, NuGet: `Azure.AI.AgentServer.Responses.Contracts`). Contains all generated models, generated internal helpers, model customizations, and the TypeSpec pipeline.
- **`Azure.AI.AgentServer.Responses/src/`** — Hand-written SDK library (output: `Azure.AI.AgentServer.Responses.dll`, NuGet: `Azure.AI.AgentServer.Responses`). Contains builders, exceptions, hosting extensions, internal plumbing, and core public types. References Contracts.
- **`Azure.AI.AgentServer.Responses/tests/`** — NUnit test project (output: `Azure.AI.AgentServer.Responses.Tests.dll`)
- **`Azure.AI.AgentServer.sln`** — Solution file (3 projects: Contracts, Sdk, Tests)

## Key Conventions

### Namespaces & Assembly
- Root namespace: `Azure.AI.AgentServer.Responses`
- Test namespace: `Azure.AI.AgentServer.Responses.Tests`
- File/directory names are short (`Azure.AI.AgentServer.Responses.csproj`, `Azure.AI.AgentServer.Responses.Tests.csproj`) but namespaces/assemblies use the full name

### SDK Design Patterns
- Consumers add the NuGet package and call extension methods on `IServiceCollection` and `IApplicationBuilder`
- Public API must be minimal and intuitive — use `internal` aggressively
- XML documentation comments required on all `public` members
- Follow Microsoft SDK design guidelines

### Development Workflow
- **Spec-Driven Development (SDD)** via GitHub Spec-Kit
- Constitution at `.specify/memory/constitution.md` — read before making changes
- API behaviour contract at `docs/api-behaviour-contract.md` — canonical reference for all API behavioural rules, endpoint matrices, SSE event contract, and error shapes
- Handler implementation guide at `docs/handler-implementation-guide.md` — developer guidance for implementing `IResponseHandler`
- Feature specs in `.specify/specs/`
- Use `/speckit.*` commands for structured workflow

### Build & Test
```bash
make dev        # open dev container (from repo root via VS Code / devcontainer CLI)
make restore    # dotnet restore
make build      # dotnet build
make test       # dotnet test (NUnit)
make lint       # dotnet format --verify-no-changes
make format     # dotnet format
make pack       # dotnet pack (NuGet)
make all        # restore → build → test → lint
```

### Dev Container Setup
The dev container config lives at the **monorepo root** (`.devcontainer/agentserver/`), not in this subfolder. This is the standard named-config pattern for monorepos — it lets you open the repo root in VS Code, select "Reopen in Container → AgentServer", and get git working at every level.

Three ways to launch:
1. `make dev` — auto-detects `devcontainer` CLI or falls back to `code` CLI
2. Open repo root in VS Code → Ctrl+Shift+P → "Reopen in Container" → select "AgentServer"
3. `devcontainer open --workspace-folder <repo-root> --config .devcontainer/agentserver/devcontainer.json`

For a multi-root workspace view (agentserver + monorepo root in file explorer), open `agentserver.code-workspace`.

### Code Style
- .NET 8, C# with nullable reference types enabled
- File-scoped namespaces
- EditorConfig enforced (see `.editorconfig`)
- `dotnet format` for formatting

## E2E Protocol Test Requirement
- **Any API behaviour change must include E2E protocol tests.** This covers: endpoint logic, SSE event contract, error shapes, status transitions, response headers, HTTP status codes.
- Protocol tests exercise the full HTTP pipeline via `TestWebApplicationFactory` and live in `Azure.AI.AgentServer.Responses/tests/Protocol/`.
- Unit tests alone are insufficient — they miss middleware ordering, header propagation, serialization edge cases, and status code mapping.
- Write protocol tests FIRST (TDD), verify they FAIL, then implement the behaviour change to make them pass.

## Deterministic Test Synchronization
- **Never use blind `Task.Delay()` to wait for asynchronous state changes in tests.** Use `TaskCompletionSource` gates, `WaitForBackgroundCompletionAsync()`, `PollUntilAsync<T>()`, or polling loops with explicit timeout assertions.
- `Task.Delay` is acceptable only inside handler helpers to **simulate slow work** (e.g., `Task.Delay(200, CancellationToken.None)` to mimic a long-running tool call).
- **Transient test failures must be fixed immediately.** A flaky test is a bug. Diagnose the root cause (race condition, blind delay) and fix with deterministic synchronization before proceeding with other work.

## Do NOT
- Expose internal implementation details in the public API
- Add dependencies without justification
- Skip tests — TDD is non-negotiable (see constitution)
- Skip E2E protocol tests for API behaviour changes (see above)
- Create standalone executable projects — this is a library SDK
