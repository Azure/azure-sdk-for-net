# Azure Synapse client library for .NET

Azure Synapse is a limitless analytics service that brings together enterprise data warehousing and Big Data analytics. It gives you the freedom to query data on your terms, using either serverless on-demand or provisioned resources—at scale. Azure Synapse brings these two worlds together with a unified experience to ingest, prepare, manage, and serve data for immediate BI and machine learning needs. 

This directory contains the open source subset of the .NET SDK. For documentation of the complete Azure SDK, please see the [Microsoft Azure .NET Developer Center](https://azure.microsoft.com/develop/net/).

Use the client library for Synapse to:

- Submit Spark Batch job and Spark Session Job
- Support management the ACL of Workspace

## Getting started

The complete Microsoft Azure SDK can be downloaded from the [Microsoft Azure Downloads Page](https://azure.microsoft.com/downloads/?sdk=net) and ships with support for building deployment packages, integrating with tooling, rich command line tooling, and more.

For the best development experience, developers should use the official Microsoft NuGet packages for libraries. NuGet packages are regularly updated with new functionality and hotfixes.

### Install the package

Install the Azure Synapse client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Microsoft.Azure.Synapse --prerelease
```

### Prerequisites

- Microsoft Azure Subscription: To call Microsoft Azure services, including Azure Synapse, you need to first [create an account](https://account.windowsazure.com/Home/Index). If you do not have an existing Azure account, you may sign up for a free trial or use your MSDN subscriber benefits.

- The Azure Synapse client library shares the same [Prerequisites](https://github.com/azure/azure-sdk-for-net#prerequisites) as the Microsoft Azure SDK for .NET.

## Examples
The Microsoft.Azure.Synapse supports the CRUD of spark batch job.

### Spark Batch Job examples
* [List spark batch job](#list-spark-batch-job)
* [Create spark batch job](#create-spark-batch-job)
* [Delete spark batch job](#delete-spark-batch-job)

### List spark batch job
List the spark batch job under the specific spark pool of a specific synapse workspace

```C#
ExtendedLivyListBatchResponse listBatchResponse = synapseClient.SparkBatch.List(workspaceName, sparkPoolName);

Console.WriteLine(listBatchResponse.Total);
```

### Create spark batch job
Create spark batch job under specific workspace and spark pool.

```C#
    ExtendedLivyBatchRequest batchRequest = new ExtendedLivyBatchRequest()
    {
        Name = "WordCount_Java",
        ClassName = "WordCount",

        // The abfss path of the file
        File = "abfss://yourfilesystem@{your adlsgen2 account name}.dfs.core.windows.net/{your path}/wordcount.jar",

        Args= new List<string>
        {
            "abfss://yourfilesystem@{your adlsgen2 account name}.dfs.core.windows.net/{your path}/input.txt",
            "abfss://yourfilesystem@{your adlsgen2 account name}.dfs.core.windows.net/{your path}/result"
        },

        DriverCores = 2,
        DriverMemory = "4G",
        ExecutorCores = 2,
        NumExecutors = 2,
        ExecutorMemory = "4G",
    };

    var batchJob = synapseClient.SparkBatch.Create(workspaceName, sparkPoolName, batchRequest);

    Console.WriteLine(ExtractSparkBatchJobInfomation(batchJob));
}
```

### Delete spark batch job
Delete a spark batch job with spark batch id under specific workspace and spark pool.

```C#
synapseClient.SparkBatch.Delete(workspaceName, sparkPoolName, sparkBatchId);
```
       
## To build

For information on building the Azure Synapse client library, please see [Building the Microsoft Azure SDK for .NET](https://github.com/azure/azure-sdk-for-net#to-build)

## Target frameworks

For information about the target frameworks of the Azure Synapse client library, please refer to the [Target Frameworks](https://github.com/azure/azure-sdk-for-net#target-frameworks) of the Microsoft Azure SDK for .NET.  

## Key concepts

Submit spark job.

## Troubleshooting

Please open issue in github.

## Next steps

The next step is adding more examples

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
