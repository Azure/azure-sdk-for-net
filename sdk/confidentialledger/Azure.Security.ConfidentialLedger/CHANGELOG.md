# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

- Custom client `options` used when instantiating a `ConfidentialLedgerClient` are no longer also passed to the `ConfidentialLedgerIdentityServiceClient` instance used during construction of the `ConfidentialLedgerClient`, as these two clients have different requirements, in particular on certificate validation. 

### Other Changes

- The `CertValidationCheck` callback for `ConfidentialLedgerClient` instances now checks the final certificate in the server's certificate chain matches the trusted TLS certificate. Previously this callback checked if the thumbprint of the trusted TLS certificate was present anywhere in the server's certificate chain. 

## 1.0.0-beta.3 (2022-07-07)

### Breaking Changes

- The `PostLedgerEntry` and `PostLedgerEntryAsync` methods on `ConfidentialLedgerClient` now return a long-running operation of type `PostLedgerEntryOperation`.

## 1.0.0-beta.2 (2021-06-08)

### Breaking Changes

- The namespace of the client has changed to Azure.Security.ConfidentialLedger

## 1.0.0-beta.1 (2021-05-11)
- Initial package
