# Sample for Routines with schedule trigger in Azure.AI.Projects

This sample demonstrates how to create a scheduled job on the hosted Agent using Routines. Routine will schedule a new run every 5 minutes.

## Hosted agent deployment
As a prerequisite to this sample, the hosted Agent needs to be deployed. Please follow the steps in the [Hosted agents sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/samples/Sample28_HostedAgent.md) and make sure that the Agent is able to generate responses. In the Microsoft foundry choose the "Build" tab and select "Agents" get the created Agent and select "Details" section and copy the Entra Agent identity ID. Assign Agent a "Foundry User" RBAC role for Microsoft foundry, containing an Agent (one level above the project). In the Azure portal, select the Foundry and click on "Access control (IAM)" on the left panel and add the role for an Agent.

## Run a sample.

1. First, create the client and read the environment variables that will be used in the following steps.

```C# Snippet:Sample_CreateClient_RoutinesScheduleTrigger
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string routineName = "sample-routine";
string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AIProjectRoutines routinesClient = projectClient.Routines;
```

2. Get the Hosted Agent.

Synchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesScheduleTrigger_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
    agentName: agentName).Value.GetLatestVersion();
```

Asynchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesScheduleTrigger_Async
ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
    agentName: agentName)).Value.GetLatestVersion();
```

3. Create a routine with a scheduled trigger and an agent invocation action.

Synchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesScheduleTrigger_Sync
IDictionary<string, RoutineTrigger> triggers = new Dictionary<string, RoutineTrigger>
{
    ["every_five_minutes"] = new ScheduleRoutineTrigger(
        cronExpression: "*/5 * * * *",
        timeZone: "UTC"
    )
};

RoutineAction action = new InvokeAgentResponsesApiRoutineAction
{
    AgentName = agentVersion.Name,
    Input = BinaryData.FromObjectAsJson("Hello, Tell me a joke."),
};

ProjectsRoutine created = routinesClient.CreateOrUpdateRoutine(
    routineName: routineName,
    triggers: triggers,
    action: action,
    description: "Routine used by the schedule-trigger sample.",
    enabled: true);
Console.WriteLine($"Created routine: {created.Name} enabled={created.Enabled}.");
Console.WriteLine($"cron expression: {((ScheduleRoutineTrigger)triggers["every_five_minutes"]).CronExpression}; time zone: {((ScheduleRoutineTrigger)triggers["every_five_minutes"]).TimeZone}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesScheduleTrigger_Async
IDictionary<string, RoutineTrigger> triggers = new Dictionary<string, RoutineTrigger>
{
    ["every_five_minutes"] = new ScheduleRoutineTrigger(
        cronExpression: "*/5 * * * *",
        timeZone: "UTC"
    )
};

RoutineAction action = new InvokeAgentResponsesApiRoutineAction
{
    AgentName = agentVersion.Name,
    Input = BinaryData.FromObjectAsJson("Hello, Tell me a joke."),
};

ProjectsRoutine created = await routinesClient.CreateOrUpdateRoutineAsync(
    routineName: routineName,
    triggers: triggers,
    action: action,
    description: "Routine used by the schedule-trigger sample.",
    enabled: true);
Console.WriteLine($"Created routine: {created.Name} enabled={created.Enabled}.");
Console.WriteLine($"cron expression: {((ScheduleRoutineTrigger)triggers["every_five_minutes"]).CronExpression}; time zone: {((ScheduleRoutineTrigger)triggers["every_five_minutes"]).TimeZone}");
```

4. List the jobs started by the routine and raise an error if job was not completed.

Synchronous sample:
```C# Snippet:Sample_WaitForTask_RoutinesScheduleTrigger_Sync
int minutesWait = 10;
Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
RoutineRun completedRun = null;
while (DateTime.UtcNow < deadline)
{
    Thread.Sleep(500);
    foreach (RoutineRun run in projectClient.Routines.GetRoutineRuns(routineName: created.Name))
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
```

Asynchronous sample:
```C# Snippet:Sample_WaitForTask_RoutinesScheduleTrigger_Async
int minutesWait = 10;
Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
DateTime deadline = DateTime.UtcNow + TimeSpan.FromMinutes(minutesWait);
RoutineRun completedRun = null;
while (DateTime.UtcNow < deadline)
{
    await Task.Delay(500);
    await foreach (RoutineRun run in projectClient.Routines.GetRoutineRunsAsync(routineName: created.Name))
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
```

5. Retrieve completed job ID.

Synchronous sample:
```C# Snippet:Sample_PrintOutput_RoutinesScheduleTrigger_Sync
Console.WriteLine($"The response Id is {completedRun.ResponseId}");
// Note: retrieving the response body produced by a routine-dispatched
// run via `projectClient.GetProjectOpenAIClient().GetProjectResponsesClient().GetResponseAsync(completedRun.responseId)` is
// not yet supported by the service for this scenario.
```

Asynchronous sample:
```C# Snippet:Sample_PrintOutput_RoutinesScheduleTrigger_Async
Console.WriteLine($"The response Id is {completedRun.ResponseId}");
// Note: retrieving the response body produced by a routine-dispatched
// run via `projectClient.GetProjectOpenAIClient().GetProjectResponsesClient().GetResponseAsync(completedRun.responseId)` is
// not yet supported by the service for this scenario.
```


6. Finally, delete the routine.

Synchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesScheduleTrigger_Sync
routinesClient.DeleteRoutine(routineName);
Console.WriteLine("Routine deleted");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesScheduleTrigger_Async
await routinesClient.DeleteRoutineAsync(routineName);
Console.WriteLine("Routine deleted");
```
