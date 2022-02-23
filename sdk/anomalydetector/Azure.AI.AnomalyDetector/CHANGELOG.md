# Release History

## 3.0.0-preview.6 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
