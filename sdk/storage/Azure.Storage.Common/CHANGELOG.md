# Release History

## 12.8.0-beta.1 (Unreleased)


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
