// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;

namespace Azure.AI.Projects.Agents.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_AgentsOptimizationCandidates : SamplesBase
{
    #region Snippet:Sample_OptimizationEvaluator_AgentsOptimizationCandidates
    private static AgentOptimizationEvaluator GetEvaluator() =>
        new(name: "builtin.meteor_score");
    #endregion
    #region Snippet:Sample_Dataset_AgentsOptimizationCandidates
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
    #endregion

    #region Snippet:Sample_OptimizationBaseline_AgentsOptimizationCandidates
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
    #endregion

    [Test]
    [AsyncOnly]
    public async Task AgentsOptimizationCandidatesAsync()
    {
        #region Snippet:Sample_CreateClient_AgentsOptimizationCandidates
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var anotherModelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME2");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var anotherModelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME2;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();
        #endregion

        #region Snippet:Sample_CreateAgent_AgentsOptimizationCandidates_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            // Start from bad prompt.
            Instructions = "You are a prompt agent, who always give wrong answers."
        };
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
            agentName: "cs-e2e-tests-client",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Async
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
        #endregion
        #region Snippet:Sample_GetOptimizationJob_AgentsOptimizationCandidates_Async
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
        #endregion
        #region Snippet:Sample_OptimizationResult_AgentsOptimizationCandidates_Async
        AgentOptimizationResultCandidateSummary summary = submittedJob.Result?.CandidateSummary
            ?? throw new InvalidOperationException($"Job {submittedJob.Id} did not return a candidate summary.");
        Console.WriteLine($"Baseline candidate: {summary.BaselineId} (score: {summary.BaselineScore})");
        Console.WriteLine($"Best candidate: {summary.BestId} (score: {summary.BestScore})");
        Console.WriteLine($"Completed candidates: {summary.CompletedCandidateCount}");
        #endregion
        #region Snippet:Sample_Delete_AgentsOptimizationCandidates_Async
        await jobsClient.DeleteAsync(jobId: submittedJob.Id, cancellationToken: default);
        Console.WriteLine($"Deleted job {submittedJob.Id}.");
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentsOptimizationCandidatesSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var anotherModelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME2");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var anotherModelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME2;
#endif
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();

        #region Snippet:Sample_CreateAgent_AgentsOptimizationCandidates_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            // Start from bad prompt.
            Instructions = "You are a prompt agent, who always give wrong answers."
        };
        ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
            agentName: "myAgent1",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateOptimizationJob_AgentsOptimizationCandidates_Sync
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
        #endregion
        #region Snippet:Sample_GetOptimizationJob_AgentsOptimizationCandidates_Sync
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
        #endregion
        #region Snippet:Sample_OptimizationResult_AgentsOptimizationCandidates_Sync
        AgentOptimizationResultCandidateSummary summary = submittedJob.Result?.CandidateSummary
            ?? throw new InvalidOperationException($"Job {submittedJob.Id} did not return a candidate summary.");
        Console.WriteLine($"Baseline candidate: {summary.BaselineId} (score: {summary.BaselineScore})");
        Console.WriteLine($"Best candidate: {summary.BestId} (score: {summary.BestScore})");
        Console.WriteLine($"Completed candidates: {summary.CompletedCandidateCount}");
        #endregion
        #region Snippet:Sample_Delete_AgentsOptimizationCandidates_Sync
        jobsClient.Delete(jobId: submittedJob.Id, cancellationToken: default);
        Console.WriteLine($"Deleted job {submittedJob.Id}.");
        agentsClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
    }

    public Sample_AgentsOptimizationCandidates(bool isAsync) : base(isAsync)
    { }
}
