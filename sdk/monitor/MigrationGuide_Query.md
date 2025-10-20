# How to migrate away from `Azure.Monitor.Query`

To migrate away from the deprecated [Azure.Monitor.Query](https://www.nuget.org/packages/Azure.Monitor.Query) package, see the table below.

| Client name             | Replacement package             | Migration guidance |
|-------------------------|---------------------------------|--------------------|
| `LogsQueryClient`       | [Azure.Monitor.Query.Logs]      | [Guide][mg-lq]     |
| `MetricsClient`         | [Azure.Monitor.Query.Metrics]   | [Guide][mg-mq]     |
| `MetricsQueryClient`    | [Azure.ResourceManager.Monitor] | [Guide][mg-mq]     |

<!-- LINKS -->
[Azure.Monitor.Query.Logs]: https://www.nuget.org/packages/Azure.Monitor.Query.Logs
[Azure.Monitor.Query.Metrics]: https://www.nuget.org/packages/Azure.Monitor.Query.Metrics
[Azure.ResourceManager.Monitor]: https://www.nuget.org/packages/Azure.ResourceManager.Monitor
[mg-lq]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Logs/MigrationGuide.md
[mg-mq]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Query.Metrics/MigrationGuide.md
