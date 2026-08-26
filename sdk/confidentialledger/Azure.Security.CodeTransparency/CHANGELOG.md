# Release History

## 1.0.0-beta.13 (Unreleased)

### Features Added

- Added `CcfReceiptVerifier.VerifyTransparentStatementReceipt(ECDsa publicKey, string keyId, byte[] receiptBytes, byte[] signedStatementBytes)`.
  This overload lets callers supply a key they already own as a standard `System.Security.Cryptography.ECDsa`
  instance, instead of having to obtain an `Azure.Security.CodeTransparency.JsonWebKey`, which has no public
  constructor and therefore could only be acquired from a service response.

### Breaking Changes

- `CborUtils` is no longer public. It carried no service semantics and only existed on the public
  surface so that the documented sample could dig the entry id out of the raw CBOR response body.
  Use `CodeTransparencyClient.GetEntryIdFromLocation(Response)` instead, which is the supported way
  to read the entry id from a submission response.

### Bugs Fixed

- Fixed receipt verification for P-521 keys. The curve was matched against the non-existent name
  `P-512` and validated against COSE algorithm `-39` (PS512, an RSA algorithm) rather than `-36`
  (ES512), so every P-521 key was rejected with an "unsupported curve" error.
- CBOR parsing no longer throws on malformed input. `CborUtils.GetStringValueFromCborMapByKey` is
  documented to return an empty string when a value cannot be read, but a payload whose root was not
  a CBOR map threw `InvalidOperationException` and a truncated map threw `CborContentException`. This
  surfaced as an unhandled exception out of entry-creation polling when the service returned a body
  that was not a CBOR map.

### Other Changes

- Removed the dependency on `Azure.Security.KeyVault.Keys`. The whole Key Vault Keys client library was
  being referenced solely to reuse its JSON Web Key to `ECDsa` conversion inside a single method body;
  that conversion is now done directly against `System.Security.Cryptography`.

## 1.0.0-beta.12 (2026-07-31)

### Bugs Fixed

- Fixed asynchronous registration and receipt retrieval against a still-pending transaction. When a
  write is routed to a backup node the service replies with a redirect whose `Location` (for example
  `/entries/{entryId}`) omits the `api-version`. `CodeTransparencyRedirectPolicy` now carries the
  originating request's `api-version` onto followed `303`/`307`/`308` redirect targets, so the
  subsequent read stays on the versioned API instead of falling back to the service's unversioned
  (legacy) behavior. On the versioned API a read of a not-yet-committed entry is answered with a
  `302 Found` whose `Location` points back at the same entry URL; the followed read now treats that
  `302` as retriable, and the client's default retry settings were raised (more, exponentially
  backed-off retries starting at 200 ms) so the pipeline polls until the committed receipt (`200`).
  All retry and delay values remain overridable through `CodeTransparencyClientOptions.Retry`.

## 1.0.0-beta.11 (2026-07-15)

### Bugs Fixed

- Hardened receipt verification to reject empty inclusion-proof collections.

## 1.0.0-beta.10 (2026-07-14)

### Features Added

- General availability release targeting REST API version `2026-03-26`
- Added a utility method `CcfReceipt.GetRegistrationTransactionId(byte[] receiptCoseSign1Bytes)` to extract the entry ID (registration transaction id) from a receipt

### Other Changes

- Removed namespace `Azure.Security.CodeTransparency.Receipt`, all classes have been moved to `Azure.Security.CodeTransparency`.
- Updated `CodeTransparencyRedirectPolicy` to also allow 303 redirects which is returned in the case of the entry create operation.

## 1.0.0-beta.9 (2026-05-26)

### Features Added

- Added `CodeTransparencyClientSettings` to support creating a `CodeTransparencyClient` from `IConfiguration`, including configuration-based credential resolution and dependency injection registration.

### Bugs Fixed

- Improved redirect performance for write operations by caching the latest primary node URL from redirect responses and reusing it for subsequent non-GET requests. The cache is lazily populated and refreshed whenever the service redirects to a different primary node.

### Other Changes

- Hardened redirect handling in the Code Transparency client. Credentials and request bodies are now only forwarded on HTTPS redirects whose target hostname matches the configured service endpoint or one of its subdomains, with the same port. Redirects to any other target are refused. Write-URL cache writes are now staged per-call and only committed after a successful trusted redirect chain.

## 1.0.0-beta.8 (2026-03-02)

### Bugs Fixed

- Fixes thread unsafe code in `VerifyTransparentStatement`. The code reused sha256 instances across multiple threads, which caused exceptions to be thrown when multiple threads were verifying statements at the same time. The fix was to create new sha256 instances for each verification operation instead of reusing them.

## 1.0.0-beta.7 (2026-02-17)

### Features Added

- Added `CodeTransparencyRedirectPolicy` to automatically follow HTTP 307/308 redirects while preserving the Authorization header. Previously, redirects between Confidential Ledger nodes could return HTTP 307/308 responses that were not automatically followed by the default pipeline, causing these requests to fail unless clients implemented redirect handling themselves.

## 1.0.0-beta.6 (2025-12-17)

### Features Added

- A new option to pass transparent statement verification key sets mapped to domain names for offline verification using `CodeTransparencyVerificationOptions.OfflineKeys`
- A new option to restrict the use of a network resolution of the ledger keys when using `OfflineKeys` with `CodeTransparencyVerificationOptions.OfflineKeysBehavior`

## 1.0.0-beta.5 (2025-10-20)

### Features Added

- Exposed `CborUtils` to extract values from CBOR maps, which would otherwise require working directly with a CBOR library
- Added new static verification method `CodeTransparencyClient.VerifyTransparentStatement` which accepts `CodeTransparencyVerificationOptions`, this allows verifying receipts from specific issuers 

### Other Changes

- Updated samples
- Fixed grammar in README files

## 1.0.0-beta.4 (2025-05-06)

### Other Changes

- Added `virtual` keyword to method `CodeTransparencyClient.RunTransparentStatementVerification`

## 1.0.0-beta.3 (2025-03-31)

### Features Added

- Aligned with the latest changes (Feb 25) of the IETF draft: https://datatracker.ietf.org/doc/draft-ietf-scitt-architecture/
- Updated receipt verification logic.
- Exposed `JsonModelWriteCore` for model serialization procedure.

## 1.0.0-beta.2 (2024-03-27)

### Bugs Fixed

- Do not fail the submission of the entry if it responds with HTTP status 202

## 1.0.0-beta.1 (2024-03-26)

Initial release of the client.
