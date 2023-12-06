# Release History

## 12.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Fixed a bug where `ChannelClosedException` could occur and be sent as an event to `ItemTransferFailed` when there was a failure during a transfer.

### Other Changes

## 12.0.0-beta.4 (2023-12-05)

### Features Added
- Added support for `TransferManager.ResumeAllTransfersAsync` to resume all transfers that can be resumed.

### Breaking Changes
- [BREAKING CHANGE] Renamed `StorageResourceSingle` to `StorageResourceItem`
- [BREAKING CHANGE] Renamed `StorageResource.MaxChunkSize` to `MaxSupportedChunkSize`.
- [BREAKING CHANGE] Made the following members `public` to `protected internal` members (including all derived classes):
    - `StorageResource.IsContainer`
    - `StorageResourceContainer.GetStorageResourcesAsync`
    - `StorageResourceItem.Length`
    - `StorageResourceItem.MaxSupportedChunkSize`
    - `StorageResourceItem.ResourceId`
    - `StorageResourceItem.TransferType`
    - `StorageResourceItem.CompleteTransferAsync`
    - `StorageResourceItem.CopyBlockFromUriAsync`
    - `StorageResourceItem.CopyFromUriAsync`
    - `StorageResourceItem.DeleteIfExistsAsync`
    - `StorageResourceItem.GetCopyAuthorizationHeaderAsync`
    - `StorageResourceItem.GetPropertiesAsync`
    - `StorageResourceItem.ReadStreamAsync`
    - `StorageResourceItem.WriteFromStreamAsync`
- [BREAKING CHANGE] Renamed `DataTransfer.AwaitCompletion` to `DataTransfer.WaitForCompletionAsync`
- [BREAKING CHANGE] Renamed `DataTransfer.EnsureCompleted` to `DataTransfer.WaitForCompletion`
- [BREAKING CHANGE] Renamed `DataTransfer.PauseIfRunningAsync` to `DataTransfer.PauseAsync`
- [BREAKING CHANGE] Removed `Azure.Storage.DataMovement.Models` and moved all classes to the `Azure.Storage.DataMovement` namespace
- [BREAKING CHANGE] Removed `Azure.Storage.DataMovement.Models.JobPlan` and replaced with `Azure.Storage.DataMovement.JobPlan` (has no public effect since it's internal)
- [BREAKING CHANGE] Removed `DataTransfer.PauseTransferIfRunningAsync(DataTransfer)`
- [BREAKING CHANGE] Renamed `DataTransferProperties.SourceScheme`.
- [BREAKING CHANGE] Removed `DataTransferProperties.DestinationScheme`.
- [BREAKING CHANGE] Removed `StorageResourceType` including removing `StorageResourceProperties.ResourceType`
- [BREAKING CHANGE] Removed `ServiceCopyStatus` including removing `StorageResourceProperties.CopyStatus`
- [BREAKING CHANGE] Renamed `TransferOptions` to `DataTransferOptions`
- [BREAKING CHANGE] Renamed `TransferCheckpointerOptions` to `TransferCheckpointStoreOptions`
- [BREAKING CHANGE] Renamed `TransferOptions.TransferFailed` to `DataTransferOptions.ItemTransferFailed`
- [BREAKING CHANGE] Renamed `TransferOptions.SingleTransferCompleted` to `DataTransferOptions.ItemTransferCompleted`
- [BREAKING CHANGE] Renamed `TransferOptions.TransferSkipped` to `DataTransferOptions.ItemTransferSkipped`
- [BREAKING CHANGE] Renamed `TransferOptions.TransferStatus` to `TransferOptions.TransferStatusChanged`
- [BREAKING CHANGE] Renamed `SingleTransferCompletedEventArgs` to `TransferItemCompletedEventArgs`
- [BREAKING CHANGE] Renamed `TransferItemFailedEventArgs` to `TransferItemFailedEventArgs`
- [BREAKING CHANGE] Renamed `TransferItemSkippedEventArgs` to `TransferItemSkippedEventArgs`
- [BREAKING CHANGE] Renamed `TransferStatusEventArgs.StorageTransferStatus` to `TransferStatus`
- [BREAKING CHANGE] Renamed `StorageResourceItem.WriteFromStreamAsync` to `CopyFromStreamAsync`
- [BREAKING CHANGE] Renamed `StorageResourceContainer.GetChildStorageResource` to `StorageResourceContainer.GetStorageResourceReference`
- [BREAKING CHANGE] Renamed `ReadStreamStorageResourceResult` to `StorageResourceReadStreamResult`
- [BREAKING CHANGE] Changed constructor `StorageResourceReadStreamResult(Stream)` from public to internal
- [BREAKING CHANGE] Removed `LocalStorageResourceProvider.MakeResource`. Instead use `LocalFilesStorageResourceProvider.FromFile()` and `.FromDirectory()` to obtain a Local `StorageResource`.
- [BREAKING CHANGE] Renamed `ErrorHandlingBehavior` to `DataTransferErrorMode`
- [BREAKING CHANGE] Renamed `DataTransferErrorMode.StopOnAllFailures` to `StopOnAnyFailure`
- [BREAKING CHANGE] Renamed `TransferType` to `DataTransferOrder`
- [BREAKING CHANGE] Renamed `DataTransferOrder.Concurrent` to `Unordered`
- [BREAKING CHANGE] Renamed `StorageTransferStatus` to `DataTransferStatus`
- [BREAKING CHANGE] Changed `DataTransferStatus` from `enum` to a `class`.
- [BREAKING CHANGE] Renamed `StorageResourceCreateMode` to `StorageResourceCreationPreference`.
- [BREAKING CHANGE] Renamed `StorageResourceCreationPreference` values from `Fail` to `FailIfExists`, `Overwrite` to `OverwriteIfExists`, `Skip` to `SkipIfExists` and `None` to `Default` which will default to `FailIfExists`.
- [BREAKING CHANGE] Renamed `DataTransferOptions.CreateMode` to `CreationPreference`.
- [BREAKING CHANGE] Changed `StorageTransferProgress` constructor from `public` to `protected internal`. 
- [BREAKING CHANGE] Renamed `StorageTransferProgress` to `DataTransferProgress`.
- [BREAKING CHANGE] Renamed `StorageTransferEventArgs` to `DataTransferEventArgs`.
- [BREAKING CHANGE] Removed `position` parameter from `StorageResourceSingle.WriteFromStreamAsync`. Use `StorageResourceWriteToOffsetOptions.Position` instead.
- [BREAKING CHANGE] Made parameter `completeLength` from `StorageResourceSingle.CopyBlockFromUriAsync` mandatory.
- [BREAKING CHANGE] Moved `DataTransferOptions.ProgressHandler` to `DataTransferOptions.ProgressHandlerOptions`.
- [BREAKING CHANGE] Removed default constructor for `ProgressHandlerOptions`. Use `ProgressHandlerOptions(IProgress<DataTransferProgress>, bool)` instead.
- [BREAKING CHANGE] Removed `StorageResource.CanProduceUri` (including it's derived classes).
- [BREAKING CHANGE] Removed `StorageResource.Path`, use `StorageResource.Uri` instead.
- [BREAKING CHANGE] Moved `DataTransferProperties` to the parent namespace, `Azure.Storage.DataMovement`.
- [BREAKING CHANGE] Removed `DataTransferProperties.SourcePath`. Instead use `DataTransferProperties.SourceUri`.
- [BREAKING CHANGE] Removed `DataTransferProperties.DestinationPath`. Instead use `DataTransferProperties.DestinationUri`.
- [BREAKING CHANGE] Changed `StorageResourceCheckpointData.Serialize()` from `public` to `protected internal`
- [BREAKING CHANGE] Made the following from `public` to `internal` (Use `LocalStorageResourceProvider` instead to create `StorageResource`s) :
    - `LocalDirectoryStorageResourceContainer`
    - `LocalFileStorageResource`

### Bugs Fixed
- Fixed bug where if a transfer was in a failed state, and during clean up an exception was thrown the transfer would throw or hang.

## 12.0.0-beta.3 (2023-07-11)

### Features Added
- `TransferManager` new API `PauseAllRunningTransfersAsync`.
- Added support for `TransferManager.GetTransfers`, to retrieve the list of transfers in the `TransferManager`.
- Added support for tracking progress of transfers. See `TransferOptions.ProgressHandler` and `TransferOptions.ProgressHandlerOptions`.
- Added `TransferManager.GetResumableTransfers` to get information about transfers that can be resumed.
- Added support for `Transfermanager.ResumeTransferAsync` to resume a transfer.
- Added support authorization using Azure Active Directory when using Service to Service Copy. 

### Breaking Changes
- [BREAKING CHANGE] Altered API signatures on `TransferManager` and `DataTransfer` for pausing.
- [BREAKING CHANGE] `StorageResouceContainer.GetParentStorageResourceContainer()` removed.
- [BREAKING CHANGE] Updated `StorageResource.CompleteTransferAsync` to have an added overwrite parameter: `StorageResource.CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)`.
- [BREAKING CHANGE] Renamed `StorageResource` to `StorageResourceSingle` and `StorageResourceBase` to `StorageResouce`.
- [BREAKING CHANGE] Combined both `TransferManager.StartTransferAsync` methods into one that accepts single or container resources. All existing calls should continue to work due to inheritence.
- [BREAKING CHANGE] Renamed `ErrorHandlingOptions` to `ErrorHandlingBehavior`.
- [BREAKING CHANGE] Changed type of `StorageResource.CanProduceUri` to `bool`.
- [BREAKING CHANGE] Removed `TransferOptions.ResumeFromCheckpointId`. Use `Transfermanager.ResumeTransferAsync` to resume a transfer instead.

### Bugs Fixed
- Fix to prevent empty strings or null to be passed as paths for `LocalFileStorageResource` and `LocalDirectoryStorageResourceContainer`.
- Fixed `ErrorHandlingOptions.ContinueOnFailure` not be respected.
- Fixed bug where resuming a transfer where the source and destination is a `StorageResourceContainer` would throw a null reference exception. 
- Fixed bug when downloading zero length `StorageResource`s in a `StorageResourceContainer` will throw an exception.

## 12.0.0-beta.2 (2023-04-26)
- [BREAKING CHANGE] Combined `SingleTransferOptions` and `ContainerTransferOptions` into `TransferOptions`.
- [BREAKING CHANGE] If `TransferOptions.CreateMode` is not specified, it will default to `StorageResourceCreateMode.Fail` instead of `Overwrite`.
- Fix to prevent thread starvation on the DataTransfer.AwaitCompletion
- Fix to prevent unnecessary OperationCancelledException's showing up in the TransferOptions.TransferFailed when cancelling a job.

## 12.0.0-beta.1 (2022-12-15)
- This preview is the first release of a ground-up rewrite of our client data movement
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
