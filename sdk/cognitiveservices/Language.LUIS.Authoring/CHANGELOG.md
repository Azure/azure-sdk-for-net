# Release History

## 3.2.0-preview.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 3.2.0-preview.5 (2022-10-05)
### Bugs Fixed
- Id attribute in labelled utterances stored as int could overflow
- ExampleId attribute description typo

## 3.2.0-preview.4 (2021-02-25)
### Fixed
- ExampleId attribute in label APIs could not hold int values
- ArmTokenParameter parameter name had a typo

## 3.2.0-preview.3 (2020-06-01)
### Added
- Enable nesting of children in luis models
- Flag to indicate if a feature is required
### Removed
- Deprecated permissions API

## 3.2.0-preview.2 (2020-04-29)
### Added
- Adding Luis App import and export in .lu format
- Adding Luis App import v2 app that enables to import an app that has entities with children of type "String"

### Fixed
- Issue where AzureAccount Api are not able to be authenticated ([#8023](https://github.com/Azure/azure-sdk-for-net/issues/8023))

## 3.2.0-preview.1 (2019-10-30)


