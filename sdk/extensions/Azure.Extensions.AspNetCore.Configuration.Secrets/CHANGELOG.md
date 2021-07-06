# Release History

## 1.3.0-beta.1 (Unreleased)


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
