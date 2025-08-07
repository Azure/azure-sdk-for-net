# Azure Synapse Analytics Monitoring client library for .NET

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](https://azure.microsoft.com/develop/net/).

Azure Synapse Analytics provides a rich monitoring experience within the Azure portal to surface insights regarding your data warehouse workload. The Azure Synapse Analytics monitoring client library enables programmatically monitoring your resources.

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs.

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](https://azure.microsoft.com/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package

Install the Azure Synapse Analytics monitoring client library for .NET with [NuGet](https://www.nuget.org/packages/Azure.Analytics.Synapse.Monitoring/):

```dotnetcli
dotnet add package Azure.Analytics.Synapse.Monitoring --prerelease
```

### Prerequisites

- **Azure Subscription:** To use Azure services, including Azure Synapse, you'll need a subscription. If you do not have an existing Azure account, you may sign up for a [free trial](https://azure.microsoft.com/free/dotnet/) or use your [Visual Studio Subscription](https://visualstudio.microsoft.com/subscriptions/) benefits when you [create an account](https://azure.microsoft.com/account).
- An existing Azure Synapse workspace. If you need to create an Azure Synapse workspace, you can use the [Azure Portal](https://portal.azure.com/) or [Azure CLI](https://learn.microsoft.com/cli/azure).

If you use the Azure CLI, the command looks like below:

```PowerShell
az synapse workspace create \
    --name <your-workspace-name> \
    --resource-group <your-resource-group-name> \
    --storage-account <your-storage-account-name> \
    --file-system <your-storage-file-system-name> \
    --sql-admin-login-user <your-sql-admin-user-name> \
    --sql-admin-login-password <your-sql-admin-user-password> \
    --location <your-workspace-location>
```

### Authenticate the client

In order to interact with the Azure Synapse Analytics service, you'll need to create an instance of the [MonitoringClient](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/synapse/Azure.Analytics.Synapse.Monitoring/src/Generated/MonitoringClient.cs) class. You need a **workspace endpoint**, which you may see as "Development endpoint" in the portal,
and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity). To use the [DefaultAzureCredential](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#defaultazurecredential) provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

## Key concepts

### MonitoringClient

With a `MonitoringClient` you can get list of Spark applications or SQL OD/DW query for the workspace.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->

[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)

<!-- CLIENT COMMON BAR -->

## Examples

The Azure.Analytics.Synapse.Monitoring package supports synchronous and asynchronous APIs. The following section covers some of the most common Azure Synapse Analytics monitoring related tasks:

### Monitoring examples

- [Get list of Spark applications](#get-list-of-spark-applications)
- [Get SQL query](#get-sql-query)

### Get list of Spark applications

`GetSparkJobList` gets a list of spark applications for the workspace.

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

### Get SQl query

`GetSqlJobQueryString` gets the SQL OD/DW query

```C# Snippet:GetSqlJobQueryString
SqlQueryStringDataModel sqlQuery = client.GetSqlJobQueryString();
```

## To build

For information on building the Azure Synapse client library, please see [Building the Microsoft Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net#to-build)

## Target frameworks

For information about the target frameworks of the Azure Synapse client library, please refer to the [Target Frameworks](https://github.com/azure/azure-sdk-for-net#target-frameworks) of the Microsoft Azure SDK for .NET.

## Troubleshooting

Please open issue in github.

## Next steps

The next step is adding more examples

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
