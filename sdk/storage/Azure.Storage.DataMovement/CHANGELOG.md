# Release History

## 12.0.0-beta.3 (Unreleased)

### Features Added
- `TransferManager` new API `PauseAllRunningTransfersAsync`.
- Added support for `TransferManager.GetTransfers`, to retrieve the list of transfers in the `TransferManager`.
- Added support for tracking progress of transfers. See `TransferOptions.ProgressHandler` and `TransferOptions.ProgressHandlerOptions`.

### Breaking Changes
- [BREAKING CHANGE] Altered API signatures on `TransferManager` and `DataTransfer` for pausing.
- [BREAKING CHANGE] Updated `StorageResource.CompleteTransferAsync` to have an added overwrite parameter: `StorageResource.CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)`.

### Bugs Fixed
- Fix to prevent empty strings or null to be passed as paths for `LocalFileStorageResource` and `LocalDirectoryStorageResourceContainer`.
- Fixed `ErrorHandlingOptions.ContinueOnFailure` not be respected.
- Fixed bug where resuming a transfer where the source and destination is a `StorageResourceContainer` would throw a null reference exception. 
- Fixed bug when downloading zero length `StorageResource`s in a `StorageResourceContainer` will throw an exception.

### Other Changes

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
