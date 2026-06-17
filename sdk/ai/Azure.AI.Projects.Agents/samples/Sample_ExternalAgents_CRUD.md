# Sample for Agent Administration with External Agents (creation, retrieval and deletion) in Azure.AI.Projects.Agents

In this example we will demonstrate management of External Agents step by step. External Agents are the third-party Agents hosted outside Foundry (for example, on GCP or AWS). Registration is metadata-only: Foundry records the agent definition to light up observability experiences (traces, evaluations) over customer-emitted OpenTelemetry data.

To use external Agents, we need to provide the `Foundry-Features` header in our REST requests. It can be done using `PipelinePolicy`.

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

1. First, we need to create agent client and read the environment variables, which will be used in the next steps. We also will add the experimental `Foundry-Features: ExternalAgents=V1Preview` header policy to the client.
**Note:** If the `AgentAdministrationClient` client was created using `AgentAdministrationClient` property of `AIProjectClient`, the `Foundry-Features` will already contain all the experimental features and no additional actions will be needed.

```C# Snippet:Sample_CreateClient_ExternalAgentsCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
AgentAdministrationClientOptions options = new();
options.AddPolicy(new FeaturePolicy("ExternalAgents=V1Preview"), PipelinePosition.PerCall);
AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
```

2. Use the client to create the Agent version object.

Synchronous sample:
```C# Snippet:Sample_CreateAgentVersion_ExternalAgentsCRUD_Sync
ExternalAgentDefinition agentDefinition = new()
{
    OtelAgentId = "sample-external-agent",
};
ProjectsAgentVersionCreationOptions agentOptions = new(agentDefinition)
{
    Description = "External agent registered by the azure-ai-projects sample.",
    Metadata = {
        { "sample", "external_agents_crud" },
        { "status", "created" }
    }
};
ProjectsAgentVersion agentVersion = agentsClient.CreateAgentVersion(
    agentName: "myExternalAgent1",
    options: agentOptions);
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentVersion_ExternalAgentsCRUD_Async
ExternalAgentDefinition agentDefinition = new()
{
    OtelAgentId = "sample-external-agent",
};
ProjectsAgentVersionCreationOptions agentOptions = new(agentDefinition)
{
    Description = "External agent registered by the azure-ai-projects sample.",
    Metadata = {
        { "sample", "external_agents_crud" },
        { "status", "created" }
    }
};
ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(
    agentName: "myExternalAgent1",
    options: agentOptions);
Console.WriteLine($"Agent created (id: {agentVersion.Id}, name: {agentVersion.Name}, version: {agentVersion.Version})");
```

3. Retrieve the Agent object.

Synchronous sample:
```C# Snippet:Sample_Get_ExternalAgentsCRUD_Sync
ProjectsAgentRecord result = agentsClient.GetAgent(agentVersion.Name);
Console.WriteLine($"Agent retrieved (id: {result.Id}, name: {result.Name}, latest version: {result.Versions.Latest})");
```

Asynchronous sample:
```C# Snippet:Sample_Get_ExternalAgentsCRUD_Async
ProjectsAgentRecord result = await agentsClient.GetAgentAsync(agentVersion.Name);
Console.WriteLine($"Agent retrieved (id: {result.Id}, name: {result.Name}, latest version: {result.Versions.Latest})");
```

4. List versions of the Agent.

Synchronous sample:
```C# Snippet:Sample_ListAgentVersions_ExternalAgentsCRUD_Sync
Console.WriteLine($"Versions for agent {agentVersion.Name}");
foreach (ProjectsAgentVersion oneAgentVersion in agentsClient.GetAgentVersions(agentVersion.Name))
{
    Console.WriteLine($"    - Agent id: {oneAgentVersion.Id}, version: {oneAgentVersion.Version}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListAgentVersions_ExternalAgentsCRUD_Async
Console.WriteLine($"Versions for agent {agentVersion.Name}");
await foreach (ProjectsAgentVersion oneAgentVersion in agentsClient.GetAgentVersionsAsync(agentVersion.Name))
{
    Console.WriteLine($"    - Agent id: {oneAgentVersion.Id}, version: {oneAgentVersion.Version}");
}
```

5. List all external Agents.

Synchronous sample:
```C# Snippet:Sample_ListAgents_ExternalAgentsCRUD_Sync
Console.WriteLine("Found the next Agents.");
foreach (ProjectsAgentRecord agent in agentsClient.GetAgents(kind: ProjectsAgentKind.External))
{
    Console.WriteLine($"    - Agent id: {agent.Id}, name: {agent.Name}, latest version: {agent.Versions.Latest.Version}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListAgents_ExternalAgentsCRUD_Async
Console.WriteLine("Found the next Agents.");
await foreach (ProjectsAgentRecord agent in agentsClient.GetAgentsAsync(kind: ProjectsAgentKind.External))
{
    Console.WriteLine($"    - Agent id: {agent.Id}, name: {agent.Name}, latest version: {agent.Versions.Latest.Version}");
}
```

6. Finally, remove the Agents we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteAgent_ExternalAgentsCRUD_Sync
agentsClient.DeleteAgent(agentName: agentVersion.Name);
Console.WriteLine($"Agent deleted (name: {agentVersion.Name})");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteAgent_ExternalAgentsCRUD_Async
await agentsClient.DeleteAgentAsync(agentName: agentVersion.Name);
Console.WriteLine($"Agent deleted (name: {agentVersion.Name})");
```
