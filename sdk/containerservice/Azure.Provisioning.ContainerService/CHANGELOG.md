# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2026-10-19)

### Features Added

- First stable release of Azure.Provisioning.ContainerService for declarative provisioning of Azure Kubernetes Service resources, using API version `2026-07-01` by default.

## 1.0.0-beta.7 (2026-10-15)

### Features Added

- Updated the default resource API version to `2026-07-01` to align with `Azure.ResourceManager.ContainerService`.
- Added `ManagedClusterIdentityBinding` resources and support for the associated monitoring, ingress, security, and agent pool features.

### Breaking Changes

- Replaced `ContainerServiceManagedCluster.IngressWebAppRouting` and `AzureMonitorMetrics` with `IngressProfile.WebAppRouting` and `AzureMonitorProfile.Metrics`.
- Replaced `VirtualMachinesScaleManual` on `ContainerServiceAgentPool` and `ManagedClusterAgentPoolProfileProperties` with `VirtualMachinesScale.Manual`, and `VirtualMachinesProfile.ScaleManual` with `Scale.Manual`.
- Replaced `ManagedClusterNatGatewayProfile.ManagedOutboundIPCount` with `ManagedOutboundIPProfile.Count`.
- Changed the numeric value of `ContainerServiceOSSku.Ubuntu2404` from `7` to `8` as `Windows2025` was added.

### Bugs Fixed

- Corrected `ManagedClusterDelegatedIdentity.ResourceId` and `ReferralResource` to be optional.

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
