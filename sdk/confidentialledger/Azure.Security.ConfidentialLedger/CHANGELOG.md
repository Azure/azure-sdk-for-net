# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added
- Added support to route to failover ledgers for the `GetLedgerEntry`, `GetLedgerEntryAsync`, `GetCurrentLedgerEntry`, and `GetCurrentLedgerEntryAsync` methods.
- The client now treats a `GetLedgerEntry`/`GetLedgerEntryAsync` response that is still in the `Loading` state as transient and automatically polls until the entry is committed, bounded by the client's configured retry settings (`ClientOptions.Retry.MaxRetries` attempts with `ClientOptions.Retry.Delay` between attempts). Callers no longer need to write a manual polling loop.
- Added `ConfidentialLedgerClientOptions.EnableArchivedCollectionFallback`. When enabled, `GetCurrentLedgerEntry` and `GetCurrentLedgerEntryAsync` transparently fall back to a historical query for a collection whose latest entry has been archived (pruned) by the service, returning the most recent committed entry instead of failing with `404 Not Found`. Defaults to `false` so callers must explicitly opt in.

### Bugs Fixed
- `PostLedgerEntryOperation` now treats transient `406 NotAcceptable` responses from the status endpoint as `Pending` (instead of failing) and tolerates up to 3 consecutive `404 NotFound` responses while a transaction is being replicated across nodes, preventing spurious `RequestFailedException`s during normal commit propagation.

## 1.4.1-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.1-beta.2 (2025-04-23)

### Features Added
- Added user defined functions feature.
- Added tags parameter for CreateLedgerEntry endpoint.

## 1.4.1-beta.1 (2025-01-27)

### Features Added
- Added the ability to list users and roles.

## 1.3.0 (2023-12-05)

### Features Added

- Added `VerifyConnection` property to `ConfidentialLedgerClientOptions` to allow the option to have a client connection without validating the service certificate.

## 1.2.0 (2023-09-12)

### Bugs Fixed

- Service calls that result in a `HttpStatusCode.NotFound` status will now be retried by default. This is to handle scenarios where there is an unexpected loss of session stickiness when the connected node changes and transactions have not been fully replicated.

## 1.2.0-beta.1 (2022-11-09)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.1.0 (2022-11-08)

### Features Added

- Added the `CertificateEndpoint` property to `ConfidentialLedgerClientOptions` to allow configuration of a custom certificate endpoint. When not configured, the current default is used.

## 1.1.0-beta.1 (2022-08-10)

### Features Added

- Added the `CertificateEndpoint` property to `ConfidentialLedgerClientOptions` to allow configuration of a custom certificate endpoint. When not configured, the current default is used.

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
