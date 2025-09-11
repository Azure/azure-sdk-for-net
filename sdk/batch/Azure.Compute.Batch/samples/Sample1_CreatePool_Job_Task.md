# Creating a Batch Pool, Job, and Tasks

This sample demonstrates how to create a pool, job, and tasks for a Batch account.

## Special note for Batch pools

Both the **Azure.Compute.Batch** and the ARM-based **Azure.ResourceManager.Batch** libraries support the creating and managing of Batch Pools with the only difference being that **Azure.ResourceManager.Batch** supports creating [Batch Pools with Managed Identities](https://learn.microsoft.com/azure/batch/managed-identity-pools), for this reason creating pools via **Azure.ResourceManager.Batch** is considered a best practice.  This example will use **Azure.ResourceManager.Batch** for pool creation and thus will need to create an `ArmClient` to do so.

## Authenticating the Azure.ResourceManager `ArmClient`

In order to create a Batch Pool from the Azure.ResourceManager.Batch library you will need to instantiate an Armclient. To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

```C# Snippet:Batch_Sample01_CreateBatchMgmtClient
var credential = new DefaultAzureCredential();
ArmClient _armClient = new ArmClient(credential);
```

### Pool creation

Batch operations in the **Azure.Management.Batch** libraries are preformed from a BatchAccountResource instance, to get a BatchAccountResource instance you can query the armclient for the resource id of your Batch account.

```C# Snippet:Batch_Sample01_GetBatchMgmtAccount
var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");
BatchAccountResource batchAccount = await _armClient.GetBatchAccountResource(batchAccountIdentifier).GetAsync();
```

With the BatchAccountResource you can create a pool with the [batchAccount.GetBatchAccountPools().CreateOrUpdateAsync](https://learn.microsoft.com/dotnet/api/azure.resourcemanager.batch.batchaccountpoolcollection.createorupdateasync?view=azure-dotnet) command

```C# Snippet:Batch_Sample01_PoolCreation
var poolName = "HelloWorldPool";
var imageReference = new Azure.ResourceManager.Batch.Models.BatchImageReference()
{
    Publisher = "canonical",
    Offer = "0001-com-ubuntu-server-jammy",
    Sku = "22_04-lts",
    Version = "latest"
};
string nodeAgentSku = "batch.node.ubuntu 22.04";

ArmOperation<BatchAccountPoolResource> armOperation = await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(
    WaitUntil.Completed, poolName, new BatchAccountPoolData()
    {
        VmSize = "Standard_DS1_v2",
        DeploymentConfiguration = new BatchDeploymentConfiguration()
        {
            VmConfiguration = new BatchVmConfiguration(imageReference, nodeAgentSku)
        },
        ScaleSettings = new BatchAccountPoolScaleSettings()
        {
            FixedScale = new BatchAccountFixedScaleSettings()
            {
                TargetDedicatedNodes = 1
            }
        }
    });
BatchAccountPoolResource pool = armOperation.Value;
```

## Authenticating the Azure.Compute.Batch `BatchClient`

Creation of Batch jobs and tasks can only be preformed with the `Azure.Compute.Batch` library.  A `BatchClient` instance is needed to preform Batch operations and can be created using [Microsoft Entra ID authtentication](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) and the Batch account endpoint  

```C# Snippet:Batch_Sample01_CreateBatchClient
var credential = new DefaultAzureCredential();
BatchClient batchClient = new BatchClient(
new Uri("https://examplebatchaccount.eastus.batch.azure.com"), credential);
```

### Job creation

Before we can create Batch Tasks, we first need to create a Job for the tasks to be associatd with, this can be done via the `CreateJobAsync` command. The basic elements needed are an id for job itself and the name of the pool that this job will run against. 

```C# Snippet:Batch_Sample01_CreateBatchJob
await batchClient.CreateJobAsync(new BatchJobCreateOptions("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
```

### Task creation

Batch tasks can be created from the BatchClient via the `CreateTaskAsync`.  The basic elements needed are the name of the job the task will be assigned to, and id for the task itself, and a command to run.
```C# Snippet:Batch_Sample01_CreateBatchTask
await batchClient.CreateTaskAsync("jobId", new BatchTaskCreateOptions("taskId", $"echo Hello world"));
```


### Task results

Onces the tasks are complete `GetTasksAsync` cand be used to retrieve the `BatchTask` instance and `GetTaskFileAsync` can be used to get the output files

```C# Snippet:Batch_Sample01_GetTasks
var completedTasks = batchClient.GetTasksAsync("jobId", filter: "state eq 'completed'");
await foreach (BatchTask t in completedTasks)
{
    var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

    Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
        t.Id, t.ExecutionInfo.ExitCode, outputFileName);

    BinaryData fileContents = await batchClient.GetTaskFileAsync("jobId", t.Id, outputFileName);
    using (var reader = new StreamReader(fileContents.ToStream()))
    {
        Console.WriteLine(await reader.ReadLineAsync());
    }
}
```
