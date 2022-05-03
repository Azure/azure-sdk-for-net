# Release History

## 0.3.0-beta.3 (Unreleased)

### Bugs Fixed

- Fixed a regression from `0.2.0-beta.1` to validate file extensions case insensitively.
- We now properly set the `AccountDomain` property when creating an `ObjectAnchorsConversionClient`.
- Better handling of `null` values in many parts of the code.

### Features Added

- Added `ScaledAssetDimensions` to `AssetConversionProperties`.
- Enabled the nullable context to surface nullable reference information.

### Breaking Changes

- `OutputModelUri` now returns a `Uri` to a `.zip` file containing the `.ou` file instead of the `.ou` file itself when
  using the new default service version: `V0_3_preview_0`.
- Simplified the `ObjectAnchorsConversionClient` constructors and removed the `SupportedAssetFileTypes` property as it
  shouldn't have been exposed.
- The value specified when creating a `AssetFileType` is now validated and must begin with a '.' character.

### Bugs Fixed

### Other Changes

## 0.3.0-beta.2 (2022-03-08)

### Bugs Fixed

- Removed support for the `gltf` file format in the SDK as it is not supported by the service.

## 0.3.0-beta.1 (2021-07-14)

- Added exception for unsupported asset file formats

## 0.2.0-beta.1 (2021-05-11)

- Added error codes to AssetConversionProperties

## 0.1.0-beta.1 (2021-02-26)

- Initial client
