# Release History

## 1.0.0-beta.4 (Unreleased)

### Added
- Added `MicrosoftTeamsUserIdentifier`.

### Breaking Changes
- Renamed `CommunicationUserCredential` to `CommunicationTokenCredential`.
- Replace `CommunicationTokenCredential(bool refreshProactively, Func<CancellationToken, string> tokenRefresher,Func<CancellationToken, ValueTask<string>>? asyncTokenRefresher = null, string? initialToken = null)` 
with `CommunicationTokenCredential(CommunicationTokenRefreshOptions tokenRefreshOptions)`.
- Renamed `PhoneNumber` to `PhoneNumberIdentifier`
- Renamed `CommunicationUser` to `CommunicationUserIdentifier `
- Renamed `CallingApplication` to `CallingApplicationIdentifier`

## 1.0.0-beta.3 (2020-11-16)
Updated `Azure.Communication.Common` version.

## 1.0.0-beta.2 (2020-10-06)
Updated `Azure.Communication.Common` version.

## 1.0.0-beta.1 (2020-09-22)
This package contains common code for Azure Communication Service libraries. For more information, please see the [README][read_me].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Common/README.md

