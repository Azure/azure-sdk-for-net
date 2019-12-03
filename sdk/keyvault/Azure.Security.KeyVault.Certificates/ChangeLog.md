# Release History

## 4.0.0-preview.7

### Breaking changes

- Moved `CertificateClient.CancelCertificationOperation` to `CertificateOperation.Cancel`.
- Moved `CertificateClient.DeleteCertificateOperation` to `CertificateOperation.Delete`.
- `CertificateClient.DeleteCertificate` has been renamed to `CertificateClient.StartDeleteCertificate` and now returns a `DeleteCertificateOperation` to track this long-running operation.
- `CertificateClient.RecoverDeletedCertificate` has been renamed to `CertificateClient.StartRecoverDeletedCertificate` and now returns a `RecoverDeletedCertificateOperation` to track this long-running operation.
- `subject` and `issuerName` constructor parameters have been switched on `CertificatePolicy`.
- `subjectAlternativeNames` and `issuerName` constructor parameters have been switched on `CertificatePolicy`.
- The `SubjectAlternativeNames` class has been rewritten to contain `DnsNames`, `Emails`, and `UserPrincipalNames` collection properties.
- `CertificateIssuer.Administrators` has been renamed to `CertificateIssuer.AdministratorContacts`.

### Major changes

- The `SubjectAlternativeNames` class now allows you to add multiple types of subject alternative names using any of the `DnsNames`, `Emails`, and `UserPrincipalNames` collection properties.
- A new `CertificatePolicy` constructor allows you to both pass in both the `subject` and `subjectAlternativeNames` parameters.

## 4.0.0-preview.6 (2019-11)

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
