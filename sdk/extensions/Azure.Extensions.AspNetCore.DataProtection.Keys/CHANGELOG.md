# Release History

## 1.7.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.6.1 (2025-06-23)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Mike Alhayek _([GitHub](https://github.com/MikeAlhayek))_

### Bugs Fixed

- Updated `ConfigureKeyManagementKeyVaultEncryptorClientOptions` to ensure that its dependencies were resolved in the correct scope to prevent issues due to lifetime drift.  Previously, a new scope was created to resolve `AzureKeyVaultXmlEncryptor`.  However, `AzureKeyVaultXmlEncryptor` is registered as a singleton and should be resolved from the same scope in which the options are being configured. Creating a new scope introduced unnecessary overhead and potential for unexpected behavior due to differences in service lifetime management.  _(A community contribution, courtesy of [danielmarbach](https://github.com/MikeAlhayek))_

## 1.6.0 (2025-05-19)

### Features Added

- Overloads were added to accept a `Uri`-typed key identifier to all protection methods.  _(A community contribution, courtesy of [MattKotsenas](https://github.com/abatishchev))_

## 1.5.0 (2025-05-06)

### Acknowledgments

Thank you to our developer community members who helped to make the Data Protection libraries better with their contributions to this release:

- Matt Kotsenas _([GitHub](https://github.com/MattKotsenas))_

### Features Added

- An overload was added to `ProtectKeysWithAzureKeyVault` which allows for resolving the key identifier dynamically using `IServiceProvider` rather than using a static identifier.  _(A community contribution, courtesy of [MattKotsenas](https://github.com/MattKotsenas))_

## 1.4.0 (2025-02-11)

### Other Changes

- Updated dependencies to ensure they are up-to-date with the latest targets and trimming from built-in dependencies.

## 1.3.0 (2024-11-26)

### Other Changes

- Updated dependency `Microsoft.Extensions.DependencyInjection` to version `8.0.11`
- Updated dependency `Microsoft.Bcl.AsyncInterfaces` to version `8.0.0`

## 1.2.4 (2024-08-16)

### Other Changes

- Updated reference to `Azure.Security.KeyVault.Keys` v4.6.0 to mitigate a reported SSRF vulnerability.

## 1.2.3 (2024-02-12)

### Bugs Fixed

- Fix several issues related to ThreadPool starvation for synchronous scenarios

## 1.2.2 (2023-03-11)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.30.0`.

## 1.2.1 (2023-03-07)

### Other Changes

- Updating additional dependencies to mitigate [CVE-2021-24112](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2021-24112).  Note that the vulnerability only exists in a dependency referenced by the `netcoreapp3.0` target, which reach end-of-life in December, 2019.

## 1.2.0 (2023-02-07)

### Acknowledgments

Thank you to our developer community members who helped to make the Event Hubs client libraries better with their contributions to this release:

- Tom Longhurst _([GitHub](https://github.com/thomhurst))_

### Features Added

- Added an overload when configuring data protection which allows token credentials to be created by a factory on-demand.  _(A community contribution, courtesy of [thomhurst](https://github.com/thomhurst))_

### Other Changes

- Updated dependency version of `Microsoft.AspNetCore.DataProtection` to mitigate [CVE-2021-24112](https://msrc.microsoft.com/update-guide/vulnerability/CVE-2021-24112).  Note that the vulnerability only exists in a dependency referenced by the `netcoreapp3.0` target, which reach end-of-life in December, 2019.

## 1.1.0 (2021-09-07)

### Changes

- Dependency versions updated.

## 1.0.3 (2021-05-14)

### Changes

- Dependency versions updated.

## 1.0.2 (2020-09-01)

### Fixed

- Support reading keys created by a previous version of Azure KeyVault Keys DataProtection library.

## 1.0.1 (2020-08-06)

### Fixed

- Deadlock on .NET Framework (https://github.com/Azure/azure-sdk-for-net/pull/12605)

## 1.0.0 (2020-06-04)

- No changes. General availability release.

## 1.0.0-preview.2 (2020-05-05)

- Package renamed to Azure.Extensions.AspNetCore.DataProtection.Keys
- Default overload of ProtectKeysWithAzureKeyVault now takes a Uri to be consistent with other extension methods and KeyVault clients.

## 1.0.0-preview.1 (2020-03-02)

- Initial preview of the Azure.AspNetCore.DataProtection.Keys library
