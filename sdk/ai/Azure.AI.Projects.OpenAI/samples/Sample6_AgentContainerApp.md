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

4. Create an `AgentConversation` conversation object, containing the first question.

Synchronous sample:
```C# Snippet:Sample_CreateConversation_ContainerApp_Sync
ProjectConversationCreationOptions conversationOptions = new();
conversationOptions.Items.Add(
    ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
);
AgentConversation conversation = projectClient.OpenAI.Conversations.CreateAgentConversation(options: conversationOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversation_ContainerApp_Async
ProjectConversationCreationOptions conversationOptions = new();
conversationOptions.Items.Add(
    ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
);
AgentConversation conversation = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync(conversationOptions);
```

5. Create synchronous and asynchronous helper methods to wait for response completion. If the response status is not `Completed` we will thow the exception with the latest error.

Synchronous sample:
```C# Snippet:Sample_WaitForRun_ContainerApp_Sync
private static OpenAIResponse WaitResponse(OpenAIResponseClient responseClient, OpenAIResponse response)
{
    while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(500));
        response = responseClient.GetResponse(responseId: response.Id);
    }
    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    return response;
}
```

Asynchronous sample:
```C# Snippet:Sample_WaitForRun_ContainerApp_Async
private static async Task<OpenAIResponse> WaitResponseAsync(OpenAIResponseClient responseClient, OpenAIResponse response)
{
    while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
    {
        await Task.Delay(TimeSpan.FromMilliseconds(500));
        response = await responseClient.GetResponseAsync(responseId: response.Id);
    }
    Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
    return response;
}
```

6. Create a response for the first question; add another question to conversation and wait again.

Synchronous sample:
```C# Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Sync
ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(containerAgentVersion, conversation);
OpenAIResponse response = responseClient.CreateResponse([]);
response = WaitResponse(projectClient.OpenAI.Responses, response);
Console.WriteLine(response.GetOutputText());

projectClient.OpenAI.Conversations.CreateAgentConversationItems(
    conversationId: conversation.Id,
    items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
response = projectClient.OpenAI.Responses.CreateResponse([]);
response = WaitResponse(projectClient.OpenAI.Responses, response);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Async
ResponseCreationOptions responseOptions = new()
{
    Agent = containerAgentVersion,
    AgentConversationId = conversation.Id,
};
OpenAIResponse response = await projectClient.OpenAI.Responses.CreateResponseAsync([], responseOptions);
response = await WaitResponseAsync(projectClient.OpenAI.Responses, response);
Console.WriteLine(response.GetOutputText());

await projectClient.OpenAI.Conversations.CreateAgentConversationItemsAsync(
    conversationId: conversation.Id,
    items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
response = await projectClient.OpenAI.Responses.CreateResponseAsync([], responseOptions);
response = await WaitResponseAsync(projectClient.OpenAI.Responses, response);
Console.WriteLine(response.GetOutputText());
```

7. Clean up resources by deleting conversations and Agent.

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
