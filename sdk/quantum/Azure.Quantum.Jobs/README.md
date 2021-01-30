# Azure Quantum Jobs client library for .NET

Azure Quantum is a Microsoft Azure service that you can use to run quantum computing programs or solve optimization problems in my cloud. Using the Azure Quantum tools and SDKs, you can create quantum programs and run them against different quantum simulators and machines.

- Create, enumerate, and cancel quantum jobs
- Enumerate provider status and quotas

  [Source code][source] | [Package (NuGet)][package] | [API reference documentation](https://docs.microsoft.com/python/api/overview/azure/batch?view=azure-python) | [Product documentation](https://docs.microsoft.com/azure/batch/)

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

First, provide instruction for obtaining and installing the package or library. This section might include only a single line of code, like `pip install package-name`, but should enable a developer to successfully install the package from NuGet, pip, npm, Maven, or even cloning a GitHub repository.

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/), [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API), and [Python 3.6+](https://www.python.org/downloads/) to use this package.

### Authentication

To authenticate with the service, the workspace will use [DefaultAzureCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) internally. This will try different authentication mechanisms based on the environment (e.g. Environment Variables, ManagedIdentity, CachedTokens) and finally it will fallback to [InteractiveBrowserCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.identity.interactivebrowsercredential?view=azure-dotnet).

Workspace will also allow the user to override the above behavior by passing their own [TokenCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.core.tokencredential?view=azure-dotnet).

In case the user already has an access token (using MSAL manually or even an external library), we will add an overload that accepts the access token string.

`TokenCredential` is the default Authentication mechanism used by Azure SDKs.

## Key concepts

TODO The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

## Examples

* [Get Container SAS URI](#get-container-sas-uri)
* [Upload Input Data](#upload-input-data)
* [Create The Job](#create-the-job)
* [Get Job](#get-job)
* [Get Jobs](#get-jobs)

### Create the client

Create an instance of the QuantumJobClient by passing in these parameters:
- Subscription Id - looks like XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX and can be found in your list of subscriptions [subscriptions]
- Resource Group Name - TODO
- Location - TODO
- StorageContainerName - TODO
- Credential - TODO

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
TODO - describe what is contains

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

Now that you have the blob input data initialized, fill in the job fields and pass it to the CreateJob() function.

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

To retrieve a specific job by its job id, you can use this function.

```C# Snippet:Azure_Quantum_Jobs_GetJob
// Get the job that we've just created based on its jobId
JobDetails myJob = (quantumJobClient.GetJob(jobId)).Value;
```

### Get Jobs

To enumerate all the jobs in the workspace, use the GetJobs() function.

```C# Snippet:Azure_Quantum_Jobs_GetJobs
foreach (JobDetails job in quantumJobClient.GetJobs())
{
    Console.WriteLine($"{job.Name}");
}
```

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/quantum/Azure.Quantum.Jobs/src
[package]: https://www.nuget.org/packages/Azure.Quantum.Jobs/
[contributing]: https://github.com/Azure/azure-sdk-for-net/tree/master/CONTRIBUTING.md
[subscriptions]: https://ms.portal.azure.com/#blade/Microsoft_Azure_Billing/SubscriptionsBlade
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fquantum%2FAzure.Quantum.Jobs%2FREADME.png)
