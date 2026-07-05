// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.AI.Projects.Evaluation;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples.Evaluation;

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
        EvaluatorGenerationJob job = new()
        {
            Inputs = new EvaluatorGenerationInputs(
                sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
                model: modelDeploymentName,
                evaluatorName: "coherence"
            )
        };
        #endregion
        #region Snippet:Sample_CreateJob_EvaluatorGenerationJob_Async
        EvaluatorGenerationJob runningJob = await projectClient.EvaluatorGenerationJobs.CreateAsync(job);
        Console.WriteLine($"Created job ID: {runningJob.Id}");
        #endregion
        #region Snippet:Sample_GetJob_EvaluatorGenerationJob_Async
        while (runningJob.Status != ProjectsJobStatus.Failed && runningJob.Status != ProjectsJobStatus.Succeeded)
        {
            await Task.Delay(500);
            Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
            runningJob = await projectClient.EvaluatorGenerationJobs.GetAsync(jobId: runningJob.Id);
        }
        if (runningJob.Status == ProjectsJobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
        }
        Console.WriteLine($"The job ID: {runningJob.Id} completed, created evaluator {runningJob.Result.Name}, v. {runningJob.Result.Version}");
        #endregion
        #region Snippet:Sample_CancelingJob_EvaluatorGenerationJob_Async
        job = new()
        {
            Inputs = new EvaluatorGenerationInputs(
                sources: [new PromptEvaluatorGenerationJobSource("Please explain the Maxwell's equation")],
                model: modelDeploymentName,
                evaluatorName: "violence"
            )
        };
        EvaluatorGenerationJob jobToCancel = await projectClient.EvaluatorGenerationJobs.CreateAsync(job);
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
    public void EvaluatorGenerationJobSync()
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
        EvaluatorGenerationJob job = new()
        {
            Inputs = new EvaluatorGenerationInputs(
                sources: [new AgentEvaluatorGenerationJobSource(agentName: agentVersion.Name)],
                model: modelDeploymentName,
                evaluatorName: "coherence"
            )
        };
        #endregion
        #region Snippet:Sample_CreateJob_EvaluatorGenerationJob_Sync
        EvaluatorGenerationJob runningJob = projectClient.EvaluatorGenerationJobs.Create(job);
        Console.WriteLine($"Created job ID: {runningJob.Id}");
        #endregion
        #region Snippet:Sample_GetJob_EvaluatorGenerationJob_Sync
        while (runningJob.Status != ProjectsJobStatus.Failed && runningJob.Status != ProjectsJobStatus.Succeeded)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Waiting for job ID: {runningJob.Id}...");
            runningJob = projectClient.EvaluatorGenerationJobs.Get(jobId: runningJob.Id);
        }
        if (runningJob.Status == ProjectsJobStatus.Failed)
        {
            throw new InvalidOperationException($"The job {runningJob.Id} has failed.");
        }
        Console.WriteLine($"The job ID: {runningJob.Id} completed, created evaluator {runningJob.Result.Name}, v. {runningJob.Result.Version}");
        #endregion
        #region Snippet:Sample_CancelingJob_EvaluatorGenerationJob_Sync
        job = new()
        {
            Inputs = new EvaluatorGenerationInputs(
                sources: [new PromptEvaluatorGenerationJobSource("Please explain the Maxwell's equation")],
                model: modelDeploymentName,
                evaluatorName: "violence"
            )
        };
        EvaluatorGenerationJob jobToCancel = projectClient.EvaluatorGenerationJobs.Create(job);
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
