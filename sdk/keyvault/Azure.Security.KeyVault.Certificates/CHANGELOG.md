# 4.0.0
Refactored several classes based on feedback, including:
* CertificateBase is now CertificateProperties.
* Certificate contains a Properties property of type CertificateProperties.
* IssuerBase is now IssuerProperties.
* Issuer contains a Properties property of type IssuerProperties.

See https://github.com/Azure/azure-sdk-for-net/tree/Azure.Security.KeyVault.Certificates_4.0.0-preview.5/sdk/keyvault/Azure.Security.KeyVault.Certificates/ChangeLog.md for more details.

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
