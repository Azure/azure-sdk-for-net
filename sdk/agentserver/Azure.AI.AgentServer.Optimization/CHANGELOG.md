# Release History

## 1.0.0-beta.3 (Unreleased)

### Changes

Consolidated configuration types ahead of public preview. The package now has a single canonical mutable options type that binds idiomatically via `Microsoft.Extensions.Configuration`, and the loader returns it directly (no result wrapper).

- `OptimizationConfig` → `OptimizationOptions` (mutable class, `{ get; set; }` properties).
- `OptimizationConfigLoader` → `OptimizationOptionsLoader`.
- Loader API collapsed from four overloads to two:
  - `OptimizationOptionsLoader.Load(LoadOptions? = null)` → `OptimizationOptions?`
  - `OptimizationOptionsLoader.LoadAsync(LoadOptions? = null, CancellationToken = default)` → `Task<OptimizationOptions?>`
  - The previous `AuthenticationTokenProvider`-only overloads are gone — pass the provider via `LoadOptions.TokenProvider`.
- Removed `LoadResult` wrapper. `LoadResult.SourceUsed` duplicated `OptimizationOptions.Source`, and `LoadResult.Warnings` is now surfaced as stderr diagnostics only.
- `LoadConfigOptions` → `LoadOptions`.
- `OptimizationSkill` is now a mutable class (was a `readonly struct`). Reference equality only.
- `ToolDefinition` is now a mutable class with `{ get; set; }` properties.
- `Skills` and `ToolDefinitions` collections are typed `IList<>` (mutable) instead of `IReadOnlyList<>`.
- Removed the `OptimizationOptions.FromOptimizationConfig` / `ToOptimizationConfig` shim — there is now only one type.

## 1.0.0-beta.2 (Unreleased)

### Features Added

- Multi-targeting: ships `net8.0` and `net10.0` assemblies, matching the sibling Core SDK.
- Priority-3 resolution: `OptimizationOptionsLoader` now loads candidate configs from `OPTIMIZATION_LOCAL_DIR/<OPTIMIZATION_CANDIDATE_ID>/` on disk, populated by `azd ai agent optimize apply --candidate`.

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of `Azure.AI.AgentServer.Optimization`.
- `OptimizationConfigLoader.LoadConfig()` and `LoadConfigAsync()` — resolves optimized agent configurations from the resolver API or environment variable.
- `OptimizationConfig` — immutable config object with instructions, model, temperature, skills, and tool definitions.
- `OptimizationSkill` — represents a single learned skill with name, description, and body.
