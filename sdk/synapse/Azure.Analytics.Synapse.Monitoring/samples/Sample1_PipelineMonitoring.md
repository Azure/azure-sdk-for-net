# Monitoring Synapse Spark Jobs

This sample demonstrates basic operations with a core classes in this library: `MonitoringClient`. `MonitoringClient` is used to monitor Spark Jobs running on Azure Synapse - each method call sends a request to the service's REST API. The sample walks through the basics of monitoring Spark jobs. To get started, you'll need a connection endpoint to Azure Synapse. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/synapse/Azure.Analytics.Synapse.Monitoring/README.md) for links and instructions.

## Create pipeline client

To monitor Spark jobs on Azure Synapse, you need to instantiate a `MonitoringClient`. It requires an endpoint URL and a `TokenCredential`.

```C# Snippet:CreateMonitoringClient
string endpoint = TestEnvironment.EndpointUrl;
MonitoringClient client = new MonitoringClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Create monitoring client

Calling `GetSparkJobList` on the `MonitoringClient` returns a list of jobs both currently and previously ran in the Synapse Workspace. Each `SparkJob` instance contains information the respective Spark job, including its name, current state, and duration of execution.

```C# Snippet:GetSparkJobList
SparkJobListViewResponse sparkJobList = client.GetSparkJobList();
foreach (var sparkJob in sparkJobList.SparkJobs)
{
    if (sparkJob.State == "Running")
    {
        Console.WriteLine ($"{sparkJob.Name} has been running for {sparkJob.RunningDuration}");
    }
    else
    {
        Console.WriteLine ($"{sparkJob.Name} has been in {sparkJob.State} for {sparkJob.QueuedDuration}");
    }
}
```

## Obtaining SQL Job Query

To obtain a OD/DW (Dedicated SQL pool/Data Warehouse) Query string for the workspace call `GetSqlJobQueryString`.

```C# Snippet:GetSqlJobQueryString
SqlQueryStringDataModel sqlQuery = client.GetSqlJobQueryString();
```
