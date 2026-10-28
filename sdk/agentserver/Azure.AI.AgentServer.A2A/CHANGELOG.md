# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Added native A2A v1.0 JSON-RPC and SSE hosting with Core host-builder,
  one-call server, and existing ASP.NET Core integration.
- Added canonical and compatibility container routes, Foundry request context,
  server-version identity, transport error classification, and semantic tracing.
- Added caller-scoped native task persistence backed by Core's Foundry state store.

### Other Changes

- Uses the native `A2A.AspNetCore` 1.0.0-preview3 dependency; release requires
  dependency and public API approval.
