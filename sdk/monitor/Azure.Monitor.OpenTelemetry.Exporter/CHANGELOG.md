# Release History

## 1.5.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0 (2025-05-08)

### Other Changes

* Changed `AzureMonitorLogExporter` to be internal to match the other Exporters (Trace and Metric).
  ([#49849](https://github.com/Azure/azure-sdk-for-net/pull/49849))

* Update OpenTelemetry dependencies
  ([#49861](https://github.com/Azure/azure-sdk-for-net/pull/49861))
  - OpenTelemetry 1.12.0

## 1.4.0-beta.3 (2025-04-01)

### Features Added

* Added support for emitting Application Insights Custom Events.
  ([#48378](https://github.com/Azure/azure-sdk-for-net/pull/48378))

* Added new api `UseAzureMonitorExporter` which automatically enables logging, tracing, and metrics.
  Additional calls to `WithLogging`, `WithMetrics`, and `WithTracing` are NOT required.
  However, you may still need to enable specific tracing/metric sources/meters separately.
  ([#48402](https://github.com/Azure/azure-sdk-for-net/pull/48402))
  - Added support for LiveMetrics when using the `UseAzureMonitorExporter` api.

### Bugs Fixed

* Fixed an issue where array attributes on metrics weren't exported correctly.
  ([#47300](https://github.com/Azure/azure-sdk-for-net/pull/47300))

* Always set Dependency.Target to "server.address" and "server.port" if present.
  ([#48317](https://github.com/Azure/azure-sdk-for-net/pull/48317))

### Other Changes

* Update OpenTelemetry dependencies
  ([#48574](https://github.com/Azure/azure-sdk-for-net/pull/48574))
  - OpenTelemetry 1.11.2
  - OpenTelemetry.PersistentStorage.FileSystem 1.0.1

## 1.4.0-beta.2 (2024-10-11)

### Bugs Fixed

* RPC attributes are now correctly exported to Application Insights as custom properties.
  ([#45316](https://github.com/Azure/azure-sdk-for-net/pull/45316))
* Fixed an issue where unmapped attributes were dropped from telemetry.
  ([#45909](https://github.com/Azure/azure-sdk-for-net/pull/45909))

## 1.4.0-beta.1 (2024-07-12)

### Bugs Fixed

* Added the `LogRecord.CategoryName` field to log and exception telemetry.
  Previously the `CategoryName` field was omitted, which was inconsistent with
  expected `ILogger` behavior, and with Application Insights classic behavior.
  ([#44754](https://github.com/Azure/azure-sdk-for-net/pull/44754))

### Features Added

* Added `LoggerProviderBuilder.AddAzureMonitorLogExporter` registration extension.
  ([#44617](https://github.com/Azure/azure-sdk-for-net/pull/44617))

### Other Changes

* Changed `AzureMonitorLogExporter` to be public.
  This will allow users to write custom processors for filtering logs.
  (This feature was originally introduced in 1.3.0-beta.1)
  ([#44511](https://github.com/Azure/azure-sdk-for-net/pull/44511))

* Update OpenTelemetry dependencies
  ([#44650](https://github.com/Azure/azure-sdk-for-net/pull/44650))
  - OpenTelemetry 1.9.0

## 1.3.0 (2024-06-07)

### Other Changes

* Changed `AzureMonitorLogExporter` to be internal.
  This will be changed back to public in our next Beta while we experiment with options to enable log filtering.
  ([#44479](https://github.com/Azure/azure-sdk-for-net/pull/44479))

## 1.3.0-beta.2 (2024-05-08)

### Features Added

* All three signals (Traces, Metrics, and Logs) now support OpenTelemetry's ["service.version"](https://github.com/open-telemetry/semantic-conventions/tree/main/docs/resource#service) in Resource attributes.
  This is mapped as [Application Version](https://learn.microsoft.com/azure/azure-monitor/app/data-model-complete#application-version) in Application Insights.
  ([#42174](https://github.com/Azure/azure-sdk-for-net/pull/42174))
* Turned off internal spans and logs in exporter HTTP pipeline
  ([#43359](https://github.com/Azure/azure-sdk-for-net/pull/43359))

### Bugs Fixed
* The success or failure of an incoming HTTP request is now determined by the status code only when the Activity Status is `Unset`
  ([#43594](https://github.com/Azure/azure-sdk-for-net/pull/43594), based on [#41993](https://github.com/Azure/azure-sdk-for-net/issues/41993))

### Other Changes

* Update OpenTelemetry dependencies
  ([#43688](https://github.com/Azure/azure-sdk-for-net/pull/43688))
  - OpenTelemetry 1.8.1

## 1.3.0-beta.1 (2024-02-08)

### Bugs Fixed

* Fixed an issue where `_OTELRESOURCE_` metrics were emitted with duplicated
  timestamps. This fix ensures accurate and distinct timestamping for all
  `_OTELRESOURCE_` metrics.
  ([#41761](https://github.com/Azure/azure-sdk-for-net/pull/41761))

* Fixed an issue where tags associated with Exceptions were not being included.
  Now, tags linked to an `ActivityEvent` following the [otel convention for storing exception](https://github.com/open-telemetry/semantic-conventions/blob/main/docs/exceptions/exceptions-spans.md) are correctly exported as Custom Properties.
  ([#41767](https://github.com/Azure/azure-sdk-for-net/pull/41767))

### Other Changes

* Changed `AzureMonitorLogExporter` to be public.
  This will allow users to write custom processors for filtering logs.
  ([#41553](https://github.com/Azure/azure-sdk-for-net/pull/41553))

## 1.2.0 (2024-01-24)

### Other Changes

* Update OpenTelemetry dependencies
  ([#41398](https://github.com/Azure/azure-sdk-for-net/pull/41398))
  - OpenTelemetry 1.7.0

## 1.1.0 (2023-11-29)

### Features Added

* Added NET6 target framework to support Trimming.
  ([#38459](https://github.com/Azure/azure-sdk-for-net/pull/38459))
* Added support for Trimming and AOT.
  ([#38459](https://github.com/Azure/azure-sdk-for-net/pull/38459))

### Bugs Fixed

* Fixed an issue where `OriginalFormat` persisted in TraceTelemetry properties
  with IncludeFormattedMessage set to true on [
  OpenTelemetryLoggerOptions](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/Logs/ILogger/OpenTelemetryLoggerOptions.cs)
  of the OpenTelemetry LoggerProvider. This fix prevents data duplication in
  message fields and properties.
  ([#39308](https://github.com/Azure/azure-sdk-for-net/pull/39308))

* Fixed an issue related to the processing of scopes that do not conform to a
  key-value pair structure.
  ([#39453](https://github.com/Azure/azure-sdk-for-net/pull/39453))
   * **Previous Behavior**: Logging a scope with a statement like
     `logger.BeginScope("SomeScopeValue")` would result in adding
     'SomeScopeValue' to the properties using a key that follows the pattern
     'scope->*'. Additionally, 'OriginalFormatScope_*' keys were used to handle
     formatted strings within the scope.
   * **New Behavior**:
     * Non-key-value pair scopes are no longer added to the properties,
       resulting in cleaner and more efficient log output.
     * 'OriginalFormatScope_*' keys have been removed.
     * In case of duplicate keys within the scopes, only the first entry is
     retained, while all subsequent duplicate entries are discarded.

* Resolved an issue where activity tags of various object types, including
  double, float, and others, were previously formatted using
  `CultureInfo.CurrentCulture`. This behavior caused inconsistencies in tag
  value formatting depending on the regional settings of the machine where the
  application was running. Such inconsistencies could lead to challenges in data
  analysis and cause test failures in environments with differing cultural
  settings. The fix ensures uniform and culture-independent formatting of
  activity tag values, aligning with consistent data representation.
  ([#39470](https://github.com/Azure/azure-sdk-for-net/issues/39470))

## 1.0.0 (2023-09-20)

### Bugs Fixed

* Fixed an issue during network failures which prevented the exporter to store
  the telemetry offline for retrying at a later time.
  ([#38832](https://github.com/Azure/azure-sdk-for-net/pull/38832))

### Other Changes

* Update OpenTelemetry dependencies
  ([#38430](https://github.com/Azure/azure-sdk-for-net/pull/38430))
  ([#38568](https://github.com/Azure/azure-sdk-for-net/pull/38568))
  - OpenTelemetry 1.6.0
  - OpenTelemetry.PersistentStorage.FileSystem 1.0.0

## 1.0.0-beta.14 (2023-08-09)

### Breaking Changes

* Location ip on server spans will now be set using `client.address` tag key on
  activity instead of `http.client_ip`.
  ([#37707](https://github.com/Azure/azure-sdk-for-net/pull/37707))
* Removing `ServiceVersion.V2020_09_15_Preview`. This is no longer in use and
  the exporter has already defaulted to the latest `ServiceVersion.v2_1`.
  ([#37996](https://github.com/Azure/azure-sdk-for-net/pull/37996))
* Remove Nullable Annotations from the Exporter's public API.
  ([#37996](https://github.com/Azure/azure-sdk-for-net/pull/37996))

### Bugs Fixed

* Fixed an issue causing no telemetry if SDK Version string exceeds max length.
  ([#37807](https://github.com/Azure/azure-sdk-for-net/pull/37807))

### Other Changes

* Update OpenTelemetry dependencies
  ([#37837](https://github.com/Azure/azure-sdk-for-net/pull/37837))
  - OpenTelemetry 1.5.1

## 1.0.0-beta.13 (2023-07-13)

### Features Added

* Added `ApplicationInsightsSampler` to the exporter, enabling users to customize the sampling rate using the `SamplingRatio` property.
  ([#36972](https://github.com/Azure/azure-sdk-for-net/pull/36972))

### Other Changes

* Updated Exporter to read v1.21.0 of the OpenTelemetry Semantic Conventions attributes for HTTP.
  For more information see [Semantic conventions for HTTP spans](https://github.com/open-telemetry/opentelemetry-specification/blob/v1.21.0/specification/trace/semantic_conventions/http.md).
  ([#37464](https://github.com/Azure/azure-sdk-for-net/pull/37464))
  ([#37357](https://github.com/Azure/azure-sdk-for-net/pull/37357))
* Update OpenTelemetry dependencies
  ([#36859](https://github.com/Azure/azure-sdk-for-net/pull/36859))
  - OpenTelemetry 1.5.0
* Remove metric namespace mapping.
  ([#36968](https://github.com/Azure/azure-sdk-for-net/pull/36968))

## 1.0.0-beta.12 (2023-06-06)

### Features Added

* Add support for Authenticated User Id.
  ([#36509](https://github.com/Azure/azure-sdk-for-net/pull/36509))
* Add `db.name` to custom properties.
  ([#36389](https://github.com/Azure/azure-sdk-for-net/pull/36389))

### Bugs Fixed

* Fixed an issue which resulted in standard metrics getting exported to backends other than Azure Monitor, when Azure Monitor metric exporter was used with other exporters such as otlp side by side.
  ([#36369](https://github.com/Azure/azure-sdk-for-net/pull/36369))

### Other Changes

* Removed `_OTELRESOURCE_` export from Logs and Metrics.
  ([#36430](https://github.com/Azure/azure-sdk-for-net/pull/36430))

## 1.0.0-beta.11 (2023-05-09)

### Features Added

* [Resource](https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/resource/sdk.md) attributes will now be exported as custom dimensions on Metric telemetry with the name `_OTELRESOURCE_`. This Metric will be included in every batch of telemetry items sent to the ingestion service. ([#36063](https://github.com/Azure/azure-sdk-for-net/pull/36063))

### Other Changes

* Update OpenTelemetry dependencies
  ([#35664](https://github.com/Azure/azure-sdk-for-net/pull/35664))
  - OpenTelemetry.PersistentStorage.FileSystem 1.0.0-beta2

## 1.0.0-beta.10 (2023-04-11)

### Bugs Fixed

- Fixed an issue of when using ILogger to log an Exception a custom message would override the exception message.
  ([#33860](https://github.com/Azure/azure-sdk-for-net/pull/33860))

## 1.0.0-beta.9 (2023-03-14)

### Other Changes

- Changed Attach Statsbeat name as per spec
- Upgraded dependent `Azure.Core` to `1.30.0` due to an [issue in `ArrayBackedPropertyBag`](https://github.com/Azure/azure-sdk-for-net/pull/34800) in `Azure.Core` version `1.29.0`.

## 1.0.0-beta.8 (2023-03-07)

### Features Added

* AAD can now be configured via `AzureMonitorExporterOptions`
  ([#34555](https://github.com/Azure/azure-sdk-for-net/pull/34555))

* Connection String can now be provided via
  `APPLICATIONINSIGHTS_CONNECTION_STRING` environment variable
  ([#34275](https://github.com/Azure/azure-sdk-for-net/pull/34275))

* `dependencies\duration` and `requests\duration` standard metrics will now be
  exported by default when trace exporter is used alongside metric exporter
  ([#34010](https://github.com/Azure/azure-sdk-for-net/pull/34010))
  ([#33955](https://github.com/Azure/azure-sdk-for-net/pull/33955))

* Added support for named options ([#33803](https://github.com/Azure/azure-sdk-for-net/pull/33803))

### Bugs Fixed

* Fixed an issue of missing logs due to unhandled exception. ([#34423](https://github.com/Azure/azure-sdk-for-net/pull/34423))

### Other Changes

* Update OpenTelemetry dependencies
  ([#34551](https://github.com/Azure/azure-sdk-for-net/pull/34551))
  - OpenTelemetry 1.4.0

## 1.0.0-beta.7 (2023-02-07)

### Features Added

* Added support for parsing AADAudience from ConnectionString ([#33593](https://github.com/Azure/azure-sdk-for-net/pull/33593))
* Activity Events (SpanEvents), except those representing Exception, will be exported to TraceTelemetry table ([#32980](https://github.com/Azure/azure-sdk-for-net/pull/32980))
  Exceptions reported via ActivityEvents will continue to be exported to ExceptionTelemetry table

### Bugs Fixed

* 4xx errors on Request telemetry will now be reported as failures ([#33617](https://github.com/Azure/azure-sdk-for-net/pull/33617))

### Other Changes

* Update OpenTelemetry dependencies
  ([#33859](https://github.com/Azure/azure-sdk-for-net/pull/33859))
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
* Debugging Output now includes Telemetry sent from storage ([#32172](https://github.com/Azure/azure-sdk-for-net/pull/32172))

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
* Added support for sampling using [Application Insights based sampler](https://www.nuget.org/packages/OpenTelemetry.Extensions.AzureMonitor/) ([#31118](https://github.com/Azure/azure-sdk-for-net/pull/31118))

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
