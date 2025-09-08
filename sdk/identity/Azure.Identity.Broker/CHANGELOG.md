# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.0 (2025-09-04)

### Breaking Changes

- Deprecated `SharedTokenCacheCredentialBrokerOptions`. The supporting credential (`SharedTokenCacheCredential`) was a legacy mechanism for authenticating clients using credentials provided to Visual Studio. For brokered authentication, consider using `InteractiveBrowserCredential` instead.

### Other Changes

- Updated `Microsoft.Identity.Client.Broker` dependency to version 4.76.0
- Updated `Azure.Identity` dependency to version 1.15.0

## 1.3.0-beta.4 (2025-07-11)

### Features Added

- Support Microsoft Broker on macOS.

### Other Changes

- Updated `Azure.Identity` to 1.14.2 to apply a security fix in the updated `Microsoft.Identity.Client` dependency.

## 1.2.1 (2025-07-11)

### Other Changes

- Updated `Azure.Identity` to 1.14.2 to apply a security fix in the updated `Microsoft.Identity.Client` dependency.

## 1.3.0-beta.3 (2025-06-10)

### Features Added

- Support Microsoft Broker on Linux and WSL. This library relies on the Microsoft Authentication Library (MSAL) to handle the broker. For more information about prerequisites and how to utilize the broker, see [Enable SSO in native Linux apps using MSAL.NET](https://learn.microsoft.com/entra/msal/dotnet/acquiring-tokens/desktop-mobile/linux-dotnet-sdk)

### Other Changes

- Updated `Microsoft.Identity.Client.Broker` dependency to version 4.70.2

## 1.3.0-beta.2 (2025-04-08)

### Other Changes

- Support for dynamic addition of the broker authentication to `DefaultAzureCredential` has been added. This allows the broker authentication to be used as part of the default credential chain by only adding a reference to this package to your application.

## 1.3.0-beta.1 (2025-03-11)

### Other Changes
- Updated Microsoft.Identity.Client.Broker dependency to version 4.69.1.

## 1.2.0 (2024-11-18)

### Other Changes

- Support for Proof of Possession (PoP) tokens for `InteractiveBrowserCredential` has migrated out of Azure.Core.Experimental to Azure.Core. This feature is enabled via the `IsProofOfPossessionEnabled` property on `TokenRequestContext`.
- Updating package dependencies.

## 1.2.0-beta.1 (2024-04-24)

### Breaking Changes
- The `IsProofOfPossessionRequired` property on `InteractiveBrowserCredentialBrokerOptions` and `SharedTokenCacheCredentialBrokerOptions` has been removed. This property has moved to the experimental `PopTokenRequestContext` struct.

## 1.1.0 (2024-04-09)

### Other Changes

- The `UseOperatingSystemAccount` property on `InteractiveBrowserCredentialBrokerOptions` and `SharedTokenCacheCredentialBrokerOptions` has been renamed to `UseDefaultBrokerAccount`

## 1.1.0-beta.1 (2024-02-06)

### Features Added

- `InteractiveBrowserCredentialBrokerOptions` and `SharedTokenCacheCredentialBrokerOptions` now support a `UseOperatingSystemAccount` property to enable the use of the currently logged in operating system account for authentication rather than prompting for a credential.
- Preview support for Proof of Possession (PoP) tokens for `InteractiveBrowserCredential`. This feature is enabled via the `IsProofOfPossessionRequired` property on `InteractiveBrowserCredentialBrokerOptions`.

## 1.0.0 (2023-11-07)

### Breaking Changes
- Renamed the `IsMsaPassthroughEnabled` property on `SharedTokenCacheCredentialBrokerOptions` to `IsLegacyMsaPassthroughEnabled`.

## 1.0.0-beta.5 (2023-10-19)

### Breaking Changes
- Renamed the `IsMsaPassthroughEnabled` property on `InteractiveBrowserCredentialBrokerOptions` to `IsLegacyMsaPassthroughEnabled`.

### Other Changes
- Updated Microsoft.Identity.Client.Broker and Microsoft.Identity.Client.Extensions.Msal dependencies to version 4.56.0
- Renamed assembly from `Azure.Identity.BrokeredAuthentication` to `Azure.Identity.Broker`.

## 1.0.0-beta.4 (2023-07-17)

### Features Added

- Added support for MSA passthrough. Note this is only available for legacy 1st party applications.

## 1.0.0-beta.3 (2022-08-09)

### Breaking Changes
- Added required constructor parameter `parentWindowHandle` to `InteractiveBrowserCredentialBrokerOptions`, to require setting the parent window for the authentication broker.

## 1.0.0-beta.2 (2022-04-05)

### Features Added
- Added `SharedTokenCacheCredentialBrokerOptions` to enable `SharedTokenCacheCredential` to use the authentication broker for silent authentication calls when this specialized options type is used to construct the credential.

## 1.0.0-beta.1 (2022-02-23)

### Features Added
- Added `InteractiveBrowserCredentialBrokerOptions` to enable `InteractiveBrowserCredential` to use the authentication broker when this specialized options type is used to construct the credential.
