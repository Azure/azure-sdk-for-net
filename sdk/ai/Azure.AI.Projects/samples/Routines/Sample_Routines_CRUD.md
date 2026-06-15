# Sample for Routines CRUD (create, retrieve, enable, disable, list, delete) in Azure.AI.Projects

This sample demonstrates how to perform CRUD operations on Routines using the `AIProjectClient`. It creates a routine bound to a hosted agent, retrieves it, toggles its enabled state via `DisableRoutine` / `EnableRoutine`, lists routines, and finally deletes it. A `CustomRoutineTrigger` is used to keep the sample self-contained (no GitHub or schedule resources required).

## Hosted agent deployment
As a prerequisite to this sample, the hosted Agent needs to be deployed. Please follow the steps in the [Hosted agents sample](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/samples/Sample28_HostedAgent.md) and make sure that the Agent is able to generate responses. In the Microsoft foundry choose the "Build" tab and select "Agents" get the created Agent and select "Details" section and copy the Entra Agnet identity ID. Assign Agent a "Foundry User" RBAC role for Microsoft foundry, containing an Agent (one level above the project). In the Azure portal, select the Foundry and click on "Access control (IAM)" on the left panel and add the role for an Agent.

## Run a sample.

1. First, create the client and read the environment variables that will be used in the following steps.

```C# Snippet:Sample_CreateClient_RoutinesCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
string routineName = "sample-routine";
string agentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AIProjectRoutines routinesClient = projectClient.Routines;
```

2. Get the Hosted Agent.

Synchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesCRUD_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.GetAgent(
    agentName: agentName).Value.GetLatestVersion();
```

Asynchronous sample:
```C# Snippet:Sample_GetHostedAgent_RoutinesCRUD_Async
ProjectsAgentVersion agentVersion = (await projectClient.AgentAdministrationClient.GetAgentAsync(
    agentName: agentName)).Value.GetLatestVersion();
```

3. Create a routine with a custom trigger and an agent invocation action.

Synchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesCRUD_Sync
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
```

Asynchronous sample:
```C# Snippet:Sample_CreateRoutine_RoutinesCRUD_Async
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
```

4. Disable the routine.

Synchronous sample:
```C# Snippet:Sample_DisableRoutine_RoutinesCRUD_Sync
ProjectsRoutine disabled = routinesClient.DisableRoutine(routineName);
Console.WriteLine($"Disabled routine: {disabled.Name} enabled={disabled.Enabled}");
```

Asynchronous sample:
```C# Snippet:Sample_DisableRoutine_RoutinesCRUD_Async
ProjectsRoutine disabled = await routinesClient.DisableRoutineAsync(routineName);
Console.WriteLine($"Disabled routine: {disabled.Name} enabled={disabled.Enabled}");
```

5. Retrieve the routine to verify its state.

Synchronous sample:
```C# Snippet:Sample_GetRoutine_RoutinesCRUD_Sync
ProjectsRoutine fetched = routinesClient.GetRoutine(routineName);
Console.WriteLine($"Retrieved routine: {fetched.Name} enabled={fetched.Enabled} description={fetched.Description}");
```

Asynchronous sample:
```C# Snippet:Sample_GetRoutine_RoutinesCRUD_Async
ProjectsRoutine fetched = await routinesClient.GetRoutineAsync(routineName);
Console.WriteLine($"Retrieved routine: {fetched.Name} enabled={fetched.Enabled} description={fetched.Description}");
```

6. Re-enable the routine.

Synchronous sample:
```C# Snippet:Sample_EnableRoutine_RoutinesCRUD_Sync
ProjectsRoutine enabled = routinesClient.EnableRoutine(routineName);
Console.WriteLine($"Enabled routine: {enabled.Name} enabled={enabled.Enabled}");
```

Asynchronous sample:
```C# Snippet:Sample_EnableRoutine_RoutinesCRUD_Async
ProjectsRoutine enabled = await routinesClient.EnableRoutineAsync(routineName);
Console.WriteLine($"Enabled routine: {enabled.Name} enabled={enabled.Enabled}");
```

7. List all routines.

Synchronous sample:
```C# Snippet:Sample_ListRoutines_RoutinesCRUD_Sync
foreach (ProjectsRoutine routine in routinesClient.GetRoutines())
{
    Console.WriteLine($"  - {routine.Name} enabled={routine.Enabled}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListRoutines_RoutinesCRUD_Async
await foreach (ProjectsRoutine routine in routinesClient.GetRoutinesAsync())
{
    Console.WriteLine($"  - {routine.Name} enabled={routine.Enabled}");
}
```

8. Finally, delete the routine and Agent.

Synchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesCRUD_Sync
routinesClient.DeleteRoutine(routineName);
Console.WriteLine("Routine deleted");
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesCRUD_Async
await routinesClient.DeleteRoutineAsync(routineName);
Console.WriteLine("Routine deleted");
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name);
```
