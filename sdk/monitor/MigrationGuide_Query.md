# How to migrate away from `Azure.Monitor.Query`

To migrate away from the deprecated [Azure.Monitor.Query](https://www.nuget.org/packages/Azure.Monitor.Query) package, see the table below.

| Client name          | Replacement package             | Migration guidance |
|----------------------|---------------------------------|--------------------|
| `LogsQueryClient`    | [Azure.Monitor.Query.Logs]      | [Guide][mg-lq]     |
| `MetricsClient`      | [Azure.Monitor.Query.Metrics]   | [Guide][mg-mc]     |
| `MetricsQueryClient` | [Azure.ResourceManager.Monitor] | [Guide][mg-mqc]    |

<!-- LINKS -->
[Azure.Monitor.Query.Logs]: https://www.nuget.org/packages/Azure.Monitor.Query.Logs
[Azure.Monitor.Query.Metrics]: https://www.nuget.org/packages/Azure.Monitor.Query.Metrics
[Azure.ResourceManager.Monitor]: https://www.nuget.org/packages/Azure.ResourceManager.Monitor
[mg-lq]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/MigrationGuide.md
[mg-mc]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Metrics/MigrationGuide.md
[mg-mqc]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.ResourceManager.Monitor/MigrationGuide.md
