# Creating a Batch Pool, Job, and Tasks

This sample demonstrates how to create a pool, job, and tasks for a Batch account.

## Special Note for Batch Pools

Both the **Azure.Compute.Batch** and the ARM based **Azure.Management.Batch** sdk's support the creating and managing of Batch Pools with the only difference being that **Azure.Management.Batch** supports creating [Batch Pools with Managed Idenities](https://learn.microsoft.com/azure/batch/managed-identity-pools), for this reason creating pools via **Azure.Management.Batch** is considered a best practice.  This example will use **Azure.Management.Batch** for pool creation and thus will need to create an ArmClient to do so.

## Authenticating the Azure.ResourceManager `ArmClient`

In order to create Batch Pool from the Azure.Managment.Batch library you will need to instantiate an Armclient. To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide here](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

```C#
var credential = new DefaultAzureCredential();
ArmClient _armClient = new ArmClient(credential);
```


### Pool Creation

Batch operations in the **Azure.Management.Batch** sdk are preformed from a BatchAccountResource object, to get a BatchAccountResource object you can query the armclient for the resource id of your Batch account.
```C#
BatchAccountResource batchAccount = await _armClient.GetBatchAccountResource("your-batch-account-resource-id").GetAsync();
```

With the BatchAccountResource you can create a pool with the [batchAccount.GetBatchAccountPools().CreateOrUpdateAsync](https://learn.microsoft.com/dotnet/api/azure.resourcemanager.batch.batchaccountpoolcollection.createorupdateasync?view=azure-dotnet) command
```C#

var poolName = "HelloWorldPool";
var imageReference = new BatchImageReference()
{
    Publisher = "canonical",
    Offer = "0001-com-ubuntu-server-jammy",
    Sku = "22_04-lts",
    Version = "latest"
};
string nodeAgentSku = "batch.node.ubuntu 22.04";

BatchAccountPoolResource pool = (await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolName, new BatchAccountPoolData()
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
})).Value;
```

## Authenticating the Azure.Compute.Batch `BatchClient`
Creation of Batch jobs and tasks can only be preformed with the `Azure.Compute.Batch` sdk.  A `BatchClient` object is needed to preform Batch operations and can be created using [Microsoft Entra ID authtentication](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) and the Batch account endpoint  

```C#
var credential = new DefaultAzureCredential();
BatchClient _batchClient = new BatchClient(
    new Uri("https://examplebatchaccount.eastus.batch.azure.com"),
    credential);
```

### Job Creation

Before we can create Batch Tasks we first need to create a Job for the tasks to be associatd with, this can be done via the `CreateJobAsync` command. The basic elements needed are a Id for job itself and the name of the pool that this job will run against. 
```C#
await _batchClient.CreateJobAsync(new BatchJobCreateContent(jobId, new BatchPoolInfo() { PoolId = poolName }));
```
### Task Creation
Batch tasks can be created from the BatchClient via the `CreateTaskAsync`.  The basic elements needed are the name of the job the task will be assigned to, and id for the task itself, and a command to run.
```C#
await _batchClient.CreateTaskAsync(jobId, new BatchTaskCreateContent(taskId, $"echo Hello world from {taskId}"));
```
### Full Sample

```C#
﻿// Copyright (c) Microsoft Corporation. All rights reserved.

using Azure.Core;
using Azure.Identity;
using Azure.Compute.Batch;
using Azure.ResourceManager;
using Azure.ResourceManager.Batch;
using Azure.ResourceManager.Batch.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Batch.Samples.HelloWorld
{
    public class HelloWorldSample
    {
        private ArmClient _armClient;
        private BatchClient _batchClient;

        /// <summary>
        /// Creates a pool with a configurable number of nodes, then submits tasks which print a 'Hello world' message.
        /// The resulting stdout.txt or stderr.txt (depending on each task's exit code) is then printed to the console.
        /// 
        /// After running, the job will be terminated and the pool will be deleted.
        /// </summary>
        /// <param name="batchAccountResourceId">The ARM resource ID of the Batch account.</param>
        /// <returns>A task which completes when the sample has finished running.</returns>
        public async Task Run(string batchAccountResourceId)
        {
            var batchAccountIdentifier = ResourceIdentifier.Parse(batchAccountResourceId);

            var credential = new DefaultAzureCredential();
            _armClient = new ArmClient(credential);

            BatchAccountResource batchAccount = await _armClient.GetBatchAccountResource(batchAccountIdentifier).GetAsync();

            _batchClient = new BatchClient(new Uri($"https://{batchAccount.Data.AccountEndpoint}"), credential);

            var poolName = GenerateUniqueName("HelloWorldPool");
            var imageReference = new BatchImageReference()
            {
                Publisher = "canonical",
                Offer = "0001-com-ubuntu-server-jammy",
                Sku = "22_04-lts",
                Version = "latest"
            };
            string nodeAgentSku = "batch.node.ubuntu 22.04";

            BatchAccountPoolResource pool = (await batchAccount.GetBatchAccountPools().CreateOrUpdateAsync(WaitUntil.Completed, poolName, new BatchAccountPoolData()
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
            })).Value;

            string jobId = GenerateUniqueName("HelloWorldJob");

            try
            {
                await _batchClient.CreateJobAsync(new BatchJobCreateContent(jobId, new BatchPoolInfo() { PoolId = poolName }));

                for (int i = 0; i < 5; i++)
                {
                    string taskId = $"task-{i}";
                    Console.WriteLine("Submitting {0}", taskId);
                    await _batchClient.CreateTaskAsync(jobId, new BatchTaskCreateContent(taskId, $"echo Hello world from {taskId}"));
                }

                Console.WriteLine("Waiting for all tasks to complete on job: {0} ...", jobId);
                await waitForTasksToComplete(jobId);

                var completedTasks = _batchClient.GetTasksAsync(jobId, filter: "state eq 'completed'");
                await foreach (BatchTask t in completedTasks)
                {
                    var outputFileName = t.ExecutionInfo.ExitCode == 0 ? "stdout.txt" : "stderr.txt";

                    Console.WriteLine("Task {0} exited with code {1}. Output ({2}):",
                        t.Id, t.ExecutionInfo.ExitCode, outputFileName);

                    BinaryData fileContents = await _batchClient.GetTaskFileAsync(jobId, t.Id, outputFileName);
                    using (var reader = new StreamReader(fileContents.ToStream()))
                    {
                        Console.WriteLine(await reader.ReadLineAsync());
                    }
                }
            }
            finally
            {
                Console.WriteLine("Terminating job {0} and deleting pool {1}", jobId, poolName);
                await Task.WhenAll([
                    _batchClient.TerminateJobAsync(jobId),
                    pool.DeleteAsync(WaitUntil.Completed)]);
            }
        }

        /// <summary>
        /// Poll all the tasks in the given job and wait for them to reach the completed state.
        /// </summary>
        /// <param name="jobId">The ID of the job to poll</param>
        /// <returns>A task that will complete when all Batch tasks have completed.</returns>
        /// <exception cref="TimeoutException">Thrown if all tasks haven't reached the completed state after a certain period of time</exception>
        private async Task waitForTasksToComplete(String jobId)
        {
            // Note that this timeout should take into account the time it takes for the pool to scale up
            var timeoutAfter = DateTime.Now.AddMinutes(10);
            while (DateTime.Now < timeoutAfter)
            {
                var allComplete = true;
                var tasks = _batchClient.GetTasksAsync(jobId, select: ["id", "state"]);
                await foreach (BatchTask task in tasks)
                {
                    if (task.State != BatchTaskState.Completed)
                    {
                        allComplete = false;
                        break;
                    }
                }

                if (allComplete)
                {
                    return;
                }

                await Task.Delay(10000);
            }

            throw new TimeoutException("Task(s) did not complete within the specified time");
        }

        /// <summary>
        /// Generate a unique name with the given prefix using the current user name and a timestamp.
        /// </summary>
        /// <param name="prefix">The name's prefix.</param>
        /// <returns>The generated name.</returns>
        private static string GenerateUniqueName(string prefix)
        {
            string currentUser = new string(Environment.UserName.Where(char.IsLetterOrDigit).ToArray());
            return string.Format("{0}-{1}-{2}", prefix, currentUser, DateTime.Now.ToString("yyyyMMdd-HHmmss"));
        }
    }

    public async static Task Main(string[] args)
    {
        string batchAccountResourceId = "your-batch-account-resource-id";

        await new HelloWorldSample().Run(batchAccountResourceId);

        Console.WriteLine("Press return to exit...");
        Console.ReadLine();
    }
}
```
