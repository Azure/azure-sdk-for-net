# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial preview release of `Azure.AI.AgentServer.Optimization.Configuration`.
- `IConfigurationBuilder.AddOptimizationConfigSource()` registers an
  `AgentConfigurationSource` that flattens the resolved `OptimizationOptions`
  into the `Agent` section of `IConfiguration` (single-agent host).
- Multi-agent overloads (`AddOptimizationConfigSource("<agentKey>")`) project
  per-agent values under `Agents:<agentKey>` using per-agent suffixed
  environment variables (`OPTIMIZATION_<VAR>__<CANONICAL_KEY>`).
- `IConfiguration.GetOptimizationOptions()` convenience binder for the
  single-agent and multi-agent sections.
- `AgentConfigurationOptions` exposes `Credential` (Azure.Core
  `TokenCredential`), `TokenProvider` (System.ClientModel
  `AuthenticationTokenProvider`), `ResolverTimeout`, `StrictMode`, and
  `FailOnEmpty` for fail-fast startup contracts.
