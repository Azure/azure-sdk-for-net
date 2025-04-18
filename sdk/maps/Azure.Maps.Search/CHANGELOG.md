# Release History

## 2.0.0-beta.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 2.0.0-beta.5 (2025-04-16)

### Features Added

- Support Search API `2025-01-01`. Support `StreetName` and `StreetNumber` in `Address` class and remove unused types

### Bugs Fixed

- Fix the issue where `Iso` is always `null` in the `GetReverseGeocoding` response

## 2.0.0-beta.4 (2024-09-30)

### Bugs Fixed

- Fix the issue where `Iso` is always `null` in the `GetReverseGeocoding` response

## 2.0.0-beta.3 (2024-09-23)

### Breaking Changes

- Hide unnecessary GeoJson interfaces and replace with `Azure.Core.GeoJson` types

### Other Changes

- Refine test samples

## 2.0.0-beta.2 (2024-08-13)

### Bugs Fixed

- Fix NPE issue during client creation

## 2.0.0-beta.1 (2024-08-06)

### Features Added

- Support Search API `2023-06-01`

## 1.0.0-beta.5 (2024-05-07)

### Bugs Fixed

- Making the properties nullable as they are not required in the REST API response for search address.
- Correct spelling of the Neighborhood property.


## 1.0.0-beta.4 (2023-07-13)

### Features Added

- Support SAS authentication

## 1.0.0-beta.3 (2022-11-08)

### Bugs Fixed

- Add setter for `FuzzySearchOptions.IndexFilter` Property

## 1.0.0-beta.2 (2022-10-11)

### Features Added

- Add `SearchLanguage`

### Breaking Changes

- Use new LRO pattern
- Update some method name

### Bugs Fixed

- Use nullable for some optional arguments

### Other Changes

- Add more samples in README
- Remove net6.0 API view
- Remove unused files
- Fix typos

## 1.0.0-beta.1 (2022-09-06)

### Features Added

- Initial release.
