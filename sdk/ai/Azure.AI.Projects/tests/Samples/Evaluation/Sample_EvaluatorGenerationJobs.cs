// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Evaluation;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;
#pragma warning disable SCME0006

public class Sample_EvaluatorGenerationJob : SamplesBase
{
    [Test]
    [AsyncOnly]
    public async Task EvaluatorGenerationJobAsync()
    {
        #region Snippet:Sample_CreateClients_EvaluatorGenerationJob
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAnAgent_EvaluatorGenerationJob_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that answers general questions",
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        EvaluatorGenerationInputs job = new(
            sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
            model: modelDeploymentName,
            evaluatorName: "coherence"
        );
        #endregion
        #region Snippet:Sample_CreateJob_EvaluatorGenerationJob_Async
        OperationResult result = await projectClient.EvaluatorGenerationJobs.CreateAsync(waitUntilCompleted: true, job: job);
        EvaluatorGenerationJob runningJob = EvaluatorGenerationJob.FromClientResult(await result.UpdateStatusAsync());
        Console.WriteLine($"Created job ID: {runningJob.Id}");
        #endregion
        #region Snippet:Sample_GetJob_EvaluatorGenerationJob_Async
        if (runningJob.Status == ProjectsJobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
        }
        Console.WriteLine($"The job ID: {runningJob.Id} completed, created evaluator {runningJob.Result.Name}, v. {runningJob.Result.Version}");
        #endregion
        #region Snippet:Sample_CancelingJob_EvaluatorGenerationJob_Async
        job = new(
            sources: [new PromptEvaluatorGenerationJobSource("Please explain the Maxwell's equation")],
            model: modelDeploymentName,
            evaluatorName: "violence"
        );
        result = await projectClient.EvaluatorGenerationJobs.CreateAsync(waitUntilCompleted: false, job: job);
        EvaluatorGenerationJob jobToCancel = EvaluatorGenerationJob.FromClientResult(await result.UpdateStatusAsync());
        jobToCancel = await projectClient.EvaluatorGenerationJobs.CancelAsync(jobToCancel.Id);
        while (jobToCancel.Status != ProjectsJobStatus.Failed && jobToCancel.Status != ProjectsJobStatus.Succeeded && jobToCancel.Status != ProjectsJobStatus.Cancelled)
        {
            await Task.Delay(500);
            Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
            jobToCancel = await projectClient.EvaluatorGenerationJobs.GetAsync(jobId: jobToCancel.Id);
        }
        if (jobToCancel.Status != ProjectsJobStatus.Cancelled)
        {
            throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
        }
        Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
        #endregion
        #region Snippet:Sample_ListJob_EvaluatorGenerationJob_Async
        // Wait while all jobs are being indexed.
        await Task.Delay(20000);
        await foreach (EvaluatorGenerationJob oneJob in projectClient.EvaluatorGenerationJobs.GetAllAsync())
        {
            Console.WriteLine($"Job ID: {oneJob.Id}, Status: {oneJob.Status}.");
        }
        #endregion
        #region Snippet:Sample_DeleteJob_EvaluatorGenerationJob_Async
        await projectClient.EvaluatorGenerationJobs.DeleteAsync(jobId: runningJob.Id);
        await projectClient.EvaluatorGenerationJobs.DeleteAsync(jobId: jobToCancel.Id);
        #endregion
    }

    [Test]
    [SyncOnly]
    public async Task EvaluatorGenerationJobSync()
    {
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var endpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        // Create client with debugging enabled
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        #region Snippet:Sample_CreateAnAgent_EvaluatorGenerationJob_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that answers general questions",
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "evalAgent",
            options: new(agentDefinition));
        Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
        EvaluatorGenerationInputs job = new(
            sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
            model: modelDeploymentName,
            evaluatorName: "coherence"
        );
        #endregion
        #region Snippet:Sample_CreateJob_EvaluatorGenerationJob_Sync
        OperationResult result = projectClient.EvaluatorGenerationJobs.Create(waitUntilCompleted: true, job: job);
        EvaluatorGenerationJob runningJob = EvaluatorGenerationJob.FromClientResult(result.UpdateStatus());
        Console.WriteLine($"Created job ID: {runningJob.Id}");
        #endregion
        #region Snippet:Sample_GetJob_EvaluatorGenerationJob_Sync
        if (runningJob.Status == ProjectsJobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
        }
        Console.WriteLine($"The job ID: {runningJob.Id} completed, created evaluator {runningJob.Result.Name}, v. {runningJob.Result.Version}");
        #endregion
        #region Snippet:Sample_CancelingJob_EvaluatorGenerationJob_Sync
        job = new(
            sources: [new PromptEvaluatorGenerationJobSource("Please explain the Maxwell's equation")],
            model: modelDeploymentName,
            evaluatorName: "violence"
        );
        result = projectClient.EvaluatorGenerationJobs.Create(waitUntilCompleted: false, job: job);
        EvaluatorGenerationJob jobToCancel = EvaluatorGenerationJob.FromClientResult(result.UpdateStatus());
        jobToCancel = projectClient.EvaluatorGenerationJobs.Cancel(jobToCancel.Id);
        while (jobToCancel.Status != ProjectsJobStatus.Failed && jobToCancel.Status != ProjectsJobStatus.Succeeded && jobToCancel.Status != ProjectsJobStatus.Cancelled)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Waiting for job {jobToCancel.Id} to cancel...");
            jobToCancel = projectClient.EvaluatorGenerationJobs.Get(jobId: jobToCancel.Id);
        }
        if (jobToCancel.Status != ProjectsJobStatus.Cancelled)
        {
            throw new InvalidOperationException($"The job {jobToCancel.Id} has failed.");
        }
        Console.WriteLine($"The job {jobToCancel.Id} was canceled.");
        #endregion
        #region Snippet:Sample_ListJob_EvaluatorGenerationJob_Sync
        // Wait while all jobs are being indexed.
        Thread.Sleep(20000);
        foreach (EvaluatorGenerationJob oneJob in projectClient.EvaluatorGenerationJobs.GetAll())
        {
            Console.WriteLine($"Job ID: {oneJob.Id}, Status: {oneJob.Status}.");
        }
        #endregion
        #region Snippet:Sample_DeleteJob_EvaluatorGenerationJob_Sync
        projectClient.EvaluatorGenerationJobs.Delete(jobId: runningJob.Id);
        projectClient.EvaluatorGenerationJobs.Delete(jobId: jobToCancel.Id);
        #endregion
    }

    public Sample_EvaluatorGenerationJob(bool isAsync) : base(isAsync)
    { }
}
