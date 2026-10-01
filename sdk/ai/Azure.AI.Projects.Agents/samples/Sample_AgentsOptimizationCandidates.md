# Sample for managing Agent Optimization Jobs in Azure.AI.Projects.Agents

An agent optimization job can propose changes to the model, instructions, skills and function tool descriptions. This example starts with a prompt agent that gives deliberately poor answers, runs an optimization job, and reads its candidate summary.

To use Agents Optimization, the `AAIP001` warning needs to be ignored.

```C#
#pragma warning disable AAIP001
```

1. Create an agent client and read the environment variables. This example uses two model deployments so the optimizer can compare target models.

```C# Snippet:Sample_CreateClient_AgentsOptimizationCandidates
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var anotherModelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME2");
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();
```

2. Create the Agent to start the optimization job for.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_AgentsOptimizationCandidates_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    // Start from bad prompt.
    Instructions = "You are a prompt agent, who always give wrong answers."
};
ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_AgentsOptimizationCandidates_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    // Start from bad prompt.
    Instructions = "You are a prompt agent, who always give wrong answers."
};
ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
    agentName: "cs-e2e-tests-client",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

3. Choose an evaluator to score the agent responses. Evaluators are configured on the job rather than on individual test cases.

```C# Snippet:Sample_OptimizationEvaluator_AgentsOptimizationCandidates
private static AgentOptimizationEvaluator GetEvaluator() =>
    new(name: "builtin.meteor_score");
```

4. Create inline training and validation evaluation sets with expected answers.

```C# Snippet:Sample_Dataset_AgentsOptimizationCandidates
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

5. Create and submit the optimization job. `OptimizationModelConfiguration` chooses the model that proposes changes, while `EvaluationModel` supplies a model for evaluation. The evaluation configuration holds the training and validation sets and evaluator. `AgentOptimizationSpace` selects all four attributes and the alternative models. The target configuration pins the registered agent version. The typed baseline supplies the prompt, model, skill and function tool used as starting values for the search.

```C# Snippet:Sample_OptimizationBaseline_AgentsOptimizationCandidates
private static AgentOptimizationBaselineAgentConfiguration GetBaselineConfiguration(string modelDeploymentName) =>
    new()
    {
        SystemPrompt = "You are a prompt agent, who always give wrong answers.",
        CurrentModel = modelDeploymentName,
        Skills =
        {
            new AgentOptimizationSkill("add two numbers", "Adds two numbers")
            {
                Body = "When asked calculate the sum of two numbers. Use echo $((<first> + <second>)) in bash and (<first> + <second>) in PowerShell."
            }
        },
        Tools =
        {
            new ChatCompletionTool(new FunctionObject("sum_numbers")
            {
                Description = "Sum two numbers",
                Parameters = new FunctionParameters
                {
                    AdditionalProperties =
                    {
                        ["type"] = BinaryData.FromObjectAsJson("object"),
                        ["properties"] = BinaryData.FromObjectAsJson(new
                        {
                            First = new { type = "number", description = "First addend" },
                            Second = new { type = "number", description = "Second addend" }
                        }),
                        ["required"] = BinaryData.FromObjectAsJson(new[] { "First", "Second" }),
                        ["additionalProperties"] = BinaryData.FromObjectAsJson(false)
                    }
                }
            })
        }
    };
```

Synchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Sync
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
            TargetAttributes = { TargetAttribute.Instructions, TargetAttribute.Model, TargetAttribute.Skills, TargetAttribute.Tools },
            ModelSearchSpace = { modelDeploymentName, anotherModelDeploymentName }
        })
    {
        BaselineAgentConfiguration = GetBaselineConfiguration(modelDeploymentName)
    })
{
    TargetConfiguration = new AgentOptimizationFoundryAgentTargetConfiguration(agentVersion.Name)
    {
        Version = agentVersion.Version
    }
};
AgentOptimizationJob submittedJob = jobsClient.Create(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob.Id}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Async
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
            TargetAttributes = { TargetAttribute.Instructions, TargetAttribute.Model, TargetAttribute.Skills, TargetAttribute.Tools },
            ModelSearchSpace = { modelDeploymentName, anotherModelDeploymentName }
        })
    {
        BaselineAgentConfiguration = GetBaselineConfiguration(modelDeploymentName)
    })
{
    TargetConfiguration = new AgentOptimizationFoundryAgentTargetConfiguration(agentVersion.Name)
    {
        Version = agentVersion.Version
    }
};
AgentOptimizationJob submittedJob = await jobsClient.CreateAsync(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob.Id}");
```

6. Wait while the optimization job completes.

Synchronous sample:
```C# Snippet:Sample_GetOptimizationJob_AgentsOptimizationCandidates_Sync
int reportedWarnings = 0;
while (submittedJob.Status != AgentsJobStatus.Failed && submittedJob.Status != AgentsJobStatus.Succeeded)
{
    Thread.Sleep(500);
    submittedJob = jobsClient.Get(submittedJob.Id, cancellationToken: default);
    if (submittedJob.Warnings.Count > reportedWarnings)
    {
        Console.WriteLine($"    {submittedJob.Id}: {submittedJob.Status}");
        for (int i = reportedWarnings; i < submittedJob.Warnings.Count; i++)
        {
            Console.WriteLine($"    Warning in job {submittedJob.Id}: {submittedJob.Warnings[i]}");
        }
    }
}
if (submittedJob.Status == AgentsJobStatus.Failed)
{
    throw new InvalidOperationException($"The job {submittedJob.Id} has failed.");
}
```

Asynchronous sample:
```C# Snippet:Sample_GetOptimizationJob_AgentsOptimizationCandidates_Async
int reportedWarnings = 0;
while (submittedJob.Status != AgentsJobStatus.Failed && submittedJob.Status != AgentsJobStatus.Succeeded)
{
    await Task.Delay(500);
    submittedJob = await jobsClient.GetAsync(submittedJob.Id, cancellationToken: default);
    if (submittedJob.Warnings.Count > reportedWarnings)
    {
        Console.WriteLine($"    {submittedJob.Id}: {submittedJob.Status}");
        for (int i = reportedWarnings; i < submittedJob.Warnings.Count; i++)
        {
            Console.WriteLine($"    Warning in job {submittedJob.Id}: {submittedJob.Warnings[i]}");
        }
    }
}
if (submittedJob.Status == AgentsJobStatus.Failed)
{
    throw new InvalidOperationException($"The job {submittedJob.Id} has failed.");
}
```

7. Read the job's candidate summary to see the baseline and selected candidate IDs, their scores when available, and how many candidates completed. Individual candidate mutations are not available through the public agent client in this release.

Synchronous sample:
```C# Snippet:Sample_OptimizationResult_AgentsOptimizationCandidates_Sync
AgentOptimizationResultCandidateSummary summary = submittedJob.Result?.CandidateSummary
    ?? throw new InvalidOperationException($"Job {submittedJob.Id} did not return a candidate summary.");
Console.WriteLine($"Baseline candidate: {summary.BaselineId} (score: {summary.BaselineScore})");
Console.WriteLine($"Best candidate: {summary.BestId} (score: {summary.BestScore})");
Console.WriteLine($"Completed candidates: {summary.CompletedCandidateCount}");
```

Asynchronous sample:
```C# Snippet:Sample_OptimizationResult_AgentsOptimizationCandidates_Async
AgentOptimizationResultCandidateSummary summary = submittedJob.Result?.CandidateSummary
    ?? throw new InvalidOperationException($"Job {submittedJob.Id} did not return a candidate summary.");
Console.WriteLine($"Baseline candidate: {summary.BaselineId} (score: {summary.BaselineScore})");
Console.WriteLine($"Best candidate: {summary.BestId} (score: {summary.BestScore})");
Console.WriteLine($"Completed candidates: {summary.CompletedCandidateCount}");
```

8. Finally, remove the job and the agent.

Synchronous sample:
```C# Snippet:Sample_Delete_AgentsOptimizationCandidates_Sync
jobsClient.Delete(jobId: submittedJob.Id, cancellationToken: default);
Console.WriteLine($"Deleted job {submittedJob.Id}.");
agentsClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_Delete_AgentsOptimizationCandidates_Async
await jobsClient.DeleteAsync(jobId: submittedJob.Id, cancellationToken: default);
Console.WriteLine($"Deleted job {submittedJob.Id}.");
await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
```
