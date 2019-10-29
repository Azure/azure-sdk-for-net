# Release History

## 4.0.0-preview.6 (2019-11)

### Major changes

- Updated to work with the 1.0.0 release versions of Azure.Core and Azure.Identity.

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
