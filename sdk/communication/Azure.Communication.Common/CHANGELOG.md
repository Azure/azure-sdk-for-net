# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.0 (2024-02-13)

### Features Added
- Added support for a new communication identifier `MicrosoftTeamsAppIdentifier`.
- Introduction of `MicrosoftTeamsAppIdentifier` is a breaking change. It will impact any code that previously depended on the use of UnknownIdentifier with rawIDs starting with `28:orgid:`, `28:dod:`, or `28:gcch:`.

## 2.0.0-beta.1 (2023-03-29)

### Features Added
- Added support for a new communication identifier `MicrosoftBotIdentifier`.

### Breaking Changes
- Introduction of `MicrosoftBotIdentifier` is a breaking change. It will affect code that relied on using `UnknownIdentifier` with a rawID starting with `28:`.

## 1.2.1 (2022-11-01)

### Bugs Fixed
- Fixed the logic of `PhoneNumberIdentifier` to always maintain the original phone number string whether it included the leading + sign or not.

## 1.2.0 (2022-09-01)

### Features Added

- Added `string RawID { get; }` and `static CommunicationIdentifier FromRawId(string rawId)` to `CommunicationIdentifier` to translate between a `CommunicationIdentifier` and its underlying canonical rawId representation. Developers can now use the rawId as an encoded format for identifiers to store in their databases or as stable keys in general.
- Always include `rawId` when serializing identifiers to wire format.

## 1.1.0 (2022-02-23)
- Optimization added: When the proactive refreshing is enabled and the token refresher fails to provide a token that's not about to expire soon, the subsequent refresh attempts will be scheduled for when the token reaches half of its remaining lifetime until a token with long enough validity (>10 minutes) is obtained.

## 1.0.1 (2021-05-25)
- Dependency versions updated.

## 1.0.0 (2021-03-29)
Updated `Azure.Communication.Common` version.

## 1.0.0-beta.5 (2021-03-09)
Updated `Azure.Communication.Common` version.

### Breaking Changes
- Updated `CommunicationTokenRefreshOptions(bool refreshProactively, Func<CancellationToken, string> tokenRefresher,  Func<CancellationToken, ValueTask<string>> asyncTokenRefresher = null, string initialToken = null)`
to `CommunicationTokenRefreshOptions(bool refreshProactively, Func<CancellationToken, string> tokenRefresher)`. `asyncTokenRefresher` and `initialToken` are updated to become public properties.

## 1.0.0-beta.4 (2021-02-09)

### Added
- Added `MicrosoftTeamsUserIdentifier`.

### Breaking Changes
- Renamed `CommunicationUserCredential` to `CommunicationTokenCredential`.
- Replaced `CommunicationTokenCredential(bool refreshProactively, Func<CancellationToken, string> tokenRefresher,Func<CancellationToken, ValueTask<string>>? asyncTokenRefresher = null, string? initialToken = null)`.
with `CommunicationTokenCredential(CommunicationTokenRefreshOptions tokenRefreshOptions)`.
- Renamed `PhoneNumber` to `PhoneNumberIdentifier`.
- Renamed `CommunicationUser` to `CommunicationUserIdentifier`.
- Removed `CallingApplication`.
- Renamed `Id` to `RawId` in `PhoneNumberIdentifier`.

## 1.0.0-beta.3 (2020-11-16)
Updated `Azure.Communication.Common` version.

## 1.0.0-beta.2 (2020-10-06)
Updated `Azure.Communication.Common` version.

## 1.0.0-beta.1 (2020-09-22)
This package contains common code for Azure Communication Service libraries. For more information, please see the [README][read_me].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Common/README.md

