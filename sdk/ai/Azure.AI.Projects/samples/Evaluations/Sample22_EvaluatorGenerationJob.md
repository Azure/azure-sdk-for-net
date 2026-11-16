# Sample Evaluator Generation Job in Azure.AI.Projects.

In this example we will demonstrate how to manage evaluator generation jobs in `Azure.AI.Projects`. Evaluator generator jobs are used to generate custom evaluators tailored to specific topics. In this scenario, we will create an Agent, which can generate questions and answers based on provided prompt and use it for evaluator generation.

**Note:** Evaluator generation job sample is using an experimental class `OperationResult`, to use it, please disable the `SCME0006` warning. The rubric scoring and generation category properties (`Category`, `Scoring`, `RubricScoringMode`) are in preview, to use them, please disable the `AAIP001` warning.

```C#
#pragma warning disable SCME0006, AAIP001
```

1. First, we need to create `AIProjectClient` and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClients_EvaluatorGenerationJob
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
```

2. Create the Agent, which will be used for generation of evaluator inputs. We create `EvaluatorGenerationInputs` using the Agent, it will generate the new version of the **coherence** evaluator with Likert scoring using the supplied model. Quality generation requires the `Model` property. Setting `Scoring` opts in to rubric scoring: `RubricScoringMode.Likert` grades each dimension from 1 to 5 and combines them using optional weights (1-10, set on all dimensions or none), and the job passes when the normalized score reaches `PassThreshold` (default 0.5). `RubricScoringMode.Boolean` requires every applicable check to pass and does not support weights. Omitting `Scoring` keeps the legacy behavior. When `Dimensions` is left empty, regenerating an existing evaluator preserves its previously approved dimensions, while an explicit list replaces them.

**Note:** In this example the same model is used for both data generation and evaluation for demonstration purposes only. Please use different models in production scenarios.

Synchronous sample:
```C# Snippet:Sample_CreateAnAgent_EvaluatorGenerationJob_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that answers general questions",
};
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "evalAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
// Quality generation requires a model deployment. Setting Scoring opts in to Likert or
// Boolean rubric scoring. Omitting Scoring keeps the legacy behavior.
EvaluatorGenerationInputs job = new(
    sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
    evaluatorName: "coherence")
{
    Model = modelDeploymentName,
    Category = EvaluatorGenerationCategory.Quality,
    Scoring = new RubricScoring { Mode = RubricScoringMode.Likert },
    PassThreshold = 0.6f,
};
// Optional: pin dimensions. When Dimensions is empty, regenerating an existing evaluator
// preserves its previously approved dimensions. An explicit list replaces them.
job.Dimensions.Add(new EvaluationsDimension(
    id: "answers_question",
    description: "The response directly answers the user's question.")
{ Weight = 3 });
```

Asynchronous sample:
```C# Snippet:Sample_CreateAnAgent_EvaluatorGenerationJob_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a helpful assistant that answers general questions",
};
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "evalAgent",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
// Quality generation requires a model deployment. Setting Scoring opts in to Likert or
// Boolean rubric scoring. Omitting Scoring keeps the legacy behavior.
EvaluatorGenerationInputs job = new(
    sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
    evaluatorName: "coherence")
{
    Model = modelDeploymentName,
    Category = EvaluatorGenerationCategory.Quality,
    Scoring = new RubricScoring { Mode = RubricScoringMode.Likert },
    PassThreshold = 0.6f,
};
// Optional: pin dimensions. When Dimensions is empty, regenerating an existing evaluator
// preserves its previously approved dimensions. An explicit list replaces them.
job.Dimensions.Add(new EvaluationsDimension(
    id: "answers_question",
    description: "The response directly answers the user's question.")
{ Weight = 3 });
```

3. Start the evaluator generation job and wait for job completion.

Synchronous sample:
```C# Snippet:Sample_CreateJob_EvaluatorGenerationJob_Sync
OperationResult result = projectClient.EvaluatorGenerationJobs.Create(waitUntilCompleted: true, job: job);
EvaluatorGenerationJob runningJob = EvaluatorGenerationJob.FromClientResult(result.UpdateStatus());
Console.WriteLine($"Created job ID: {runningJob.Id}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateJob_EvaluatorGenerationJob_Async
OperationResult result = await projectClient.EvaluatorGenerationJobs.CreateAsync(waitUntilCompleted: true, job: job);
EvaluatorGenerationJob runningJob = EvaluatorGenerationJob.FromClientResult(await result.UpdateStatusAsync());
Console.WriteLine($"Created job ID: {runningJob.Id}");
```

4. Wait for the job to arrive at a final state. After the generation job is complete, the `EvaluatorVersion` object will be returned in `runningJob.Result` property.

Synchronous sample:
```C# Snippet:Sample_GetJob_EvaluatorGenerationJob_Sync
if (runningJob.Status == ProjectsJobStatus.Failed)
{
    throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
}
Console.WriteLine($"The job ID: {runningJob.Id} completed, created evaluator {runningJob.Result.Name}, v. {runningJob.Result.Version}");
```

Asynchronous sample:
```C# Snippet:Sample_GetJob_EvaluatorGenerationJob_Async
if (runningJob.Status == ProjectsJobStatus.Failed)
{
    throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
}
Console.WriteLine($"The job ID: {runningJob.Id} completed, created evaluator {runningJob.Result.Name}, v. {runningJob.Result.Version}");
```

5. Define the inputs for a safety evaluator. Safety generation requires a prompt source describing the policy plus an agent or traces source. The service always uses Boolean scoring and centrally managed model capacity, so `Model` is not required. Generated dimensions set `Allowed` (allowed or disallowed behavior) instead of `Weight`, and results are reported as two lower-is-better metrics: `disallowed_behavior_violated` and `allowed_behavior_violated`.

```C# Snippet:Sample_SafetyInputs_EvaluatorGenerationJob
private static EvaluatorGenerationInputs GetSafetyGenerationInputs(string agentName)
{
    // Safety generation needs a prompt source describing the policy plus an agent or traces
    // source. It always uses Boolean scoring and centrally managed model capacity, so Model
    // is not required. Generated dimensions set Allowed instead of Weight.
    return new EvaluatorGenerationInputs(
        sources: [
            new PromptEvaluatorGenerationJobSource("The agent must never reveal another customer's account details."),
            new AgentEvaluatorGenerationJobSource(agentName: agentName),
        ],
        evaluatorName: "account_data_safety")
    {
        Category = EvaluatorGenerationCategory.Safety,
    };
}
```

6. Demonstrate how to cancel the job, using the safety evaluator inputs.

Synchronous sample:
```C# Snippet:Sample_CancelingJob_EvaluatorGenerationJob_Sync
job = GetSafetyGenerationInputs(agentName: agentVersion.Name);
result = projectClient.EvaluatorGenerationJobs.Create(waitUntilCompleted: false, job: job);
EvaluatorGenerationJob jobToCancel = EvaluatorGenerationJob.FromClientResult(result.UpdateStatus());
jobToCancel = projectClient.EvaluatorGenerationJobs.Cancel(jobToCancel.Id);
while (jobToCancel.Status != ProjectsJobStatus.Failed && jobToCancel.Status != ProjectsJobStatus.Succeeded && jobToCancel.Status != ProjectsJobStatus.Cancelled)
{
    Thread.Sleep(500);
    Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
    jobToCancel = projectClient.EvaluatorGenerationJobs.Get(jobId: jobToCancel.Id);
}
if (jobToCancel.Status != ProjectsJobStatus.Cancelled)
{
    throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
}
Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
```

Asynchronous sample:
```C# Snippet:Sample_CancelingJob_EvaluatorGenerationJob_Async
job = GetSafetyGenerationInputs(agentName: agentVersion.Name);
result = await projectClient.EvaluatorGenerationJobs.CreateAsync(waitUntilCompleted: false, job: job);
EvaluatorGenerationJob jobToCancel = EvaluatorGenerationJob.FromClientResult(await result.UpdateStatusAsync());
jobToCancel = await projectClient.EvaluatorGenerationJobs.CancelAsync(jobToCancel.Id);
while (jobToCancel.Status != ProjectsJobStatus.Failed && jobToCancel.Status != ProjectsJobStatus.Succeeded && jobToCancel.Status != ProjectsJobStatus.Cancelled)
{
    await Task.Delay(500);
    Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
    jobToCancel = await projectClient.EvaluatorGenerationJobs.GetAsync(jobId: jobToCancel.Id);
}
if (jobToCancel.Status != ProjectsJobStatus.Cancelled)
{
    throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
}
Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
```

7. List all created jobs.

Synchronous sample:
```C# Snippet:Sample_ListJob_EvaluatorGenerationJob_Sync
// Wait while all jobs are being indexed.
Thread.Sleep(20000);
foreach (EvaluatorGenerationJob oneJob in projectClient.EvaluatorGenerationJobs.GetAll())
{
    Console.WriteLine($"Job ID: {oneJob.Id}, Status: {oneJob.Status}.");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListJob_EvaluatorGenerationJob_Async
// Wait while all jobs are being indexed.
await Task.Delay(20000);
await foreach (EvaluatorGenerationJob oneJob in projectClient.EvaluatorGenerationJobs.GetAllAsync())
{
    Console.WriteLine($"Job ID: {oneJob.Id}, Status: {oneJob.Status}.");
}
```

8. Finally, delete the jobs we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteJob_EvaluatorGenerationJob_Sync
projectClient.EvaluatorGenerationJobs.Delete(jobId: runningJob.Id);
projectClient.EvaluatorGenerationJobs.Delete(jobId: jobToCancel.Id);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteJob_EvaluatorGenerationJob_Async
await projectClient.EvaluatorGenerationJobs.DeleteAsync(jobId: runningJob.Id);
await projectClient.EvaluatorGenerationJobs.DeleteAsync(jobId: jobToCancel.Id);
```
