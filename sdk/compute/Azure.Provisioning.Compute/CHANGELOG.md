# Release History

## 1.0.0-beta.3 (2026-10-30)

### Features Added

- Upgraded the Compute API version to `2026-04-01` and the ComputeGallery API version to `2026-03-03`, aligning with `Azure.ResourceManager.Compute`.
- Added `VirtualMachineDiagnosticRunCommand` and `VirtualMachineScaleSetVMDiagnosticRunCommand` resources.
- Added `VirtualMachine.FlexPreferredVmSize` for configuring FlexProfile preferred VM sizes.
- Added `PrivateIPAddressPrefixLength` to `VirtualMachineNetworkInterfaceIPConfiguration` and `VirtualMachineScaleSetIPConfiguration`.
- Added support for gallery image metadata and data disk security profiles, capacity reservation state and utilization details, and secrets provisioning settings.

### Breaking Changes

- Replaced `VirtualMachine.CapacityReservationGroupId` and `VirtualMachineScaleSetVmProfile.CapacityReservationGroupId` with `CapacityReservation.CapacityReservationGroupId`.
- Replaced `VirtualMachineScaleSetVmProfile.HardwareVmSizeProperties` with `HardwareProfile.VmSizeProperties`.
- Replaced `GalleryImageVersion.SecurityUefiSettings` with `SecurityProfile.UefiSettings`.
- Replaced `GalleryResource.IsSoftDeleteEnabled` with `SoftDeletePolicy.IsSoftDeleteEnabled`.

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2026-08-11)

### Features Added

- Migrated `Azure.Provisioning.Compute` to the TypeSpec-based provisioning generator.
- Added support for newer Compute resource API versions, including Compute `2026-03-01`, ComputeDisk `2026-03-02`, and ComputeGallery `2025-12-03`.
- Added generated support for additional Compute resources and models, including disk restore points, interconnect blocks, virtual machine scale set lifecycle hooks, virtual machine scale set rolling upgrades, and virtual machine extension images.

### Breaking Changes

- Renamed `ComputeGallery` to `GalleryResource` and `ComputeSnapshot` to `SnapshotResource` to avoid generic single-word resource type names.
- Removed beta-only generated types that are no longer emitted by the TypeSpec generator, including `GalleryArtifactVersionSource` and `LoadBalancerFrontendIPConfiguration`.
- Updated several generated model/property shapes to match the TypeSpec-generated API surface.

## 1.0.0-beta.1 (2026-03-25)

### Features Added

- Initial release of `Azure.Provisioning.Compute` with support for declarative provisioning of Azure Compute resources.
