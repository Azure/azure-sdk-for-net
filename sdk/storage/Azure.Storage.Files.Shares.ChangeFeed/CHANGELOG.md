# Release History

## 12.0.0-beta.1 (Unreleased)

### Features Added
- Initial release of Azure.Storage.Files.Shares.ChangeFeed.

### Breaking Changes
- `ShareChangeFeedClient.GetChanges(start, end)` and `GetChangesAsync(start, end)` now treat `end` as **inclusive**. Events whose `EventTime` equals `end` are returned. Previously the upper bound was exclusive.

### Bugs Fixed
- Fixed `GetChangesBetweenSnapshots` returning no events when the begin and end snapshot share a log-window timestamp (i.e., `MinLogWindowForNextSnapshot == MaxLogWindowForCurrentSnapshot`). The reader now treats the boundary segment as inclusive, matching the service's snapshot semantics.

### Other Changes
