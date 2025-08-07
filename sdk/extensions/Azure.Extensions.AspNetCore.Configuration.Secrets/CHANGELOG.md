# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0 (2025-02-11)

### Other Changes

- Updated dependencies to ensure they are up-to-date with the latest targets and trimming from built-in dependencies.

## 1.3.2 (2024-08-16)

### Other Changes

- Updated reference to `Azure.Security.KeyVault.Secrets` v4.6.0 to mitigate a reported SSRF vulnerability.

## 1.3.1 (2024-02-12)

### Bugs Fixed

- Fix several issues related to ThreadPool starvation for synchronous scenarios

## 1.3.0 (2023-11-08)

### Acknowledgments

Thank you to our developer community members who helped to make the Key Vault configuration library better with their contributions to this release:

- Daniel Laughland _([GitHub](https://github.com/jabberwik))_

### Features Added

- Changed visibility of `AzureKeyVaultConfigurationSource` as public to allow for custom ordering of configuration sections when reading.  _(A community contribution, courtesy of [jabberwik](https://github.com/jabberwik))_

### Bugs Fixed

- Corrected the parameter name in the `ArgumentNullException` that is thrown if a null `options` argument is passed 
  to `AddAzureKeyVault`.

## 1.2.2 (2022-04-05)

### Acknowledgments

Thank you to our developer community members who helped to make the Key Vault configuration library better with their contributions to this release:

- Martin Costello  _([GitHub](https://github.com/martincostello))_

### Bugs Fixed

- Prevent ObjectDisposedException when Key Vault config provider is disposed twice. _(A community contribution, courtesy of [martincostello](https://github.com/martincostello))_

## 1.2.1 (2021-05-18)

### Changes

#### Key Bug Fixes

- Fixes an issues where keys returned from `AzureKeyVaultConfigurationProvider` were case sensitive. 

## 1.1.0 (2021-05-14)

### Changes

- Dependency versions updated.

### Added

- The `AzureKeyVaultConfigurationProvider` was made public.
- The `KeyVaultSecretManager.GetData` method was added to allow customizing the way secrets are turned into configuration values.

## 1.0.2 (2020-11-10)

### Added

An overload of `AddAzureKeyVault` that takes an `AzureKeyVaultConfigurationOptions` parameter and allows specifying the reload interval.

## 1.0.1 (2020-10-06)

- Number of parallel secret retrievals is limited to `32`.

## 1.0.0 (2020-06-04)

- No changes. General availability release.

## 1.0.0-preview.2 (2020-05-05)

- Package renamed to Azure.Extensions.AspNetCore.Configuration.Secrets

## 1.0.0-preview.1 (2020-03-02)

- Initial preview of the Azure.Extensions.Configuration.Secrets library
