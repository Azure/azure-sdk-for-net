# Release History

## 2.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 2.0.0-beta.3 (2026-08-17)

### Breaking Changes

- Changed `ConfidentialLedgerClientOptions.EnableArchivedCollectionFallback` to default to `false`. Callers that require `GetCurrentLedgerEntry` and `GetCurrentLedgerEntryAsync` to search ledger history after a collection-specific 404 must now explicitly opt in by setting the option to `true`.

## 2.0.0-beta.2 (2026-08-13)

### Features Added
- Added support to route retryable HTTP responses and retryable transport failures to failover ledgers for `GetLedgerEntry`, `GetLedgerEntryAsync`, `GetCurrentLedgerEntry`, and `GetCurrentLedgerEntryAsync`. No other reads or writes fail over. The primary and every failover endpoint receive independent normal retry budgets; caller cancellation never initiates failover, and the original primary failure is preserved if discovery or all failovers fail.
- Added `ConfidentialLedgerClientOptions.Failover` to control the order in which failover endpoints are attempted: `Ordered` (default, preserves the order reported by the identity service) or `Random` (shuffles the candidates to spread load across failover ledgers).
- Added `ConfidentialLedgerClientOptions.FailoverNetworkTimeout`. When set, this network timeout applies independently to requests against each failover endpoint. When unset, the configured retry network timeout applies.
- The client now treats a `GetLedgerEntry`/`GetLedgerEntryAsync` response that is still in the `Loading` state as transient and automatically polls until the entry is committed, bounded by the client's configured retry settings (`ClientOptions.Retry.MaxRetries` attempts with `ClientOptions.Retry.Delay` between attempts). Callers no longer need to write a manual polling loop.
- Added `ConfidentialLedgerClientOptions.EnableArchivedCollectionFallback`. It defaults to `true`, so `GetCurrentLedgerEntry` and `GetCurrentLedgerEntryAsync` transparently fall back to a historical query for a collection whose latest entry has been archived (pruned), without additional caller logic or configuration. Set it to `false` to retain the legacy `404 Not Found` behavior.

- Added strongly typed convenience overloads for service operations. The existing protocol methods remain available for advanced scenarios.
- Added experimental configuration and host-builder integration through `ConfidentialLedgerClientSettings` and `ConfidentialLedgerClientHostExtensions`.

### Breaking Changes

- Renamed and moved `Azure.Security.ConfidentialLedger.Models.SecurityConfidentialLedgerModelFactory` to `Azure.Security.ConfidentialLedger.ConfidentialLedgerModelFactory`.

### Bugs Fixed
- Failover requests are now validated by endpoint-specific transports against that ledger's own identity TLS certificate, fetched from the independently validated Identity Service. A certificate trusted for one ledger cannot authenticate another ledger. Custom transports remain supported.
- `PostLedgerEntryOperation` now treats transient `406 NotAcceptable` responses from the status endpoint as `Pending` and tolerates exactly 3 consecutive `404 NotFound` HTTP responses while a transaction is replicated. The operation-specific 404 tolerance no longer multiplies with pipeline retries; normal 404 retry behavior remains unchanged for other operations.
- Archived-collection fallback responses now preserve the complete historical ledger entry payload, including optional tags.

## 2.0.0-beta.1 (2026-08-05)

### Features Added

- Added support for stable API version 2026-02-23.
- Added opt-in support for the Azure Confidential Ledger Gateway via `ConfidentialLedgerClientOptions.UseLedgerGateway`. When enabled:
  - The SDK skips the per-ledger CCF identity-service TLS bootstrap. The gateway uses publicly-rooted certificates, so the OS trust store is sufficient.
  - `ConfidentialLedgerClient.PostLedgerEntry` accepts an HTTP 202 response and returns an operation whose `Id` is the gateway-assigned `operationId` (read from the `x-ms-webfe-operation-id` response header, with a fallback to the response body). The operation transparently polls `GET /app/operations/{operationId}` and surfaces the underlying CCF transaction once committed.
  - Client-certificate (mTLS) authentication is rejected at construction time — only `TokenCredential` is supported by the gateway.
  - Primary-node redirect caching (added in 1.4.1-beta.5) is automatically disabled, since the gateway brokers node routing on the server side.
- Added `ConfidentialLedgerClient.GetOperationStatus` / `GetOperationStatusAsync` for direct polling of the gateway operation queue.
- Added `ConfidentialLedgerClient.RehydratePostLedgerEntryOperation(string operationId)` for resuming a previously-started write submission across process restarts (no I/O is performed until polling begins). Operation IDs remain valid on the server for the gateway's operation-record retention period.

### Bugs Fixed

- `PostLedgerEntryOperation.GetRawResponse()` now returns the initial submit response before the first poll. Previously, callers using `WaitUntil.Started` who inspected response headers (for example `x-ms-ccf-transaction-id` or `x-ms-webfe-operation-id`) on the returned operation observed a `NullReferenceException`.

### Other Changes

- Renamed several generated model and enum types in the .NET client to follow Azure SDK for .NET naming guidelines (C# only; the REST contract and other language SDKs are unchanged): `Bundle` → `LedgerBundle`, `Constitution` → `LedgerConstitution`, `Metadata` → `LedgerEndpointMetadata`, `Mode` → `LedgerEndpointMode`, `Role` → `LedgerRole`, `Collection` → `LedgerCollectionInfo`, and `UserDefinedFunctionExecutionResponse` → `UserDefinedFunctionExecution`.

## 1.4.1-beta.5 (2026-05-26)

### Bugs Fixed

- Improved redirect performance for write operations by caching the latest primary node URL from redirect responses and reusing it for subsequent non-GET requests. The cache is lazily populated and refreshed whenever the service redirects to a different primary node.
- Hardened redirect handling so credential-preserving redirects are only followed when the target remains within the configured ledger endpoint's trust boundary.

## 1.4.1-beta.4 (2026-02-27)

### Bugs Fixed

- Fixed `VerifyConnection` in `ConfidentialLedgerClientOptions` defaulting to `false`, which caused TLS certificate verification to be skipped unless explicitly enabled. It now defaults to `true`.

## 1.4.1-beta.3 (2026-02-17)

### Features Added

- Added `ConfidentialLedgerRedirectPolicy` to automatically follow HTTP 307/308 redirects while preserving the Authorization header. Previously, the SDK did not follow redirects by default, and even when redirects were enabled, the Authorization header was stripped on cross-domain redirects between ACL nodes, causing write operations to fail when routed to non-primary nodes.

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
