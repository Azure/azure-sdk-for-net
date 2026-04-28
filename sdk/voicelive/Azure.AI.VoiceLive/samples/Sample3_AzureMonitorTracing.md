# Azure Monitor Tracing

This sample demonstrates how to export VoiceLive spans to Azure Monitor (Application Insights) for production observability.

## Configure the Azure Monitor exporter

Supply your Application Insights connection string and replace the console exporter with `AddAzureMonitorTraceExporter`:

```csharp
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
    .AddSource("Azure.AI.VoiceLive")
    .AddAzureMonitorTraceExporter(o => o.ConnectionString = connectionString)
    .Build();
```

The `connectionString` variable above should be set to your Application Insights connection string, for example from `Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")`.

## Required packages

```bash
dotnet add package OpenTelemetry
dotnet add package Azure.Monitor.OpenTelemetry.Exporter
```

## Environment variables

| Variable | Required | Description |
|---|---|---|
| `AZURE_VOICELIVE_ENDPOINT` | **Yes** | VoiceLive endpoint URL |
| `AZURE_VOICELIVE_API_KEY` | **Yes** | API key |
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | **Yes** | Application Insights connection string |
| `AZURE_VOICELIVE_MODEL` | No | Model deployment name. Defaults to `gpt-4o-realtime-preview`. |

## See also

- [Sample2_ConsoleTracing.md](Sample2_ConsoleTracing.md) — console exporter for local development
- [Sample4_CustomAttributes.md](Sample4_CustomAttributes.md) — attach custom tags to every span
