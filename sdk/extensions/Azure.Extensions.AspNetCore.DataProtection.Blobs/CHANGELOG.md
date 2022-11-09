# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.3 (2022-09-12)

### Other Changes

- Updated dependency version of `System.Security.Cryptography` to mitigate [CVE-2022-34716](https://github.com/advisories/GHSA-2m65-m22p-9wjw).

## 1.2.2 (2022-09-06)

### Other Changes

- Updating the `Azure.Storage.Blobs` package to 12.13.1 to mitigate warnings for [CVE-2022-30187](https://github.com/advisories/GHSA-64x4-9hc6-r2h6).  Note that no vulnerability exists, as the feature under advisement is not used by the `Azure.Extensions.AspNetCore.DataProtection.Blobs` package.

## 1.2.1 (2021-05-14)

### Changes

- Dependency versions updated.

#### Key Bug Fixes

- Fixed a bug where referencing an existing empty blob resulted in a failure.

## 1.2.0 (2020-12-16)

### Changes

#### Key Bug Fixes

- The `Azure.Storage.Blobs` dependency updated to 12.6.0 to avoid a breaking change in an early package version.

## 1.1.0 (2020-08-06)

- No major changes.

## 1.0.1 (2020-08-06)

### Fixed

- Transient error in key refresh (#12415).

## 1.0.0 (2020-06-04)

- No changes. General availability release.

## 1.0.0-preview.2 (2020-05-05)

- Package renamed to Azure.Extensions.AspNetCore.DataProtection.Blobs

## 1.0.0-preview.1 (2020-03-02)

- Initial preview of the Azure.AspNetCore.DataProtection.Blobs library
