# Release History

## 12.0.0-preview.43 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 12.0.0-preview.42 (2023-12-05)
- Added support for service version 2024-02-04.

## 12.0.0-preview.41 (2023-11-13)
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 12.0.0-preview.40 (2023-11-06)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.39 (2023-10-16)
- Added support for service version 2023-11-03.

## 12.0.0-preview.38 (2023-09-12)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.37 (2023-08-08)
- Added support for service version 2023-05-03 and 2023-08-03.

## 12.0.0-preview.36 (2023-07-11)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.35 (2023-05-30)
- Added support for service version 2023-01-03.

## 12.0.0-preview.34 (2023-04-11)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.33 (2023-03-28)
- Added support for service version 2022-11-02.

## 12.0.0-preview.32 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 12.0.0-preview.31 (2023-02-21)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.30 (2023-02-07)
- Added support for service version 2021-12-02.

## 12.0.0-preview.29 (2022-10-12)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.28 (2022-08-23)
- Added support for service version 2021-10-04.

## 12.0.0-preview.27 (2022-07-07)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.26 (2022-06-15)
- Added support for service version 2021-08-06.
- Fixed bug where BlobType == PageBlob was not being parsed correctly.

## 12.0.0-preview.25 (2022-05-02)
- Updated Change Feed to return 0 events when meta/segments.json file hasn't been created yet.

## 12.0.0-preview.24 (2022-04-19)
- Added ability to specify chunk download size with BlobChangeFeedClientOptions.MaximumTransferSize.

## 12.0.0-preview.23 (2022-04-13)
- Fixed bug where BlobChangeFeedEvent.BlobChangeFeedEventData.PreviousInfo.WasBlobSoftDeleted was not being deserialized correctly.

## 12.0.0-preview.22 (2022-04-12)
- Added support for service version 2021-06-08.

## 12.0.0-preview.21 (2022-03-30)
- Fixed bug where BlobChangeFeedEvent.BlobChangeFeedEventData.AsyncOperationInfo.IsAsync was not being deserialized correctly.

## 12.0.0-preview.20 (2022-03-10)
- Added support for event schema V3, V4, and V5.

## 12.0.0-preview.19 (2022-02-07)
- Added support for service version 2021-04-10.

## 12.0.0-preview.18 (2021-11-30)
- Added support for service version 2021-02-12.

## 12.0.0-preview.17 (2021-11-03)
- Added support for service version 2020-12-06.
- This release contains bug fixes to improve quality.
- Fixed bug where Segment.GetCursor() would throw an ArgumentOutOfRangeException if the Segment has no Shards.

## 12.0.0-preview.16 (2021-09-08)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.15 (2021-07-23)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.14 (2021-07-22)
- TenantId can now be discovered through the service challenge response, when using a TokenCredential for authorization.
    - A new property is now available on the ClientOptions called `EnableTenantDiscovery`. If set to true, the client will attempt an initial unauthorized request to the service to prompt a challenge containing the tenantId hint.
- Fixed bug where "Segment doesn't have any more events" exception was throw when attempting to resume from a cusor pointed at a segment that had no more events, and newer segments exist in the Change Feed.

## 12.0.0-preview.13 (2021-06-08)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.12 (2021-05-12)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.11 (2021-04-09)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.10 (2021-03-09)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.9 (2021-02-09)
- Added support for service version 2020-06-12.
- This release contains bug fixes to improve quality.

## 12.0.0-preview.8 (2021-01-12)
- Fixed bug where we couldn't handle BlobChangeFeedEvent.EventData.ClientRequestIds that were not GUIDs.

## 12.0.0-preview.7 (2020-12-07)
- Added support for service version 2020-04-08.
- This release contains bug fixes to improve quality.

## 12.0.0-preview.6 (2020-11-10)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.5 (2020-09-30)
- Added support for service version 2020-02-10.
- This release contains bug fixes to improve quality.

## 12.0.0-preview.4 (2020-08-18)
- Fixed bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 12.0.0-preview.3 (2020-08-13)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.2 (2020-07-27)
- This release contains bug fixes to improve quality.

## 12.0.0-preview.1 (2020-07-03)
- This preview is the first release supporting Azure Storage Blobs Change Feed.
