// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;
#pragma warning disable AAIP001

public class RoutinesTests : ProjectsClientTestBase
{
    public static readonly string HOSTED_AGENT_PREFIX = "cs-routines-hosted-agent";
    public static readonly string ROUTINE_NAME_PREFIX = "cs-routines";
    private static readonly  int PAGE_SIZE = 3;
    public RoutinesTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task TestRoutinesCRUD()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectsAgentVersion agentVersion = await GetHostedAgent(projectClient);
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
        string routineName = $"{ROUTINE_NAME_PREFIX}-0";
        ProjectsRoutine created = await projectClient.Routines.CreateOrUpdateRoutineAsync(
            routineName: routineName,
            triggers: triggers,
            action: action,
            description: "Routine created by unit test.",
            enabled: true);
        Assert.That(created.Name, Is.EqualTo(routineName));
        Assert.That(created.Enabled, Is.True);

        ProjectsRoutine disabled = await projectClient.Routines.DisableRoutineAsync(routineName);
        Assert.That(disabled.Name, Is.EqualTo(routineName));
        Assert.That(disabled.Enabled, Is.False);

        ProjectsRoutine fetched = await projectClient.Routines.GetRoutineAsync(routineName);
        Assert.That(fetched.Name, Is.EqualTo(routineName));
        Assert.That(fetched.Enabled, Is.False);

        ProjectsRoutine enabled = await projectClient.Routines.EnableRoutineAsync(routineName);
        Assert.That(enabled.Name, Is.EqualTo(routineName));
        Assert.That(enabled.Enabled, Is.True);

        List<string> routineNames = await projectClient.Routines.GetRoutinesAsync().Where(x => string.Equals(x.Name, routineName)).Select(x => x.Name).ToListAsync();
        Assert.That(routineNames, Has.Count.EqualTo(1));
        Assert.That(routineNames[0], Is.EqualTo(routineName));
        //InvokeAgentResponsesApiDispatchPayload

        DispatchRoutineResponse response = await projectClient.Routines.DispatchAsyncRoutineAsync(routineName, new InvokeAgentResponsesApiDispatchPayload(BinaryData.FromObjectAsJson("Hello, tell me a joke")));
        Assert.That(response.DispatchId, Is.Not.Null);
        Assert.That(response.TaskId, Is.Not.Null);
        Assert.That(response.ActionCorrelationId, Is.Not.Null);

        await projectClient.Routines.DeleteRoutineAsync(routineName);
        List<ProjectsRoutine> routines = await projectClient.Routines.GetRoutinesAsync().Where(x => string.Equals(x.Name, routineName)).ToListAsync();
        Assert.That(routines, Has.Count.EqualTo(0));
    }

    [RecordedTest]
    public async Task TestRoutinePagination()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectsAgentVersion agentVersion = await GetHostedAgent(projectClient);
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
        for (int i=0; i< PAGE_SIZE + 1; i++)
        {
            await projectClient.Routines.CreateOrUpdateRoutineAsync(
                routineName: $"{ROUTINE_NAME_PREFIX}-{i}",
                triggers: triggers,
                action: action,
                description: "Routine created by unit test.",
                enabled: false);
        }
        List<ProjectsRoutine> records = await projectClient.Routines.GetRoutinesAsync(limit: PAGE_SIZE, order: "asc").Where(x => x.Name.StartsWith(ROUTINE_NAME_PREFIX)).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(PAGE_SIZE + 1));
        // Go forward.
        List<ProjectsRoutine> forward = await projectClient.Routines.GetRoutinesAsync(order: "asc", after: records[0].Name, limit: PAGE_SIZE).Where(x => x.Name.StartsWith(ROUTINE_NAME_PREFIX)).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Name, Is.EqualTo(records[1].Name));
        Assert.That(forward[forward.Count - 1].Name, Is.EqualTo(records[records.Count - 1].Name));
        //// Two limits:
        // Pagination via before is not supported.
        forward = await projectClient.Routines.GetRoutinesAsync(order: "asc", after: records[0].Name, before: records[3].Name, limit: PAGE_SIZE).Where(x => x.Name.StartsWith(ROUTINE_NAME_PREFIX)).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].Name, Is.EqualTo(records[1].Name));
        Assert.That(forward[1].Name, Is.EqualTo(records[2].Name));
        // Go backwards.
        List<ProjectsRoutine> backwards = await projectClient.Routines.GetRoutinesAsync(order: "desc", after: records[3].Name, limit: PAGE_SIZE).Where(x => x.Name.StartsWith(ROUTINE_NAME_PREFIX)).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].Name, Is.EqualTo(records[records.Count - 2].Name));
        Assert.That(backwards[backwards.Count - 1].Name, Is.EqualTo(records[0].Name));
        //// Two limits.
        // Pagination via before is not supported.
        backwards = await projectClient.Routines.GetRoutinesAsync(order: "desc", after: records[records.Count - 1].Name, before: records[records.Count - 4].Name, limit: PAGE_SIZE).Where(x => x.Name.StartsWith(ROUTINE_NAME_PREFIX)).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].Name, Is.EqualTo(records[records.Count - 2].Name));
        Assert.That(backwards[1].Name, Is.EqualTo(records[records.Count - 3].Name));
    }

    [TestCase(true)]
    [TestCase(false)]
    [RecordedTest]
    public async Task TestRoutineE2E(bool isScheduledTask)
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectsAgentVersion agentVersion = await GetHostedAgent(projectClient);
        RoutineTrigger trigger;
        if (isScheduledTask)
        {
            trigger = new ScheduleRoutineTrigger(
                cronExpression: "*/5 * * * *",
                timeZone: "UTC"
            );
        }
        else
        {
            trigger = new TimerRoutineTrigger()
            {
                At = DateTime.Now + new TimeSpan(hours: 0, minutes: 0, seconds: 20),
            };
        }
        IDictionary<string, RoutineTrigger> triggers = new Dictionary<string, RoutineTrigger>
        {
            ["test"] = trigger
        };
        RoutineAction action = new InvokeAgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
            Input = BinaryData.FromObjectAsJson("Hello, Tell me a joke."),
        };
        string routineName = $"{ROUTINE_NAME_PREFIX}-0";
        ProjectsRoutine created = await projectClient.Routines.CreateOrUpdateRoutineAsync(
            routineName: routineName,
            triggers: triggers,
            action: action,
            description: "Routine created by unit test.",
            enabled: true);
        int minutesWait = 10;
        DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 10, seconds: 0);
        RoutineRun completedRun = null;
        while (DateTime.UtcNow < deadline)
        {
            await Delay(60000);
            await foreach (RoutineRun run in projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name))
            {
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
        Assert.That(completedRun, Is.Not.Null, $"The run did not completed within {minutesWait} minutes.");
        Assert.That(completedRun.Status.ToLower(), Is.Not.EqualTo("killed"), "The run was forcefully stopped.");
        Assert.That(completedRun.Status.ToLower(), Is.Not.EqualTo("failed"), $"The run has failed with the error. Type: {completedRun.ErrorType} Message: {completedRun.ErrorMessage}.");
        Assert.That(completedRun.Status.ToLower(), Is.EqualTo("finished"));
        Assert.That(completedRun.ResponseId, Is.Not.Null);
    }

    [RecordedTest]
    public async Task TestRoutineRunPagination()
    {
        AIProjectClient projectClient = GetTestProjectClient();
        ProjectsAgentVersion agentVersion = await GetHostedAgent(projectClient);
        RoutineTrigger trigger= new ScheduleRoutineTrigger(
            cronExpression: "*/5 * * * *",
            timeZone: "UTC"
        );
        RoutineAction action = new InvokeAgentResponsesApiRoutineAction
        {
            AgentName = agentVersion.Name,
            Input = BinaryData.FromObjectAsJson("Hello, Tell me a joke."),
        };
        string routineName = $"{ROUTINE_NAME_PREFIX}-0";
        ProjectsRoutine created = await projectClient.Routines.CreateOrUpdateRoutineAsync(
            routineName: routineName,
            triggers: new Dictionary<string, RoutineTrigger> { { "test", trigger} },
            action: action,
            description: "Routine created by unit test.",
            enabled: true);
        int minutesWait = 20;
        DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: minutesWait, seconds: 0);
        List<RoutineRun> runs = [];
        while (DateTime.UtcNow < deadline)
        {
            await Delay(60000);
            runs = await projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name).ToListAsync();
            if (runs.Count > PAGE_SIZE)
            {
                // When we have generated enough run, disable the routine and check pahgination.
                await projectClient.Routines.DisableRoutineAsync(routineName: created.Name);
                // Make sure, we have all the runs after the routine was disabled.
                runs = await projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name).ToListAsync();
                break;
            }
        }
        Assert.That(runs, Has.Count.GreaterThan(PAGE_SIZE));
        // We cannot know, how many runs we have generated, so we set the new baseline here.
        int runsGenerated = runs.Count;
        List<RoutineRun> records = await projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name, limit: PAGE_SIZE, order: "asc").ToListAsync();
        Assert.That(records.Count, Is.EqualTo(PAGE_SIZE + 1));
        // Go forward.
        List<RoutineRun> forward = await projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name, order: "asc", after: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[forward.Count - 1].Id, Is.EqualTo(records[records.Count - 1].Id));
        //// Two limits:
        // Pagination via before is not supported.
        forward = await projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name, order: "asc", after: records[0].Id, before: records[3].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[1].Id, Is.EqualTo(records[2].Id));
        // Go backwards.
        List<RoutineRun> backwards = await projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name, order: "desc", after: records[3].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        Assert.That(backwards[backwards.Count - 1].Id, Is.EqualTo(records[0].Id));
        //// Two limits.
        // Pagination via before is not supported.
        backwards = await projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name, order: "desc", after: records[records.Count - 1].Id, before: records[records.Count - 4].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        Assert.That(backwards[1].Id, Is.EqualTo(records[records.Count - 3].Id));
    }

    private static long toMillis(DateTimeOffset? date)
    {
        long? millis = date?.ToUnixTimeSeconds();
        Assert.That(millis.HasValue, Is.True);
        //Assert.That(DateTimeOffset.FromUnixTimeSeconds(millis ?? 0), Is.EqualTo(date));
        return millis.Value;
    }

    #region Helpers
    public async Task<ProjectsAgentVersion> GetHostedAgent(AIProjectClient projectClient, string suffix="1")
    {
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            ContainerConfiguration = new(TestEnvironment.AGENT_DOCKER_IMAGE)
        };
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        return await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: $"{HOSTED_AGENT_PREFIX}-{suffix}",
            options: creationOptions);
    }
    #endregion
    #region Cleanup
    [TearDown]
    public async virtual Task Cleanup()
    {
        if (Mode == RecordedTestMode.Playback)
            return;
        Uri connectionString = new(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        AIProjectClient projectClient = new(connectionString, GetTestTokenProvider());
        // Remove Routnes
        List<string> routines = await projectClient.Routines.GetRoutinesAsync().Where(x => x.Name.StartsWith(ROUTINE_NAME_PREFIX)).Select(x => x.Name).ToListAsync();
        foreach (string routineName in routines)
        {
            await projectClient.Routines.DeleteRoutineAsync(routineName);
        }
        // Remove Agents.
        List<string> hostedAgents = await projectClient.AgentAdministrationClient.GetAgentsAsync().Select((x) => x.Name).Where((x) => x.StartsWith(HOSTED_AGENT_PREFIX)).ToListAsync();
        foreach (string hostedAgent in hostedAgents)
        {
            try
            {
                projectClient.AgentAdministrationClient.DeleteAgent(hostedAgent, force: true);
            }
            catch { }
        }
    }
    #endregion
}
