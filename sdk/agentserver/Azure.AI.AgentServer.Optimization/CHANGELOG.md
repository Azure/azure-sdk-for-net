# Release History

## 1.0.0-beta.3 (2026-09-30)

### Breaking Changes

Consolidated configuration types ahead of public preview. The package now has a single canonical mutable options type that binds idiomatically via `Microsoft.Extensions.Configuration`, and the loader returns it directly without a result wrapper.

- Renamed `OptimizationConfig` to `OptimizationOptions`. The new type is a mutable class with `{ get; set; }` properties.
- Renamed `OptimizationConfigLoader` to `OptimizationOptionsLoader`.
- Replaced the previous loader overloads with:
  - `OptimizationOptionsLoader.Load(LoadOptions? = null)` returning `OptimizationOptions?`.
  - `OptimizationOptionsLoader.LoadAsync(LoadOptions? = null, CancellationToken = default)` returning `Task<OptimizationOptions?>`.
- Removed the `AuthenticationTokenProvider`-only overloads. Pass the provider through `LoadOptions.TokenProvider`.
- Removed the `LoadResult` wrapper. `LoadResult.SourceUsed` is available through `OptimizationOptions.Source`, and warnings are emitted as stderr diagnostics.
- Renamed `LoadConfigOptions` to `LoadOptions`.
- Changed `OptimizationSkill` from a `readonly struct` to a mutable class. It now uses reference equality.
- Changed `ToolDefinition` to a mutable class with `{ get; set; }` properties.
- Changed the `Skills` and `ToolDefinitions` collection types from `IReadOnlyList<>` to `IList<>`.
- Removed `OptimizationOptions.FromOptimizationConfig` and `ToOptimizationConfig`.

## 1.0.0-beta.2 (Unreleased)

### Features Added

- Multi-targeting: ships `net8.0` and `net10.0` assemblies, matching the sibling Core SDK.
- Priority-3 resolution: `OptimizationOptionsLoader` now loads candidate configs from `OPTIMIZATION_LOCAL_DIR/<OPTIMIZATION_CANDIDATE_ID>/` on disk, populated by `azd ai agent optimize apply --candidate`.

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial release of `Azure.AI.AgentServer.Optimization`.
- `OptimizationConfigLoader.LoadConfig()` and `LoadConfigAsync()` resolve optimized agent configurations from the resolver API or environment variable.
- `OptimizationConfig` is an immutable configuration object with instructions, model, temperature, skills, and tool definitions.
- `OptimizationSkill` represents a learned skill with a name, description, and body.
