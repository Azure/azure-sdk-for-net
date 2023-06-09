# Release History

## 1.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
