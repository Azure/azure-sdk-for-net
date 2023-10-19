# Azure.Communication.JobRouter Samples - Router Worker CRUD operations (async)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient`.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");
```

## Create a worker

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_CreateRouterWorker_Async
string routerWorkerId = "my-router-worker";

Response<RouterWorker> worker = await routerClient.CreateWorkerAsync(
    new CreateWorkerOptions(
        workerId: routerWorkerId,
        totalCapacity: 100)
    {
        QueueAssignments =
        {
            ["worker-q-1"] = new RouterQueueAssignment(),
            ["worker-q-2"] = new RouterQueueAssignment()
        },
        ChannelConfigurations =
        {
            ["WebChat"] = new ChannelConfiguration(1),
            ["WebChatEscalated"] = new ChannelConfiguration(20),
            ["Voip"] = new ChannelConfiguration(100)
        },
        Labels =
        {
            ["Location"] = new LabelValue("NA"),
            ["English"] = new LabelValue(7),
            ["O365"] = new LabelValue(true),
            ["Xbox_Support"] = new LabelValue(false)
        },
        Tags =
        {
            ["Name"] = new LabelValue("John Doe"),
            ["Department"] = new LabelValue("IT_HelpDesk")
        }
    }
);

Console.WriteLine($"Router worker successfully created with id: {worker.Value.Id}");
```

## Get a worker

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorker_Async
Response<RouterWorker> queriedWorker = await routerClient.GetWorkerAsync(routerWorkerId);

Console.WriteLine($"Successfully fetched worker with id: {queriedWorker.Value.Id}");
Console.WriteLine($"Worker associated with queues: {queriedWorker.Value.QueueAssignments.Values.ToList()}");
```

## Update a worker

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_UpdateRouterWorker_Async
// we are going to
// 1. Assign the worker to another queue
// 2. Modify an value of label: `O365`
// 3. Delete label: `Xbox_Support`
// 4. Add a new label: `Xbox_Support_EN` and set value true
// 5. Increase capacityCostPerJob for channel `WebChatEscalated` to 50

Response<RouterWorker> updateWorker = await routerClient.UpdateWorkerAsync(
    new UpdateWorkerOptions(routerWorkerId)
    {
        QueueAssignments = { ["worker-q-3"] = new RouterQueueAssignment() },
        ChannelConfigurations = { ["WebChatEscalated"] = new ChannelConfiguration(50), },
        Labels =
        {
            ["O365"] = new LabelValue("Supported"),
            ["Xbox_Support"] = new LabelValue(null),
            ["Xbox_Support_EN"] = new LabelValue(true),
        }
    });

Console.WriteLine($"Worker successfully updated with id: {updateWorker.Value.Id}");
Console.Write($"Worker now associated with {updateWorker.Value.QueueAssignments.Count} queues"); // 3 queues
```

## Register a worker

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_RegisterRouterWorker_Async
updateWorker = await routerClient.UpdateWorkerAsync(
    options: new UpdateWorkerOptions(workerId: routerWorkerId) { AvailableForOffers = true, });

Console.WriteLine($"Worker successfully registered with status set to: {updateWorker.Value.State}");
```

## Deregister a worker

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeregisterRouterWorker_Async
updateWorker = await routerClient.UpdateWorkerAsync(
    options: new UpdateWorkerOptions(workerId: routerWorkerId) { AvailableForOffers = false, });

Console.WriteLine($"Worker successfully de-registered with status set to: {updateWorker.Value.State}");
```

## List workers

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_GetRouterWorkers_Async
AsyncPageable<RouterWorkerItem> workers = routerClient.GetWorkersAsync();
await foreach (Page<RouterWorkerItem> asPage in workers.AsPages(pageSizeHint: 10))
{
    foreach (RouterWorkerItem? workerPaged in asPage.Values)
    {
        Console.WriteLine($"Listing exception policy with id: {workerPaged.Worker.Id}");
    }
}

// Additionally workers can be queried with several filters like queueId, capacity, state etc.
workers = routerClient.GetWorkersAsync(channelId: "Voip", state: RouterWorkerStateSelector.All);

await foreach (Page<RouterWorkerItem> asPage in workers.AsPages(pageSizeHint: 10))
{
    foreach (RouterWorkerItem? workerPaged in asPage.Values)
    {
        Console.WriteLine($"Listing exception policy with id: {workerPaged.Worker.Id}");
    }
}
```

## Delete a worker

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Crud_DeleteRouterWorker_Async
_ = await routerClient.DeleteWorkerAsync(routerWorkerId);
```
