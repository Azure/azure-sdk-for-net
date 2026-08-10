# Sample on using reminder tool with Hosted Agent in Azure.AI.Extensions.OpenAI.

## Hosted Code Agent Deployment prerequisites

`Azure.AI.Projects` can be used only to create a `ProjectsAgentVersion` object; however, the hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create a folder containing agent code and dependencies. In our example, it should be located in the `Assets/AgentsCodeReminder` folder next to the sample itself (this folder is not provided).
2. Create a project and add dependencies.

```bash
dotnet new console --name ToolboxAgent --output ToolboxAgent
dotnet add package Azure.AI.Projects --prerelease
dotnet add package Microsoft.Agents.AI.Foundry --prerelease
dotnet add package Microsoft.Agents.AI.Foundry.Hosting --prerelease
```

2. Populate the code in Program.cs

```C#
using Azure.AI.Projects;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Foundry.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.AI;

// Read in the environment variables
string TOOLBOX_NAME = System.Environment.GetEnvironmentVariable(nameof(TOOLBOX_NAME)) ?? throw new InvalidOperationException($"Missing environment variable {nameof(TOOLBOX_NAME)}");
string FOUNDRY_PROJECT_ENDPOINT = System.Environment.GetEnvironmentVariable(nameof(FOUNDRY_PROJECT_ENDPOINT)) ?? throw new InvalidOperationException($"Missing environment variable {nameof(FOUNDRY_PROJECT_ENDPOINT)}");
string FOUNDRY_MODEL_NAME = System.Environment.GetEnvironmentVariable(nameof(FOUNDRY_MODEL_NAME)) ?? throw new InvalidOperationException($"Missing environment variable {nameof(FOUNDRY_MODEL_NAME)}");
string AGENT_NAME = System.Environment.GetEnvironmentVariable(nameof(AGENT_NAME)) ?? throw new InvalidOperationException($"Missing environment variable {nameof(AGENT_NAME)}");
//

DefaultAzureCredential credential = new();
AIAgent agent = new AIProjectClient(endpoint: new(FOUNDRY_PROJECT_ENDPOINT), credential)
    .AsAIAgent(new ChatClientAgentOptions()
    {
        ChatOptions = new ChatOptions()
        {
            ModelId = FOUNDRY_MODEL_NAME,
            Instructions = "You are a helpful assistant that can schedule reminders. " +
                           "When a user asks to set, create, schedule, or remind them about something after " +
                           "some number of minutes, call the `schedule_reminder` tool with the best integer " +
                           "`minutes` value you can extract from the request. After the tool call succeeds, " +
                           "briefly confirm that the reminder was scheduled and include the created reminder name if the tool returned one." +
                           "Do not pretend a reminder was created if the tool call failed. Keep your answers brief.",
        },
        Name = AGENT_NAME,
        Description = "Agent with the Toolbox.",
    });
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddFoundryResponses(agent);
builder.Services.AddFoundryToolboxes(credential, TOOLBOX_NAME);
var app = builder.Build();
app.MapFoundryResponses();
app.Run();
```

3. Compile the application.

```bash
dotnet publish
```

This will create the publish output in the `bin\Release\net%version%\publish\` folder, where `%version%` is the .NET version used to build the application.
4. Copy the contents of `publish` folder to `Assets/AgentsCodeReminder`.


## Run the sample.

1. Read the environment variables, which will be used in the next steps; use these variables to initialize `AIProjectClient` and create `AgentToolboxes`.

```C# Snippet:Sample_CreateAgentClient_CodeAgentReminderTool
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
```

2. For brevity we will create the method, returning the `AgentVersionFromCodeMetadata` object. It contains all environment variables needed to access toolbox from the Hosted Agent.
**Note:** In this example we are uploading the project. It is also possible to place source codes and a C# project file to the `Assets/AgentsCodeReminder` folder. In this case we will need to set `dependencyResolution: CodeDependencyResolution.RemoteBuild`.

```C# Snippet:Sample_CodeAgentReminderToolMetadata_CodeAgentReminderTool
private static AgentVersionFromCodeMetadata GetAgentMetadata(string middlewareAgentName, string toolboxName, string foundryProjectEndpoint, string modelDeploymentName)
{
    HostedAgentDefinition agentDefinition = new(
        cpu: "0.5",
        memory: "1Gi"
    )
    {
        Versions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "2.0.0") },
        CodeConfiguration = new(
            runtime: "dotnet_10",
            entryPoint: ["dotnet", "ToolboxAgent.dll"],
            dependencyResolution: CodeDependencyResolution.Bundled
        ),
        EnvironmentVariables = {
            { "AGENT_NAME", middlewareAgentName},
            { "TOOLBOX_NAME", toolboxName},
            { "FOUNDRY_PROJECT_ENDPOINT", foundryProjectEndpoint},
            { "FOUNDRY_MODEL_NAME", modelDeploymentName },
            { "ASPNETCORE_URLS", "http://+:8088"},
        }
    };
    AgentVersionFromCodeMetadata metadata = new(agentDefinition);
    metadata.Metadata["enableVnextExperience"] = "true";
    return metadata;
}
```

3. In this example we will use files which should be in the `Assets/AgentsCodeToolbox` folder next to the sample source code. To get the file location we will use the `GetDirectory` method.

```C# Snippet:Sample_GetPath_CodeAgentReminderTool
protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine([dirName, path]);
}
```

4. Create a `ToolboxVersion` object with `ReminderPreviewToolboxTool`.

Synchronous sample:
```C# Snippet:Sample_CreateToolbox_CodeAgentReminderTool_Sync
ToolboxVersion toolBox = toolboxClient.CreateVersion(
    name: "toolboxWithTheReminder",
    tools: [new ReminderPreviewToolboxTool()],
    description: "The toolbox with a reminder tool."
);
Console.WriteLine($"Created a toolbox {toolBox.Name} v. {toolBox.Version}.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateToolbox_CodeAgentReminderTool_Async
ToolboxVersion toolBox = await toolboxClient.CreateVersionAsync(
    name: "toolboxWithTheReminder",
    tools: [new ReminderPreviewToolboxTool()],
    description: "The toolbox with a reminder tool."
);
Console.WriteLine($"Created a toolbox {toolBox.Name} v. {toolBox.Version}.");
```


5. Create the hosted agent object from code.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_CodeAgentReminderTool_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersionFromCode(
    agentName: "myCodeAgentReminderTool",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCodeReminder"])),
    metadata: GetAgentMetadata(
        middlewareAgentName: "codeAgentMiddleware1",
        toolboxName: toolBox.Name,
        foundryProjectEndpoint: projectEndpoint,
        modelDeploymentName: modelDeploymentName
    )
);
Console.WriteLine($"Created Agent {agentVersion.Name}, v. {agentVersion.Version}.");
Console.WriteLine($"The Agent's identity ID is {agentVersion.InstanceIdentity.ClientId}. Please use it to set \"Foundry User\" permission if needed.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_CodeAgentReminderTool_Async
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
    agentName: "myCodeAgentReminderTool",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCodeReminder"])),
    metadata: GetAgentMetadata(
        middlewareAgentName: "codeAgentMiddleware1",
        toolboxName: toolBox.Name,
        foundryProjectEndpoint: projectEndpoint,
        modelDeploymentName: modelDeploymentName
    )
);
Console.WriteLine($"Created Agent {agentVersion.Name}, v. {agentVersion.Version}.");
Console.WriteLine($"The Agent's identity ID is {agentVersion.InstanceIdentity.ClientId}. Please use it to set \"Foundry User\" permission if needed.");
```

6. Wait for the Agent to reach the active state; throw error if the deployment fails.

Synchronous sample:
```C# Snippet:Sample_WaitForDeployment_CodeAgentReminderTool_Sync
while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
{
    Thread.Sleep(500);
    agentVersion = projectClient.AgentAdministrationClient.GetAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
}
if (agentVersion.Status != AgentVersionStatus.Active)
{
    throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForDeployment_CodeAgentReminderTool_Async
while (agentVersion.Status != AgentVersionStatus.Active && agentVersion.Status != AgentVersionStatus.Failed)
{
    await Task.Delay(500);
    agentVersion = await projectClient.AgentAdministrationClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
}
if (agentVersion.Status != AgentVersionStatus.Active)
{
    throw new InvalidOperationException($"The Agent deployment failed, status: {agentVersion.Status}");
}
```

7. Create a session and wait for it to arrive to active state.

Synchronous sample:
```C# Snippet:Sample_WaitForSession_CodeAgentReminderTool_Sync
string prompt = "Please remind me to go to lunch after one minute.";
DateTimeOffset responseTime;
ProjectAgentSession session = projectClient.AgentAdministrationClient.CreateSession(agentName: agentVersion.Name, versionIndicator: new VersionRefIndicator(agentVersion.Version));
while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
{
    Thread.Sleep(500);
    session = projectClient.AgentAdministrationClient.GetSession(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
}
if (session.Status != AgentSessionStatus.Active)
{
    throw new InvalidOperationException($"The session creation reached a non-successful status {session.Status}.");
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForSession_CodeAgentReminderTool_Async
string prompt = "Please remind me to go to lunch after one minute.";
DateTimeOffset responseTime;
ProjectAgentSession session = await projectClient.AgentAdministrationClient.CreateSessionAsync(agentName: agentVersion.Name, versionIndicator: new VersionRefIndicator(agentVersion.Version));
while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
{
    await Task.Delay(500);
    session = await projectClient.AgentAdministrationClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
}
if (session.Status != AgentSessionStatus.Active)
{
    throw new InvalidOperationException($"The session creation reached a non-successful status {session.Status}.");
}
```

8. Create the response client to communicate with an Agent and get the response and list the response items.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_CodeAgentReminderTool_Sync
Console.WriteLine($"Sending prompt {prompt} in session {session.AgentSessionId}...");
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem(prompt) },
    SessionId = session.AgentSessionId,
};
ResponseResult response = responseClient.CreateResponse(responseOptions);
if (response.Error != null)
{
    throw new InvalidOperationException($"Unable to get the response from an Agent. Error Code: {response.Error.Code}; {response.Error.Message}");
}
Console.WriteLine("Response items:");
foreach (ResponseItem item in response.OutputItems)
{
    if (item is FunctionCallOutputResponseItem functionResponse)
    {
        Console.WriteLine($"    Function output {functionResponse.FunctionOutput}");
    }
    else if (item is FunctionCallResponseItem functionCall)
    {
        Console.WriteLine($"    Calling function {functionCall.FunctionName} with arguments {functionCall.FunctionArguments}");
    }
}
Console.WriteLine(response.GetOutputText());
responseTime = response.CreatedAt;
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_CodeAgentReminderTool_Async
Console.WriteLine($"Sending prompt {prompt} in session {session.AgentSessionId}...");
ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
CreateResponseOptions responseOptions = new()
{
    InputItems = { ResponseItem.CreateUserMessageItem(prompt) },
    SessionId = session.AgentSessionId,
};
ResponseResult response = await responseClient.CreateResponseAsync(responseOptions);
if (response.Error != null)
{
    throw new InvalidOperationException($"Unable to get the response from an Agent. Error Code: {response.Error.Code}; {response.Error.Message}");
}
Console.WriteLine("Response items:");
foreach (ResponseItem item in response.OutputItems)
{
    if (item is FunctionCallOutputResponseItem functionResponse)
    {
        Console.WriteLine($"    Function output {functionResponse.FunctionOutput}");
    }
    else if (item is FunctionCallResponseItem functionCall)
    {
        Console.WriteLine($"    Calling function {functionCall.FunctionName} with arguments {functionCall.FunctionArguments}");
    }
}
Console.WriteLine(response.GetOutputText());
responseTime = response.CreatedAt;
```

9. In this example the reminder tool will create a routine. Generally, it will be named as `reminder-mycodeagentremindertool-1784584974173`, however, the naming scheme may be changed. In this example, we will take a routine, which was created within one minute after the response.

Synchronous sample:
```C# Snippet:Sample_GetCreatedTrigger_CodeAgentReminderTool_Sync
Console.WriteLine("Wait for a half of a second and inspect the routines.");
Thread.Sleep(500);
ProjectsRoutine created = null;
foreach (ProjectsRoutine routine in projectClient.Routines.GetRoutines(order: MemoryStoreListOrder.Descending, limit: 1))
{
    // The routine created no earlier than response and not later than one minute after response.
    if (routine.CreatedAt >= responseTime && routine.CreatedAt < responseTime.AddMinutes(1))
    {
        created = routine;
        break;
    }
    // If the latest routine was created before the response, our routine was not created.
    else if (routine.CreatedAt < responseTime)
    {
        break;
    }
}
if (created == null)
{
    throw new InvalidOperationException($"The routine was not created.");
}
Console.WriteLine($"The last created routine is {created.Name}, assuming it was created by ReminderPreviewToolboxTool.");
```

Asynchronous sample:
```C# Snippet:Sample_GetCreatedTrigger_CodeAgentReminderTool_Async
Console.WriteLine("Wait for a half of a second and inspect the routines.");
await Task.Delay(500);
ProjectsRoutine created = null;
await foreach (ProjectsRoutine routine in projectClient.Routines.GetRoutinesAsync(order: MemoryStoreListOrder.Descending, limit: 1))
{
    // The routine created no earlier than response and not later than one minute after response.
    if (routine.CreatedAt >= responseTime && routine.CreatedAt < responseTime.AddMinutes(1))
    {
        created = routine;
        break;
    }
    // If the latest routine was created before the response, our routine was not created.
    else if (routine.CreatedAt < responseTime)
    {
        break;
    }
}
if (created == null)
{
    throw new InvalidOperationException($"The routine was not created.");
}
Console.WriteLine($"The last created routine is {created.Name}, assuming it was created by ReminderPreviewToolboxTool.");
```

10. Create the `CheckRunResult` method, handling routine run errors.

```C# Snippet:Sample_CheckRunResult_CodeAgentReminderTool
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

11. Wait for the routine run to complete.

Synchronous sample:
```C# Snippet:Sample_WaitForRoutine_CodeAgentReminderTool_Sync
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
```C# Snippet:Sample_WaitForRoutine_CodeAgentReminderTool_Async
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

12. Output the routine run status.

Synchronous sample:
```C# Snippet:Sample_OutputStatus_CodeAgentReminderTool_Sync
Console.WriteLine($"The run has completed with status {completedRun.Status}, response ID is {completedRun.ResponseId}");
// Currently the response retrieval is not supported.
// ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
// ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
// if (result.Error is not null)
// {
//     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
// }
// Console.WriteLine($"Response: {result.GetOutputText()}");
```

Asynchronous sample:
```C# Snippet:Sample_OutputStatus_CodeAgentReminderTool_Async
Console.WriteLine($"The run has completed with status {completedRun.Status}, response ID is {completedRun.ResponseId}");
// Currently the response retrieval is not supported.
// ProjectResponsesClient oaiClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
// ResponseResult result = await oaiClient.GetResponseAsync(new GetResponseOptions(responseId: completedRun.ResponseId));
// if (result.Error is not null)
// {
//     throw new InvalidOperationException($"The response, triggered by routine resulted in error. Code: {result.Error.Code}, Message: {result.Error.Message}");
// }
// Console.WriteLine($"Response: {result.GetOutputText()}");
```

13. Delete toolbox and Agent we have created.

Synchronous sample:
```C# Snippet:DeleteCodeAgentReminderTool_CodeAgentReminderTool_Sync
toolboxClient.Delete(toolBox.Name);
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
```

Asynchronous sample:
```C# Snippet:DeleteCodeAgentReminderTool_CodeAgentReminderTool_Async
await toolboxClient.DeleteAsync(toolBox.Name);
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
```
