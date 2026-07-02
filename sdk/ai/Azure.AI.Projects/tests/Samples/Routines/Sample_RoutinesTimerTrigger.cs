// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_RoutinesTimerTrigger : SamplesRoutineBase
{
    [Test]
    [AsyncOnly]
    public async Task RoutinesTimerTriggerAsync()
    {
        #region Snippet:Sample_CreateClient_RoutinesTimerTrigger
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string routineName = "sample-routine";
        string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string routineName = SAMPLE_ROUTINE_NAME_PREFIX;
        string agentName = TestEnvironment.HOSTED_AGENT_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        #endregion
        #region Snippet:Sample_GetHostedAgent_RoutinesTimerTrigger_Async
        ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
            agentName: agentName)).Value.GetLatestVersion();
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { await routinesClient.DeleteAsync(routineName); } catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesTimerTrigger_Async
        RoutineAction action = new AgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
            Input = BinaryData.FromObjectAsJson("Hello, Tell me a joke."),
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by the timer-trigger sample.", enabled: true);
        routineOptions.Triggers.Add("once", new TimerRoutineTrigger()
        {
            At = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(20),
        });
        ProjectsRoutine created = await routinesClient.CreateOrUpdateAsync(
            name: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}.");
        Console.WriteLine($"Fire at: {((TimerRoutineTrigger)routineOptions.Triggers["once"]).At.Value.ToString("o")}");
        #endregion

        #region Snippet:Sample_WaitForTask_RoutinesTimerTrigger_Async
        int minutesWait = 10;
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        RoutineRun completedRun = null;
        while (DateTime.UtcNow < deadline)
        {
            await Task.Delay(500);
            await foreach (RoutineRun run in projectClient.Routines.GetRoutineRunsAsync(name: created.Name))
            {
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
        if (completedRun == null)
        {
            throw new InvalidOperationException($"The run did not complete within {minutesWait} minutes.");
        }
        if (string.Equals(completedRun.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException("The run was forcefully stopped.");
        }
        if (string.Equals(completedRun.Status, "failed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException($"The run has failed with the error. Type: {completedRun.ErrorType} Message: {completedRun.ErrorMessage}.");
        }
        #endregion

        #region Snippet:Sample_PrintOutput_RoutinesTimerTrigger_Async
        Console.WriteLine($"The response Id is {completedRun.ResponseId}");
        // Note: retrieving the response body produced by a routine-dispatched
        // run via `projectClient.GetProjectOpenAIClient().GetProjectResponsesClient().GetResponseAsync(completedRun.responseId)` is
        // not yet supported by the service for this scenario.
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesTimerTrigger_Async
        await routinesClient.DeleteAsync(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void RoutinesTimerTriggerSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string routineName = "sample-routine";
        string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string routineName = SAMPLE_ROUTINE_NAME_PREFIX;
        string agentName = TestEnvironment.HOSTED_AGENT_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        #region Snippet:Sample_GetHostedAgent_RoutinesTimerTrigger_Sync
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
            agentName: agentName).Value.GetLatestVersion();
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { routinesClient.Delete(routineName); }
        catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesTimerTrigger_Sync
        RoutineAction action = new AgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
            Input = BinaryData.FromObjectAsJson("Hello, Tell me a joke."),
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by the timer-trigger sample.", enabled: true);
        routineOptions.Triggers.Add("once", new TimerRoutineTrigger()
        {
            At = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(20),
        });
        ProjectsRoutine created = routinesClient.CreateOrUpdate(
            name: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}.");
        Console.WriteLine($"Fire at: {((TimerRoutineTrigger)routineOptions.Triggers["once"]).At.Value.ToString("o")}");
        #endregion

        #region Snippet:Sample_WaitForTask_RoutinesTimerTrigger_Sync
        int minutesWait = 10;
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        RoutineRun completedRun = null;
        while (DateTime.UtcNow < deadline)
        {
            Thread.Sleep(500);
            foreach (RoutineRun run in projectClient.Routines.GetRoutineRuns(name: created.Name))
            {
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
        if (completedRun == null)
        {
            throw new InvalidOperationException($"The run did not complete within {minutesWait} minutes.");
        }
        if (string.Equals(completedRun.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException("The run was forcefully stopped.");
        }
        if (string.Equals(completedRun.Status, "failed", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new InvalidOperationException($"The run has failed with the error. Type: {completedRun.ErrorType} Message: {completedRun.ErrorMessage}.");
        }
        #endregion

        #region Snippet:Sample_PrintOutput_RoutinesTimerTrigger_Sync
        Console.WriteLine($"The response Id is {completedRun.ResponseId}");
        // Note: retrieving the response body produced by a routine-dispatched
        // run via `projectClient.GetProjectOpenAIClient().GetProjectResponsesClient().GetResponseAsync(completedRun.responseId)` is
        // not yet supported by the service for this scenario.
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesTimerTrigger_Sync
        routinesClient.Delete(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    public Sample_RoutinesTimerTrigger(bool isAsync) : base(isAsync)
    { }
}
