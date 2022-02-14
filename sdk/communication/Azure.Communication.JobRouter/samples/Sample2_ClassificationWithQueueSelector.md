# Azure.Communication.JobRouter Samples - Using QueueSelectors in Classification Policy

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
using Azure.Communication.JobRouter.Models;
```

## Create a client

Create a `RouterClient` and send a request.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Enqueue job to a queue using classification policy and queue id

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionById
// In this scenario we are going to use a classification policy while submitting a job.
// We are going to utilize the 'QueueSelectors' attribute on the classification policy to determine
// which queue a job should be enqueued in. For this scenario, we are going to demonstrate
// StaticLabelSelector to select a queue directly by its unique ID through the classification policy
// Steps
// 1. Create 2 Queues - Queue1(For Office 365 related jobs), Queue2(For XBox related jobs)
// 2. Create 2 classification policies - CP1(For Office 365 related jobs), CP2(For XBox related jobs)
// 3. Create 2 jobs - Job1 (with CP1), Job2 (with CP2)
//
// Output:
// 1. Job1 is enqueued in Queue1
// 2. Job2 is enqueued in Queue2

var distributionPolicy = await routerClient.SetDistributionPolicyAsync(
    id: "distribution-policy-id-2",
    name: "My LongestIdle Distribution Policy",
    offerTTL: TimeSpan.FromSeconds(30),
    mode: new LongestIdleMode()
    );

var queue1 = await routerClient.SetQueueAsync(
    id: "Queue-1",
    name: "Queue_365",
    distributionPolicyId: distributionPolicy.Value.Id);

var queue2 = await routerClient.SetQueueAsync(
    id: "Queue-2",
    name: "Queue_XBox",
    distributionPolicyId: distributionPolicy.Value.Id);

var cp1 = await routerClient.SetClassificationPolicyAsync(
    id: "classification-policy-o365",
    name: "Classification_Policy_O365",
    queueSelector: new QueueIdSelector(new StaticRule(queue1.Value.Id)));

var cp2 = await routerClient.SetClassificationPolicyAsync(
    id: "classification-policy-xbox",
    name: "Classification_Policy_XBox",
    queueSelector: new QueueIdSelector(new StaticRule(queue2.Value.Id)));

var jobO365 = await routerClient.CreateJobWithClassificationPolicyAsync(
    channelId: "general",
    classificationPolicyId: cp1.Value.Id,
    channelReference: "12345");

var jobXbox = await routerClient.CreateJobWithClassificationPolicyAsync(
    channelId: "general",
    classificationPolicyId: cp2.Value.Id,
    channelReference: "12345");


var jobO365Result = await routerClient.GetJobAsync(jobO365.Value.Id);
var jobXBoxResult = await routerClient.GetJobAsync(jobXbox.Value.Id);

Console.WriteLine($"O365 job has been enqueued in queue: {queue1.Value.Id}. Status: {jobO365Result.Value.QueueId == queue1.Value.Id}");
Console.WriteLine($"XBox job has been enqueued in queue: {queue2.Value.Id}. Status: {jobXBoxResult.Value.QueueId == queue2.Value.Id}");
```

## Enqueue job to a queue using classification policy and conditional label attachments

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionByConditionalLabelAttachments
// In this scenario we are going to use a classification policy while submitting a job.
// We are going to utilize the 'QueueSelectors' attribute on the classification policy to determine
// which queue a job should be enqueued in. For this scenario, we are going to demonstrate
// ConditionalLabelSelector to select a queue based on labels associated with a queue
// Steps
// 1. Create 2 Queues
//     - Queue1(For Office 365 related jobs) - with label {ProductDetail = 'Office_Support'},
//     - Queue2(For XBox related jobs) - with label {ProductDetail = 'XBox_Support'},
// 2. Create 1 classification policy
//    - Set condition: If job.Product == O365, then attach label {ProductDetail = 'Office_Support'}
//                     Else if job.Product == XBx, then attach labels {ProductDetail = 'XBox_Support'}
// 3. Create 2 jobs
//     - Job1 - with label {Product = 'O365'}
//     - Job2 - with labels {Product = 'XBx'}
//
// Output:
// 1. Job1 is enqueued in Queue1
// 2. Job2 is enqueued in Queue2

var distributionPolicy = await routerClient.SetDistributionPolicyAsync(
    id: "distribution-policy-id-3",
    name: "My LongestIdle Distribution Policy",
    offerTTL: TimeSpan.FromSeconds(30),
    mode: new LongestIdleMode()
    );

var queue1 = await routerClient.SetQueueAsync(
    id: "Queue-1",
    name: "Queue_365",
    distributionPolicyId: distributionPolicy.Value.Id,
    labels: new LabelCollection()
    {
        ["ProductDetail"] = "Office_Support"
    });

var queue2 = await routerClient.SetQueueAsync(
    id: "Queue-2",
    name: "Queue_XBox",
    distributionPolicyId: distributionPolicy.Value.Id,
    labels: new LabelCollection()
    {
        ["ProductDetail"] = "XBox_Support"
    });

var labelSelectors = new List<LabelSelectorAttachment>()
{
    new ConditionalLabelSelector(
        condition: new ExpressionRule("If(job.Product = \"O365\", true, false)"),
        labelSelectors: new List<LabelSelector>()
        {
            new LabelSelector("ProductDetail", LabelOperator.Equal, "Office_Support")
        }),
    new ConditionalLabelSelector(
        condition: new ExpressionRule("If(job.Product = \"XBx\", true, false)"),
        labelSelectors: new List<LabelSelector>()
        {
            new LabelSelector("ProductDetail", LabelOperator.Equal, "XBox_Support")
        })
};

var classificationPolicy = await routerClient.SetClassificationPolicyAsync(
    id: "classification-policy",
    name: "Classification_Policy_O365_And_XBox",
    queueSelector: new QueueLabelSelector(labelSelectors)
    );

var jobO365 = await routerClient.CreateJobWithClassificationPolicyAsync(
    channelId: "general",
    classificationPolicyId: classificationPolicy.Value.Id,
    channelReference: "12345",
    labels: new LabelCollection()
    {
        ["Language"] = "en",
        ["Product"] = "O365",
        ["Geo"] = "North America",
    });

var jobXbox = await routerClient.CreateJobWithClassificationPolicyAsync(
    channelId: "general",
    classificationPolicyId: classificationPolicy.Value.Id,
    channelReference: "12345",
    labels: new LabelCollection()
    {
        ["Language"] = "en",
        ["Product"] = "XBx",
        ["Geo"] = "North America",
    });


var jobO365Result = await routerClient.GetJobAsync(jobO365.Value.Id);
var jobXBoxResult = await routerClient.GetJobAsync(jobXbox.Value.Id);

Console.WriteLine($"O365 job has been enqueued in queue: {queue1.Value.Id}. Status: {jobO365Result.Value.QueueId == queue1.Value.Id}");
Console.WriteLine($"XBox job has been enqueued in queue: {queue2.Value.Id}. Status: {jobXBoxResult.Value.QueueId == queue2.Value.Id}");
```

## Enqueue job to a queue using classification policy and pass through label attachments

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionByPassThroughLabelAttachments
// In this scenario we are going to use a classification policy while submitting a job.
// We are going to utilize the 'QueueSelectors' attribute on the classification policy to determine
// which queue a job should be enqueued in. For this scenario, we are going to demonstrate
// PassThroughLabelSelector to select a queue based on labels associated with a queue and the incoming job
// Steps
// 1. Create 3 Queues
//     - Queue1(For Office 365 related jobs - EN - EMEA) - with labels {ProductDetail = 'Office_Support', Language = 'en', Region = 'EMEA'},
//     - Queue2(For Office 365 related jobs - FR - EMEA) - with labels {ProductDetail = 'Office_Support', Language = 'fr', Region = 'EMEA'},
//     - Queue3(For Office 365 related jobs - EN - NA) - with labels {ProductDetail = 'Office_Support', Language = 'en', Region = 'NA'},
// 2. Create 1 classification policy
//    - Set condition: Pass through the following properties from job: ProductDetail, Language, Region
// 3. Create 3 jobs
//     - Job1 - with labels {Product = 'O365', ProductDetail = 'Office_Support', Language = 'en', Region = 'EMEA'}
//     - Job2 - with labels {Product = 'O365', ProductDetail = 'Office_Support', Language = 'fr', Region = 'EMEA'}
//     - Job3 - with labels {Product = 'O365', ProductDetail = 'Office_Support', Language = 'en', Region = 'NA'}
//
// Output:
// 1. Job1 is enqueued in Queue1
// 2. Job2 is enqueued in Queue2
// 3. Job3 is enqueued in Queue3

var distributionPolicy = await routerClient.SetDistributionPolicyAsync(
    id: "distribution-policy-id-3",
    name: "My LongestIdle Distribution Policy",
    offerTTL: TimeSpan.FromSeconds(30),
    mode: new LongestIdleMode()
    );

var queue1 = await routerClient.SetQueueAsync(
    id: "Queue-1",
    name: "Queue_365_EN_EMEA",
    distributionPolicyId: distributionPolicy.Value.Id,
    labels: new LabelCollection()
    {
        ["ProductDetail"] = "Office_Support",
        ["Language"] = "en",
        ["Region"] = "EMEA",
    });

var queue2 = await routerClient.SetQueueAsync(
    id: "Queue-2",
    name: "Queue_365_FR_EMEA",
    distributionPolicyId: distributionPolicy.Value.Id,
    labels: new LabelCollection()
    {
        ["ProductDetail"] = "Office_Support",
        ["Language"] = "fr",
        ["Region"] = "EMEA",
    });

var queue3 = await routerClient.SetQueueAsync(
    id: "Queue-3",
    name: "Queue_365_EN_NA",
    distributionPolicyId: distributionPolicy.Value.Id,
    labels: new LabelCollection()
    {
        ["ProductDetail"] = "Office_Support",
        ["Language"] = "en",
        ["Region"] = "NA",
    });

var labelSelectors = new List<LabelSelectorAttachment>()
{
    new PassThroughLabelSelector("ProductDetail", LabelOperator.Equal),
    new PassThroughLabelSelector("Language", LabelOperator.Equal),
    new PassThroughLabelSelector("Region", LabelOperator.Equal),
};

var classificationPolicy = await routerClient.SetClassificationPolicyAsync(
    id: "classification-policy",
    name: "Classification_Policy_O365_EMEA_NA",
    queueSelector: new QueueLabelSelector(labelSelectors)
    );

var jobENEmea = await routerClient.CreateJobWithClassificationPolicyAsync(
    channelId: "general",
    classificationPolicyId: classificationPolicy.Value.Id,
    channelReference: "12345",
    labels: new LabelCollection()
    {
        ["Language"] = "en",
        ["Product"] = "O365",
        ["Geo"] = "Europe, Middle East, Africa",
        ["ProductDetail"] = "Office_Support",
        ["Region"] = "EMEA",
    });

var jobFREmea = await routerClient.CreateJobWithClassificationPolicyAsync(
    channelId: "general",
    classificationPolicyId: classificationPolicy.Value.Id,
    channelReference: "12345",
    labels: new LabelCollection()
    {
        ["Language"] = "fr",
        ["Product"] = "O365",
        ["Geo"] = "Europe, Middle East, Africa",
        ["ProductDetail"] = "Office_Support",
        ["Region"] = "EMEA",
    });

var jobENNa = await routerClient.CreateJobWithClassificationPolicyAsync(
    channelId: "general",
    classificationPolicyId: classificationPolicy.Value.Id,
    channelReference: "12345",
    labels: new LabelCollection()
    {
        ["Language"] = "en",
        ["Product"] = "O365",
        ["Geo"] = "North America",
        ["ProductDetail"] = "Office_Support",
        ["Region"] = "NA",
    });


var jobENEmeaResult = await routerClient.GetJobAsync(jobENEmea.Value.Id);
var jobFREmeaResult = await routerClient.GetJobAsync(jobFREmea.Value.Id);
var jobENNaResult = await routerClient.GetJobAsync(jobENNa.Value.Id);

Console.WriteLine($"O365 EN EMEA job has been enqueued in queue: {queue1.Value.Id}. Status: {jobENEmeaResult.Value.QueueId == queue1.Value.Id}");
Console.WriteLine($"O365 FR EMEA job has been enqueued in queue: {queue2.Value.Id}. Status: {jobFREmeaResult.Value.QueueId == queue2.Value.Id}");
Console.WriteLine($"O365 EN NA job has been enqueued in queue: {queue3.Value.Id}. Status: {jobENEmeaResult.Value.QueueId == queue3.Value.Id}");
```
<!--
TODO:
## Enqueue job to a queue using classification policy and label attachments from custom rule
--->
