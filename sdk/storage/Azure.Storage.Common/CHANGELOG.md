# Release History

## 12.2.0 (2020-02)
- Added support for service version 2019-07-07.
- Update StorageSharedKeyPipelinePolicy to upload the request date header each retry.
- Sanitized header values in exceptions.

## 12.1.1 (2020-01)
 - Fixed issue where SAS content headers were not URL encoded when using Sas builders.
 - Fixed bug where using SAS connection string from portal would throw an exception if it included
   table endpoint.

## 12.1.0
- Add support for populating AccountName properties of the UriBuilders
  for non-IP style Uris.

## 12.0.0-preview.4 (2019-10)
- Bug fixes

## 12.0.0-preview.3 (2019-09)
- Support new for Blobs/Files features
- Bug fixes

For more information, please visit: https://aka.ms/azure-sdk-preview3-net.

## 12.0.0-preview.2 (2019-08)
- Credential rolling
- Bug fixes

## 12.0.0-preview.1 (2019-07)
This preview is the first release of a ground-up rewrite of our client
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
