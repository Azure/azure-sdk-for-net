# Release History

## 1.0.0-beta.7 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

* Update OpenTelemetry dependencies
  ([#38568](https://github.com/Azure/azure-sdk-for-net/pull/38568))
  ([#38833](https://github.com/Azure/azure-sdk-for-net/pull/38833))
  - OpenTelemetry 1.6.0
  - OpenTelemetry.Extensions.Hosting 1.6.0
  - OpenTelemetry.ResourceDetectors.Azure 1.0.0-beta.3

## 1.0.0-beta.6 (2023-08-09)

### Features Added

* Added `Resource` to traces, logs, and metrics with default configuration.
  ([#37837](https://github.com/Azure/azure-sdk-for-net/pull/37837))
* Added resource detection for `Azure App Service` and `Azure Virtual Machine` environment. .
  ([#37837](https://github.com/Azure/azure-sdk-for-net/pull/37837))

### Other Changes

* Update OpenTelemetry dependencies
  ([#37837](https://github.com/Azure/azure-sdk-for-net/pull/37837))
  ([#37881](https://github.com/Azure/azure-sdk-for-net/pull/37881))
  - OpenTelemetry 1.5.1
  - OpenTelemetry.Extensions.Hosting 1.5.1
  - OpenTelemetry.Instrumentation.AspNetCore 1.5.1-beta.1
  - OpenTelemetry.Instrumentation.Http 1.5.1-beta.1
  - OpenTelemetry.Instrumentation.SqlClient 1.5.1-beta.1
  - OpenTelemetry.ResourceDetectors.Azure 1.0.0-beta2

## 1.0.0-beta.5 (2023-07-13)

### Features Added

* Added instrumentation support for Azure SDKs.
  See [Enable Azure SDK Instrumentation](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/README.md#enable-azure-sdk-instrumentation) for details.
  ([#37505](https://github.com/Azure/azure-sdk-for-net/pull/37505))
* Added `SamplingRatio` property to customize the sampling rate in Azure Monitor Exporter. **Note**: This package no longer takes dependency on [OpenTelemetry.Extensions.AzureMonitor](https://www.nuget.org/packages/OpenTelemetry.Extensions.AzureMonitor)
  ([#36972](https://github.com/Azure/azure-sdk-for-net/pull/36972))

### Other Changes

* Update OpenTelemetry dependencies
  ([#36859](https://github.com/Azure/azure-sdk-for-net/pull/36859))
  - OpenTelemetry 1.5.0
  - OpenTelemetry.Extensions.Hosting 1.5.0
  - OpenTelemetry.Instrumentation.AspNetCore 1.5.0-beta.1
  - OpenTelemetry.Instrumentation.Http 1.5.0-beta.1
  - OpenTelemetry.Instrumentation.SqlClient 1.5.0-beta.1

* Removed reference to `OpenTelemetry.Extensions.AzureMonitor`.
  ([#36972](https://github.com/Azure/azure-sdk-for-net/pull/36972))

## 1.0.0-beta.4 (2023-05-09)

### Features Added

* Added ability to configure sampling percentage using `ApplicationInsightsSamplerOptions`.
([#36111](https://github.com/Azure/azure-sdk-for-net/pull/3611))

## 1.0.0-beta.3 (2023-04-11)

### Features Added

* Added new public APIs `Services.AddOpenTelemetry().UseAzureMonitor()` and `Services.AddOpenTelemetry().UseAzureMonitor(Action<AzureMonitorOptions> configureAzureMonitor)`.

### Breaking Changes

* Removed public APIs `Services.AddAzureMonitor()`, `Services.AddAzureMonitor(AzureMonitorOptions options)` and `Services.AddAzureMonitor(Action<AzureMonitorOptions> configureAzureMonitor)`.

## 1.0.0-beta.2 (2023-03-14)

### Other Changes

* Upgraded dependent `Azure.Core` to `1.30.0` due to an [issue in `ArrayBackedPropertyBag`](https://github.com/Azure/azure-sdk-for-net/pull/34800) in `Azure.Core` version `1.29.0`.

## 1.0.0-beta.1 (2023-03-07)

* Initial release of `Azure.Monitor.OpenTelemetry.AspNetCore`.

This is a beta version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).
