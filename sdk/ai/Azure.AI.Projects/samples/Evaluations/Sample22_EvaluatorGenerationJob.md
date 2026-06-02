# Sample Evaluator Generation Job in Azure.AI.Projects.

In this example we will demonstrate how to manage evaluator generation jobs in `Azure.AI.Projects`. Evaluator generator jobs are used to generate custom evaluators tailored to specific topics. In this scenario, we will create an Agent, which can generate questions and answers based on provided prompt and use it for evaluator generation.

**Note:** Evaluator generation job is an experimental feature, to use it, please disable the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

1. First, we need to create `AIProjectClient` and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClients_EvaluatorGenerationJob
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
```

2. Create the Agent, which will be used for generation of evaluator inputs. We create `EvaluatorGenerationJob` using the Agent, it will generate the new version of built in **coherence** evaluator using the supplied model.

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
EvaluatorGenerationJob job = new()
{
    Inputs = new EvaluatorGenerationInputs(
        sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
        model: modelDeploymentName,
        evaluatorName: "coherence"
    )
};
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
EvaluatorGenerationJob job = new()
{
    Inputs = new EvaluatorGenerationInputs(
        sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
        model: modelDeploymentName,
        evaluatorName: "coherence"
    )
};
```

3. Start the evaluator generation job.

Synchronous sample:
```C# Snippet:Sample_CreateJob_EvaluatorGenerationJob_Sync
EvaluatorGenerationJob runningJob = projectClient.EvaluatorGenerationJobs.Create(job);
Console.WriteLine($"Created job ID: {runningJob.Id}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateJob_EvaluatorGenerationJob_Async
EvaluatorGenerationJob runningJob = await projectClient.EvaluatorGenerationJobs.CreateAsync(job);
Console.WriteLine($"Created job ID: {runningJob.Id}");
```

4. Wait for the job to arrive at a final state. After the generation job is complete, the `EvaluatorVersion` object will be returned in `runningJob.Result` property.

Synchronous sample:
```C# Snippet:Sample_GetJob_EvaluatorGenerationJob_Sync
while (runningJob.Status != JobStatus.Failed && runningJob.Status != JobStatus.Succeeded)
{
    Thread.Sleep(500);
    Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
    runningJob = projectClient.EvaluatorGenerationJobs.Get(jobId: runningJob.Id);
}
if (runningJob.Status == JobStatus.Failed)
{
    throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
}
Console.WriteLine($"The job ID: {runningJob.Id} completed, created evaluator {runningJob.Result.Name}, v. {runningJob.Result.Version}");
```

Asynchronous sample:
```C# Snippet:Sample_GetJob_EvaluatorGenerationJob_Async
while (runningJob.Status != JobStatus.Failed && runningJob.Status != JobStatus.Succeeded)
{
    await Task.Delay(500);
    Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
    runningJob = await projectClient.EvaluatorGenerationJobs.GetAsync(jobId: runningJob.Id);
}
if (runningJob.Status == JobStatus.Failed)
{
    throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
}
Console.WriteLine($"The job ID: {runningJob.Id} completed, created evaluator {runningJob.Result.Name}, v. {runningJob.Result.Version}");
```

5. Demonstrate how to cancel the job

Synchronous sample:
```C# Snippet:Sample_CancelingJob_EvaluatorGenerationJob_Sync
job = new()
{
    Inputs = new EvaluatorGenerationInputs(
        sources: [new PromptEvaluatorGenerationJobSource("Please explain the Maxwell's equation")],
        model: modelDeploymentName,
        evaluatorName: "violence"
    )
};
EvaluatorGenerationJob jobToCancel = projectClient.EvaluatorGenerationJobs.Create(job);
jobToCancel = projectClient.EvaluatorGenerationJobs.Cancel(jobToCancel.Id);
while (jobToCancel.Status != JobStatus.Failed && jobToCancel.Status != JobStatus.Succeeded && jobToCancel.Status != JobStatus.Cancelled)
{
    Thread.Sleep(500);
    Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
    jobToCancel = projectClient.EvaluatorGenerationJobs.Get(jobId: jobToCancel.Id);
}
if (jobToCancel.Status != JobStatus.Cancelled)
{
    throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
}
Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
```

Asynchronous sample:
```C# Snippet:Sample_CancelingJob_EvaluatorGenerationJob_Async
job = new()
{
    Inputs = new EvaluatorGenerationInputs(
        sources: [new PromptEvaluatorGenerationJobSource("Please explain the Maxwell's equation")],
        model: modelDeploymentName,
        evaluatorName: "violence"
    )
};
EvaluatorGenerationJob jobToCancel = await projectClient.EvaluatorGenerationJobs.CreateAsync(job);
jobToCancel = await projectClient.EvaluatorGenerationJobs.CancelAsync(jobToCancel.Id);
while (jobToCancel.Status != JobStatus.Failed && jobToCancel.Status != JobStatus.Succeeded && jobToCancel.Status != JobStatus.Cancelled)
{
    await Task.Delay(500);
    Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
    jobToCancel = await projectClient.EvaluatorGenerationJobs.GetAsync(jobId: jobToCancel.Id);
}
if (jobToCancel.Status != JobStatus.Cancelled)
{
    throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
}
Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
```

6. List all created jobs.

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

7. Finally, delete the jobs we have created.

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
