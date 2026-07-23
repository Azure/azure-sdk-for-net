# Sample for managing Agent Optimization Jobs in Azure.AI.Projects.Agents

The Agent optimization Job is optimizing Agent parameters: model, skills, system prompt or tool description. In this example we will show how to create, get, list, cancel and delete the Agent optimization jobs.

To use Agents Optimization, we need to provide the `Foundry-Features` header in our REST requests. It can be done using `PipelinePolicy`.

```C# Snippet:Sample_Agents_ExperimentalHeader
internal class FeaturePolicy(string feature) : PipelinePolicy
{
    private const string _FEATURE_HEADER = "Foundry-Features";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
```

We also need to ignore the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

1. First, we need to create agent client and read the environment variables, which will be used in the next steps. In this example we will need two models, so that we can optimize the model used by an Agent. We will also set `AgentsOptimization=V2Preview` preview header.

```C# Snippet:Sample_CreateClient_AgentsOptimization
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var anotherModelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME2");
AgentAdministrationClientOptions options = new();
options.AddPolicy(new FeaturePolicy("AgentsOptimization=V2Preview"), PipelinePosition.PerCall);
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();
```

2. Create the Agent to start the optimization job for.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_AgentsOptimization_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
    agentName: "myAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_AgentsOptimization_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
    agentName: "myAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

3. Create an optimization criterion based on the groundedness.

```C# Snippet:Sample_OptimizationCriterion_AgentsOptimization
private readonly OptimizationDatasetCriterion _criterion = new(
    name: "Groundedness",
    instruction: """
    You are a Groundedness Evaluator.

    Your task is to evaluate how well the given response is grounded in the provided ground truth.  
    Groundedness means the response’s statements are factually supported by the ground truth.  
    Evaluate factual alignment only — ignore grammar, fluency, or completeness.

    ---

    ### Input:
    Query:
    {{query}}

    Response:
    {{response}}

    Ground Truth:
    {{ground_truth}}

    ---

    ### Scoring Scale (1–5):
    5 → Fully grounded. All claims supported by ground truth.  
    4 → Mostly grounded. Minor unsupported details.  
    3 → Partially grounded. About half the claims supported.  
    2 → Mostly ungrounded. Only a few details supported.  
    1 → Not grounded. Almost all information unsupported.

    ---

    ### Output Format (JSON):
    {
        "result": <integer from 1 to 5>,
        "reason": "<brief explanation for the score>"
    }
    """
);
```

4. Create a toy data set. Please note that we are asking Agent to return the string as an answer, it is needed because evaluation works only on text values.

```C# Snippet:Sample_Dataset_AgentsOptimization
private OptimizationInlineDatasetInput GetDataset(int start, int itemNumber)
{
    List<OptimizationDatasetItem> items = [];
    for (int i = start; i < start + itemNumber; i++)
    {
        items.Add(new OptimizationDatasetItem()
        {
            Query = $"What is 42 + {i * 2}? Please save the result as text: The answer is .... For example: Q: What is 42 + 12? A: The answer is 56.",
            GroundTruth = $"The answer is {(42 + i * 2)}",
            Criteria = { _criterion }
        });
    }
    return new(items);
}
```

5. Create and submit the optimization job. We define models for different purposes:
  - `OptimizationModel` - reads the Agent evaluation result and reason and creates the improved target description: system prompt, tool description or skill.
  - `EvalModel` - used for Agent evaluation.
  - `model_search_space` - the models considered during Agent optimization.
  - `model` - the model used by Hosted Agent, for Declarative Agent, the model from definition is being used. For more information about optimizing Hosted Agents please see the [document](https://learn.microsoft.com/azure/foundry/agents/how-to/make-agent-optimizer-ready).
**Note:** For optimization of declarative Agent, the `OptimizationConfig` is optional; `system_prompt`, `tools` and `model` parameters are automatically detected. `skills` optimization is only available for Hosted Agents. Here we provide `OptimizationConfig` for demonstration purposes only.

Synchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimization_Sync
OptimizationJob job = new()
{
    Inputs = new(
        agent: new OptimizationAgentIdentifier(agentName: agentVersion.Name)
        {
            AgentVersion = agentVersion.Version
        },
        trainDataset: GetDataset(0, 7),
        evaluators: [new OptimizationEvaluatorRef(name: "builtin.meteor_score")]
    )
    {
        ValidationDataset = GetDataset(7, 3),
        Options = new OptimizationOptions()
        {
            OptimizationModel = modelDeploymentName,
            EvalModel = modelDeploymentName,
            MaxCandidates = 3,
            OptimizationConfig =
            {
                {"model_search_space",  BinaryData.FromObjectAsJson(new[] {modelDeploymentName, anotherModelDeploymentName})},
                {"model", BinaryData.FromString(JsonSerializer.Serialize(modelDeploymentName)) }
            }
        }
    }
};
OptimizationJob submittedJob1 = jobsClient.Create(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob1.Id}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimization_Async
OptimizationJob job = new()
{
    Inputs = new(
        agent: new OptimizationAgentIdentifier(agentName: agentVersion.Name)
        {
            AgentVersion = agentVersion.Version
        },
        trainDataset: GetDataset(0, 7),
        evaluators: [new OptimizationEvaluatorRef(name: "builtin.meteor_score")]
    )
    {
        ValidationDataset = GetDataset(7, 3),
        Options = new OptimizationOptions()
        {
            OptimizationModel = modelDeploymentName,
            EvalModel = modelDeploymentName,
            MaxCandidates = 3,
            OptimizationConfig =
            {
                {"model_search_space",  BinaryData.FromObjectAsJson(new[] {modelDeploymentName, anotherModelDeploymentName})},
                {"model", BinaryData.FromString(JsonSerializer.Serialize(modelDeploymentName)) }
            }
        }
    }
};
OptimizationJob submittedJob1 = await jobsClient.CreateAsync(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob1.Id}");
```

6. Wait while the optimization job completes.

Synchronous sample:
```C# Snippet:Sample_GetOptimizationJob_AgentsOptimization_Sync
int reportedWarnings = 0;
while (submittedJob1.Status != AgentsJobStatus.Failed && submittedJob1.Status != AgentsJobStatus.Succeeded)
{
    Thread.Sleep(500);
    submittedJob1 = jobsClient.Get(submittedJob1.Id, cancellationToken: default);
    if (submittedJob1.Warnings.Count > reportedWarnings)
    {
        Console.WriteLine($"    {submittedJob1.Id}: {submittedJob1.Status}");
        for (int i = reportedWarnings; i < submittedJob1.Warnings.Count; i++)
        {
            Console.WriteLine($"    Warning in job {submittedJob1.Id}: {submittedJob1.Warnings[i]}");
        }
    }
}
if (submittedJob1.Status == AgentsJobStatus.Failed)
{
    throw new InvalidOperationException($"The job {submittedJob1.Id} has failed.");
}
```

Asynchronous sample:
```C# Snippet:Sample_GetOptimizationJob_AgentsOptimization_Async
int reportedWarnings = 0;
while (submittedJob1.Status != AgentsJobStatus.Failed && submittedJob1.Status != AgentsJobStatus.Succeeded)
{
    await Task.Delay(500);
    submittedJob1 = await jobsClient.GetAsync(submittedJob1.Id, cancellationToken: default);
    if (submittedJob1.Warnings.Count > reportedWarnings)
    {
        Console.WriteLine($"    {submittedJob1.Id}: {submittedJob1.Status}");
        for (int i = reportedWarnings; i < submittedJob1.Warnings.Count; i++)
        {
            Console.WriteLine($"    Warning in job {submittedJob1.Id}: {submittedJob1.Warnings[i]}");
        }
    }
}
if (submittedJob1.Status == AgentsJobStatus.Failed)
{
    throw new InvalidOperationException($"The job {submittedJob1.Id} has failed.");
}
```

7. Create another optimization job and cancel it.

Synchronous sample:
```C# Snippet:Sample_CancelOptimizationJob_AgentsOptimization_Sync
OptimizationJob submittedJob2 = jobsClient.Create(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob2.Id}");
OptimizationJob cancelledJob = jobsClient.Cancel(jobId: submittedJob2.Id, cancellationToken: default);
while (cancelledJob.Status != AgentsJobStatus.Failed && cancelledJob.Status != AgentsJobStatus.Succeeded && cancelledJob.Status != AgentsJobStatus.Cancelled)
{
    cancelledJob = jobsClient.Get(cancelledJob.Id, cancellationToken: default);
}
if (cancelledJob.Status != AgentsJobStatus.Cancelled)
{
    throw new InvalidOperationException($"The job {cancelledJob.Id} has unexpected status: {cancelledJob.Status}.");
}
Console.WriteLine($"The job {cancelledJob.Id} was cancelled.");
```

Asynchronous sample:
```C# Snippet:Sample_CancelOptimizationJob_AgentsOptimization_Async
OptimizationJob submittedJob2 = await jobsClient.CreateAsync(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob2.Id}");
OptimizationJob cancelledJob = await jobsClient.CancelAsync(jobId: submittedJob2.Id, cancellationToken: default);
while (cancelledJob.Status != AgentsJobStatus.Failed && cancelledJob.Status != AgentsJobStatus.Succeeded && cancelledJob.Status != AgentsJobStatus.Cancelled)
{
    cancelledJob = await jobsClient.GetAsync(cancelledJob.Id, cancellationToken: default);
}
if (cancelledJob.Status != AgentsJobStatus.Cancelled)
{
    throw new InvalidOperationException($"The job {cancelledJob.Id} has unexpected status: {cancelledJob.Status}.");
}
Console.WriteLine($"The job {cancelledJob.Id} was cancelled.");
```

8. List All optimization jobs.

Synchronous sample:
```C# Snippet:Sample_ListOptimizationJobs_AgentsOptimization_Sync
Console.WriteLine("Listing optimization jobs:");
foreach (OptimizationJobListItem oneJob in jobsClient.GetAll())
{
    Console.WriteLine($"    Job: {oneJob.Id}, Status: {oneJob.Status}.");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListOptimizationJobs_AgentsOptimization_Async
Console.WriteLine("Listing optimization jobs:");
await foreach (OptimizationJobListItem oneJob in jobsClient.GetAllAsync())
{
    Console.WriteLine($"    Job: {oneJob.Id}, Status: {oneJob.Status}.");
}
```

9. Finally, remove the jobs we created and the Agent.

Synchronous sample:
```C# Snippet:Sample_Delete_AgentsOptimization_Sync
jobsClient.Delete(jobId: submittedJob1.Id, cancellationToken: default);
Console.WriteLine($"Deleted job {submittedJob1.Id}.");
jobsClient.Delete(jobId: submittedJob2.Id, cancellationToken: default);
Console.WriteLine($"Deleted job {submittedJob2.Id}.");
agentsClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_Delete_AgentsOptimization_Async
await jobsClient.DeleteAsync(jobId: submittedJob1.Id, cancellationToken: default);
Console.WriteLine($"Deleted job {submittedJob1.Id}.");
await jobsClient.DeleteAsync(jobId: submittedJob2.Id, cancellationToken: default);
Console.WriteLine($"Deleted job {submittedJob2.Id}.");
await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
```
