# Azure Batch client library for .NET

Azure Batch allows users to run large-scale parallel and high-performance computing (HPC) batch jobs efficiently in Azure.  

Use the client library for to:

* Create and manage Batch jobs and tasks
* View and perform operations on nodes in a Batch pool

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://learn.microsoft.com/dotnet/api/overview/azure/batch?view=azure-dotnet) | [Product documentation](https://learn.microsoft.com/azure/batch/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Compute.Batch --prerelease
```

### Prerequisites

- An Azure account with an active subscription. If you don't have one, [create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).

- A Batch account with a linked Azure Storage account. You can create the accounts by using any of the following methods: [Azure CLI](https://learn.microsoft.com/azure/batch/quick-create-cli) | [Azure portal](https://learn.microsoft.com/azure/batch/quick-create-portal) | [Bicep](https://learn.microsoft.com/azure/batch/quick-create-bicep) | [ARM template](https://learn.microsoft.com/azure/batch/quick-create-template) | [Terraform](https://learn.microsoft.com/azure/batch/quick-create-terraform).

- [Visual Studio 2019](https://www.visualstudio.com/vs) or later, or the [.NET SDK](https://dotnet.microsoft.com/download/dotnet) version 6.0 or later.

### Authenticate the client

Batch account access supports two methods of authentication: Shared Key and Microsoft Entra ID.

We strongly recommend using Microsoft Entra ID for Batch account authentication. Some Batch capabilities require this method of authentication, including many of the security-related features discussed here. The service API authentication mechanism for a Batch account can be restricted to only Microsoft Entra ID using the [allowedAuthenticationModes](https://learn.microsoft.com/rest/api/batchmanagement/batch-account/create?view=rest-batchmanagement-2024-02-01&tabs=HTTP) property. When this property is set, API calls using Shared Key authentication will be rejected.

#### Authenticate using Microsoft Entra ID

Azure Batch provides integration with Microsoft Entra ID for identity-based authentication of requests. With Azure AD, you can use role-based access control (RBAC) to grant access to your Azure Batch resources to users, groups, or applications. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) provides easy Microsoft Entra ID support for authentication.


```C# Snippet:Batch_Readme_EntraIDCredential
var credential = new DefaultAzureCredential();
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), credential);
```

#### Authenticate using Shared Key

You can also use Shared Key authentication to sign into your Batch account. This method uses your Batch account access keys to authenticate Azure commands for the Batch service.  You can find your batch account shared keys in the portal under the "keys" section or you can run the following [CLI command](https://learn.microsoft.com/cli/azure/batch/account/keys?view=azure-cli-latest) 

```bash
az batch account keys list --name <your-batch-account> --resource-group <your-resource-group-name>
```

```C# Snippet:Batch_Readme_AzureNameKeyCredential
var credential = new AzureNamedKeyCredential("<your account>", "BatchAccountKey");
BatchClient _batchClient = new BatchClient(
    new Uri("https://<your account>.eastus.batch.azure.com"),
    credential);
```

## Key concepts

[Azure Batch Overview](https://learn.microsoft.com/azure/batch/batch-technical-overview)

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking?tabs=csharp) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The Azure.Compute.Batch package supports synchronous and asynchronous APIs.

The following section provides several synchronous code snippets covering some of the most common Azure Batch related tasks:

* [Create a pool](#create-a-pool)
* [Retrieve a pool](#retrieve-a-pool)
* [List pools ](#list-pools)
* [Retrieve a node](#retrieve-a-node)
* [List nodes](#list-nodes)
* [Create a job](#create-a-job)
* [Retrieve a job](#retrieve-a-job)
* [List jobs](#list-jobss)
* [Create a task](#create-a-task)
* [Retrieve a task](#retrieve-a-task)
* [Retrieve an output file from a task](#retrieve-an-output-file-from-a-task)

### Create a Pool

In an Azure Batch workflow, a compute node (or node) is a virtual machine that processes a portion of your application's workload. A pool is a collection of these nodes for your application to runs on. For more information see [Nodes and pools in Azure Batch](https://learn.microsoft.com/azure/batch/nodes-and-pools).

Use the `CreatePool` method with a `BatchPoolCreateContent` instance to create a `BatchPool`. 

```C# Snippet:Batch_Readme_PoolCreation
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

string poolID = "HelloWorldPool";

ImageReference imageReference = new ImageReference()
{
    Publisher = "MicrosoftWindowsServer",
    Offer = "WindowsServer",
    Sku = "2019-datacenter-smalldisk",
    Version = "latest"
};

VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

BatchPoolCreateContent batchPoolCreateOptions = new BatchPoolCreateContent(
poolID, "STANDARD_D1_v2")
{
    VirtualMachineConfiguration = virtualMachineConfiguration,
    TargetDedicatedNodes = 2,
};

// create pool
_batchClient.CreatePool(batchPoolCreateOptions);
```

### Retrieve a Pool

`GetPool` can be used to retrieve created pools

```C# Snippet:Batch_Readme_PoolRetreival
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchPool batchPool = _batchClient.GetPool("poolID");

Console.WriteLine(batchPool.Id);
Console.WriteLine(batchPool.Url);
Console.WriteLine(batchPool.AllocationState);
```

### List Pools

`GetPools` can be used to list all pools under the Batch account

```C# Snippet:Batch_Readme_ListPools
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchPool item in _batchClient.GetPools())
{
    Console.WriteLine(item.Id);
}
```

### Retrieve a Node

A node is an Azure virtual machine (VM) that is dedicated to processing a portion of your application's workload. The size of a node determines the number of CPU cores, memory capacity, and local file system size that is allocated to the node. For more information see [Nodes and pools in Azure Batch](https://learn.microsoft.com/azure/batch/nodes-and-pools).

`GetNode` can be used to retrieve an allocated `BatchNode` from a pool.

```C# Snippet:Batch_Readme_NodeRetreival
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchNode batchNode = _batchClient.GetNode("<poolId>", "<nodeId>");
Console.WriteLine(batchNode.Id);
Console.WriteLine(batchNode.Url);
Console.WriteLine(batchNode.State);
```

### List Nodes

`GetNodes` can be used to list all `BatchNode` allocated under a pool

```C# Snippet:Batch_Readme_ListNodes
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchNode item in _batchClient.GetNodes("poolID"))
{
    Console.WriteLine(item.Id);
}
```

### Create a Job
A job is a collection of tasks. It manages how computation is performed by its tasks on the compute nodes in a pool.

A job specifies the pool in which the work is to be run. You can create a new pool for each job, or use one pool for many jobs. You can create a pool for each job that is associated with a job schedule, or one pool for all jobs that are associated with a job schedule. For more information see [Jobs and tasks in Azure Batch](https://learn.microsoft.com/azure/batch/jobs-and-tasks).

Use the `CreateJob` method with a `BatchJobCreateContent` instance to create a `BatchJob`. 

```C# Snippet:Batch_Readme_JobCreation
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

_batchClient.CreateJob(new BatchJobCreateContent("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
```

### Retrieve a job

`GetJob` can be used to retrieve a created `BatchJob`

```C# Snippet:Batch_Readme_JobRetreival
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJob batchJob = _batchClient.GetJob("jobID");
Console.WriteLine(batchJob.Id);
Console.WriteLine(batchJob.State);
```

### List jobs

`GetJobs` can be used to list all `BatchJob` allocated under a Batch Account

```C# Snippet:Batch_Readme_ListJobs
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchJob item in _batchClient.GetJobs())
{
    Console.WriteLine(item.Id);
}
```

### Create a task

A task is a unit of computation that is associated with a job. It runs on a node. Tasks are assigned to a node for execution, or are queued until a node becomes free. Put simply, a task runs one or more programs or scripts on a compute node to perform the work you need done. For more information see [Jobs and tasks in Azure Batch](https://learn.microsoft.com/azure/batch/jobs-and-tasks).

Use the `CreateTask` method with a `BatchTaskCreateContent` instance to create a `BatchTask`. 

```C# Snippet:Batch_Readme_TaskCreation
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

_batchClient.CreateTask("jobId", new BatchTaskCreateContent("taskId", $"echo Hello world"));
```

### Retrieve a task

`GetTask` can be used to retrieve a created `BatchTask`

```C# Snippet:Batch_Readme_TaskRetreival
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTask batchTask = _batchClient.GetTask("<jobId>", "<taskId>");
Console.WriteLine(batchTask.Id);
Console.WriteLine(batchTask.State);
```

### Retrieve an output file from a task

In Azure Batch, each task has a working directory under which it can create files and directories. This working directory can be used for storing the program that is run by the task, the data that it processes, and the output of the processing it performs. All files and directories of a task are owned by the task user.

The Batch service exposes a portion of the file system on a node as the root directory. This root directory is located on the temporary storage drive of the VM, not directly on the OS drive.

Tasks can access the root directory by referencing the AZ_BATCH_NODE_ROOT_DIR environment variable. For more information see [Files and directories in Azure Batch](https://learn.microsoft.com/azure/batch/files-and-directories).


`GetTasks` can be used to list all `BatchTask` allocated under a `BatchJob`.  `GetTaskFile` can be used to retrive files from a `BatchTask`

```C# Snippet:Batch_Readme_ListTasks
BatchClient _batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

var completedTasks = _batchClient.GetTasks("jobId", filter: "state eq 'completed'");
foreach (BatchTask t in completedTasks)
{
    var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

    Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
        t.Id, t.ExecutionInfo.ExitCode, outputFileName);

    BinaryData fileContents = _batchClient.GetTaskFile("jobId", t.Id, outputFileName);
    using (var reader = new StreamReader(fileContents.ToStream()))
    {
        Console.WriteLine(reader.ReadLine());
    }
}
```

## Troubleshooting

Please see [Troubleshooting common batch issues](https://learn.microsoft.com/troubleshoot/azure/hpc/batch/welcome-hpc-batch).

## Next steps

View more https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/samples here for common usages of the Batch client library: [Batch Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/samples).

## Contributing

This project welcomes contributions and suggestions.
Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution.
For details, visit [Contributor License Agreements](https://opensource.microsoft.com/cla/).

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment).
Simply follow the instructions provided by the bot.
You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.