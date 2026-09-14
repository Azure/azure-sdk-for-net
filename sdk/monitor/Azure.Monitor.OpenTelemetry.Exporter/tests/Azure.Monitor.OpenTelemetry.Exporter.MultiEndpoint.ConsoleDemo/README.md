# Multi-endpoint `UseAzureMonitorExporter` console demo

This console app enables multi-endpoint routing and uses `UseAzureMonitorExporter` to emit
traces, logs, and metrics from one OpenTelemetry registration. Its project reference points to the
local Azure Monitor exporter source.

Set the exporter's host connection string and a comma-separated list of destination connection
strings:

```powershell
$env:MULTIENDPOINT_HOST_CONNECTION_STRING = "<host-connection-string>"
$env:MULTIENDPOINT_ROUTE_CONNECTION_STRINGS = "<route-1-connection-string>,<route-2-connection-string>"
```

Run the app with an optional iteration count:

```powershell
dotnet run --framework net10.0 -- 30
```

The app prints a run ID for the emitted telemetry. To verify routing, open each destination
Application Insights resource in the Azure portal, select **Monitoring > Logs**, replace
`<run-id>` below with the printed value, and run the query. Run it separately in every destination
resource to confirm that each resource contains only its assigned route.

```kusto
union requests, dependencies, traces, customMetrics
| where tostring(customDimensions["demo.run_id"]) == "<run-id>"
```
