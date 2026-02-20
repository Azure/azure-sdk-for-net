# Release History

## 1.0.0-beta.8 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
