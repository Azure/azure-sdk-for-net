// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_AgentsOptimizationCRUD : SamplesBase
{
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
    private OptimizationInlineDatasetInput GetDataset(int start, int itemNumber)
    {
        OptimizationInlineDatasetInput returnValues = new();
        for (int i = start; i < start + itemNumber; i++)
        {
            returnValues.Items.Add(new()
            {
                Query = $"What is 42 + {i * 2}",
                GroundTruth = (42 + i * 2).ToString(),
                Criteria = { _criterion }
            });
        }
        return returnValues;
    }

    [Test]
    [AsyncOnly]
    public async Task AgentsOptimizationAsync()
    {
        #region Snippet:Sample_CreateClient_AgentsOptimization
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("AgentsOptimization=V2Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new AzureCliCredential(), options: options);
        AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();
        #endregion

        #region Snippet:Sample_CreateAgent_AgentsOptimization_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateOptimizationJob_AgentsOptimization_Async
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
            }
        };

        OptimizationJob submittedJob1 = await jobsClient.CreateAsync(job: job, operationId: null, cancellationToken: default);
        Console.WriteLine($"Submitted optimization job: {submittedJob1.Id}");
        #endregion
        #region Snippet:Sample_GetOptimizationJob_AgentsOptimization_Async
        int reportedWarnings = 0;
        while (submittedJob1.Status != AgentsJobStatus.Failed && submittedJob1.Status != AgentsJobStatus.Succeeded)
        {
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
            throw new InvalidOperationException($"The job {submittedJob1.Id} has failed. Code: {submittedJob1.Error.Code}, Message: {submittedJob1.Error.Message}");
        }
        #endregion
        #region Snippet:Sample_CancelOptimizationJob_AgentsOptimization_Async
        OptimizationJob submittedJob2 = await jobsClient.CreateAsync(job: job, operationId: null, cancellationToken: default);
        Console.WriteLine($"Submitted optimization job: {submittedJob2.Id}");
        OptimizationJob cancelledJob = await jobsClient.CancelAsync(jobId: job.Id, cancellationToken: default);
        while (cancelledJob.Status != AgentsJobStatus.Failed && cancelledJob.Status != AgentsJobStatus.Succeeded && cancelledJob.Status != AgentsJobStatus.Cancelled)
        {
            cancelledJob = await jobsClient.GetAsync(cancelledJob.Id, cancellationToken: default);
        }
        if (cancelledJob.Status != AgentsJobStatus.Cancelled)
        {
            throw new InvalidOperationException($"The job {cancelledJob.Id} has unexpected status: {cancelledJob.Status}.");
        }
        Console.WriteLine($"The job {cancelledJob.Id} was cancelled.");
        #endregion
        #region Snippet:Sample_ListOptimizationJobs_AgentsOptimization_Async
        Console.WriteLine("Listing optimization jobs:");
        await foreach (OptimizationJob oneJob in jobsClient.GetAllAsync())
        {
            Console.WriteLine($"    Job: {oneJob.Id}, Status: {oneJob.Status}.");
        }
        #endregion
        #region Snippet:Sample_Delete_AgentsOptimization_Async
        await jobsClient.DeleteAsync(jobId: submittedJob1.Id, cancellationToken: default);
        await jobsClient.DeleteAsync(jobId: submittedJob2.Id, cancellationToken: default);
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
    }

    public Sample_AgentsOptimizationCRUD(bool isAsync) : base(isAsync)
    { }
}
