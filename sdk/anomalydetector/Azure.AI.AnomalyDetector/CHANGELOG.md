# Release History

## 3.0.0-preview.8 (Unreleased)

### Features Added

- Introduced model factory `Azure.AI.AnomalyDetector.AnomalyDetectorModelFactory` for mocking.
- Exposed `JsonModelWriteCore` for model serialization procedure.

### Breaking Changes

### Bugs Fixed

### Other Changes

## 3.0.0-preview.7 (2023-05-08)

### New Features

- Updated the code examples for protocol methods to ensure they can always compile
- Added code examples for convenience methods
- Added documentation on what protocol methods are on how they should be used

### Breaking Changes

- Removed the `Value` suffix from convenience methods such as `GetMultivariateBatchDetectionResultValue` is now simply an overload of `GetMultivariateBatchDetectionResult`

## 3.0.0-preview.6 (2022-12-08)
**Features**
- Added `OneTable` and `MultiTable` two data schemas.
- Added Azure Managed Identity data reader access for Azure Blob Storage.
- Added `topContributorCount` in the request body for `DetectMultivariateBatchAnomaly` and `DetectMultivariateLastAnomaly`.

**Breaking Changes**
- Renamed `Model` to `AnomalyDetectionModel`.
- Renamed `DetectionRequest` to `MultivariateBatchDetectionOptions`.
- Renamed `DetectionResult` to `MultivariateDetectionResult`.
- Renamed `DetectionStatus` to `MultivariateBatchDetectionStatus`.
- Renamed `DetectionResultSummary` to `MultivariateBatchDetectionResultSummary`.
- Renamed `FillNaMethod` to `FillNAMethod`.
- Renamed `LastDetectionRequest` to `MultivariateLastDetectionOptions`.
- Renamed `LastDetectionResult` to `MultivariateLastDetectionResult`.
- Replaced `ModelSnapshot` with `AnomalyDetectionModel` in `listMultivariateModel`.
- Renamed `listMultivariateModel` to `GetMultivariateModelValues`.
- Renamed `DetectAnomaly` to `DetectMultivariateBatchAnomaly`
- Renamed `GetDetectionResult` to `GetMultivariateBatchDetectionResultValue`.
- Renamed `GetMultivariateModel`to `GetMultivariateModelValue`
- Renamed `LastDetectAnomaly` to `DetectMultivariateLastAnomaly`.
- Renamed `DetectRequest` to `UnivariateDetectionOptions`.
- Renamed `EntireDetectResponse` to `UnivariateEntireDetectionResult`.
- Renamed `LastDetectResponse` to `UnivariateLastDetectionResult`.
- Renamed `ChangePointDetectRequest` to `UnivariateChangePointDetectionOptions`.
- Renamed `ChangePointDetectResponse` to `UnivariateChangePointDetectionResult`.
- Renamed `DetectEntireSeries` to `DetectUnivariateEntireSeries`.
- Renamed `DetectLastPoint` to `DetectUnivariateLastPoint`.
- Renamed `DetectChangePoint` to `DetectUnivariateChangePoint`.
- Renamed `ApiVersion` to `ServiceVersion` in `AnomalyDetectorClientOptions`
- Removed `ExportModel`.
- Removed `AnomalyDetectorModelFactory`
- Added `DataSchema` to `ModelInfo`

## 3.0.0-preview.5 (2022-01-23)

- Fix release issues

## 3.0.0-preview.4 (2022-01-18)

- Added operation `AnomalyDetectorClient.LastDetectAnomaly`
- Added 2 optional properties `ImputeMode` and `ImputeFixedValue` to `DetectRequest`.
- Added 1 optional property `Severity` to `EntireDetectResponse` and `LastDetectResponse`.
- Removed the optional property `Errors` of `VariableState`.
- Refactored the optional properties `Contributors` to `Interpretation` of `AnomalyValue`.
- Removed `AnomalyContributor`.
- Removed `AnomalyDetectorExportModelHeaders`.
- Refactored `FillNAMethod` to an extensible enum.

## 3.0.0-preview.3 (2021-04-15)

### Breaking Changes

-  Now `TimeSeriesPoint.Timestamp` property is nullable
- `TimeSeriesPoint(System.DateTimeOffset timestamp, float value)` constructor now takes only float type parameter.

## New Features

- Added operation `AnomalyDetectorClient.ListMultivariateModelAsync` and `AnomalyDetectorClient.ListMultivariateModel`
- Added operation `AnomalyDetectorClient.TrainMultivariateModelAsync` and `AnomalyDetectorClient.TrainMultivariateModel`
- Added operation `AnomalyDetectorClient.DetectAnomalyAsync` and `AnomalyDetectorClient.DetectAnomaly`
- Added operation `AnomalyDetectorClient.GetDetectionResultAsync` and `AnomalyDetectorClient.GetDetectionResult`
- Added operation `AnomalyDetectorClient.GetMultivariateModelAsync` and `AnomalyDetectorClient.GetMultivariateModel`
- Added operation `AnomalyDetectorClient.ExportModelAsync` and `AnomalyDetectorClient.ExportModel`
- Added operation `AnomalyDetectorClient.DeleteMultivariateModelAsync` and `AnomalyDetectorClient.DeleteMultivariateModel`

## 3.0.0-preview.2 (2020-09-03)

### Breaking Changes
- Renamed `AnomalyDetectorClient.EntireDetectAsync` and `AnomalyDetectorClient.EntireDetect` to `AnomalyDetectorClient.DetectEntireSeriesAsync` and `AnomalyDetectorClient.DetectEntireSeries`.
- Renamed `AnomalyDetectorClient.LastDetectAsync` and `AnomalyDetectorClient.LastDetect` to `AnomalyDetectorClient.DetectLastPointAsync` and `AnomalyDetectorClient.DetectLastPoint`.
- Renamed `AnomalyDetectorClient.ChangePointDetectAsync` and `AnomalyDetectorClient.ChangePointDetect` to `AnomalyDetectorClient.DetectChangePointAsync` and `AnomalyDetectorClient.DetectChangePoint`.
- Renamed `Request` to `DetectRequest`.
- Renamed `Point` to `TimeSeriesPoint`.
- Renamed `Granularity` to `TimeGranularity`.
- Renamed `Granularity.Minutely` to `TimeGranularity.PerMinute`.
- Renamed `Granularity.Secondly` to `TimeGranularity.PerSecond`.

## 3.0.0-preview.1 (2020-08-18)

- Initial preview of the Azure.AI.AnomalyDetector client library.
