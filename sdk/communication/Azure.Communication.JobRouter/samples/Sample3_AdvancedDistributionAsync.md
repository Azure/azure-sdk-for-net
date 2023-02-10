# Azure.Communication.JobRouter Samples - Using distribution policy (simple scenarios)

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

## Using expression rule with best worker distribution mode

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_ExpressionRule
// In this scenario, we are going to create a simple PowerFx expression rule to check whether a worker can handler escalation or not
// If the worker can handler escalation then they are given a score of 100, otherwise a score of 1

// Create distribution policy
string distributionPolicyId = "best-worker-dp-2";
Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: distributionPolicyId,
        offerTtl: TimeSpan.FromMinutes(5),
        mode: new BestWorkerMode(scoringRule: new ExpressionRule("If(worker.HandleEscalation = true, 100, 1)"))));

// Create job queue
string jobQueueId = "job-queue-id-2";
Response<JobQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
    queueId: jobQueueId,
    distributionPolicyId: distributionPolicyId));

string channelId = "general";

// Create two workers
string worker1Id = "worker-Id-1";
string worker2Id = "worker-Id-2";

// Worker 1 can handle escalation
Dictionary<string, LabelValue> worker1Labels = new Dictionary<string, LabelValue>()
{
    ["HandleEscalation"] = new LabelValue(true),
    ["IT_Support"] = new LabelValue(true)
};

Response<RouterWorker> worker1 = await routerClient.CreateWorkerAsync(
    options: new CreateWorkerOptions(workerId: worker1Id, totalCapacity: 10)
    {
        AvailableForOffers = true,
        ChannelConfigurations =
            new Dictionary<string, ChannelConfiguration>()
            {
                [channelId] = new ChannelConfiguration(10),
            },
        Labels = worker1Labels,
        QueueIds = new Dictionary<string, QueueAssignment>() { [jobQueueId] = new QueueAssignment(), }
    });

// Worker 2 cannot handle escalation
Dictionary<string, LabelValue> worker2Labels = new Dictionary<string, LabelValue>()
{
    ["IT_Support"] = new LabelValue(true),
};

Response<RouterWorker> worker2 = await routerClient.CreateWorkerAsync(
    options: new CreateWorkerOptions(workerId: worker2Id, totalCapacity: 10)
    {
        AvailableForOffers = true,
        ChannelConfigurations =
            new Dictionary<string, ChannelConfiguration>() { [channelId] = new ChannelConfiguration(10), },
        Labels = worker2Labels,
        QueueIds = new Dictionary<string, QueueAssignment>() { [jobQueueId] = new QueueAssignment(), },
    });

// Create job
string jobId = "job-id-2";
Response<RouterJob> job = await routerClient.CreateJobAsync(
    options: new CreateJobOptions(jobId: jobId, channelId: channelId, queueId: jobQueueId)
    {
        RequestedWorkerSelectors = new List<WorkerSelector>(){ new WorkerSelector("IT_Support", LabelOperator.Equal, new LabelValue(true))},
        Priority = 100,
    });


Response<RouterWorker> queriedWorker1 = await routerClient.GetWorkerAsync(worker1Id);
Response<RouterWorker> queriedWorker2 = await routerClient.GetWorkerAsync(worker2Id);

Console.WriteLine($"Worker 1 has been offered: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobId)}");
Console.WriteLine($"Worker 2 has not been offered: {queriedWorker2.Value.Offers.All(offer => offer.JobId != jobId)}");
```

## Using azure function rule with best worker distribution mode

### Situation

- A job has been created and classified.
  - Job has the following **labels** associated with it
    - ["CommunicationType"] = "Chat"
    - ["IssueType"] = "XboxSupport"
    - ["Language"] = "en"
    - ["HighPriority"] = true
    - ["SubIssueType"] = "ConsoleMalfunction"
    - ["ConsoleType"] = "XBOX_SERIES_X"
    - ["Model"] = "XBOX_SERIES_X_1TB"
  - Job has the following **WorkerSelectors** associated with it
    - ["English"] >= 7
    - ["ChatSupport"] = true
    - ["XboxSupport"] = true
- Job currently is in a state of '**Queued**'; enqueued in *Xbox Hardware Support Queue* waiting to be matched to a worker.
- Multiple workers become available simultaneously.
  - **Worker 1** has been created with the following **labels**
    - ["HighPrioritySupport"] = true
    - ["HardwareSupport"] = true
    - ["Support_XBOX_SERIES_X"] = true
    - ["English"] = 10
    - ["ChatSupport"] = true
    - ["XboxSupport"] = true
  - **Worker 2** has been created with the following **labels**
    - ["HighPrioritySupport"] = true
    - ["HardwareSupport"] = true
    - ["Support_XBOX_SERIES_X"] = true
    - ["Support_XBOX_SERIES_S"] = true
    - ["English"] = 8
    - ["ChatSupport"] = true
    - ["XboxSupport"] = true
  - **Worker 3** has been created with the following **labels**
    - ["HighPrioritySupport"] = false
    - ["HardwareSupport"] = true
    - ["Support_XBOX"] = true
    - ["English"] = 7
    - ["ChatSupport"] = true
    - ["XboxSupport"] = true

We would like the following behavior when scoring workers to select which worker gets the first offer.

The decision flow (as shown above) is as follows:

- If a job is **NOT HighPriority**:
  - Workers with label: **["Support_XBOX"] = true**; get a score of *100*
  - Otherwise, get a score of *1*

- If a job is **HighPriority**:
  - Workers with label: **["HighPrioritySupport"] = false**; get a score of *1*
  - Otherwise, if **["HighPrioritySupport"] = true**:
    - Does Worker specialize in console type -> Does worker have label: **["Support_<**jobLabels.ConsoleType**>"] = true**? If true, worker gets score of *200*
    - Otherwise, get a score of *100*

### Pre-requisite: creating an azure function

Before moving on any further in the process, let us first define an Azure function that scores worker.
> [!NOTE]
> The following Azure function is using JavaScript. For more information, please refer to [Quickstart: Create a JavaScript function in Azure using Visual Studio Code](https://docs.microsoft.com/azure/azure-functions/create-first-function-vs-code-node)

Sample input for **Worker 1**

```json
{
  "job": {
    "CommunicationType": "Chat",
    "IssueType": "XboxSupport",
    "Language": "en",
    "HighPriority": true,
    "SubIssueType": "ConsoleMalfunction",
    "ConsoleType": "XBOX_SERIES_X",
    "Model": "XBOX_SERIES_X_1TB"
  },
  "selectors": [
    {
      "key": "English",
      "operator": "GreaterThanEqual",
      "value": 7,
      "ttl": null
    },
    {
      "key": "ChatSupport",
      "operator": "Equal",
      "value": true,
      "ttl": null
    },
    {
      "key": "XboxSupport",
      "operator": "Equal",
      "value": true,
      "ttl": null
    }
  ],
  "worker": {
    "Id": "e3a3f2f9-3582-4bfe-9c5a-aa57831a0f88",
    "HighPrioritySupport": true,
    "HardwareSupport": true,
    "Support_XBOX_SERIES_X": true,
    "English": 10,
    "ChatSupport": true,
    "XboxSupport": true
  }
}
```

Sample implementation of Azure function

```javascript
module.exports = async function (context, req) {
    context.log('Best Worker Distribution Mode using Azure Function');

    let score = 0;
    const jobLabels = req.body.job;
    const workerLabels = req.body.worker;

    const isHighPriority = !!jobLabels["HighPriority"];
    context.log('Job is high priority? Status: ' + isHighPriority);

    if(!isHighPriority) {
        const isGenericXboxSupportWorker = !!workerLabels["Support_XBOX"];
        context.log('Worker provides general xbox support? Status: ' + isGenericXboxSupportWorker);

        score = isGenericXboxSupportWorker ? 100 : 1;

    } else {
        const workerSupportsHighPriorityJob = !!workerLabels["HighPrioritySupport"];
        context.log('Worker provides high priority support? Status: ' + workerSupportsHighPriorityJob);

        if(!workerSupportsHighPriorityJob) {
            score = 1;
        } else {
            const key = `Support_${jobLabels["ConsoleType"]}`;
            
            const workerSpecializeInConsoleType = !!workerLabels[key];
            context.log(`Worker specializes in consoleType: ${jobLabels["ConsoleType"]} ? Status: ${workerSpecializeInConsoleType}`);

            score = workerSpecializeInConsoleType ? 200 : 100;
        }
    }
    context.log('Final score of worker: ' + score);

    context.res = {
        // status: 200, /* Defaults to 200 */
        body: score
    };
}
```

Output for **Worker 1**

```markdown
200
```

With the aforementioned implementation, for the given job we'll get the following scores for workers:

| Worker | Score |
|--------|-------|
| Worker 1 | 200 |
| Worker 2 | 200 |
| Worker 3 | 1 |

Let us set up the rest using the Router SDK.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_AzureFunctionRule
// Create distribution policy
string distributionPolicyId = "best-worker-dp-1";
Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
    new CreateDistributionPolicyOptions(
        distributionPolicyId: distributionPolicyId,
        offerTtl: TimeSpan.FromMinutes(5),
        mode: new BestWorkerMode(scoringRule: new FunctionRule(new Uri("<insert function url>")))));

// Create job queue
string queueId = "job-queue-id-1";
Response<JobQueue> jobQueue = await routerAdministrationClient.CreateQueueAsync(new CreateQueueOptions(
    queueId: queueId,
    distributionPolicyId: distributionPolicyId));

string channelId = "general";

// Create workers

string workerId1 = "worker-Id-1";
Dictionary<string, LabelValue> worker1Labels = new Dictionary<string, LabelValue>()
{
    ["HighPrioritySupport"] = new LabelValue(true),
    ["HardwareSupport"] = new LabelValue(true),
    ["Support_XBOX_SERIES_X"] = new LabelValue(true),
    ["English"] = new LabelValue(10),
    ["ChatSupport"] = new LabelValue(true),
    ["XboxSupport"] = new LabelValue(true)
};

Response<RouterWorker> worker1 = await routerClient.CreateWorkerAsync(
    options: new CreateWorkerOptions(workerId: workerId1, totalCapacity: 100)
    {
        QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
        Labels = worker1Labels,
        ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
        {
            [channelId] = new ChannelConfiguration(10),
        },
        AvailableForOffers = true,
    });

string workerId2 = "worker-Id-2";
Dictionary<string, LabelValue> worker2Labels = new Dictionary<string, LabelValue>()
{
    ["HighPrioritySupport"] = new LabelValue(true),
    ["HardwareSupport"] = new LabelValue(true),
    ["Support_XBOX_SERIES_X"] = new LabelValue(true),
    ["Support_XBOX_SERIES_S"] = new LabelValue(true),
    ["English"] = new LabelValue(8),
    ["ChatSupport"] = new LabelValue(true),
    ["XboxSupport"] = new LabelValue(true)
};

Response<RouterWorker> worker2 = await routerClient.CreateWorkerAsync(
    options: new CreateWorkerOptions(workerId: workerId2, totalCapacity: 100)
    {
        QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
        Labels = worker2Labels,
        ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
        {
            [channelId] = new ChannelConfiguration(10),
        },
        AvailableForOffers = true,
    });

string workerId3 = "worker-Id-3";
Dictionary<string, LabelValue> worker3Labels = new Dictionary<string, LabelValue>()
{
    ["HighPrioritySupport"] = new LabelValue(false),
    ["HardwareSupport"] = new LabelValue(true),
    ["Support_XBOX"] = new LabelValue(true),
    ["English"] = new LabelValue(7),
    ["ChatSupport"] = new LabelValue(true),
    ["XboxSupport"] = new LabelValue(true),
};

Response<RouterWorker> worker3 = await routerClient.CreateWorkerAsync(
    options: new CreateWorkerOptions(workerId: workerId3, totalCapacity: 100)
    {
        QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
        Labels = worker3Labels,
        ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
        {
            [channelId] = new ChannelConfiguration(10),
        },
        AvailableForOffers = true,
    });

// Create job
Dictionary<string, LabelValue> jobLabels = new Dictionary<string, LabelValue>()
{
    ["CommunicationType"] = new LabelValue("Chat"),
    ["IssueType"] = new LabelValue("XboxSupport"),
    ["Language"] = new LabelValue("en"),
    ["HighPriority"] = new LabelValue(true),
    ["SubIssueType"] = new LabelValue("ConsoleMalfunction"),
    ["ConsoleType"] = new LabelValue("XBOX_SERIES_X"),
    ["Model"] = new LabelValue("XBOX_SERIES_X_1TB")
};

string jobId = "job-id-1";
List<WorkerSelector> workerSelectors = new List<WorkerSelector>()
{
    new WorkerSelector("English", LabelOperator.GreaterThanEqual, new LabelValue(7)),
    new WorkerSelector("ChatSupport", LabelOperator.Equal, new LabelValue(true)),
    new WorkerSelector("XboxSupport", LabelOperator.Equal, new LabelValue(true))
};

Response<RouterJob> job = await routerClient.CreateJobAsync(
    options: new CreateJobOptions(
        jobId: jobId,
        channelId: channelId,
        queueId: queueId)
    {
        Labels = jobLabels, RequestedWorkerSelectors = workerSelectors, Priority = 100,
    });


Response<RouterWorker> queriedWorker1 = await routerClient.GetWorkerAsync(workerId1);
Response<RouterWorker> queriedWorker2 = await routerClient.GetWorkerAsync(workerId2);
Response<RouterWorker> queriedWorker3 = await routerClient.GetWorkerAsync(workerId3);

// Since both workers, Worker_1 and Worker_2, get the same score of 200,
// the worker who has been idle the longest will get the first offer.
if (queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobId))
{
    Console.WriteLine($"Worker 1 has received the offer");
}
else if (queriedWorker2.Value.Offers.Any(offer => offer.JobId == jobId))
{
    Console.WriteLine($"Worker 2 has received the offer");
}

Console.WriteLine($"Worker 3 has not received any offer: {queriedWorker3.Value.Offers.All(offer => offer.JobId != jobId)}");
```
