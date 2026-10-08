// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests.Samples;
#pragma warning disable AAIP001
#pragma warning disable SCME0006

public class Sample_AgentsOptimizationCRUD : SamplesBase
{
    #region Snippet:Sample_Dataset_AgentsOptimization
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
    #endregion

    [Test]
    [AsyncOnly]
    public async Task AgentsOptimizationAsync()
    {
        #region Snippet:Sample_CreateClient_AgentsOptimization
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
                TargetAttributes = { TargetAttribute.Model },
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
        AgentOptimizationJob submittedJob1 = AgentOptimizationJob.FromClientResult(await jobOperation.UpdateStatusAsync());
        Console.WriteLine($"Submitted optimization job: {submittedJob1.Id}");
        #endregion
        #region Snippet:Sample_GetOptimizationJob_AgentsOptimization_Async
        int reportedWarnings = 0;
        if (submittedJob1.Status == AgentsJobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {submittedJob1.Id} has failed.");
        }
        if (submittedJob1.Warnings.Count > reportedWarnings)
        {
            Console.WriteLine($"    {submittedJob1.Id}: {submittedJob1.Status}");
            for (int i = reportedWarnings; i < submittedJob1.Warnings.Count; i++)
            {
                Console.WriteLine($"    Warning in job {submittedJob1.Id}: {submittedJob1.Warnings[i]}");
            }
        }
        #endregion
        #region Snippet:Sample_CancelOptimizationJob_AgentsOptimization_Async
        jobOperation = await jobsClient.CreateAsync(waitUntilCompleted: false, job: job, operationId: null, cancellationToken: default);
        AgentOptimizationJob submittedJob2 = AgentOptimizationJob.FromClientResult(await jobOperation.UpdateStatusAsync());
        Console.WriteLine($"Submitted optimization job: {submittedJob2.Id}");
        AgentOptimizationJob cancelledJob = await jobsClient.CancelAsync(jobId: submittedJob2.Id, cancellationToken: default);
        while (cancelledJob.Status != AgentsJobStatus.Failed && cancelledJob.Status != AgentsJobStatus.Succeeded && cancelledJob.Status != AgentsJobStatus.Cancelled)
        {
            await Task.Delay(500);
            cancelledJob = AgentOptimizationJob.FromClientResult(await jobOperation.UpdateStatusAsync());
        }
        if (cancelledJob.Status != AgentsJobStatus.Cancelled)
        {
            throw new InvalidOperationException($"The job {cancelledJob.Id} has unexpected status: {cancelledJob.Status}.");
        }
        Console.WriteLine($"The job {cancelledJob.Id} was cancelled.");
        #endregion
        #region Snippet:Sample_ListOptimizationJobs_AgentsOptimization_Async
        Console.WriteLine("Listing optimization jobs:");
        await foreach (AgentOptimizationJob oneJob in jobsClient.GetAllAsync())
        {
            Console.WriteLine($"    Job: {oneJob.Id}, Status: {oneJob.Status}.");
        }
        #endregion
        #region Snippet:Sample_Delete_AgentsOptimization_Async
        await jobsClient.DeleteAsync(jobId: submittedJob1.Id, cancellationToken: default);
        Console.WriteLine($"Deleted job {submittedJob1.Id}.");
        // The deletion of cancelled job may not happen immediately after the cancellation.
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(5);
        bool wasDeleted = false;
        while (DateTime.UtcNow < deadline)
        {
            try
            {
                await jobsClient.DeleteAsync(jobId: submittedJob2.Id, cancellationToken: default);
                wasDeleted = true;
                break;
            }
            catch { }
        }
        Console.WriteLine($"The job {submittedJob2.Id} was{(wasDeleted ? "": " not")}.");
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AgentsOptimizationSync()
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
        AgentAdministrationClientOptions opts = new();
        opts.AddPolicy(GetDumpPolicy(), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: opts);
        AgentOptimizationJobs jobsClient = agentsClient.GetAgentOptimizationJobs();

        #region Snippet:Sample_CreateAgent_AgentsOptimization_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a prompt agent."
        };
        ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
        #region Snippet:Sample_CreateOptimizationJob_AgentsOptimization_Sync
        AgentOptimizationConfiguration conf = new(
            evaluationConfiguration: new(
                trainingSet: GetDataset(0, 7),
                evaluators: [ new AgentOptimizationEvaluator(name: "builtin.meteor_score") ],
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
                TargetAttributes = { TargetAttribute.Model },
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
        //

        //
        OperationResult jobOperation = jobsClient.Create(waitUntilCompleted: true, job: job, operationId: null, cancellationToken: default);
        AgentOptimizationJob submittedJob1 = AgentOptimizationJob.FromClientResult(jobOperation.UpdateStatus());
        Console.WriteLine($"Submitted optimization job: {submittedJob1.Id}");
        #endregion
        #region Snippet:Sample_GetOptimizationJob_AgentsOptimization_Sync
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
        #endregion
        #region Snippet:Sample_CancelOptimizationJob_AgentsOptimization_Sync
        jobOperation = jobsClient.Create(waitUntilCompleted: false, job: job, operationId: null, cancellationToken: default);
        AgentOptimizationJob submittedJob2 = AgentOptimizationJob.FromClientResult(jobOperation.UpdateStatus());
        Console.WriteLine($"Submitted optimization job: {submittedJob2.Id}");
        AgentOptimizationJob cancelledJob = jobsClient.Cancel(jobId: submittedJob2.Id, cancellationToken: default);
        while (cancelledJob.Status != AgentsJobStatus.Failed && cancelledJob.Status != AgentsJobStatus.Succeeded && cancelledJob.Status != AgentsJobStatus.Cancelled)
        {
            Thread.Sleep(500);
            cancelledJob = AgentOptimizationJob.FromClientResult(jobOperation.UpdateStatus());
        }
        if (cancelledJob.Status != AgentsJobStatus.Cancelled)
        {
            throw new InvalidOperationException($"The job {cancelledJob.Id} has unexpected status: {cancelledJob.Status}.");
        }
        Console.WriteLine($"The job {cancelledJob.Id} was cancelled.");
        #endregion
        #region Snippet:Sample_ListOptimizationJobs_AgentsOptimization_Sync
        Console.WriteLine("Listing optimization jobs:");
        foreach (AgentOptimizationJob oneJob in jobsClient.GetAll())
        {
            Console.WriteLine($"    Job: {oneJob.Id}, Status: {oneJob.Status}.");
        }
        #endregion
        #region Snippet:Sample_Delete_AgentsOptimization_Sync
        jobsClient.Delete(jobId: submittedJob1.Id, cancellationToken: default);
        Console.WriteLine($"Deleted job {submittedJob1.Id}.");
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(5);
        bool wasDeleted = false;
        while (DateTime.UtcNow < deadline)
        {
            try
            {
                jobsClient.Delete(jobId: submittedJob2.Id, cancellationToken: default);
                wasDeleted = true;
                break;
            }
            catch { }
        }
        Console.WriteLine($"The job {submittedJob2.Id} was{(wasDeleted ? "" : " not")}.");
        agentsClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Console.WriteLine($"Agent deleted (name: {agentVersion.Name}, version: {agentVersion.Version})");
        #endregion
    }

    public Sample_AgentsOptimizationCRUD(bool isAsync) : base(isAsync)
    { }
}
