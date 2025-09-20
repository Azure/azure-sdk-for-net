# Release History

## 4.9.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

- The default service version is now `2025-07-01`.

## 4.8.0 (2025-06-16)

### Acknowledgments

Thank you to our developer community members who helped to make the Key Vault client libraries better with their contributions to this release:

- James Gould _([GitHub](https://github.com/james-gould))_

### Bugs Fixed

- Removed additional forward slash in `RestoreCertificateBackup` and `RestoreCertificateBackupAsync`.

### Other Changes

- The default service version is now "7.6". 

## 4.8.0-beta.1 (2025-04-08)

### Features Added

- New `preserveCertificateOrder` option when creating and importing certificates. It can be set as an optional paremeter in `StartCreateCertificate`, as an option in `ImportCertificateOptions`, and it can be retrieved from certificates of type `KeyVaultCertificateWithPolicy`

### Bugs Fixed

- Corrected a typo in the documentation for `CertificatePolicy.KeySize`, changing the RSA key length from "4092" to "4096".
- Removed an extra `/` when building the request Uri for `CertificateClient.ImportCertificate` and `CertificateClient.ImportCertificateAsync`.

### Other Changes

- The default service version is now "7.6-preview.2".

## 4.7.0 (2024-10-14)

### Features Added

- Support for Continuous Access Evaluation (CAE).

## 4.6.0 (2024-02-14)

Changes from both the last release and the last beta include:

### Features Added

- Added `CertificateProperties.X509ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `CertificateProperties.X509Thumbprint` has been hidden but is still available.

### Breaking Changes

- Renamed tags reported on `CertificateClient` activities to following OpenTelemetry attribute naming conventions:
  - `certificate` to `az.keyvault.certificate.name`
  - `version` to `az.keyvault.certificate.version`
  - `issuer` to `az.keyvault.certificate.issuer.name`

### Bugs Fixed

- When a Key Vault is moved to another tenant, the client is reauthenticated.

### Other Changes

- The default service version is now "7.5".
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 4.6.0-beta.2 (2023-11-13)

### Other Changes

- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 4.6.0-beta.1 (2023-11-09)

### Features Added

- Added `CertificateProperties.X509ThumbprintString` to return the hexadecimal string representation of the SHA-1 hash of the certificate.
  `CertificateProperties.X509Thumbprint` has been hidden but is still available.

### Breaking Changes

- Renamed tags reported on `CertificateClient` activities to following OpenTelemetry attribute naming conventions:
  - `certificate` to `az.keyvault.certificate.name`
  - `version` to `az.keyvault.certificate.version`
  - `issuer` to `az.keyvault.certificate.issuer.name`

### Bugs Fixed

- When a Key Vault is moved to another tenant, the client is reauthenticated.

### Other Changes

- The default service version is now "7.5-preview.1".

## 4.5.1 (2023-03-31)

### Bugs Fixed

- Correctly serialize `CertificateIssuer.OrganizationId` property ([#35245](https://github.com/Azure/azure-sdk-for-net/issues/35245))

## 4.5.0 (2023-03-14)

### Breaking Changes

- Service version "7.4-preview.1" is not supported.

### Other Changes

- The default service version is now "7.4".

## 4.5.0-beta.1 (2022-11-09)

### Bugs Fixed

- Fixed possible "ObjectIsBeingRecovered" error immediately after restoring certificates, keys, or secrets. ([#31581](https://github.com/Azure/azure-sdk-for-net/issues/31581))

### Other Changes

- The default service version is now "7.4-preview.1".

## 4.4.0 (2022-09-20)

### Breaking Changes

- Verify the challenge resource matches the vault domain.
  This should affect few customers who can set `CertificateClientOptions.DisableChallengeResourceVerification` to `true` to disable.
  See https://aka.ms/azsdk/blog/vault-uri for more information.

## 4.3.0 (2022-03-24)

Changes from both the last release and the last beta include:

### Features Added

- Added `KeyVaultCertificateIdentifier.TryCreate` to parse certificate URIs without throwing an exception when invalid. ([#23146](https://github.com/Azure/azure-sdk-for-net/issues/23146))
- Support multi-tenant authentication against Key Vault and Managed HSM when using Azure.Identity 1.5.0 or newer. ([#18359](https://github.com/Azure/azure-sdk-for-net/issues/18359))

### Bugs Fixed

- Added `DownloadCertificateOptions` to pass `X509KeyStorageFlags` appropriate for different host applications. ([#23016](https://github.com/Azure/azure-sdk-for-net/issues/23016))
- Added certificate version to distributed tracing. ([#12907](https://github.com/Azure/azure-sdk-for-net/issues/12907))

### Breaking Changes

- (Since 4.3.0-beta.4) To pass `X509KeyStorageFlags` you must now pass a single required `DownloadCertificateOptions` with a required `certificateName`.

### Other Changes

- The default service version is now "7.3".

## 4.3.0-beta.4 (2022-01-12)

### Other Changes

- Package metadata fixed

## 4.3.0-beta.3 (2022-01-11)

### Other Changes

- Bug fixes

## 4.3.0-beta.2 (2021-10-14)

### Features Added

- Added `KeyVaultCertificateIdentifier.TryCreate` to parse certificate URIs without throwing an exception when invalid. ([#23146](https://github.com/Azure/azure-sdk-for-net/issues/23146))
- Support multi-tenant authentication against Key Vault and Managed HSM when using Azure.Identity 1.5.0 or newer. ([#18359](https://github.com/Azure/azure-sdk-for-net/issues/18359))

### Bugs Fixed

- Added certificate version to distributed tracing. ([#12907](https://github.com/Azure/azure-sdk-for-net/issues/12907))
- Added `DownloadCertificateOptions` to pass `X509KeyStorageFlags` appropriate for different host applications. ([#23016](https://github.com/Azure/azure-sdk-for-net/issues/23016))

## 4.3.0-beta.1 (2021-08-10)

### Fixed

- The default service version is now "7.3-preview".

## 4.2.0 (2021-06-15)

### Features Added

- Changed default service version to "7.2".
- Added `KeyVaultCertificateIdentifier` to parse certificate URIs.
- Added `CertificateClient.DownloadCertificate` and `DownloadCertificateAsync` to download an `X509Certificate2` with private key.

## 4.2.0-beta.6 (2021-05-11)

### Changed

- Updated dependency versions

## 4.1.1 (2021-05-04)

### Changed

- Updated dependency versions

## 4.2.0-beta.5 (2021-03-09)

### Changed

- `DownloadCertificate` and `DownloadCertificateAsync` on `CertificateClient` now support PEM-encoded certificates and keys.

## 4.2.0-beta.4 (2021-02-10)

### Added

- Added default constructor to `CertificatePolicy` to use when importing a PEM-encoded certificate ([#16217](https://github.com/Azure/azure-sdk-for-net/issues/16217)).
- Added constructor to `KeyVaultCertificateIdentifier` to parse a `Uri`.
- Added support for PEM files on .NET Core for `CertificateClient.DownloadCertificate` and `CertificateClient.DownloadCertificateAsync` ([#16897](https://github.com/Azure/azure-sdk-for-net/issues/16897))

### Changed

- The default service version is now "7.2" (still in preview).

### Removed

- Removed `KeyVaultCertificateIdentifier.Parse` and `KeyVaultCertificateIdentifier.TryParse` in favor of the added constructor.

## 4.2.0-beta.3 (2020-11-12)

### Added

- Added `DownloadCertificate` and `DownloadCertificateAsync` methods to get `X509Certificate2` with private key if permitted ([#12083](https://github.com/Azure/azure-sdk-for-net/issues/12083))

### Changed

- Clarified in documentation that `LifetimeActions` requires a single value at this time.

## 4.2.0-beta.2 (2020-10-06)

- Bug fixes and performance improvements.

## 4.2.0-beta.1 (2020-09-08)

### Added

- Added `KeyVaultCertificateIdentifier` to parse certificate URIs.
- Added link to sample on `KeyVaultCertificate.Cer` to the private key.

## 4.1.0 (2020-08-11)

### Added

- Added `RecoverableDays` property to `CertificateProperties`.

### Changed

- Default service version is now 7.1.

## 4.0.3 (2020-07-09)

### Fixed

- Fixed an issue where the issuer name was always null ([#10908](https://github.com/Azure/azure-sdk-for-net/issues/10908))
- Fixed an issue where GetIssuerAsync would throw for issuers with contact information populated ([#10905](https://github.com/Azure/azure-sdk-for-net/issues/10905))
- Fixed an issue where some Certificate policy properties were not serialized properly ([#11669](https://github.com/azure/azure-sdk-for-net/issues/11669))

## 4.0.2 (2020-03-18)

### Fixed

- Fixed concurrency issue in our challenge-based authentication policy ([#9737](https://github.com/Azure/azure-sdk-for-net/issues/9737))

## 4.1.0-preview.1 (2020-03-09)

### Added

- Add `RecoverableDays` property to `CertificateProperties`.

## 4.0.1 (2020-03-03)

### Fixed

- Fixed issue that prevented certificate contacts from being created, enumerated, or deleted.
- Reset challenge cache so tests can be run individually and in any order. ([#9356](https://github.com/Azure/azure-sdk-for-net/issues/9356))
- Properly import PKCS12 or PEM-encoded certificate. ([#9963](https://github.com/Azure/azure-sdk-for-net/issues/9963))
- Serialize the `MergeCertificateOptions` in `CertificateClient.MergeCertificate`. ([#9986](https://github.com/Azure/azure-sdk-for-net/issues/9986))
- Shorten diagnostic scope names. ([#9651](https://github.com/Azure/azure-sdk-for-net/issues/9651))
- Include resource namespace in diagnostics scope. ([#9655](https://github.com/Azure/azure-sdk-for-net/issues/9655))
- Sanitize header values in exceptions. ([#9782](https://github.com/Azure/azure-sdk-for-net/issues/9782))

## 4.0.0 (2020-01-08)

### Minor changes

- Challenge-based authentication requests are only sent over HTTPS.

## 4.0.0-preview.8 (2019-12-20)

### Breaking changes

- `CertificateClient.CreateIssuer` and `CertificateClient.CreateIssuerAsync` now require a `CertificateIssuer` with both a name and provider.
- `CertificateContentType.Pem` now correctly returns "x-pem-file".
- A name is now required when creating a `CertificateIssuer`.
- `CertificateIssuer.Provider` is now read-only. Use the new overload constructor to set a required provider when creating an issuer.
- `CertificateIssuer.Properties` was redundant and has been removed.
- The `value` parameter of the `ImportCertificateOptions` constructor has been renamed to `certificate`.
- The `policy` parameter was removed from the `ImportCertificateOptions` constructor, and the `Policy` property is now read-write.
- The `LifetimeAction` constructor now requires a `CertificatePolicyAction` argument.
- `LifetimeAction.Action` is now read-only. Use the constructor to set the action.
- The `x509certificates` parameter of the `MergeCertificateOptions` constructor has been renamed to `x509Certificates`.

### Major changes

- A constructor was added to `CertificateOperation`. You can use this to construct a `CertificateOperation` to cancel or delete it without certificates/get permission.

## 4.0.0-preview.7 (2019-12-04)

### Breaking changes

- Moved `CertificateClient.CancelCertificationOperation` to `CertificateOperation.Cancel`.
- Moved `CertificateClient.DeleteCertificateOperation` to `CertificateOperation.Delete`.
- `CertificateClient.DeleteCertificate` has been renamed to `CertificateClient.StartDeleteCertificate` and now returns a `DeleteCertificateOperation` to track this long-running operation.
- `CertificateClient.RecoverDeletedCertificate` has been renamed to `CertificateClient.StartRecoverDeletedCertificate` and now returns a `RecoverDeletedCertificateOperation` to track this long-running operation.
- `subject` and `issuerName` constructor parameters have been switched on `CertificatePolicy`.
- `subjectAlternativeNames` and `issuerName` constructor parameters have been switched on `CertificatePolicy`.
- The `SubjectAlternativeNames` class has been rewritten to contain `DnsNames`, `Emails`, and `UserPrincipalNames` collection properties.
- `CertificateIssuer.Administrators` has been renamed to `CertificateIssuer.AdministratorContacts`.
- `CertificateKeyType.Oct` has been removed.
- `CertificateType` and `CertificateTransparency` were added to `CertificateOperationProperties`.
- `ImportCertificateOptions.Value` has been renamed to `ImportCertificateOptions.Certificate`.
- `KeyVaultCertificate.ContentType` has been removed.

### Major changes

- The `SubjectAlternativeNames` class now allows you to add multiple types of subject alternative names using any of the `DnsNames`, `Emails`, and `UserPrincipalNames` collection properties.
- A new `CertificatePolicy` constructor allows you to both pass in both the `subject` and `subjectAlternativeNames` parameters.
- `CertificateIssuer.Provider` was added.

## 4.0.0-preview.6 (2019-11-01)

### Breaking changes

- `Certificate` and `CertificateWithPolicy` have been renamed to `KeyVaultCertificate` and `KeyVaultCertificateWithPolicy` to avoid ambiguity with other libraries and to yield better search results.
- `AdministratorDetails` has been renamed to `AdministratorContact`.
- `Action` has been renamed to `CertificatePolicyAction` to avoid ambiguity with other libraries.
- `Contact` has been renamed to `CertificateContact` to avoid ambiguity with other libraries.
- `Error` has been renamed to `CertificateOperationError` to avoid ambiguity with other libraries.
- `Issuer` has been renamed to `CertificateIssuer` to avoid ambiguity with other libraries.
- `CertificateClientOptions.Default` has been removed. Use `CertificatePolicy.Default` instead.
- Starting a certificate creation operation with `CertificateClient` now requires a `CertificatePolicy`.
- On `DeletedCertificate`, `DeletedDate` has been renamed to `DeletedOn`.
- `Hsm` properties and `hsm` parameters have been renamed to `HardwareProtected` and `hardwareProtected` respectively.
- `Certificate.CER` has been renamed to `KeyVaultCertificate.Cer`.
- `CertificateClient.RestoreCertificate` has been renamed to `CertificateClient.RestoreCertificateBackup` to better associate it with `CertificateClient.BackupCertificate`.

### Major changes

- A new `CertificatePolicy.Default` property returns a new policy suitable for self-signed certificate requests.
- `CertificateClient.VaultUri` has been added with the original value pass to `CertificateClient`.
- `CertificateClient.GetDeletedCertificates` includes an optional `includePending` parameter to include certificates in a delete pending state.

## 4.0.0-preview.5 (2019-10-07)

### Breaking changes

- `CertificateBase` has been renamed to `CertificateProperties`.
- `Certificate` no longer extends `CertificateProperties`, but instead contains a `CertificateProperties` property named `Properties`.
- `IssuerBase` has been renamed to `IssuerProperties`.
- `Issuer` no longer extends `IssuerProperties`, but instead contains a `IssuerProperties` property named `Properties`.
- `CertificatePolicy` has been flattened to include all properties from `KeyOptions` and derivative classes.
- `KeyOptions` and derivative classes have been removed.
- `CertificateKeyType` members have been aligned with `Azure.Security.KeyVault.Keys.KeyType` members.
- `CertificateImport` has been renamed to `CertificateImportOptions`.
