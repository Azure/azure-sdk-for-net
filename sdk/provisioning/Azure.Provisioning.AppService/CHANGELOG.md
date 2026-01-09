# Release History

## 1.4.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.3.1 (2026-01-06)

### Bugs Fixed

- Fixed the `Name` property of `SlotConfigNames` to include a default value of `slotConfigNames`. ([#54675](https://github.com/Azure/azure-sdk-for-net/issues/54675))

## 1.3.0 (2025-12-10)

### Other Changes

- Bump dependent package `Azure.Provisioning` to 1.4.0

## 1.3.0-beta.1 (2025-11-07)

### Features Added

- Bump api-version to latest.

### Breaking Changes

- Deprecated models `AseV3NetworkingConfigurationData`, `CustomDnsSuffixConfigurationData` and `StaticSiteUserProvidedFunctionAppData`. Please use `AseV3NetworkingConfiguration`, `CustomDnsSuffixConfiguration` and `StaticSiteUserProvidedFunctionApp` instead.
- Deprecated properties `AppServiceEnvironment.CustomDnsSuffixConfiguration`, `AppServiceEnvironment.NetworkingConfiguration` and `StaticSite.UserProvidedFunctionApps`. Please use `AppServiceEnvironment.CustomDnsSuffixConfig`, `AppServiceEnvironment.NetworkingConfig` and `StaticSite.UserFunctionApps` instead.

### Bugs Fixed

- Property `Name` of `WebSiteSlot` is now settable. (#53508)

## 1.2.0 (2025-06-26)

### Features Added

- Bump api-version to latest.
- Added `SiteAuthSettingsV2` resource and its related models.

## 1.1.1 (2025-06-25)

### Bugs Fixed

- Hide some properties that are incorrectly generated in previous versions.

## 1.1.0 (2025-06-16)

### Features Added

- Updated to use latest API version.

## 1.0.0 (2024-10-25)

### Features Added

- The new Azure.Provisioning experience.

## 1.0.0-beta.1 (2024-10-04)

### Features Added

- Preview of the new Azure.Provisioning experience.
