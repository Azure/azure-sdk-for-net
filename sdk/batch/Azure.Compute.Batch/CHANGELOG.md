# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2025-02-28)

### Features Added

- Exposed `JsonModelWriteCore` for model serialization procedure.

- Force delete/terminate job or job schedule:
  - Added `force` parameter of type Boolean to `DeleteJobAsync`, `DeleteJob`, `TerminateJobAsync`, `TerminateJob`, `DeleteJobScheduleAsync`, `DeleteJobSchedule`, `TerminateJobScheduleAsync`, and `TerminateJobSchedule`.

- Support for compute node start/deallocate operations:
  - Added `StartNode`, `StartNodeAsync`, `DeallocateNode`, and `DeallocateNodeAsync` methods to `BatchClient`

- Container task data mount isolation:
  - Added `containerHostBatchBindMounts` of type `List<ContainerHostBatchBindMountEntry>` to `BatchTaskContainerSettings`.

- Patch improvements for pool and job:
  - Added `displayName`, `vmSize`, `taskSlotsPerNode`, `taskSchedulingPolicy`, `enableInterNodeCommunication`, `virtualMachineConfiguration`, `networkConfiguration`, `userAccounts`, `mountConfiguration`, `upgradePolicy`, and `resourceTags` to `BatchPoolUpdateContent`.
  - Added `networkConfiguration` to `BatchJobUpdateContent`.

- Confidential VM support:
  - Added `confidentialVM` to `SecurityTypes`.
  - Added `securityProfile` of type `VMDiskSecurityProfile` to `ManagedDisk`.

- Support for shared and community gallery images:
  - Added `sharedGalleryImageId` and `communityGalleryImageId` to `ImageReference`.
### Breaking Changes

- Removed `getNodeRemoteDesktop` method from `BatchClient`. Use `getNodeRemoteLoginSettings` instead to remotely login to a compute node.
- Removed `CloudServiceConfiguration` from pool models and operations. Use `VirtualMachineConfiguration` when creating pools.
- Removed `ApplicationLicenses` from pool models and operations.

## 1.0.0-beta.1 (2024-06-01)

### Features Added

New design of track 2 initial commit. This package, `Azure.Compute.Batch`, replaces `Microsoft.Azure.Batch`.

This package follows the [new Azure SDK guidelines](https://azure.github.io/azure-sdk/general_introduction.html), and provides many core capabilities.

This package is a Public Preview version, so expect incompatible changes in subsequent releases as we improve the product. To provide feedback, submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

> NOTE: For more information about unified authentication, please refer to [Microsoft Azure Identity documentation for .NET](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet).
