# AGENTS.md — Azure.AI.AgentServer

> For general AI agent guidelines, safety boundaries, and repo-wide workflows,
> see the root [AGENTS.md](../../AGENTS.md).

## 1. Project Architecture

| Project | Path | Description |
|---|---|---|
| **Responses.Contracts** | `Azure.AI.AgentServer.Responses.Contracts/src/` | TypeSpec-generated model contracts (all generated models, internal helpers, customizations) |
| **Responses** | `Azure.AI.AgentServer.Responses/src/` | Hand-written SDK library (builders, hosting extensions, `IResponseHandler`, streaming plumbing). References Contracts. |
| **Tests** | `Azure.AI.AgentServer.Responses/tests/` | NUnit tests — protocol tests in `Protocol/`, provider tests in `Provider/`, builder tests in `Builder/` |
| **Core** | `Azure.AI.AgentServer.Core/src/` | Shared core types |
| **Contracts** | `Azure.AI.AgentServer.Contracts/src/` | Shared contract types |
| **AgentFramework** | `Azure.AI.AgentServer.AgentFramework/src/` | Agent framework library |

Solution file: `Azure.AI.AgentServer.sln` (includes Contracts, Responses, Tests).

### Key namespaces

- `Azure.AI.AgentServer.Responses` — public API surface
- `Azure.AI.AgentServer.Responses.Models` — model types (from Contracts)
- `Azure.AI.AgentServer.Responses.Internal` — internal implementation (e.g., `SeekableReplaySubject`)

## 2. Azure SDK Compliance References

Do **not** duplicate repo-wide rules here. Instead, consult these canonical sources:

| Topic | Canonical Source |
|---|---|
| Contributing & prerequisites | [CONTRIBUTING.md](../../CONTRIBUTING.md) |
| Code style (StyleCop) | [eng/stylecop.json](../../eng/stylecop.json) |
| Code analysis rules | [eng/CodeAnalysis.ruleset](../../eng/CodeAnalysis.ruleset) |
| Target frameworks (`RequiredTargetFrameworks`, etc.) | [eng/Directory.Build.Common.props](../../eng/Directory.Build.Common.props) |
| SDK project template & conventions | [sdk/template/Azure.Template/](../../sdk/template/Azure.Template/) |
| Central package management | [eng/centralpackagemanagement/README.md](../../eng/centralpackagemanagement/README.md) |
| Pre-commit checks (`dotnet format`, API export, snippets) | [.github/skills/pre-commit-checks/SKILL.md](../../.github/skills/pre-commit-checks/SKILL.md) |
| Test framework (recorded tests, mocking) | [sdk/core/Azure.Core.TestFramework/README.md](../../sdk/core/Azure.Core.TestFramework/README.md) |
| Copilot / agent-specific instructions | [.github/copilot-instructions.md](../../.github/copilot-instructions.md) |
| Versioning strategy | [doc/dev/Versioning.md](../../doc/dev/Versioning.md) |
| API listing targets | [eng/ApiListing.targets](../../eng/ApiListing.targets) |

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
See [pre-commit-checks SKILL.md](../../.github/skills/pre-commit-checks/SKILL.md) for the full procedure. Summary:

```powershell
# Format
dotnet format Azure.AI.AgentServer.sln

# Export public API
eng/scripts/Export-API.ps1 agentserver

# Update doc snippets
eng/scripts/Update-Snippets.ps1 agentserver
```

### Regenerate Contracts (TypeSpec)

```powershell
# Prerequisites: Node.js, Python 3 + pyyaml
# Install npm deps (one-time)
npm install

# Regenerate
./scripts/Generate-Contracts.ps1
```

> **Note**: The TypeSpec pipeline currently uses a standalone `package.json` with pinned
> dependencies. This is a known deviation from the repo-standard pattern of
> repo-level emitter packages + `tsp-location.yaml` with `emitterPackageJsonPath`.
> Alignment is tracked for a future PR.

## 4. Package-Specific Rules

### Dependency isolation
- **Responses** depends only on **Responses.Contracts** (project reference) plus `Microsoft.AspNetCore.App` (framework reference). No additional NuGet packages in production.
- **Responses.Contracts** has zero NuGet dependencies.
- Test dependencies are managed via central package management with overrides in `eng/centralpackagemanagement/overrides/Azure.AI.AgentServer.Responses.Packages.props`.

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

### E2E protocol tests
Any API behaviour change **must** include protocol tests in `tests/Protocol/`. These test the full HTTP pipeline via `TestWebApplicationFactory`. Unit tests alone are insufficient.

### Deterministic test synchronization
Never use blind `Task.Delay()` for async synchronization. Use `TaskCompletionSource`, `WaitAsync(TimeSpan)`, or polling loops with explicit timeout assertions. `Task.Delay` is acceptable only to simulate slow work in handlers.
