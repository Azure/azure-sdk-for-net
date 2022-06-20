# Azure.Communication.JobRouter Samples - Using distribution policy (simple scenarios)

## Import the namespaces

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_UsingStatements
using Azure.Communication.JobRouter;
```

## Create a client

Create a `RouterClient` and send a request.

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_CreateClient
var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
```

## Using expression rule with best worker distribution mode

```C# Snippet:Azure_Communication_JobRouter_Tests_Samples_Distribution_Advanced_Scoring_ExpressionRule
// In this scenario, we are going to create a simple PowerFx expression rule to check whether a worker can handler escalation or not
// If the worker can handler escalation then they are given a score of 100, otherwise a score of 1
// Create distribution policy
var distributionPolicyId = "best-worker-dp-2";
var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
    id: distributionPolicyId,
    offerTtlSeconds: 5 * 60,
    mode: new BestWorkerMode(scoringRule: new ExpressionRule("If(worker.HandleEscalation = true, 100, 1)")));

// Create job queue
var jobQueueId = "job-queue-id-2";
var jobQueue = await routerClient.CreateQueueAsync(
    id: jobQueueId,
    distributionPolicyId: distributionPolicyId);

var channelId = "general";

// Create two workers
var worker1Id = "worker-Id-1";
var worker2Id = "worker-Id-2";

// Worker 1 can handle escalation
var worker1Labels = new LabelCollection() { ["HandleEscalation"] = true, ["IT_Support"] = true };

var worker1 = await routerClient.CreateWorkerAsync(
    id: worker1Id,
    totalCapacity: 10,
    options: new CreateWorkerOptions()
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
var worker2Labels = new LabelCollection() { ["IT_Support"] = true, };

var worker2 = await routerClient.CreateWorkerAsync(
    id: worker2Id,
    totalCapacity: 10,
    options: new CreateWorkerOptions()
    {
        AvailableForOffers = true,
        ChannelConfigurations =
            new Dictionary<string, ChannelConfiguration>() { [channelId] = new ChannelConfiguration(10), },
        Labels = worker2Labels,
        QueueIds = new Dictionary<string, QueueAssignment>() { [jobQueueId] = new QueueAssignment(), },
    });

// Create job
var jobId = "job-id-2";
var job = await routerClient.CreateJobAsync(
    id: jobId,
    channelId: channelId,
    queueId: jobQueueId,
    options: new CreateJobOptions()
    {
        RequestedWorkerSelectors = new List<WorkerSelector>(){ new WorkerSelector("IT_Support", LabelOperator.Equal, true)},
        Priority = 100,
    });


var queriedWorker1 = await routerClient.GetWorkerAsync(worker1Id);
var queriedWorker2 = await routerClient.GetWorkerAsync(worker2Id);

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
var distributionPolicyId = "best-worker-dp-1";
var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
    id: distributionPolicyId,
    offerTtlSeconds: 5 * 60,
    mode: new BestWorkerMode(scoringRule: new AzureFunctionRule("<insert function url>")));

// Create job queue
var queueId = "job-queue-id-1";
var jobQueue = await routerClient.CreateQueueAsync(
    id: queueId,
    distributionPolicyId: distributionPolicyId);

var channelId = "general";

// Create workers

var workerId1 = "worker-Id-1";
var worker1Labels = new LabelCollection()
{
    ["HighPrioritySupport"] = true,
    ["HardwareSupport"] = true,
    ["Support_XBOX_SERIES_X"] = true,
    ["English"] = 10,
    ["ChatSupport"] = true,
    ["XboxSupport"] = true
};

var worker1 = await routerClient.CreateWorkerAsync(
    id: workerId1,
    totalCapacity: 100,
    options: new CreateWorkerOptions()
    {
        QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
        Labels = worker1Labels,
        ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
        {
            [channelId] = new ChannelConfiguration(10),
        },
        AvailableForOffers = true,
    });

var workerId2 = "worker-Id-2";
var worker2Labels = new LabelCollection()
{
    ["HighPrioritySupport"] = true,
    ["HardwareSupport"] = true,
    ["Support_XBOX_SERIES_X"] = true,
    ["Support_XBOX_SERIES_S"] = true,
    ["English"] = 8,
    ["ChatSupport"] = true,
    ["XboxSupport"] = true
};

var worker2 = await routerClient.CreateWorkerAsync(
    id: workerId2,
    totalCapacity: 100,
    options: new CreateWorkerOptions()
    {
        QueueIds = new Dictionary<string, QueueAssignment>() { [queueId] = new QueueAssignment(), },
        Labels = worker2Labels,
        ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
        {
            [channelId] = new ChannelConfiguration(10),
        },
        AvailableForOffers = true,
    });

var workerId3 = "worker-Id-3";
var worker3Labels = new LabelCollection()
{
    ["HighPrioritySupport"] = false,
    ["HardwareSupport"] = true,
    ["Support_XBOX"] = true,
    ["English"] = 7,
    ["ChatSupport"] = true,
    ["XboxSupport"] = true
};

var worker3 = await routerClient.CreateWorkerAsync(
    id: workerId3,
    totalCapacity: 100,
    options: new CreateWorkerOptions()
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
var jobLabels = new LabelCollection()
{
    ["CommunicationType"] = "Chat",
    ["IssueType"] = "XboxSupport",
    ["Language"] = "en",
    ["HighPriority"] = true,
    ["SubIssueType"] = "ConsoleMalfunction",
    ["ConsoleType"] = "XBOX_SERIES_X",
    ["Model"] = "XBOX_SERIES_X_1TB"
};

var jobId = "job-id-1";
var workerSelectors = new List<WorkerSelector>()
{
    new WorkerSelector("English", LabelOperator.GreaterThanEqual, 7),
    new WorkerSelector("ChatSupport", LabelOperator.Equal, true),
    new WorkerSelector("XboxSupport", LabelOperator.Equal, true)
};

var job = await routerClient.CreateJobAsync(
    id: jobId,
    channelId: channelId,
    queueId: queueId,
    options: new CreateJobOptions()
    {
        Labels = jobLabels, RequestedWorkerSelectors = workerSelectors, Priority = 100,
    });


var queriedWorker1 = await routerClient.GetWorkerAsync(workerId1);
var queriedWorker2 = await routerClient.GetWorkerAsync(workerId2);
var queriedWorker3 = await routerClient.GetWorkerAsync(workerId3);

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
