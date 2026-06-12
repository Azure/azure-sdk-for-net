# Sample for Routines with schedule trigger in Azure.AI.Projects

This sample demonstrates how to create a scheduled job on the hosted Agent using Routines. Routine will schedule a new run every 5 minutes.

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

```C# Snippet:Sample_CreateClient_RoutinesScheduleTrigger
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var dockerImage = System.Environment.GetEnvironmentVariable("AGENT_DOCKER_IMAGE");
string routineName = "sample-routine";
string agentName = "myHostedForRoutines";
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AIProjectRoutines routinesClient = projectClient.Routines;
```

2. For brevity we will create the method, returning the `HostedAgentDefinition` object.

```C# Snippet:Sample_HostedAgentDefinition_RoutinesScheduleTrigger
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
```C# Snippet:Sample_CreateHostedAgent_RoutinesScheduleTrigger_Sync
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
```C# Snippet:Sample_CreateHostedAgent_RoutinesScheduleTrigger_Async
HostedAgentDefinition agentDefinition = GetAgentDefinition(
    dockerImage: dockerImage
);
ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
creationOptions.Metadata["enableVnextExperience"] = "true";
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myHostedForRoutines",
    options: creationOptions);
```

4. Create a routine with a scheduled trigger and an agent invocation action.

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

5. List the jobs started by the routine and raise an error if job was not completed.

Synchronous sample:
```C# Snippet:Sample_WaitForTask_RoutinesScheduleTrigger_Sync
int minutesWait = 10;
Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 10, seconds: 0);
RoutineRun completedRun = null;
while (DateTime.UtcNow < deadline)
{
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
```C# Snippet:Sample_WaitForTask_RoutinesScheduleTrigger_Async
int minutesWait = 10;
Console.WriteLine($"Waiting for run for {minutesWait} minutes...");
DateTime deadline = DateTime.UtcNow + new TimeSpan(hours: 0, minutes: 10, seconds: 0);
RoutineRun completedRun = null;
while (DateTime.UtcNow < deadline)
{
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

6. Retrieve completed job ID.

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


7. Finally, delete the routine and Agent.

Synchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesScheduleTrigger_Sync
routinesClient.DeleteRoutine(routineName);
Console.WriteLine("Routine deleted");
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteRoutine_RoutinesScheduleTrigger_Async
await routinesClient.DeleteRoutineAsync(routineName);
Console.WriteLine("Routine deleted");
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
```
