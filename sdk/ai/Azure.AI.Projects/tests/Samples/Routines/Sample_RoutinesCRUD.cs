// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_RoutinesCRUD : SamplesRoutineBase
{
    [Test]
    [AsyncOnly]
    public async Task RoutinesCRUDAsync()
    {
        #region Snippet:Sample_CreateClient_RoutinesCRUD
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
        #region Snippet:Sample_GetHostedAgent_RoutinesCRUD_Async
        ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
            agentName: agentName)).Value.GetLatestVersion();
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { await routinesClient.DeleteAsync(routineName); } catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesCRUD_Async
        RoutineAction action = new AgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine created by the azure-ai-projects sample.", enabled: true);
        routineOptions.Triggers.Add("manual", new CustomRoutineTrigger(
                provider: "sample-provider",
                parameters: new Dictionary<string, BinaryData>
                {
                    ["source"] = BinaryData.FromString("\"sample_routines_crud\"")
                })
        {
            EventName = "sample-event"
        });
        ProjectsRoutine created = await routinesClient.CreateOrUpdateAsync(
            name: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}");
        #endregion

        #region Snippet:Sample_DisableRoutine_RoutinesCRUD_Async
        ProjectsRoutine disabled = await routinesClient.DisableAsync(routineName);
        Console.WriteLine($"Disabled routine: {disabled.Name} enabled={disabled.IsEnabled}");
        #endregion

        #region Snippet:Sample_GetRoutine_RoutinesCRUD_Async
        ProjectsRoutine fetched = await routinesClient.GetAsync(routineName);
        Console.WriteLine($"Retrieved routine: {fetched.Name} enabled={fetched.IsEnabled} description={fetched.Description}");
        #endregion

        #region Snippet:Sample_EnableRoutine_RoutinesCRUD_Async
        ProjectsRoutine enabled = await routinesClient.EnableAsync(routineName);
        Console.WriteLine($"Enabled routine: {enabled.Name} enabled={enabled.IsEnabled}");
        #endregion

        #region Snippet:Sample_ListRoutines_RoutinesCRUD_Async
        await foreach (ProjectsRoutine routine in routinesClient.GetRoutinesAsync())
        {
            Console.WriteLine($"  - {routine.Name} enabled={routine.IsEnabled}");
        }
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesCRUD_Async
        await routinesClient.DeleteAsync(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    [Test]
    [SyncOnly]
    public void RoutinesCRUD()
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
        // Clean up any pre-existing routine with the same name.
        try { routinesClient.Delete(routineName); } catch { }
        #region Snippet:Sample_GetHostedAgent_RoutinesCRUD_Sync
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
            agentName: agentName).Value.GetLatestVersion();
        #endregion
        #region Snippet:Sample_CreateRoutine_RoutinesCRUD_Sync
        RoutineAction action = new AgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name
        };
        ProjectsRoutineOptions routineOptions = new(action: action, description: "Routine created by the azure-ai-projects sample.", enabled: true);
        routineOptions.Triggers.Add("manual", new CustomRoutineTrigger(
                provider: "sample-provider",
                parameters: new Dictionary<string, BinaryData>
                {
                    ["source"] = BinaryData.FromString("\"sample_routines_crud\"")
                })
        {
            EventName = "sample-event"
        });
        ProjectsRoutine created = routinesClient.CreateOrUpdate(
            name: routineName,
            options: routineOptions
        );
        Console.WriteLine($"Created routine: {created.Name} enabled={created.IsEnabled}");
        #endregion

        #region Snippet:Sample_DisableRoutine_RoutinesCRUD_Sync
        ProjectsRoutine disabled = routinesClient.Disable(routineName);
        Console.WriteLine($"Disabled routine: {disabled.Name} enabled={disabled.IsEnabled}");
        #endregion

        #region Snippet:Sample_GetRoutine_RoutinesCRUD_Sync
        ProjectsRoutine fetched = routinesClient.Get(routineName);
        Console.WriteLine($"Retrieved routine: {fetched.Name} enabled={fetched.IsEnabled} description={fetched.Description}");
        #endregion

        #region Snippet:Sample_EnableRoutine_RoutinesCRUD_Sync
        ProjectsRoutine enabled = routinesClient.Enable(routineName);
        Console.WriteLine($"Enabled routine: {enabled.Name} enabled={enabled.IsEnabled}");
        #endregion

        #region Snippet:Sample_ListRoutines_RoutinesCRUD_Sync
        foreach (ProjectsRoutine routine in routinesClient.GetRoutines())
        {
            Console.WriteLine($"  - {routine.Name} enabled={routine.IsEnabled}");
        }
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesCRUD_Sync
        routinesClient.Delete(routineName);
        Console.WriteLine("Routine deleted");
        #endregion
    }

    public Sample_RoutinesCRUD(bool isAsync) : base(isAsync)
    { }
}
