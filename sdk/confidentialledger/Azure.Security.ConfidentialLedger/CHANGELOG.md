# Release History

## 1.0.0 (2022-08-09)

### Breaking Changes

- The `ConfidentialLedgerIdentityClient` was renamed to `ConfidentialLedgerCertificateClient` and was moved to the `Azure.Security.ConfidentialLedger.Certificate` namespace
- The automatic configuration to trust the service's TLS certificate in `ConfidentialLedgerClient` now checks that the final certificate in the server's certificate chain matches the trusted TLS certificate. Previously the client checked if the thumbprint of the trusted TLS certificate was present anywhere in the server's certificate chain.
- The `GetCollections` and `GetConsortiumMembers` methods on `ConfidentialLedgerClient` now return `Pageable<BinaryData>`


## 1.0.0-beta.3 (2022-07-07)

### Breaking Changes

- The `PostLedgerEntry` and `PostLedgerEntryAsync` methods on `ConfidentialLedgerClient` now return a long-running operation of type `PostLedgerEntryOperation`.

## 1.0.0-beta.2 (2021-06-08)

### Breaking Changes

- The namespace of the client has changed to Azure.Security.ConfidentialLedger

## 1.0.0-beta.1 (2021-05-11)
- Initial package
