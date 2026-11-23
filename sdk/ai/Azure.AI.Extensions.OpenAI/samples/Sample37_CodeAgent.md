# Sample on getting the responses from hosted code Agent in Azure.AI.Extensions.OpenAI.

## Hosted agent deployment
`Azure.AI.Projects` can be used only to create a `ProjectsAgentVersion` object, however hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create a project and add `Azure.AI.AgentServer.Responses` package as a dependency.

```bash
dotnet new console --name EchoAgent --output EchoAgent
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

2. Populate the code in Program.cs

```C#
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

ResponsesServer.Run<EchoHandler>();

public class EchoHandler : ResponseHandler
{
    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request,
            createText: async ct =>
            {
                var input = await context.GetInputTextAsync(cancellationToken: ct);
                return $"Echo: {input}";
            });
    }
}
```

3. Compile the application.

```bash
dotnet publish
```

This will create the publish output in the `bin\Release\net%version%\publish\` folder, where `%version%` is the .NET version used to build the application.
4. Copy the contents of `publish` folder to `Assets/AgentsCode`.


# Run the sample.

1. Read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_CodeAgent
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. For brevity we will create the method, returning the `AgentVersionFromCodeMetadata` object.
**Note:** In this example we are uploading the project. It is also possible to place source codes and a C# project file to the `Assets/AgentsCode` folder. In this case we will need to set `dependencyResolution: CodeDependencyResolution.RemoteBuild`.

```C# Snippet:Sample_CodeAgentMetadata_CodeAgent
private static AgentVersionFromCodeMetadata GetAgentMetadata()
{
    HostedAgentDefinition agentDefinition = new(
        cpu: "0.5",
        memory: "1Gi"
    )
    {
        Versions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0") },
        CodeConfiguration = new(
            runtime: "dotnet_10",
            entryPoint: ["dotnet", "EchoAgent.dll"],
            dependencyResolution: CodeDependencyResolution.Bundled
        ),
    };
    AgentVersionFromCodeMetadata metadata = new(agentDefinition);
    metadata.Metadata["enableVnextExperience"] = "true";
    return metadata;
}
```

3. In this example we will use files which should be located in the `Assets/AgentsCode` folder next to the sample source code. To get the file location we will use the `GetDirectory` method.

```C# Snippet:Sample_GetPath_CodeAgent
protected static string GetDirectory(string path, [CallerFilePath] string pth = "")
{
    var dirName = Path.GetDirectoryName(pth) ?? "";
    return Path.Combine([dirName, path]);
}
```

4. Create the hosted agent object from code.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_CodeAgent_Sync
ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersionFromCode(
    agentName: "myCodeAgent",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
    metadata: GetAgentMetadata()
);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_CodeAgent_Async
ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionFromCodeAsync(
    agentName: "myCodeAgent",
    filePath: GetDirectory(Path.Combine(["Assets", "AgentsCode"])),
    metadata: GetAgentMetadata()
);
```

5. Wait while Agent will get to the active state; throw error if the deployment fails.

Synchronous sample:
```C# Snippet:Sample_WaitForDeployment_CodeAgent_Sync
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
```C# Snippet:Sample_WaitForDeployment_CodeAgent_Async
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

6. Create the response client to communicate with an Agent and get the response. If hosted agent is not functioning properly, the `session_not_ready` error is raised. In this case we will extract session ID, get the session logs and print the error.

Synchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_CodeAgent_Sync
try
{
    ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
    ResponseResult response = responseClient.CreateResponse("Hello, tell me a joke.");

    Console.WriteLine(response.GetOutputText());
}
catch (ClientResultException e)
{
    MatchCollection session = Regex.Matches(e.Message, "'[^']+'");
    if (e.Status == 424 && e.Message.IndexOf("session_not_ready", StringComparison.OrdinalIgnoreCase) != -1 && session.Count > 0)
    {
        SessionLogEvent logEvent = projectClient.AgentAdministrationClient.GetSessionLogStream(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session[0].Value.Trim('\''));
        Console.WriteLine(logEvent.Data);
    }
    throw;
}
```

Asynchronous sample:
```C# Snippet:Sample_GetResponseFromAgent_CodeAgent_Async
try
{
    ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgentEndpoint(agentVersion.Name);
    ResponseResult response = await responseClient.CreateResponseAsync("Hello, tell me a joke.");

    Console.WriteLine(response.GetOutputText());
}
catch (ClientResultException e)
{
    MatchCollection session = Regex.Matches(e.Message, "'[^']+'");
    if (e.Status == 424 && e.Message.IndexOf("session_not_ready", StringComparison.OrdinalIgnoreCase) != -1 && session.Count > 0)
    {
        SessionLogEvent logEvent = await projectClient.AgentAdministrationClient.GetSessionLogStreamAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: session[0].Value.Trim('\''));
        Console.WriteLine(logEvent.Data);
    }
    throw;
}
```

7. Download the code, used by the Agent.

Synchronous sample:
```C# Snippet:Sample_DownloadCode_CodeAgent_Sync
string downloadPath = Path.GetFullPath("./AgentCode");
projectClient.AgentAdministrationClient.DownloadAgentCode(agentName: agentVersion.Name, path: downloadPath);
Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
```

Asynchronous sample:
```C# Snippet:Sample_DownloadCode_CodeAgent_Async
string downloadPath = Path.GetFullPath("./AgentCode");
await projectClient.AgentAdministrationClient.DownloadAgentCodeAsync(agentName: agentVersion.Name, path: downloadPath);
Console.WriteLine($"The Agent code was downloaded to {downloadPath}");
```

8. Delete the Agent we have created.

Synchronous sample:
```C# Snippet:DeleteCodeAgent_CodeAgent_Sync
projectClient.AgentAdministrationClient.DeleteAgent(agentVersion.Name, force: true);
```

Asynchronous sample:
```C# Snippet:DeleteCodeAgent_CodeAgent_Async
await projectClient.AgentAdministrationClient.DeleteAgentAsync(agentVersion.Name, force: true);
```
