# Azure.ResourceManager.Search — Copilot Instructions

Azure AI Search management-plane SDK. Generated from OpenAPI specs via AutoRest, with hand-written customizations for backward compatibility.

> For repo-wide guidance, see the root [AGENTS.md](../../../../AGENTS.md) and [.github/copilot-instructions.md](../../../../.github/copilot-instructions.md).

## Architecture

```
src/
├── autorest.md              # Generation config: spec commit, tag, rename-mapping
├── Generated/               # Auto-generated code — NEVER edit directly
│   ├── Models/              # Data models, enums, serialization
│   ├── Extensions/          # ARM extension methods
│   └── RestOperations/      # HTTP REST operations
├── Customization/           # Hand-written partial classes for backward compat
│   ├── Models/              # Obsolete type shims, enum extensions
│   ├── SearchServiceData.cs # Convenience properties (IPRules, SkuName, PublicNetworkAccess)
│   └── ArmSearchModelFactory.cs  # Factory method overrides
tests/
├── Tests/                   # Live/recorded integration tests (NUnit)
├── SearchManagementTestBase.cs   # Base class with sanitizers and resource group helpers
api/                         # Public API surface snapshots (one per TFM)
skills/                      # Copilot skills for generation and spec analysis
```

### Code Generation Pattern

This SDK uses **AutoRest** (not TypeSpec). The generation config lives in `src/autorest.md`:
- `require:` points to a specific commit in `azure-rest-api-specs`
- `tag:` selects the API version
- `rename-mapping:` maps spec names to SDK-friendly C# names (e.g., `IpRule` → `SearchServiceIPRule`)

Generated code goes to `src/Generated/`. Customizations in `src/Customization/` use partial classes to extend generated types without modifying them. This is how breaking changes are mitigated when upgrading API versions.

### Customization Patterns

- **Obsolete property shims**: Keep removed/renamed properties via `[EditorBrowsable(EditorBrowsableState.Never)]` on partial class extensions (see `SearchServiceData.cs`)
- **Enum extensions**: Custom serialization methods like `ToSearchSkuName()` / `ToSerialString()` for backward-compat enum types
- **Model factory overrides**: `ArmSearchModelFactory.cs` provides backward-compatible factory methods when signatures change

## Build & Test Commands

All commands run from `sdk/search/Azure.ResourceManager.Search/`.

```powershell
# Generate code from spec (run from src/)
cd src && dotnet build /t:GenerateCode

# Build
dotnet build

# Run tests (playback mode — no Azure resources needed)
dotnet test --filter "TestCategory!=Live"

# Run a single test
dotnet test --filter "FullyQualifiedName~SearchServiceCollectionTests.CreateOrUpdateTest"

# Export public API surface (run from repo root)
pwsh eng/scripts/Export-API.ps1 search

# Update documentation snippets (run from repo root)
pwsh eng/scripts/Update-Snippets.ps1 search

# Format code
dotnet format src/Azure.ResourceManager.Search.csproj
dotnet format tests/Azure.ResourceManager.Search.Tests.csproj

# Validate API compatibility (surfaces breaking changes)
dotnet pack --no-restore
```

## Key Conventions

- **Never edit files in `src/Generated/`** — regenerate instead. Fix issues via `rename-mapping` in `autorest.md` or partial classes in `src/Customization/`.
- **ApiCompat enforcement**: `ApiCompatVersion` in the csproj is set to the last GA release. `dotnet pack` will fail if public API breaks. For intentional breaks in beta, update `ApiCompatVersion`.
- **Rename-mapping in autorest.md** controls how spec names map to C# names. All Search types are prefixed with `SearchService` or `Search` to avoid namespace collisions.
- **Pre-commit checks**: Before committing, run `Export-API.ps1`, `Update-Snippets.ps1`, and `dotnet format`. CI will fail without these.
- **Test base class**: Tests inherit from `SearchManagementTestBase` which sets up `ArmClient`, default subscription, sanitizers, and resource group creation helpers.
- **`WirePath` attribute**: Used on customization properties to map them to their JSON wire path for serialization.

## Copilot Skills

Two custom skills are available in the `skills/` directory:

| Skill | Purpose |
|-------|---------|
| `search-management-api-analysis` | Compare spec versions, identify breaking changes, and document required customizations **before** regenerating |
| `create-search-management-sdk` | End-to-end generation workflow: update spec → generate → build → customize → test |


# Guidelines
Always run `search-management-api-analysis` before `create-search-management-sdk` when upgrading to a new API version.
NEVER mass delete code without user confirmation.
NEVER modify code outside of /search root without explicit instructions.
