# Release History

## 12.0.0-beta.1 (Unreleased)

### Features Added
- Initial release of Azure.Storage.Files.Shares.ChangeFeed.
- Added `ShareChangeFeedResetPolicy` and `ShareChangeFeedClientOptions.ResetPolicy` to control how the SDK reacts when a change feed reset marker is discovered during enumeration. Batched APIs (`GetChanges(start, end)` and `GetChangesBetweenSnapshots(begin, end)`, including their continuation-token and async counterparts) default to `ThrowOnReset`; streaming APIs (`GetChanges()` and `GetChanges(continuationToken)` plus async counterparts) default to `ContinueOnReset`.
- Added `ShareChangeFeedResetEvent` (a specialized `ShareChangeFeedEvent` with `ResetId`, `ResetFileTime`, `AccountName`, `ContainerName`, and `ResetReason` properties) and the `ShareChangeFeedReasonType.Reset` well-known value for surfacing reset markers in-band on `Pageable<ShareChangeFeedEvent>` enumerations.
- Added `ShareChangeFeedResetException` with a `ResetEvent` property so callers configured with `ShareChangeFeedResetPolicy.ThrowOnReset` can inspect the reset metadata (id, time, account, share, reason) and drive recovery.
- Added `ShareChangeFeedModelFactory.ShareChangeFeedResetEvent(...)` for mocking reset events in tests.

### Breaking Changes

### Bugs Fixed

### Other Changes
