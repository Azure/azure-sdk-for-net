# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.3 (2023-06-30)

### Features Added

- Added the new share resource capability that allows listing resources associated with sent and received shares.

### Breaking Changes

- Removed skipToken as a parameter from all client list calls
- Constructor for clients now takes in Uri object as oppose to a string parameter

## 1.0.0-beta.2 (2023-03-13)

### Other Changes

- Upgraded dependent `Azure.Core` to `1.30.0` due to an [issue in `ArrayBackedPropertyBag`](https://github.com/Azure/azure-sdk-for-net/pull/34800) in `Azure.Core` version `1.29.0`.

## 1.0.0-beta.1 (2023-03-06)

### New Features

- Initial release of the Purview Share client library for .NET
