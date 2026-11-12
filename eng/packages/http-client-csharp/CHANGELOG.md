# Release History

## 1.0.0 (Unreleased)

### Features Added

- Consume TCGC `0.74.0` LRO metadata. `@lroStatusMetadata` generates typed access to the latest monitor values, using wire-aware `propertySegments`, including inherited properties and failure diagnostics.
- `@lroOperationId` generates server-issued operation ID access from selected polling URI parameters or monitor-body properties, with URI fallback and continuation-token rehydration. Polling retains the complete URL.

### Breaking Changes

### Bugs Fixed

### Other Changes
