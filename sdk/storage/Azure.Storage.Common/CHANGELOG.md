# Release History

## 12.19.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 12.19.0-beta.1 (2023-12-05)
- Fixed bug where parsing the "sdd" value of a SAS would increment the value by 6 if the value was 10 or over.

## 12.18.1 (2023-11-13)
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 12.18.0 (2023-11-06)
- Includes all features from 12.18.0-beta.1.

## 12.18.0-beta.1 (2023-10-16)
- This release contains bug fixes to improve quality.

## 12.17.0 (2023-09-12)
- Includes all features from 12.17.0-beta.1.

## 12.17.0-beta.1 (2023-08-08)
- This release contains bug fixes to improve quality.

## 12.16.0 (2023-07-11)
- Includes all features from 12.16.0-beta.1.

## 12.16.0-beta.1 (2023-05-30)
- This release contains bug fixes to improve quality.

## 12.15.0 (2023-04-11)
- Includes all features from 12.15.0-beta.1.

## 12.15.0-beta.1 (2023-03-28)
- This release contains bug fixes to improve quality.

## 12.14.1 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 12.14.0 (2023-02-21)
- Includes all features from 12.14.0-beta.1.

## 12.14.0-beta.1 (2023-02-07)
- This release contains bug fixes to improve quality.

## 12.13.0 (2022-10-12)
- Includes all features from 12.13.0-beta.1.

## 12.13.0-beta.1 (2022-08-23)
- Fixed bug where Account SAS with the resources type value not in the order "sco" would get reordered to that order, which would invalidate the Account SAS signature from the string to sign

## 12.12.0 (2022-07-07)
- Includes all features from 12.12.0-beta.1.

## 12.12.0-beta.1 (2022-06-15)
- This release contains bug fixes to improve quality.

## 12.11.0 (2022-05-02)
- Includes all features from 12.11.0-beta.1.

## 12.11.0-beta.1 (2022-04-12)
- This release contains bug fixes to improve quality.

## 12.10.0 (2022-03-10)
- Includes all features from 12.10.0-beta.1, 12.10.0-beta.2, and 12.10.0-beta.3 except SDK-calculated transactional checksums on data transfer.
- Updated StorageBearerTokenChallengeAuthorizationPolicy to use the AAD scope returned by a bearer challenges.
- Removed preview support for SDK-calculated transactional checksums on data transfer.
- Fixed bug where Storage Uri Builder was case sensitive for parameter names.

## 12.10.0-beta.3 (2022-02-07)
- Fixed bug where AccountSasBuilder.SetPermissions(string rawPermissions) was not properly handling the Permanent Delete ('y') and set Immutability Policy ('i') permissions.

## 12.10.0-beta.2 (2021-11-30)
- This release contains bug fixes to improve quality.

## 12.10.0-beta.1 (2021-11-03)
- Added support for SDK-calculated transactional hash checksums on data transfer.
- This release contains bug fixes to improve quality.

## 12.9.0 (2021-09-08)
- Includes all features from 12.9.0-beta.1 and 12.9.0-beta.2.

## 12.9.0-beta.2 (2021-07-23)
- This release changes the dependency on Azure.Core to v1.16.0

## 12.9.0-beta.1 (2021-07-22)
- TenantId can now be discovered through the service challenge response, when using a TokenCredential for authorization.
    - A new property is now available on the ClientOptions called `EnableTenantDiscovery`. If set to true, the client will attempt an initial unauthorized request to the service to prompt a challenge containing the tenantId hint.

## 12.8.0 (2021-06-08)
- Includes all features from 12.8.0-beta.4.
- This release contains bug fixes to improve quality.

## 12.7.3 (2021-05-20)
- This release contains bug fixes to improve quality.

## 12.8.0-beta.4 (2021-05-12)
- Added ability to specify server timeout.
- Deprecated property AccountSasBuilder.Version, so when generating SAS will always use the latest Storage Service SAS version.

## 12.8.0-beta.3 (2021-04-09)
- Fixed bug in SasQueryParameters causing services (ss) reorder when parsing externally provided URI.

## 12.7.2 (2021-04-02)
- Fixed bug in SasQueryParameters causing services (ss) reorder when parsing externally provided URI.

## 12.7.1 (2021-03-29)
- This release contains bug fixes to improve quality.

## 12.8.0-beta.2 (2021-03-09)
- This release contains bug fixes to improve quality.

## 12.8.0-beta.1 (2021-02-09)
- Aligned storage URL parsing with other platforms

## 12.7.0 (2021-01-12)
- Includes all features from 12.7.0-beta.1
- Fixed bug where parsing the connection string only accepted lowercase values

## 12.7.0-beta.1 (2020-12-07)
- This release contains bug fixes to improve quality.

## 12.6.0 (2020-11-10)
- This release contains bug fixes to improve quality.

## 12.6.0-preview.1 (2020-09-30)
- This release contains bug fixes to improve quality.

## 12.5.2 (2020-08-31)
- This release contains bug fixes to improve quality.

## 12.5.1 (2020-08-18)
- Fixed bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 12.5.0 (2020-08-13)
- Includes all features from 12.5.0-preview.1 through 12.5.0-preview.6.
- This release contains bug fixes to improve quality.

## 12.5.0-preview.6 (2020-07-27)
- This release contains bug fixes to improve quality.

## 12.5.0-preview.5 (2020-07-03)
- This release contains bug fixes to improve quality.

## 12.5.0-preview.4 
- This preview contains bug fixes to improve quality.

## 12.5.0-preview.1 
- This preview adds support for client-side encryption, compatible with data uploaded in previous major versions.

## 12.4.3 
- This release contains bug fixes to improve quality.

## 12.4.2 
- This release contains bug fixes to improve quality.

## 12.4.1 
- This release contains bug fixes to improve quality.

## 12.4.0 
- This release contains bug fixes to improve quality.

## 12.3.0 
- Added InitialTransferLength to StorageTransferOptions

## 12.2.0 
- Added support for service version 2019-07-07.
- Update StorageSharedKeyPipelinePolicy to upload the request date header each retry.
- Sanitized header values in exceptions.

## 12.1.1 
 - Fixed issue where SAS content headers were not URL encoded when using Sas builders.
 - Fixed bug where using SAS connection string from portal would throw an exception if it included
   table endpoint.

## 12.1.0 
- Add support for populating AccountName properties of the UriBuilders
  for non-IP style Uris.

## 12.0.0-preview.4 
- Bug fixes

## 12.0.0-preview.3 
- Support new for Blobs/Files features
- Bug fixes

For more information, please visit: https://aka.ms/azure-sdk-preview3-net.

## 12.0.0-preview.2 
- Credential rolling
- Bug fixes

## 12.0.0-preview.1 
This preview is the first release of a ground-up rewrite of our client
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
