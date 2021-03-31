# Release History

## 1.0.0-beta.2 (2021-04-15)

- Fixed bug #19708, handle JSON values that are not just simple integers.
- Fixed bug #18183, Significant cleanup of README.md.

### Breaking Changes:
It is no longer necessary to manually Base64Url encode the AttestationPolicy property in the StoredAttestationPolicy model. 
This simplifies the user experience for interacting with the saved attestation policies - developers can treat attestation policies as string values.

## 1.0.0-beta.1 (2021-01-15)
Released as beta, not alpha.

## 1.0.0-alpha.1 (2020-12-08)

Created.

