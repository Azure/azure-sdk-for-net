# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
