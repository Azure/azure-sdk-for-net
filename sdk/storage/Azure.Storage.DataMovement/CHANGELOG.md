# Release History

## 12.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes
- [BREAKING CHANGE] Made the following members `public` to `protected internal` members (including all derived classes):
    - `StorageResource.CanProduceUri`
    - `StorageResource.IsContainer`
    - `StorageResourceContainer.GetStorageResourcesAsync`
    - `StorageResourceSingle.Length`
    - `StorageResourceSingle.MaxChunkSize`
    - `StorageResourceSingle.ResourceId`
    - `StorageResourceSingle.TransferType`
    - `StorageResourceSingle.CompleteTransferAsync`
    - `StorageResourceSingle.CopyBlockFromUriAsync`
    - `StorageResourceSingle.CopyFromUriAsync`
    - `StorageResourceSingle.DeleteIfExistsAsync`
    - `StorageResourceSingle.GetCopyAuthorizationHeaderAsync`
    - `StorageResourceSingle.GetPropertiesAsync`
    - `StorageResourceSingle.ReadStreamAsync`
    - `StorageResourceSingle.WriteFromStreamAsync`

### Bugs Fixed

### Other Changes

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
