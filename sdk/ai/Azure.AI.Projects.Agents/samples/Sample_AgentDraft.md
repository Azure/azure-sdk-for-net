# Sample for Agent version drafts in Azure.AI.Projects.Agents

Agent version draft may be useful for Agent testing, when it is not yet ready foor release. In this example we will demonstrate creation ov draft Agent versions.

To use Agents version drafts, we need to provide the `Foundry-Features` header in our REST requests. It can be done using `PipelinePolicy`.

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

1. First, we need to create agent client and read the environment variables, which will be used in the next steps. We will also set `DraftAgents=V1Preview` preview header.

```C# Snippet:Sample_CreateAgentClient_AgentsDraft
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AgentAdministrationClientOptions options = new();
options.AddPolicy(new FeaturePolicy("DraftAgents=V1Preview"), PipelinePosition.PerCall);
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new AzureCliCredential());
```

2. Use the client to create versioned agent object.

Synchronous sample:
```C# Snippet:Sample_CreateAgentVersion_AgentsDraft_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent, which always give wrong responses."
};
ProjectsAgentVersion agentVersion1 = agentsClient.CreateAgentVersion(
    agentName: "myAgentWithDraft",
    options: new(agentDefinition));
Console.WriteLine($"Agent created: name: {agentVersion1.Name}, version: {agentVersion1.Version}");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentVersion_AgentsDraft_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent, which always give wrong responses."
};
ProjectsAgentVersion agentVersion1 = await agentsClient.CreateAgentVersionAsync(
    agentName: "myAgentWithDraft",
    options: new(agentDefinition));
Console.WriteLine($"Agent created: name: {agentVersion1.Name}, version: {agentVersion1.Version}");
```

3. Retrieve the agent object and display the latest version.

Synchronous sample:
```C# Snippet:Sample_GetDefaultVersion_AgentsDraft_Sync
ProjectsAgentRecord agent = agentsClient.GetAgent(agentName: agentVersion1.Name);
Console.WriteLine($"The latest version of agent \"{agent.Name}\" is {agent.Versions.Latest}.");
```

Asynchronous sample:
```C# Snippet:Sample_GetDefaultVersion_AgentsDraft_Async
ProjectsAgentRecord agent = await agentsClient.GetAgentAsync(agentName: agentVersion1.Name);
Console.WriteLine($"The latest version of agent \"{agent.Name}\" is {agent.Versions.Latest}.");
```

4. Create another another Agent version and again, retrieve the Agent and get the latest version.

Synchronous sample:
```C# Snippet:Sample_CreateAnotherAgentVersion_AgentsDraft_Sync
agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent which frequently give wrong responses."
};
ProjectsAgentVersion agentVersion2 = agentsClient.CreateAgentVersion(
    agentName: agent.Name,
    options: new(agentDefinition));
Console.WriteLine($"Agent created name: {agentVersion2.Name}, version: {agentVersion2.Version}");
agent = agentsClient.GetAgent(agentName: agentVersion1.Name);
Console.WriteLine($"The latest version of agent \"{agent.Name}\" is now {agent.Versions.Latest}.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAnotherAgentVersion_AgentsDraft_Async
agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent which frequently give wrong responses."
};
ProjectsAgentVersion agentVersion2 = await agentsClient.CreateAgentVersionAsync(
    agentName: agent.Name,
    options: new(agentDefinition));
Console.WriteLine($"Agent created name: {agentVersion2.Name}, version: {agentVersion2.Version}");
agent = await agentsClient.GetAgentAsync(agentName: agentVersion1.Name);
Console.WriteLine($"The latest version of agent \"{agent.Name}\" is now {agent.Versions.Latest}.");
```

5. Now create the Agent Draft version and inspect the latest version again. Note, it did not changed now.

Synchronous sample:
```C# Snippet:Sample_CreateDraft_AgentsDraft_Sync
agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent which gives wrong answers with 0.1 probability."
};
ProjectsAgentVersion agentVersionDraft = agentsClient.CreateAgentVersion(
    agentName: agent.Name,
    options: new(agentDefinition)
    {
        Draft = true
    }
);
Console.WriteLine($"Agent created draft name: {agentVersionDraft.Name}, version: {agentVersionDraft.Version}");
agent = agentsClient.GetAgent(agentName: agentVersion1.Name);
Console.WriteLine($"The latest version of agent \"{agent.Name}\" is still {agent.Versions.Latest}.");
```

Asynchronous sample:
```C# Snippet:Sample_CreateDraft_AgentsDraft_Async
agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent which gives wrong answers with 0.1 probability."
};
ProjectsAgentVersion agentVersionDraft = await agentsClient.CreateAgentVersionAsync(
    agentName: agent.Name,
    options: new(agentDefinition)
    {
        Draft = true
    }
);
Console.WriteLine($"Agent created draft name: {agentVersionDraft.Name}, version: {agentVersionDraft.Version}");
agent = await agentsClient.GetAgentAsync(agentName: agentVersion1.Name);
Console.WriteLine($"The latest version of agent \"{agent.Name}\" is still {agent.Versions.Latest}.");
```

6. List agents. The Agent version draft are not listed by default.

Synchronous sample:
```C# Snippet:Sample_ListReleaseAgents_AgentsDraft_Sync
Console.WriteLine($"Here are \"release\" versions of the agent {agent.Name}:");
foreach (ProjectsAgentVersion agentVersion in agentsClient.GetAgentVersions(agentName: agent.Name))
{
    Console.WriteLine($"    {agentVersion.Version}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListReleaseAgents_AgentsDraft_Async
Console.WriteLine($"Here are \"release\" versions of the agent {agent.Name}:");
await foreach (ProjectsAgentVersion agentVersion in agentsClient.GetAgentVersionsAsync(agentName: agent.Name))
{
    Console.WriteLine($"    {agentVersion.Version}");
}
```

7. List all agents, including drafts.

Synchronous sample:
```C# Snippet:Sample_ListReleaseAgentsWithDrafts_AgentsDraft_Sync
Console.WriteLine($"Here are \"release\" versions of the agent {agent.Name}:");
foreach (ProjectsAgentVersion agentVersion in agentsClient.GetAgentVersions(agentName: agent.Name, includeDrafts: true))
{
    Console.WriteLine($"    {agentVersion.Version}, is draft: {agentVersion.Draft ?? false}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListReleaseAgentsWithDrafts_AgentsDraft_Async
Console.WriteLine($"Here are \"release\" versions of the agent {agent.Name}:");
await foreach (ProjectsAgentVersion agentVersion in agentsClient.GetAgentVersionsAsync(agentName: agent.Name, includeDrafts: true))
{
    Console.WriteLine($"    {agentVersion.Version}, is draft: {agentVersion.Draft ?? false}");
}
```

8. Finally, remove the agent we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteAgent_AgentsDraft_Sync
agentsClient.DeleteAgent(agentName: agentVersion1.Name);
Console.WriteLine($"Agent deleted (name: {agentVersion1.Name})");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteAgent_AgentsDraft_Async
await agentsClient.DeleteAgentAsync(agentName: agentVersion1.Name);
Console.WriteLine($"Agent deleted (name: {agentVersion1.Name})");
```
