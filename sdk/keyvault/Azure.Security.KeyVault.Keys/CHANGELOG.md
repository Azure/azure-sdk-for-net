# Release History

## 4.9.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

- The default service version is now `2025-07-01`.

## 4.8.0 (2025-06-27)

### Acknowledgments

Thank you to our developer community members who helped to make the Key Vault client libraries better with their contributions to this release:

- James Gould _([GitHub](https://github.com/james-gould))_

### Features Added

- Added Hmac algorithms in `SignatureAlgorithm`
- Added CkmAesKeyWrap algorithm in `KeyWrapAlgorithm`
- Added Attestation property for Keys in Managed HSM Key Vaults.
- Adde new `GetKeyAttestation` operation to get the public part of a stored key along with its attestation blob.

### Bugs Fixed

- Removed additional forward slash in `RestoreKeyBackup` and `RestoreKeyBackupAsync`.

### Other Changes

- The default service version is now "7.6".

## 4.8.0-beta.1 (2025-04-08)

### Features Added

- Added Hmac algorithms in `SignatureAlgorithm`
- Added CkmAesKeyWrap algorithm in `EncryptionAlgorithm`
- Added Attestation property for Keys in Managed HSM Key Vaults.
- New `GetKeyAttestation` operation to get the public part of a stored key along with its attestation blob.

### Other Changes

- The default service version is now "7.6-preview.2".

## 4.7.0 (2024-10-14)

### Features Added

- Support for Continuous Access Evaluation (CAE).

## 4.6.0 (2024-02-14)

Changes from both the last release and the last beta include:

### Features Added

- Added `CryptographyClient.CreateRSA` and `CreateRSAAsync` to create an `RSA` implementation backed by Key Vault or Managed HSM.
  Use this anywhere an `RSA` or `AsymmetricAlgorithm` is required. ([#3545](https://github.com/Azure/azure-sdk-for-net/issues/3545))
- Added `KeyProperties.HsmPlatform` to get the underlying HSM platform.

### Breaking Changes

- Renamed tags reported on `KeyClient`, `KeyResolver`, `CryptographyClient`, and `RemoteCryptographyClient` activities to follow OpenTelemetry attribute naming conventions:
  - `key` to `az.keyvault.key.id` or `az.keyvault.key.name` depending on the value being reported
  - `version` to `az.keyvault.key.version`

### Bugs Fixed

- When a Key Vault is moved to another tenant, the client is reauthenticated.
- `KeyRotationPolicyAction` performs case-insensitive comparisons since Key Vault and Managed HSM return different cases for "rotate".

### Other Changes

- The default service version is now "7.5".
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 4.6.0-beta.2 (2023-11-13)

### Other Changes

- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 4.6.0-beta.1 (2023-11-09)

### Features Added

- Added `CryptographyClient.CreateRSA` and `CreateRSAAsync` to create an `RSA` implementation backed by Key Vault or Managed HSM.
  Use this anywhere an `RSA` or `AsymmetricAlgorithm` is required. ([#3545](https://github.com/Azure/azure-sdk-for-net/issues/3545))
- Added `KeyProperties.HsmPlatform` to get the underlying HSM platform.

### Breaking Changes

- Renamed tags reported on `KeyClient`, `KeyResolver`, `CryptographyClient`, and `RemoteCryptographyClient` activities to follow OpenTelemetry attribute naming conventions:
  - `key` to `az.keyvault.key.id` or `az.keyvault.key.name` depending on the value being reported
  - `version` to `az.keyvault.key.version`

### Bugs Fixed

- When a Key Vault is moved to another tenant, the client is reauthenticated.
- `KeyRotationPolicyAction` performs case-insensitive comparisons since Key Vault and Managed HSM return different cases for "rotate".

### Other Changes

- The default service version is now "7.5-preview.1".

## 4.5.0 (2023-03-14)

### Breaking Changes

The following changes are only breaking from the previous beta. They are not breaking since version 4.4.0 when those types and members did not exist.

- Service version "7.4-preview.1" is not supported.
- Removed `CreateOkpKeyOptions`.
- Removed `KeyClient.CreateOkpKey` and `CreateOkpKeyAsync`.
- Removed `KeyType.Okp` and `KeyType.OkpHsm` from `JsonWebKey`.
- Removed `KeyCurveName.Ed25519`.
- Removed `SignatureAlgorithm.EdDsa`.

### Other Changes

- The default service version is now "7.4".

## 4.5.0-beta.1 (2022-11-09)

### Features Added

- Added `CreateOkpKeyOptions` to pass key options when creating an Octet Key Pair (OKP) on Managed HSM.
- Added `KeyClient.CreateOkpKey` and `CreateOkpKeyAsync` to create an Octet Key Pair (OKP) on Managed HSM.
- Added `KeyType.Okp` and `KeyType.OkpHsm` for `JsonWebKey`.
- Added `KeyCurveName.Ed25519` to create an Octet Key Pair (OKP) using the Ed25519 curve.
- Added `SignatureAlgorithm.EdDsa` to support signing and verifying using an Edwards Curve Digital Signature Algorithm (EdDSA) on Managed HSM.

### Bugs Fixed

- Fixed possible "ObjectIsBeingRecovered" error immediately after restoring certificates, keys, or secrets. ([#31581](https://github.com/Azure/azure-sdk-for-net/issues/31581))

### Other Changes

- The default service version is now "7.4-preview.1".

## 4.4.0 (2022-09-20)

### Breaking Changes

- Verify the challenge resource matches the vault domain.
  This should affect few customers who can set `KeyClientOptions.DisableChallengeResourceVerification` or `CryptographyClientOptions.DisableChallengeResourceVerification` to `true` to disable.
  See https://aka.ms/azsdk/blog/vault-uri for more information.

## 4.3.0 (2022-03-24)

Changes from both the last release and the last beta include:

### Features Added

- Added `Exportable` and `ReleasePolicy` to `CreateKeyOptions`, `ImportKeyOptions`, and `KeyProperties` to support Secure Key Release for Key Vault and Managed HSM.
- Added `GetRandomBytes` and `GetRandomBytesAsync` to `KeyClient` to get random bytes from a managed HSM.
- Added `JsonWebKeyConverter` to support serializing and deserializing a `JsonWebKey` to a RFC 7517 JWK. ([#16155](https://github.com/Azure/azure-sdk-for-net/issues/16155))
- Added `KeyClient.GetCryptographyClient` to get a `CryptographyClient` that uses the same options, policies, and pipeline as the `KeyClient` that created it. ([#23786](https://github.com/Azure/azure-sdk-for-net/issues/23786))
- Added `KeyReleasePolicy.Immutable` property.
- Added `KeyRotationPolicy` class and new methods including `KeyClient.GetKeyRotationPolicy`, `KeyClient.RotateKey`, and `KeyClient.UpdateKeyRotationPolicy`.
- Added `KeyVaultKeyIdentifier.TryCreate` to parse key URIs without throwing an exception when invalid. ([#23146](https://github.com/Azure/azure-sdk-for-net/issues/23146))
- Added `ReleaseKey` and `ReleaseKeyAsync` to `KeyClient` to release a key for Key Vault and Managed HSM.
- Support multi-tenant authentication against Key Vault and Managed HSM when using Azure.Identity 1.5.0 or newer. ([#18359](https://github.com/Azure/azure-sdk-for-net/issues/18359))

- Changed `KeyRotationLifetimeAction.Action` to read-only and added constructor to set the `KeyRotationPolicyAction`.
- Renamed `name` parameter in `GetKeyRotationPolicy` and `GetKeyRotationPolicyAsync` to `keyName`.
- Renamed `name` parameter in `UpdateKeyRotationPolicy` and `UpdateKeyRotationPolicyAsync` to `keyName`.

### Bugs Fixed

- The default service version is now "7.3".
- Attempt to cache key locally from `KeyClient.GetCryptographyClient`. ([#25254](https://github.com/Azure/azure-sdk-for-net/issues/25254))
- Added key version to distributed tracing. ([#12907](https://github.com/Azure/azure-sdk-for-net/issues/12907))

### Breaking Changes

- (Since 4.3.0-beta.7) `KeyClient.ReleaseKey` and `ReleaseKeyAsync` now take `name` and `targetAttestationToken`, or a `ReleaseKeyOptions` with a required `name` and `targetAttestationToken` along with additional properties.

### Other Changes

- `KeyProperties.Version` is no longer required when calling `KeyClient.UpdateKeyProperties` or `UpdateKeyPropertiesAsync`.

## 4.3.0-beta.7 (2022-02-08)

### Features Added

- Added `KeyReleasePolicy.Immutable` property.

### Breaking Changes

- `KeyRotationPolicy.ExpiresIn` was changed from a `TimeSpan?` to a `string` to properly round trip. It must be an ISO 8601 duration like "P30D" for 30 days.
- `KeyRotationLifetimeAction.TimeAfterCreate` and `TimeBeforeExpiry` were changed from a `TimeSpan?` to a `string` to properly round trip. It must be an ISO 8601 duration like "P30D" for 30 days.

### Other Changes

- `KeyProperties.Version` is no longer required when calling `KeyClient.UpdateKeyProperties` or `UpdateKeyPropertiesAsync`.

## 4.3.0-beta.6 (2022-01-12)

### Other Changes

- Package metadata fixed

## 4.3.0-beta.5 (2022-01-11)

### Other Changes

- Bug fixes

## 4.3.0-beta.4 (2021-11-16)

### Bugs Fixed

- Attempt to cache key locally from `KeyClient.GetCryptographyClient`. ([#25254](https://github.com/Azure/azure-sdk-for-net/issues/25254))

## 4.3.0-beta.3 (2021-11-09)

### Breaking Changes

- Changed return type from `RandomBytes` to `byte[]` on `KeyClient.GetRandomBytes` and `GetRandomBytesAsync`.
- Renamed `KeyReleasePolicy.Data` to `KeyReleasePolicy.EncodedPolicy` and changed property type from `byte[]` to `BinaryData`.
- Renamed `name` and `version` parameters on `KeyClient.GetCryptographyClient` to `keyName` and `keyVersion`, respectively.
- Renamed `target` parameter on `KeyClient.ReleaseKey` and `ReleaseKeyAsync` to `targetAttestationToken`.

## 4.3.0-beta.2 (2021-10-14)

### Features Added

- Added `JsonWebKeyConverter` to support serializing and deserializing a `JsonWebKey` to a RFC 7517 JWK. ([#16155](https://github.com/Azure/azure-sdk-for-net/issues/16155))
- Added `KeyClient.GetCryptographyClient` to get a `CryptographyClient` that uses the same options, policies, and pipeline as the `KeyClient` that created it. ([#23786](https://github.com/Azure/azure-sdk-for-net/issues/23786))
- Added `KeyRotationPolicy` class and new methods including `KeyClient.GetKeyRotationPolicy`, `KeyClient.RotateKey`, and `KeyClient.UpdateKeyRotationPolicy`.
- Added `KeyVaultKeyIdentifier.TryCreate` to parse key URIs without throwing an exception when invalid. ([#23146](https://github.com/Azure/azure-sdk-for-net/issues/23146))
- Support multi-tenant authentication against Key Vault and Managed HSM when using Azure.Identity 1.5.0 or newer. ([#18359](https://github.com/Azure/azure-sdk-for-net/issues/18359))

### Bugs Fixed

- Added key version to distributed tracing. ([#12907](https://github.com/Azure/azure-sdk-for-net/issues/12907))

## 4.3.0-beta.1 (2021-08-10)

### Features Added

- Added `GetRandomBytes` and `GetRandomBytesAsync` to `KeyClient` to get random bytes from a managed HSM.
- Added `Exportable` and `ReleasePolicy` to `CreateKeyOptions`, `ImportKeyOptions`, and `KeyProperties` to support Secure Key Release for Key Vault and Managed HSM.
- Added `ReleaseKey` and `ReleaseKeyAsync` to `KeyClient` to release a key for Key Vault and Managed HSM.

### Fixed

- The default service version is now "7.3-preview".

## 4.2.0 (2021-06-15)

### Features Added

- Changed default service version to "7.2".
- Added `KeyVaultKeyIdentifier` to parse certificate URIs.
- Added local-only support for `CryptographyClient` using only a `JsonWebKey` using `LocalCryptographyClientOptions`.
- Added `CreateEcKeyOptions` class and associated `KeyClient.CreateEcKey` and `CreateEcKeyAsync` methods.
- Added `KeyType.OctHsm` to support "oct-HSM" key operations to support Managed HSM.
- Added AES-GCM and AES-CBC support for encrypting and decrypting, including new `Encrypt` and `Decrypt` overloads.

### Breaking Changes since 4.2.0-beta.6

- Renamed `additionalAuthenticationData` factory method parameters to `additionalAuthenticatedData` to match properties and constructor parameters.
- Renamed `parameters` parameter to `decryptParameters` for `CryptographyClient.Decrypt` and `DecryptAsync`.
- Renamed `parameters` parameter to `encryptParameters` for `CryptographyClient.Encrypt` and `EncryptAsync`.

## 4.2.0-beta.6 (2021-05-11)

### Changed

- Updated dependency versions

## 4.1.1 (2021-05-04)

### Changed

- Updated dependency versions

## 4.2.0-beta.5 (2021-03-09)

### Added

- `LocalCryptographyClientOptions` has been added to configure diagnostics for `CryptographyClient` when used for local-only operations.

### Removed

- `LocalCryptographyClient` has been removed. Use `CryptographyClient` with a `JsonWebKey` instead.

## 4.2.0-beta.4 (2021-02-10)

### Added

- Added `CreateEcKeyOptions` class.
- Added `CreateEcKey` and `CreateEcKeyAsync` methods to the `KeyClient` class.
- Added constructor to `KeyVaultKeyIdentifier` to parse a `Uri`.

### Changed

- The default service version is now "7.2" (still in preview).
- Renamed `EncryptOptions` to `EncryptParameters`.
- Renamed `DecryptOptions` to `DecryptParameters`.
- Made `EncryptParameters.AdditionalAuthenticatedData` read-only, requiring it to be passed to the constructor.
- Made `DecryptParameters.AdditionalAuthenticatedData` read-only, requiring it to be passed to the constructor.

### Removed

- Removed local cryptographic support for AES-GCM.
- Removed `Export` and `ExportAsync` methods from `KeyClient`.
- Removed `Exportable` property from `KeyProperties`'.
- Removed `KeyReleasePolicy` class and associated properties.
- Removed `KeyVaultKeyIdentifier.Parse` and `KeyVaultKeyIdentifier.TryParse` in favor of the added constructor.

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

## 4.0.0 (2019-11-01)

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
[documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md)
and
[samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/keyvault/Azure.Security.KeyVault.Keys/samples)
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
  [documentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/keyvault/Azure.Security.KeyVault.Keys/README.md)
  , and the
  [Azure Identity documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity)
  for more information

### `Microsoft.Azure.KeyVault` features not implemented in this release:

- Certificate management APIs
- Cryptographic operations, e.g. sign, un/wrap, verify, en- and
decrypt
- National cloud support. This release supports public global cloud vaults,
    e.g. `https://{vault-name}.vault.azure.net`
