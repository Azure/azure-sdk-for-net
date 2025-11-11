# Sample of using Azure Container App with Agent in Azure.AI.Projects.OpenAI.

In this example we will demonstrate how to use [Azure Container App](https://learn.microsoft.com/azure/container-apps/ai-integration) in Azure.AI.Projects.OpenAI

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_Create_client_ContainerApp
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var containerAppResourceId = System.Environment.GetEnvironmentVariable("CONTAINER_APP_RESOURCE_ID");
var ingressSubdomainSuffix = System.Environment.GetEnvironmentVariable("INGRESS_SUBDOMAIN_SUFFIX");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Create the `ContainerAppAgentDefinition` object, holding information about the Azure Container App and use it to create the versioned agent object.

Synchronous sample:
```C# Snippet:Sample_CreateContainerApp_ContainerApp_Sync
AgentVersion containerAgentVersion = client.CreateAgentVersion(
    agentName: "containerAgent",
    options: new(new ContainerAppAgentDefinition(
        containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
        containerAppResourceId: containerAppResourceId,
        ingressSubdomainSuffix: ingressSubdomainSuffix)));
```

Asynchronous sample:
```C# Snippet:Sample_CreateContainerApp_ContainerApp_Async
AgentVersion containerAgentVersion = await client.CreateAgentVersionAsync(
    agentName: "containerAgent",
    options: new(new ContainerAppAgentDefinition(
        containerProtocolVersions: [new ProtocolVersionRecord(protocol: AgentCommunicationMethod.Responses, version: "1")],
        containerAppResourceId: containerAppResourceId,
        ingressSubdomainSuffix: ingressSubdomainSuffix)));
```

4. Create an `AgentConversation` conversation object, containing the first question.

Synchronous sample:
```C# Snippet:Sample_CreateConversation_ContainerApp_Sync
OpenAIClient openAIClient = client.GetOpenAIClient();
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
ConversationClient conversationClient = client.GetConversationClient();
AgentConversationCreationOptions conversationOptions = new();
conversationOptions.Items.Add(
    ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
);
AgentConversation conversation = conversationClient.CreateConversation(options: conversationOptions);
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversation_ContainerApp_Async
OpenAIClient openAIClient = client.GetOpenAIClient();
OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);
ConversationClient conversationClient = client.GetConversationClient();
AgentConversationCreationOptions conversationOptions = new();
conversationOptions.Items.Add(
    ResponseItem.CreateUserMessageItem("What is the size of France in square miles?")
);
AgentConversation conversation = await conversationClient.CreateConversationAsync(options: conversationOptions);
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
AgentReference agentReference = new(name: containerAgentVersion.Name)
{
    Version = containerAgentVersion.Version,
};

OpenAIResponse response = responseClient.CreateResponse(
    agentRef: agentReference,
    conversation: conversation
);
response = WaitResponse(responseClient, response);
Console.WriteLine(response.GetOutputText());

conversationClient.CreateConversationItems(
    conversationId: conversation.Id,
    items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
response = responseClient.CreateResponse(
    agentRef: agentReference,
    conversation: conversation
);
response = WaitResponse(responseClient, response);
Console.WriteLine(response.GetOutputText());
```

Asynchronous sample:
```C# Snippet:Sample_CommunicateWithTheAgent_ContainerApp_Async
AgentReference agentReference = new(name: containerAgentVersion.Name)
{
    Version = containerAgentVersion.Version,
};

OpenAIResponse response = await responseClient.CreateResponseAsync(
    agentRef: agentReference,
    conversation: conversation
);
response = await WaitResponseAsync(responseClient, response);
Console.WriteLine(response.GetOutputText());

await conversationClient.CreateConversationItemsAsync(
    conversationId: conversation.Id,
    items: [ResponseItem.CreateUserMessageItem("And what is the capital city?")]);
response = await responseClient.CreateResponseAsync(
    agentRef: agentReference,
    conversation: conversation
);
response = await WaitResponseAsync(responseClient, response);
Console.WriteLine(response.GetOutputText());
```

7. Clean up resources by deleting conversations and agent.

Synchronous sample:
```C# Snippet:Sample_Cleanup_ContainerApp_Sync
conversationClient.DeleteConversation(conversationId: conversation.Id);
client.DeleteAgentVersion(agentName: containerAgentVersion.Name, agentVersion: containerAgentVersion.Version);
```

Asynchronous sample:
```C# Snippet:Sample_Cleanup_ContainerApp_Async
await conversationClient.DeleteConversationAsync(conversationId:conversation.Id);
await client.DeleteAgentVersionAsync(agentName: containerAgentVersion.Name, agentVersion: containerAgentVersion.Version);
```
