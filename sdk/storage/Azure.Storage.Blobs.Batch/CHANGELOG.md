# Release History

## 12.23.0 (2025-10-13)

### Features Added
- Includes all features from 12.23.0-beta.1

## 12.22.0 (2025-07-14)

### Features Added
- Includes all features from 12.22.0-beta.1

## 12.22.0 (2025-07-14)

### Features Added
- Includes all features from 12.22.0-beta.1

## 12.23.0-beta.1 (2025-06-09)

### Features Added
- Added support for service version 2025-11-05.
- Added more useful error message when the SDK encounters an x-ms-version mis-match issue.

## 12.22.0-beta.1 (2025-05-06)

### Features Added
- Added support for service version 2025-07-05.

## 12.21.0 (2025-03-11)

### Features Added
- Includes all features from 12.21.0-beta.1

### Bugs Fixed
- Fixed an issue where batch subrequests would not authenticate properly if using `TokenCredential` authentication when the `BlobBatchClient` was created from `BlobContianerClient.GetBlobBatchClient`.

## 12.21.0-beta.1 (2025-02-11)

### Features Added
- Added support for service version 2025-05-05.

## 12.20.0 (2024-11-12)

### Features Added
- Includes all features from 12.20.0-beta.1 and 12.20.0-beta.2.

## 12.20.0-beta.2 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.19.1 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.20.0-beta.1 (2024-10-08)

### Features Added
- Added support for service version 2025-01-05.

## 12.19.0 (2024-09-18)

### Features Added
- Includes all features from 12.19.0-beta.1.

## 12.19.0-beta.1 (2024-08-06)

### Features Added
- Added support for service version 2024-11-04.

## 12.18.1 (2024-07-25)

### Bugs Fixed
- Fixed \[BUG\] Azure Blob Storage Client SDK No Longer Supports Globalization Invariant Mode for Account Key Authentication #45052

## 12.18.0 (2024-07-16)

### Features Added
- Includes all features from 12.18.0-beta.1.

## 12.18.0-beta.1 (2024-06-11)
- Added support for service version 2024-08-04.

## 12.17.0 (2024-05-15)
- Includes all features from 12.17.0-beta.1 and 12.17.0-beta.2.

## 12.17.0-beta.2 (2024-04-15)
- Added support for service version 2023-05-04.
- Added support for deleting individual blob versions.

## 12.17.0-beta.1 (2023-12-05)
- Added support for service version 2024-02-04.

## 12.16.1 (2023-11-13)
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 12.16.0 (2023-11-06)
- Includes all features from 12.16.0-beta.1.

## 12.16.0-beta.1 (2023-10-16)
- Added support for service version 2023-11-03.

## 12.15.0 (2023-09-12)
- Includes all features from 12.15.0-beta.1.

## 12.15.0-beta.1 (2023-08-08)
- Added support for service version 2023-05-03 and 2023-08-03.

## 12.14.0 (2023-07-11)
- Includes all features from 12.14.0-beta.1.

## 12.14.0-beta.1 (2023-05-30)
- Added support for service version 2023-01-03.

## 12.13.0 (2023-04-11)
- Includes all features from 12.13.0-beta.1.

## 12.13.0-beta.1 (2023-03-28)
- Added support for service version 2022-11-02.
- `BlobBatch` is made explicitly resilient to multiple dispose

## 12.12.1 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 12.12.0 (2023-02-21)
- Includes all features from 12.12.0-beta.1.

## 12.12.0-beta.1 (2023-02-07)
- Added support for service version 2021-12-02.

## 12.11.0 (2022-10-12)
- Includes all features from 12.11.0-beta.1.

## 12.11.0-beta.1 (2022-08-23)
- Added support for service version 2021-10-04.

## 12.10.0 (2022-07-07)
- Includes all features from 12.10.0-beta.1.

## 12.10.0-beta.1 (2022-06-15)
- Added support for service version 2021-08-06.

## 12.9.0 (2022-05-02)
- Includes all features from 12.9.0-beta.1.

## 12.9.0-beta.1 (2022-04-12)
- Added support for service version 2021-06-08.

## 12.8.0 (2022-03-10)
- Includes all features from 12.8.0-beta.1, 12.8.0-beta.2, and 12.8.0-beta.3

## 12.8.0-beta.3 (2022-02-07)
- Added support for service version 2021-04-10.

## 12.8.0-beta.2 (2021-11-30)
- Added support for service vesrion 2021-02-12.

## 12.8.0-beta.1 (2021-11-03)
- Added support for service version 2020-12-06.

## 12.7.0 (2021-09-08)
- Includes all features from 12.7.0-beta.1 and 12.7.0-beta.2.
- Fixed bug where Batch Delete was not property parsing DeleteSnapshotsOption.

## 12.7.0-beta.2 (2021-07-23)
- This release contains bug fixes to improve quality.

## 12.7.0-beta.1 (2021-07-22)
- Added support for service version 2020-10-02.
- TenantId can now be discovered through the service challenge response, when using a TokenCredential for authorization.
    - A new property is now available on the ClientOptions called `EnableTenantDiscovery`. If set to true, the client will attempt an initial unauthorized request to the service to prompt a challenge containing the tenantId hint.
- Fixed bug where blob name was not encoded properly when using batch operations.

## 12.6.0 (2021-06-08)
- Includes all features from 12.6.0-beta.4.

## 12.5.2 (2021-05-20)
- This release contains bug fixes to improve quality.

## 12.6.0-beta.4 (2021-05-12)
- Added support for service version 2020-08-04.
- This release contains bug fixes to improve quality.

## 12.6.0-beta.3 (2021-04-09)
- This release contains bug fixes to improve quality.

## 12.5.1 (2021-03-29)
- Fixed bug where ClientDiagnostics's DiagnosticListener was leaking resources.

## 12.6.0-beta.2 (2021-03-09)
- This release contains bug fixes to improve quality.

## 12.6.0-beta.1 (2021-02-09)
- Added support for service version 2020-06-12.
- Added support for container-scoped batch requests.
- This release contains bug fixes to improve quality.

## 12.5.0 (2021-01-12)
- Includes all features from 12.5.0-beta.1.
- This release contains bug fixes to improve quality.

## 12.5.0-beta.1 (2020-12-07)
- Added support for service version 2020-04-08.
- This release contains bug fixes to improve quality.

## 12.4.0 (2020-11-10)
- This release contains bug fixes to improve quality.
- Includes all features from 12.4.0-preview.1

## 12.4.0-preview.1 (2020-09-30)
- Added support for service version 2020-02-10.
- This release contains bug fixes to improve quality.

## 12.3.1 (2020-08-18)
- Fixed bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 12.3.0 (2020-08-13)
- Includes all features from 12.3.0-preview.1 through 12.3.0-preview.2.
- This release contains bug fixes to improve quality.

## 12.3.0-preview.2 (2020-07-03)
- This release contains bug fixes to improve quality.

## 12.3.0-preview.1 (2020-07-03)
- Added support for service version 2019-12-12.
- This release contains bug fixes to improve quality.

## 12.2.1 
- Minor bugfixes around task completion.

## 12.2.0 
- Added support for service version 2019-07-07.
- Sanitized header values in exceptions.

## 12.1.1 
- Pass Storage version to each API.

## 12.1.0 
- Removed internal dependencies

## 12.0.0 
- Azure.Storage.Blobs.Batching assembly and package are renamed to
  Azure.Storage.Blobs.Batch for consistency with other platforms.

## 12.0.0-preview.4 
- This preview is the first release supporting batched operations for Azure
Storage blobs.
