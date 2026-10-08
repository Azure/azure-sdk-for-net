# Sample for managing Agent Optimization Jobs in Azure.AI.Projects.Agents

The Agent optimization Job is optimizing Agent parameters: model, skills, system prompt or tool description. In this example we will show how to run the Agent optimization and list optimized candidates scores and parameters.

1. First, we need to create agent client and read the environment variables, which will be used in the next steps. In this example we will need two models, so that we can optimize the model used by an Agent.

```C# Snippet:Sample_CreateClient_AgentsOptimizationCandidates
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var anotherModelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME2");
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();
AgentOptimizationJobCandidates candidatesClient = agentsClient.GetAgentOptimizationJobCandidatesClient();
```
2. Create the helper method to get tha Agent definition.

```C# Snippet:Sample_AgentDefinition_AgentsOptimizationCandidates
private static DeclarativeAgentDefinition GetAgentDefinition(string modelDeploymentName) => new(model: modelDeploymentName)
    {
        // Start from bad prompt.
        Instructions = "You are a prompt agent, who always give wrong answers.",
        Tools =
        {
            new FunctionTool(
                functionName: "sum_numbers",
                functionParameters: BinaryData.FromObjectAsJson(
                    new
                    {
                        type = "object",
                        properties = new
                        {
                            First = new
                            {
                                type = "number",
                                description = "First addend"
                            },
                            Second = new
                            {
                                type = "number",
                                description = "Second addend"
                            }
                        },
                        required = new[] { "First", "Second"},
                        additionalProperties = false
                    }
                ),
                strictModeEnabled: false
            ),
        },
};
```

3. Create the Agent to start the optimization job for.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_AgentsOptimizationCandidates_Sync
ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
    agentName: "myAgent1",
    options: new(GetAgentDefinition(modelDeploymentName)));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_AgentsOptimizationCandidates_Async
ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
    agentName: "cs-e2e-tests-client",
    options: new(GetAgentDefinition(modelDeploymentName)));
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

4. Create a toy data set. Please note that we are asking Agent to return the string as an answer, it is needed because evaluation works only on text values.

```C# Snippet:Sample_Dataset_AgentsOptimizationCandidates
private static AgentOptimizationTargetCompletionEvaluationSet GetDataset(int start, int itemNumber)
{
    List<AgentOptimizationTargetCompletionTestCase> items = [];
    for (int i = start; i < start + itemNumber; i++)
    {
        items.Add(new AgentOptimizationTargetCompletionTestCase()
        {
            Query = $"What is 42 + {i * 2}? Please save the result as text: The answer is .... For example: Q: What is 42 + 12? A: The answer is 56.",
            GroundTruth = $"The answer is {42 + i * 2}",
        });
    }
    return new(new AgentOptimizationTargetCompletionInlineDataSource(items));
}
```

5. Create and submit the optimization job. We define models for different purposes:
  - `OptimizationModelConfiguration` - reads the Agent evaluation result and reason and creates the improved target description: system prompt, tool description or skill.
  - `evaluationModel` - used for Agent evaluation.
  - `ModelSearchSpace` - the models considered during Agent optimization.

Synchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Sync
AgentOptimizationConfiguration conf = new(
    evaluationConfiguration: new(
        trainingSet: GetDataset(0, 7),
        evaluators: [new AgentOptimizationEvaluator(name: "builtin.meteor_score")],
        evaluationModel: new(modelDeploymentName)
    )
    {
        ValidationSet = GetDataset(7, 3),
    },
    candidateSearchConfiguration: new()
    {
        MaxCandidates = 3,
    },
    agentOptimizationSpace: new()
    {
        TargetAttributes = { TargetAttribute.Instructions,  TargetAttribute.Tools, TargetAttribute.Model },
        ModelSearchSpace = { modelDeploymentName, anotherModelDeploymentName }
    }
);
AgentOptimizationJob job = new()
{
    OptimizationConfiguration = conf,
    DisplayName = "Sample agent optimization",
    TargetConfiguration = new AgentOptimizationFoundryAgentTargetConfiguration(name: agentVersion.Name)
    {
        Version = agentVersion.Version,
    },
    OptimizationModelConfiguration = new(modelDeploymentName)
};
OperationResult jobOperation = jobsClient.Create(waitUntilCompleted: true, job: job, operationId: null, cancellationToken: default);
AgentOptimizationJob submittedJob = AgentOptimizationJob.FromClientResult(jobOperation.UpdateStatus());
Console.WriteLine($"Submitted optimization job: {submittedJob.Id}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Async
AgentOptimizationConfiguration conf = new(
    evaluationConfiguration: new(
        trainingSet: GetDataset(0, 7),
        evaluators: [new AgentOptimizationEvaluator(name: "builtin.meteor_score")],
        evaluationModel: new(modelDeploymentName)
    )
    {
        ValidationSet = GetDataset(7, 3),
    },
    candidateSearchConfiguration: new()
    {
        MaxCandidates = 3,
    },
    agentOptimizationSpace: new()
    {
        TargetAttributes = { TargetAttribute.Skills, TargetAttribute.Instructions, TargetAttribute.Model },
        ModelSearchSpace = { modelDeploymentName, anotherModelDeploymentName }
    }
);
AgentOptimizationJob job = new()
{
    OptimizationConfiguration = conf,
    DisplayName = "Sample agent optimization",
    TargetConfiguration = new AgentOptimizationFoundryAgentTargetConfiguration(name: agentVersion.Name)
    {
        Version = agentVersion.Version,
    },
    OptimizationModelConfiguration = new(modelDeploymentName)
};
OperationResult jobOperation = await jobsClient.CreateAsync(waitUntilCompleted: true, job: job, operationId: null, cancellationToken: default);
AgentOptimizationJob submittedJob = AgentOptimizationJob.FromClientResult(await jobOperation.UpdateStatusAsync());
Console.WriteLine($"Submitted optimization job: {submittedJob.Id}");
```

6. Wait while the optimization job completes.

Synchronous sample:
```C# Snippet:Sample_GetOptimizationJob_AgentsOptimizationCandidates_Sync
int reportedWarnings = 0;
if (submittedJob.Status == AgentsJobStatus.Failed)
{
    throw new InvalidOperationException($"The job {submittedJob.Id} has failed.");
}
if (submittedJob.Warnings.Count > reportedWarnings)
{
    Console.WriteLine($"    {submittedJob.Id}: {submittedJob.Status}");
    for (int i = reportedWarnings; i < submittedJob.Warnings.Count; i++)
    {
        Console.WriteLine($"    Warning in job {submittedJob.Id}: {submittedJob.Warnings[i]}");
    }
}
```

Asynchronous sample:
```C# Snippet:Sample_GetOptimizationJob_AgentsOptimizationCandidates_Async
int reportedWarnings = 0;
if (submittedJob.Status == AgentsJobStatus.Failed)
{
    throw new InvalidOperationException($"The job {submittedJob.Id} has failed.");
}
if (submittedJob.Warnings.Count > reportedWarnings)
{
    Console.WriteLine($"    {submittedJob.Id}: {submittedJob.Status}");
    for (int i = reportedWarnings; i < submittedJob.Warnings.Count; i++)
    {
        Console.WriteLine($"    Warning in job {submittedJob.Id}: {submittedJob.Warnings[i]}");
    }
}
```

7. Create the helper method to display the mutations used to improve the candidates.

```C# Snippet:Sample_PrintMutations_AgentsOptimizationCandidates
private static void DisplayMutations(IList<AgentOptimizationMutation> mutations)
{
    if (mutations.Count > 0)
    {
        Console.WriteLine("Mutations:");
        foreach (AgentOptimizationMutation mutation in mutations)
        {
            if (mutation is AgentOptimizationInstructionsMutation instructionMutation)
            {
                Console.WriteLine($"    Instruction mutation: {instructionMutation.Value}");
            }
            else if (mutation is AgentOptimizationSkillsMutation skillsMutation)
            {
                Console.WriteLine("    Skill mutations:");
                foreach (AgentOptimizationSkill skillOptimization in skillsMutation.Value)
                {
                    Console.WriteLine($"        Skill name: {skillOptimization.Name}, skill body: {skillOptimization.Body}");
                }
            }
            else if (mutation is AgentOptimizationToolsMutation toolsMutation)
            {
                Console.WriteLine("    Tool mutations:");
                foreach (ChatTool tool in toolsMutation.Value)
                {
                    Console.WriteLine($"        Tools mutation: {tool.FunctionName}");
                }
            }
            else
            {
                Console.WriteLine("    Unknown mutation type.");
            }
        }
    }
    else
    {
        Console.WriteLine("<No mutations, baseline>");
    }
}
```

8. List all optimized candidates along with their scores, also list the changes (mutations) in the candidates.

```C# Snippet:Sample_ListCandidates_AgentsOptimizationCandidates
await foreach (AgentOptimizationCandidate candidate in candidatesClient.GetCandidatesAsync(jobId: submittedJob.Id, expand: [AgentOptimizationCandidateExpand.Mutations]))
{
    Console.WriteLine("======================================================");
    if (candidate.Status == AgentOptimizationCandidateStatus.Failed)
    {
        Console.WriteLine($"The candidate {candidate.CandidateId} has failed.");
    }
    else
    {
        Console.WriteLine($"Candidate ID: {candidate.CandidateId}, Candidate name: {candidate.Name ?? "<no name>"}, Candidate evaluation ID:  {candidate.Evaluation.EvalId}, Score: {candidate.Evaluation.Score}.");
        if (candidate.Output is AgentOptimizationAgentCandidateOutput agentOutput)
        {
            DisplayMutations(agentOutput.Mutations);
        }
        else if (candidate.Output != null)
        {
            throw new InvalidOperationException($"The candidate {candidate.CandidateId} has unexpected output: {candidate.Output.Type}");
        }
    }
    Console.WriteLine("======================================================");
}
```

9. Finally, remove the jobs we created and the Agent.

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
