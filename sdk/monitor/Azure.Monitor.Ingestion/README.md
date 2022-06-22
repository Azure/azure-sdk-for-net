# Azure Monitor Ingestion client library for .NET

This section should give out brief introduction of the client library.

* First sentence: **Describe the service** briefly. You can usually use the first line of the service's docs landing page for this (Example: [Cosmos DB docs landing page](https://docs.microsoft.com/azure/cosmos-db/)).
* Next, add a **bulleted list** of the **most common tasks** supported by the package or library, prefaced with "Use the client library for [Product Name] to:". Then, provide code snippets for these tasks in the [Examples](#examples) section later in the document. Keep the task list short but include those tasks most developers need to perform with your package.

  **Resources:**
* [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/src)
* [Package (NuGet)](https://www.nuget.org/packages/Azure.Monitor.Ingestion)
* [API reference documentation](https://docs.microsoft.com/dotnet/api/overview/azure/monitor/ingestion?view=azure-dotnet)
* [Service documentation](https://docs.microsoft.com/azure/azure-monitor/overview)
* [Change log](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.Ingestion/CHANGELOG.md)

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- A [Data Collection Endpoint](https://docs.microsoft.com/azure/azure-monitor/essentials/data-collection-endpoint-overview)
- A [Data Collection Rule](https://docs.microsoft.com/azure/azure-monitor/essentials/data-collection-rule-overview)
- A [Log Analytics workspace](https://docs.microsoft.com/azure/azure-monitor/logs/log-analytics-workspace-overview)

### Install the package

Install the Azure Monitor Ingestion client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Monitor.Ingestion --prerelease
```

### Authenticate the client

An authenticated client is required to ingest data. To authenticate, create an instance of a [TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet) class. Pass it to the constructor of your client class.

## Key concepts

The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

Include the *Thread safety* and *Additional concepts* sections below at the end of your *Key concepts* section. You may remove or add links depending on what your library makes use of:

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/monitor/Azure.Monitor.Ingestion/samples).

### <scenario>

You can create a client and call the client's `<operation>` method.

```C# Snippet:Azure_Monitor_Ingestion_Scenario
Uri dataCollectionEndpoint = new Uri("...");
TokenCredential credential = new DefaultAzureCredential();
string workspaceId = "...";
LogsIngestionClient client = new(dataCollectionEndpoint, credential);
LogsQueryClient logsQueryClient = new LogsQueryClient(credential);

DateTimeOffset currentTime = DateTimeOffset.UtcNow;

BinaryData data = BinaryData.FromObjectAsJson(
    // Use an anonymous type to create the payload
    new[] {
        new
        {
            Time = currentTime,
            Computer = "Computer1",
            AdditionalContext = new
            {
                InstanceName = "user1",
                TimeZone = "Pacific Time",
                Level = 4,
                CounterName = "AppMetric1",
                CounterValue = 15.3
            }
        },
        new
        {
            Time = currentTime,
            Computer = "Computer2",
            AdditionalContext = new
            {
                InstanceName = "user2",
                TimeZone = "Central Time",
                Level = 3,
                CounterName = "AppMetric1",
                CounterValue = 23.5
            }
        },
    });

// Make the request
Response response = client.Upload(TestEnvironment.DCRImmutableId, "Custom-MyTableRawData", RequestContent.Create(data)); //takes StreamName not tablename

LogsBatchQuery batch = new LogsBatchQuery();
string countQueryId = batch.AddWorkspaceQuery(
    workspaceId,
    "MyTable_CL | count;",
    new QueryTimeRange(TimeSpan.FromDays(1)));

Response<LogsBatchQueryResultCollection> responseLogsQuery = logsQueryClient.QueryBatch(batch);

Console.WriteLine("Table entry count: " + responseLogsQuery.Value.GetResult<int>(countQueryId).Single());
```

## Troubleshooting

Describe common errors and exceptions, how to "unpack" them if necessary, and include guidance for graceful handling and recovery.

Provide information to help developers avoid throttling or other service-enforced errors they might encounter. For example, provide guidance and examples for using retry or connection policies in the API.

If the package or a related package supports it, include tips for logging or enabling instrumentation to help them debug their code.

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

This is a template, but your SDK readme should include details on how to contribute code to the repo/package.

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/monitor/Azure.Monitor.Ingestion/README.png)
