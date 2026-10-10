# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial preview release of the Azure Container Apps Sandbox data-plane client library.
- Added `SandboxGroupClient` and resource-specific subclients for sandboxes, volumes, snapshots, secrets, connections, credentials, content packages, egress policies, and disk images.
- Added support for sandbox lifecycle, files, commands, streams, networking, volume mounts, and content package operations.
- Added resource clients for identifier-scoped operations and create/list responses with service data.
- Exposed sandbox group identifiers and the full ARM resource ID as read-only properties on `SandboxGroupClient`.
- Added streaming convenience methods for sandbox files, volume files, and content package uploads. Upload streams remain caller-owned, and downloaded file streams must be disposed by the caller.
- Added interactive exec sessions with dedicated WebSocket start requests and process streams over WebSocket, and unbuffered HTTP log streaming.

### Breaking Changes

### Bugs Fixed

### Other Changes

- Generated the client from the `2026-09-01-preview` Azure Container Apps Sandbox TypeSpec.
- Added unit, playback, and live test coverage for the generated SDK scenarios.