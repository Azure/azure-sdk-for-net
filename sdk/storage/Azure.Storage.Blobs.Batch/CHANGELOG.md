# Release History

## 12.8.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
