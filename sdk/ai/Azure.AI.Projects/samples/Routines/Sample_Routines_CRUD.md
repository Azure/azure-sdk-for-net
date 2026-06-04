# Sample for Routines CRUD (create, retrieve, enable, disable, list, delete) in Azure.AI.Projects

This sample demonstrates how to perform CRUD operations on Routines using the `AIProjectClient`. It creates a routine bound to a hosted agent, retrieves it, toggles its enabled state via `DisableRoutine` / `EnableRoutine`, lists routines, and finally deletes it. A `CustomRoutineTrigger` is used to keep the sample self-contained (no GitHub or schedule resources required).

## Hosted agent deployment
`Azure.AI.Projects` can be used only to create an `ProjectsAgentVersion` object, however hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create Azure Container registry in the same resource group and region as Microsoft Foundry project. Find the docker login at Settings>Access keys section at the left panel of created container registry in the Azure portal. Check the box "Admin user" to generate the password for the default user account marked as `<DOCKER_USERNAME>` below.
2. Assign the `AcrPull` role to the project's Managed Identity for the Azure Container Registry.
3. Assign the `Azure AI User` role to the project's Managed Identity for resource group (This operation only may be performed by the group owner).
4. Copy the contents of a [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py) to the file main.py
5. At the same directory create the file called `requirements.txt` with the next content:

```
azure-ai-agentserver-core
azure-ai-agentserver-invocations
azure-ai-agentserver-responses
openai
```

6. Create a file `Dockerfile`, which instructs docker to copy the contents of the current directory, install the requirements and run `main.py`, which will start the service:

```
FROM python:3.12-slim

WORKDIR /app

COPY . user_agent/
WORKDIR /app/user_agent

RUN if [ -f requirements.txt ]; then \
        pip install -r requirements.txt; \
    else \
        echo "No requirements.txt found"; \
    fi

EXPOSE 8088

CMD ["python", "main.py"]
```

5. Build the docker image and push it to the Azure Container registry you have created.

```bash
docker build -t <DOCKER_USERNAME>/workflow-agent .
docker image tag <DOCKER_USERNAME>/workflow-agent:latest <DOCKER_USERNAME>.azurecr.io/<DOCKER_USERNAME>/workflow-agent:latest
docker login <DOCKER_USERNAME>.azurecr.io
docker push <DOCKER_USERNAME>.azurecr.io/<DOCKER_USERNAME>/workflow-agent:latest
```

## Run a sample.

1. First, create the client and read the environment variables that will be used in the following steps.

```C# Snippet:Sample_CreateClient_RoutinesCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
AIProjectClientOptions options = new();
options.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
AIProjectRoutines routinesClient = projectClient.Routines;
string routineName = "sample-routine";
```

2. For brevity we will create the method, returning the `HostedAgentDefinition` object.

```C# Snippet:Sample_HostedAgentDefinition_RoutinesCRUD
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
```

3. Create a new Hosted Agent.

Synchronous sample:
```C# Snippet:Sample_CreateHostedAgent_RoutinesCRUD_Sync
HostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage
);
ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
creationOptions.Metadata["enableVnextExperience"] = "true";
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myHostedForRoutines",
    options: creationOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateHostedAgent_RoutinesCRUD_Async
HostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage
);
ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
creationOptions.Metadata["enableVnextExperience"] = "true";
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myHostedForRoutines",
    options: creationOptions);
```

4. Create a routine with a custom trigger and an agent invocation action.

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

5. Disable the routine.

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

6. Retrieve the routine to verify its state.

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

7. Re-enable the routine.

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

8. List all routines.

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

9. Finally, delete the routine and Agent.

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
