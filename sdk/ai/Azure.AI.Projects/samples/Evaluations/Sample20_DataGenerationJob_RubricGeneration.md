# Generate evaluation test cases with rubric dimensions

This sample creates an evaluation data-generation job from recent agent traces and enables AI-generated rubric dimensions for each test case. Rubric generation is a preview feature that requires the `Foundry-Features: DataGenerationJobs=V1Preview` request header. The standard `AIProjectClient` supplies this feature opt-in for data-generation requests.

Set `FOUNDRY_PROJECT_ENDPOINT`, `FOUNDRY_MODEL_NAME`, `FOUNDRY_AGENT_ID`, and `TRACE_LOOKBACK_HOURS` before running the sample. The model deployment name must be nonempty when rubric generation is enabled.

Data-generation job creation uses the experimental `OperationResult` type, so suppress the corresponding warning:

```C#
#pragma warning disable SCME0006
```

## Create the client

Authenticate using `DefaultAzureCredential` and read the project, model deployment, agent, and trace-window settings.

```C# Snippet:Sample_CreateClient_DataGenerationJob_RubricGeneration
string endpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
string agentId = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_ID");
int lookbackHours = int.Parse(Environment.GetEnvironmentVariable("TRACE_LOOKBACK_HOURS"));
AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
```

## Build the traces request

Select recent traces for an existing agent. Set `GenerateTestCaseRubric` to `true` and provide the required model deployment through `DataGenerationModelOptions`.

```C# Snippet:Sample_CreateRequest_DataGenerationJob_RubricGeneration
DateTimeOffset endsOn = DateTimeOffset.UtcNow;
TracesDataGenerationJobSource tracesSource = new(endsOn.AddHours(-lookbackHours))
{
    AgentId = agentId,
    EndsOn = endsOn,
    Description = "Recent traces used to create evaluation test cases."
};

TracesDataGenerationJobConfiguration generationConfiguration = new()
{
    MaxSamples = 10,
    GenerateTestCaseRubric = true,
    ModelOptions = new DataGenerationModelOptions(modelDeploymentName)
};

EvaluationDataGenerationJobInputs job = new(
    name: "sampleTraceRubricGeneration",
    sources: [tracesSource],
    generationConfiguration: generationConfiguration)
{
    OutputConfiguration = new EvaluationDataGenerationJobOutputConfiguration
    {
        Name = "trace-rubric-evaluation-dataset",
        Description = "Evaluation test cases with generated rubric dimensions."
    }
};
```

## Create and monitor the job

Create the job asynchronously, poll until it reaches a terminal state, and print the generated dataset details.

```C# Snippet:Sample_CreateAndPoll_DataGenerationJob_RubricGeneration_Async
DataGenerationJob runningJob = await projectClient.DataGenerationJobs.CreateAsync(job);
Console.WriteLine($"Created job ID: {runningJob.Id}");

while (runningJob.Status != ProjectsJobStatus.Failed &&
       runningJob.Status != ProjectsJobStatus.Succeeded &&
       runningJob.Status != ProjectsJobStatus.Cancelled)
{
    await Task.Delay(TimeSpan.FromSeconds(2));
    runningJob = await projectClient.DataGenerationJobs.GetAsync(runningJob.Id);
}

if (runningJob.Status != ProjectsJobStatus.Succeeded)
{
    throw new InvalidOperationException(
        $"The job {runningJob.Id} completed with status {runningJob.Status}.");
}

if (runningJob.Result.Outputs[0] is DatasetDataGenerationJobOutput output)
{
    Console.WriteLine($"Created dataset {output.Name}, version {output.Version}.");
}
```
