# Release History

## 1.0.0-preview.9 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-preview.8 (2021-10-05)

### Features Added
- Enhance Long Running Operation (LRO) logic for `SparkBatchClient` to support both scenarios of job submission and job execution.
- Update `LivyState` to be an extensible enum.


## 1.0.0-preview.7 (2021-08-10)

### Changed
- Updated to use service API version `2020-12-01`

## 1.0.0-preview.6 (2021-05-11)
### Key Bug Fixes
- Updated dependency versions.

## 1.0.0-preview.5 (2021-02-11)
### Changed
- Fix StartCreateSparkStatement API visibility

## 1.0.0-preview.4 (2021-02-10)

### Changed
- Changed APIs on `SparkBatchClient` and `SparkSessionClient` to provide a Long Running Operation (LRO) when operations can be long in duration.
- Renamed `Msg` to `Message` on `SparkStatementCancellationResult`.
- Renamed `DotNetSpark` to `Dotnetspark` and `PySpark` to `Pyspark` on `SparkStatementCollection`.

### Added
- Improved samples and documentation

## 1.0.0-preview.2 (2020-09-01)
- This release contains bug fixes to improve quality.

## 1.0.0-preview.1 (2020-06-10)
- Initial release
