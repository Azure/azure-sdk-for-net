# Azure Quantum Jobs client library for .NET

Use the guidelines in each section of this template to ensure consistency and readability of your README. The README resides in your package's GitHub repository at the root of its directory within the repo. It's also used as the package distribution page (NuGet, PyPi, npm, etc.) and as a Quickstart on docs.microsoft.com. See [Azure.Quantum.Jobs/README.md](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/template/Azure.Template/README.md) for an example following this template.

**Title**: The H1 of your README should be in the format: `# [Product Name] client library for [Language]`

* All headings, including the H1, should use **sentence-style capitalization**. Refer to the [Microsoft Style Guide][style-guide-msft] and [Microsoft Cloud Style Guide][style-guide-cloud] for more information.
* Example: `# Azure Batch client library for Python`

# Azure Template client library for .NET

**Introduction**: The introduction appears directly under the title (H1) of your README.

* **DO NOT** use an "Introduction" or "Overview" heading (H2) for this section.
* First sentence: **Describe the service** briefly. You can usually use the first line of the service's docs landing page for this (Example: [Cosmos DB docs landing page](https://docs.microsoft.com/azure/cosmos-db/)).
* Next, add a **bulleted list** of the **most common tasks** supported by the package or library, prefaced with "Use the client library for [Product Name] to:". Then, provide code snippets for these tasks in the [Examples](#examples) section later in the document. Keep the task list short but include those tasks most developers need to perform with your package.
* Include this single line of links targeting your product's content at the bottom of the introduction, making any adjustments as necessary (for example, NuGet instead of PyPi):

  [Source code](https://github.com/Azure/azure-sdk-for-python/tree/master/sdk/batch/azure-batch) | [Package (PyPi)](https://pypi.org/project/azure-batch/) | [API reference documentation](https://docs.microsoft.com/python/api/overview/azure/batch?view=azure-python) | [Product documentation](https://docs.microsoft.com/azure/batch/)

> TIP: Your README should be as **brief** as possible but **no more brief** than necessary to get a developer new to Azure, the service, or the package up and running quickly. Keep it brief, but include everything a developer needs to make their first API call successfully.

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

First, provide instruction for obtaining and installing the package or library. This section might include only a single line of code, like `pip install package-name`, but should enable a developer to successfully install the package from NuGet, pip, npm, Maven, or even cloning a GitHub repository.

### Prerequisites

Include a section after the install command that details any requirements that must be satisfied before a developer can [authenticate](#authenticate-the-client) and test all of the snippets in the [Examples](#examples) section. For example, for Cosmos DB:

> You must have an [Azure subscription](https://azure.microsoft.com/free/), [Cosmos DB account](https://docs.microsoft.com/azure/cosmos-db/account-overview) (SQL API), and [Python 3.6+](https://www.python.org/downloads/) to use this package.

### Authenticate the client

If your library requires authentication for use, such as for Azure services, include instructions and example code needed for initializing and authenticating.

For example, include details on obtaining an account key and endpoint URI, setting environment variables for each, and initializing the client object.

## Key concepts

The *Key concepts* section should describe the functionality of the main classes. Point out the most important and useful classes in the package (with links to their reference pages) and explain how those classes work together. Feel free to use bulleted lists, tables, code blocks, or even diagrams for clarity.

## Examples

Include code snippets and short descriptions for each task you listed in the [Introduction](#introduction) (the bulleted list). Briefly explain each operation, but include enough clarity to explain complex or otherwise tricky operations.

If possible, use the same example snippets that your in-code documentation uses. For example, use the snippets in your `examples.py` that Sphinx ingests via its [literalinclude](https://www.sphinx-doc.org/en/1.5/markup/code.html?highlight=code%20examples#includes) directive. The `examples.py` file containing the snippets should reside alongside your package's code, and should be tested in an automated fashion.

Each example in the *Examples* section starts with an H3 that describes the example. At the top of this section, just under the *Examples* H2, add a bulleted list linking to each example H3. Each example should deep-link to the types and/or members used in the example.

### Get the thing

The `get_thing` method retrieves a Thing from the service. The `id` parameter is the unique ID of the Thing, not its "name" property.

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

```C# Snippet:Azure_Quantum_Jobs_GetContainerSasUri
// Get container Uri with SAS key
var containerUri = (quantumJobClient.GetStorageSasUri(
    new BlobDetails(storageContainerName))).Value.SasUri;
```

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

```C# Snippet:Azure_Quantum_Jobs_GetJob
// Get the job that we've just created based on its jobId
JobDetails myJob = (quantumJobClient.GetJob(jobId)).Value;
```

```C# Snippet:Azure_Quantum_Jobs_GetJobs
// Get all jobs from the workspace (.ToList() will force all pages to be fetched)
var allJobs = quantumJobClient.GetJobs().ToList();
```

## Next steps

* Provide a link to additional code examples, ideally to those sitting alongside the README in the package's `/samples` directory.
* If appropriate, point users to other packages that might be useful.
* If you think there's a good chance that developers might stumble across your package in error (because they're searching for specific functionality and mistakenly think the package provides that functionality), point them to the packages they might be looking for.

## Contributing

TODO copy from storage blob sample, point to master contributing

<!-- LINKS -->
[style-guide-msft]: https://docs.microsoft.com/style-guide/capitalization
[style-guide-cloud]: https://aka.ms/azsdk/cloud-style-guide

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fquantum%2FAzure.Quantum.Jobs%2FREADME.png)
