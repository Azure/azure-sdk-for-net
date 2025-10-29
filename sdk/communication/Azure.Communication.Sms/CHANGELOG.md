# Release History

## 1.1.0 (Unreleased)

### Features Added

- Added new `TelcoMessagingClient` with improved architecture using sub-clients:
  - `TelcoMessagingClient.Sms` - for sending SMS messages
  - `TelcoMessagingClient.OptOuts` - for managing opt-out preferences
  - `TelcoMessagingClient.DeliveryReports` - for retrieving message delivery status
- Added `DeliveryReportsClient` for getting delivery reports of sent messages
- Added comprehensive samples demonstrating the new `TelcoMessagingClient` functionality
- Enhanced `DeliveryReport` model with `MessagingConnectPartnerMessageId` property for tracking partner-generated message IDs
- Added documentation remarks to `SmsClient` methods guiding users to consider `TelcoMessagingClient` for new development

### Breaking Changes

- **MessagingConnect API Changes**: Updated `MessagingConnectOptions` constructor and properties for better flexibility:
  - Constructor changed from `MessagingConnectOptions(string apiKey, string partner)` to `MessagingConnectOptions(string partner, object partnerParams)`
  - Property `ApiKey` replaced with `PartnerParams` to support various partner-specific parameters
  - Added new `MessagingConnectPartnerParameters` class providing multiple convenient factory methods for creating partner parameters:
    - `MessagingConnectPartnerParameters.Create(("key", "value"), ...)` - Clean tuple syntax (recommended)
    - `MessagingConnectPartnerParameters.FromObject(new { Key = "value" })` - Familiar anonymous object syntax
    - `MessagingConnectPartnerParameters.FromDictionary(dictionary)` - Dictionary-based creation
  - **Migration**: Replace `new MessagingConnectOptions("your-api-key", "PartnerName")` with `new MessagingConnectOptions("PartnerName", MessagingConnectPartnerParameters.FromObject(new { ApiKey = "your-api-key" }))` or use the recommended tuple syntax: `MessagingConnectPartnerParameters.Create(("ApiKey", "your-api-key"))`

### Other Changes

- Migrate to `TelcoMessagingClient` for new development
- Updated documentation and README.md with migration guidance from `SmsClient` to `TelcoMessagingClient`
- Added comprehensive unit tests for the new client architecture

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


