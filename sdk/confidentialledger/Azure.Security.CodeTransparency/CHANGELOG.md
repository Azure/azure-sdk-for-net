# Release History

## 1.0.0-beta.5 (2025-10-07)

### Features Added

- New constructor allows extracting the endpoint from the receipt in the transparent statement when the verifier does not know it
- Exposed `CborUtils` to extract values from CBOR maps, which would otherwise require working directly with a CBOR library

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
