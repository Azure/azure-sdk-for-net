# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2022-08-26)
## Features Added
- Added Batching and GZip capabilities to Upload methods
- Added Model `UploadLogsResult` containing the result of a logs upload operation
- Added Model `UploadLogsError` representing the error and the associated logs that failed when uploading a subset of logs to Azure Monitor.
- Added Model `UploadLogsStatus` indicating the status of a logs upload operation.
- Added Upload overload that takes a List<T> of logs

## 1.0.0-beta.1 (2022-07-05)
Version 1.0.0-beta.1 is a preview for the Azure Monitor service to ingest logs and designed to be developer-friendly, idiomatic to the .NET ecosystem, and as consistent across different languages and platforms as
possible. The principles that guide our efforts can be found in the
[Azure SDK Design Guidelines for .NET](https://azure.github.io/azure-sdk/dotnet_introduction.html).

## Features Added
- Initial release. See the README for information on using the new library.

