# Release History

## 1.4.0 (2021-05-12)

### New Features

- By default, the MSAL Public Client Client Capabilities are populated with "CP1" to enable support for [Continuous Access Evaluation (CAE)](https://docs.microsoft.com/azure/active-directory/develop/app-resilience-continuous-access-evaluation).
This indicates to AAD that your application is CAE ready and can handle the CAE claim challenge. This capability can be disabled, if necessary, by either setting an `AppContext` switch named "Azure.Identity.DisableCP1" to `true` or by setting the environment variable;
"AZURE_IDENTITY_DISABLE_CP1" to "true". Note: AppContext switches can also be configured via configuration like below:
  
```xml  
<ItemGroup>
    <RuntimeHostConfigurationOption Include="Azure.Identity.DisableCP1" Value="true" />
</ItemGroup> 
  ```
### Fixes and improvements

- The Microsoft Authentication Library (MSAL) dependency versions have been updated to the latest
    - Microsoft.Identity.Client version 4.30.1, Microsoft.Identity.Client.Extensions.Msal version 2.18.4.

## 1.4.0-beta.5 (2021-04-06)

### Acknowledgments

Thank you to our developer community members who helped to make Azure Identity better with their contributions to this release:

- Marco Mansi _([GitHub](https://github.com/olandese))_

### New Features

- Added `AzurePowerShellCredential` to `DefaultAzureCredential` (A community contribution, courtesy of _[olandese](https://github.com/olandese))_

### Fixes and improvements

- When logging is enabled, the log output from Microsoft Authentication Library (MSAL) is also logged.
- Fixed an issue where an account credential fails to load from the cache when EnableGuestTenantAuthentication is true and the account found in the cache has multiple matching tenantIds ([#18276](https://github.com/Azure/azure-sdk-for-net/issues/18276)).
- Fixed deadlock issue in `InteractiveBrowserCredential` when running in a UI application ([#18418](https://github.com/Azure/azure-sdk-for-net/issues/18418)).

### Breaking Changes

- `TokenCache` class is moved removed from the public API surface and has been replaced by `TokenCachePersistenceOptions` for configuration of disk based persistence of the token cache.

## 1.4.0-beta.4 (2021-03-09)

### Fixes and Improvements

- Added the `[Serializable]` attribute to all custom exception types.

### Breaking Changes

- Update the default value of `ExcludeSharedTokenCacheCredential` on `DefaultAzureCredentialsOptions` to true, to exclude the `SharedTokenCacheCredential` from the `DefaultAzureCredential` by default. See [BREAKING_CHANGES.md](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/BREAKING_CHANGES.md#140)

## 1.4.0-beta.3 (2021-02-09)

### Breaking Changes

- The `IDisposable` interface has been removed from `TokenCache`.

### New Features

- All credentials added support to handle the `Claims` property on `TokenRequestContext`

## 1.4.0-beta.2 (2021-01-29)

### Fixes and improvements

- Fixed issue in `HttpExtensions` causing the omission of content headers on requests ([#17448](https://github.com/Azure/azure-sdk-for-net/issues/17448))
- Made `EnvironmentCredential` to account for both null and empty string when checking for the presense of the environment variables ([#18031](https://github.com/Azure/azure-sdk-for-net/issues/18031))

## 1.3.0 (2020-11-12)

### New Features

- Added support for Service Fabric managed identity authentication to `ManagedIdentityCredential`.
- Added support for Azure Arc managed identity authentication to `ManagedIdentityCredential`.

### Fixes and improvements

- Fix race condition in `ProcessRunner` causing `VisualStudioCredential` and `AzureCliCredential` to fail intermittently ([#16211](https://github.com/Azure/azure-sdk-for-net/issues/16211))
- Fix `VisualStudioCodeCredential` to raise `CredentialUnavailableException` when reading from VS Code's stored secret ([#16795](https://github.com/Azure/azure-sdk-for-net/issues/16795))
- Prevent `VisualStudioCodeCredential` using invalid authentication data when no user is signed in to Visual Studio Code ([#15870](https://github.com/Azure/azure-sdk-for-net/issues/15870))
- Fix deadlock in `ProcessRunner` causing `AzureCliCredential` and `VisualStudioCredential` to fail due to timeout ([#14691](https://github.com/Azure/azure-sdk-for-net/issues/14691), [14207](https://github.com/Azure/azure-sdk-for-net/issues/14207))
- Fix issue with `AzureCliCredential` incorrectly parsing expires on property returned from `az account get-access-token` ([#15801](https://github.com/Azure/azure-sdk-for-net/issues/15801))
- Fix issue causing `DeviceCodeCredential` and `InteractiveBrowserCredential` to improperly authenticate to the home tenant for silent authentication calls after initial authentication ([#13801](https://github.com/Azure/azure-sdk-for-net/issues/13801))
- Fix cache loading issue in `SharedTokenCacheCredential` on Linux ([#12939](https://github.com/Azure/azure-sdk-for-net/issues/12939))

### Breaking Changes

- Rename property `IncludeX5CCliamHeader` on `ClientCertificateCredentialOptions` to `SendCertificateChain`
- Removing Application Authentication APIs for GA release. These will be reintroduced in 1.4.0-beta.1.
  - Removed class `AuthenticationRecord`
  - Removed class `AuthenticationRequiredException`
  - Removed class `ClientSecretCredentialOptions` and `ClientSecretCredential` constructor overloads accepting this type
  - Removed class `UsernamePasswordCredentialOptions` and `UsernamePasswordCredential` constructor overloads accepting this type
  - Removed properties `EnablePersistentCache` and `AllowUnprotectedCache` from `ClientCertificateCredentialOptions`, `DeviceCodeCredentialOptions` and `InteractiveBrowserCredentialOptions`
  - Removed properties `AuthenticationRecord` and `DisableAutomaticAuthentication` from `DeviceCodeCredentialOptions` and `InteractiveBrowserCredentialOptions`
  - Removed properties `AllowUnencryptedCache`and `AuthenticationRecord` from `SharedTokenCacheCredentialOptions`
  - Removed methods `Authenticate` and `AuthenticateAsync` from `DeviceCodeCredential`, `InteractiveBrowserCredential` and `UsernamePasswordCredential`

## 1.4.0-beta.1 (2020-10-15)

### New Features

- Redesigned Application Authentication APIs
  - Adds `TokenCache` and `TokenCache` classes to give more user control over how the tokens are cached and how the cache is persisted.
  - Adds `TokenCache` property to options for credentials supporting token cache configuration.

## 1.3.0-beta.2 (2020-10-07)

### New Features

- Update `DeviceCodeCredential` to output device code information and authentication instructions in the console, in the case no `deviceCodeCallback` is specified.
  - Added `DeviceCodeCallback` to `DeviceCodeCredentialOptions`
  - Added default constructor to `DeviceCodeCredential`

### Breaking Changes

- Replaced `DeviceCodeCredential` constructor overload taking `deviceCodeCallback` and `DeviceCodeCredentialOptions` with constructor taking only `DeviceCodeCredentialOptions`

## 1.3.0-beta.1 (2020-09-11)

### New Features

- Restoring Application Authentication APIs from 1.2.0-preview.6
- Added support for App Service Managed Identity API version `2019-08-01` ([#13687](https://github.com/Azure/azure-sdk-for-net/issues/13687))
- Added `IncludeX5CClaimHeader` to `ClientCertificateCredentialOptions` to enable subject name / issuer authentication with the `ClientCertificateCredential`.
- Added `RedirectUri` to `InteractiveBrowserCredentialOptions` to enable authentication with user specified application with a custom redirect url.
- Added `IdentityModelFactory` to enable constructing models from the Azure.Identity library for mocking.
- Unify exception handling between `DefaultAzureCredential` and `ChainedTokenCredential` ([#14408](https://github.com/Azure/azure-sdk-for-net/issues/14408))

### Fixes and improvements

- Updated `MsalPublicClient` and `MsalConfidentialClient` to respect `CancellationToken` during initialization ([#13201](https://github.com/Azure/azure-sdk-for-net/issues/13201))
- Fixed `VisualStudioCodeCredential` crashes on macOS (Issue [#14362](https://github.com/Azure/azure-sdk-for-net/issues/14362))
- Fixed issue with non GUID Client Ids (Issue [#14585](https://github.com/Azure/azure-sdk-for-net/issues/14585))
- Update `VisualStudioCredential` and `VisualStudioCodeCredential` to throw `CredentialUnavailableException` for ADFS tenant (Issue [#14639](https://github.com/Azure/azure-sdk-for-net/issues/14639))

## 1.2.3 (2020-09-11)

### Fixes and improvements

- Fixed issue with `DefaultAzureCredential` incorrectly catching `AuthenticationFailedException` (Issue [#14974](https://github.com/Azure/azure-sdk-for-net/issues/14974))
- Fixed issue with `DefaultAzureCredential` throwing exceptions during concurrent calls (Issue [#15013](https://github.com/Azure/azure-sdk-for-net/issues/15013))

## 1.2.2 (2020-08-20)

### Fixes and improvements

- Fixed issue with `InteractiveBrowserCredential` not specifying correct redirectUrl (Issue [#13940](https://github.com/Azure/azure-sdk-for-net/issues/13940))

## 1.2.1 (2020-08-18)

### Fixes and improvements

- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 1.2.0 (2020-08-10)

### Breaking Changes

- Removing Application Authentication APIs for GA release. These will be reintroduced in 1.3.0-preview.
  - Removed class `AuthenticationRecord`
  - Removed class `AuthenticationRequiredException`
  - Removed class `ClientCertificateCredentialOptions` and `ClientCertificateCredential` constructor overloads accepting this type
  - Removed class `ClientSecretCredentialOptions` and `ClientSecretCredential` constructor overloads accepting this type
  - Removed class `DeviceCodeCredentialOptions` and `DeviceCodeCredential` constructor overloads accepting this type
  - Removed class `InteractiveBrowserCredentialOptions` and `InteractiveBrowserCredential` constructor overloads accepting this type
  - Removed class `UsernamePasswordCredentialOptions` and `UsernamePasswordCredential` constructor overloads accepting this type
  - Removed methods `Authenticate` and `AuthenticateAsync` from `DeviceCodeCredential`
  - Removed methods `Authenticate` and `AuthenticateAsync` from `InteractiveBrowserCredential`
  - Removed methods `Authenticate` and `AuthenticateAsync` from `UsernamePasswordCredential`
  - Removed properties `AllowUnencryptedCache`and `AuthenticationRecord` from `SharedTokenCacheCredentialOptions`

### Fixes and improvements

- Fixed excess errors in `DefaultAzureCredential` tracing (Issue [#10659](https://github.com/Azure/azure-sdk-for-net/issues/10659))
- Fixed concurrency issue in `DefaultAzureCredential` (Issue [#13044](https://github.com/Azure/azure-sdk-for-net/issues/13044))

## 1.2.0-preview.6 (2020-07-22)

### New Features

- Added the read only property `ClientId` to `AuthenticationRecord`.
- Added the property `AllowUnencryptedCache` to the option classes `ClientCertificateCredentialOptions`, `ClientSecretCredentialOptions`, `DeviceCodeCredentialOptions`, `InteractiveBrowserCredentialOptions` and `SharedTokenCacheCredentialOptions` which when set to true allows the credential to fall back to storing tokens in an unencrypted file if no OS level user encryption is available when `EnablePersistentCache` is set to true.
- Added the property `AuthenticationRecord` to the option class `SharedTokenCacheCredentialOptions` to support silent authentication for accounts previously authenticated with an interactive credential.
- Added option class `UsernamePasswordCredentialOptions` which supports the options `EnablePersistentCache` and `AllowUnencryptedCache`.

### Breaking Changes

- Rename type `KnownAuthorityHosts` to `AzureAuthorityHosts`
  - Rename property `AzureChinaCloud` to `AzureChina`
  - Rename property `AzureGermanCloud` to `AzureGermany`
  - Rename property `AzureUSGovernment` to `AzureGovernment`
  - Rename property `AzureCloud` to `AzurePublicCloud`

## 1.2.0-preview.5 (2020-07-08)

### New Features

- Added options classes `ClientCertificateCredentialOptions` and `ClientSecretCredentialOptions` which support the following new option
    - `EnablePersistentCache` configures these credentials to use a persistent cache shared between credentials which set this option. By default the cache is per credential and in memory only.

## 1.2.0-preview.4 (2020-06-10)

### New Features

- Makes `AzureCliCredential`, `VisualStudioCredential` and `VisualStudioCodeCredential` public to allow direct usage.
- Added `Authenticate` methods to `UsernamePasswordCredential`

### Fixes and improvements

- Fix `SharedTokenCacheCredential` account filter to be case-insensitive (Issue [#10816](https://github.com/Azure/azure-sdk-for-net/issues/10816))
- Update `VisualStudioCodeCredential` to properly throw `CredentialUnavailableException` when re-authentication is needed. (Issue [#11595](https://github.com/Azure/azure-sdk-for-net/issues/11595))

## 1.2.0-preview.3 (2020-05-05)

### New Features

- First preview of new API for authenticating users with `DeviceCodeCredential` and `InteractiveBrowserCredential`
  - Added method `Authenticate` which pro-actively interacts with the user to authenticate if necessary and returns a serializable `AuthenticationRecord`
  - Added Options classes `DeviceCodeCredentialOptions` and `InteractiveBrowserCredentialOptions` which support the following new options
    - `AuthenticationRecord` enables initializing a credential with an `AuthenticationRecord` returned from a prior call to `Authenticate`
    - `DisableAutomaticAuthentication` disables automatic user interaction causing the credential to throw an `AuthenticationRequiredException` when interactive authentication is necessary.
    - `EnablePersistentCache` configures these credentials to use a persistent cache shared between credentials which set this option. By default the cache is per credential and in memory only.

## 1.2.0-preview.2 (2020-04-06)

### New Features

- Updates `DefaultAzureCredential` to enable authenticating through Visual Studio
- Updates `DefaultAzureCredential` to enable authentication through Visual Studio Code

## 1.2.0-preview.1 (2020-03-10)

### New Features

- Updating `DefaultAzureCredential` to enable authenticating through the Azure CLI
- `ClientCertificateCredential` now supports being constructed with a path to an unencrypted certificate (in either PFX or PEM format)
- `EnvironmentCredential` now supports reading a certificate path from `AZURE_CLIENT_CERTIFICATE_PATH`

### Fixes and improvements

- Fix an issue where `EnvironmentCredential` did not behave correctly when `AZURE_USERNAME` and `AZURE_PASSWORD` where set
- Added `KnownAuthorityHosts` class to aid in sovereign cloud configuration.

## 1.1.1 (2020-02-10)

### Fixes and improvements

- Fixed `UsernamePasswordCredential` constructor parameter mishandling
- Updated `ManagedIdentityCredential` endpoint discovery to avoid throwing
- Fixed `ManagedIdentityCredential` to raise `CredentialUnavailableException` on 400 return from the service where no identity has been assigned
- Updated error messaging from `DefaultAzureCredential` to more easily root cause failures

## 1.1.0 (2019-11-25)

### Fixes and improvements

- Update `SharedTokenCacheCredential` to filter accounts by tenant id
  - Added `SharedTokenCacheCredentialOptions` class with properties `TenantId` and `Username`
  - Added constructor overload to `SharedTokenCacheCredential` which accepts `SharedTokenCacheCredentialOptions` 
  - Added property `SharedTokenCacheTenantId` to `DefaultAzureCredentialOptions`
- Support for personal account authentication in `DefaultAzureCredential`, `InteractiveBrowserCredential`, and `SharedTokenCacheCredential`
- Added `InteractiveBrowserTenantId` to `DefaultAzureCredentialOptions`
- Fixed issue with `ManagedIdentityCredential` authentication with user assigned identities

## 1.0.0 (2019-10-29)

- First stable release of Azure.Identity package.

### Breaking Changes

- Rename `AzureCredentialOptions` -> `TokenCredentialOptions`
  - Renamed property `VerificationUrl` -> `VerificationUri` and changed type from `string` to `Uri`
- Updated `ClientSecretCredential` class
  - Removed property `ClientId`
  - Removed property `ClientSecret`
  - Removed property `TenantId`
- Updated `ClientCertificateCredential` class
  - Removed property `ClientId`
  - Removed property `ClientCertificate`
  - Removed property `TenantId`
- Updated `DefaultAzureCredential` class to derive directly from `TokenCredential` rather than `ChainedTokenCredential`
- Updated `DefaultAzureCredentialOptions` class
  - Renamed property `PreferredAccountUsername` -> `SharedTokenCacheUsername`
  - Renamed property `IncludeEnvironmentCredential` -> `ExcludeEnvironmentCredential`
  - Renamed property `IncludeManagedIdentityCredential` -> `ExcludeManagedIdentityCredential`
  - Renamed property `IncludeSharedTokenCacheCredential` -> `ExcludeSharedTokenCacheCredential`
  - Renamed property `IncludeInteractiveBrowserCredential` -> `ExcludeInteractiveBrowserCredential`
- Updated `DeviceCodeInfo` class
  - Removed property `Interval`
  - Renamed property `VerificationUrl` -> `VerificationUri` and changed type from `string` to `Uri`
- Updated `InteractiveBrowserCredential` class
  - Reordered constructor parameters `tenantId` and `clientId` to be consistent with other credential types
- Updated `SharedTokenCacheCredential` class
  - Updated constructor to take `TokenCredentialOptions`
  - Removed `clientId` constructor parameter
- Removed class `SharedTokenCacheCredentialOptions`
- Updated exception model across the Azure.Identity library.
  - `TokenCredential` implementations in the Azure.Identity library now throw exceptions rather than returning `default`(`AccessToken`) when no token is obtained
  - Added the `CredentialUnavailableExcpetion` exception type to distinguish cases when failure to obtain an `AccessToken` was expected
  
### Dependency Changes

- Adopted Azure.Core 1.0.0

### Fixes and improvements

- Update `ManagedIdentityCredential` IMDS availability check to handle immediate network failures
- Added a `DefaultAzureCredential` constructor overload to enable interactive credential types by default

## 1.0.0-preview.5 (2019-10-07)

### Dependency Changes

- Adopted Azure.Core 1.0.0-preview.9

### New Features

- Added `DefaultAzureCredentialOptions` for configuring the `DefaultAzureCredential` authentication flow
- Added `InteractiveBrowserCredential` to the `DefaultAzureCredential` authentication flow, but excluded by default

### Fixes and improvements

- Updated `InteractiveBrowserCredential` and `DeviceCodeCredential` to optionally accept a tenantId to support non-multitenant applications

## 1.0.0-preview.4 (2019-09-10)

### Breaking Changes

- Modified GetToken abstraction to accept `TokenRequest` structure rather than `string[]` for forwards compatibility

### Dependency Changes

- Adopted Azure.Core 1.0.0-preview.8

### New Features

- Added `SharedTokenCacheCredential` to support Single Sign On with developer tooling
- Updated `DefaultAzureCredential`authentication flow to include the `SharedTokenCacheCredential`

## 1.0.0-preview.3 (2019-08-06)

### Dependency Changes

- Adopted Azure.Core 1.0.0-preview.7
- Adopted Microsoft.Identity.Client 4.1.0

### New Features

- User Principal Authentication
    - Added `DeviceCodeCredential` class
    - Added  `InteractiveBrowserCredential` class
    - Added `UsernamePasswordCredential` class
- Support for Azure SDK ASP .NET Core integration

### Fixes and improvements

- Added identity client distributed tracing support

## 1.0.0-preview.2 (2019-07-02)

### Fixes and improvements

- Fix to ManagedIdentityCredential to properly parse expires_on from response

## 1.0.0-preview.1 (2019-06-27)

Version 1.0.0-preview.1 is the first preview of our efforts to create a user-friendly authentication API for Azure SDK client libraries. For more
information about preview releases of other Azure SDK libraries, please visit https://aka.ms/azure-sdk-preview1-net.

### New Features

- Azure Service Authentication
  - Added `DefaultAzureCredential` class
  - Added `ChainedTokenCredential` class
- Service Principal Authentication
    - Added `ClientSecretCredential` class
    - Added `ClientCertificateCredential` class
- Managed Identity Authentication
    - Added `ManagedIdentityCredential` class

See the [documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md) for more details. User authentication will be added in an upcoming preview release.
