# Release History

## 1.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

* Fix for "Comitted Memory" not updating.
  ([#42760](https://github.com/Azure/azure-sdk-for-net/pull/42760))

### Other Changes

## 1.0.0-beta.3 (2024-03-08)

### Features Added

* Update to report Memory and CPU which are displayed in the Live Metrics UX.
  ([#42213](https://github.com/Azure/azure-sdk-for-net/pull/42213))
  * For "Committed Memory", we use [Process.PrivateMemorySize64](https://learn.microsoft.com/dotnet/api/system.diagnostics.process.privatememorysize64).
  * For "CPU Total (%)", we use the change in [Process.TotalProcessorTime](https://learn.microsoft.com/dotnet/api/system.diagnostics.process.totalprocessortime) over a period of time. This value is normalized by dividing by the number of processors. The formula is `((change in ticks / period) / number of processors)`.

* Added NET6 target framework.
  ([#42426](https://github.com/Azure/azure-sdk-for-net/pull/42426))

### Bugs Fixed

* Fix runtime crash with Microsoft.Bcl.AsyncInterfaces.
  ([#42426](https://github.com/Azure/azure-sdk-for-net/pull/42426))

## 1.0.0-beta.2 (2024-02-09)

### Breaking Changes

* Disable Performance Counters to prevent runtime exceptions.
  CPU and Memory will no longer be displayed on the LiveMetrics chart.
  ([#41878](https://github.com/Azure/azure-sdk-for-net/pull/41878))

## 1.0.0-beta.1 (2024-02-08)

* Initial release of Azure Monitor [Live Metrics](https://learn.microsoft.com/azure/azure-monitor/app/live-stream) Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet). This version includes metrics, performance counters, and Sample Telemetry. This version does not include Filtering.

This is a beta version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

