# AGENTS.md — Azure.AI.AgentServer

> For general AI agent guidelines, safety boundaries, and repo-wide workflows,
> see the root [AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/AGENTS.md).

---

## 0. Core Principles (Constitution)

These principles govern **all** work under `sdk/agentserver/`, across every protocol and project. They are the **supreme governing rules** — they supersede informal practices and ad-hoc decisions. When principles conflict, resolve in this priority order: **Protocol Fidelity > Developer Experience > Minimal API Surface > Simplicity**.

### I. Library-First (Library, Never Application)

- This project produces **class libraries** distributed via NuGet. It is never a standalone executable.
- Every public type must be designed for consumption by external developers building their own ASP.NET Core hosts.
- The library owns protocol concerns (request/response models, routing, serialization, error shapes). The consumer owns business logic (tool implementations, agent behaviour).
- No global state, static mutable singletons, or assumptions about the host process.

### II. Developer Experience Above All

- The primary measure of success is how quickly a developer can go from `dotnet add package` to a working server.
- Integration follows standard ASP.NET Core conventions: `IServiceCollection` extensions for registration, `IEndpointRouteBuilder` extensions for routing.
- Provide sensible defaults with progressive disclosure of complexity — simple things must be simple, advanced scenarios must be possible.
- XML documentation comments are required on **all** `public` and `protected` members.

### III. Minimal Public API Surface

- Default visibility is `internal`. Only promote to `public` when there is a clear, justified consumer need.
- Every public type, method, and property must earn its place. Prefer fewer, well-designed abstractions over a sprawling API.
- Use `[EditorBrowsable(EditorBrowsableState.Never)]` for types that must be public for technical reasons but are not intended for direct consumer use.
- Avoid leaking implementation details into the public API.

### IV. Test-First (NON-NEGOTIABLE)

- **TDD is mandatory.** Write test → see it fail (red) → implement → see it pass (green) → refactor.
- All public API contracts must have corresponding unit tests.
- **E2E protocol tests are mandatory for API behaviour changes.** Any change to endpoint logic, SSE event contract, error shapes, status transitions, response headers, or HTTP status codes MUST include protocol tests that exercise the full HTTP pipeline. Unit tests alone are insufficient.
- **Deterministic synchronization is mandatory.** Never use blind `Task.Delay()` to wait for async state changes. Use `TaskCompletionSource` gates, `WaitAsync(TimeSpan)`, or polling loops with explicit timeout assertions. `Task.Delay` is acceptable only to simulate slow work in handlers.
- **Transient test failures must be fixed immediately.** A flaky test is a bug. Diagnose the root cause and fix with deterministic synchronization before proceeding.

### V. Protocol Fidelity

- Each protocol library must faithfully implement its specification. Deviations from the spec are bugs.
- API models (request/response shapes, error codes, headers) must match the specification exactly.
- The authoritative contract documents win over the code. Fix the code, not the contract. Each protocol's AGENTS.md defines its authoritative documents.

### VI. Async-All-the-Way

- The library is **async-only**. All public service methods are asynchronous.
- **AZC0004 exemption**: Azure SDK rule AZC0004 requires both sync and async variants for HTTP/REST client libraries. This library is exempt because it is a **server-side hosting library** running on the inherently async ASP.NET Core pipeline (similar to the AMQP exemption for Event Hubs/Service Bus). If an analyzer flags AZC0004, suppress it with justification in `AssemblyInfo.cs`.
- All async methods MUST accept `CancellationToken cancellationToken = default` as the last parameter.
- Never block on async code (`Task.Result`, `.Wait()`, `.GetAwaiter().GetResult()`).

### VII. Thread Safety & Immutability

- Public service types must be **thread-safe** — instances may be shared across threads and stored as singletons in DI containers.
- Service types should be effectively immutable after construction.

### VIII. Designed for Testability & Mocking

- Consumers must be able to mock library types in their own test suites without calling real services.
- Provide `protected` parameterless constructors on public types to enable mocking frameworks.
- Make all public service methods `virtual` so they can be overridden in mocks.
- Provide a static model factory for constructing model types that have no public constructors.

### IX. Observability & Security

- Use `Microsoft.Extensions.Logging.ILogger` for all diagnostic output. Never write to `Console`.
- Use structured logging placeholders (`{RequestId}`, not string interpolation).
- Instrument key operations with `System.Diagnostics.Activity` for OpenTelemetry-compatible distributed tracing.
- **Never** log credentials, tokens, keys, or PII. Sanitize error messages exposed to callers.

### X. Simplicity & YAGNI

- Start with the simplest correct implementation. Do not build speculative features.
- Prefer composition over inheritance. Prefer interfaces over abstract base classes.
- If a design decision can be deferred without harm, defer it.
- Code should be readable by an unfamiliar developer within 5 minutes of opening a file.

---

## 1. Project Architecture

| Project | Path | Description |
|---|---|---|
| **Hosting** | `Azure.AI.AgentServer.Hosting/src/` | Shared hosting foundation: AgentHost, AgentHostBuilder, OpenTelemetry, server user-agent header, health endpoint |
| **Hosting Tests** | `Azure.AI.AgentServer.Hosting/tests/` | NUnit tests for Hosting |
| **Invocations** | `Azure.AI.AgentServer.Invocations/src/` | Invocations protocol library: InvocationHandler, session resolution, client header forwarding |
| **Invocations Tests** | `Azure.AI.AgentServer.Invocations/tests/` | NUnit tests for Invocations |
| **Responses.Contracts** | `Azure.AI.AgentServer.Responses.Contracts/src/` | TypeSpec-generated model contracts for Responses protocol |
| **Responses** | `Azure.AI.AgentServer.Responses/src/` | Responses protocol library (hosting extensions, streaming, handlers) |
| **Responses Tests** | `Azure.AI.AgentServer.Responses/tests/` | NUnit tests for Responses protocol |

> **Out of scope**: `Azure.AI.AgentServer.Core`, `Azure.AI.AgentServer.Contracts`, and `Azure.AI.AgentServer.AgentFramework` are legacy projects slated for deprecation. Do not invest effort in them.

Solution file: `Azure.AI.AgentServer.sln`

### Per-protocol AGENTS.md files

Each protocol has its own `AGENTS.md` with protocol-specific contract compliance, package rules, and implementation details:

| Protocol | AGENTS.md | Status |
|---|---|---|
| **Hosting** | Covered by this top-level AGENTS.md | Active |
| **Invocations** | Covered by this top-level AGENTS.md | Active |
| **Responses** | [Azure.AI.AgentServer.Responses/AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/AGENTS.md) | Active |

> When adding a new protocol, create an `AGENTS.md` in the protocol project directory following the same structure.

## 2. Azure SDK Compliance References

Do **not** duplicate repo-wide rules here. Instead, consult these canonical sources:

| Topic | Canonical Source |
|---|---|
| Contributing & prerequisites | [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) |
| Code style (StyleCop) | [eng/stylecop.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/stylecop.json) |
| Code analysis rules | [eng/CodeAnalysis.ruleset](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/CodeAnalysis.ruleset) |
| Target frameworks (`RequiredTargetFrameworks`, etc.) | [eng/Directory.Build.Common.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/Directory.Build.Common.props) |
| Library project template & conventions | [sdk/template/Azure.Template/](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template) |
| Central package management | [eng/centralpackagemanagement/README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/README.md) |
| Pre-commit checks (`dotnet format`, API export, snippets) | [.github/skills/pre-commit-checks/SKILL.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/pre-commit-checks/SKILL.md) |
| Test framework (recorded tests, mocking) | [sdk/core/Azure.Core.TestFramework/README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md) |
| Copilot / agent-specific instructions | [.github/copilot-instructions.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/copilot-instructions.md) |
| Versioning strategy | [doc/dev/Versioning.md](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/Versioning.md) |
| API listing targets | [eng/ApiListing.targets](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/ApiListing.targets) |

## 3. Build, Test & Finalize

All commands run from `sdk/agentserver/`:

```bash
# Build
dotnet build Azure.AI.AgentServer.sln

# Test (excludes live tests)
dotnet test Azure.AI.AgentServer.sln --filter TestCategory!=Live

# Lint (verify formatting — fails on violations)
dotnet format Azure.AI.AgentServer.sln --verify-no-changes

# Fix formatting
dotnet format Azure.AI.AgentServer.sln
```

### Pre-commit checks

Before committing changes, run the pre-commit validations for the `agentserver` service directory.
See [pre-commit-checks SKILL.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/pre-commit-checks/SKILL.md) for the full procedure. Summary:

```powershell
# Format
dotnet format Azure.AI.AgentServer.sln

# Export public API
eng/scripts/Export-API.ps1 agentserver

# Update doc snippets
eng/scripts/Update-Snippets.ps1 agentserver

# Build snippets (reproduces the CI "Build snippets" step locally)
# This defines the SNIPPET constant and verifies all #region Snippet:Name
# code compiles. MUST be run before committing snippet changes.
cd sdk/agentserver
dotnet build Azure.AI.AgentServer.sln /p:BuildSnippets=true
```

### Regenerate Contracts (TypeSpec)

```powershell
# Prerequisites: Node.js, Python 3 + pyyaml
# Regenerate (deps installed automatically via tsp-client sync + npm install)
./scripts/Generate-Contracts.ps1
```

TypeSpec dependencies are resolved from the repo-level emitter package
(`eng/http-client-csharp-emitter-package.json`) via `emitterPackageJsonPath`
in `tsp-location.yaml`. There is no standalone `package.json` in this directory.

## 4. Samples & Snippet System

### How compiled snippets work

Samples in markdown are sourced from compiled C# test files via the repo's snippet system.
See [CONTRIBUTING.md — Updating Sample Snippets](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets) for the canonical reference, including `#region Snippet:Name` and the `Update-Snippets.ps1` tool.

**Key rule:** Never edit code inside `` ```C# Snippet:Name `` fences in markdown. Edit the `.cs` source file, then run `eng/scripts/Update-Snippets.ps1 agentserver`.

**No `#if SNIPPET` blocks.** CI builds snippet files with `/p:BuildSnippets=true`, which defines the `SNIPPET` preprocessor constant. Code inside `#if SNIPPET` blocks must compile in that mode, but method-scoped `using` directives and references to `args` (which only exists in top-level statements) are illegal. Instead, write snippet code that compiles directly — `AgentHost.Run<T>()` and `AgentHost.CreateBuilder()` accept optional `args` so no workaround is needed.

### `AgentHost` namespace design and global using

All Hosting types — `AgentHost`, `AgentHostBuilder`, `AgentHostApp`, `AgentHostOptions`, `AgentHostTelemetry`, and `AgentHostMiddlewareExtensions` — live in namespace `Azure.AI.AgentServer.Hosting`.

The Hosting NuGet package ships `build/` and `buildTransitive/` `.props` files that inject a **global using** for this namespace. This means:

- **Zero-import one-liner**: consumers who install any protocol package (Responses, Invocations) get `AgentHost` resolved automatically — no `using` statement needed for the entry point.
- **Transitive reach**: because `buildTransitive/` is included, the global using flows to consumers who never directly reference `Azure.AI.AgentServer.Hosting`.

For **test projects** that use `<ProjectReference>` (which does _not_ trigger NuGet build props), each test `.csproj` adds `<Using Include="Azure.AI.AgentServer.Hosting" />` to mirror the NuGet consumer experience.

### Snippet test project references

Snippet tests may reference types from **other** AgentServer packages (e.g., Invocations snippets using `AgentHost.Run` from Hosting, or Hosting snippets using `IResponseHandler` from Responses). The test `.csproj` must include project references to all packages used by snippet code. Current required references:

| Test Project | Extra References Needed |
|---|---|
| `Responses.Tests` | `Hosting` (for `AgentHost.Run`, `AgentHost.CreateBuilder`) |
| `Invocations.Tests` | `Hosting` (for `AgentHost.Run`, `AgentHost.CreateBuilder`) |
| `Hosting.Tests` | `Responses` (for `IResponseHandler`, `ResponseEventStream`), `Invocations` (already present) |

### Snippet test conventions

- Mark snippet test classes with `[Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]`
- Handler classes used as snippets go **outside** test methods as nested types wrapped in `#region Snippet:Name`
- Server startup code goes **inside** test methods wrapped in `#region Snippet:Name`
- **Never use `#if SNIPPET`** — write code that compiles in both normal and snippet build modes
- Use parameterless overloads (`AgentHost.Run<T>()`, `AgentHost.CreateBuilder()`) instead of passing `args`
- Each sample markdown file gets its own `<SampleN>Snippets.cs` backing file
- Each README gets a `ReadMeSnippets.cs` backing file
- **Always verify locally** with `dotnet build /p:BuildSnippets=true` before committing

## 5. Analyzer Suppression Rules

### AZC0012 (single-word type names)

TypeSpec-generated models with generic names (e.g., `Response`, `Error`, `Prompt`) trigger AZC0012. Suppress these with **type-scoped** `[assembly: SuppressMessage]` entries in `Responses.Contracts/src/Suppression.cs` — never use blanket `<NoWarn>` in the `.csproj`.

**When adding new generated types:** check if any new type name triggers AZC0012 by building. If so, add a scoped entry to `Suppression.cs`. The full list of suppressed types must be maintained there.

### AZC0014 (generic parameter names)

Validator files in `Generated/Validators/` use generic parameter names that trigger AZC0014. Each validator file has `#pragma warning disable AZC0014` in its header. The `scripts/generate-validators.py` generator emits this pragma automatically. Never suppress AZC0014 via `<NoWarn>` in the `.csproj`.

### Target framework conditions

Use `$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net8.0'))` — **never** `$(TargetFramework) != 'net462'` or similar brittle string comparisons.

## 6. `.docsettings.yml` Rules

- **Never modify the `required_readme_sections` regex** in `eng/.docsettings.yml`. It is shared repo-wide.
- Our README titles use "library for .NET" (not "client library for .NET") because these are server-side hosting libraries. This intentionally doesn't match the title regex.
- Our READMEs omit "Authenticate the Client" because there is no client to authenticate.
- Both issues are suppressed via `known_content_issues` entries with the reason: `'Server-side library - title and auth section do not match client SDK pattern'`.
- If you add a new package, add its README to `known_content_issues` with the same reason.

## 7. Do NOT

- Expose internal implementation details in the public API.
- Add NuGet dependencies without justification (see Principle III).
- Skip tests — TDD is non-negotiable (Principle IV).
- Skip E2E protocol tests for API behaviour changes (Principle IV).
- Create standalone executable projects — this is a library (Principle I).
- Use `Task.Result`, `.Wait()`, or `.GetAwaiter().GetResult()` (Principle VI).
- Log credentials, tokens, keys, or PII (Principle IX).
- Modify contract docs to match code — fix the code instead (Principle V).
- Use blind `Task.Delay()` for test synchronization (Principle IV).
- Add `InternalsVisibleTo` for non-test assemblies. `InternalsVisibleTo` must only grant access to test assemblies (e.g., `*.Tests`). When another production assembly needs to construct types with `internal` constructors, use the public model factory (`AzureAIAgentServerResponsesModelFactory` via `static using`) or add a public constructor/factory method via partial-class customization.

## 8. Governance

- This `AGENTS.md` (including Section 0: Core Principles) is the **supreme governing document** for the AgentServer library. It supersedes informal practices and ad-hoc decisions.
- Per-protocol `AGENTS.md` files inherit and extend these principles for their specific protocol. They may add protocol-specific rules but may **not** weaken or override the core principles.
- All PRs and code reviews must verify compliance with these principles.
- Amendments require: (1) written proposal with rationale, (2) update to any affected docs for consistency.
