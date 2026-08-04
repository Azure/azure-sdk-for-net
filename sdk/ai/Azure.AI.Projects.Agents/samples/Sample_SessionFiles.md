# Sample showing how to work with session files in Azure.AI.Projects.Agents

## Prerequisites

This sample require the deployedf Hosted agent. Please follow the [instructions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/samples/Sample28_HostedAgent.md) for Agent deployment.

## Sample

1. First, we need to create clients to operate sessions and Agents; read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClient_SessionFiles
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Get the Agent, create a session and `AgentSessionFiles` client. We will need to wait while the sessions are being created.

Synchronous sample:
```C# Snippet:Sample_CreateAgentAndSession_SessionFiles_Sync
ProjectsAgentVersion agentVersion = agentsClient.GetAgentVersion(
    agentName: hostedAgentName,
    agentVersion: hostedAgentVersion);
string sessionId = Guid.NewGuid().ToString();
ProjectAgentSession session = agentsClient.CreateSession(
    agentName: agentVersion.Name,
    agentSessionId: sessionId,
    versionIndicator: new VersionRefIndicator(agentVersion.Version)
);
AgentSessionFiles sessionClient = agentsClient.GetAgentSessionFiles(agentVersion.Name, session.AgentSessionId);
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
string sessionId = Guid.NewGuid().ToString("N");
ProjectAgentSession session = await agentsClient.CreateSessionAsync(
    agentName: agentVersion.Name,
    agentSessionId: sessionId,
    versionIndicator: new VersionRefIndicator(agentVersion.Version)
);
AgentSessionFiles sessionClient = agentsClient.GetAgentSessionFiles(agentVersion.Name, session.AgentSessionId);
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

SessionFileWriteResponse writeResponse = sessionClient.Upload(
    sessionStoragePath: filePath,
    localPath: filePath
);
Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
File.Delete(filePath);
filePath = "sample_file_for_upload2.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'grape' uses the code 111222, while the word 'mango' uses the code 222111.");
writeResponse = sessionClient.Upload(
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
SessionFileWriteResponse writeResponse = await sessionClient.UploadAsync(
        sessionStoragePath: filePath,
        localPath: filePath
    );
Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
File.Delete(filePath);
filePath = "sample_file_for_upload2.txt";
File.WriteAllText(
    path: filePath,
    contents: "The word 'grape' uses the code 111222, while the word 'mango' uses the code 222111.");
writeResponse = await sessionClient.UploadAsync(
    sessionStoragePath: $"{filePath}",
    localPath: filePath
);
Console.WriteLine($"The file was written to path {writeResponse.Path}, file length is {writeResponse.BytesWritten}.");
File.Delete(filePath);
```

4. List the files inside the session sandbox.

Synchronous sample:
```C# Snippet:Sample_List_SessionFiles_Sync
CollectionResult<SessionDirectoryEntry> response = sessionClient.GetAll(sessionStoragePath: ".");
Console.WriteLine($"The path contains the next files:");
foreach (SessionDirectoryEntry entry in response)
{
    Console.WriteLine($"    - {entry.Name}, size {entry.SizeInBytes}");
}
```

Asynchronous sample:
```C# Snippet:Sample_List_SessionFiles_Async
AsyncCollectionResult<SessionDirectoryEntry> response = sessionClient.GetAllAsync(sessionStoragePath: ".");
Console.WriteLine($"The path contains the next files:");
await foreach (SessionDirectoryEntry entry in response)
{
    Console.WriteLine($"    - {entry.Name}, size {entry.SizeInBytes}");
}
```

5. Download the file and display its contents.

Synchronous sample:
```C# Snippet:Sample_Download_SessionFiles_Sync
filePath = "saved.txt";
sessionClient.Download(
    sessionStoragePath: "sample_file_for_upload1.txt",
    localPath: filePath
);
Console.WriteLine($"Download file contents: {File.ReadAllText(filePath)}");
File.Delete(filePath);
```

Asynchronous sample:
```C# Snippet:Sample_Download_SessionFiles_Async
filePath = "saved.txt";
await sessionClient.DownloadAsync(
    sessionStoragePath: "sample_file_for_upload1.txt",
    localPath: filePath
);
Console.WriteLine($"Download file contents: {File.ReadAllText(filePath)}");
File.Delete(filePath);
```

6. Delete the files from the session sandbox and the session.

Synchronous sample:
```C# Snippet:Sample_DeleteFiles_SessionFiles_Sync
sessionClient.Delete(localPath: "sample_file_for_upload1.txt");
sessionClient.Delete(localPath: "sample_file_for_upload2.txt");
agentsClient.DeleteSession(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteFiles_SessionFiles_Async
await sessionClient.DeleteAsync(localPath: "sample_file_for_upload1.txt");
await sessionClient.DeleteAsync(localPath: "sample_file_for_upload2.txt");
await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId);
```
