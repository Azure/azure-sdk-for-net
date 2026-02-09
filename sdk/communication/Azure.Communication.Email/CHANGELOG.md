# Release History

## 1.2.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2025-10-01)

### Features Added

- Consumers can now provide a value for the `ContentId` property when sending emails with attachments.
  This allows consumers to reference attachments in the email body using the `cid` scheme. The `ContentId` property can be set on the `EmailAttachment` object.

## 1.1.0-beta.2 (2024-08-14)

### Features Added

- Consumers can now provide a value for the `ContentId` property when sending emails with attachments.
  This allows consumers to reference attachments in the email body using the `cid` scheme. The `ContentId` property can be set on the `EmailAttachment` object.

## 1.1.0-beta.1 (2024-07-10)

### Features Added

- Consumers can now provide their own value for the Operation ID when sending emails.
  New overloads have been added to `EmailClient` with the `operationId` parameter.

## 1.0.1 (2023-08-17)

### Other Changes
- Improve memory management for attachment handling
 
## 1.0.0 (2023-03-31)

### Breaking Changes
- Changed: Renamed parameter names in EmailMessage constructor
- Removed: Removed public methods for GetSendResult and GetSendResultAsync since the same functionality is available through EmailSendOperation.UpdateStatus method

## 1.0.0-beta.4 (2023-03-15)

### Bugs Fixed
- Fixed a bug that caused some attachments to be corrupted.

## 1.0.0-beta.3 (2023-03-11)

### Other Changes
- Upgraded dependent `Azure.Core` to `1.30.0` due to an [issue in `ArrayBackedPropertyBag`](https://github.com/Azure/azure-sdk-for-net/pull/34800) in `Azure.Core` version `1.29.0`

## 1.0.0-beta.2 (2023-03-01)

### Features Added
- AAD token auth has been added for `EmailClient` and `EmailAsyncClient`

### Breaking Changes
- Changed: Reworked the SDK to follow the LRO (long running operation) approach. The 'Send' method returns an `Azure.Operation` that can be used to retrieve the status of the email request. The result object is a status monitor that contains the OperationID as well as the current status and error if any.
- Changed: We have added some convenience overloads to the Send method for quickly sending an email with a from address, to address and simple message.
- Changed: The `EmailMessage` model now has convenience overloads for when you want to quickly create an EmailMessage with a single from and to email address.
- Changed: The `EmailAttachment` constructor now accepts BinaryData instead of a string.
- Changed: The `contentBytesBase64` property under `attachments` has been changed to `contentInBase64`.
- Changed: The `attachmentType` property under `attachments` has been changed to 'contentType'. This now accepts a string representing the mime type of the content being attached.
- Changed: The `sender` property has been changed to `senderAddress`.
- Changed: The `email` property under the recipient object has been changed to `address`.
- Changed: Custom headers in the email message are now key/value pairs.
- Changed: ASP.Net extensions have been added for the `EmailClient`. 
- Removed: The `EmailAttachmentType` enum has been removed.
- Removed: The importance property was removed. Email importance can now be specified through either the `x-priority` or `x-msmail-priority` custom headers.
- Removed: The `getSendStatus` method has been removed.

## 1.0.0-beta.1 (2022-05-24)
Initial version of the Azure Communication Services Email service
- Send emails to multiple recipients with attachments
- Get the status of a sent message
