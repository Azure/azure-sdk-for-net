# Sample showing how to work with session files in Azure.AI.Projects.Agents

## Prerequisites

This sample require the deployedf Hosted agent. Please follow the [instructions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/samples/Sample28_HostedAgent.md) for Agent deployment.

## Sample

In this example we will create the session for an Agent and will demonstrate how to manage files in session sandbox.
To use sessions, we need to provide the `Foundry-Features` header in our REST requests. It can be done using `PipelinePolicy`.

```C# Snippet:Sample_Agents_ExperimentalHeader
internal class FeaturePolicy(string feature) : PipelinePolicy
{
    private const string _FEATURE_HEADER = "Foundry-Features";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(_FEATURE_HEADER, feature);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
```

We also need to ignore the `AAIP001` warning.

```C#
#pragma warning disable AAIP001
```

1. First, we need to create clients to operate sessions, files and Agents and read the environment variables, which will be used in the next steps. We also will add the experimental `Foundry-Features: HostedAgents=V1Preview` header policy to the client.
**Note:** If the `AgentAdministrationClient` client was created using `AgentAdministrationClient` property of `AIProjectClient`, the `Foundry-Features` will already contain all the experimental features and no additional actions will be needed.

```C# Snippet:Sample_CreateClient_SessionFiles
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
AgentAdministrationClientOptions options = new();
options.AddPolicy(new FeaturePolicy("HostedAgents=V1Preview,AgentEndpoints=V1Preview"), PipelinePosition.PerCall);
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
AgentSessionFiles sessionClient = agentsClient.GetAgentSessionFiles();
```

2. Get the Agent and create a session. We will need to wait while the sessions are being created.

Synchronous sample:
```C# Snippet:Sample_CreateAgentAndSession_SessionFiles_Sync
ProjectsAgentVersion agentVersion = agentsClient.GetAgentVersion(
    agentName: hostedAgentName,
    agentVersion: hostedAgentVersion);
string sessionKey = Guid.NewGuid().ToString();
string sessionId = Guid.NewGuid().ToString();
ProjectAgentSession session = agentsClient.CreateSession(
    agentName: agentVersion.Name,
    agentSessionId: sessionId,
    isolationKey: sessionKey,
    versionIndicator: new VersionRefIndicator(agentVersion.Version)
);
while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    session = agentsClient.GetSession(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
}
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentAndSession_SessionFiles_Async
ProjectsAgentVersion agentVersion = await agentsClient.GetAgentVersionAsync(
    agentName: hostedAgentName,
    agentVersion: hostedAgentVersion);
string sessionKey = Guid.NewGuid().ToString("N");
string sessionId = Guid.NewGuid().ToString("N");
ProjectAgentSession session = await agentsClient.CreateSessionAsync(
    agentName: agentVersion.Name,
    agentSessionId: sessionId,
    isolationKey: sessionKey,
    versionIndicator: new VersionRefIndicator(agentVersion.Version)
);
while (session.Status != AgentSessionStatus.Failed && session.Status != AgentSessionStatus.Active)
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    session = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
}
```

3. Create and upload two files to the session storage.

Synchronous sample:
```C# Snippet:Sample_Upload_SessionFiles_Sync
string filePath = "sample_file_for_upload1.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");

SessionFileWriteResponse writeResponse = sessionClient.UploadSessionFile(
    agentName: agentVersion.Name,
    sessionId: session.AgentSessionId,
    sessionStoragePath: filePath,
    localPath: filePath
);
Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
File.Delete(filePath);
filePath = "sample_file_for_upload2.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'grape' uses the code 111222, while the word 'mango' uses the code 222111.");
writeResponse = sessionClient.UploadSessionFile(
    agentName: agentVersion.Name,
    sessionId: session.AgentSessionId,
    sessionStoragePath: filePath,
    localPath: filePath
);
Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
File.Delete(filePath);
```

Asynchronous sample:
```C# Snippet:Sample_Upload_SessionFiles_Async
string filePath = "sample_file_for_upload1.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'apple' uses the code 442345, while the word 'banana' uses the code 673457.");
SessionFileWriteResponse writeResponse = await sessionClient.UploadSessionFileAsync(
        agentName: agentVersion.Name,
        sessionId: session.AgentSessionId,
        sessionStoragePath: filePath,
        localPath: filePath
    );
Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
File.Delete(filePath);
filePath = "sample_file_for_upload2.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'grape' uses the code 111222, while the word 'mango' uses the code 222111.");
writeResponse = await sessionClient.UploadSessionFileAsync(
    agentName: agentVersion.Name,
    sessionId: session.AgentSessionId,
    sessionStoragePath: $"{filePath}",
    localPath: filePath
);
Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
File.Delete(filePath);
```

4. List the files inside the session sandbox.

Synchronous sample:
```C# Snippet:Sample_List_SessionFiles_Sync
SessionDirectoryListResponse response = sessionClient.GetSessionFiles(agentName: agentVersion.Name, sessionId: session.AgentSessionId, sessionStoragePath: ".");
Console.WriteLine($"The path {response.Path} contains the next files:");
foreach (SessionDirectoryEntry entry in response.Entries)
{
    Console.WriteLine($"    - {entry.Name}, size {entry.Size}");
}
```

Asynchronous sample:
```C# Snippet:Sample_List_SessionFiles_Async
SessionDirectoryListResponse response = await sessionClient.GetSessionFilesAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, sessionStoragePath: ".");
Console.WriteLine($"The path {response.Path} contains the next files:");
foreach (SessionDirectoryEntry entry in response.Entries)
{
    Console.WriteLine($"    - {entry.Name}, size {entry.Size}");
}
```

5. Download the file and display its contents.

Synchronous sample:
```C# Snippet:Sample_Download_SessionFiles_Sync
filePath = "saved.txt";
sessionClient.DownloadSessionFile(
    agentName: agentVersion.Name,
    sessionId: session.AgentSessionId,
    sessionStoragePath: "sample_file_for_upload1.txt",
    localPath: filePath
);
Console.WriteLine($"Download file contents: {File.ReadAllText(filePath)}");
File.Delete(filePath);
```

Asynchronous sample:
```C# Snippet:Sample_Download_SessionFiles_Async
filePath = "saved.txt";
await sessionClient.DownloadSessionFileAsync(
    agentName: agentVersion.Name,
    sessionId: session.AgentSessionId,
    sessionStoragePath: "sample_file_for_upload1.txt",
    localPath: filePath
);
Console.WriteLine($"Download file contents: {File.ReadAllText(filePath)}");
File.Delete(filePath);
```

6. Delete the files from the session sandbox and the session.

Synchronous sample:
```C# Snippet:Sample_DeleteFiles_SessionFiles_Sync
sessionClient.DeleteSessionFile(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: "sample_file_for_upload1.txt");
sessionClient.DeleteSessionFile(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: "sample_file_for_upload2.txt");
agentsClient.DeleteSession(agentName: agentVersion.Name, sessionId: session.AgentSessionId, isolationKey: sessionKey);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteFiles_SessionFiles_Async
await sessionClient.DeleteSessionFileAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: "sample_file_for_upload1.txt");
await sessionClient.DeleteSessionFileAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: "sample_file_for_upload2.txt");
await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, isolationKey: sessionKey);
```
