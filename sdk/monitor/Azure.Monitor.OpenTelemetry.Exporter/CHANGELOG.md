# Release History

## 1.0.0-beta.7 (2023-02-07)

### Features Added

* Added support for parsing AADAudience from ConnectionString ([#33593](https://github.com/Azure/azure-sdk-for-net/pull/33593))
* Activity Events (SpanEvents), except those representing Exception, will be exported to TraceTelemetry table([#32980](https://github.com/Azure/azure-sdk-for-net/pull/32980))
Exceptions reported via ActivityEvents will continue to be exported to ExceptionTelemetry table

### Bugs Fixed

* 4xx errors on Request telemetry will now be reported as failures ([#33617](https://github.com/Azure/azure-sdk-for-net/pull/33617))

### Other Changes

* Update OpenTelemetry dependencies
  ([]())
  - OpenTelemetry 1.4.0-rc.3

## 1.0.0-beta.6 (2023-01-10)

### Features Added

* AAD Support ([#32986](https://github.com/Azure/azure-sdk-for-net/pull/32986))

### Other Changes

* Update OpenTelemetry dependencies
  ([#33152](https://github.com/Azure/azure-sdk-for-net/pull/33152))
  - OpenTelemetry 1.4.0-rc.1

## 1.0.0-beta.5 (2022-11-08)

### Features Added

* Add support for exporting Histogram Min and Max ([#32072](https://github.com/Azure/azure-sdk-for-net/pull/32072))
* Add support for exporting UpDownCounter and ObservableUpDownCounter ([#32170](https://github.com/Azure/azure-sdk-for-net/pull/32170))

### Other Changes

* Update OpenTelemetry dependencies ([#32047](https://github.com/Azure/azure-sdk-for-net/pull/32047))
  - OpenTelemetry v1.4.0-beta.2
* Debugging Output now includes Telemetry sent from storage. ([#32172](https://github.com/Azure/azure-sdk-for-net/pull/32172))

## 1.0.0-beta.4 (2022-10-07)

### Features Added

* A public "AddAzureMonitorExporter" method is now available for all three signals
  - `AddAzureMonitorTraceExporter()` for Traces (available in previous version)
  - `AddAzureMonitorMetricExporter()` for Metrics ([#26651](https://github.com/Azure/azure-sdk-for-net/pull/26651))
  - `AddAzureMonitorLogExporter()` for Logs ([#26355](https://github.com/Azure/azure-sdk-for-net/pull/26355))
* Added support for offline storage when ingestion endpoint is unavailable. This is enabled by default.
  - Default directory is "Microsoft\AzureMonitor" ([#31073](https://github.com/Azure/azure-sdk-for-net/pull/31073))
  - Users may override the default location by setting `AzureMonitorExporterOptions.StorageDirectory` ([#26494](https://github.com/Azure/azure-sdk-for-net/pull/26494))
  - Users may disable by setting `AzureMonitorExporterOptions.DisableOfflineStorage` ([#28446](https://github.com/Azure/azure-sdk-for-net/pull/28446))
* Added support for exception telemetry from ILogger ([#26670](https://github.com/Azure/azure-sdk-for-net/pull/26670))
* Support for exporting Activity exception event ([#29676](https://github.com/Azure/azure-sdk-for-net/pull/29676))
* Added support for sampling using [Application Insights based sampler](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/main/src/OpenTelemetry.Extensions.AzureMonitor).  ([#31118](https://github.com/Azure/azure-sdk-for-net/pull/31118))

### Breaking Changes

* Request and Dependency Success criteria will now be decided based on
  `Activity.Status` ([#31024](https://github.com/Azure/azure-sdk-for-net/pull/31024))
* Changed `AzureMonitorTraceExporter` to internal ([#31067](https://github.com/Azure/azure-sdk-for-net/pull/31067))
  
### Bugs Fixed

* Fix shared RoleName/RoleInstance between Trace and Log Exporter ([#26438](https://github.com/Azure/azure-sdk-for-net/pull/26438))

### Other Changes

* Update OpenTelemetry dependencies ([#31065](https://github.com/Azure/azure-sdk-for-net/pull/31065))
  - OpenTelemetry v1.3.1
  - OpenTelemetry.Extensions.PersistentStorage v1.0.0-beta.1

## 1.0.0-beta.3 (2021-10-04)

* [Update SdkVersion to include pre-release part](https://github.com/Azure/azure-sdk-for-net/pull/24290)
* [Remove otel.status_code from custom properties](https://github.com/Azure/azure-sdk-for-net/pull/24250)
* [Update Request operation name to use http.route/http.url path](https://github.com/Azure/azure-sdk-for-net/pull/24222)
* [Update Http Dependency name to httpUrl path and target for Db dependency](https://github.com/Azure/azure-sdk-for-net/pull/24211)
* [Rename EventSource](https://github.com/Azure/azure-sdk-for-net/pull/24176)
* [Update Request Name to match Operation Name](https://github.com/Azure/azure-sdk-for-net/pull/24059)
* [Fix success field logic for request and dependency](https://github.com/Azure/azure-sdk-for-net/pull/23757)
* [Default cloud_RoleInstance to HostName](https://github.com/Azure/azure-sdk-for-net/pull/23592)
* [Add InProc dependency type and update Db target mapping](https://github.com/Azure/azure-sdk-for-net/pull/23541)
* [Add ai.location.ip and ai.user.userAgent mapping](https://github.com/Azure/azure-sdk-for-net/pull/23524)
* [Operation name mapping for ActivityKind = SERVER](https://github.com/Azure/azure-sdk-for-net/pull/23448)
* [Update Dependency Type and Target mapping for Http and Db](https://github.com/Azure/azure-sdk-for-net/pull/23330)
* [Update Http Request mapping](https://github.com/Azure/azure-sdk-for-net/pull/23206)
* [Add ActivityLinks Support](https://github.com/Azure/azure-sdk-for-net/pull/23110)
* [Update OpenTelemetry Package versions](https://github.com/Azure/azure-sdk-for-net/pull/23059)

## 1.0.0-beta.2 (2021-03-04)

* [Set Remote Dependency Telemetry semantics](https://github.com/Azure/azure-sdk-for-net/issues/17026)
* [Supports sending EventSource and Telemetry output to the debug trace](https://github.com/Azure/azure-sdk-for-net/issues/16893)

## 1.0.0-beta.1 (2020-11-06)

* Initial release of Azure Monitor Exporter for [OpenTelemetry .NET](https://github.com/open-telemetry/opentelemetry-dotnet)

This is a beta version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).
