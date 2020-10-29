# Azure Synapse Analytics Monitoring client library for .NET

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](https://azure.microsoft.com/develop/net/).

Azure Synapse Analytics provides a rich monitoring experience within the Azure portal to surface insights regarding your data warehouse workload. The Azure Synapse Analytics monitoring client library enables programmatically monitoring your resources.

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs. 

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](https://azure.microsoft.com/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package
Install the Azure Synapse Analytics monitoring client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Analytics.Synapse.Monitoring --version 1.0.0-preview.1
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Azure Synapse workspace. If you need to create an Azure Synapse workspace, you can use the Azure Portal or [Azure CLI][azure_cli].

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
In order to interact with the Azure Synapse Analytics service, you'll need to create an instance of the [MonitoringClient][monitoring_client_class] class. You need a **workspace endpoint**, which you may see as "Development endpoint" in the portal,
 and **client secret credentials (client id, client secret, tenant id)** to instantiate a client object.

Client secret credential authentication is being used in this getting started section but you can find more ways to authenticate with [Azure identity][azure_identity]. To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, you should install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
```

## Key concepts

### MonitoringClient
With a `MonitoringClient` you can get list of Spark applications or SQL OD/DW query for the workspace.

## Examples
The Azure.Analytics.Synapse.Monitoring package supports synchronous and asynchronous APIs. The following section covers some of the most common Azure Synapse Analytics monitoring related tasks:

### Monitoring examples
* [Get list of Spark applications](#get-list-of-spark-applications)
* [Get SQL query](#get-sql-query)

### Get list of Spark applications

`GetSparkJobList` gets a list of spark applications for the workspace.

```C# Snippet:GetSparkJobList
SparkJobListViewResponse sparkJobList = client.GetSparkJobList();
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
