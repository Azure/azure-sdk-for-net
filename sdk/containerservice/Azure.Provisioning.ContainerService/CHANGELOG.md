# Release History

## 1.0.0-beta.7 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.6 (2026-04-02)

### Features Added

- Migrated from the reflection-based generator to the TypeSpec provisioning emitter.
- Bumped API version from `2024-08-01` to `2026-01-01`.
- Added new resource types: `AgentPoolUpgradeProfile`, `ContainerServiceMachine`, `ManagedClusterUpgradeProfile`, `MeshRevisionProfile`, `MeshUpgradeProfile`.
- Added new models: `ManagedClusterAdvancedNetworkingAccelerationMode`, `ProxyRedirectionMechanism`, `TransitEncryptionType`, `ManagedClusterPodIdentityProvisioningErrorDetail`.
- Added new properties: `PerformanceAccelerationMode`, `TransitEncryptionType`, `ProxyRedirectionMechanism`, `IsHttpProxyEnabled`.

### Breaking Changes

- Renamed `ResourceIdentityType` to `IdentityType` on `ManagedClusterIdentity`.
- Renamed boolean properties to follow `Is*Enabled`/`Is*Disabled` convention (e.g., `EnableAutoScaling` → `IsAutoScalingEnabled`, `EnablePrivateCluster` → `IsPrivateClusterEnabled`).
- Renamed `FailStartWithSwapOn` to `ShouldFailStartWithSwapOn`, `ScaleManual` to `VirtualMachinesScaleManual`, `IsOutboundNatDisabled` to `WindowsIsOutboundNatDisabled`, `IsCostAnalysisEnabled` to `MetricsIsCostAnalysisEnabled`, `IsVpaEnabled` to `VerticalPodAutoscalerIsVpaEnabled`.
- Removed duplicate properties `DisableLocalAccounts`, `EnableRbac`, `EnablePodSecurityPolicy`.
- Removed `IPFamily` enum (consolidated into `ContainerServiceIPFamily`).
- Changed `UserAssignedIdentities` type from `BicepDictionary<UserAssignedIdentityDetails>` to `BicepDictionary<ManagedServiceIdentityUserAssignedIdentitiesValue>`.
- `EffectiveOutboundIPs` on load balancer/NAT gateway profiles changed from read-write to read-only.
- `ResourceVersions` trimmed from ~40 historical versions to `V2025_10_01` and `V2026_01_01` only.

## 1.0.0-beta.5 (2026-03-03)

### Features Added

- Regenerated from `Azure.ResourceManager.ContainerService` version 1.3.1.

## 1.0.0-beta.4 (2025-06-25)

### Features Added

- Included new api-versions

### Bugs Fixed

- Fixed bicep path for some properties.

## 1.0.0-beta.3 (2025-06-16)

### Features Added

- Updated to use latest API version.

## 1.0.0-beta.2 (2024-10-25)

### Features Added

- Preview of the new Azure.Provisioning experience.

## 1.0.0-beta.1 (2024-10-04)

### Features Added

- Preview of the new Azure.Provisioning experience.
