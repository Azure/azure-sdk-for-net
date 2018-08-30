# Microsoft.Azure.Batch release notes

## Changes in 9.0.0
### Features
- Added the ability to see what version of the Azure Batch Node Agent is running on each of the VMs in a pool, via the new `NodeAgentInformation` property on `ComputeNode`.
- Added the ability to specify a `Filter` on the `Result` of a task. See [here](https://docs.microsoft.com/en-us/rest/api/batchservice/odata-filters-in-batch) for more details.
  - This enables the often requested scenario of performing a server-side query to find all tasks which failed.
- **[Breaking]** Added a default retry policy to `BatchClient`.
  - Note that this policy may not be sufficient for every case. If the old behavior (a `BatchClient` that doesn't perform any retries) is desired, the default policy can be removed from a `BatchClient` with `client.CustomBehaviors = client.CustomBehaviors.Where(behavior => !(behavior is RetryPolicyProvider)).ToList()`.
- **[Breaking]** Removed the `ValidationStatus` property from `TaskCounts`, as well as the `TaskCountValidationStatus` enum.
- **[Breaking]** The default caching type for `DataDisk` and `OSDisk` is now `ReadWrite` instead of `None`.

### Bug fixes
- Fixed bug when using `BatchSharedKeyCredentials` where some operations would fail with an `Unauthenticated` error in `netcoreapp2.1` even though the right shared key was used.

### REST API version
This version of the Batch .NET client library targets version 2018-08-01.7.0 of the Azure Batch REST API.

## Changes in 8.1.2
Rename Nuget package name from Azure.Batch to Microsoft.Azure.Batch

# Prior to version 8.1.2, this package was named "Azure.Batch" on Nuget. The release notes below are for that package.

## Changes in 8.1.2
Add deprecation announcement to nuget package.

## Changes in 8.1.1
### Bug fixes
 - Fixed bug where LeavingPool state was not correctly returned via the `ListPoolNodeCounts` method on `PoolOperations`.
 - Clarified various confusing documentation.

### REST API version
This version of the Batch .NET client library targets version 2018-02-01.6.1 of the Azure Batch REST API.

## Changes in 8.1.0
### Features
 - Added the ability to query pool node counts by state, via the new `ListPoolNodeCounts` method on `PoolOperations`.
 - Added the ability to upload Azure Batch node agent logs from a particular node, via the `UploadComputeNodeBatchServiceLogs` method on `PoolOperations` and `ComputeNode`.
   - This is intended for use in debugging by Microsoft support when there are problems on a node.

### REST API version
This version of the Batch .NET client library targets version 2018-02-01.6.1 of the Azure Batch REST API.

### Import Note
The package will be renamed to Microsoft.Azure.Batch in a future release.

## Changes in 8.0.1
### Bug fixes
- Fixed a bug where deserializing some enum properties could fail if using Newtonsoft 10.

### REST API version
This version of the Batch .NET client library targets version 2017-09-01.6.0 of the Azure Batch REST API.

## Changes in 8.0.0
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

## Changes in 7.1.0
### Features
- Added support for detailed aggregate task counts via a new `JobOperations.GetJobTaskCounts` API. Also available on `CloudJob.GetTaskCounts`.
- Added support for specifying inbound endpoints on pool compute nodes, via a new `CloudPool.PoolEndpointConfiguration` property.  This allows specific ports on the node to be addressed externally.

### REST API version
This version of the Batch .NET client library targets version 2017-06-01.5.1 of the Azure Batch REST API.

## Changes in 7.0.1
### Bug fixes
- Fixed a bug where requests using HTTP DELETE (for example, `DeletePool` and `DeleteJob`) failed with an authentication error in the netstandard package. This was due to a change made to `HttpClient` in netcore.
  - This bug impacted the 6.1.0 release as well.

### REST API version
This version of the Batch .NET client library targets version 2017-05-01.5.0 of the Azure Batch REST API.

## Changes in 7.0.0
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

## Changes in 6.1.0
### REST API version
This version of the Batch .NET client library targets version 2017-01-01.4.0 of the Azure Batch REST API.

### Packaging
- The client library is now supported on .NET Core. The package now includes a `netstandard1.5` assembly in addition to the `net45` assembly.

## Changes in 6.0.0
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

## Changes in 5.1.2
### Bug fixes
- Fixed a bug where performing `JobOperations.GetNodeFile` and `PoolOperations.GetNodeFile` could throw an `OutOfMemoryException` if the file that was being examined was large.

### REST API version
This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## Changes in 5.1.1
### Bug fixes
- Fixed a bug where certificates with a signing algorithm other than SHA1 were incorrectly imported, causing the Batch service to reject them.

### REST API version
This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## Changes in 5.1.0
### Features
- Added support for a new operation `JobOperations.ReactivateTask` (or `CloudTask.Reactivate`) which allows users to reactivate a previously failed task.

### REST API version
This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## Changes in 5.0.2
### Bug fixes
- Fixed bug where `CommitChanges` would incorrectly include elements in the request which did not actually change.

### REST API version
This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## Changes in 5.0.1
### Bug fixes
- Fixed bug where `CloudJob.Commit` and `CloudJob.CommitChanges` would hit an exception when attempting to commit a job which had previously been gotten using an `ODataDetail` select clause.

### Documentation
- Improved comments for `ExitCode` on all task execution information objects (`TaskExecutionInformation`, `JobPreparationTaskExecutionInformation`, `JobReleaseTaskExecutionInformation`, `StartTaskInformation`, etc)
- Improved documentation on `ocp-range` header format.

### REST API version
This version of the Batch .NET client library targets version 2016-07-01.3.1 of the Azure Batch REST API.

## Changes in 5.0.0
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

## Changes in 4.0.1
### Bug fixes
-  Fixed a bug where specifying a `DetailLevel` on a list operation would fail if the Batch service returned a list spanning multiple pages.
-  Fixed a bug where `TaskDependencies` and `ApplicationPackageSummary` could throw a `NullReferenceException` if the Batch service returned a collection that was null.
-  Fixed a bug where `PoolOperations.ListNodeAgentSkus` and `PoolOperations.ListPoolUsageMetrics` were missing support for `DetailLevel`.
-  Updated `FileMode` comment to clarify that the default is `0770` instead of `0600`. 

### REST API version
This version of the Batch .NET client library targets version 2016-02-01.3.0 of the Azure Batch REST API.

## Changes in 4.0.0
### Package dependencies
-  Removed Hyak.Common dependency.
-  Removed Microsoft.Azure.Common dependency.
-  Added Microsoft.Rest.ClientRuntime.Azure dependency.
-  Updated Azure.Storage 4.x to 6.x.

### Features
-  Azure Batch now supports Linux compute nodes (you can see which Linux distributions and versions are supported by using the new `ListNodeAgentSkus` API).
-  New API `ListNodeAgentSkus`.
-  New API `GetRemoteLoginSettings`.
-  `ResourceFile` now has a property `FileMode` which is used for Linux VM file download.
-  All node file deletion methods now take an optional recursive option (which can be used on directories).
-  Properties can now be read on objects after they have been committed.  An exception will be thrown if you attempt to write them though.
-  `Refresh()` can now be called on objects after they have been added via `Commit()`.
-  Added a new namespace `Microsoft.Azure.Batch.Protocol.BatchRequests` which contains types defined for each type of `BatchRequest`.  This is useful for writing interceptors.
-  Changed various properties which had a type of `IEnumerable` to `IReadOnlyList` because they are explicitly read-only.
-  Changed `CloudJob.CommonEnvironmentSettings` type from `IEnumerable` to `IList`.

### Bug fixes
-  Fixed bug where `Enable` and `Disable` scheduling APIs weren't correctly inheriting the behaviors of their parent objects.
-  Fixed bug in signing which breaks some requests issued with custom conditional headers such as If-Match.
-  Fixed a few possible memory leaks.

### Breaking and default behavior changes
-  Changed the default exception thrown from all synchronous methods.  Previously, all synchronous methods threw an `AggregateException`, which usually contained a single inner exception.  Now that inner exception will be thrown directly and it will not be wrapped in an outer `AggregateException`.
-  Changed `AddTask(IEnumerable<CloudTask>)` to always wrap exceptions from its many parallel REST requests in a `ParallelOperationsException`.  Note that in some cases (such as when performing validation before issuing requests) this method can throw exceptions other than a `ParallelOperationsException`.
-  The `CloudPool` class has changed to support the creation and management of Linux pools based on the virtual machine compute infrastructure as well as Windows pools based on the Azure cloud services platform.
    -  To configure pools based on Azure cloud services, use the `CloudPool.CloudServiceConfiguration` property.
    -  To configure pools based on the virtual machines infrastructure (specifically Linux pools), use the `CloudPool.VirtualMachineConfiguration` property.
    -  The `OSFamily` and `TargetOSVersion` properties are no longer directly on the CloudPool type.  These properties apply only to cloud service pools and are now on the `CloudServiceConfiguration` type.
-  Enumerations
    -  Renamed `CertificateVisibility.RemoteDesktop` to `CertificateVisibility.RemoteUser`.
    -  Renamed `CertificateVisibility.Invalid` to `CertificateVisibility.None`.
    -  Removed `Unmapped` state for enumerations which the Batch service guarantees backwards compatibility with.
    -  Removed `Invalid` state from all enums, as this is now represented by the nullability of the enum.
-  Removed `ComputeNodeUser` constructor. Use the `CreateComputeNodeUser` method of the `ComputeNode` or `PoolOperations` classes instead.
-  Renamed `AutoScaleEvaluation` class to `AutoScaleRun`, and removed property `DataServiceId`.
-  Using a `DetailLevel` that is not supported by an operation now throws an exception (e.g. trying to use `FilterClause` on an API that doesn't support it, or trying to use `SelectClause` on an API that doesn't support it).
-  Renamed `AzureError` type to `BatchError`. This should now be accessed on the `BatchException` via `BatchException.RequestInformation.BatchError`.
-  Changed `AddTaskResult`:
    -  `StatusCode` is now Status and is an enum instead of an int.
    -  `ContentId` removed.
    -  `DataServiceId` removed.
-  `BatchClient.Open` and `BatchClient.OpenAsync` now take a `BatchServiceClient` object, not a `BatchRestClient` object.
-  Made `AffinityInformation` read-only after construction.
-  Changed `TaskSchedulingPolicy.ComputeNodeFillType` to be non-nullable.
-  Removed `ReadAsStringAsync` optional Stream parameter.
-  Refactored the protocol namespace. It is now generated via the AutoRest tool (https://github.com/Azure/autorest).
    -  Removed the `BatchRequest` constructor which took a `BatchRestClient` (it had been marked obsolete since Azure.Batch 3.0.0).
    -  Significantly refactored `BatchRequest`.
    -  Changed request interceptor types to reflect changes to `BatchRequest`.
    -  Changed most types in this namespace to comply with the new underlying protocol layer generated by AutoRest.
-  Removed `ResourceStatistics.DiskWriteIOps` setter.
-  Removed `TaskInformation.JobScheduleId` property.

### REST API version
This version of the Batch .NET client library targets version 2016-02-01.3.0 of the Azure Batch REST API.