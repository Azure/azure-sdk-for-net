# Sample for managing Agent Optimization Jobs in Azure.AI.Projects.Agents

An agent optimization job can improve an agent's instructions and select from alternative models. This example shows how to create, get, list, cancel and delete optimization jobs.

To use Agents Optimization, we need to ignore the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

1. Create an agent client and read the environment variables. This example uses two model deployments so the optimizer can compare models for the target agent.

```C# Snippet:Sample_CreateClient_AgentsOptimization
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var anotherModelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME2");
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
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

3. Choose an evaluator to score the agent responses. Evaluators are configured on the job rather than on individual test cases.

```C# Snippet:Sample_OptimizationEvaluator_AgentsOptimization
private static AgentOptimizationEvaluator GetEvaluator() =>
    new(name: "builtin.meteor_score");
```

4. Create inline training and validation evaluation sets with expected answers.

```C# Snippet:Sample_Dataset_AgentsOptimization
private static AgentOptimizationTargetCompletionEvaluationSet GetDataset(int start, int itemNumber)
{
    List<AgentOptimizationTargetCompletionTestCase> items = [];
    for (int i = start; i < start + itemNumber; i++)
    {
        items.Add(new AgentOptimizationTargetCompletionTestCase(
            query: $"What is 42 + {i * 2}? Please save the result as text: The answer is .... For example: Q: What is 42 + 12? A: The answer is 56.")
        {
            GroundTruth = $"The answer is {(42 + i * 2)}"
        });
    }
    return new(new AgentOptimizationTargetCompletionInlineDataSource(items));
}
```

5. Create and submit the optimization job. `OptimizationModelConfiguration` chooses the model that proposes changes, while `EvaluationModel` supplies a model for evaluation. The evaluation configuration holds the training and validation sets and evaluator; `AgentOptimizationSpace` selects the agent attributes to optimize and which models to consider. The target configuration pins the registered agent version.

Synchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimization_Sync
AgentOptimizationJob job = new(
    optimizationModelConfiguration: new AgentOptimizationModelConfiguration(modelDeploymentName),
    optimizationConfiguration: new AgentOptimizationConfiguration(
        evaluationConfiguration: new AgentOptimizationEvaluationConfiguration(
            trainingSet: GetDataset(0, 7),
            evaluators: [GetEvaluator()],
            evaluationModel: new EvaluationModelConfiguration(modelDeploymentName))
        {
            ValidationSet = GetDataset(7, 3)
        },
        candidateSearchConfiguration: new AgentOptimizationCandidateSearchConfiguration
        {
            MaxCandidates = 3
        },
        agentOptimizationSpace: new AgentOptimizationSpace
        {
            TargetAttributes = { TargetAttribute.Instructions, TargetAttribute.Model },
            ModelSearchSpace = { modelDeploymentName, anotherModelDeploymentName }
        }))
{
    TargetConfiguration = new AgentOptimizationFoundryAgentTargetConfiguration(agentVersion.Name)
    {
        Version = agentVersion.Version
    }
};
AgentOptimizationJob submittedJob1 = jobsClient.Create(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob1.Id}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimization_Async
AgentOptimizationJob job = new(
    optimizationModelConfiguration: new AgentOptimizationModelConfiguration(modelDeploymentName),
    optimizationConfiguration: new AgentOptimizationConfiguration(
        evaluationConfiguration: new AgentOptimizationEvaluationConfiguration(
            trainingSet: GetDataset(0, 7),
            evaluators: [GetEvaluator()],
            evaluationModel: new EvaluationModelConfiguration(modelDeploymentName))
        {
            ValidationSet = GetDataset(7, 3)
        },
        candidateSearchConfiguration: new AgentOptimizationCandidateSearchConfiguration
        {
            MaxCandidates = 3
        },
        agentOptimizationSpace: new AgentOptimizationSpace
        {
            TargetAttributes = { TargetAttribute.Instructions, TargetAttribute.Model },
            ModelSearchSpace = { modelDeploymentName, anotherModelDeploymentName }
        }))
{
    TargetConfiguration = new AgentOptimizationFoundryAgentTargetConfiguration(agentVersion.Name)
    {
        Version = agentVersion.Version
    }
};
AgentOptimizationJob submittedJob1 = await jobsClient.CreateAsync(job: job, operationId: null, cancellationToken: default);
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
AgentOptimizationJob submittedJob2 = jobsClient.Create(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob2.Id}");
AgentOptimizationJob cancelledJob = jobsClient.Cancel(jobId: submittedJob2.Id, cancellationToken: default);
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
AgentOptimizationJob submittedJob2 = await jobsClient.CreateAsync(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob2.Id}");
AgentOptimizationJob cancelledJob = await jobsClient.CancelAsync(jobId: submittedJob2.Id, cancellationToken: default);
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
foreach (AgentOptimizationJob oneJob in jobsClient.GetAll())
{
    Console.WriteLine($"    Job: {oneJob.Id}, Status: {oneJob.Status}.");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListOptimizationJobs_AgentsOptimization_Async
Console.WriteLine("Listing optimization jobs:");
await foreach (AgentOptimizationJob oneJob in jobsClient.GetAllAsync())
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
