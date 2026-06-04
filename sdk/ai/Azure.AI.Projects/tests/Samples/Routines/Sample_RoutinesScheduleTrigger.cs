// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_RoutinesScheduleTrigger : SamplesBase
{
    #region Snippet:Sample_HostedAgentDefinition_RoutinesScheduleTrigger
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
    public async Task RoutinesScheduleTriggerAsync()
    {
        #region Snippet:Sample_CreateClient_RoutinesScheduleTrigger
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var dockerImage = TestEnvironment.AGENT_DOCKER_IMAGE;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AIProjectRoutines routinesClient = projectClient.Routines;
        string routineName = "sample-schreduloed-routine";
        #endregion
        #region Snippet:Sample_CreateHostedAgent_RoutinesScheduleTrigger_Async
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

        #region Snippet:Sample_CreateRoutine_RoutinesScheduleTrigger_Async
        IDictionary<string, RoutineTrigger> triggers = new Dictionary<string, RoutineTrigger>
        {
            ["every_five_minutes"] = new ScheduleRoutineTrigger(
                cronExpression: "*/5 * * * *",
                timeZone: "UTC"
            )
        };

        RoutineAction action = new InvokeAgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name
        };

        ProjectsRoutine created = await routinesClient.CreateOrUpdateRoutineAsync(
            routineName: routineName,
            triggers: triggers,
            action: action,
            description: "Routine used by the schedule-trigger sample.",
            enabled: true);
        Console.WriteLine($"Created routine: {created.Name} enabled={created.Enabled}.");
        Console.WriteLine($"cron expression: {((ScheduleRoutineTrigger)triggers["every_five_minutes"]).CronExpression}; time zone: {((ScheduleRoutineTrigger)triggers["every_five_minutes"]).TimeZone}");
        #endregion

        #region Snippet:Sample_WaitForTask_RoutinesScheduleTrigger_Async
        int minutesWait = 10;
        Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
        DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 10, seconds: 0);
        RoutineRun completedRun = null;
        while (DateTime.UtcNow < deadline)
        {
            await foreach (RoutineRun run in projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name))
            {
                Console.WriteLine($"    - run ID {run.Id}, status: {run.Status}, trigger type: {run.TriggerType}, truggered at: {run.TriggeredAt?.ToString() ?? "<Not triggered yet>"}, ended at: {run.EndedAt?.ToString() ?? "<Not ended yet>"}");
                if (string.Equals(run.Status, "finished", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "failed", StringComparison.InvariantCultureIgnoreCase) ||
                    string.Equals(run.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
                {
                    completedRun = run;
                }
            }
        }
        if (completedRun == null)
        {
            throw new InvalidOperationException($"The run did not completed within {minutesWait} minutes.");
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

        #region Snippet:Sample_PrintOutput_RoutinesScheduleTrigger_Async
        Console.WriteLine($"The response Id is {completedRun.ResponseId}");
        // Note: retrieving the response body produced by a routine-dispatched
        // run via `projectClient.GetProjectOpenAIClient().GetProjectResponsesClient().GetResponseAsync(final_run.response_id)` is
        // not yet supported by the service for this scenario.
        //GetResponseOptions responseOptions = new()
        //{

        //};
        //projectClient.GetProjectOpenAIClient().GetProjectResponsesClient().GetResponseAsync()
        #endregion

        #region Snippet:Sample_DeleteRoutine_RoutinesScheduleTrigger_Async
        await routinesClient.DeleteRoutineAsync(routineName);
        Console.WriteLine("Routine deleted");
        await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name);
        #endregion
    }

    
    public Sample_RoutinesScheduleTrigger(bool isAsync) : base(isAsync)
    { }
}
