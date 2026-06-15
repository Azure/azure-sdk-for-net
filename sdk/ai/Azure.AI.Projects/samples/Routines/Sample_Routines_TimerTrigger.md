# Sample for Routines with schedule trigger in Azure.AI.Projects

This sample demonstrates how to create a job, which will be launched at specific time on the hosted Agent using Routines. In this scenario Routine will create a single run.

## Hosted agent deployment
As a prerequisite to this sample, the hosted Agent needs to be deployed. Please follow the steps in the [Hosted agents sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/samples/Sample28_HostedAgent.md) and make sure that the Agent is able to generate responses. In the Microsoft foundry choose the "Build" tab and select "Agents" get the created Agent and select "Details" section and copy the Entra Agnet identity ID. Assign Agent a "Foundry User" RBAC role for Microsoft foundry, containing an Agent (one level above the project). In the Azure portal, select the Foundry and click on "Access control (IAM)" on the left panel and add the role for an Agent.

## Run a sample.

1. First, create the client and read the environment variables that will be used in the following steps.

```C# Snippet:Sample_CreateClient_RoutinesTimerTrigger
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string routineName = "sample-routine";
string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AIProjectRoutines routinesClient = projectClient.Routines;
```

2. Get the Hosted Agent.

Synchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesTimerTrigger_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
    agentName: agentName).Value.GetLatestVersion();
```

Asynchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesTimerTrigger_Async
ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
    agentName: agentName)).Value.GetLatestVersion();
```

3. Create a routine with a timer-based trigger and an agent invocation action.

Synchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesTimerTrigger_Sync
IDictionary<string, RoutineTrigger> triggers = new Dictionary<string, RoutineTrigger>
{
    ["once"] = new TimerRoutineTrigger()
    {
        At = DateTime.Now + new TimeSpan(hours: 0, minutes: 0, seconds: 20),
    },
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
    description: "Routine used by the timer-trigger sample.",
    enabled: true);
Console.WriteLine($"Created routine: {created.Name} enabled={created.Enabled}.");
Console.WriteLine($"Fire at: {((TimerRoutineTrigger)triggers["once"]).At.Value.ToString("o")}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesTimerTrigger_Async
IDictionary<string, RoutineTrigger> triggers = new Dictionary<string, RoutineTrigger>
{
    ["once"] = new TimerRoutineTrigger()
    {
        At = DateTime.Now + new TimeSpan(hours: 0, minutes: 0, seconds: 20),
    },
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
    description: "Routine used by the timer-trigger sample.",
    enabled: true);
Console.WriteLine($"Created routine: {created.Name} enabled={created.Enabled}.");
Console.WriteLine($"Fire at: {((TimerRoutineTrigger)triggers["once"]).At.Value.ToString("o")}");
```

4. List the jobs started by the routine and raise an error if job was not completed.

Synchronous sample:
```C# Snippet:Sample_WaitForTask_RoutinesTimerTrigger_Sync
int minutesWait = 10;
Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 10, seconds: 0);
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
```

Asynchronous sample:
```C# Snippet:Sample_WaitForTask_RoutinesTimerTrigger_Async
int minutesWait = 10;
Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 10, seconds: 0);
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
```

5. Retrieve completed job ID.

Synchronous sample:
```C# Snippet:Sample_PrintOutput_RoutinesTimerTrigger_Sync
Console.WriteLine($"The response Id is {completedRun.ResponseId}");
// Note: retrieving the response body produced by a routine-dispatched
// run via `projectClient.GetProjectOpenAIClient().GetProjectResponsesClient().GetResponseAsync(completedRun.responseId)` is
// not yet supported by the service for this scenario.
```

Asynchronous sample:
```C# Snippet:Sample_PrintOutput_RoutinesTimerTrigger_Async
Console.WriteLine($"The response Id is {completedRun.ResponseId}");
// Note: retrieving the response body produced by a routine-dispatched
// run via `projectClient.GetProjectOpenAIClient().GetProjectResponsesClient().GetResponseAsync(completedRun.responseId)` is
// not yet supported by the service for this scenario.
```


6. Finally, delete the routine and Agent.

Synchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesTimerTrigger_Sync
routinesClient.DeleteRoutine(routineName);
Console.WriteLine("Routine deleted");
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesTimerTrigger_Async
await routinesClient.DeleteRoutineAsync(routineName);
Console.WriteLine("Routine deleted");
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
```
