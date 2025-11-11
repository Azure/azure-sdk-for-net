# Release History

## 1.1.0 (Unreleased)

### Features Added

- Added delivery report functionality to `SmsClient`:
  - New `SmsClient.GetDeliveryReport` and `SmsClient.GetDeliveryReportAsync` methods for retrieving message delivery status
  - Provides detailed information including delivery status, delivery attempts, and timestamps
  - Supports tracking partner-generated message IDs via `MessagingConnectPartnerMessageId` property
- Improved MessagingConnect partner integration with standard Azure SDK patterns (changed from 1.1.0-beta.3):
  - Use `Dictionary<string, object>` for partner-specific parameters instead of the previous `MessagingConnectPartnerParameters` helper class
  - Updated constructor: `new MessagingConnectOptions(string partner, IDictionary<string, object> partnerParams)`
  - Follows Azure SDK design guidelines for flexible parameter collections
  - Migration from beta: Change `new MessagingConnectOptions("your-api-key", "PartnerName")` to `new MessagingConnectOptions("PartnerName", new Dictionary<string, object> { { "ApiKey", "your-api-key" } })`

### Other Changes (changed from 1.1.0-beta.2)

- **Redesigned Opt-Out Management API response types for improved consistency and developer experience**:
  - `OptOutResponseItem` has been renamed to `OptOutCheckResponseItem` to match the Check operation
  - `OptOutAddResponseItem` and `OptOutRemoveResponseItem` have been unified into a single `OptOutOperationResponseItem` type since they were functionally identical
  - Updated method signatures:
    - `OptOuts.CheckAsync()` and `OptOuts.Check()` now return `IReadOnlyList<OptOutCheckResponseItem>`
    - `OptOuts.AddAsync()`, `OptOuts.Add()`, `OptOuts.RemoveAsync()`, and `OptOuts.Remove()` now return `IReadOnlyList<OptOutOperationResponseItem>`
  - **Migration guide**:
    - Replace `OptOutResponseItem` with `OptOutCheckResponseItem` for Check operations
    - Replace both `OptOutAddResponseItem` and `OptOutRemoveResponseItem` with `OptOutOperationResponseItem` for Add and Remove operations
  - This change eliminates duplicate types and provides consistent naming across all opt-out operations

## 1.1.0-beta.3 (2025-06-12)

### Features Added

- Introduced Messaging Connect support in the .NET SDK.
  - Added a new MessagingConnect field to the SmsSendOptions model.
  - The MessagingConnect structure includes:
    - partner: identifies the Messaging Connect partner.
    - partnerParams: partner-specific parameters as key-value pairs (e.g., apiKey, servicePlanId, authToken).
  - Supports:
    - Incoming and outgoing flows for long codes.
    - Outgoing flow for Dynamic Alpha Sender IDs (DASID).

## 1.1.0-beta.2 (2024-12-10)

### Features Added
 - Added support for Opt Out Management Api to:
    - Opt-out the recipient.
    - Opt-in the recipient.
    - Check if the recpient is opted-out or not.

## 1.1.0-beta.1 (2024-05-07)

### Features Added
- Added optional DeliveryReportTimeoutInSeconds to smsSendOptions.

## 1.0.2 (2021-10-05)
- Dependency versions updated.

## 1.0.1 (2021-05-25)
- Dependency versions updated.

## 1.0.0 (2021-03-29)
Updated `Azure.Communication.Sms` version.

## 1.0.0-beta.4 (2021-03-09)

### Added
- Added support to create SmsClient with AzureKeyCredential.
- Support for creating SmsClient with TokenCredential.
- Added support for 1:N SMS messaging.
- Added support for tagging SMS messages.
- Send method series in SmsClient are idempotent under retry policy.

### Breaking
- Updated `Task<Response<SendSmsResponse>> SendAsync(PhoneNumberIdentifier from, PhoneNumberIdentifier to, string message, SendSmsOptions sendSmsOptions = null, CancellationToken cancellationToken = default)`
to `Task<Response<SmsSendResult>> SendAsync(string from, string to, string message, SmsSendOptions options = default)`
- Replaced `SendSmsResponse` with `SmsSendResult`.

## 1.0.0-beta.3 (2020-11-16)

### Added
- Support for mocking all client methods that use models with internal constructors.

## 1.0.0-beta.2 (2020-10-06)
Updated `Azure.Communication.Sms` version.

## 1.0.0-beta.1 (2020-09-22)
This is the first release of Azure Communication Services for Telephony and SMS. For more information, please see the [README][read_me] and [documentation][documentation].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Sms/README.md
[documentation]:https://learn.microsoft.com/azure/communication-services/quickstarts/telephony-sms/send?pivots=programming-language-csharp


