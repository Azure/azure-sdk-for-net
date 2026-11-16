// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

#pragma warning disable SCME0006

public class Sample_DataGenerationJob_RubricGeneration : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task TracesDataGenerationJobRubricAsync()
    {
        #region Snippet:Sample_CreateClient_DataGenerationJob_RubricGeneration
#if SNIPPET
        string endpoint = Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string modelDeploymentName = Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        string agentId = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_ID");
        int lookbackHours = int.Parse(Environment.GetEnvironmentVariable("TRACE_LOOKBACK_HOURS"));
#else
        string endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        string agentId = TestEnvironment.FOUNDRY_AGENT_ID;
        int lookbackHours = int.Parse(TestEnvironment.TRACE_LOOKBACK_HOURS);
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateRequest_DataGenerationJob_RubricGeneration
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
        #endregion

        #region Snippet:Sample_CreateAndPoll_DataGenerationJob_RubricGeneration_Async
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
        #endregion
    }

    public Sample_DataGenerationJob_RubricGeneration(bool isAsync) : base(isAsync)
    {
    }
}
