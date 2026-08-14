# Sample for Agent Administration (creation, retrieval, update, deletion) in Azure.AI.Projects

In this example we will demonstrate creation and basic use of an agent step by step.

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClientCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create two versioned agent objects.

Synchronous sample:
```C# Snippet:Sample_CreateAgentVersionCRUD_Sync
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion1 = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
ProjectsAgentVersion agentVersion2 = projectClient.AgentAdministrationClient.CreateAgentVersion(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentVersionCRUD_Async
DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
ProjectsAgentVersion agentVersion1 = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
ProjectsAgentVersion agentVersion2 = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

3. Retrieve the agent object and list its labels.

Synchronous sample:
```C# Snippet:Sample_GetAgentCRUD_Sync
ProjectsAgentRecord result = projectClient.AgentAdministrationClient.GetAgent(agentVersion1.Name);
Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
```

Asynchronous sample:
```C# Snippet:Sample_GetAgentCRUD_Async
ProjectsAgentRecord result = await projectClient.AgentAdministrationClient.GetAgentAsync(agentVersion1.Name);
Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
```

4. List all agents.

Synchronous sample:
```C# Snippet:Sample_ListAgentsCRUD_Sync
foreach (ProjectsAgentRecord agent in projectClient.AgentAdministrationClient.GetAgents())
{
    Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListAgentsCRUD_Async
await foreach (ProjectsAgentRecord agent in projectClient.AgentAdministrationClient.GetAgentsAsync())
{
    Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
}
```

5. Finally, remove the agents we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteAgentCRUD_Sync
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteAgentCRUD_Async
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```
