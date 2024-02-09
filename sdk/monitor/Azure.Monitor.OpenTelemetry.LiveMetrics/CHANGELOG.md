# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2024-02-09)

### Breaking Changes

* Disable Performance Counters to prevent runtime exceptions.
  CPU and Memory will no longer be displayed on the LiveMetrics chart.
  ([#41878](https://github.com/Azure/azure-sdk-for-net/pull/41878))

## 1.0.0-beta.1 (2024-02-08)

* Initial release of Azure Monitor [Live Metrics](https://learn.microsoft.com/azure/azure-monitor/app/live-stream) Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet). This version includes metrics, performance counters, and Sample Telemetry. This version does not include Filtering.

This is a beta version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

