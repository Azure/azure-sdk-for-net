# AGENTS.md — Azure.AI.AgentServer

> For general AI agent guidelines, safety boundaries, and repo-wide workflows,
> see the root [AGENTS.md](https://github.com/Azure/azure-sdk-for-net/blob/main/AGENTS.md).

---

## 0. Core principles

These principles govern **all** work under `sdk/agentserver/`. They are the **supreme
governing rules** — they supersede informal practices and ad-hoc decisions. When
principles conflict, resolve in this priority order:
**Protocol Fidelity > Developer Experience > Minimal API Surface > Simplicity**.

### I. Library-first (library, never application)

- This project produces **class libraries** distributed via NuGet, never a standalone executable.
- Every public type must be designed for consumption by external developers building their own ASP.NET Core hosts.
- The library owns protocol concerns (request/response models, routing, serialization, error shapes). The consumer owns business logic (tool implementations, agent behaviour).
- No global state, static mutable singletons, or assumptions about the host process.

### II. Developer experience above all

- The primary measure of success is how quickly a developer can go from `dotnet add package` to a working server.
- Integration follows standard ASP.NET Core conventions: `IServiceCollection` extensions for registration, `IEndpointRouteBuilder` extensions for routing.
- Provide sensible defaults with progressive disclosure of complexity — simple things must be simple, advanced scenarios must be possible.
- XML documentation comments are required on **all** `public` and `protected` members.

### III. Minimal public API surface

- Default visibility is `internal`. Only promote to `public` when there is a clear, justified consumer need.
- Every public type, method, and property must earn its place. Prefer fewer, well-designed abstractions over a sprawling API.
- Use `[EditorBrowsable(EditorBrowsableState.Never)]` for types that must be public for technical reasons but are not intended for direct consumer use.
- Avoid leaking implementation details into the public API.

### IV. Test-first (non-negotiable)

- **TDD is mandatory.** Write test → see it fail (red) → implement → see it pass (green) → refactor.
- All public API contracts must have corresponding unit tests.
- **E2E protocol tests are mandatory for API behaviour changes.** Any change to endpoint logic, SSE event contract, error shapes, status transitions, response headers, or HTTP status codes MUST include protocol tests that exercise the full HTTP pipeline. Unit tests alone are insufficient.
- **Deterministic synchronization is mandatory.** Never use blind `Task.Delay()` to wait for async state changes. Use `TaskCompletionSource` gates, `WaitAsync(TimeSpan)`, or polling loops with explicit timeout assertions. `Task.Delay` is acceptable only to simulate slow work in handlers.
- **Transient test failures must be fixed immediately.** A flaky test is a bug.

### V. Protocol fidelity

- Each protocol library must faithfully implement its specification. Deviations from the spec are bugs.
- API models (request/response shapes, error codes, headers) must match the specification exactly.
- The authoritative contract documents win over the code. Fix the code, not the contract.

### VI. Async-all-the-way

- The library is **async-only**. All public service methods are asynchronous.
- **AZC0004 exemption**: this is a **server-side hosting library** on the inherently async ASP.NET Core pipeline (similar to Event Hubs / Service Bus AMQP exemption). Suppress AZC0004 with justification in `AssemblyInfo.cs` if flagged.
- All async methods MUST accept `CancellationToken cancellationToken = default` as the last parameter.
- Never block on async code (`Task.Result`, `.Wait()`, `.GetAwaiter().GetResult()`).

### VII. Thread safety & immutability

- Public service types must be **thread-safe** — instances may be shared across threads as DI singletons.
- Service types should be effectively immutable after construction.

### VIII. Designed for testability & mocking

- Provide `protected` parameterless constructors on public types to enable mocking frameworks.
- Make all public service methods `virtual` so they can be overridden in mocks.
- Provide a static model factory for constructing model types that have no public constructors.

### IX. Observability & security

- Use `ILogger` for all diagnostic output. Never write to `Console`.
- Use structured logging placeholders (`{RequestId}`, not string interpolation).
- Instrument key operations with `System.Diagnostics.Activity` for distributed tracing.
- **Never** log credentials, tokens, keys, or PII.

### X. Simplicity & YAGNI

- Start with the simplest correct implementation. Do not build speculative features.
- Prefer composition over inheritance. Prefer interfaces over abstract base classes.
- Code should be readable by an unfamiliar developer within 5 minutes.

---

## 1. Project architecture

| Project | Path | Description |
|---|---|---|
| **Core** | `Azure.AI.AgentServer.Core/src/` | Shared hosting foundation: `AgentHost`, `AgentHostBuilder`, OpenTelemetry, user-agent header, health endpoint |
| **Core Tests** | `Azure.AI.AgentServer.Core/tests/` | NUnit tests for Core |
| **Invocations** | `Azure.AI.AgentServer.Invocations/src/` | Invocations protocol: `InvocationHandler`, session resolution, client header forwarding |
| **Invocations Tests** | `Azure.AI.AgentServer.Invocations/tests/` | NUnit tests for Invocations |
| **Responses.Contracts** | `Azure.AI.AgentServer.Responses.Contracts/src/` | TypeSpec-generated model contracts for Responses protocol |
| **Responses** | `Azure.AI.AgentServer.Responses/src/` | Responses protocol: hosting extensions, SSE streaming, handlers |
| **Responses Tests** | `Azure.AI.AgentServer.Responses/tests/` | NUnit tests for Responses |

> **Removed**: The legacy `Azure.AI.AgentServer.Contracts` and
> `Azure.AI.AgentServer.AgentFramework` projects have been removed from this
> repository. They are superseded by the Responses and Invocations packages above.

**Solution file**: `Azure.AI.AgentServer.sln`

### Per-protocol AGENTS.md

| Protocol | Location | Notes |
|---|---|---|
| Core / Invocations | This file | — |
| Responses | `Azure.AI.AgentServer.Responses/AGENTS.md` | Contract compliance (B1–B37, S-001–S-046) |

> When adding a new protocol, create an `AGENTS.md` in the protocol directory.

---

## 2. Azure SDK compliance (mandatory)

This library is part of the Azure SDK for .NET. All code under `sdk/agentserver/` **must**
comply with the repository-wide rules below. These are not guidelines — they are
merge requirements enforced by CI, code review, and the Azure SDK architects.

### 2.1 Use the repo standard — no custom overrides

| Do NOT create | Why |
|---|---|
| Custom `.editorconfig` | Use the repo-wide config |
| Custom `.devcontainer/` | Use the repo-wide definition; propose additions via PR if needed |
| `Makefile` | All scripts must be PowerShell (`.ps1`) for cross-platform parity |
| Shell scripts (`.sh`) in production | PowerShell only; `.sh` is acceptable only for test helpers that will not ship |

### 2.2 Target frameworks

| Project type | Property to use | Example |
|---|---|---|
| Class libraries (Contracts) | `$(RequiredTargetFrameworks)` | `netstandard2.0;net8.0;net10.0` |
| ASP.NET libraries (Core, Responses, Invocations) | `$(RequiredRunnableTargetFrameworks)` | `net8.0;net10.0` |
| Test projects | Inherited from repo defaults | — |

**Never hard-code target framework monikers.** The variables are defined in
`eng/Directory.Build.Common.props` and track the repo's supported TFM set.

For conditional `<ItemGroup>` blocks, use
`$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net8.0'))` — never
string comparisons like `$(TargetFramework) != 'net462'`.

### 2.3 Analyzer suppressions

**Blanket `<NoWarn>` in production `.csproj` files is forbidden.** Suppress only via:

| Mechanism | When to use | Example |
|---|---|---|
| `[assembly: SuppressMessage]` in `Suppression.cs` | Type-scoped rules (AZC0012) | `Responses.Contracts/src/Suppression.cs` |
| `#pragma warning disable` in file header | Generated file rules (AZC0014) | Emitted by `generate-validators.py` |
| `<DisableEnhancedAnalysis>true</DisableEnhancedAnalysis>` | Projects that are 90%+ generated code | `Responses.Contracts` csproj |
| `Generated/Directory.Build.props` | Suppress rules for entire `Generated/` folder | StyleCop, CS1591 in generated code |

**Test `.csproj` NoWarn** — match the repo template exactly: `<NoWarn>$(NoWarn);CS1591</NoWarn>`. No extra codes. If a test triggers an analyzer, fix the code rather than suppressing.

**Client SDK analyzers** — enable only for production code. In `Directory.Build.props`:

```xml
<EnableClientSdkAnalyzers Condition="'$(IsTestProject)' != 'true'">true</EnableClientSdkAnalyzers>
```

**AZC0012** (single-word type names) — suppress with type-scoped `[assembly: SuppressMessage]` entries in `Suppression.cs`. When adding a new generated type, build and check for warnings; add to `Suppression.cs` if triggered.

**AZC0014** (STJ types in public API) — Azure SDK libraries must not expose `System.Text.Json` types publicly. For generated validators that accept `JsonElement` (server-side JSON validation, not client serialization), the `#pragma` is emitted by the generator. If the architects flag this, be prepared to discuss the server-side rationale.

**AZC0150** (AOT compatibility) — fix, don't suppress. Use `AzureAIAgentServerResponsesContext.Default` for `ModelReaderWriter` calls.

### 2.4 Central package management

- **Production dependencies** → `eng/centralpackagemanagement/Directory.Packages.props`
- **Test-only dependencies** → `eng/centralpackagemanagement/Directory.Support.Packages.props`
- **Package-specific overrides** (e.g., NUnit 4.4) → `eng/centralpackagemanagement/overrides/<PackageName>.Packages.props`
- **Alpha/preview dependencies** are not permitted in stable releases and require architect sign-off for beta.
- **Unapproved dependencies** must be isolated to package-specific overrides, not added globally.

### 2.5 InternalsVisibleTo

`InternalsVisibleTo` must only grant access to **test assemblies** (`*.Tests`).

When another production assembly needs internal types, eliminate the cross-library dependency:
- Add `@@usage(..., Usage.input | Usage.output)` in `client.tsp` for public constructors on generated models.
- Use the public model factory (`AzureAIAgentServerResponsesModelFactory`).
- Add a public constructor or factory method via partial-class customization.

### 2.6 Copyright headers

Every `.cs` file — hand-written and generated — must start with:

```csharp
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
```

Code generators (`Generate-Contracts.ps1`, `generate-validators.py`) must emit this header automatically.

### 2.7 Documentation and branding

| Rule | Correct | Wrong |
|---|---|---|
| Individual package | "library" or "client library" | "SDK" (reserved for the collection) |
| Heading style | Sentence case: "Getting started" | Title Case: "Getting Started" |
| Style guide | [Microsoft Writing Style Guide](https://learn.microsoft.com/style-guide/welcome/) | — |
| README template | [sdk/template/Azure.Template/README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/README.md) | Free-form layout |

**`.docsettings.yml` rules:**
- Never modify the `required_readme_sections` regex in `eng/.docsettings.yml` — it is repo-wide.
- Our READMEs use "library for .NET" (not "client library for .NET") — these are server-side hosting libraries.
- Our READMEs omit "Authenticate the Client" — there is no client.
- Both are suppressed via `known_content_issues` entries.
- When adding a new package, add its README with the same suppression reason.

### 2.8 NUnit version

Use **NUnit 4.4** with `Assert.That()` constraint-based syntax. Override via:

```
eng/centralpackagemanagement/overrides/Azure.AI.AgentServer.Responses.Packages.props
```

All assertions must use the constraint model (`Assert.That(x, Is.EqualTo(y))`), never the classic API (`Assert.AreEqual`).

---

## 3. Build, test & pre-commit

All commands run from `sdk/agentserver/`.

### Quick reference

```bash
# Build
dotnet build Azure.AI.AgentServer.sln

# Test (excludes live tests)
dotnet test Azure.AI.AgentServer.sln --filter TestCategory!=Live

# Verify formatting (fails on violations)
dotnet format Azure.AI.AgentServer.sln --verify-no-changes

# Fix formatting
dotnet format Azure.AI.AgentServer.sln
```

### Pre-commit checks (strict ordering)

Run these **in this exact order** before every commit. Order matters — `dotnet format`
must run **last** so it catches formatting issues introduced by earlier steps.

Steps 1–2 run from the **repo root**; steps 3–4 run from `sdk/agentserver/`.

```powershell
# 1. Export public API  (from repo root)
eng/scripts/Export-API.ps1 agentserver

# 2. Update doc snippets  (from repo root — syncs #region blocks into markdown)
eng/scripts/Update-Snippets.ps1 agentserver

# 3. Build snippets  (from sdk/agentserver/ — reproduces CI "Build snippets" step)
cd sdk/agentserver
dotnet build Azure.AI.AgentServer.sln /p:BuildSnippets=true

# 4. Format LAST  (from sdk/agentserver/ — catches indent/whitespace from all prior steps)
dotnet format Azure.AI.AgentServer.sln
```

**Why format last?** Steps 1–3 may modify files (API listings, snippet markdown, or
code via scripts like `sed`). Running format first would miss those changes. The CI
"Build snippets" step defines the `SNIPPET` preprocessor constant — snippet code must
compile in that mode.

See [pre-commit-checks SKILL.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/pre-commit-checks/SKILL.md) for the full procedure.

### Regenerate contracts (TypeSpec)

```powershell
./scripts/Generate-Contracts.ps1
```

Prerequisites: Node.js, Python 3 + `pyyaml`. Dependencies are installed automatically
via `tsp-client sync` + `npm install`. TypeSpec dependencies resolve from the repo-level
emitter package (`eng/http-client-csharp-emitter-package.json`) via `emitterPackageJsonPath`
in `tsp-location.yaml`.

---

## 4. Samples & snippet system

### How compiled snippets work

All C# code in markdown must be **compiled snippets** with backing `.cs` test files.
Inline (non-snippet) code blocks in markdown are only acceptable for non-C# content
(e.g., `curl` commands, `dotnetcli` install commands).

See [CONTRIBUTING.md — Updating Sample Snippets](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md#updating-sample-snippets).

**Golden rule:** Never edit code inside snippet-backed code fences in markdown.
Edit the `.cs` source file, then run `eng/scripts/Update-Snippets.ps1 agentserver`.

### Snippet file conventions

| Rule | Detail |
|---|---|
| Location | `<Package>/tests/Snippets/<SampleN>Snippets.cs` per sample, `ReadMeSnippets.cs` per README |
| Test attribute | `[Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]` |
| Handler snippets | Nested types **outside** test methods, wrapped in named `#region` / `#endregion` blocks |
| Startup snippets | **Inside** test methods, wrapped in named `#region` / `#endregion` blocks |
| `#if SNIPPET` | **Never** — code must compile in both normal and `BuildSnippets=true` modes (see below) |
| `args` parameter | Use parameterless overloads: `ResponsesServer.Run<T>()`, `AgentHost.CreateBuilder()` |
| Local verification | `dotnet build /p:BuildSnippets=true` before every commit |

### Why `#if SNIPPET` is banned

CI builds snippet files with `/p:BuildSnippets=true`, which defines the `SNIPPET`
preprocessor constant via `eng/Directory.Build.Common.props`. Code inside `#if SNIPPET`
blocks must compile in that mode, but:

- **`using` directives** inside method bodies are parsed as C# 14 "using declarations" (variable disposal), causing CS1001.
- **`args`** only exists in top-level statements, not inside test methods, causing CS0103.
- **Extension methods** from packages not available in the test context cause CS1061.

Since `ResponsesServer.Run<T>()`, `InvocationsServer.Run<T>()`, and `AgentHost.CreateBuilder()` accept optional `string[]? args = null`, no workaround is needed — write snippet code that compiles directly.

### `AgentHost` global using

The Core NuGet package ships `build/` and `buildTransitive/` `.props` files that
inject a global `using Azure.AI.AgentServer.Core;`. This gives consumers a
zero-import one-liner experience.

For **test projects** (which use `<ProjectReference>`, not triggering NuGet build props),
add `<Using Include="Azure.AI.AgentServer.Core" />` in the test `.csproj`, gated on:

```xml
<ItemGroup Condition="$([MSBuild]::IsTargetFrameworkCompatible('$(TargetFramework)', 'net8.0'))">
  <Using Include="Azure.AI.AgentServer.Core" />
</ItemGroup>
```

**Note:** The `build/` directory is matched by the root `.gitignore`. Use
`git add -f Azure.AI.AgentServer.Core/build/` to force-add those files.

### Cross-package snippet references

Snippet tests may reference types from other AgentServer packages. The test `.csproj`
must include `<ProjectReference>` entries for all packages used.

| Test Project | Extra References Needed |
|---|---|
| Responses.Tests | Core (`AgentHost.CreateBuilder`) |
| Invocations.Tests | Core (`AgentHost.CreateBuilder`) |
| Core.Tests | Responses (`IResponseHandler`, `ResponseEventStream`), Invocations |

---

## 5. Common pitfalls

Mistakes encountered during development, codified here so agents and contributors
avoid repeating them.

### 5.1 Target framework mistakes

| Mistake | Fix |
|---|---|
| Hard-coded `<TargetFrameworks>net8.0;net10.0</TargetFrameworks>` | Use `$(RequiredRunnableTargetFrameworks)` or `$(RequiredTargetFrameworks)` |
| `Condition="$(TargetFramework) != 'net462'"` | Use `$([MSBuild]::IsTargetFrameworkCompatible(...))` |

### 5.2 Blanket analyzer suppressions

| Mistake | Fix |
|---|---|
| `<NoWarn>AZC0011;AZC0012;AZC0014;...</NoWarn>` in `.csproj` | Type-scoped `[SuppressMessage]` in `Suppression.cs` |
| Suppressing AZC0150 | Fix the code: use explicit `JsonModelReaderWriterOptions` with source-gen context |
| Extra NoWarn codes in test `.csproj` | Match repo template: `$(NoWarn);CS1591` only; fix test code instead |

### 5.3 Dependency management errors

| Mistake | Fix |
|---|---|
| Adding test deps to `Directory.Packages.props` | Use `Directory.Support.Packages.props` for test-only deps |
| Adding alpha packages globally | Isolate to `overrides/<PackageName>.Packages.props`; require architect sign-off |
| Adding unapproved external deps (e.g., `System.Reactive.Async`) | Implement internally or get approval |

### 5.4 Cross-library InternalsVisibleTo

| Mistake | Fix |
|---|---|
| `InternalsVisibleTo` from Contracts → Responses | Eliminate by adding `@@usage(..., Usage.input \| Usage.output)` in `client.tsp` or using public model factory |

### 5.5 Documentation mistakes

| Mistake | Fix |
|---|---|
| Title Case headings ("Getting Started") | Sentence case ("Getting started") per Microsoft Writing Style Guide |
| Using "SDK" for individual packages | Use "library" |
| Free-form README layout | Follow the repo README template |
| Code blocks without snippet backing | Every C# block must be a compiled snippet |
| Standalone sample projects (`.csproj` + `Program.cs`) | Markdown-based samples with compiled snippet backing |

### 5.6 Snippet build failures

| Mistake | Fix |
|---|---|
| `#if SNIPPET` blocks with `using` directives | Remove all `#if SNIPPET` blocks; write code that compiles in both modes |
| Passing `args` or `args: null` in snippets | Use parameterless overloads: `ResponsesServer.Run<T>()` |
| Snippet-only code (e.g., `ConfigureHealth`) unavailable in test context | Remove or provide the dependency in the test project |
| Not running `dotnet build /p:BuildSnippets=true` locally | Add to pre-commit checklist (step 3) |

### 5.7 Formatting and whitespace

| Mistake | Fix |
|---|---|
| Running `dotnet format` before file-modifying steps | Format must run **last** in pre-commit — after Export-API, Update-Snippets, and BuildSnippets |
| Using `sed` for code changes (strips indentation) | If `sed` is unavoidable, always run `dotnet format` afterwards |

### 5.8 git and CI gotchas

| Mistake | Fix |
|---|---|
| `build/` directory not committed (root `.gitignore`) | Use `git add -f` for `build/` and `buildTransitive/` props |
| Not testing CI snippet build locally | Always run `dotnet build /p:BuildSnippets=true` before pushing |
| CI "Analyze PRBatch" / "Set diagnostic arguments" flake | Repo-wide infrastructure issue; not caused by our changes; retry |

---

## 6. Reference links

Do **not** duplicate repo-wide rules here. Consult these canonical sources:

| Topic | Canonical source |
|---|---|
| Contributing & prerequisites | [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) |
| Code style (StyleCop) | [eng/stylecop.json](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/stylecop.json) |
| Code analysis rules | [eng/CodeAnalysis.ruleset](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/CodeAnalysis.ruleset) |
| Target frameworks | [eng/Directory.Build.Common.props](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/Directory.Build.Common.props) |
| Library project template | [sdk/template/Azure.Template/](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template) |
| Central package management | [eng/centralpackagemanagement/README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/centralpackagemanagement/README.md) |
| Pre-commit checks | [.github/skills/pre-commit-checks/SKILL.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/skills/pre-commit-checks/SKILL.md) |
| Test framework | [sdk/core/Azure.Core.TestFramework/README.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core.TestFramework/README.md) |
| Copilot / agent instructions | [.github/copilot-instructions.md](https://github.com/Azure/azure-sdk-for-net/blob/main/.github/copilot-instructions.md) |
| Versioning | [doc/dev/Versioning.md](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/Versioning.md) |
| API listing targets | [eng/ApiListing.targets](https://github.com/Azure/azure-sdk-for-net/blob/main/eng/ApiListing.targets) |

---

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
- Add `InternalsVisibleTo` for non-test assemblies (see §2.5).
- Use blanket `<NoWarn>` in production `.csproj` files (see §2.3).
- Create custom `.editorconfig`, `.devcontainer`, or `Makefile` (see §2.1).
- Hard-code target framework monikers in `.csproj` (see §2.2).
- Use `#if SNIPPET` blocks in snippet test files (see §4).
- Add alpha/preview packages to global package management (see §2.4).

---

## 8. Governance

- This `AGENTS.md` (including Section 0) is the **supreme governing document** for the
  AgentServer library. It supersedes informal practices and ad-hoc decisions.
- Per-protocol `AGENTS.md` files inherit and extend these principles. They may add
  protocol-specific rules but may **not** weaken or override the core principles.
- All PRs and code reviews must verify compliance with these principles.
- Amendments require: (1) written proposal with rationale, (2) update to any affected
  docs for consistency.
