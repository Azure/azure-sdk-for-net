# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

- The library is now generated from TypeSpec, which adds the `2025-11-01` API version, `ContainerRegistryPrivateLinkResource`, and `ContainerRegistryRoleAssignmentMode`.

### Bugs Fixed

### Other Changes

- The Container Registry Tasks types (`ContainerRegistryTask`, `ContainerRegistryTaskRun`, `ContainerRegistryRunData`, `ContainerRegistryAgentPool`, and their supporting models, triggers, steps and enums) are now obsolete in this package. They keep working unchanged, but new code should use the dedicated `Azure.Provisioning.ContainerRegistry.Tasks` package, where the equivalent types carry the `ContainerRegistryTask` prefix (for example `ContainerRegistryOS` becomes `ContainerRegistryTaskOS` and `ContainerRegistryRunData` becomes `ContainerRegistryRun`). Each obsolete type names its replacement in its `[Obsolete]` message.
- `ContainerRegistryService.PrivateEndpointConnections` remains available as an obsolete compatibility property. New code should use `PrivateEndpointConnectionResources`, which exposes the provisionable child resources.


## 1.1.0 (2025-06-16)

### Features Added

- Updated to use latest API version.

## 1.0.0 (2024-10-25)

### Features Added

- The new Azure.Provisioning experience.

## 1.0.0-beta.1 (2024-10-04)

### Features Added

- Preview of the new Azure.Provisioning experience.
