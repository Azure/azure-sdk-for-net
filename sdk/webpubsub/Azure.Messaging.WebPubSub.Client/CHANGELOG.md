# Release History

## 1.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0 (2023-12-01)
### Breaking Changes
- Change type of `AckId` and `SequenceId` from `ulong` to `long`
- Update `SendMessageFailedException`. Remove `AckMessageError` and add `Code` property

## 1.0.0-beta.2 (2023-02-06)
### Bugs Fixed
- Fix AutoRejoinGroups doesn't work issue

### Other Changes
- Make WebPubSubClientCredential.GetClientAccessUriAsync() virtual for extendable

## 1.0.0-beta.1 (2023-01-13)
### Features Added
- Initial beta release
