# Release History

## 12.26.0-beta.1 (Unreleased)

### Features Added

## 12.25.0-beta.1 (Unreleased)

### Features Added
- Added support for service version 2026-02-06.
- Added support for User Delegation SAS.
- Added support for Principal-Bound Identity User Delegation SAS.

## 12.24.0 (2025-10-13)

### Features Added
- Includes all features from 12.24.0-beta.1

## 12.23.0 (2025-07-14)

### Features Added
- Includes all features from 12.23.0-beta.1

## 12.24.0-beta.1 (2025-06-09)

### Features Added
- Added support for service version 2025-11-05.
- Added more useful error message when the SDK encounters an x-ms-version mis-match issue.
- Added `QueueProperties.ApproximateMessagesCountLong` to replace `QueueProperties.ApproximateMessagesCount`.  This property will correctly handle approximate message counts greater than max int.

## 12.23.0-beta.1 (2025-05-06)

### Features Added
- Added support for service version 2025-07-05.

## 12.22.0 (2025-03-11)

### Features Added
- Includes all features from 12.22.0-beta.1
- Added the following Client Builders: `AddQueueServiceClient(Uri, Azure.SasCredential)`, `AddQueueServiceClient(Uri, TokenCredential)`

### Bugs Fixed
- Fixed bug where a `QueueServiceClient`, `QueueClient` created with a connection string with an account name specified (e.g. "AccountName=..;"), the account name was not populated on the Storage Clients if the account name was not also specified in the endpoint. (#42925)
- Fixed bug where a `QueueServiceClient`, `QueueClient` created with a `StorageSharedKeyCredential`, the account name was not populated on the Storage Clients if the account name was not also specified in the endpoint. (#42925)

## 12.22.0-beta.1 (2025-02-11)

### Features Added
- Added support for service version 2025-05-05.

## 12.21.0 (2024-11-12)

### Features Added
- Includes all features from 12.21.0-beta.1 and 12.21.0-beta.2.

## 12.21.0-beta.2 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.20.1 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.21.0-beta.1 (2024-10-08)

### Features Added
- Added support for service version 2025-01-05.

## 12.20.0 (2024-09-18)

### Features Added
- Includes all features from 12.20.0-beta.1.
- Removed Queue Permissions enum from 12.20.0-beta.1.

### Bugs Fixed
- Fixed \[BUG\] Fixed Equality failures due to implicit cast on QueueErrorCode #44213

## 12.20.0-beta.1 (2024-08-06)

### Features Added
- Added support for service version 2024-11-04.
- Added ability to retrieve SAS string to sign for debugging purposes.
- Add Queue Permissions enum to represent QueueAccessPolicy.Permissions #37653

## 12.19.1 (2024-07-25)

### Bugs Fixed
- Fixed \[BUG\] Azure Blob Storage Client SDK No Longer Supports Globalization Invariant Mode for Account Key Authentication #45052

## 12.19.0 (2024-07-16)

### Features Added
- Includes all features from 12.19.0-beta.1.

## 12.19.0-beta.1 (2024-06-11)
- Added support for service version 2024-08-04.
- This package will now respect the QueueClientOptions.ServiceVersion specified by the customer, or default to the latest version.
- Added more detailed messaging for authorization failure cases.

## 12.18.0 (2024-05-13)
- Includes all features from 12.18.0-beta.1 and 12.18.0-beta.2.
- Fixed bug where `QueueClient` did not throw an exception on empty/null queue names when constructing a client.

## 12.18.0-beta.2 (2024-04-15)
- Added support for service version 2024-05-04.

## 12.18.0-beta.1 (2023-12-05)
- Added support for service version 2024-02-04.

## 12.17.1 (2023-11-13)
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 12.17.0 (2023-11-06)
- Includes all features from 12.17.0-beta.1.

## 12.17.0-beta.1 (2023-10-16)
- Added support for QueueClientOptions.Audience

## 12.16.0 (2023-09-12)
- Includes all features from 12.16.0-beta.1.

## 12.16.0-beta.1 (2023-08-08)
- This release contains bug fixes to improve quality.

## 12.15.0 (2023-07-11)
- Includes all features from 12.15.0-beta.1.

## 12.15.0-beta.1 (2023-05-30)
- This release contains bug fixes to improve quality.

## 12.14.0 (2023-04-11)
- Includes all features from 12.14.0-beta.1.

## 12.14.0-beta.1 (2023-03-28)
- This release contains bug fixes to improve quality.

## 12.13.1 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 12.13.0 (2023-02-21)
- Includes all features from 12.13.0-beta.1.

## 12.13.0-beta.1 (2023-02-07)
- This release contains bug fixes to improve quality.

## 12.12.0 (2022-10-12)
- Includes all features from 12.12.0-beta.1.

## 12.12.0-beta.1 (2022-08-23)
- This release contains bug fixes to improve quality.

## 12.11.1 (2022-08-22)
- Added support for receiving queue messages with bugged client-side encryption metadata from previous library versions.

## 12.11.0 (2022-07-07)
- Includes all features from 12.10.1-beta.1.

## 12.11.0-beta.1 (2022-06-15)
- This release contains bug fixes to improve quality.

## 12.10.0 (2022-05-02)
- Includes all features from 12.10.0-beta.1.

## 12.10.0-beta.1 (2022-04-12)
- This release contains bug fixes to improve quality.

## 12.9.0 (2022-03-10)
- Includes all features from 12.9.0-beta.1, 12.9.0-beta.2, and 12.9.0-beta.3.

## 12.9.0-beta.3 (2022-02-07)
- This release contains bug fixes to improve quality.

## 12.9.0-beta.2 (2021-11-30)
- This release contains bug fixes to improve quality.

## 12.9.0-beta.1 (2021-11-03)
- This release contains bug fixes to improve quality.

## 12.8.0 (2021-09-08)
- Includes all features from 12.8.0-beta.1 and 12.8.0-beta.2.
- Fixed issue where QueueClient.ReceiveMessage() and .ReceiveMessageAsync() were creating two Diagnostic Scopes.

## 12.8.0-beta.2 (2021-07-23)
- This release contains bug fixes to improve quality.

## 12.8.0-beta.1 (2021-07-22)
- TenantId can now be discovered through the service challenge response, when using a TokenCredential for authorization.
    - A new property is now available on the ClientOptions called `EnableTenantDiscovery`. If set to true, the client will attempt an initial unauthorized request to the service to prompt a challenge containing the tenantId hint.

## 12.7.0 (2021-06-08)
- Includes all features from 12.7.0-beta.4.
- This release contains bug fixes to improve quality.

## 12.6.2 (2021-05-20)
- This release contains bug fixes to improve quality.

## 12.7.0-beta.4 (2021-05-12)
- Fixed bug where clients would sometimes throw a NullReferenceException when calling GenerateSas() with a QueueSasBuilder parameter.
- Deprecated property QueueSasBuilder.Version, so when generating SAS will always use the latest Storage Service SAS version.

## 12.7.0-beta.3 (2021-04-09)
- This preview contains bug fixes to improve quality.

## 12.6.1 (2021-03-29)
- Fixed bug where ClientDiagnostics's DiagnosticListener was leaking resources.

## 12.7.0-beta.2 (2021-03-09)
- This preview contains bug fixes to improve quality.

## 12.7.0-beta.1 (2021-02-09)
- Fixed bug where QueueClient.CanGenerateSasUri and QueueServiceClient.CanGenerateSasUri was not mockable.
- Added MessageDecodingFailed event to QueueClientOptions.

## 12.6.0 (2021-01-12)
- Includes all features from 12.6.0-beta.1.
- Added support for AzureSasCredential. That allows SAS rotation for long living clients.

## 12.6.0-beta.1 (2020-12-07)
- Fixed bug where QueueServiceClient.GetQueueClient() and QueueClient.WithClientSideEncryptionOptions() created clients that could not generate a SAS from clients that could generate a SAS.

## 12.5.0 (2020-11-10)
- Includes all features from 12.5.0-preview.1
- Fixed a bug where QueueServiceClient.SetProperties and QueueService.GetProperties where the creating/parsing XML Service Queue Properties CorsRules incorrectly causing Invalid XML Errors
- Fixed bug where Queues SDK coudn't handle SASs with start and expiry time in format other than yyyy-MM-ddTHH:mm:ssZ.
- Added CanGenerateSasUri property, GenerateSasUri() to QueueClient.
- Added CanGenerateAccountSasUri property, GenerateAccountSasUri() to QueueServiceClient.

### Support for binary data, custom shapes and Base64 encoding
This release adds a convinient way to send and receive binary data and custom shapes as a payload.
Additionally, support for Base64 encoding in HTTP requests and reponses has been added that makes interoperability with V11 and prior Storage SDK easier to implement.

The `QueueClient.SendMessage` and `QueueClient.SendMessageAsync` consume `System.BinaryData` in addition to `string`.
`QueueMessage` and `PeekedMessage` expose new property `Body` of `System.BinaryData` type to access message payload and should be used instead of `MessageText`.

See [System.BinaryData](https://github.com/Azure/azure-sdk-for-net/blob/System.Memory.Data_1.0.0/sdk/core/System.Memory.Data/README.md) for more information about handling `string`, binary data and custom shapes.

#### Receiving message as string
Before:
```C#
QueueMessage message = await queueClient.ReceiveMessage();
string messageText = message.MessageText;
```

After:
```C#
QueueMessage message = await queueClient.ReceiveMessage();
BinaryData body = message.Body;
string messageText = body.ToString();
```

## 12.5.0-preview.1 (2020-09-30)
- This preview contains bug fixes to improve quality.

## 12.4.2 (2020-08-31)
- Fixed a bug where QueueClient.UpdateMessage and QueueClient.UpdateMessageAsync were erasing message content if only visiblityTimeout was provided.

## 12.4.1 (2020-08-18)
- Fixed bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 12.4.0 (2020-08-13)
- Includes all features from 12.4.0-preview.1 through 12.4.0-preview.6.
- This preview contains bug fixes to improve quality.

## 12.4.0-preview.6 (2020-07-27)
- Updated QueueSasBuilder to correctly order raw string permissions and make the permissions lowercase.

## 12.4.0-preview.5 (2020-07-03)
- Fixed a bug in queue client-side encryption deserialization.
- This release contains bug fixes to improve quality.

## 12.4.0-preview.4 
- This preview contains bug fixes to improve quality.

## 12.4.0-preview.1 
- This preview adds support for client-side encryption, compatible with data uploaded in previous major versions.

## 12.3.2 
- This release contains bug fixes to improve quality.

## 12.3.1 
- This release contains bug fixes to improve quality.

## 12.3.0 
- Added Exists(), CreateIfNotExists() and DeleteIfNotExists() to QueueClient.

## 12.2.0 
- Added support for service version 2019-07-07.
- Fixed issue where SAS didn't work with signed identifiers.
- Sanitized header values in exceptions.

## 12.1.1 
 - Fixed issue where SAS content headers were not URL encoded when using QueueSasBuilder.
 - Fixed bug where using SAS connection string from portal would throw an exception if it included
   table endpoint.

## 12.1.0 
- Added check to enforce TokenCredential is used only over HTTPS
- Support using SAS token from connection string
- Fixed issue where AccountName on QueueUriBuilder would not be populated
  for non-IP style Uris.

## 12.0.0 
- Renamed a number of operations and models to better align with other client
  libraries and the .NET Framework Design Guidelines

## 12.0.0-preview.4 
- Support for geo-redundant read from secondary location on failure
- Verification of echoed client request IDs
- Added convenient resource Name properties on all clients

## 12.0.0-preview.3 
- Added QueueUriBuilder for addressing Azure Storage resources
- Bug fixes

For more information, please visit: https://aka.ms/azure-sdk-preview3-net.

## 12.0.0-preview.2 
- Distributed Tracing
- Bug fixes

## 12.0.0-preview.1 
This preview is the first release of a ground-up rewrite of our client
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
