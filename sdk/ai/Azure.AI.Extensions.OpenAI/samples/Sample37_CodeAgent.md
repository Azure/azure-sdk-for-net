# Sample on getting the responses from hosted code Agent in Azure.AI.Extensions.OpenAI.

## Hosted Code Agent Deployment prerequisites

In this example we will use the code from the simple [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py). The service defined in this file just gets the request, adds "Echo: " to it and sends it back using the responses protocol.

## Run the sample
`Azure.AI.Projects` can be used only to create an `ProjectsAgentVersion` object, however hosted object represents the running container, which exposes the OpenAI-compatible API.
1. Create a folder, containing agent code and dependencies. In our example, it should be located `Assets/AgentsCode` folder next to the sample itself (this folder is not provided).
2. Copy the contents of a [sample](https://github.com/Azure/azure-sdk-for-python/blob/main/sdk/agentserver/azure-ai-agentserver-responses/samples/sample_01_getting_started.py) to the file main.py in the `Assets` folder.
3. Create the `requirements.txt` in `Assets` folder with the next contents.

```
azure-ai-agentserver-core
azure-ai-agentserver-invocations
azure-ai-agentserver-responses
```

4. Change directory to `AgentsCode` folder and install all the required python dependencies. **This step is ONLY required if `CodeDependencyResolution.Bundled` dependency resolution is being used.**

```bash
pip install -r requirements.txt --target packages --platform manylinux2014_x86_64 --python-version 3.14 --implementation cp --only-binary=:all:
```

# Run the sample.

1. Read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_CodeAgent
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
AIProjectClient projectClient = new(endpoint: new(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. For brevity we will create the method, returning the `CreateAgentVersionFromCodeMetadata` object.

```C# Snippet:Sample_CodeAgentMetadata_CodeAgent
private static CreateAgentVersionFromCodeMetadata GetAgentMetadata()
{
    HostedAgentDefinition agentDefinition = new(
        cpu: "0.5",
        memory: "1Gi"
    )
    {
        Versions = { new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0") },
        CodeConfiguration = new(
            runtime: "python_3_14",
            entryPoint: ["python", "main.py"],
            dependencyResolution: CodeDependencyResolution.RemoteBuild
        ),
    };
    CreateAgentVersionFromCodeMetadata metadata = new(agentDefinition);
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
    if (e.Status == 424 && e.Message.IndexOf("session_not_ready", StringComparison.OrdinalIgnoreCase) !=-1 && session.Count > 0)
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
