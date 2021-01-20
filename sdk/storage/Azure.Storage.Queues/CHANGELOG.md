# Release History

## 12.7.0-beta.1 (Unreleased)


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
