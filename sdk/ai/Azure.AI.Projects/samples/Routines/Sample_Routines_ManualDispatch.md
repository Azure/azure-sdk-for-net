# Sample for Routines manual dispatching in Azure.AI.Projects

This sample demonstrates how to manually create a routine job and to use custom trigger. In this scenario, one run is triggered by a Teams message and another is triggered using manual dispatch.

## Hosted agent deployment
As a prerequisite to this sample, the hosted Agent needs to be deployed. Please follow the steps in the [Hosted agents sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/samples/Sample28_HostedAgent.md) and make sure that the Agent is able to generate responses. In the Microsoft foundry choose the "Build" tab and select "Agents" get the created Agent and select "Details" section and copy the Entra Agent identity ID. Assign Agent a "Foundry User" RBAC role for Microsoft foundry, containing an Agent (one level above the project). In the Azure portal, select the Foundry and click on "Access control (IAM)" on the left panel and add the role for an Agent.

## Run a sample.

1. First, create the client and read the environment variables that will be used in the following steps. To use teams, please create teams channel and get the link to it. The link to a channel will look like https://teams.microsoft.com/l/channel/%TEAMS_CHANNEL_ID%/ChannelName?groupId=%TEAMS_GROUP_ID%&tenantId=%TenantID%.

```C# Snippet:Sample_CreateClient_RoutinesManualDispatch
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string routineName = "sample-routine";
string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
string connectionName = System.Environment.GetEnvironmentVariable("TEAMS_CONNECTION_NAME");
string teamsGroupID = System.Environment.GetEnvironmentVariable("TEAMS_GROUP_ID");
string teamsChannelID = System.Environment.GetEnvironmentVariable("TEAMS_CHANNEL_ID");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AIProjectRoutines routinesClient = projectClient.Routines;
```

2. Get the Hosted Agent.

Synchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesManualDispatch_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
    agentName: agentName).Value.GetLatestVersion();
```

Asynchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesManualDispatch_Async
ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
    agentName: agentName)).Value.GetLatestVersion();
```

3. Create a routine with a custom trigger and an agent invocation action.

Synchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesManualDispatch_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesManualDispatch_Async
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
```

4. For brevity we will create the method, checking the run status and will use it to check if the run has succeeded.

```C# Snippet:Sample_HandleRunError_Routines
protected static void CheckRunResult(RoutineRun completedRun, int minutesWait, bool runCreated)
{
    if (completedRun == null)
    {
        if (runCreated)
        {
            throw new InvalidOperationException($"The run did not complete within {minutesWait} minutes.");
        }
        else
        {
            throw new InvalidOperationException("The run was not created.");
        }
    }
    if (string.Equals(completedRun.Status, "killed", StringComparison.InvariantCultureIgnoreCase))
    {
        throw new InvalidOperationException("The run was forcefully stopped.");
    }
    if (string.Equals(completedRun.Status, "failed", StringComparison.InvariantCultureIgnoreCase))
    {
        throw new InvalidOperationException($"The run has failed with the error. Type: {completedRun.ErrorType} Message: {completedRun.ErrorMessage}.");
    }
}
```

5. Wait for the message in the teams channel and check for the dispatched run.

Synchronous sample:
```C# Snippet:Sample_WaitForTeamsTriggeredTask_RoutinesManualDispatch_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_WaitForTeamsTriggeredTask_RoutinesManualDispatch_Async
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
```

6. Manually dispatch the task.

Synchronous sample:
```C# Snippet:Sample_DispatchTask_RoutinesManualDispatch_Sync
DispatchRoutineResult dispatch = routinesClient.Dispatch(name: created.Name, payload: new AgentResponsesApiDispatchPayload(BinaryData.FromObjectAsJson("Hello, Tell me a joke.")));
Console.WriteLine($"Dispatched the routine. Dispatch ID {dispatch.DispatchId}, task ID: {dispatch.TaskId}.");
```

Asynchronous sample:
```C# Snippet:Sample_DispatchTask_RoutinesManualDispatch_Async
DispatchRoutineResult dispatch = await routinesClient.DispatchAsync(name: created.Name, payload: new AgentResponsesApiDispatchPayload(BinaryData.FromObjectAsJson("Hello, Tell me a joke.")));
Console.WriteLine($"Dispatched the routine. Dispatch ID {dispatch.DispatchId}, task ID: {dispatch.TaskId}.");
```

7. List the jobs started by the routine and raise an error if job was not completed.

Synchronous sample:
```C# Snippet:Sample_WaitForTask_RoutinesManualDispatch_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_WaitForTask_RoutinesManualDispatch_Async
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
```

8. Retrieve completed job ID.

Synchronous sample:
```C# Snippet:Sample_PrintOutput_RoutinesManualDispatch_Sync
Console.WriteLine($"The response Id is {completedRun.ResponseId}");
//  Currently the response retrieval is not supported.
//ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
//ResponseResult result = oaiClient.GetResponse(new GetResponseOptions(responseId: completedRun.ResponseId));
//if (result.Error is not null)
//{
//    throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
//}
//Console.WriteLine($"Response: {result.GetOutputText()}");
```

Asynchronous sample:
```C# Snippet:Sample_PrintOutput_RoutinesManualDispatch_Async
Console.WriteLine($"The response Id is {completedRun.ResponseId}");
//  Currently the response retrieval is not supported.
// ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
// ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
// if (result.Error is not null)
// {
//     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
// }
// Console.WriteLine($"Response: {result.GetOutputText()}");
```


9. Finally, delete the routine.

Synchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesManualDispatch_Sync
routinesClient.Delete(routineName);
Console.WriteLine("Routine deleted");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesManualDispatch_Async
await routinesClient.DeleteAsync(routineName);
Console.WriteLine("Routine deleted");
```
