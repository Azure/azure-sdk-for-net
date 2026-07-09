# Release History

## 1.0.0-beta.1 (Unreleased)

### Features Added

- Initial preview of `Azure.Provisioning.ServiceFabric`.
- `ServiceFabricApplicationType` follows the `2026-03-01-preview` schema, whose application type properties do not expose `maximumUnusedVersionsToKeep`. Use `ServiceFabricCluster.MaxUnusedVersionsToKeep` for application type version cleanup configuration.
