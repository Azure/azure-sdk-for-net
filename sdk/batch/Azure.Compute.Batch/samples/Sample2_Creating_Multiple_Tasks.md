# Creating large amounts of tasks 

This sample demonstrates how to use the utility method `CreateTasks` to create a large batch of tasks in one call.  This sample will cover creating a pool, job, and multip tasks for a Batch account.

## Special note for Batch pools

Both the **Azure.Compute.Batch** and the ARM-based **Azure.ResourceManager.Batch** libraries support the creating and managing of Batch Pools with the only difference being that **Azure.ResourceManager.Batch** supports creating [Batch Pools with Managed Identities](https://learn.microsoft.com/azure/batch/managed-identity-pools), for this reason creating pools via **Azure.ResourceManager.Batch** is considered a best practice.  This example will use **Azure.ResourceManager.Batch** for pool creation and thus will need to create an `ArmClient` to do so.

## Authenticating the Azure.ResourceManager `ArmClient`

In order to create a Batch Pool from the Azure.ResourceManager.Batch library you will need to instantiate an Armclient. To create an authenticated client and start interacting with Microsoft Azure resources, see the [quickstart guide](https://github.com/Azure/azure-sdk-for-net/blob/main/doc/dev/mgmt_quickstart.md).

```C# Snippet:Batch_Sample02_CreateBatchMgmtClient
var credential = new DefaultAzureCredential();
ArmClient _armClient = new ArmClient(credential);
```

### Pool creation

Batch operations in the **Azure.Management.Batch** libraries are preformed from a BatchAccountResource instance, to get a BatchAccountResource instance you can query the armclient for the resource id of your Batch account.

```C# Snippet:Batch_Sample02_GetBatchMgmtAccount
var batchAccountIdentifier = ResourceIdentifier.Parse("your-batch-account-resource-id");
BatchAccountResource batchAccount = await _armClient.GetBatchAccountResource(batchAccountIdentifier).GetAsync();
```

With the BatchAccountResource you can create a pool with the [batchAccount.GetBatchAccountPools().CreateOrUpdateAsync](https://learn.microsoft.com/dotnet/api/azure.resourcemanager.batch.batchaccountpoolcollection.createorupdateasync?view=azure-dotnet) command

```C# Snippet:Batch_Sample02_PoolCreation
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

```C# Snippet:Batch_Sample02_CreateBatchClient
var credential = new DefaultAzureCredential();
BatchClient batchClient = new BatchClient(
new Uri("https://examplebatchaccount.eastus.batch.azure.com"), credential);
```

### Job creation

Before we can create Batch Tasks, we first need to create a Job for the tasks to be associatd with, this can be done via the `CreateJobAsync` command. The basic elements needed are an id for job itself and the name of the pool that this job will run against. 

```C# Snippet:Batch_Sample02_CreateBatchJob
await batchClient.CreateJobAsync(new BatchJobCreateOptions("jobId", new BatchPoolInfo() { PoolId = "poolName" }));
```

### Task creation
With `Azure.Compute.Batch` there are three ways to create a task

You can call `CreateTask` with a parameter of type `BatchTaskCreateContent` to create a single task. This method represents the /jobs/{jobId}/tasks api.
``` C#
 BatchTaskCreateContent taskCreateContent = new BatchTaskCreateContent("taskID", commandLine);
 batchClient.CreateTask("jobID", taskCreateContent);
```

You can call `CreateTaskCollection` with a `BatchTaskGroup` param to create up to 100 tasks.  This will return a `BatchTaskGroup` object that contains a list of `BatchTaskAddResult` results.  This method represents the /jobs/{jobId}/addtaskcollection api.
``` C#
BatchTaskGroup taskCollection = new BatchTaskGroup(new BatchTaskCreateContent[]
{
    new BatchTaskCreateContent("task1", commandLine),
    new BatchTaskCreateContent("task2", commandLine)
});

BatchTaskAddCollectionResult batchTaskAddCollectionResult = batchClient.CreateTaskCollection("jobID", taskCollection);

foreach (BatchTaskAddResult item in batchTaskAddCollectionResult.Value)
{
    // do something
}
```

Lastly you can call `CreateTasks()` which is a utility method that will package up the list of `BatchTaskCreateContent` tasks passed in and repeatly call the `CreateTaskCollection()` with groups of tasks bundled into `BatchTaskGroup` objects.  This utility method allowed the user to select the number of parallel calls to `CreateTaskCollection()` and to preform custom actions post task creation.

In the following code example a list of 1000 tasks are created of type `BatchTaskCreateContent` and passed into the `CreateTasksAsync` method which will return a `CreateTasksResult` object.  The `CreateTasksResult` will contain a count of Pass and Fail results.  

> Note: The source code for this sample can be found under the `\samples` directory.

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

By default `CreateTasksResult` will only contain a count of the Pass/Fail results but if you want the list of the `BatchTaskAddResult` results returned by the service you can pass in a CreateTasksOptions to the AddTasks method with the field ReturnBatchTaskAddResults set to true.  This is disabled by default because the size of the list scales with the number of requests so memory constrants could be a factor.

```C# Snippet:Batch_Sample02_CreateTasks_ReturnBatchTaskAddResults
int tasksCount = 1000;
List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
for (int i = 0; i < tasksCount; i++)
{
    tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
}

// Create a CreateTaskOptions object with custom settings for the BatchTaskAddResults to be returned.
CreateTasksOptions createTaskOptions = new CreateTasksOptions(returnBatchTaskAddResults: true);

// Create 1000 tasks in a single request over 10 parallel requests
CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks, createTaskOptions);

foreach (BatchTaskCreateResult t in result.BatchTaskCreateResults)
{
    Console.WriteLine("Task {0} created with status {1}. ",
        t.TaskId, t.Status);
}
```

Alternatively you can call `CreateTasks()` with an instance of `CreateTasksOptions` which allows you set the number of parallel processes to split up the workload.  

```C# Snippet:Batch_Sample02_CreateTasks_ParallelOptions
int tasksCount = 1000;
List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
for (int i = 0; i < tasksCount; i++)
{
    tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
}

// Create a CreateTaskOptions object with custom settings for parallelism
CreateTasksOptions createTaskOptions = new CreateTasksOptions()
{
    MaxDegreeOfParallelism = 10,
    ReturnBatchTaskCreateResults = true
};

// Create 1000 tasks in a single request over 10 parallel requests
CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks, createTaskOptions);

foreach (BatchTaskCreateResult t in result.BatchTaskCreateResults)
{
    Console.WriteLine("Task {0} created with status  {1}. ",
        t.TaskId, t.Status);
}
```

Addiontally you can call `CreateTasks()` with an instance of `CreateTasksOptions` which allows you set the upper limit of time between calls to the `CreateTaskCollection` method.  Normally this doesn't need to be set but if the call is failing due to a server error 429 (TooManyRequest) this will increase the time between calls.

```C# Snippet:Batch_Sample02_CreateTasks_MaxTimeBetweenCallsInSeconds
int tasksCount = 1000;
List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
for (int i = 0; i < tasksCount; i++)
{
    tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
}

// Create a CreateTaskOptions object with custom settings for
// parallelism and the max time between calls.  Note calls start off with a delay of
// 100 milliseconds and only increases if the service returns a 429 (TooManyRequest).
CreateTasksOptions createTaskOptions = new CreateTasksOptions()
{
    MaxDegreeOfParallelism = 10,
    MaxTimeBetweenCallsInSeconds = 60,
    ReturnBatchTaskCreateResults = true
};

// Create 1000 tasks in a single request over 10 parallel requests
CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks, createTaskOptions);

foreach (BatchTaskCreateResult t in result.BatchTaskCreateResults)
{
    Console.WriteLine("Task {0} created with status  {1}. ",
        t.TaskId, t.Status);
}
```

Addtional parameters to the `CreateTasks()` method can be set such as `timeOutInSeconds` and `cancellationToken`. `timeOutInSeconds` gives an upper limit to how long the method can be run and if the limit is reached a `ParallelOperationsException` exception will be throw with a `TimeoutException` sub exception.  `cancellationToken` can be provided and if the user desides to issue a Cancel then a `OperationCanceledException` will be thrown.

```C# Snippet:Batch_Sample02_CreateTasks_Non_Default
int tasksCount = 1000;
List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
for (int i = 0; i < tasksCount; i++)
{
    tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
}

// Create a CancellationTokenSource object to cancel the operation if need be
var cts = new CancellationTokenSource();

// Create a CreateTaskOptions object with custom settings for
// parallelism and the max time between calls.
CreateTasksOptions createTaskOptions = new CreateTasksOptions()
{
    MaxDegreeOfParallelism = 10,
    ReturnBatchTaskCreateResults = true
};

try
{
    // Create 1000 tasks in a single request over 10 parallel requests with a timeout of 10 minutes
    // and a cancellation token
    CreateTasksResult result = await batchClient.CreateTasksAsync(
        jobId: "jobId",
        tasksToAdd: tasks,
        createTasksOptions: createTaskOptions,
        timeOutInSeconds: TimeSpan.FromMinutes(10),
        cancellationToken: cts.Token
        );

    // Print the results
    Console.WriteLine("{0} Tasks Passed, {1} Failed.", result.PassCount, result.FailCount);
}
catch (ParallelOperationsException)
{
    // timeout exception
}
catch (OperationCanceledException)
{
    // cancelation token execptoin
}
```

You can customize the result handling of the `CreateTasks()` method in processing the results from the `CreateTaskCollection` call. After the call to `CreateTaskCollection` each of the of `CreateTaskResult` are passed to an instance of `ICreateTaskResultHandler` to determine if that result passed, failed, needs to be Retried, or if an execption should be thrown.

Here's and example of a custom implmentation of `ICreateTaskResultHandler`

```C# Snippet:Batch_Sample02__CustomTaskCollectionResultHandler
/// <summary>
///  Custom TaskCollectionResultHandler to handle the result of a CreateTasksAsync operation.
/// </summary>
private class CustomTaskCollectionResultHandler : TaskResultHandler
{
    /// <summary>
    /// This handler treats and result without errors as Success, 'TaskExists' errors as failures, retries server errors (HTTP 5xx),
    /// and throws for any other error.
    /// <see cref="AddTaskCollectionTerminatedException"/> on client error (HTTP 4xx).
    /// </summary>
    /// <param name="addTaskResult">The result of a single Add Task operation.</param>
    /// <param name="cancellationToken">The cancellation token associated with the AddTaskCollection operation.</param>
    /// <returns>An <see cref="CreateTaskResultStatus"/> which indicates whether the <paramref name="addTaskResult"/>
    /// is classified as a success or as requiring a retry.</returns>
    public override CreateTaskResultStatus CreateTaskResultHandler(CreateTaskResult addTaskResult, CancellationToken cancellationToken)
    {
        if (addTaskResult == null)
        {
            throw new ArgumentNullException("addTaskResult");
        }

        CreateTaskResultStatus status = CreateTaskResultStatus.Success;
        if (addTaskResult.BatchTaskResult.Error != null)
        {
            //Check status code
            if (addTaskResult.BatchTaskResult.Status == BatchTaskAddStatus.ServerError)
            {
                status = CreateTaskResultStatus.Retry;
            }
            else if (addTaskResult.BatchTaskResult.Status == BatchTaskAddStatus.ClientError && addTaskResult.BatchTaskResult.Error.Code == BatchErrorCode.TaskExists)
            {
                status = CreateTaskResultStatus.Failure; //TaskExists mark as failure
            }
            else
            {
                //Anything else is a failure -- abort the work flow
                throw new AddTaskCollectionTerminatedException(addTaskResult);
            }
        }
        return status;
    }
```
Here is an example of the custom CreateTaskResultHandler being used.

```C# Snippet:Batch_Sample02_CreateTasks_Custom_TaskCollectionResultHandler
int tasksCount = 1000;
List<BatchTaskCreateOptions> tasks = new List<BatchTaskCreateOptions>();
for (int i = 0; i < tasksCount; i++)
{
    tasks.Add(new BatchTaskCreateOptions($"task{i}", "cmd /c echo Hello World"));
}

// Create a CreateTaskOptions object with a custom CreateTaskResultHandler
CreateTasksOptions createTaskOptions = new CreateTasksOptions()
{
    CreateTaskResultHandler = new CustomTaskCollectionResultHandler(),
    ReturnBatchTaskCreateResults = true
};

// Create 1000 tasks in a single request using the default settings
CreateTasksResult result = await batchClient.CreateTasksAsync("jobId", tasks, createTaskOptions);

// Print the status of each task creation
foreach (BatchTaskCreateResult t in result.BatchTaskCreateResults)
{
    Console.WriteLine("Task {0} created with status  {1}. ",
        t.TaskId, t.Status);
}
```


### Task results

Onces the tasks are complete `GetTasksAsync` cand be used to retrieve the `BatchTask` instance and `GetTaskFileAsync` can be used to get the output files

```C# Snippet:Batch_Sample02_GetTasks
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
