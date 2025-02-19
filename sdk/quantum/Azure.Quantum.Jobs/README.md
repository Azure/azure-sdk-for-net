# Azure Quantum Jobs client library for .NET

Azure Quantum is a Microsoft Azure service that you can use to run quantum computing programs in the cloud.  Using the Azure Quantum tools and SDKs, you can create quantum programs and run them against different quantum simulators and machines.  You can use the Azure.Quantum.Jobs client library to:
- Create, enumerate, and cancel quantum jobs
- Enumerate provider status and quotas

  [Source code][source] | [API reference documentation](https://learn.microsoft.com/qsharp/api/) | [Product documentation](https://learn.microsoft.com/azure/quantum/)

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the Azure Quantum Jobs client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Quantum.Jobs --prerelease
```

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/), [Cosmos DB account](https://learn.microsoft.com/azure/cosmos-db/account-overview) (SQL API), and [Python 3.6+](https://www.python.org/downloads/) to use this package.

### Authenticate the client

To authenticate with the service, the workspace will use [DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) internally. This will try different authentication mechanisms based on the environment (e.g. Environment Variables, ManagedIdentity, CachedTokens) and finally it will fallback to [InteractiveBrowserCredential](https://learn.microsoft.com/dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet).

Workspace will also allow the user to override the above behavior by passing their own [TokenCredential](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential?view=azure-dotnet).

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
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
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
- [Workspace][workspaces] - a collection of assets associated with running quantum
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

### Compile your quantum program into QIR

This step can be done in multiple ways and it is not in scope for this sample.

[Quantum Intermediate Representation (QIR)](https://github.com/qir-alliance/qir-spec) is a [QIR Alliance](https://www.qir-alliance.org/) specification to represent quantum programs within the [LLVM](https://llvm.org/) Intermediate Representation (IR).

A few methods to compile or generate a quantum program into QIR:
- [Q# compiler](https://github.com/microsoft/qsharp-compiler/): Can be used to [compile Q# Code into QIR](https://github.com/microsoft/qsharp-compiler/tree/main/src/QsCompiler/QirGeneration).
- [PyQIR](https://github.com/qir-alliance/pyqir): PyQIR is a set of APIs for generating, parsing, and evaluating Quantum Intermediate Representation (QIR).
- [IQ#](https://github.com/microsoft/iqsharp): Can be used to compile a Q# program into QIR with the [%qir](https://learn.microsoft.com/qsharp/api/iqsharp-magic/qir) magic command.

In this sample, we assume you already have a file with the QIR bitcode and you know the method name that you want to execute (entry point).

We will use the QIR bitcode sample (./samples/BellState.bc), compiled a Q# code (./samples/BellState.qs) targeting the `quantinuum.sim.h1-1e` target, with `AdaptiveExecution` target capability.

### Upload Input Data

Using the SAS URI, upload the QIR bitcode input data to the blob client.

```C# Snippet:Azure_Quantum_Jobs_UploadQIRBitCode
string qirFilePath = "./BellState.bc";

// Get input data blob Uri with SAS key
string blobName = Path.GetFileName(qirFilePath);
var inputDataUri = (quantumJobClient.GetStorageSasUri(
    new BlobDetails(storageContainerName)
    {
        BlobName = blobName,
    })).Value.SasUri;

// Upload QIR bitcode to blob storage
var blobClient = new BlobClient(new Uri(inputDataUri));
var blobHeaders = new BlobHttpHeaders
{
    ContentType = "qir.v1"
};
var blobUploadOptions = new BlobUploadOptions { HttpHeaders = blobHeaders };
using (FileStream qirFileStream = File.OpenRead(qirFilePath))
{
    blobClient.Upload(qirFileStream, options: blobUploadOptions);
}
```

### Create The Job

Now that you've uploaded your QIR program bitcode to Azure Storage, you can use `CreateJob` to define an Azure Quantum job.

```C# Snippet:Azure_Quantum_Jobs_CreateJob
// Submit job
var jobId = $"job-{Guid.NewGuid():N}";
var jobName = $"jobName-{Guid.NewGuid():N}";
var inputDataFormat = "qir.v1";
var outputDataFormat = "microsoft.quantum-results.v1";
var providerId = "quantinuum";
var target = "quantinuum.sim.h1-1e";
var inputParams = new Dictionary<string, object>()
{
    { "entryPoint", "ENTRYPOINT__BellState" },
    { "arguments", new string[] { } },
    { "targetCapability", "AdaptiveExecution" },
};
var createJobDetails = new JobDetails(containerUri, inputDataFormat, providerId, target)
{
    Id = jobId,
    InputDataUri = inputDataUri,
    Name = jobName,
    InputParams = inputParams,
    OutputDataFormat = outputDataFormat
};

JobDetails myJob = (quantumJobClient.CreateJob(jobId, createJobDetails)).Value;
```

### Get Job

`GetJob` retrieves a specific job by its id.

```C# Snippet:Azure_Quantum_Jobs_GetJob
// Get the job that we've just created based on its jobId
myJob = (quantumJobClient.GetJob(jobId)).Value;
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

*  Visit our [Product documentation](https://learn.microsoft.com/azure/quantum/) to learn more about Azure Quantum.
## Contributing

See the [CONTRIBUTING.md][contributing] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit https://cla.microsoft.com.

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact opencode@microsoft.com with any
additional questions or comments.


<!-- LINKS -->
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/quantum/Azure.Quantum.Jobs/src
[resource-groups]: https://learn.microsoft.com/azure/azure-resource-manager/management/manage-resource-groups-portal
[workspaces]: https://learn.microsoft.com/azure/quantum/how-to-create-quantum-workspaces-with-the-azure-portal
[location]: https://azure.microsoft.com/global-infrastructure/services/?products=quantum
[blob-storage]: https://learn.microsoft.com/azure/storage/blobs/storage-blobs-introduction
[contributing]: https://github.com/Azure/azure-sdk-for-net/tree/main/CONTRIBUTING.md
[subscriptions]: https://ms.portal.azure.com/#blade/Microsoft_Azure_Billing/SubscriptionsBlade
[credentials]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme#credentials
[style-guide-msft]: https://learn.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide
