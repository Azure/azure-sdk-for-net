// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_RoutinesGithub : SamplesRoutineBase
{
    [Test]
    [AsyncOnly]
    public async Task RoutinesGithubAsync()
    {
        #region Snippet:Sample_CreateClient_RoutinesGithub
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string routineName = "sample-routine";
        string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        string connectionName = System.Environment.GetEnvironmentVariable("GITHUB_CONNECTION_NAME");
        string owner = System.Environment.GetEnvironmentVariable("GITHUB_USERNAME");
        string repository = System.Environment.GetEnvironmentVariable("GITHUB_REPOSITORY");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string routineName = SAMPLE_ROUTINE_NAME_PREFIX;
        string agentName = TestEnvironment.HOSTED_AGENT_NAME;
        string connectionName = TestEnvironment.GITHUB_CONNECTION_NAME;
        string owner = TestEnvironment.GITHUB_USERNAME;
        string repository = TestEnvironment.GITHUB_REPOSITORY;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        #endregion
        #region Snippet:Sample_GetHostedAgent_RoutinesGithub_Async
        ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
            agentName: agentName)).Value.GetLatestVersion();
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { await routinesClient.DeleteAsync(routineName); } catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesGithub_Async
        RoutineAction action = new AgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by GitHub trigger sample.", enabled: true);
        routineOptions.Triggers.Add("on-issue",
            new GitHubIssueRoutineTrigger(
                connectionId: connectionName,
                owner: owner,
                repository: repository,
                issueEvent: GitHubIssueEvent.Opened
            )
        );
        ProjectsRoutine created = await routinesClient.CreateOrUpdateAsync(
            name: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}.");
        #endregion
        #region Snippet:Sample_WaitForGitHubEventTriggeredTask_RoutinesGithub_Async
        Console.WriteLine($"Please create an issue on {repository} GitHub repository.");
        int minutesWait = 10;
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        RoutineRun completedRun = null;
        bool runWasTriggered = false;
        while (DateTime.UtcNow < deadline)
        {
            await Task.Delay(500);
            await foreach (RoutineRun run in projectClient.Routines.GetRoutineRunsAsync(name: created.Name))
            {
                runWasTriggered = true;
                Console.WriteLine($"    - run ID {run.Id}, status: {run.Status}, trigger type: {run.TriggerType}, triggered at: {run.TriggeredAt?.ToString() ?? "<Not triggered yet>"}, ended at: {run.EndedAt?.ToString() ?? "<Not ended yet>"}");
                if (string.Equals(run.Status, "finished", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "failed", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
                {
                    completedRun = run;
                }
            }
            if (completedRun is not null)
            {
                break;
            }
        }
        CheckRunResult(completedRun, minutesWait, runWasTriggered);
        #endregion

        #region Snippet:Sample_PrintOutput_RoutinesGithub_Async
        Console.WriteLine($"The response Id is {completedRun.ResponseId}");
        //  Currently the response retrieval is not supported.
        // ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
        // ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
        // if (result.Error is not null)
        // {
        //     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
        // }
        // Console.WriteLine($"Response: {result.GetOutputText()}");
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesGithub_Async
        await routinesClient.DeleteAsync(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void RoutinesGithubSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string routineName = "sample-routine";
        string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        string connectionName = System.Environment.GetEnvironmentVariable("GITHUB_CONNECTION_NAME");
        string owner = System.Environment.GetEnvironmentVariable("GITHUB_USERNAME");
        string repository = System.Environment.GetEnvironmentVariable("GITHUB_REPOSITORY");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string routineName = SAMPLE_ROUTINE_NAME_PREFIX;
        string agentName = TestEnvironment.HOSTED_AGENT_NAME;
        string connectionName = TestEnvironment.GITHUB_CONNECTION_NAME;
        string owner = TestEnvironment.GITHUB_USERNAME;
        string repository = TestEnvironment.GITHUB_REPOSITORY;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        #region Snippet:Sample_GetHostedAgent_RoutinesGithub_Sync
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
            agentName: agentName).Value.GetLatestVersion();
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { routinesClient.Delete(routineName); }
        catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesGithub_Sync
        RoutineAction action = new AgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by GitHub trigger sample.", enabled: true);
        routineOptions.Triggers.Add("on-issue",
            new GitHubIssueRoutineTrigger(
                connectionId: connectionName,
                owner: owner,
                repository: repository,
                issueEvent: GitHubIssueEvent.Opened
            )
        );
        ProjectsRoutine created = routinesClient.CreateOrUpdate(
            name: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}.");
        #endregion
        #region Snippet:Sample_WaitForGitHubEventTriggeredTask_RoutinesGithub_Sync
        Console.WriteLine($"Please create an issue on {repository} GitHub repository.");
        int minutesWait = 10;
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        RoutineRun completedRun = null;
        bool runWasTriggered = false;
        while (DateTime.UtcNow < deadline)
        {
            Thread.Sleep(500);
            foreach (RoutineRun run in projectClient.Routines.GetRoutineRuns(name: created.Name))
            {
                runWasTriggered = true;
                Console.WriteLine($"    - run ID {run.Id}, status: {run.Status}, trigger type: {run.TriggerType}, triggered at: {run.TriggeredAt?.ToString() ?? "<Not triggered yet>"}, ended at: {run.EndedAt?.ToString() ?? "<Not ended yet>"}");
                if (string.Equals(run.Status, "finished", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "failed", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
                {
                    completedRun = run;
                }
            }
            if (completedRun is not null)
            {
                break;
            }
        }
        CheckRunResult(completedRun, minutesWait, runWasTriggered);
        #endregion

        #region Snippet:Sample_PrintOutput_RoutinesGithub_Sync
        Console.WriteLine($"The response Id is {completedRun.ResponseId}");
        //  Currently the response retrieval is not supported.
        // ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
        // ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
        // if (result.Error is not null)
        // {
        //     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
        // }
        // Console.WriteLine($"Response: {result.GetOutputText()}");
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesGithub_Sync
        routinesClient.Delete(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    public Sample_RoutinesGithub(bool isAsync) : base(isAsync)
    { }
}
