# Release History

## 4.2.0-beta.4 (Unreleased)


## 4.2.0-beta.3 (2020-11-12)

### Added

- Added `KeyType.OctHsm` to support "oct-HSM" key operations.
- Added AES-GCM and AES-CBC support for encrypting and decrypting, including new `Encrypt` and `Decrypt` overloads.
- Added support for Secure Key Release including the `Export` method on `KeyClient` and `ReleasePolicy` property on various models.

## 4.2.0-beta.2 (2020-10-06)

- Bug fixes and performance improvements.

## 4.2.0-beta.1 (2020-09-08)

### Added

- Added `KeyVaultKeyIdentifier` to parse key URIs.
- Added `LocalCryptographyClient` to do cryptography operations locally using a `JsonWebKey`.

### Changed

- Clarified documentation for `KeyClientBuilderExtensions` methods.

## 4.1.0 (2020-08-11)

### Added

- Added "import" value to `KeyOperation` enumeration.
- Added `RecoverableDays` property to `KeyProperties`.

### Changed

- Default service version is now 7.1.

## 4.0.4 (2020-07-09)

### Fixed

- The "get" permission is no longer required to resolve keys for `KeyResolver` ([#11574](https://github.com/Azure/azure-sdk-for-net/issues/11574))

### Minor changes

- Make public `JsonWebKey` properties settable ([#12084](https://github.com/Azure/azure-sdk-for-net/issues/12084))

## 4.0.3 (2020-03-18)

### Fixed

- Fixed concurrency issue in our challenge-based authentication policy ([#9737](https://github.com/Azure/azure-sdk-for-net/issues/9737))

## 4.1.0-preview.1 (2020-03-09)

### Added

- Add "import" value to `KeyOperation` enumeration.
- Add `RecoverableDays` property to `KeyProperties`.

## 4.0.2 (2020-03-03)

### Fixed

- Shorten diagnostic scope names. ([#9651](https://github.com/Azure/azure-sdk-for-net/issues/9651))
- Include resource namespace in diagnostics scope. ([#9655](https://github.com/Azure/azure-sdk-for-net/issues/9655))
- Sanitize header values in exceptions. ([#9782](https://github.com/Azure/azure-sdk-for-net/issues/9782))

## 4.0.1 (2020-01-08)

### Minor changes

- Challenge-based authentication requests are only sent over HTTPS.

## 4.0.0 (2019-11)

### Breaking changes

- `Key` has been renamed to `KeyVaultKey` to avoid ambiguity with other libraries and to yield better search results.
- `Key.KeyMaterial` has been renamed to `KeyVaultKey.Key`.
- The default `JsonWebKey` constructor has been removed.
- `JsonWebKey` constructors now take an optional collection of key operations.
- `JsonWebKey.KeyOps` is now read-only. You must pass a collection of key operations at construction time.
- `Hsm` properties and `hsm` parameters have been renamed to `HardwareProtected` and `hardwareProtected` respectively.
- On the `KeyProperties` class, `Expires`, `Created`, and `Updated` have been renamed to `ExpiresOn`, `CreatedOn`, and `UpdatedOn` respectively.
- On the `DeletedKey` class, `DeletedDate` has been renamed to `DeletedOn`.
- `KeyClient.GetKeys` and `KeyClient.GetKeyVersions` have been renamed to `KeyClient.GetPropertiesOfKeys` and `KeyClient.GetPropertiesOfKeyVersions` respectively.
- `KeyClient.RestoreKey` has been renamed to `KeyClient.RestoreKeyBackup` to better associate it with `KeyClient.BackupKey`.
- `KeyClient.DeleteKey` has been renamed to `KeyClient.StartDeleteKey` and now returns a `DeleteKeyOperation` to track this long-running operation.
- `KeyClient.RecoverDeletedKey` has been renamed to `KeyClient.StartRecoverDeletedKey` and now returns a `RecoverDeletedKeyOperation` to track this long-running operation.
- `KeyCreateOptions` has been renamed to `CreateKeyOptions`.
- `KeyImportOptions` has been renamed to `ImportKeyOptions`.
- `EcCreateKeyOptions` has been renamed to `CreateEcKeyOptions`.
- `CreateEcKeyOptions.Curve` has been renamed to `CurveName` to be consistent across the library.
- The `curveName` optional parameter has been removed from  the `CreateEcKeyOptions` constructor. Set it using the `CurveName` property instead.
- `RsaKeyCreateOptions` has been renamed to `CreateRsaKeyOptions`.
- The `keySize` optional parameter has been removed from  the `CreateRsaKeyOptions` constructor. Set it using the `KeySize` property instead.

### Major changes

- Updated to work with the 1.0.0 release versions of Azure.Core and Azure.Identity.
- `JsonWebKey.KeyType` and `JsonWebKey.KeyOps` have been exposed as `KeyVaultKey.KeyType` and `KeyVaultKey.KeyOperations` respectively.
- `KeyModelFactory` added to create mocks of model types for testing.
- `CryptographyModeFactory` added to create mocks of model types for testing.
- Added ETW trace logger "Azure-Security-KeyVault-Keys" with provider ID "{657a121e-762e-50da-b233-05d7cdb24eb8}"
  for cases in `CryptographyClient` when the available `KeyVaultKey` cannot be used for an operation and the service will perform the operation instead.

## 4.0.0-preview.5 (2019-10-07)

### Breaking changes

- `KeyType` enumeration values have been changed to match other languages, e.g. `KeyType.EllipticCurve` is now `KeyType.Ec`.
- `KeyOperations` has been renamed `KeyOperation`.
- Enumerations including `KeyCurveName`, `KeyOperation`, and `KeyType` are now structures that define well-known, supported static fields.
- `KeyBase` has been renamed to `KeyProperties`.
- `Key` and `DeletedKey` no longer extend `KeyProperties`, but instead contain a `KeyProperties` property named `Properties`.
- `KeyClient.UpdateKey` has been renamed to `KeyClient.UpdateKeyProperties`.

### Major changes

- `KeyClient.UpdateKey` and `KeyClient.UpdateKeyAsync` now allow the `keyOperations` parameter to be null, resulting in no changes to the allowed key operations.
- `RSA` and `ECDsa` support have been implemented for `CryptographyClient` to use locally if key operations and key material allow; otherwise, operations will be performed in Azure Key Vault.

## 4.0.0-preview.1 (2019-06-28)

Version 4.0.0-preview.1 is the first preview of our efforts to create a user-friendly client library for Azure Key Vault. For more information about
preview releases of other Azure SDK libraries, please visit
https://aka.ms/azure-sdk-preview1-net.

This library is not a direct replacement for `Microsoft.Azure.KeyVault`. Applications
using that library would require code changes to use `Azure.Security.KeyVault.Keys`.
This package's
[documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md)
and
[samples](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/keyvault/Azure.Security.KeyVault.Keys/samples)
demonstrate the new API.

### Major changes from `Microsoft.Azure.KeyVault`

- Packages scoped by functionality
  - `Azure.Security.KeyVault.Keys` contains a client for key operations.
  - `Azure.Security.KeyVault.Secrets` contains a client for secret operations.
- Client instances are scoped to vaults (an instance interacts with one vault
only).
- Asynchronous and synchronous APIs in the `Azure.Security.KeyVault.Keys` package.
- Authentication using `Azure.Identity` credentials
  - see this package's
  [documentation](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md)
  , and the
  [Azure Identity documentation](https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity)
  for more information

### `Microsoft.Azure.KeyVault` features not implemented in this release:

- Certificate management APIs
- Cryptographic operations, e.g. sign, un/wrap, verify, en- and
decrypt
- National cloud support. This release supports public global cloud vaults,
    e.g. `https://{vault-name}.vault.azure.net`
