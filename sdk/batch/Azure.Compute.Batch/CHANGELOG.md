# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.3 (2025-06-19)
 
 Added in Long Running operation support for the following methods:
 - `BatchClient.DeallocateNode`
 - `BatchClient.DeleteCertificate`
 - `BatchClient.DeleteJob`
 - `BatchClient.DeleteJob`
 - `BatchClient.DeletePool`
 - `BatchClient.DisableJob`
 - `BatchClient.EnableJob`
 - `BatchClient.RebootNode`
 - `BatchClient.ReimageNode`
 - `BatchClient.RemoveNodes`
 - `BatchClient.ResizePool`
 - `BatchClient.StartNode`
 - `BatchClient.StopPoolResize`
 - `BatchClient.TerminateJob`
 - `BatchClient.TerminateJobSchedule`
 
 Renamed the following models:

- `AffinityInfo` -> `BatchAffinityInfo`
- `BatchJobAction` -> `BatchJobActionKind`
- `BatchJobCreateContent` -> `BatchJobCreateOptions`
- `BatchJobDisableContent` -> `BatchJobDisableOptions`
- `BatchJobScheduleCreateContent` -> `BatchJobScheduleCreateOptions`
- `BatchJobScheduleUpdateContent` -> `BatchJobScheduleUpdateOptions`
- `BatchJobTerminateContent` -> `BatchJobTerminateOptions`
- `BatchJobUpdateContent` -> `BatchJobUpdateOptions`
- `BatchNodeDeallocateContent` -> `BatchNodeDeallocateOptions`
- `BatchNodeDisableSchedulingContent` -> `BatchNodeDisableSchedulingOptions`
- `BatchNodeRebootContent` -> `BatchNodeRebootOptions`
- `BatchNodeRebootOption` -> `BatchNodeRebootKind`
- `BatchNodeReimageContent` -> `BatchNodeReimageOptions`
- `BatchNodeRemoveContent` -> `BatchNodeRemoveOptions`
- `BatchNodeUserCreateContent` -> `BatchNodeUserCreateOptions`
- `BatchNodeUserUpdateContent` -> `BatchNodeUserUpdateOptions`
- `BatchPoolCreateContent` -> `BatchPoolCreateOptions`
- `BatchPoolEnableAutoScaleContent` -> `BatchPoolEnableAutoScaleOptions`
- `BatchPoolEvaluateAutoScaleContent` -> `BatchPoolEvaluateAutoScaleOptions`
- `BatchPoolReplaceContent` -> `BatchPoolReplaceOptions`
- `BatchPoolResizeContent` -> `BatchPoolResizeOptions`
- `BatchPoolUpdateContent` -> `BatchPoolUpdateOptions`
- `BatchTaskCreateContent` -> `BatchTaskCreateOptions`
- `ContainerConfiguration` -> `BatchContainerConfiguration`
- `ContainerConfigurationUpdate` -> `BatchContainerConfigurationUpdate`
- `DeleteBatchCertificateError` -> `BatchCertificateDeleteError`
- `DiffDiskSettings` -> `BatchDiffDiskSettings`
- `ErrorCategory` -> `BatchErrorSourceCategory`
- `ImageReference` -> `BatchVmImageReference`
- `OSDisk` -> `BatchOsDisk`
- `OnAllBatchTasksComplete` -> `BatchAllTasksCompleteMode`
- `OnBatchTaskFailure` -> `BatchAllTasksCompleteMode`
- `PublicIpAddressConfiguration` -> `BatchPublicIpAddressConfiguration`
- `UefiSettings` -> `BatchUefiSettings`
- `UploadBatchServiceLogsContent` -> `UploadBatchServiceLogsOptions`
- `VMDiskSecurityProfile` -> `BatchVMDiskSecurityProfile`
 
Renamed parameter in the following methods:

- `BatchClient.DisableJob` changed `content` parameter to `disableOptions`.
- `BatchClient.EnablePoolAutoScale` changed `content` parameter to `enableAutoScaleOptions`.
- `BatchClient.EvaluatePoolAutoScale` changed `content` parameter to `evaluateAutoScaleOptions`.
- `BatchClient.UploadNodeLogs` changed `content` parameter to `uploadOptions`.
- `BatchClient.ReplaceNodeUser` changed `content` parameter to `updateOptions`.
- `BatchClient.RemoveNodes` changed `content` parameter to `removeOptions`.
- `BatchClient.ResizePool` changed `content` parameter to `resizeOptions`.
- `BatchClient.TerminateJob` changed `parameters` parameter to `options`.
- `BatchClient.DeallocateNode` changed `parameters` parameter to `options`.
- `BatchClient.DisableNodeScheduling` changed `parameters` parameter to `options`.
- `BatchClient.RebootNode` changed `parameters` parameter to `options`.
- `BatchClient.ReimageNode` changed `parameters` parameter to `options`.

Renamed parameter in the following models:

- `BatchPoolStatistics.Url` changed to `Uri` and changed the type to Uri.
- `BatchJobStatistics.Url` changed to `Uri` and changed the type to Uri.
- `BatchCertificate.Url` changed to `Uri` and changed the type to Uri.
- `BatchNodeFile.Url` changed to `Uri` and changed the type to Uri.
- `BatchJobSchedule.Url` changed to `Uri` and changed the type to Uri.
- `ContainerRegistryReference.Url` changed to `Uri` and changed the type to Uri.
- `ResourceFile.registryServer` changed to `registryServerUri` and changed the type to Uri.
- `ResourceFile.storageContainerUrl` changed to `storageContainerUri` and changed the type to Uri.
- `ResourceFile.httpUrl` changed to `httpUri` and changed the type to Uri.
- `OutputFileBlobContainerDestination.containerUrl` changed to `containerUri` and changed the type to Uri.
- `BatchMetadataItem.azureFileUrl` changed to `azureFileUri` and changed the type to Uri.
- `RecentBatchJob.url` changed to `uri` and changed the type to Uri.
- `BatchJobScheduleStatistics.url` changed to `uri` and changed the type to Uri.
- `BatchJob.url` changed to `uri` and changed the type to Uri.
- `BatchJobPreparationAndReleaseTaskStatus.nodeUrl` changed to `nodeUri` and changed the type to Uri.
- `BatchJobPreparationTaskExecutionInfo.taskRootDirectoryUrl` changed to `taskRootDirectoryUri` and changed the type to Uri.
- `BatchJobReleaseTaskExecutionInfo.taskRootDirectoryUrl` changed to `taskRootDirectoryUri` and changed the type to Uri.
- `BatchPool.url` changed to `uri` and changed the type to Uri.
- `BatchTask.url` changed to `uri` and changed the type to Uri.
- `BaBatchNodeInfo.nodeUrl` changed to `nodeUri` and changed the type to Uri.
- `BaBatchNodeInfo.taskRootDirectoryUrl` changed to `taskRootDirectoryUri` and changed the type to Uri.
- `MultiInstanceSettings.url` changed to `uri` and changed the type to Uri.
- `BatchNode.url` changed to `uri` and changed the type to Uri.
- `BatchTaskInfo.taskUrl` changed to `taskUri` and changed the type to Uri.
- `UploadBatchServiceLogsOptions.containerUrl` changed to `containerUri` and changed the type to Uri.

Changed the type of the following properties

- `BatchCertificate.Data` from string to BinaryData
- `BatchNodeIdentityReference.ResourceId ` from string to ResourceIdentifier
- `BatchUserAssignedIdentity.ResourceId ` from string to ResourceIdentifier
- `BatchVmImageReference.VirtualMachineImageId ` from string to ResourceIdentifier



### Other Changes
 
 Documenation updates.

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
  - Added `displayName`, `vmSize`, `taskSlotsPerNode`, `taskSchedulingPolicy`, `enableInterNodeCommunication`, `virtualMachineConfiguration`, `networkConfiguration`, `userAccounts`, `mountConfiguration`, `upgradePolicy`, and `resourceTags` to `BatchPoolUpdateOptions`.
  - Added `networkConfiguration` to `BatchJobUpdateOptions`.

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
