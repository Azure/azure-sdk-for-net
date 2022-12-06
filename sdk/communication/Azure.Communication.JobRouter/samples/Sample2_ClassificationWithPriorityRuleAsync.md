# Azure.Communication.JobRouter Samples - Using prioritization rule in Classification Policy

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
```

## Create a client

Create a `RouterClient` and send a request.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
RouterClient routerClient = new RouterClient("<< CONNECTION STRING >>");
RouterAdministrationClient routerAdministrationClient = new RouterAdministrationClient("<< CONNECTION STRING >>");
```

## Assign priority value to job using StaticRule

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyStaticRule
// In this scenario we are going to create a classification policy which assigns a static value of 10 to every job
// The classification policy will be setup to add only the priority value to a job
// Hence, when the job will be created it will have a queueId assigned to it

// define the classification policy
string classificationPolicyId = "static-priority";
Response<ClassificationPolicy> classificationPolicy = await routerAdministration.CreateClassificationPolicyAsync(
    new CreateClassificationPolicyOptions(classificationPolicyId: classificationPolicyId)
    {
        PrioritizationRule = new StaticRule(new LabelValue(10))
    });

Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

// setting up queue

// Create distribution policy for queue
string distributionPolicyId = "longest-idle-distribution";
Response<DistributionPolicy> distributionPolicy = await routerAdministration.CreateDistributionPolicyAsync(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: distributionPolicyId,
        offerTtl: TimeSpan.FromMinutes(5),
        mode: new LongestIdleMode()));

Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

// Create queue
string jobQueueId = "my-default-queue";
Response<JobQueue> jobQueue =
    await routerAdministration.CreateQueueAsync(new CreateQueueOptions(queueId: jobQueueId, distributionPolicyId: distributionPolicyId));

Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

// Create a job

Response<RouterJob> job = await routerClient.CreateJobAsync(
    options: new CreateJobWithClassificationPolicyOptions(
        jobId: "demo-job-id",
        channelId: "Voip",
        classificationPolicyId: classificationPolicyId)
    {
        QueueId = jobQueueId
    });

Console.WriteLine($"Job has been successfully created with id: {job.Value.Id}, and status: {job.Value.JobStatus}"); // Status: PendingClassification


// After a few seconds, the job would have successfully classified and queued

Response<RouterJob> queriedJob = await routerClient.GetJobAsync(job.Value.Id);

Console.WriteLine($"Job has been successfully queued: {queriedJob.Value.JobStatus == RouterJobStatus.Queued}");
Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob.Value.QueueId == jobQueueId}");
Console.WriteLine($"Job has been assigned a priority value: {queriedJob.Value.Priority}"); // 10
```

## Assign priority value to job using ExpressionRule

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyExpressionRule
// In this scenario we are going to create a classification policy which assigns a priority value by evaluating a simple PowerFx expression
// The classification policy will be setup to add only the priority value to a job
// Hence, when the job will be created it will have a queueId assigned to it

// define the classification policy
string classificationPolicyId = "expression-priority";
Response<ClassificationPolicy> classificationPolicy = await routerAdministration.CreateClassificationPolicyAsync(
    new CreateClassificationPolicyOptions(classificationPolicyId: classificationPolicyId)
    {
        PrioritizationRule = new ExpressionRule("If(job.Escalated = true, 10, 1)") // this will check whether the job has a label "Escalated" set to "true"
    });

Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

// setting up queue

// Create distribution policy for queue
string distributionPolicyId = "longest-idle-distribution";
Response<DistributionPolicy> distributionPolicy = await routerAdministration.CreateDistributionPolicyAsync(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: distributionPolicyId,
        offerTtl: TimeSpan.FromMinutes(5),
        mode: new LongestIdleMode()));

Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

// Create queue
string jobQueueId = "my-default-queue";
Response<JobQueue> jobQueue =
    await routerAdministration.CreateQueueAsync(new CreateQueueOptions(queueId: jobQueueId, distributionPolicyId: distributionPolicyId));

Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

// Create a job

Response<RouterJob> job1 = await routerClient.CreateJobAsync(
    options: new CreateJobWithClassificationPolicyOptions(
        jobId: "demo-job-id-1",
        channelId: "Voip",
        classificationPolicyId: classificationPolicyId)
    {
        QueueId = jobQueueId,
        Labels = new Dictionary<string, LabelValue>()
        {
            ["Escalated"] = new LabelValue(false)
        }
    });

Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.JobStatus}"); // Status: PendingClassification

Response<RouterJob> job2 = await routerClient.CreateJobAsync(
    options: new CreateJobWithClassificationPolicyOptions(
        jobId: "demo-job-id-2",
        channelId: "Voip",
        classificationPolicyId: classificationPolicyId)
    {
        QueueId = jobQueueId,
        Labels = new Dictionary<string, LabelValue>()
        {
            ["Escalated"] = new LabelValue(true)
        }
    });

Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.JobStatus}"); // Status: PendingClassification


// After a few seconds, both jobs would have successfully classified and queued

Response<RouterJob> queriedJob1 = await routerClient.GetJobAsync(job1.Value.Id);

Console.WriteLine($"Job has been successfully queued: {queriedJob1.Value.JobStatus == RouterJobStatus.Queued}");
Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob1.Value.QueueId == jobQueueId}");
Console.WriteLine($"Job has been assigned a priority value: {queriedJob1.Value.Priority}"); // 1

Response<RouterJob> queriedJob2 = await routerClient.GetJobAsync(job1.Value.Id);

Console.WriteLine($"Job has been successfully queued: {queriedJob2.Value.JobStatus == RouterJobStatus.Queued}");
Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob2.Value.QueueId == jobQueueId}");
Console.WriteLine($"Job has been assigned a priority value: {queriedJob2.Value.Priority}"); // 10
```

## Assign priority value to job using AzureFunctionRule

We define the azure function as following:
> [!NOTE]
> The following Azure function is using JavaScript. For more information, please refer to [Quickstart: Create a JavaScript function in Azure using Visual Studio Code][azure-func-js-quickstart]

```javascript
module.exports = async function (context, req) {
    context.log('Simple prioritization rule for classification');

    let score = 1;
    const jobLabels = req.body.job;

    const isEscalated = !!jobLabels["Escalated"];
    context.log('Job is escalated? Status: ' + isHighPriority);

    if(isHighPriority) {
        score = 10;
    }
    context.log('Final priority value: ' + score);

    context.res = {
        // status: 200, /* Defaults to 200 */
        body: score
    };
}
```

Setting up using the Router SDK:

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyAzureFunctionRule
// In this scenario we are going to create a classification policy which assigns a priority value by evaluating a simple AzureFunction
// The classification policy will be setup to add only the priority value to a job
// Hence, when the job will be created it will have a queueId assigned to it

// define the classification policy
string classificationPolicyId = "expression-priority";
Response<ClassificationPolicy> classificationPolicy = await routerAdministration.CreateClassificationPolicyAsync(
    new CreateClassificationPolicyOptions(classificationPolicyId: classificationPolicyId)
    {
        PrioritizationRule = new FunctionRule(new Uri("<insert azure function rule URI>")) // this will check whether the job has a label "Escalated" set to "true"
    });

Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

// setting up queue

// Create distribution policy for queue
string distributionPolicyId = "longest-idle-distribution";
Response<DistributionPolicy> distributionPolicy = await routerAdministration.CreateDistributionPolicyAsync(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: distributionPolicyId,
        offerTtl: TimeSpan.FromMinutes(5),
        mode: new LongestIdleMode()));

Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

// Create queue
string jobQueueId = "my-default-queue";
Response<JobQueue> jobQueue =
    await routerAdministration.CreateQueueAsync(new CreateQueueOptions(queueId: jobQueueId, distributionPolicyId: distributionPolicyId));

Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

// Create a job

Response<RouterJob> job1 = await routerClient.CreateJobAsync(
    options: new CreateJobWithClassificationPolicyOptions(
        jobId: "demo-job-id-1",
        channelId: "Voip",
        classificationPolicyId: classificationPolicyId)
    {
        QueueId = jobQueueId,
        Labels = new Dictionary<string, LabelValue>()
        {
            ["Escalated"] = new LabelValue(false)
        }
    });

Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.JobStatus}"); // Status: PendingClassification

Response<RouterJob> job2 = await routerClient.CreateJobAsync(
    options: new CreateJobWithClassificationPolicyOptions(
        jobId: "demo-job-id-2",
        channelId: "Voip",
        classificationPolicyId: classificationPolicyId)
    {
        QueueId = jobQueueId,
        Labels = new Dictionary<string, LabelValue>()
        {
            ["Escalated"] = new LabelValue(true)
        }
    });

Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.JobStatus}"); // Status: PendingClassification


// After a few seconds, both jobs would have successfully classified and queued

Response<RouterJob> queriedJob1 = await routerClient.GetJobAsync(job1.Value.Id);

Console.WriteLine($"Job has been successfully queued: {queriedJob1.Value.JobStatus == RouterJobStatus.Queued}");
Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob1.Value.QueueId == jobQueueId}");
Console.WriteLine($"Job has been assigned a priority value: {queriedJob1.Value.Priority}"); // 1

Response<RouterJob> queriedJob2 = await routerClient.GetJobAsync(job1.Value.Id);

Console.WriteLine($"Job has been successfully queued: {queriedJob2.Value.JobStatus == RouterJobStatus.Queued}");
Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob2.Value.QueueId == jobQueueId}");
Console.WriteLine($"Job has been assigned a priority value: {queriedJob2.Value.Priority}"); // 10
```

<!-- LINKS -->
[azure-func-js-quickstart]: https://docs.microsoft.com/azure/azure-functions/create-first-function-vs-code-node
