# Sample showing how to work with sessionsin Azure.AI.Projects.Agents

## Prerequisites

This sample require the deployedf Hosted agent. Please follow the [instructions](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/ai/Azure.AI.Extensions.OpenAI/samples/Sample28_HostedAgent.md) for Agent deployment.

1. First, we need to create `AgentAdministrationClient`, and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateClient_SessionsCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var hostedAgentName = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_NAME");
var hostedAgentVersion = System.Environment.GetEnvironmentVariable("HOSTED_AGENT_VERSION");
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Get the Agent, for which we will create sessions in the next step.

Synchronous sample:
```C# Snippet:Sample_CreateAgent_SessionsCRUD_Sync
ProjectsAgentVersion agentVersion = agentsClient.GetAgentVersion(
    agentName: hostedAgentName,
    agentVersion: hostedAgentVersion);
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgent_SessionsCRUD_Async
ProjectsAgentVersion agentVersion = await agentsClient.GetAgentVersionAsync(
    agentName: hostedAgentName,
    agentVersion: hostedAgentVersion);
```

3. Create two sessions for the same agent version. Each of the sessions will have its own key. We will need to wait while the sessions are being created.

Synchronous sample:
```C# Snippet:Sample_CreateSessions_SessionsCRUD_Sync
string sessionId1 = Guid.NewGuid().ToString();
string sessionId2 = Guid.NewGuid().ToString();
ProjectAgentSession session1 = agentsClient.CreateSession(
    agentName: agentVersion.Name,
    agentSessionId: sessionId1,
    versionIndicator: new VersionRefIndicator(agentVersion.Version)
);
Console.WriteLine($"Created session with ID {session1.AgentSessionId}");
ProjectAgentSession session2 = agentsClient.CreateSession(
    agentName: agentVersion.Name,
    agentSessionId: sessionId2,
    versionIndicator: new VersionRefIndicator(agentVersion.Version)
);
Console.WriteLine($"Created session with ID {session2.AgentSessionId}");

while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    session1 = agentsClient.GetSession(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
}
while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
{
    Thread.Sleep(TimeSpan.FromMilliseconds(500));
    session2 = agentsClient.GetSession(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
}
```

Asynchronous sample:
```C# Snippet:Sample_CreateSessions_SessionsCRUD_Async
string sessionId1 = Guid.NewGuid().ToString();
string sessionId2 = Guid.NewGuid().ToString();
ProjectAgentSession session1 = await agentsClient.CreateSessionAsync(
    agentName: agentVersion.Name,
    agentSessionId: sessionId1,
    versionIndicator: new VersionRefIndicator(agentVersion.Version)
);
Console.WriteLine($"Created session with ID {session1.AgentSessionId}");
ProjectAgentSession session2 = await agentsClient.CreateSessionAsync(
    agentName: agentVersion.Name,
    agentSessionId: sessionId2,
    versionIndicator: new VersionRefIndicator(agentVersion.Version)
);
Console.WriteLine($"Created session with ID {session2.AgentSessionId}");
while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    session1 = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
}
while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
{
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    session2 = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
}
```

4. Get one session by ID.

Synchronous sample:
```C# Snippet:Sample_Get_SessionsCRUD_Sync
ProjectAgentSession session = agentsClient.GetSession(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
Console.WriteLine($"Retrieved session with ID {session.AgentSessionId}");
```

Asynchronous sample:
```C# Snippet:Sample_Get_SessionsCRUD_Async
ProjectAgentSession session = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
Console.WriteLine($"Retrieved session with ID {session.AgentSessionId}");
```

5. List all sessions, we have created for the Agent.

Synchronous sample:
```C# Snippet:Sample_List_SessionsCRUD_Sync
List<ProjectAgentSession> sessions = [..agentsClient.GetSessions(agentName: agentVersion.Name)];
Console.WriteLine($"Found {sessions.Count} sessions.");
foreach (ProjectAgentSession item in sessions)
{
    Console.WriteLine($"    - Id: {item.AgentSessionId}, last accessed: {item.LastAccessedAt}.");
}
```

Asynchronous sample:
```C# Snippet:Sample_List_SessionsCRUD_Async
List<ProjectAgentSession> sessions = await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).ToListAsync();
Console.WriteLine($"Found {sessions.Count} sessions.");
foreach (ProjectAgentSession item in sessions)
{
    Console.WriteLine($"    - Id: {item.AgentSessionId}, last accessed: {item.LastAccessedAt}.");
}
```

6. Delete sessions and we have created.

Synchronous sample:
```C# Snippet:Sample_Delete_SessionsCRUD_Sync
agentsClient.DeleteSession(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
agentsClient.DeleteSession(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
```

Asynchronous sample:
```C# Snippet:Sample_Delete_SessionsCRUD_Async
await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
```
