// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Extensions.OpenAI;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_RoutinesManualDispatch : SamplesRoutineBase
{
    [Test]
    [AsyncOnly]
    public async Task RoutinesManualDispatchAsync()
    {
        #region Snippet:Sample_CreateClient_RoutinesManualDispatch
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string routineName = "sample-routine";
        string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        string connectionName = System.Environment.GetEnvironmentVariable("TEAMS_CONNECTION_NAME");
        string teamsGroupID = System.Environment.GetEnvironmentVariable("TEAMS_GROUP_ID");
        string teamsChannelID = System.Environment.GetEnvironmentVariable("TEAMS_CHANNEL_ID");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string routineName = SAMPLE_ROUTINE_NAME_PREFIX;
        string agentName = TestEnvironment.HOSTED_AGENT_NAME;
        string connectionName = TestEnvironment.TEAMS_CONNECTION_NAME;
        string teamsGroupID = TestEnvironment.TEAMS_GROUP_ID;
        string teamsChannelID = TestEnvironment.TEAMS_CHANNEL_ID;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        #endregion
        #region Snippet:Sample_GetHostedAgent_RoutinesManualDispatch_Async
        ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
            agentName: agentName)).Value.GetLatestVersion();
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { await routinesClient.DeleteAsync(routineName); } catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesManualDispatch_Async
        RoutineAction action = new AgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by manual dispatch sample.", enabled: true);
        routineOptions.Triggers.Add("manual", new CustomRoutineTrigger(provider: "teams", parameters: new Dictionary<string, BinaryData>()
        {
            { "connection_id", BinaryData.FromString(JsonSerializer.Serialize(connectionName)) },
            { "thread_type", BinaryData.FromString(JsonSerializer.Serialize("channel")) },
            { "group_id", BinaryData.FromString(JsonSerializer.Serialize(teamsGroupID))},
            { "channel_id", BinaryData.FromString(JsonSerializer.Serialize(teamsChannelID))},
        }));
        ProjectsRoutine created = await routinesClient.CreateOrUpdateAsync(
            name: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}.");
        #endregion
        #region Snippet:Sample_WaitForTeamsTriggeredTask_RoutinesManualDispatch_Async
        Console.WriteLine("Please send the message in the teams channel to proceed.");
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
        #region Snippet:Sample_DispatchTask_RoutinesManualDispatch_Async
        DispatchRoutineResult dispatch = await routinesClient.DispatchAsync(name: created.Name, payload: new AgentResponsesApiDispatchPayload(BinaryData.FromObjectAsJson("Hello, Tell me a joke.")));
        Console.WriteLine($"Dispatched the routine. Dispatch ID {dispatch.DispatchId}, task ID: {dispatch.TaskId}.");
        #endregion
        #region Snippet:Sample_WaitForTask_RoutinesManualDispatch_Async
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        completedRun = null;
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
        CheckRunResult(completedRun, minutesWait, true);
        #endregion

        #region Snippet:Sample_PrintOutput_RoutinesManualDispatch_Async
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

        #region Snippet:Sample_DeleteRoutine_RoutinesManualDispatch_Async
        await routinesClient.DeleteAsync(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void RoutinesManualDispatchSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        string routineName = "sample-routine";
        string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
        string connectionName = System.Environment.GetEnvironmentVariable("TEAMS_CONNECTION_NAME");
        string teamsGroupID = System.Environment.GetEnvironmentVariable("TEAMS_GROUP_ID");
        string teamsChannelID = System.Environment.GetEnvironmentVariable("TEAMS_CHANNEL_ID");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        string routineName = SAMPLE_ROUTINE_NAME_PREFIX;
        string agentName = TestEnvironment.HOSTED_AGENT_NAME;
        string connectionName = TestEnvironment.TEAMS_CONNECTION_NAME;
        string teamsGroupID = TestEnvironment.TEAMS_GROUP_ID;
        string teamsChannelID = TestEnvironment.TEAMS_CHANNEL_ID;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        #region Snippet:Sample_GetHostedAgent_RoutinesManualDispatch_Sync
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
            agentName: agentName).Value.GetLatestVersion();
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { routinesClient.Delete(routineName); }
        catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesManualDispatch_Sync
        RoutineAction action = new AgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine used by manual dispatch sample.", enabled: true);
        routineOptions.Triggers.Add("manual", new CustomRoutineTrigger(provider: "teams", parameters: new Dictionary<string, BinaryData>()
        {
            { "connection_id", BinaryData.FromString(JsonSerializer.Serialize(connectionName)) },
            { "thread_type", BinaryData.FromString(JsonSerializer.Serialize("channel")) },
            { "group_id", BinaryData.FromString(JsonSerializer.Serialize(teamsGroupID))},
            { "channel_id", BinaryData.FromString(JsonSerializer.Serialize(teamsChannelID))},
        }));
        ProjectsRoutine created = routinesClient.CreateOrUpdate(
            name: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}.");
        #endregion
        #region Snippet:Sample_WaitForTeamsTriggeredTask_RoutinesManualDispatch_Sync
        Console.WriteLine("Please send the message in the teams channel to proceed.");
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
        #region Snippet:Sample_DispatchTask_RoutinesManualDispatch_Sync
        DispatchRoutineResult dispatch = routinesClient.Dispatch(name: created.Name, payload: new AgentResponsesApiDispatchPayload(BinaryData.FromObjectAsJson("Hello, Tell me a joke.")));
        Console.WriteLine($"Dispatched the routine. Dispatch ID {dispatch.DispatchId}, task ID: {dispatch.TaskId}.");
        #endregion
        #region Snippet:Sample_WaitForTask_RoutinesManualDispatch_Sync
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
        completedRun = null;
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
        CheckRunResult(completedRun, minutesWait, true);
        #endregion

        #region Snippet:Sample_PrintOutput_RoutinesManualDispatch_Sync
        Console.WriteLine($"The response Id is {completedRun.ResponseId}");
        //  Currently the response retrieval is not supported.
        //ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
        //ResponseResult result = oaiClient.GetResponse(new GetResponseOptions(responseId: completedRun.ResponseId));
        //if (result.Error is not null)
        //{
        //    throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
        //}
        //Console.WriteLine($"Response: {result.GetOutputText()}");
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesManualDispatch_Sync
        routinesClient.Delete(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    public Sample_RoutinesManualDispatch(bool isAsync) : base(isAsync)
    { }
}
