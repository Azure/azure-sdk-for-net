# Release History

## 1.2.0-preview.5 (Unreleased)


## 1.2.0-preview.4

### New Features
- Makes `AzureCliCredential`, `VisualStudioCredential` and `VisualStudioCodeCredential` public to allow direct usage.
- Added `Authenticate` methods to `UsernamePasswordCredential`

### Fixes and improvements
- Fix `SharedTokenCacheCredential` account filter to be case-insensitive (Issue [#10816](https://github.com/Azure/azure-sdk-for-net/issues/10816))
- Update `VisualStudioCodeCredential` to properly throw `CredentialUnavailableException` when re-authentication is needed. (Issue [#11595](https://github.com/Azure/azure-sdk-for-net/issues/11595))

## 1.2.0-preview.3

### New Features
- First preview of new API for authenticating users with `DeviceCodeCredential` and `InteractiveBrowserCredential`
  - Added method `Authenticate` which pro-actively interacts with the user to authenticate if necessary and returns a serializable `AuthenticationRecord`
  - Added Options classes `DeviceCodeCredentialOptions` and `InteractiveBrowserCredentialOptions` which support the following new options
    - `AuthenticationRecord` enables initializing a credential with an `AuthenticationRecord` returned from a prior call to `Authenticate`
    - `DisableAutomaticAuthentication` disables automatic user interaction causing the credential to throw an `AuthenticationRequiredException` when interactive authentication is necessary.
    - `EnablePersistentCache` configures these credentials to use a persistent cache shared between credentials which set this option. By default the cache is per credential and in memory only.

## 1.2.0-preview.2

### New Features
- Updates `DefaultAzureCredential` to enable authenticating through Visual Studio
- Updates `DefaultAzureCredential` to enable authentication through Visual Studio Code

## 1.2.0-preview.1

### New Features
- Updating `DefaultAzureCredential` to enable authenticating through the Azure CLI
- `ClientCertificateCredential` now supports being constructed with a path to an unencrypted certificate (in either PFX or PEM format)
- `EnvironmentCredential` now supports reading a certificate path from `AZURE_CLIENT_CERTIFICATE_PATH`

### Fixes and improvements
- Fix an issue where `EnvironmentCredential` did not behave correctly when `AZURE_USERNAME` and `AZURE_PASSWORD` where set
- Added `KnownAuthorityHosts` class to aid in sovereign cloud configuration.

## 1.1.1

### Fixes and improvements
- Fixed `UsernamePasswordCredential` constructor parameter mishandling
- Updated `ManagedIdentityCredential` endpoint discovery to avoid throwing
- Fixed `ManagedIdentityCredential` to raise `CredentialUnavailableException` on 400 return from the service where no identity has been assigned
- Updated error messaging from `DefaultAzureCredential` to more easily root cause failures

## 1.1.0

### Fixes and improvements
- Update `SharedTokenCacheCredential` to filter accounts by tenant id
  - Added `SharedTokenCacheCredentialOptions` class with properties `TenantId` and `Username`
  - Added constructor overload to `SharedTokenCacheCredential` which accepts `SharedTokenCacheCredentialOptions` 
  - Added property `SharedTokenCacheTenantId` to `DefaultAzureCredentialOptions`
- Support for personal account authentication in `DefaultAzureCredential`, `InteractiveBrowserCredential`, and `SharedTokenCacheCredential`
- Added `InteractiveBrowserTenantId` to `DefaultAzureCredentialOptions`
- Fixed issue with `ManagedIdentityCredential` authentication with user assigned identities

## 1.0.0
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

## 1.0.0-preview.5

### Dependency Changes
- Adopted Azure.Core 1.0.0-preview.9

### New Features
- Added `DefaultAzureCredentialOptions` for configuring the `DefaultAzureCredential` authentication flow
- Added `InteractiveBrowserCredential` to the `DefaultAzureCredential` authentication flow, but excluded by default

### Fixes and improvements
- Updated `InteractiveBrowserCredential` and `DeviceCodeCredential` to optionally accept a tenantId to support non-multitenant applications

## 1.0.0-preview.4

### Breaking Changes
- Modified GetToken abstraction to accept `TokenRequest` structure rather than `string[]` for forwards compatibility

### Dependency Changes
- Adopted Azure.Core 1.0.0-preview.8

### New Features
- Added `SharedTokenCacheCredential` to support Single Sign On with developer tooling
- Updated `DefaultAzureCredential`authentication flow to include the `SharedTokenCacheCredential`


## 1.0.0-preview.3

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


## 1.0.0-preview.2

### Fixes and improvements
- Fix to ManagedIdentityCredential to properly parse expires_on from response


## 1.0.0-preview.1

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
