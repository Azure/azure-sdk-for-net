# Release History

## 1.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

- Removed `ClientRequestId` tag reported on `MixedRealityStsClient` activities - it is reported on the underlying HTTP activities.

### Bugs Fixed

### Other Changes

## 1.2.0 (2022-09-09)

### Bugs Fixed

- Fixed an issue that prevented proper AAD authentication in regions other than East US 2 using the
  `mixedreality.azure.com` account domain.

## 1.1.0 (2022-07-28)

### Key Bug Fixes

- The `Azure.Core` dependency was updated to `1.25.0`.
- The `System.IdentityModel.Tokens.Jwt` dependency was updated to `6.5.0`.
- The `System.Text.Json` dependency was updated to `4.7.2`.

## 1.0.1 (2021-05-25)

### Key Bug Fixes

- Updated dependency versions.

## 1.0.0 (2021-02-23)

- First stable release.

## 1.0.0-beta.2 (2021-02-16)

- Automated update.

## 1.0.0-beta.1 (2021-02-10)

- Initial release.
