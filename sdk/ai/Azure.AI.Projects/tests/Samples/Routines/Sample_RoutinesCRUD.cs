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

public class Sample_RoutinesCRUD : SamplesBase
{
    #region Snippet:Sample_HostedAgentDefinition_RoutinesCRUD
    private static HostedAgentDefinition GetAgentDefinition(string dockerImage)
    {
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            ContainerConfiguration = new(dockerImage)
        };
        return agentDefinition;
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task RoutinesCRUDAsync()
    {
        #region Snippet:Sample_CreateClient_RoutinesCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        string routineName = "sample-routine";
        #endregion
        #region Snippet:Sample_CreateHostedAgent_RoutinesCRUD_Async
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myHostedForRoutines",
            options: creationOptions);
        #endregion
        // Clean up any pre-existing routine with the same name.
        try
        { await routinesClient.DeleteRoutineAsync(routineName); } catch { }

        #region Snippet:Sample_CreateRoutine_RoutinesCRUD_Async
        IDictionary<string, RoutineTrigger> triggers = new Dictionary<string, RoutineTrigger>
        {
            ["manual"] = new CustomRoutineTrigger(
                provider: "sample-provider",
                parameters: new Dictionary<string, BinaryData>
                {
                    ["source"] = BinaryData.FromString("\"sample_routines_crud\"")
                })
            {
                EventName = "sample-event"
            }
        };

        RoutineAction action = new InvokeAgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name
        };

        ProjectsRoutine created = await routinesClient.CreateOrUpdateRoutineAsync(
            routineName: routineName,
            triggers: triggers,
            action: action,
            description: "Routine created by the azure-ai-projects sample.",
            enabled: true);
        Console.WriteLine($"Created routine: {created.Name} enabled={created.Enabled}");
        #endregion

        #region Snippet:Sample_DisableRoutine_RoutinesCRUD_Async
        ProjectsRoutine disabled = await routinesClient.DisableRoutineAsync(routineName);
        Console.WriteLine($"Disabled routine: {disabled.Name} enabled={disabled.Enabled}");
        #endregion

        #region Snippet:Sample_GetRoutine_RoutinesCRUD_Async
        ProjectsRoutine fetched = await routinesClient.GetRoutineAsync(routineName);
        Console.WriteLine($"Retrieved routine: {fetched.Name} enabled={fetched.Enabled} description={fetched.Description}");
        #endregion

        #region Snippet:Sample_EnableRoutine_RoutinesCRUD_Async
        ProjectsRoutine enabled = await routinesClient.EnableRoutineAsync(routineName);
        Console.WriteLine($"Enabled routine: {enabled.Name} enabled={enabled.Enabled}");
        #endregion

        #region Snippet:Sample_ListRoutines_RoutinesCRUD_Async
        await foreach (ProjectsRoutine routine in routinesClient.GetRoutinesAsync())
        {
            Console.WriteLine($"  - {routine.Name} enabled={routine.Enabled}");
        }
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesCRUD_Async
        await routinesClient.DeleteRoutineAsync(routineName);
        Console.WriteLine("Routine deleted");
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void RoutinesCRUD()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        string routineName = "sample-routine";

        // Clean up any pre-existing routine with the same name.
        try { routinesClient.DeleteRoutine(routineName); } catch { }
        #region Snippet:Sample_CreateHostedAgent_RoutinesCRUD_Sync
        HostedAgentDefinition agentDefinition = GetAgentDefinition(
            dockerImage: dockerImage
        );
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myHostedForRoutines",
            options: creationOptions);
        #endregion
        #region Snippet:Sample_CreateRoutine_RoutinesCRUD_Sync
        IDictionary<string, RoutineTrigger> triggers = new Dictionary<string, RoutineTrigger>
        {
            ["manual"] = new CustomRoutineTrigger(
                provider: "sample-provider",
                parameters: new Dictionary<string, BinaryData>
                {
                    ["source"] = BinaryData.FromString("\"sample_routines_crud\"")
                })
            {
                EventName = "sample-event"
            }
        };

        RoutineAction action = new InvokeAgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name
        };

        ProjectsRoutine created = routinesClient.CreateOrUpdateRoutine(
            routineName: routineName,
            triggers: triggers,
            action: action,
            description: "Routine created by the azure-ai-projects sample.",
            enabled: true);
        Console.WriteLine($"Created routine: {created.Name} enabled={created.Enabled}");
        #endregion

        #region Snippet:Sample_DisableRoutine_RoutinesCRUD_Sync
        ProjectsRoutine disabled = routinesClient.DisableRoutine(routineName);
        Console.WriteLine($"Disabled routine: {disabled.Name} enabled={disabled.Enabled}");
        #endregion

        #region Snippet:Sample_GetRoutine_RoutinesCRUD_Sync
        ProjectsRoutine fetched = routinesClient.GetRoutine(routineName);
        Console.WriteLine($"Retrieved routine: {fetched.Name} enabled={fetched.Enabled} description={fetched.Description}");
        #endregion

        #region Snippet:Sample_EnableRoutine_RoutinesCRUD_Sync
        ProjectsRoutine enabled = routinesClient.EnableRoutine(routineName);
        Console.WriteLine($"Enabled routine: {enabled.Name} enabled={enabled.Enabled}");
        #endregion

        #region Snippet:Sample_ListRoutines_RoutinesCRUD_Sync
        foreach (ProjectsRoutine routine in routinesClient.GetRoutines())
        {
            Console.WriteLine($"  - {routine.Name} enabled={routine.Enabled}");
        }
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesCRUD_Sync
        routinesClient.DeleteRoutine(routineName);
        Console.WriteLine("Routine deleted");
        projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name);
        #endregion
    }

    public Sample_RoutinesCRUD(bool isAsync) : base(isAsync)
    { }
}
