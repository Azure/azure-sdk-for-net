# Release History

## 1.0.0-beta.2 (2026-10-27)

### Features Added

- Added active OpenShift version information to cluster and node pool resource status.
- Added `HcpOpenShiftClusterKmsEncryptionProfile.KeyVaultType` to select Azure Key Vault or Managed HSM for KMS encryption.
- Added `HcpOpenShiftClusterPlatformProfile.ContainerRegistryManagedIdentity` to configure the managed identity used for container registry access.

### Breaking Changes

- Replaced `HcpOpenShiftClusterProperties.StatusConditions` and `HcpOpenShiftClusterNodePoolProperties.StatusConditions` with `Status.Conditions`. The new `Status` properties also expose `ActiveVersions`.
- Updated the corresponding `ArmRedHatOpenShiftHcpModelFactory` method signatures to reflect the new status models, KMS key vault type, and container registry managed identity.

## 1.0.0-beta.1 (2026-09-10)

### Features Added

- First beta release for API version 2026-09-01-preview.
