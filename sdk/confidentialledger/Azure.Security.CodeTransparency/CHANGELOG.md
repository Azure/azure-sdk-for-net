# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

- New constructor allows to extract the endpoint from the receipt as verifier would not know it
- Exposed CborUtils to easily extract the values from cbor maps which would otherwise require working with the cbor library

### Other Changes

- Updated samples
- Fixed grammar in readmes

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
