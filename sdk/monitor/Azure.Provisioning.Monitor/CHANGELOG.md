# Release History

## 1.0.0-beta.2 (Unreleased)

### Features Added

- Added support for diagnostic setting categories, service diagnostic settings, tenant action groups, VM Insights onboarding status, and additional private link resources.

### Breaking Changes

- Moved Monitor workspace resources to `Azure.Provisioning.Monitor.Workspaces`.
- Moved Monitor pipeline group resources to `Azure.Provisioning.Monitor.PipelineGroups`.

### Bugs Fixed

### Other Changes

- Migrated the library from the reflection-based provisioning generator to the TypeSpec provisioning emitter.
- Preserved the legacy Alert Rule resource as custom compatibility code because its CRUD API is not represented in the current TypeSpec specification.

## 1.0.0-beta.1 (2026-04-07)

### Features Added

- Initial beta release of new Azure.Provisioning.Monitor.
