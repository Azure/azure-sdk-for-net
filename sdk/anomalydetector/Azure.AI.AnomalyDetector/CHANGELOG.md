# Release History

## 3.0.0-preview.4 (Unreleased)


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
