# Azure Batch client library for .NET

`Azure.Compute.Batch` allows users to run large-scale parallel and high-performance computing (HPC) batch jobs efficiently in Azure.  

Use the client library for to:

* Create and manage Batch jobs and tasks
* View and perform operations on nodes in a Batch pool

  [Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/src) | [Package (NuGet)](https://www.nuget.org/packages) | [API reference documentation](https://learn.microsoft.com/dotnet/api/overview/azure/batch?view=azure-dotnet) | [Product documentation](https://learn.microsoft.com/azure/batch/)

>Note: `Azure.Compute.Batch` replaces 'Microsoft.Azure.Batch`, see the [Migration Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/MigrationGuide.md) for migration guidance.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Compute.Batch
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
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), credential);
```

#### Authenticate using Shared Key

You can also use Shared Key authentication to sign into your Batch account. This method uses your Batch account access keys to authenticate Azure commands for the Batch service.  You can find your batch account shared keys in the portal under the "keys" section or you can run the following [CLI command](https://learn.microsoft.com/cli/azure/batch/account/keys?view=azure-cli-latest) 

```bash
az batch account keys list --name <your-batch-account> --resource-group <your-resource-group-name>
```

```C# Snippet:Batch_Readme_AzureNameKeyCredential
var credential = new AzureNamedKeyCredential("<your account>", "BatchAccountKey");
BatchClient batchClient = new BatchClient(
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

* [Pool Operations](#pool-operations)
  * [Create a pool](#create-a-pool)
  * [Retrieve a pool](#retrieve-a-pool)
  * [List pools ](#list-pools)
  * [Delete Pool](#delete-pool)
  * [Patch Pool](#patch-pool)
  * [Update Pool](#update-pool)
  * [Resize Pool](#resize-pool)
  * [Stop Pool Resize](#stop-resizepool)
  * [Enable Pool Auto Scale](#enable-autoscalepool)
  * [Disable Pool Auto Scale](#disable-autoscalepool)
  * [Evaluate Pool Auto Scale](#evaluate-autoscalepool)
  * [List Pool Node Counts](#list-poolnodecounts)
  * [List Pool Usage Metrics](#list-poolusagemetrics)
  * [Get Supported Images](#get-supported-images)
* [Job Operations](#job-operations)
  * [Create a job](#create-a-job)
  * [Retrieve a job](#retrieve-a-job)
  * [List jobs](#list-jobs)
  * [Delete Job](#deletejob)
  * [Replace Job](#replace-job)
  * [Update Job](#update-job)
  * [Disable Job](#disable-job)
  * [Enable Job](#enable-job)
  * [List Job Preparation And Release Task Status](#listjobpreparationandreleasetaskstatus)
  * [Get Job Task Counts](#getjobtaskcounts)
  * [Terminate Job](#terminate-job)
* [Job Schedule Operations](#job-schedule-operations)
  * [Create Job Schedule](#createjobschedule)
  * [Get Job Schedule](#getjobschedule)
  * [List Job Schedules](#listjobschedules)
  * [Delete Job Schedule](#deletejobschedule)
  * [Replace Job Schedule](#replace-job-schedule)
  * [Update Job Schedule](#update-job-schedule)
  * [Disable Job Schedule](#disable-job-schedule)
  * [Enable Job Schedule](#enable-job-schedule)
  * [Terminate Job Schedule](#terminate-job-schedule)
* [Task Operations](#task-operations)
  * [Create a task](#create-a-task)
  * [Retrieve a task](#retrieve-a-task)
  * [List Tasks](#listtasks)
  * [Delete Task](#delete-task)
  * [Replace Task](#replace-task)
  * [Reactivate Task](#reactivate-task)
  * [Terminate Task](#terminate-task)
  * [Retrieve an output file from a task](#retrieve-an-output-file-from-a-task)
* [Node Operations](#node-operations)
    * [Retrieve a Node](#retrieve-a-node)
    * [List Nodes](#list-nodes)
    * [Reboot Node](#reboot-node)
    * [Create Compute Node User](#createcomputenodeuser)
    * [Delete Compute Node User](#deletecomputenodeuser)
    * [Get Node File](#getnodefile)
    * [List Node Files](#listnodefiles)
    * [Delete Node File](#deletenodefile)
    * [Node File Properties](#get-node-file-properties)
    * [Get Remote Login Settings](#getremoteloginsettings)
    * [Upload Compute Node BatchService Logs](#uploadcomputenodebatchservicelogs)
* [Certificate Operations](#certificate-operations)
    * [Create a Certificate](#createcertificate)
    * [Get a Certificatec](#getcertificate)
    * [List Certificates](#listcertificates)
    * [Delete Certificate](#deletecertificate)
    * [Cancel Delete Certificate](#canceldeletecertificate)
* [Application Operations](#application-operations)
    * [Get Application](#get-application)
    * [List Applications](#list-application)
* [Error Handling](#error-handling)

### Pool Operations

### Create a Pool

In an Azure Batch workflow, a compute node (or node) is a virtual machine that processes a portion of your application's workload. A pool is a collection of these nodes for your application to runs on. For more information see [Nodes and pools in Azure Batch](https://learn.microsoft.com/azure/batch/nodes-and-pools).

Use the `CreatePool` method with a `BatchPoolCreateOptions` instance to create a `BatchPool`. 

```C# Snippet:Batch_Readme_PoolCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

string poolID = "HelloWorldPool";

BatchVmImageReference imageReference = new BatchVmImageReference()
{
    Publisher = "MicrosoftWindowsServer",
    Offer = "WindowsServer",
    Sku = "2019-datacenter-smalldisk",
    Version = "latest"
};

VirtualMachineConfiguration virtualMachineConfiguration = new VirtualMachineConfiguration(imageReference, "batch.node.windows amd64");

BatchPoolCreateOptions batchPoolCreateOptions = new BatchPoolCreateOptions(
poolID, "STANDARD_D1_v2")
{
    VirtualMachineConfiguration = virtualMachineConfiguration,
    TargetDedicatedNodes = 2,
};

// create pool
batchClient.CreatePool(batchPoolCreateOptions);
```

### Retrieve a Pool

`GetPool` can be used to retrieve created pools.

```C# Snippet:Batch_Readme_PoolRetreival
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchPool batchPool = batchClient.GetPool("poolID");

Console.WriteLine(batchPool.Id);
Console.WriteLine(batchPool.Uri);
Console.WriteLine(batchPool.AllocationState);
```

### List Pools

`GetPools` can be used to list all pools under the Batch account.

```C# Snippet:Batch_Readme_ListPools
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchPool item in batchClient.GetPools())
{
    Console.WriteLine(item.Id);
}
```

#### Delete Pool
`DeletePool` can be used to delete a pool.

```C# Snippet:Batch_Migration_DeletePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeletePool("poolID");
```

#### Patch Pool

`UpdatePool` can be used to patch a pool.

```C# Snippet:Batch_Migration_PatchPool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchPoolUpdateOptions updateOptions = new BatchPoolUpdateOptions();
updateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

batchClient.UpdatePool("poolID", updateOptions);
```

#### Update Pool

`ReplacePoolProperties` can be used to update a pool.

```C# Snippet:Batch_Migration_UpdatePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchMetadataItem[] metadataItems = new BatchMetadataItem[] {
  new BatchMetadataItem("name", "value")};

BatchApplicationPackageReference[] batchApplicationPackageReferences = new BatchApplicationPackageReference[] {
        new BatchApplicationPackageReference("applicationPackage")
        {
            Version = "1"
        }
    };

BatchCertificateReference[] certificateReferences = new BatchCertificateReference[] {
        new BatchCertificateReference("thumbprint","thumbprintAlgorithm")
        {
            StoreLocation = "storeLocation",
            StoreName = "storeName"
        }
};

BatchPoolReplaceOptions replaceOptions = new BatchPoolReplaceOptions(certificateReferences, batchApplicationPackageReferences, metadataItems);
batchClient.ReplacePoolProperties("poolID", replaceOptions);
```
#### Resize Pool

`ResizePool` can be used to resize a pool.

```C# Snippet:Batch_Migration_ResizePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchPoolResizeOptions resizeOptions = new BatchPoolResizeOptions()
{
    TargetDedicatedNodes = 1,
    ResizeTimeout = TimeSpan.FromMinutes(10),
};

batchClient.ResizePool("poolID", resizeOptions);
```
                    
#### Stop ResizePool

`StopPoolResize` can be used to stop a pool resize in progress.

```C# Snippet:Batch_Migration_StopResizePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.StopPoolResize("poolId");
```

#### Enable AutoScalePool

`EnablePoolAutoScale` can be used to enable auto scale in a pool. Pass in a `BatchPoolEnableAutoScaleOptions` object.

```C# Snippet:Batch_Migration_EnableAutoScalePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());
TimeSpan evalInterval = TimeSpan.FromMinutes(6);
string poolASFormulaNew = "$TargetDedicated = 1;";

BatchPoolEnableAutoScaleOptions batchPoolEnableAutoScaleOptions = new BatchPoolEnableAutoScaleOptions()
{
    AutoScaleEvaluationInterval = evalInterval,
    AutoScaleFormula = poolASFormulaNew,
};

batchClient.EnablePoolAutoScale("poolId", batchPoolEnableAutoScaleOptions);
```

#### Disable AutoScalePool

`DisablePoolAutoScale` can be used to disable auto scale in a pool. Pass in a `BatchPoolEnableAutoScaleOptions` object.

```C# Snippet:Batch_Migration_DisableAutoScalePool
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DisablePoolAutoScale("poolId");
```

#### Evaluate AutoScalePool

`EvaluatePoolAutoScale` cand be used to evaluate an auto scale formula in a pool. Pass in a `BatchPoolEvaluateAutoScaleOptions` object.

```C# Snippet:Batch_Migration_EvaluatePoolAutoScale
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

string poolASFormulaNew = "$TargetDedicated = 1;";
BatchPoolEvaluateAutoScaleOptions batchPoolEvaluateAutoScaleOptions = new BatchPoolEvaluateAutoScaleOptions(poolASFormulaNew);
AutoScaleRun eval = batchClient.EvaluatePoolAutoScale("poolId", batchPoolEvaluateAutoScaleOptions);
```

#### List PoolNodeCounts

`GetPoolNodeCounts` cand be used to list pool node counts.

```C# Snippet:Batch_Migration_GetPoolNodeCounts
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchPoolNodeCounts item in batchClient.GetPoolNodeCounts())
{
    // do something
}
```

#### List PoolUsageMetrics

`GetPoolUsageMetricsAsync` can be used to list pool usage metrics.

```C# Snippet:Batch_Migration_GetPoolUsageMetrics
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchPoolUsageMetrics item in batchClient.GetPoolUsageMetrics())
{
    // do something
}
```

#### Get Supported Images

`GetSupportedImagesAsync` can be used to get a list of supported image.

```C# Snippet:Batch_Migration_GetSupportedImages
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchSupportedImage item in batchClient.GetSupportedImages())
{
    // do something
}
```

### Job Operations

### Create a Job
A job is a collection of tasks. It manages how computation is performed by its tasks on the compute nodes in a pool.

A job specifies the pool in which the work is to be run. You can create a new pool for each job, or use one pool for many jobs. You can create a pool for each job that is associated with a job schedule, or one pool for all jobs that are associated with a job schedule. For more information see [Jobs and tasks in Azure Batch](https://learn.microsoft.com/azure/batch/jobs-and-tasks).

Use the `CreateJob` method with a `BatchTaskCreateOptions` instance to create a `BatchJob`. 

```C# Snippet:Batch_Readme_JobCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.CreateJob(new BatchJobCreateOptions("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
```

### Retrieve a job

`GetJob` can be used to retrieve a created `BatchJob`.

```C# Snippet:Batch_Readme_JobRetreival
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJob batchJob = batchClient.GetJob("jobID");
Console.WriteLine(batchJob.Id);
Console.WriteLine(batchJob.State);
```

### List jobs

`GetJobs` can be used to list all `BatchJob` allocated under a Batch Account.

```C# Snippet:Batch_Readme_ListJobs
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchJob item in batchClient.GetJobs())
{
    Console.WriteLine(item.Id);
}
```

#### DeleteJob

 `DeleteJob` can be used to delete a job.

```C# Snippet:Batch_Migration_DeleteJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteJob("jobID");
```

#### Replace Job

`ReplaceJob` can be used to replace an existing job.

```C# Snippet:Batch_Migration_ReplaceJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJob job = batchClient.GetJob("jobID");
job.AllTasksCompleteMode = BatchAllTasksCompleteMode.TerminateJob;
batchClient.ReplaceJob("jobID", job);
```

#### Update Job

`UpdateJob` with a parameter of type `BatchJobUpdateOptions` can be used to update a job

```C# Snippet:Batch_Migration_UpdateJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobUpdateOptions batchUpdateOptions = new BatchJobUpdateOptions();
batchUpdateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

batchClient.UpdateJob("jobID", batchUpdateOptions);
```

#### Disable Job

`DisableJob` with a parameter of type `BatchJobDisableOptions` can be used to disable a job.

```C# Snippet:Batch_Migration_DisableJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobDisableOptions options = new BatchJobDisableOptions(DisableBatchJobOption.Requeue);
batchClient.DisableJob("jobID", options);
```

#### Enable Job

`EnableJob` can be used to enable a disabled job.

```C# Snippet:Batch_Migration_EnableJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.EnableJob("jobID");
```

#### ListJobPreparationAndReleaseTaskStatus

`GetJobPreparationAndReleaseTaskStatuses` can be used to get a list of job preparation and release task status.

```C# Snippet:Batch_Migration_GetJobPreparationAndReleaseTaskStatuses
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchJobPreparationAndReleaseTaskStatus item in batchClient.GetJobPreparationAndReleaseTaskStatuses("jobID"))
{
    // do something
}
```

#### GetJobTaskCounts

`GetJobTaskCounts` can be used to get a job task count.

```C# Snippet:Batch_Migration_GetJobTaskCounts
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTaskCountsResult batchTaskCountsResult = batchClient.GetJobTaskCounts("jobID");
```

#### Terminate Job

`TerminateJob` can be used to terminate a job.

```C# Snippet:Batch_Migration_TerminateJob
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.TerminateJob("jobID");
```

### Job Schedule Operations

#### CreateJobSchedule

`CreateJobSchedule` with a parameter of type `BatchJobScheduleCreateOptions` to create a Job Schedule.

```C# Snippet:Batch_Migration_CreateJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobScheduleConfiguration schedule = new BatchJobScheduleConfiguration();

BatchPoolInfo poolInfo = new BatchPoolInfo()
{
    PoolId = "poolID",
};
BatchJobManagerTask batchJobManagerTask = new BatchJobManagerTask("task1", "cmd / c echo Hello World");

BatchJobSpecification jobSpecification = new BatchJobSpecification(poolInfo)
{
    JobManagerTask = batchJobManagerTask,
};

BatchJobScheduleCreateOptions jobSchedule = new BatchJobScheduleCreateOptions("jobScheduleId", schedule, jobSpecification);

batchClient.CreateJobSchedule(jobSchedule);
```

#### GetJobSchedule

`GetJobSchedule` can be used to retrieve a `BatchJobSchedule` object.

```C# Snippet:Batch_Migration_GetJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobSchedule batchJobSchedule = batchClient.GetJobSchedule("jobScheduleId");
```

#### ListJobSchedules

`GetJobSchedules` with a parameter of type `BatchJobScheduleCreateOptions` can be used to get a list of job schedules.

```C# Snippet:Batch_Migration_GetJobSchedules
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchJobSchedule item in batchClient.GetJobSchedules())
{
    // do something
}
```

#### DeleteJobSchedule

`DeleteJobSchedule` can be used to delete a Job Schedule

```C# Snippet:Batch_Migration_DeleteJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteJobSchedule("jobScheduleId");
```

#### Replace Job Schedule

`ReplaceJobSchedule` can be used to replace a job schedule.

```C# Snippet:Batch_Migration_ReplaceJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobSchedule batchJobSchedule = batchClient.GetJobSchedule("jobScheduleId");

DateTime unboundDNRU = DateTime.Parse("2026-08-18T00:00:00.0000000Z");
batchJobSchedule.Schedule = new BatchJobScheduleConfiguration()
{
    DoNotRunUntil = unboundDNRU,
};
batchClient.ReplaceJobSchedule("jobScheduleId", batchJobSchedule);
```

#### Update Job Schedule

`UpdateJobSchedule` with a parameter of type `BatchJobScheduleUpdateOptions` can be used to update a job schedule.

```C# Snippet:Batch_Migration_UpdateJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchJobScheduleUpdateOptions batchUpdateOptions = new BatchJobScheduleUpdateOptions();
batchUpdateOptions.Metadata.Add(new BatchMetadataItem("name", "value"));

batchClient.UpdateJobSchedule("jobID", batchUpdateOptions);
```

#### Disable Job Schedule

`DisableJobSchedule` can be used to to disable a job schedule.

```C# Snippet:Batch_Migration_DisableJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DisableJobSchedule("jobScheduleId");
```

#### Enable Job Schedule

`EnableJobSchedule` can be used to enable a job schedule.

```C# Snippet:Batch_Migration_EnableJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.EnableJobSchedule("jobScheduleId");
```

#### Terminate Job Schedule

`TerminateJobSchedule` cand be used to termainate a job schedule.

```C# Snippet:Batch_Migration_TerminateJobSchedule
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.TerminateJobSchedule("jobScheduleId");
```

### Task Operations

### Create a task

A task is a unit of computation that is associated with a job. It runs on a node. Tasks are assigned to a node for execution, or are queued until a node becomes free. Put simply, a task runs one or more programs or scripts on a compute node to perform the work you need done. For more information see [Jobs and tasks in Azure Batch](https://learn.microsoft.com/azure/batch/jobs-and-tasks).

With `Azure.Compute.Batch` there are three ways to add a task to a job.

You can call `CreateTask` with a parameter of type `BatchTaskCreateOptions` to create a single task
```C# Snippet:Batch_Readme_TaskCreation
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.CreateTask("jobId", new BatchTaskCreateOptions("taskId", $"echo Hello world"));
```

You can call `CreateTaskCollection` with a `BatchTaskGroup` param to create up to 100 tasks.  This method represents the /jobs/{jobId}/addtaskcollection api
```C# Snippet:Batch_Migration_CreateTaskCollection
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTaskGroup taskCollection = new BatchTaskGroup(
    new BatchTaskCreateOptions[]
    {
        new BatchTaskCreateOptions("task1", "cmd / c echo Hello World"),
        new BatchTaskCreateOptions("task2", "cmd / c echo Hello World")
    });

BatchCreateTaskCollectionResult batchCreateTaskCollectionResult = batchClient.CreateTaskCollection("jobID", taskCollection);
```
Lastly you can call `CreateTasks` which is the replacement for the utility method found in `Microsoft.Azure.Batch`.  This method will package up the list of `BatchTaskCreateOptions` tasks passed in and repeatly call the `batchClient.CreateTaskCollection()` with groups of tasks bundled into `BatchTaskGroup` objects.  This utility method allowed the user
to select the number of parallel calls to `batchClient.CreateTaskCollection()`. See [Creating multiple Task](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/batch/Azure.Compute.Batch/samples/Sample2_Creating_Multiple_Tasks.md)

```C# Snippet:Batch_Sample02_CreateTasks_Default
int tasksCount = 1000;
List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
for (int i = 0; i < tasksCount; i++)
{
    tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
}

// Create 1000 tasks in a single request using the default settings
CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks);

// Print the results
Console.WriteLine("{0} Tasks Passed, {1} Failed.", result.PassCount, result.FailCount);
```

### Retrieve a task

`GetTask` can be used to retrieve a created `BatchTask`.

```C# Snippet:Batch_Readme_TaskRetreival
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTask batchTask = batchClient.GetTask("<jobId>", "<taskId>");
Console.WriteLine(batchTask.Id);
Console.WriteLine(batchTask.State);
```

#### ListTasks

`GetTasks` can be used to get a list of tasks.

```C# Snippet:Batch_Readme_ListTasks
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchTask t in batchClient.GetTasks("jobId"))
{
    // do something with the task
}
```

#### Delete Task

`DeleteTask` can be called to get a delete a task.

```C# Snippet:Batch_Migration_DeleteTask
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteTask("jobId", "taskId");
```

#### Replace Task

`ReplaceTask` with a `BatchTaskConstraints` parameter can be called to replace a task.

```C# Snippet:Batch_Migration_ReplaceTask
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchTask task = batchClient.GetTask("jobId", "taskId");
BatchTaskConstraints batchTaskConstraints = new BatchTaskConstraints()
{
    MaxTaskRetryCount = 3,
};

task.Constraints = batchTaskConstraints;
batchClient.ReplaceTask("jobID", "taskID", task);
```

#### Reactivate Task

`ReactivateTask` can be called to reactive a task.

```C# Snippet:Batch_Migration_ReactivateTask
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.ReactivateTask("jobID", "taskID");
```

#### Terminate Task

`TerminateTask` can be called to terminate a task.

```C# Snippet:Batch_Migration_TerminateTask
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.TerminateTask("jobID", "taskID");
```

### Retrieve an output file from a task

In Azure Batch, each task has a working directory under which it can create files and directories. This working directory can be used for storing the program that is run by the task, the data that it processes, and the output of the processing it performs. All files and directories of a task are owned by the task user.

The Batch service exposes a portion of the file system on a node as the root directory. This root directory is located on the temporary storage drive of the VM, not directly on the OS drive.

Tasks can access the root directory by referencing the AZ_BATCH_NODE_ROOT_DIR environment variable. For more information see [Files and directories in Azure Batch](https://learn.microsoft.com/azure/batch/files-and-directories).


`GetTasks` can be used to list all `BatchTask` allocated under a `BatchJob`.  `GetTaskFile` can be used to retrive files from a `BatchTask`

```C# Snippet:Batch_Readme_GetTaskFile
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

var completedTasks = batchClient.GetTasks("jobId", filter: "state eq 'completed'");
foreach (BatchTask t in completedTasks)
{
    var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

    Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
        t.Id, t.ExecutionInfo.ExitCode, outputFileName);

    BinaryData fileContents = batchClient.GetTaskFile("jobId", t.Id, outputFileName);
    using (var reader = new StreamReader(fileContents.ToStream()))
    {
        Console.WriteLine(reader.ReadLine());
    }
}
```

### Node Operations

### Retrieve a Node

A node is an Azure virtual machine (VM) that is dedicated to processing a portion of your application's workload. The size of a node determines the number of CPU cores, memory capacity, and local file system size that is allocated to the node. For more information see [Nodes and pools in Azure Batch](https://learn.microsoft.com/azure/batch/nodes-and-pools).

`GetNode` can be used to retrieve an allocated `BatchNode` from a pool.

```C# Snippet:Batch_Readme_NodeRetreival
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchNode batchNode = batchClient.GetNode("<poolId>", "<nodeId>");
Console.WriteLine(batchNode.Id);
Console.WriteLine(batchNode.Uri);
Console.WriteLine(batchNode.State);
```

### List Nodes

`GetNodes` can be used to list all `BatchNode` allocated under a pool.

```C# Snippet:Batch_Readme_ListNodes
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchNode item in batchClient.GetNodes("poolID"))
{
    Console.WriteLine(item.Id);
}
```

#### Reboot Node

`RebootNode` can be used to reboot a node.

```C# Snippet:Batch_Migration_RebootNode
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.RebootNode("poolId", "computeNodeId");
```

#### CreateComputeNodeUser

`CreateNodeUserAsync` with a `BatchNodeUserCreateOptions` param can be used to create a node user.

```C# Snippet:Batch_Migration_CreateNodeUser
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchNodeUserCreateOptions user = new BatchNodeUserCreateOptions("userName")
{
    Password = "userPassWord"
};
batchClient.CreateNodeUser("poolID", "batchNodeID", user);
```

#### DeleteComputeNodeUser

`DeleteNodeUser` can be to delete a node user.

```C# Snippet:Batch_Migration_DeleteNodeUser
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteNodeUser("poolID", "batchNodeID", "userName");
```

#### GetNodeFile

`GetNodeFile` cand be used to get a file from a node.

```C# Snippet:Batch_Migration_GetNodeFile
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BinaryData fileContents = batchClient.GetNodeFile("poolId", "computeNodeId", "filePath");
```

#### ListNodeFiles

`GetNodeFiles` can be used to get a list of files.

```C# Snippet:Batch_Migration_GetNodeFiles
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchNodeFile item in batchClient.GetNodeFiles("jobId", "nodeId"))
{
    // do something
}
```

#### DeleteNodeFile

`DeleteNodeFile` can be used to delete a file from a node.

```C# Snippet:Batch_Migration_DeleteNodeFile
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteNodeFile("jobId", "taskId", "filePath");
```

#### Get Node File Properties

`GetNodeFileProperties` can be used to get the properties of a file.

```C# Snippet:Batch_Migration_GetNodeFileProperties
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchFileProperties batchFileProperties = batchClient.GetNodeFileProperties("poolId", "nodeId", "filePath");
```
#### GetRemoteLoginSettings

`GetNodeRemoteLoginSettings` can be used to get the remote loging settings of a node.

```C# Snippet:Batch_Migration_GetNodeRemoteLoginSettings
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchNodeRemoteLoginSettings batchNodeRemoteLoginSettings = batchClient.GetNodeRemoteLoginSettings("poolId", "computeNodeId");
```

#### UploadComputeNodeBatchServiceLogs

`UploadNodeLogs` with a param of type `UploadBatchServiceLogsOptions` can be used to upload logs to a node.

```C# Snippet:Batch_Migration_UploadNodeLogs
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

UploadBatchServiceLogsOptions uploadBatchServiceLogsOptions = new UploadBatchServiceLogsOptions(new Uri("containerUrl"), DateTimeOffset.Parse("2026-05-01T00:00:00.0000000Z"));

UploadBatchServiceLogsResult uploadBatchServiceLogsResult = batchClient.UploadNodeLogs("poolId", "computeNodeId", uploadBatchServiceLogsOptions);
```

### Certificate Operations

> Note: Certificates has been [deprecated].

#### CreateCertificate

Call `CreateCertificate` with a `BatchCertificate` param to create a Certificate.

```C# Snippet:Batch_Migration_CreateCerCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());
byte[] certData = File.ReadAllBytes("certPath");
BatchCertificate cerCertificate = new BatchCertificate("Thumbprint", "ThumbprintAlgorithm", BinaryData.FromBytes(certData))
{
    CertificateFormat = BatchCertificateFormat.Cer,
    Password = "",
};

Response response = batchClient.CreateCertificate(cerCertificate);
```

#### GetCertificate

Call `GetCertificate` to get the certificate which will return a `GetCertificateResponse`.

```C# Snippet:Batch_Migration_GetCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchCertificate cerCertificateResponse = batchClient.GetCertificate("ThumbprintAlgorithm", "Thumbprint");
```

#### ListCertificates

Call `GetCertificates` to get a list of certificates.

```C# Snippet:Batch_Migration_ListCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchCertificate item in batchClient.GetCertificates())
{
        // do something
}
```

#### DeleteCertificate

Call `DeleteCertificate` to delete a Certificate.

```C# Snippet:Batch_Migration_DeleteCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.DeleteCertificate("ThumbprintAlgorithm", "Thumbprint");
```

#### CancelDeleteCertificate

Call `CancelCertificateDeletion` to cancel a delete of a certificate.

```C# Snippet:Batch_Migration_CancelDeleteCertificate
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

batchClient.CancelCertificateDeletion("ThumbprintAlgorithm", "Thumbprint");
```

### Application Operations

#### Get Application

`GetApplication` can be used to get a `BatchApplication` object.

```C# Snippet:Batch_Migration_GetApplication
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

BatchApplication application = batchClient.GetApplication("appID");
```

#### List Application

`GetApplications` can be used to list all `BatchApplication` allocated under a account.

```C# Snippet:Batch_Migration_GetApplications
BatchClient batchClient = new BatchClient(
new Uri("https://<your account>.eastus.batch.azure.com"), new DefaultAzureCredential());

foreach (BatchApplication item in batchClient.GetApplications())
{
    // do something
}
```
### Error Handling

In `Azure.Compute.Batch` when a command fails due to an error on the server side an exception of type RequestFailedException will be thrown.  Inside that exception will an "ErrorCode" property which is a string representation of the error, a "Status" property which represents the HTTP status code, a "Message" which provides a summary of the error, and in some cases their will be additional information in the "Data" Dictionary.  A list of common Batch error codes can be found in the BatchErrorCode class.

```C# Snippet:Batch_Migration_Exception
try
{
    Response response = batchClient.ResizePool("fakepool", resizeOptions);
}
catch (Azure.RequestFailedException e)
{
    if ( (e.ErrorCode == BatchErrorCode.PoolNotFound) &&
        ( e.Status == 404))
    {
        // write out the summary message
        Console.WriteLine(e.Message);

        // additional message details
        if (e.Data != null)
        {
            foreach (DictionaryEntry item in e.Data)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value);
            }
        }
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
