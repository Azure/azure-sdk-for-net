# Release History

## 4.2.0-beta.4 (Unreleased)


## 4.2.0-beta.3 (2020-11-12)

- Bug fixes and performance improvements.

## 4.2.0-beta.2 (2020-10-06)

- Bug fixes and performance improvements.

## 4.2.0-beta.1 (2020-09-08)

### Added

- Added `KeyVaultSecretIdentifier` to parse secret URIs.

## 4.1.0 (2020-08-11)

### Added

- Added `RecoverableDays` property to `SecretProperties`.

### Changed

- Default service version is now 7.1.

## 4.0.3 (2020-03-18)

### Fixed

- Fixed concurrency issue in our challenge-based authentication policy ([#9737](https://github.com/Azure/azure-sdk-for-net/issues/9737))

## 4.1.0-preview.1 (2020-03-09)

### Added

- Add `RecoverableDays` property to `SecretProperties`.

## 4.0.2 (2020-03-03)

### Fixed

- `SecretClient.PurgeDeletedSecret` properly traces errors ([#9658](https://github.com/Azure/azure-sdk-for-net/issues/9658))
- Shorten diagnostic scope names. ([#9651](https://github.com/Azure/azure-sdk-for-net/issues/9651))
- Include resource namespace in diagnostics scope. ([#9655](https://github.com/Azure/azure-sdk-for-net/issues/9655))
- Sanitize header values in exceptions. ([#9782](https://github.com/Azure/azure-sdk-for-net/issues/9782))

## 4.0.1 (2020-01-08)

### Minor changes

- Challenge-based authentication requests are only sent over HTTPS.

## 4.0.0 (2019-11)

### Breaking changes

- `Secret` has been renamed to `KeyVaultSecret` to avoid ambiguity with other libraries and to yield better search results.
- On the `SecretProperties` class, `Expires`, `Created`, and `Updated` have been renamed to `ExpiresOn`, `CreatedOn`, and `UpdatedOn` respectively.
- On the `DeletedSecret` class, `DeletedDate` has been renamed to `DeletedOn`.
- `SecretClient.GetSecrets` and `SecretClient.GetSecretVersions` have been renamed to `SecretClient.GetPropertiesOfSecrets` and `SecretClient.GetPropertiesOfSecretVersions` respectively.
- `SecretClient.RestoreSecret` has been renamed to `SecretClient.RestoreSecretBackup` to better associate it with `SecretClient.BackupSecret`.
- `SecretClient.DeleteSecret` has been renamed to `SecretClient.StartDeleteSecret` and now returns a `DeleteSecretOperation` to track this long-running operation.
- `SecretClient.RecoverDeletedSecret` has been renamed to `SecretClient.StartRecoverDeletedSecret` and now returns a `RecoverDeletedSecretOperation` to track this long-running operation.

###  Major changes

- Updated to work with the 1.0.0 release versions of Azure.Core and Azure.Identity.
- `KeyModelFactory` added to create mocks of model types for testing.

## 4.0.0-preview.5 (2019-10-07)

###  Breaking changes

- `SecretBase` has been renamed to `SecretProperties`.
- `Secret` and `DeletedSecret` no longer extend `SecretProperties`, but instead contain a `SecretProperties` property named `Properties`.
- `SecretClient.Update` has been renamed to `SecretClient.UpdateProperties`.
- `SecretProperties.Vault` has been renamed to `SecretProperties.VaultUri`.
- All methods in `SecretClient` now include the word "Secret" consistent with `KeyClient` and `CertificateClient`.

## 4.0.0-preview.1 (2019-06-28)
Version 4.0.0-preview.1 is the first preview of our efforts to create a user-friendly client library for Azure Key Vault. For more information about
preview releases of other Azure SDK libraries, please visit
https://aka.ms/azure-sdk-preview1-net.

This library is not a direct replacement for `Microsoft.Azure.KeyVault`. Applications
using that library would require code changes to use `Azure.Security.KeyVault.Secrets`.
This package's
[documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md)
and
[samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/samples)
demonstrate the new API.

### Major changes from `Microsoft.Azure.KeyVault`
- Packages scoped by functionality
    - `Azure.Security.KeyVault.Secrets` contains a client for secret operations.
    - `Azure.Security.KeyVault.Keys` contains a client for key operations.
- Client instances are scoped to vaults (an instance interacts with one vault
only).
- Asynchronous and synchronous APIs in the `Azure.Security.KeyVault.Secrets` package.
- Authentication using `Azure.Identity` credentials
  - see this package's
  [documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md)
  , and the
  [Azure Identity documentation](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity)
  for more information

### `Microsoft.Azure.KeyVault` features not implemented in this release:
- Certificate management APIs
- National cloud support. This release supports public global cloud vaults,
    e.g. https://{vault-name}.vault.azure.net
