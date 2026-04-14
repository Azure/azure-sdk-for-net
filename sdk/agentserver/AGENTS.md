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
| **Core** | `Azure.AI.AgentServer.Core/src/` | Shared foundation: `AgentHost`, `AgentHostBuilder`, OpenTelemetry, user-agent header, health endpoint |
| **Core Tests** | `Azure.AI.AgentServer.Core/tests/` | NUnit tests for Core |
| **Invocations** | `Azure.AI.AgentServer.Invocations/src/` | Invocations protocol: `InvocationHandler`, session resolution, client header forwarding |
| **Invocations Tests** | `Azure.AI.AgentServer.Invocations/tests/` | NUnit tests for Invocations |
| **Responses** | `Azure.AI.AgentServer.Responses/src/` | Responses protocol: TypeSpec-generated models, hosting extensions, SSE streaming, handlers |
| **Responses Tests** | `Azure.AI.AgentServer.Responses/tests/` | NUnit tests for Responses |

> **Removed**: The legacy `Azure.AI.AgentServer.Contracts` and
> `Azure.AI.AgentServer.AgentFramework` projects have been removed from this
> repository. They are superseded by the Responses and Invocations packages above.

**Solution file**: `Azure.AI.AgentServer.sln`

### Per-protocol AGENTS.md

| Protocol | Location | Notes |
|---|---|---|
| Core / Invocations | This file | — |
| Responses | `Azure.AI.AgentServer.Responses/AGENTS.md` | Contract compliance (B1–B39, S-001–S-052) |

> When adding a new protocol, create an `AGENTS.md` in the protocol directory.

**AI agent instruction (MANDATORY):** Before modifying any file under a package
directory listed above that has its own `AGENTS.md`, **read that file in full**
and follow its rules in addition to this file. The per-protocol `AGENTS.md` contains
package-specific rules (spec contracts, model governance, testing requirements)
that are **not** duplicated here. Failure to load the per-protocol file risks
introducing spec-violating code.

### Authoritative spec documents

The AgentServer libraries implement specifications maintained in an external repo.
These docs define the contract for **all** packages — individual protocol specs
are listed in the per-protocol `AGENTS.md` files.

| Document | Location | Scope |
|----------|----------|-------|
| **Container Image Spec** | `/tmp/foundrysdk_specs/specs/hosted-agents/container-spec/docs/container-image-spec.md` | All packages — networking, health probe, env vars, observability, graceful shutdown, identity header |
| **Package Architecture** | `/tmp/foundrysdk_specs/specs/hosted-agents/container-spec/docs/package-architecture.md` | All packages — package layering, developer tiers (zero-config → spec-only), dependency graph |
| **Tools Integration Spec** | `/tmp/foundrysdk_specs/specs/hosted-agents/container-spec/docs/tools-integration-spec.md` | All packages — tool call routing, function execution, tool result reporting |
| **Invocation Protocol Spec** | `/tmp/foundrysdk_specs/specs/hosted-agents/container-spec/docs/invocation-protocol-spec.md` | Invocations package — invocation endpoint protocol, session resolution, client header forwarding |
| **Handler Implementation Guide** | `docs/handler-implementation-guide.md` | All packages — handler contract, builder pattern, cancellation, error handling, configuration |

> **Dev setup**: Run `pwsh -File scripts/Bootstrap-Copilot.ps1` from `sdk/agentserver/` — it auto-clones the specs repo to `/tmp/foundrysdk_specs`. The repo requires EMU auth; the script skips gracefully if access is denied. Use `-Clean` to remove all generated artifacts.

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
| `[assembly: SuppressMessage]` in `Suppression.cs` | Type-scoped rules (AZC0012) | `Responses/src/Suppression.cs` |
| `#pragma warning disable` in file header | Generated file rules (AZC0014) | Emitted by `generate-validators.py` |
| `<DisableEnhancedAnalysis>true</DisableEnhancedAnalysis>` | Projects that are 90%+ generated code | `Responses` csproj |
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

Run these **in this exact order** before every commit. Order matters — tests must
run **first** to catch regressions before any formatting work, and `dotnet format`
must run **last** so it catches formatting issues introduced by earlier steps.

Step 1 runs from `sdk/agentserver/`; steps 2–3 run from the **repo root**;
steps 4–5 run from `sdk/agentserver/`.

```powershell
# 1. Run tests FIRST  (from sdk/agentserver/ — catches regressions before formatting)
cd sdk/agentserver
dotnet test Azure.AI.AgentServer.sln --filter TestCategory!=Live

# 2. Export public API  (from repo root)
eng/scripts/Export-API.ps1 agentserver

# 3. Update doc snippets  (from repo root — syncs #region blocks into markdown)
eng/scripts/Update-Snippets.ps1 agentserver

# 4. Build snippets  (from sdk/agentserver/ — reproduces CI "Build snippets" step)
cd sdk/agentserver
dotnet build Azure.AI.AgentServer.sln /p:BuildSnippets=true

# 5. Format LAST  (from sdk/agentserver/ — catches indent/whitespace from all prior steps)
dotnet format Azure.AI.AgentServer.sln
```

**Why tests first?** Lifecycle validation, protocol compliance, and handler logic
bugs are only caught by tests — not by formatting or API export. Running tests
first prevents pushing regressions that pass all static checks but fail at runtime.

**Why format last?** Steps 2–4 may modify files (API listings, snippet markdown, or
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

### E2E tests for sample handlers (mandatory)

Compiled snippet tests only verify that sample code **compiles** — they do not
run the handler or send HTTP requests. Every sample handler **must** also have
a matching end-to-end test in `<Package>/tests/SampleEndToEndTests.cs` that:

1. Registers the actual handler class from the snippet file into an in-memory
   test server (via `TestWebApplicationFactory` or `WebApplication.CreateBuilder()`
   + `UseTestServer()`).
2. Sends a real HTTP request to the handler endpoint.
3. Asserts on response status, content, headers, or SSE event structure.

| Package | E2E test file | Pattern |
|---|---|---|
| Responses | `tests/SampleEndToEndTests.cs` | `TestWebApplicationFactory` with `configureTestServices` to register the snippet handler |
| Invocations | `tests/SampleEndToEndTests.cs` | `WebApplication.CreateBuilder()` + `UseTestServer()` + `AddScoped<InvocationHandler, T>` |
| Core | `tests/SampleEndToEndTests.cs` | `AgentHost.CreateBuilder()` + `UseTestServer()` + `RegisterProtocol` |

**When adding or modifying a sample:**
- Add/update the snippet test (compilation guard) **and** the E2E test (behavioral guard).
- Run `dotnet test --filter SampleEndToEndTests` on the relevant test project before committing.
- If a sample handler uses DI (e.g., `IKnowledgeBase`), register the mock/test
  implementation in the E2E test's service configuration.
| Invocations.Tests | Core (`AgentHost.CreateBuilder`) |
| Core.Tests | Responses (`ResponseHandler`, `ResponseEventStream`), Invocations |

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
| `InternalsVisibleTo` from library → tests only | Ensure internal types use `@@usage(..., Usage.input \| Usage.output)` in `client.tsp` or public model factory for external consumers |

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
| Using `git rebase` | **Always use `git merge`**, never rebase. This is a strict project rule. |
| Running piecemeal generation steps (`tsp compile`, `npx` individually) | **Always use the full pipeline script** (e.g., `Generate-Contracts.ps1`). Never execute individual steps — the script handles sequencing, cleanup, and copyright headers. |

### 5.9 External SDK verification

| Mistake | Fix |
|---|---|
| Guessing external SDK API names (method names, property names, enum values) | **Decompile the actual SDK assembly** to verify names before writing code. Use `ilspycmd` or equivalent. Never guess — the OpenAI SDK renames and reshapes types from the spec. |
| Trusting TypeSpec-generated type names without investigation when interop issues arise | Azure TypeSpec is intentionally a superset of OpenAI \u2014 extra types are expected. But when a type causes **interop issues or contradicts the spec description**, investigate whether it is an intentional extension or an authoring mistake. See Responses `AGENTS.md` \u00a75 for the `output_message` case study. || Assuming the correct resolution for OpenAI compat conflicts | **Always confirm with the user** before making TypeSpec (`client.tsp`), service-layer, or wire-format changes to resolve an OpenAI compat conflict. Present findings and proposed actions for approval — do not assume correctness. The user has domain knowledge about intentional vs. unintentional Azure TypeSpec deviations. || Bulk `sed` renames without verification | After any bulk text replacement, **always run a second-pass grep sweep** to verify zero remaining old references. Build immediately after to catch type/parameter mismatches that text replacement cannot detect. |

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
- Use `git rebase` — always use `git merge` (see §5.8).
- Run generation steps individually — always use the full pipeline script (see §5.8).
- Guess external SDK API names — decompile and verify (see §5.9).
- Assume the correct fix for OpenAI compat conflicts — always confirm with the user first (see §5.9).

---

## 8. Governance

- This `AGENTS.md` (including Section 0) is the **supreme governing document** for the
  AgentServer library. It supersedes informal practices and ad-hoc decisions.
- Per-protocol `AGENTS.md` files inherit and extend these principles. They may add
  protocol-specific rules but may **not** weaken or override the core principles.
- All PRs and code reviews must verify compliance with these principles.
- Amendments require: (1) written proposal with rationale, (2) update to any affected
  docs for consistency.

### 8.1 Continuous learning (MANDATORY)

This `AGENTS.md` (and its per-protocol children) should be a **living document** that captures generalized patterns discovered during development sessions. When the user corrects the agent or suggests a reusable pattern:

1. **Recognize** generalized lessons that would benefit future sessions (not one-off fixes).
2. **Do NOT update AGENTS.md automatically.** At the end of the session, propose the specific additions to the user — explain what you learned, where you would add it, and why it is generalizable.
3. **Seek explicit confirmation** from the user before making any edits. Ask clarifying questions if the scope or framing is unclear.
4. **Only after user approval**, add the rule to the appropriate `AGENTS.md` file(s) with clear context.

This ensures AGENTS.md stays accurate and reflects the user's intent, not the agent's assumptions.
