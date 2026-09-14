# Multi-endpoint `UseAzureMonitor` ASP.NET Core demo

This ASP.NET Core app enables multi-endpoint routing and uses `UseAzureMonitor` to emit routed
request spans, child spans, logs, and metrics. It references the local ASP.NET Core distro project,
which is configured to reference the local exporter project for development.

Set the distro's host connection string and a comma-separated list of destination connection
strings:

```powershell
$env:MULTIENDPOINT_HOST_CONNECTION_STRING = "<host-connection-string>"
$env:MULTIENDPOINT_ROUTE_CONNECTION_STRINGS = "<route-1-connection-string>,<route-2-connection-string>"
```

Run the app:

```powershell
dotnet run --framework net10.0
```

Emit telemetry for a configured route:

```powershell
Invoke-RestMethod "http://127.0.0.1:5058/emit/route1?count=2"
```

The response contains a run ID for the emitted telemetry. To verify routing, open the destination
Application Insights resource in the Azure portal, select **Monitoring > Logs**, replace
`<run-id>` below with the response value, and run the query. Repeat this in each destination
resource after calling its route to confirm that telemetry landed only in the expected resource.

```kusto
union requests, dependencies, traces, customMetrics
| where tostring(customDimensions["demo.run_id"]) == "<run-id>"
```
