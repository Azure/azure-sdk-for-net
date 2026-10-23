# Vendored: OpenTelemetry.Resources.Azure

This folder contains a vendored copy of the
[OpenTelemetry.Resources.Azure](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/tree/Resources.Azure-1.20.1-beta.1/src/OpenTelemetry.Resources.Azure)
resource detectors. The upstream package is still in beta, so this distro carries the source rather than taking a
package dependency.

## Source

| | |
|---|---|
| Repository | [open-telemetry/opentelemetry-dotnet-contrib](https://github.com/open-telemetry/opentelemetry-dotnet-contrib) |
| Release tag | [`Resources.Azure-1.20.1-beta.1`](https://github.com/open-telemetry/opentelemetry-dotnet-contrib/releases/tag/Resources.Azure-1.20.1-beta.1) |
| Commit | `cae14fd3d642fb7bc1c114116b0fff45a11698e8` |

Files copied from `src/OpenTelemetry.Resources.Azure/` (all `*.cs`) into this folder, and from `src/Shared/` into
[`../Shared`](../Shared):

| Upstream `src/Shared` file | Status |
|---|---|
| `HttpClientHelpers.cs` | Synced from the tag (see deviations). |
| `ResourceSemanticConventions.cs` | Synced from the tag. |
| `SchemaUrls.cs` | Synced from the tag. |
| `StopwatchExtensions.cs` | Synced from the tag. |
| `ExceptionExtensions.cs` | Already identical to the tag. |
| `Guard.cs` | **Not re-synced.** Shared with the vendored SqlClient instrumentation; the existing copy already provides every member the detectors use (`ThrowIfNull`, `ThrowIfOutOfRange`). |

## Deviations from upstream

Keep this list up to date. Every change made to the upstream files must be listed here so that the next sync can
re-apply it.

| File | Deviation | Reason |
|---|---|---|
| `AzureResourceBuilderExtensions.cs` | `public static class` changed to `internal static class`. | The detectors are an implementation detail of the distro and must not leak into its public API. |
| `AzureResourcesEventSource.cs` | EventSource name changed from `OpenTelemetry-Resources-Azure` to `OpenTelemetry-AzureMonitor-AspNetCore-Resources-Azure`. | Avoids an EventSource name collision with the `OpenTelemetry.Resources.Azure` package or other vendored copies (Microsoft.OpenTelemetry, Application Insights SDK) loaded in the same process. |
| `AzureVmMetaDataRequestor.cs` | Added `#pragma warning disable AZC0102` / `AZC0104` around the `netstandard2.0` sync-over-async `SendAsync(...).GetAwaiter().GetResult()` call. | Azure SDK analyzers; the upstream code is intentionally synchronous. |
| `../Shared/HttpClientHelpers.cs` | Added `using System.IO;`. | Upstream relies on an implicit global using that this repository does not enable. |
| `../Shared/HttpClientHelpers.cs` | Added `#pragma warning disable AZC0102` around the `netstandard2.0` `ReadAsStreamAsync().GetAwaiter().GetResult()` call. | Azure SDK analyzers; the upstream code is intentionally synchronous. |

## Syncing

1. Pick the latest `Resources.Azure-*` release tag in opentelemetry-dotnet-contrib.
2. Copy `src/OpenTelemetry.Resources.Azure/*.cs` into this folder and the `src/Shared` files listed above into
   [`../Shared`](../Shared). Check the upstream `.csproj` for any new `src/Shared` includes.
3. Re-apply every deviation listed above and update the [Source](#source) table.
4. Review the upstream `CHANGELOG.md` for attribute name or value changes and call out any customer-visible change in
   this package's `CHANGELOG.md` (all resource attributes are exported on the `_OTELRESOURCE_` metric).
