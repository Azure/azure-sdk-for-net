# Release History

## 16.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 16.3.1 (2024-09-19)

### Bugs Fixed

- Fixed `ImageReference` constructor null reference exception.

## 16.3.0 (2024-07-01)

### Features Added

- Compute node start/deallocate support.
  - Added `Start` and `StartAsync` to ComputeNode
  - Added `Deallocate` and `DeallocateAsync` to ComputeNode

- Force delete/terminate job/jobSchedule.
  - Added `force` of type Boolean to type `JobDeleteOptions`, `JobTerminateOptions`, `JobScheduleTerminateOptions`, and `JobScheduleDeleteOptions`.

- Improved patch for pool/job
  - Added `DisplayName`, `VmSize`, `TaskSlotsPerNode`, `TaskSchedulingPolicy`, `EnableInterNodeCommunication`, `VirtualMachineConfiguration`, `NetworkConfiguration`, `UserAccounts`, `MountConfiguration`, `UpgradePolicy`, and `ResourceTags` to type `PoolPatchParameter`.
  - Added `JobNetworkConfiguration` to type `JobPatchParameter`.

- Confidential VM support.
  - Added `ConfidentialVM` value to type `SecurityTypes`.
  - Added `securityProfile` of type `VMDiskSecurityProfile` to type `ManagedDisk`.

- Added `sharedGalleryImageId` and `communityGalleryImageId` of type string to type `ImageReference`.

### Breaking Changes
- Removed `CloudServiceConfiguration` from pool models and operations, `VirtualMachineConfiguration` is the only supported pool configuration.
- Removed `ApplicationLicenses` from pool models and operations.

- Removed `GetRDPFile()` method, use `GetRemoteLoginSettings()` instead.
  - Removed `GetRDPFile` and `GetRDPFileAsync` from PoolOperations 
  - Removed `GetRDPFile` and `GetRDPFileAsync` from ComputeNode

## 16.2.0 (2024-02-29)

### Features Added

- Add `UpgradePolicy` support to Pool Creation
  - Added `upgradePolicy` property to `PoolSpecification`definition
  - Added `upgradePolicy` property to `CloudPool`definition
  - Added `upgradePolicy` property to `PoolAddParameter`definition
  - Added `upgradingOS` value to `ComputeNodeState` enum
  - Added `upgradingOS` property to `NodeCounts`definition
  - Added `UpgradePolicy`definition
  - Added `AutomaticOSUpgradePolicy`definition
  - Added `RollingUpgradePolicy`definition

## 16.1.0 (2024-01-01)

### Features Added

- Add `ResourceTags` support to Pool Creation
  - Added `resourceTags` property to `PoolAddParameter` definition
  - Added `resourceTags` property to `PoolSpecification` definition
  - Added `resourceTags` property to `CloudPool` definition

- Add `SecurityProfile` support to Pool Creation
  - Added `serviceArtifactReference` property to `VirtualMachineConfiguration`definition
  - Added `securityProfile` property to `VirtualMachineConfiguration` definition
  - Added `ScaleSetVmResourceId` property to `VirtualMachineInfo` definition

- Add `ServiceArtifactReference` and `OSDisk` support to Pool Creation
  - Added `StandardSSDLRS` value to `StorageAccountType` enum
  - Added `caching` property to `OSDisk` definition
  - Added `managedDisk` property to `OSDisk` definition
  - Added `diskSizeGB` property to `OSDisk` definition
  - Added `writeAcceleratorEnabled` property to `OSDisk` definition

## 16.0.0 (2023-05-01)

### Features Added

- Added boolean property `enableAcceleratedNetworking` to `NetworkConfiguration`. 
    -  This property determines whether this pool should enable accelerated networking, with default value as False. 
    - Whether this feature can be enabled is also related to whether an operating system/VM instance is supported, which should align with AcceleratedNetworking Policy ([AcceleratedNetworking Limitations and constraints](https://learn.microsoft.com/azure/virtual-network/accelerated-networking-overview?tabs=redhat#limitations-and-constraints)). 
- Added boolean property `enableAutomaticUpgrade` to `VMExtension`. 
    - This property determines whether the extension should be automatically upgraded by the platform if there is a newer version of the extension available.
- Added new property `Type` to `ContainerConfiguration`, which now supports two values: `DockerCompatible` and `CriCompatible`.

### Breaking Changes

- Removed lifetime statistics operations. The lifetime statistics APIs are no longer supported.
    - Removed GetAllLifetimeStatistics in JobOperation.
    - Removed GetAllLifetimeStatistics in PoolOperation.

### Other Changes

- Added deprecation warning to certificate operations.

## 15.4.0 (2022-10-01)

### Features Added

- Added new custom enum type `NodeCommunicationMode`.
  - This property determines how a pool communicates with the Batch service.
  - Possible values: Default, Classic, Simplified.
- Added properties `CurrentNodeCommunicationMode` and `TargetNodeCommunicationMode` of type `NodeCommunicationMode` to `CloudPool`.
- Added property `TargetNodeCommunicationMode` of type `NodeCommunicationMode` to `PoolSpecification`, `PoolAddParameter`, `PoolPatchParameter`, and `PoolUpdatePropertiesParameter`.

### Other Changes

- Modified descriptions of `ApplicationId`, `UploadHeaders`, and `Name` (UserAccount) properties.

## 15.3.0 (2022-01-07)

### Features Added

- Added property `UploadHeaders` to `OutputFileBlobContainerDestination`.
  - Allows users to set custom HTTP headers on resource file uploads.
  - Array of type `HttpHeader` (also being added).
- Added boolean property `AllowTaskPreemption` to `JobSpecification`, `CloudJob`, `JobAddParameter`, `JobPatchParameter`, `JobUpdateParameter`
  - Mark Tasks as preemptible for higher priority Tasks (requires Comms-Enabled or Single Tenant Pool).
- Replaced comment (title, description, etc.) references of "low-priority" with "Spot/Low-Priority", to reflect new service behavior.
  - No API change required.
  - Low-Priority Compute Nodes (VMs) will continue to be used for User Subscription pools (and only User Subscription pools), as before.
  - Spot Compute Nodes (VMs) will now be used for Batch Managed (and only Batch Managed pools) pools.

### Bugs Fixed

- Fixed OutputFileBlobContainerDestination constructor null reference exception.

### Features Added

## 15.1.0 (2021-08-10)

- Made ComputeNodeExtension operations publicly accessible.
- Added default constructors to BatchServiceClient and models for mocking.

### Features Added

- Added an identity reference argument to various constructors and utility functions to make identities easier to use.

## 15.0.0 (2021-07-30)

### Features Added

- Add ability to assign user-assigned managed identities to `CloudPool`. These identities will be made available on each node in the pool, and can be used to access various resources.
- Added `IdentityReference` property to the following models to support accessing resources via managed identity:
  - `AzureBlobFileSystemConfiguration`
  - `OutputFileBlobContainerDestination`
  - `ContainerRegistry`
  - `ResourceFile`
  - `UploadBatchServiceLogsConfiguration`
- Added new `ComputeNodeExtension` operations to `BatchServiceClient` for getting/listing VM extensions on a node
- Added new `extensions` property to `VirtualMachineConfiguration` on `CloudPool` to specify virtual machine extensions for nodes
- Added the ability to specify availability zones using a new property `NodePlacementConfiguration` on `VirtualMachineConfiguration`
- Added new `OSDisk` property to `VirtualMachineConfiguration`, which contains settings for the operating system disk of the Virtual Machine.
  - The `placement` property on `DiffDiskSettings` specifies the ephemeral disk placement for operating system disks for all VMs in the pool. Setting it to "CacheDisk" will store the ephemeral OS disk on the VM cache.
- Added `MaxParallelTasks` property on `CloudJob` to control the maximum allowed tasks per job (defaults to -1, meaning unlimited).
- Added `VirtualMachineInfo` property on `ComputeNode` which contains information about the current state of the virtual machine, including the exact version of the marketplace image the VM is using.
- Added `RecurrenceInterval` property to `Schedule` to control the interval between the start times of two successive job under a job schedule.

## 14.0.0 (2020-09-10)

### Features

- **[Breaking]** Removed proprty `MaxTasksPerNode` on CloudPool and added property `TaskSlotsPerNode`. Using this property `CloudTasks`
in a `CloudJob` can consume a dynamic amount of slots allowing for more fine-grained control over resource consumption.
- **[Breaking]** Changed the return type of `GetJobTaskCounts` operations to return a `TaskCountsResult` object, which is a complex object containing the previous
`TaskCounts` object and a new `TaskSlotCounts` object providing similar information in the context of slots being used.
- Added property `RequiredSlots` to CloudTask allowing user to specify how many slots on a node they should take up.

## 13.0.0 (2020-03-01)

### Features

- Added ability to encrypt `ComputeNode` disk drives using the new `DiskEncryptionConfiguration` property of `VirtualMachineConfiguration`.
- **[Breaking]** The `VirtualMachineImageId` property of `ImageReference` can now only refer to a Shared Image Gallery image.
- **[Breaking]** The `CreateCertificate` functions on `CertificateOperations` have been renamed to `CreateCertificateFromCer` and `CreateCertificateFromPfx` and had their parameters updated to more clearly reflect that `password` is optional for PFX formatted certificates.
- **[Breaking]** Pools can now be provisioned without a public IP using the new `PublicIPAddressConfiguration` property of `NetworkConfiguration`.
  - The `PublicIPs` property of `NetworkConfiguration` has moved in to `PublicIPAddressConfiguration` as well. This property can only be specified if `IPAddressProvisioningType` is `UserManaged`.

### Bug fixes

- Add missing error codes to `TaskFailureInformationCodes`.

### REST API version

This version of the Batch .NET client library targets version 2020-03-01.11.0 of the Azure Batch REST API.
**Note**: This REST API version may not be available in all regions prior to 2020-03-13. Attempts to use the SDK will fail if the region has not had support for the REST API version enabled yet.

## 12.0.0

### Features

- Added ability to specify a collection of public IPs on `NetworkConfiguration` via the new `PublicIPs` property. This guarantees nodes in the Pool will have an
  IP from the list user provided IPs.
- Added ability to mount remote file-systems on each node of a pool via the `MountConfiguration` property on `CloudPool`.
- Shared Image Gallery images can now be specified on the `VirtualMachineImageId` property of `ImageReference` by referencing the image via its ARM ID.
- **[Breaking]** When not specified, the default value for `WaitForSuccess` on `StartTask` is now `true` (was `false`).
- **[Breaking]** When not specified, the default value for `Scope` on `AutoUserSpecification` is now always `Pool` (was `Task` on Windows nodes, `Pool` on Linux nodes).

### Bug fixes

- Improved various confusing or incomplete documentation.

### REST API version

This version of the Batch .NET client library targets version 2019-08-01.10.0 of the Azure Batch REST API.

## 11.0.0

### Features

- Added `maxBackoff` parameter to `RetryPolicyProvider.ExponentialRetryProvider`. This option was already available on the `ExponentialRetry` constructor,
   but adding it on `RetryPolicyProvider.ExponentialRetryProvider` makes it easier to use.
- **[Breaking]** Replaced `PoolOperations.ListNodeAgentSKUs` with `PoolOperations.ListSupportedImages`. `ListSupportedImages` contains all of the same information originally available in
   `ListNodeAgentSKUs` but in a clearer format. New non-verified images are also now returned. Additional information about `Capabilities` and `BatchSupportEndOfLife` is accessible on the
   `ImageInformation` object returned by `ListSupportedImages`.
- Now support network security rules blocking network access to a `CloudPool` based on the source port of the traffic. This is done via the `SourcePortRanges` property on `NetworkSecurityGroupRule`.
- When running a container, Batch now supports executing the task in the container working directory or in the Batch task working directory. This is controlled by the
   `WorkingDirectory` property on `TaskContainerSettings`.

### Bug fixes

- Improved various confusing or incomplete documentation.

### REST API version

This version of the Batch .NET client library targets version 2019-06-01.9.0 of the Azure Batch REST API.

## 10.1.0

- Added `net461` and `netstandard2.0` target frameworks.
- Updated `Microsoft.AspNetCore.WebUtilities` to `1.1.2` for the `netstandard1.4` target framework.

### REST API version

This version of the Batch .NET client library targets version 2018-12-01.8.0 of the Azure Batch REST API.

## 10.0.0

### Features

- **[Breaking]** Removed support for the `ChangeOSVersion` API on `CloudServiceConfiguration` pools.
  - Removed `PoolOperations.ChangeOSVersion` and `PoolOperations.ChangeOSVersionAsync`.
  - Renamed `TargetOSVersion` to `OSVersion` and removed `CurrentOSVersion` on `CloudPool`.
  - Removed `PoolState.Upgrading` enum.
- **[Breaking]** Removed `DataEgressGiB` and `DataIngressGiB` from `PoolUsageMetrics`. These properties are no longer supported.
- **[Breaking]** ResourceFile improvements
  - The `ResourceFile` constructor is now private.
  - Added the ability specify an entire Azure Storage container in `ResourceFile`. There are now three supported modes for `ResourceFile`:
    - `ResourceFile.FromUrl` creates a `ResourceFile` pointing to a single HTTP URL.
    - `ResourceFile.FromStorageContainerUrl` creates a `ResourceFile` pointing to an Azure Blob Storage container.
    - `ResourceFile.FromAutoStorageContainer` creates a `ResourceFile` pointing to an Azure Blob Storage container in the Batch registered auto-storage account.
  - URLs provided to `ResourceFile` via the `ResourceFile.FromUrl` method can now be any HTTP URL. Previously, these had to be an Azure Blob Storage URL.
  - The `BlobPrefix` property can be used to filter downloads from a storage container to only those matching the prefix.
- **[Breaking]** Removed `OSDisk` property from `VirtualMachineConfiguration`. This property is no longer supported.
- Pools which set the `DynamicVNetAssignmentScope` on `NetworkConfiguration` to be `DynamicVNetAssignmentScope.Job` can
  now dynamically assign a Virtual Network to each node the job's tasks run on. The specific Virtual Network to join the nodes to is specified in
  the new `JobNetworkConfiguration` property on `CloudJob` and `JobSpecification`.
  - **Note**: This feature is in public preview. It is disabled for all Batch accounts except for those which have contacted us and requested to
    be in the pilot.
- The maximum lifetime of a task is now 180 days (previously it was 7).
- Added support on Windows pools for creating users with a specific login mode (either `Batch` or `Interactive`) via `WindowsUserConfiguration.LoginMode`.
- The default task retention time for all tasks is now 7 days, previously it was infinite.
- `ExponentialRetry` supports a backoff cap, via the `MaxBackoff` property.

### Bug fixes

- The built in retry policies `ExponentialRetry` and `LinearRetry` now correctly retry on HTTP status code `429` and honor the `retry-after` header.

### REST API version

This version of the Batch .NET client library targets version 2018-12-01.8.0 of the Azure Batch REST API.

## 9.0.1

- Updating Newtonsoft.Json to 10.0.3

### REST API version

This version of the Batch .NET client library targets version 2018-08-01.7.0 of the Azure Batch REST API.

## 9.0.0

### Features

- Added the ability to see what version of the Azure Batch Node Agent is running on each of the VMs in a pool, via the new `NodeAgentInformation` property on `ComputeNode`.
- Added the ability to specify a `Filter` on the `Result` of a task. See [here](https://learn.microsoft.com/rest/api/batchservice/odata-filters-in-batch) for more details.
  - This enables the often requested scenario of performing a server-side query to find all tasks which failed.
- **[Breaking]** Added a default retry policy to `BatchClient`.
  - Note that this policy may not be sufficient for every case. If the old behavior (a `BatchClient` that doesn't perform any retries) is desired, the default policy can be removed from a `BatchClient` with `client.CustomBehaviors = client.CustomBehaviors.Where(behavior => !(behavior is RetryPolicyProvider)).ToList()`.
- **[Breaking]** Removed the `ValidationStatus` property from `TaskCounts`, as well as the `TaskCountValidationStatus` enum.
- **[Breaking]** The default caching type for `DataDisk` and `OSDisk` is now `ReadWrite` instead of `None`.

### Bug fixes

- Fixed bug when using `BatchSharedKeyCredentials` where some operations would fail with an `Unauthenticated` error in `netcoreapp2.1` even though the right shared key was used.

### REST API version

This version of the Batch .NET client library targets version 2018-08-01.7.0 of the Azure Batch REST API.

## 8.1.2

Rename Nuget package name from Azure.Batch to Microsoft.Azure.Batch

## Prior to version 8.1.2, this package was named "Azure.Batch" on Nuget. The release notes below are for that package

Add deprecation announcement to nuget package.

## 8.1.1

### Bug fixes

- Fixed bug where LeavingPool state was not correctly returned via the `ListPoolNodeCounts` method on `PoolOperations`.
- Clarified various confusing documentation.

### REST API version

This version of the Batch .NET client library targets version 2018-02-01.6.1 of the Azure Batch REST API.

## 8.1.0

### Features

- Added the ability to query pool node counts by state, via the new `ListPoolNodeCounts` method on `PoolOperations`.
- Added the ability to upload Azure Batch node agent logs from a particular node, via the `UploadComputeNodeBatchServiceLogs` method on `PoolOperations` and `ComputeNode`.
  - This is intended for use in debugging by Microsoft support when there are problems on a node.

### REST API version

This version of the Batch .NET client library targets version 2018-02-01.6.1 of the Azure Batch REST API.

### Import Note

The package will be renamed to Microsoft.Azure.Batch in a future release.

## 8.0.1

### Bug fixes

- Fixed a bug where deserializing some enum properties could fail if using Newtonsoft 10.

### REST API version

This version of the Batch .NET client library targets version 2017-09-01.6.0 of the Azure Batch REST API.

## 8.0.0

### Features

- Added the ability to get a discount on Windows VM pricing if you have on-premises licenses for the OS SKUs you are deploying, via `LicenseType` on `VirtualMachineConfiguration`.
- Added support for attaching empty data drives to `VirtualMachineConfiguration` based pools, via the new `DataDisks` property on `VirtualMachineConfiguration`.
- **[Breaking]** Custom images must now be deployed using a reference to an ARM Image, instead of pointing to .vhd files in blobs directly.
  - The new `VirtualMachineImageId` property on `ImageReference` contains the reference to the ARM Image, and `OSDisk.ImageUris` no longer exists.
  - Because of this, `ImageReference` is now a required property of `VirtualMachineConfiguration`.
- **[Breaking]** Multi-instance tasks (created using `MultiInstanceSettings`) must now specify a `CoordinationCommandLine`, and `NumberOfInstances` is now optional and defaults to 1.
- Added support for tasks run using Docker containers. To run a task using a Docker container you must specify a `ContainerConfiguration` on the `VirtualMachineConfiguration` for a pool, and then add `TaskContainerSettings` on the Task.

### REST API version

This version of the Batch .NET client library targets version 2017-09-01.6.0 of the Azure Batch REST API.

## 7.1.0

### Features

- Added support for detailed aggregate task counts via a new `JobOperations.GetJobTaskCounts` API. Also available on `CloudJob.GetTaskCounts`.
- Added support for specifying inbound endpoints on pool compute nodes, via a new `CloudPool.PoolEndpointConfiguration` property.  This allows specific ports on the node to be addressed externally.

### REST API version

This version of the Batch .NET client library targets version 2017-06-01.5.1 of the Azure Batch REST API.

## 7.0.1

### Bug fixes

- Fixed a bug where requests using HTTP DELETE (for example, `DeletePool` and `DeleteJob`) failed with an authentication error in the netstandard package. This was due to a change made to `HttpClient` in netcore.
  - This bug impacted the 6.1.0 release as well.

### REST API version

This version of the Batch .NET client library targets version 2017-05-01.5.0 of the Azure Batch REST API.

## 7.0.0

### License

Moved source code and NuGet package from Apache 2.0 license to MIT license. This is more consistent with the other Azure SDKs as well as other open source projects from Microsoft such as .NET.

### REST API version

This version of the Batch .NET client library targets version 2017-05-01.5.0 of the Azure Batch REST API.

### Features

- Added support for the new low-priority node type.
  - **[Breaking]** `TargetDedicated` and `CurrentDedicated` on `CloudPool` and `PoolSpecification` have been renamed to `TargetDedicatedComputeNodes` and `CurrentDedicatedComputeNodes`.
  - **[Breaking]** `ResizeError` on `CloudPool` is now a collection called `ResizeErrors`.
  - Added a new `IsDedicated` property on `ComputeNode`, which is `false` for low-priority nodes.
  - Added a new `AllowLowPriorityNode` property to `JobManagerTask`, which if `true` allows the `JobManagerTask` to run on a low-priority compute node.
  - `PoolOperations.ResizePool` and `ResizePoolAsync` now take two optional parameters, `targetDedicatedComputeNodes` and `targetLowPriorityComputeNodes`, instead of one required parameter `targetDedicated`. At least one of these two parameters must be specified.
- Linux user creation improvements
  - **[Breaking]** Moved `SshPrivateKey` on `UserAccount` to a new class `LinuxUserConfiguration`, which is now a property of `UserAccount`.
  - Added support for specifying a `Uid` and `Gid` when creating a Linux user, also on the new `LinuxUserConfiguration` class.
- Added support for uploading task output files to Azure Blob storage.
  - Added support for uploading task output files to persistent storage, via the `OutputFiles` property on `CloudTask` and `JobManagerTask`.
  - Added support for specifying actions to take based on a task's output file upload status, via the `FileUploadError` property on `ExitConditions`.
- Task error reporting improvements
  - **[Breaking]** Renamed `SchedulingError` on all `ExecutionInfo` classes to `FailureInformation`. `FailureInformation` is returned any time there is a task failure. This includes all previous scheduling error cases, as well as nonzero task exit codes, and file upload failures from the new output files feature.
  - Added support for determining if a task was a success or a failure via the new `Result` property on all `ExecutionInfo` classes.
  - **[Breaking]** Renamed `SchedulingError` on `ExitConditions` to `PreProcessingError` to more clearly clarify when the error took place in the task life-cycle.
  - **[Breaking]** Renamed `SchedulingErrorCateogry` to `ErrorCategory`.
- Added support for provisioning application licenses be your pool, via a new `ApplicationLicenses` property on `CloudPool` and `PoolSpecification`.
  - Please note that this feature is in gated public preview, and you must request access to it via a support ticket.

### Bug fixes

- **[Breaking]** Removed `Unmapped` enum state from `AddTaskStatus`, `CertificateFormat`, `CertificateVisibility`, `CertStoreLocation`, `ComputeNodeFillType`, `OSType`, and `PoolLifetimeOption` as they were not ever used.

### Documentation

- Improved and clarified documentation.

### Packaging

- The package now includes a `netstandard1.4` assembly instead of the previous `netstandard1.5`.

## 6.1.0

### REST API version

This version of the Batch .NET client library targets version 2017-01-01.4.0 of the Azure Batch REST API.

### Packaging

- The client library is now supported on .NET Core. The package now includes a `netstandard1.5` assembly in addition to the `net45` assembly.

## 6.0.0

### REST API version

This version of the Batch .NET client library targets version 2017-01-01.4.0 of the Azure Batch REST API.

### Features

#### Breaking changes

- Added support for running a task under a configurable user identity via the `UserIdentity` property on all task objects (`CloudTask`, `JobPreparationTask`, `StartTask`, etc). `UserIdentity` replaces `RunElevated`. `UserIdentity` supports running a task as a predefined named user (via `UserIdentity.UserName`) or an automatically created user. The `AutoUserSpecification` specifies an automatically created user account under which to run the task. To translate existing code, change `RunElevated = true` to `UserIdentity = new UserIdentity(new AutoUserSpecification(elevationLevel: ElevationLevel.Admin))` and `RunElevated = false` to `UserIdentity = new UserIdentity(new AutoUserSpecification(elevationLevel: ElevationLevel.NonAdmin))`.
- Moved `FileToStage` implementation to the [Azure.Batch.FileStaging](https://www.nuget.org/packages/Azure.Batch.FileStaging) NuGet package and removed the dependency on `WindowsAzure.Storage` from the `Azure.Batch` package. This gives more flexibility on what version of `WindowsAzure.Storage` to use for users who do not use the `FileToStage` features.

#### Non-breaking changes

- Added support for defining pool-wide users, via the `UserAccounts` property on `CloudPool` and `PoolSpecification`. You can run a task as such a user using the `UserIdentity` constructor that takes a user name.
- Added support for requesting the Batch service provide an authentication token to the task when it runs. This is done using the `AuthenticationTokenSettings` on `CloudTask` and `JobManagerTask`. This avoids the need to pass Batch account keys to the task in order to issue requests to the Batch service.
- Added support for specifying an action to take on a task's dependencies if the task fails using the `DependencyAction` property of `ExitOptions`.
- Added support for deploying nodes using custom VHDs, via the `OSDisk` property of `VirtualMachineConfiguration`. Note that the Batch account being used must have been created with `PoolAllocationMode = UserSubscription` to allow this.
- Added support for Azure Active Directory based authentication. Use `BatchClient.Open/OpenAsync(BatchTokenCredentials)` to use this form of authentication. This is mandatory for accounts with `PoolAllocationMode = UserSubscription`.

### Package dependencies

- Removed the dependency on `WindowsAzure.Storage`.
- Updated to use version 3.3.5 of `Microsoft.Rest.ClientRuntime.Azure`.

### Documentation

- Improved and clarified documentation.

## 5.1.2

### Bug fixes

- Fixed a bug where performing `JobOperations.GetNodeFile` and `PoolOperations.GetNodeFile` could throw an `OutOfMemoryException` if the file that was being examined was large.

### REST API version

This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## 5.1.1

### Bug fixes

- Fixed a bug where certificates with a signing algorithm other than SHA1 were incorrectly imported, causing the Batch service to reject them.

### REST API version

This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## 5.1.0

### Features

- Added support for a new operation `JobOperations.ReactivateTask` (or `CloudTask.Reactivate`) which allows users to reactivate a previously failed task.

### REST API version

This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## 5.0.2

### Bug fixes

- Fixed bug where `CommitChanges` would incorrectly include elements in the request which did not actually change.

### REST API version

This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## 5.0.1

### Bug fixes

- Fixed bug where `CloudJob.Commit` and `CloudJob.CommitChanges` would hit an exception when attempting to commit a job which had previously been gotten using an `ODataDetail` select clause.

### Documentation

- Improved comments for `ExitCode` on all task execution information objects (`TaskExecutionInformation`, `JobPreparationTaskExecutionInformation`, `JobReleaseTaskExecutionInformation`, `StartTaskInformation`, etc)
- Improved documentation on `ocp-range` header format.

### REST API version

This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## 5.0.0

### Features

- Added `CommitChanges` method on `CloudJob`, `CloudJobSchedule` and `CloudPool`, which use the HTTP PATCH verb to perform partial updates, which can be safer if multiple clients are making concurrent changes).
- Added support for joining a `CloudPool` to a virtual network on using the `NetworkConfiguration` property.
- Added support for automatically terminating jobs when all tasks complete or when a task fails, via the `CloudJob.OnAllTasksComplete` and `CloudJob.OnAllTasksFailure` properties, and the `CloudTask.ExitConditions` property.
- Added support for application package references on `CloudTask` and `JobManagerTask`.

### Documentation

- Improved documentation across various classes in the `Microsoft.Azure.Batch` namespace as well as the `Microsoft.Azure.Batch.Protocol` namespaces.
- Improved documentation for `AddTask` overload which takes a collection of `CloudTask` objects to include details about possible exceptions.
- Improved documentation for the `WhenAll`/`WaitAll` methods of `TaskStateMonitor`.

### Other

- Updated constructors for the following types to more clearly convey their required properties:
  - `JobManagerTask`
  - `JobPreparationTask`
  - `JobReleaseTask`
  - `JobSpecification`
  - `StartTask`
- `TaskStateMonitor` changes:
  - Removed previously Obsolete method `WaitAllAsync`.
  - Removed `WaitAll` which returns `Task<bool>`.
  - Renamed `WhenAllAsync` to `WhenAll`.
  - `WhenAll` overloads now have a consistent return type.
  - Refactored existing methods to provide an overload which takes a `CancellationToken`, and an overload which takes a timeout.  Removed the overload which takes both.

### REST API version

This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## 4.0.1

### Bug fixes

- Fixed a bug where specifying a `DetailLevel` on a list operation would fail if the Batch service returned a list spanning multiple pages.
- Fixed a bug where `TaskDependencies` and `ApplicationPackageSummary` could throw a `NullReferenceException` if the Batch service returned a collection that was null.
- Fixed a bug where `PoolOperations.ListNodeAgentSkus` and `PoolOperations.ListPoolUsageMetrics` were missing support for `DetailLevel`.
- Updated `FileMode` comment to clarify that the default is `0770` instead of `0600`.

### REST API version

This version of the Batch .NET client library targets version 2016-02-01.3.0 of the Azure Batch REST API.

## 4.0.0

### Package dependencies

- Removed Hyak.Common dependency.
- Removed Microsoft.Azure.Common dependency.
- Added Microsoft.Rest.ClientRuntime.Azure dependency.
- Updated Azure.Storage 4.x to 6.x.

### Features

- Azure Batch now supports Linux compute nodes (you can see which Linux distributions and versions are supported by using the new `ListNodeAgentSkus` API).
- New API `ListNodeAgentSkus`.
- New API `GetRemoteLoginSettings`.
- `ResourceFile` now has a property `FileMode` which is used for Linux VM file download.
- All node file deletion methods now take an optional recursive option (which can be used on directories).
- Properties can now be read on objects after they have been committed.  An exception will be thrown if you attempt to write them though.
- `Refresh()` can now be called on objects after they have been added via `Commit()`.
- Added a new namespace `Microsoft.Azure.Batch.Protocol.BatchRequests` which contains types defined for each type of `BatchRequest`.  This is useful for writing interceptors.
- Changed various properties which had a type of `IEnumerable` to `IReadOnlyList` because they are explicitly read-only.
- Changed `CloudJob.CommonEnvironmentSettings` type from `IEnumerable` to `IList`.

### Bug fixes

- Fixed bug where `Enable` and `Disable` scheduling APIs weren't correctly inheriting the behaviors of their parent objects.
- Fixed bug in signing which breaks some requests issued with custom conditional headers such as If-Match.
- Fixed a few possible memory leaks.

### Breaking and default behavior changes

- Changed the default exception thrown from all synchronous methods.  Previously, all synchronous methods threw an `AggregateException`, which usually contained a single inner exception.  Now that inner exception will be thrown directly and it will not be wrapped in an outer `AggregateException`.
- Changed `AddTask(IEnumerable<CloudTask>)` to always wrap exceptions from its many parallel REST requests in a `ParallelOperationsException`.  Note that in some cases (such as when performing validation before issuing requests) this method can throw exceptions other than a `ParallelOperationsException`.
- The `CloudPool` class has changed to support the creation and management of Linux pools based on the virtual machine compute infrastructure as well as Windows pools based on the Azure cloud services platform.
  - To configure pools based on Azure cloud services, use the `CloudPool.CloudServiceConfiguration` property.
  - To configure pools based on the virtual machines infrastructure (specifically Linux pools), use the `CloudPool.VirtualMachineConfiguration` property.
  - The `OSFamily` and `TargetOSVersion` properties are no longer directly on the CloudPool type.  These properties apply only to cloud service pools and are now on the `CloudServiceConfiguration` type.
- Enumerations
  - Renamed `CertificateVisibility.RemoteDesktop` to `CertificateVisibility.RemoteUser`.
  - Renamed `CertificateVisibility.Invalid` to `CertificateVisibility.None`.
  - Removed `Unmapped` state for enumerations which the Batch service guarantees backwards compatibility with.
  - Removed `Invalid` state from all enums, as this is now represented by the nullability of the enum.
- Removed `ComputeNodeUser` constructor. Use the `CreateComputeNodeUser` method of the `ComputeNode` or `PoolOperations` classes instead.
- Renamed `AutoScaleEvaluation` class to `AutoScaleRun`, and removed property `DataServiceId`.
- Using a `DetailLevel` that is not supported by an operation now throws an exception (e.g. trying to use `FilterClause` on an API that doesn't support it, or trying to use `SelectClause` on an API that doesn't support it).
- Renamed `AzureError` type to `BatchError`. This should now be accessed on the `BatchException` via `BatchException.RequestInformation.BatchError`.
- Changed `AddTaskResult`:
  - `StatusCode` is now Status and is an enum instead of an int.
  - `ContentId` removed.
  - `DataServiceId` removed.
- `BatchClient.Open` and `BatchClient.OpenAsync` now take a `BatchServiceClient` object, not a `BatchRestClient` object.
- Made `AffinityInformation` read-only after construction.
- Changed `TaskSchedulingPolicy.ComputeNodeFillType` to be non-nullable.
- Removed `ReadAsStringAsync` optional Stream parameter.
- Refactored the protocol namespace. It is now generated via the AutoRest tool (<https://github.com/Azure/autorest>).
  - Removed the `BatchRequest` constructor which took a `BatchRestClient` (it had been marked obsolete since Azure.Batch 3.0.0).
  - Significantly refactored `BatchRequest`.
  - Changed request interceptor types to reflect changes to `BatchRequest`.
  - Changed most types in this namespace to comply with the new underlying protocol layer generated by AutoRest.
- Removed `ResourceStatistics.DiskWriteIOps` setter.
- Removed `TaskInformation.JobScheduleId` property.

### REST API version

This version of the Batch .NET client library targets version 2016-02-01.3.0 of the Azure Batch REST API.
