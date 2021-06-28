# Azure Quantum Jobs client library for .NET

Azure Quantum is a Microsoft Azure service that you can use to run quantum computing programs or solve optimization problems in the cloud.  Using the Azure Quantum tools and SDKs, you can create quantum programs and run them against different quantum simulators and machines.  You can use the Azure.Quantum.Jobs client library t
- Create, enumerate, and cancel quantum jobs
- Enumerate provider status and quotas

  [Source code][source] | [API reference documentation](https://docs.microsoft.com/qsharp/api/) | [Product documentation](https://docs.microsoft.com/azure/quantum/)

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the Azure Quantum Jobs client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Quantum.Jobs --prerelease -v 1.0.0-beta.1
```

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/), [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API), and [Python 3.6+](https://www.python.org/downloads/) to use this package.

### Authenticate the client

To authenticate with the service, the workspace will use [DefaultAzureCredential](https://docs.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) internally. This will try different authentication mechanisms based on the environment (e.g. Environment Variables, ManagedIdentity, CachedTokens) and finally it will fallback to [InteractiveBrowserCredential](https://docs.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet).

Workspace will also allow the user to override the above behavior by passing their own [TokenCredential](https://docs.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet).

`TokenCredential` is the default Authentication mechanism used by Azure SDKs.

## Key concepts

`QuantumJobClient` is the root class to be used to authenticate and create, enumerate, and cancel jobs.

`JobDetails` contains all the properties of a job.

`ProviderStatus` contains status information for a provider.

`QuantumJobQuota` contains quota properties.

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

* [Get Container SAS URI](#get-container-sas-uri)
* [Upload Input Data](#upload-input-data)
* [Create The Job](#create-the-job)
* [Get Job](#get-job)
* [Get Jobs](#get-jobs)

### Create the client

Create an instance of the QuantumJobClient by passing in these parameters:
- [Subscription][subscriptions] - looks like XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX and can be found in your list of subscriptions on azure
- [Resource Group][resource-groups] - a container that holds related resources for an Azure solution 
- [Workspace][workspaces] - a collection of assets associated with running quantum or optimization applications
- [Location][location] - choose the best data center by geographical region 
- [StorageContainerName][blob-storage] - your blob storage 
- [Credential][credentials] - used to authenticate 

```C# Snippet:Azure_Quantum_Jobs_CreateClient
// Create a QuantumJobClient
var subscriptionId = "your_subscription_id";
var resourceGroupName = "your_resource_group_name";
var workspaceName = "your_quantum_workspace_name";
var location = "your_location";
var storageContainerName = "your_container_name";
var credential = new DefaultAzureCredential(true);

var quantumJobClient =
    new QuantumJobClient(
        subscriptionId,
        resourceGroupName,
        workspaceName,
        location,
        credential);
```

### Get Container SAS URI

Create a storage container where to put your data.

```C# Snippet:Azure_Quantum_Jobs_GetContainerSasUri
// Get container Uri with SAS key
var containerUri = (quantumJobClient.GetStorageSasUri(
    new BlobDetails(storageContainerName))).Value.SasUri;
```

### Upload Input Data

Using the SAS URI, upload the json input data to the blob client.
This contains the parameters to be used with [Quantum Inspired Optimizations](https://docs.microsoft.com/azure/quantum/optimization-overview-introduction)

```C# Snippet:Azure_Quantum_Jobs_UploadInputData
// Get input data blob Uri with SAS key
string blobName = $"myjobinput.json";
var inputDataUri = (quantumJobClient.GetStorageSasUri(
    new BlobDetails(storageContainerName)
    {
        BlobName = blobName,
    })).Value.SasUri;

// Upload input data to blob
var blobClient = new BlobClient(new Uri(inputDataUri));
var problemFilename = "problem.json";
blobClient.Upload(problemFilename, overwrite: true);
```

### Create The Job

Now that you've uploaded your problem definition to Azure Storage, you can use `CreateJob` to define an Azure Quantum job.

```C# Snippet:Azure_Quantum_Jobs_CreateJob
// Submit job
var jobId = $"job-{Guid.NewGuid():N}";
var jobName = $"jobName-{Guid.NewGuid():N}";
var inputDataFormat = "microsoft.qio.v2";
var outputDataFormat = "microsoft.qio-results.v2";
var providerId = "microsoft";
var target = "microsoft.paralleltempering-parameterfree.cpu";
var createJobDetails = new JobDetails(containerUri, inputDataFormat, providerId, target)
{
    Id = jobId,
    InputDataUri = inputDataUri,
    Name = jobName,
    OutputDataFormat = outputDataFormat
};
JobDetails createdJob = (quantumJobClient.CreateJob(jobId, createJobDetails)).Value;
```

### Get Job

`GetJob` retrieves a specific job by its id.

```C# Snippet:Azure_Quantum_Jobs_GetJob
// Get the job that we've just created based on its jobId
JobDetails myJob = (quantumJobClient.GetJob(jobId)).Value;
```

### Get Jobs

To enumerate all the jobs in the workspace, use the `GetJobs` method.

```C# Snippet:Azure_Quantum_Jobs_GetJobs
foreach (JobDetails job in quantumJobClient.GetJobs())
{
    Console.WriteLine($"{job.Name}");
}
```


## Troubleshooting

All Quantum Jobs service operations will throw a RequestFailedException on failure with helpful ErrorCodes. Many of these errors are recoverable.

## Next steps

*  Visit our [Product documentation](https://docs.microsoft.com/azure/quantum/) to learn more about Azure Quantum.
## Contributing

See the [CONTRIBUTING.md][contributing] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.


<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/quantum/Azure.Quantum.Jobs/src
[resource-groups]: https://docs.microsoft.com/azure/azure-resource-manager/management/manage-resource-groups-portal
[workspaces]: https://docs.microsoft.com/azure/quantum/how-to-create-quantum-workspaces-with-the-azure-portal
[location]: https://azure.microsoft.com/global-infrastructure/services/?products=quantum
[blob-storage]: https://docs.microsoft.com/azure/storage/blobs/storage-blobs-introduction
[contributing]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[subscriptions]: https://ms.portal.azure.com/#blade/Microsoft_Azure_Billing/SubscriptionsBlade
[credentials]: https://docs.microsoft.com/dotnet/api/overview/azure/identity-readme#credentials
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fquantum%2FAzure.Quantum.Jobs%2FREADME.png)
