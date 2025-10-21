# Release History

## 1.4.0-beta.1 (2025-10-21)

### Features Added

* Added support for configuring sampling via OpenTelemetry environment
  variables:
  * `OTEL_TRACES_SAMPLER` (supported values: `microsoft.rate_limited`,
    `microsoft.fixed_percentage`).
  * `OTEL_TRACES_SAMPLER_ARG` (rate limit in traces/sec for
  `microsoft.rate_limited`, sampling ratio 0.0 - 1.0 for
  `microsoft.fixed_percentage`).
  ([#52720](https://github.com/Azure/azure-sdk-for-net/pull/52720))
* Added handling of stable database client span semantic conventions
  ([#53050](https://github.com/Azure/azure-sdk-for-net/pull/53050))
* Added collection of the following metrics:
  - `\.NET CLR Exceptions(??APP_CLR_PROC??)\# of Exceps Thrown / sec`
  - `\ASP.NET Applications(??APP_W3SVC_PROC??)\Requests/Sec`;
  - `\Process(??APP_WIN32_PROC??)\% Processor Time"`
  - `\Process(??APP_WIN32_PROC??)\% Processor Time Normalized`
  - `\Process(??APP_WIN32_PROC??)\Private Bytes`
  ([#52705](https://github.com/Azure/azure-sdk-for-net/pull/52705))
* Emission of customer facing SDK stats
  - `preview.item.success.count`
  - `preview.item.dropped.count`
  - `preview.item.retry.count`
  ([#53010](https://github.com/Azure/azure-sdk-for-net/pull/53010))
* Add `enduser.pseudo.id` as ai.user.id 
([#52722](https://github.com/Azure/azure-sdk-for-net/pull/52722))
* Add `ai.location.ip` mapping for all telemetry types ([#52211](https://github.com/Azure/azure-sdk-for-net/pull/52211))

## 1.3.0 (2025-05-09)

### Other Changes

* Updated the code of vendored resource detector library `OpenTelemetry.Resources.Azure` from the OpenTelemetry .NET contrib repository.
  Code has been updated to [1.11.0-beta.2](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/Resources.Azure-1.11.0-beta.2/src/OpenTelemetry.Resources.Azure).
  ([#49351](https://github.com/Azure/azure-sdk-for-net/pull/49351))

* Update OpenTelemetry dependencies
  ([#49861](https://github.com/Azure/azure-sdk-for-net/pull/49861))
  - OpenTelemetry 1.12.0
  - OpenTelemetry.Extensions.Hosting 1.12.0
  - OpenTelemetry.Instrumentation.AspNetCore 1.12.0
  - OpenTelemetry.Instrumentation.Http 1.12.0

## 1.3.0-beta.3 (2025-04-08)

### Other Changes

* Update OpenTelemetry dependencies
  ([#48574](https://github.com/Azure/azure-sdk-for-net/pull/48574))
  - OpenTelemetry 1.11.2
  - OpenTelemetry.Extensions.Hosting 1.11.2
  - OpenTelemetry.Instrumentation.AspNetCore 1.11.1
  - OpenTelemetry.Instrumentation.Http 1.11.1

## 1.3.0-beta.2 (2024-10-11)

### Bugs Fixed

* Fixed an issue where `APPLICATIONINSIGHTS_CONNECTION_STRING` was not read from
  `IConfiguration` when using the `UseAzureMonitor` overload with the
  `Action<AzureMonitorOptions>` parameter. If the connection string is not set
  using the `Action<AzureMonitorOptions>` delegate, the distro will now check if
  `APPLICATIONINSIGHTS_CONNECTION_STRING` is present in `IConfiguration`.
  ([#45292](https://github.com/Azure/azure-sdk-for-net/pull/45292))

* Fixed a bug where LiveMetrics displays "UNKNOWN_INSTANCE" and "UNKNOWN_NAME" for "server name" and "role name" respectively.
  ([#45433](https://github.com/Azure/azure-sdk-for-net/pull/45433))

* Fixed a bug in LiveMetrics that counted all manually created Dependencies as failures.
  ([#45103](https://github.com/Azure/azure-sdk-for-net/pull/45103))

* Fixed a bug in LiveMetrics that caused incorrect counts for telemetry.
  ([#46429](https://github.com/Azure/azure-sdk-for-net/pull/46429))

### Other Changes

* Updated the code of vendored resource detector library `OpenTelemetry.Resources.Azure` from the OpenTelemetry .NET contrib repository.
  Code has been updated to [1.0.0-beta.9](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/Resources.Azure-1.0.0-beta.9/src/OpenTelemetry.Resources.Azure).
  ([#46207](https://github.com/Azure/azure-sdk-for-net/pull/46207))

* Updated field mappings for telemetry sent to LiveMetrics.
  ([#45103](https://github.com/Azure/azure-sdk-for-net/pull/45103))

* Updated log collection to default to Warning level and above for Azure SDKs
  via `Microsoft.Extensions.Logging`. For more information, refer to [Logging
  with the Azure SDK for
  .NET](https://learn.microsoft.com/dotnet/azure/sdk/logging).
  ([#45649](https://github.com/Azure/azure-sdk-for-net/pull/45649))

* Improved the efficiency of `AzureEventSourceLogForwarder` by eliminating message formatting. ([#46202](https://github.com/Azure/azure-sdk-for-net/pull/46202))

## 1.3.0-beta.1 (2024-07-12)

### Bugs Fixed

* Added the `LogRecord.CategoryName` field to log and exception telemetry.
  Previously the `CategoryName` field was omitted, which was inconsistent with
  expected `ILogger` behavior, and with Application Insights classic behavior.
  ([#44754](https://github.com/Azure/azure-sdk-for-net/pull/44754))

* Fixed an issue where a `DuplicateKeyException` could be thrown if `EventId`
  and `EventName` were present in both `LogRecord` (`LogRecord.EventId`,
  `LogRecord.EventName`) and `LogRecord.Attributes`. The method now uses
  `EventId` and `EventName` from `LogRecord.Attributes` when both are present.
  If they are not in `LogRecord.Attributes`, it uses the values from
  `LogRecord.EventId` or `LogRecord.EventName`, preventing the `LogRecord` from
  being dropped.
  ([#44748](https://github.com/Azure/azure-sdk-for-net/pull/44748))

### Other Changes

* Enabled support for log collection from Azure SDKs via `Microsoft.Extensions.Logging`.
  See [Logging with the Azure SDK for .NET](https://learn.microsoft.com/dotnet/azure/sdk/logging) for the details.
  (This feature was originally introduced in 1.2.0-beta.2)
  ([#44511](https://github.com/Azure/azure-sdk-for-net/pull/44511))

* Update OpenTelemetry dependencies.
  ([#44650](https://github.com/Azure/azure-sdk-for-net/pull/44650))
  - OpenTelemetry 1.9.0
  - OpenTelemetry.Extensions.Hosting 1.9.0
  - OpenTelemetry.Instrumentation.AspNetCore 1.9.0
  - OpenTelemetry.Instrumentation.Http 1.9.0

* Updated the code of vendored instrumentation library `OpenTelemetry.Instrumentation.SqlClient` from the OpenTelemetry .NET contrib repository.
  Code has been updated to [1.9.0-beta.1](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/Instrumentation.SqlClient-1.9.0-beta.1/src/OpenTelemetry.Instrumentation.SqlClient).
  ([#44682](https://github.com/Azure/azure-sdk-for-net/pull/44682))

* Updated the code of vendored resource detector library `OpenTelemetry.Resources.Azure` from the OpenTelemetry .NET contrib repository.
  Code has been updated to [1.0.0-beta.8](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/Resources.Azure-1.0.0-beta.8/src/OpenTelemetry.Resources.Azure).
  ([#44682](https://github.com/Azure/azure-sdk-for-net/pull/44682))

* Removed an experimental feature for logs emitted within an active tracing context to follow the Activity's sampling decision.
  (This feature was originally introduced in 1.2.0-beta.1)
  ([#44745](https://github.com/Azure/azure-sdk-for-net/pull/44745))

## 1.2.0 (2024-06-11)

### Other Changes

* Disabled support for log collection from Azure SDKs.
  This will be re-enabled in our next Beta while we experiment with options to enable log filtering.
  ([#44479](https://github.com/Azure/azure-sdk-for-net/pull/44479))

* Disabled trace-based log sampling experimental feature.
  This will be re-enabled in our next Beta while we experiment with options to enable log filtering.
  ([#44479](https://github.com/Azure/azure-sdk-for-net/pull/44479))

## 1.2.0-beta.4 (2024-05-20)

### Features Added

* Added CustomProperties to LiveMetrics Documents
  ([#43600](https://github.com/Azure/azure-sdk-for-net/pull/43600))

### Bugs Fixed

* Fixed a bug in LiveMetrics Document filtering
  ([#43546](https://github.com/Azure/azure-sdk-for-net/pull/43546))

### Other Changes

* Update Azure.Monitor.OpenTelemetry.Exporter to 1.3.0-beta.2
  ([#44159](https://github.com/Azure/azure-sdk-for-net/pull/44159))

## 1.1.1 (2024-04-26)

### Other Changes

* Update OpenTelemetry dependencies.
  ([#43432](https://github.com/Azure/azure-sdk-for-net/pull/43432))
  - OpenTelemetry 1.8.1
  - OpenTelemetry.Extensions.Hosting 1.8.1
  - OpenTelemetry.Instrumentation.AspNetCore 1.8.1
  - OpenTelemetry.Instrumentation.Http 1.8.1
  - This update is a response to [CVE-2024-32028](https://nvd.nist.gov/vuln/detail/CVE-2024-32028)

## 1.2.0-beta.3 (2024-04-19)

### Features Added

* Added support for OpenTelemetry Logs to be sent to LiveMetrics.
  ([#43081](https://github.com/Azure/azure-sdk-for-net/pull/43081))

### Bugs Fixed

* Turned off internal spans and logs in distro HTTP pipelines
  ([#43359](https://github.com/Azure/azure-sdk-for-net/pull/43359))

### Other Changes

* Update OpenTelemetry dependencies
  ([#43197](https://github.com/Azure/azure-sdk-for-net/pull/43197))
  - OpenTelemetry 1.8.0
  - OpenTelemetry.Extensions.Hosting 1.8.0

* Removed the necessity for custom resource attributes configuration in
  OpenTelemetry logging setup, as the OpenTelemetry .NET SDK's enhancements to
  the builder.ConfigureResource method now uniformly set resource attributes
  across logs, metrics, and traces.
  ([#43197](https://github.com/Azure/azure-sdk-for-net/pull/43197))

## 1.2.0-beta.2 (2024-03-12)

### Features Added

* Added ASP.NET Core and HTTP Client Metrics Collection:
  * For `.NET 8.0` and above, we now utilize built-in Metrics from
    [Microsoft.AspNetCore.Hosting](https://learn.microsoft.com/en-in/dotnet/core/diagnostics/built-in-metrics-aspnetcore#microsoftaspnetcorehosting)
    and [System.Net.Http](https://learn.microsoft.com/en-in/dotnet/core/diagnostics/built-in-metrics-system-net#systemnethttp).
  * For environments targetting `.NET 7.0` and below, distro uses ASP.NET Core and HTTP Client Instrumentation.
    Detailed metrics information can be found in the
    [ASP.NET Core Instrumentation](https://github.com/open-telemetry/opentelemetry-dotnet/blob/Instrumentation.AspNetCore-1.7.1/src/OpenTelemetry.Instrumentation.AspNetCore/README.md#list-of-metrics-produced)
    and [HTTP Client Instrumentation](https://github.com/open-telemetry/opentelemetry-dotnet/blob/Instrumentation.Http-1.7.1/src/OpenTelemetry.Instrumentation.Http/README.md#list-of-metrics-produced)
    documentation.
  ([#42307](https://github.com/Azure/azure-sdk-for-net/pull/42307))

* Enabled support for log collection from Azure SDKs via `Microsoft.Extensions.Logging`. See [Logging with the Azure SDK for .NET](https://learn.microsoft.com/dotnet/azure/sdk/logging)
  for the details.
  ([#42374](https://github.com/Azure/azure-sdk-for-net/pull/42374))

* Added NET6 target framework.
  ([#42426](https://github.com/Azure/azure-sdk-for-net/pull/42426))

### Bugs Fixed

* Will no longer emit `db.statement_type` as a part of SQL custom dimensions.
  This attribute was removed from the SqlClient Instrumentation Library because it's not a part of the [semantic conventions](https://github.com/open-telemetry/semantic-conventions/blob/v1.24.0/docs/database/database-spans.md#call-level-attributes).

* Fix runtime crash with Microsoft.Bcl.AsyncInterfaces.
  ([#42426](https://github.com/Azure/azure-sdk-for-net/pull/42426))

### Other Changes

* Updated the code of vendored instrumentation library `OpenTelemetry.Instrumentation.SqlClient` from the OpenTelemetry .NET repository.
  Code has been updated to [1.7.0-beta.1](https://github.com/open-telemetry/opentelemetry-dotnet/tree/Instrumentation.SqlClient-1.7.0-beta.1/src/OpenTelemetry.Instrumentation.SqlClient).
  ([#42479](https://github.com/Azure/azure-sdk-for-net/pull/42479))

* Updated the code of vendored resource detector library `OpenTelemetry.ResourceDetectors.Azure` from the OpenTelemetry .NET contrib repository.
  Code has been updated to [1.0.0-beta.5](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/ResourceDetectors.Azure-1.0.0-beta.5/src/OpenTelemetry.ResourceDetectors.Azure).
  ([#42479](https://github.com/Azure/azure-sdk-for-net/pull/42479))

## 1.2.0-beta.1 (2024-02-09)

### Features Added

* Added Azure Container Apps resource detector.
  ([#41803](https://github.com/Azure/azure-sdk-for-net/pull/41803))

* Added `Azure.Monitor.OpenTelemetry.LiveMetrics`, enabling the sending of [live
  metrics
  data](https://learn.microsoft.com/azure/azure-monitor/app/live-stream).
  The newly added `EnableLiveMetrics` property is set to `true` by default. This
  property can be set to `false` to disable live metrics.
  ([#41872](https://github.com/Azure/azure-sdk-for-net/pull/41872))

* Added an experimental feature for logs emitted within an active tracing
  context to follow the Activity's sampling decision. The feature can be enabled
  by setting `OTEL_DOTNET_AZURE_MONITOR_EXPERIMENTAL_ENABLE_LOG_SAMPLING`
  environment variable to `true`.
  ([#41665](https://github.com/Azure/azure-sdk-for-net/pull/41665))

### Other Changes

* Updated the vendored code in the `OpenTelemetry.ResourceDetectors.Azure`
  resource detector to include the Azure Container Apps resource detector.
  ([#41803](https://github.com/Azure/azure-sdk-for-net/pull/41803))

## 1.1.0 (2024-01-25)

### Other Changes

- Removed the code of internal vendored instrumentation libraries `OpenTelemetry.Instrumentation.AspNetCore` and `OpenTelemetry.Instrumentation.Http`.
  Previously users needed to manually add package references to these instrumentation libraries to apply any customizations. This will no longer be necessary.
  Now that these packages have released stable versions, we will directly reference those and users will be able to apply any customizations using the publicly available APIs.
  ([#41395](https://github.com/Azure/azure-sdk-for-net/pull/41395))
- Update OpenTelemetry dependencies
  ([41398](https://github.com/Azure/azure-sdk-for-net/pull/41398))
  - OpenTelemetry 1.7.0
  - NEW: OpenTelemetry.Instrumentation.AspNetCore 1.7.0
  - NEW: OpenTelemetry.Instrumentation.Http 1.7.0

## 1.0.0 (2023-11-29)

### Other Changes

- Updated the code of vendored instrumentation libraries `OpenTelemetry.Instrumentation.AspNetCore`, `OpenTelemetry.Instrumentation.Http`, and `OpenTelemetry.Instrumentation.SqlClient` from the OpenTelemetry .NET repository.
  Code has been updated to [1.6.0-beta3](https://github.com/open-telemetry/opentelemetry-dotnet/tree/1.6.0-beta.3).
  ([#40315](https://github.com/Azure/azure-sdk-for-net/pull/40315))

## 1.0.0-beta.8 (2023-10-05)

### Breaking Changes

- Removed package references to the beta versions of `OpenTelemetry.Instrumentation.AspNetCore`, `OpenTelemetry.Instrumentation.Http`, and `OpenTelemetry.Instrumentation.SqlClient`.
  Instead, these packages are now internally vendored within the distro.
  Due to this change, users will no longer be able to access the public APIs of these beta packages.
  Manually adding package references to these instrumentation libraries in an application will cause the internal vendored instrumentation from the distro to be ignored.
  If users choose to add these references, they must ensure to update their configuration subsequently. This includes incorporating the necessary instrumentation using either TracerProviderBuilder or MeterProviderBuilder.

### Other Changes

- Vendored the code of instrumentation libraries `OpenTelemetry.Instrumentation.AspNetCore`, `OpenTelemetry.Instrumentation.Http`, and `OpenTelemetry.Instrumentation.SqlClient` from the OpenTelemetry .NET repository.
  Integrated the forked code and converted all of its public API to internal.
  This ensures that `Azure.Monitor.OpenTelemetry.AspNetCore` has native support for ASP.NET Core, HTTP Client, and SQL instrumentation without needing external beta package references.
- Vendored the code of the `OpenTelemetry.ResourceDetectors.Azure` resource detector from the OpenTelemetry .NET Contrib repository and made its public API internal.
- Removed reference to the `OpenTelemetry.ResourceDetectors.Azure` resource detector package.
- Replaced the project reference for `Azure.Monitor.OpenTelemetry.Exporter` with a 1.0.0 package reference.

## 1.0.0-beta.7 (2023-09-20)

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
