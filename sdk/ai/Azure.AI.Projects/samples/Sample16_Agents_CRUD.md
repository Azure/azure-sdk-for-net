# Sample for Create, Read, Update and Delete (CRUD) agent in Azure.AI.Agents.V2.

In this example we will demonstrate creation and basic use of an agent step by step.

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClientCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create two versioned agent objects.

Synchronous sample:
```C# Snippet:Sample_CreateAgentVersionCRUD_Sync
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion1 = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
AgentVersion agentVersion2 = projectClient.Agents.CreateAgentVersion(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateAgentVersionCRUD_Async
PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
{
    Instructions = "You are a prompt agent."
};
AgentVersion agentVersion1 = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent1",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion1.Id}, name: {agentVersion1.Name}, version: {agentVersion1.Version})");
AgentVersion agentVersion2 = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "myAgent2",
    options: new(agentDefinition));
Console.WriteLine($"Agent created (id: {agentVersion2.Id}, name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

3. Retrieve the agent object and list its labels.

Synchronous sample:
```C# Snippet:Sample_GetAgentCRUD_Sync
AgentRecord result = projectClient.Agents.GetAgent(agentVersion1.Name);
Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
```

Asynchronous sample:
```C# Snippet:Sample_GetAgentCRUD_Async
AgentRecord result = await projectClient.Agents.GetAgentAsync(agentVersion1.Name);
Console.WriteLine($"Agent created (id: {result.Id}, name: {result.Name})");
```

4. List all agents.

Synchronous sample:
```C# Snippet:Sample_ListAgentsCRUD_Sync
foreach (AgentRecord agent in projectClient.Agents.GetAgents())
{
    Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListAgentsCRUD_Async
await foreach (AgentRecord agent in projectClient.Agents.GetAgentsAsync())
{
    Console.WriteLine($"Listed Agent: id: {agent.Id}, name: {agent.Name}");
}
```

5. Finally, remove the agents we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteAgentCRUD_Sync
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
projectClient.Agents.DeleteAgentVersion(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteAgentCRUD_Async
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion1.Name, agentVersion: agentVersion1.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion1.Name}, version: {agentVersion1.Version})");
await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion2.Name, agentVersion: agentVersion2.Version);
Console.WriteLine($"Agent deleted (name: {agentVersion2.Name}, version: {agentVersion2.Version})");
```
