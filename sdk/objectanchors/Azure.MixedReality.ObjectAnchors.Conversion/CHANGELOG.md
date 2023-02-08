# Release History

## 0.3.0-beta.7 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 0.3.0-beta.6 (2022-11-03)

### Bugs Fixed

- The `AccountDomain` property on the `ObjectAnchorsConversionClient` is not properly set to the value passed into the
  constructor.

### Features Added

- As of API version `0.3-preview.2`, we have begun detecting and using asset scale units embedded in FBX files for asset
  conversion. The detected scale unit will be used by default. To disable this behavior, you can set the new
  `DisableDetectScaleUnits` option in `AssetConversionOptions` to `true`. The `DisableDetectScaleUnits` option is
  ignored in previous API versions.

## 0.3.0-beta.5 (2022-09-12)

### Other Changes

- Updated `Azure.MixedReality.Authentication` to `1.2.0`.

## 0.3.0-beta.4 (2022-07-29)

### Breaking Changes

- `ServiceVersion` enum values are now pascal case.

## 0.3.0-beta.3 (2022-05-11)

### Bugs Fixed

- Fixed a regression from `0.2.0-beta.1` to validate file extensions case insensitively.

### Features Added

- Added `ScaledAssetDimensions` to `AssetConversionProperties`.

### Breaking Changes

- `OutputModelUri` now returns a `Uri` to a `.zip` file containing the `.ou` file instead of the `.ou` file itself when using the new default service version: `V0_3_preview_0`.
- The value specified when creating an `AssetFileType` is now validated and must begin with a '.' character.

## 0.3.0-beta.2 (2022-03-08)

### Bugs Fixed

- Removed support for the `gltf` file format in the SDK as it is not supported by the service.

## 0.3.0-beta.1 (2021-07-14)

- Added exception for unsupported asset file formats

## 0.2.0-beta.1 (2021-05-11)

- Added error codes to AssetConversionProperties

## 0.1.0-beta.1 (2021-02-26)

- Initial client
