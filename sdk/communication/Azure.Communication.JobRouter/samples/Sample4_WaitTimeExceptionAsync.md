# Azure.Communication.JobRouter Samples - trigger exception action using WaitTimeExceptionTrigger

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient` and send a request.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
var routerAdministrationClient = new RouterAdministrationClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Using WaitTimeExceptionTrigger to trigger job reclassification

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Exception_WaitTimeTrigger
// In this scenario, we are going to address how to escalate jobs when it had waited in queue for a threshold period of time
//
// We are going to use the exception policy associated with a queue to perform this task.
// We are going to create an exception policy with a WaitTimeExceptionTrigger, and a ManuallyReclassifyAction to enqueue the job
// to a different queue.
//
// Test setup:
// 1. Create an initial queue (Q1)
// 2. Enqueue job to Q1
// 3. Job waits for 30 seconds before exception policy hits

// Create distribution policy
var distributionPolicyId = "distribution-policy-id-9";

var distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(new CreateDistributionPolicyOptions(distributionPolicyId: distributionPolicyId,
    offerTtl: TimeSpan.FromSeconds(5),
    mode: new RoundRobinMode()));

// Create fallback queue
var fallbackQueueId = "fallback-q-id";
var fallbackQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
    queueId: fallbackQueueId,
    distributionPolicyId: distributionPolicyId));

// Create exception policy
// define trigger
var trigger = new WaitTimeExceptionTrigger(TimeSpan.FromSeconds(30)); // triggered after 5 minutes

// define exception action
var action = new ManualReclassifyExceptionAction(
    queueId: fallbackQueueId,
    priority: 100,
    workerSelectors: new List<WorkerSelector>()
    {
        new WorkerSelector("HandleEscalation", LabelOperator.Equal, new LabelValue(true))
    });

var exceptionPolicyId = "execption-policy-id";
var exceptionPolicy = await routerAdministrationClient.CreateExceptionPolicyAsync(new CreateExceptionPolicyOptions(
    exceptionPolicyId: exceptionPolicyId,
    exceptionRules: new Dictionary<string, ExceptionRule>()
    {
        ["WaitTimeTriggerExceptionRule"] = new ExceptionRule(
            trigger: trigger,
            actions: new Dictionary<string, ExceptionAction?>()
            {
                ["EscalateJobToFallbackQueueAction"] = action,
            })
    }));

// Create initial queue
var jobQueueId = "job-queue-id";
var jobQueue = await routerAdministrationClient.CreateQueueAsync(
    options: new CreateQueueOptions(
        queueId: jobQueueId,
        distributionPolicyId: distributionPolicyId)
    {
        ExceptionPolicyId = exceptionPolicyId,
    });

// create job
var jobId = "router-job-id";
var job = await routerClient.CreateJobAsync(new CreateJobOptions(
    jobId: jobId,
    channelId: "general",
    queueId: jobQueueId));

var queriedJob = await routerClient.GetJobAsync(jobId);

Console.WriteLine($"Job has been enqueued initially to queue with id: {jobQueueId}");

// Since there are no worker associated with the queue, no offers will be created for the job
// This can also happen when all the workers associated with the queue are busy and has no capacity

// We will wait for 30 seconds before the exception trigger kicks in
await Task.Delay(TimeSpan.FromSeconds(30));


queriedJob = await routerClient.GetJobAsync(jobId);

Console.WriteLine($"Exception has been triggered and job has been moved to queue with id: {fallbackQueueId}"); // fallback-q-id
Console.WriteLine($"Job priority has been raised to: {queriedJob.Value.Priority}"); // 100
Console.WriteLine($"Job has extra requirement for workers who can handler escalation now: {queriedJob.Value.RequestedWorkerSelectors.Any(ws => ws.Key == "HandlerEscalation" && ws.LabelOperator == LabelOperator.Equal && (bool)ws.Value.Value)}"); // true
```
