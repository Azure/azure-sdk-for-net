# Sample for managing Agent Optimization Jobs in Azure.AI.Projects.Agents

The Agent optimization Job is optimizing Agent parameters: model, skills, system prompt or tool description. In this example we will show how to run the Agent optimization and list optimized candidates scores and parameters.

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

```C# Snippet:Sample_CreateClient_AgentsOptimizationCandidates
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

3. Create an optimization criterion based on the groundedness.

```C# Snippet:Sample_OptimizationCriterion_AgentsOptimizationCandidates
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

```C# Snippet:Sample_Dataset_AgentsOptimizationCandidates
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
In his example we will try to optimize all four: model, system prompt, tool description and a skill.
**Note:** For optimization of declarative Agent, the `OptimizationConfig` is optional; `system_prompt`, `tools` and `model` parameters are automatically detected. `skills` optimization is only available for Hosted Agents. Here we provide `OptimizationConfig` for demonstration purposes only.

Synchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Sync
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
                {"system_prompt", BinaryData.FromString(JsonSerializer.Serialize("You are a prompt agent, who always give wrong answers.")) },
                {"model_search_space",  BinaryData.FromObjectAsJson(new[] {modelDeploymentName, anotherModelDeploymentName})},
                {"model", BinaryData.FromString(JsonSerializer.Serialize(modelDeploymentName)) },
                {"skills", BinaryData.FromObjectAsJson(new[]
                    {new {
                        name = "add two numbers",
                        description = "Adds two numbers",
                        body = "When asked calculate the sum of two numbers. Use echo $((<first> + <second>)) in bash and (<first> + <second>) in PowerShell."
                    }}
                )},
                {"tools",  BinaryData.FromObjectAsJson(new[]{
                    new
                    {
                        type = "function",
                        function = new
                        {
                            name = "sum_numbers",
                            description = "Sum two numbers",
                            parameters = new
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
                        }
                    }
                })}
            }
        }
    }
};
OptimizationJob submittedJob = jobsClient.Create(job: job, operationId: null, cancellationToken: default);
Console.WriteLine($"Submitted optimization job: {submittedJob.Id}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Async
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
                // Start from bad prompt.
                {"system_prompt", BinaryData.FromString(JsonSerializer.Serialize("You are a prompt agent, who always give wrong answers.")) },
                {"model_search_space",  BinaryData.FromObjectAsJson(new[] {modelDeploymentName, anotherModelDeploymentName})},
                {"model", BinaryData.FromString(JsonSerializer.Serialize(modelDeploymentName)) },
                {"skills", BinaryData.FromObjectAsJson(new[]
                    {new {
                        name = "add two numbers",
                        description = "Adds two numbers",
                        body = "When asked calculate the sum of two numbers. Use echo $((<first> + <second>)) in bash and (<first> + <second>) in PowerShell."
                    }}
                )},
                {"tools",  BinaryData.FromObjectAsJson(new[]{
                    new
                    {
                        type = "function",
                        function = new
                        {
                            name = "sum_numbers",
                            description = "Sum two numbers",
                            parameters = new
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
                        }
                    }
                })}
            }
        }
    }
};
OptimizationJob submittedJob = await jobsClient.CreateAsync(job: job, operationId: null, cancellationToken: default);
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

7. List all optimized candidates along with their scores, also list the changes (mutations) in the candidates.

```C# Snippet:Sample_ListCandidates_AgentsOptimizationCandidates
foreach (OptimizationCandidate candidate in submittedJob.Result.Candidates)
{
    Console.WriteLine("======================================================");
    Console.WriteLine($"CandidateID: {candidate.CandidateId}, Candidate evaluation ID:  {candidate.EvalId}, Score: {candidate.AvgScore}.");
    if (candidate.Mutations.Count == 0)
    {
        Console.WriteLine("<No mutations, baseline>");
    }
    else
    {
        Console.WriteLine("Mutations:");
        foreach (KeyValuePair<string, BinaryData> mutation in candidate.Mutations)
        {
            Console.WriteLine($"    {mutation.Key}: {mutation.Value}");
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
