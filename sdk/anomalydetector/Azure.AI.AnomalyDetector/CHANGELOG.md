# Release History

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
