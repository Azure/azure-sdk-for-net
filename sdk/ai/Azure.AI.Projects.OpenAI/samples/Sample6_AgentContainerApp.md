# Sample of using Azure Container App with Agent in Azure.AI.Projects.OpenAI.

In this example we will demonstrate how to use [Azure Container App](https://learn.microsoft.com/azure/container-apps/ai-integration) in Azure.AI.Agents

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_Create_client_ContainerApp
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var containerAppResourceId = System.Environment.GetEnvironmentVariable("CONTAINER_APP_RESOURCE_ID");
var ingressSubdomainSuffix = System.Environment.GetEnvironmentVariable("INGRESS_SUBDOMAIN_SUFFIX");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create the `ContainerAppAgentDefinition` object, holding information about the Azure Container App and use it to create the versioned agent object.

Synchronous sample:
```C# Snippet:Sample_CreateContainerApp_ContainerApp_Sync
AgentVersion containerAgentVersion = projectClient.Agents.CreateAgentVersion(
    agentName: "containerAgent",
    options: new(new ContainerApplicationAgentDefinition(
        containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
        containerAppResourceId: containerAppResourceId,
        ingressSubdomainSuffix: ingressSubdomainSuffix)));
```

Asynchronous sample:
```C# Snippet:Sample_CreateContainerApp_ContainerApp_Async
AgentVersion containerAgentVersion = await projectClient.Agents.CreateAgentVersionAsync(
    agentName: "containerAgent",
    options: new(new ContainerApplicationAgentDefinition(
        containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
        containerAppResourceId: containerAppResourceId,
        ingressSubdomainSuffix: ingressSubdomainSuffix)));
```

4. Create an `ProjectConversation` conversation object, containing the first question.

Synchronous sample:
```C# Snippet:Sample_CreateConversation_ContainerApp_Sync
ProjectConversationCreationOptions conversationOptions = new();
conversationOptions.Items.Add(
    ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
);
ProjectConversation conversation = projectClient.OpenAI.Conversations.CreateProjectConversation(options: conversationOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversation_ContainerApp_Async
ProjectConversationCreationOptions conversationOptions = new();
conversationOptions.Items.Add(
    ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
);
ProjectConversation conversation = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync(conversationOptions);
```

5. Create a response for the first question; add another question to conversation and get the next response.

Synchronous sample:
```C# Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(containerAgentVersion, conversation);
ResponseResult response = responseClient.CreateResponse([]);
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());

projectClient.OpenAI.Conversations.CreateProjectConversationItems(
    conversationId: conversation.Id,
    items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
response = projectClient.OpenAI.Responses.CreateResponse([]);
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Async
CreateResponseOptions responseOptions = new()
{
    Agent = containerAgentVersion,
    AgentConversationId = conversation.Id,
};
ResponseResult response = await projectClient.OpenAI.Responses.CreateResponseAsync(responseOptions);
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());

await projectClient.OpenAI.Conversations.CreateProjectConversationItemsAsync(
    conversationId: conversation.Id,
    items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
response = await projectClient.OpenAI.Responses.CreateResponseAsync(responseOptions);
Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
Console.WriteLine(response.GetOutputText());
```

6. Clean up resources by deleting conversations and Agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_ContainerApp_Sync
projectClient.OpenAI.Conversations.DeleteConversation(conversationId: conversation.Id);
projectClient.Agents.DeleteAgentVersion(agentName: containerAgentVersion.Name, agentVersion: containerAgentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_ContainerApp_Async
await projectClient.OpenAI.Conversations.DeleteConversationAsync(conversationId:conversation.Id);
await projectClient.Agents.DeleteAgentVersionAsync(agentName: containerAgentVersion.Name, agentVersion: containerAgentVersion.Version);
```
