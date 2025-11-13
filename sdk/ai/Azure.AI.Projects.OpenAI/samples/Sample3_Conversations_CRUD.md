# Sample for Create, Read, Update and Delete (CRUD) conversations in Azure.AI.Projects.OpenAI.

In this example we will demonstrate creation and basic use of an `ConversationResource` objects step by step.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ConversationCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create a `ConversationClient`, which will be used to create two `AgentConversation` objects.

Synchronous sample:
```C# Snippet:Sample_CreateConversations_ConversationCRUD_Sync
AgentConversation conversation1 = projectClient.OpenAI.Conversations.CreateAgentConversation();
Console.WriteLine($"Created conversation (id: {conversation1.Id})");

AgentConversation conversation2 = projectClient.OpenAI.Conversations.CreateAgentConversation();
Console.WriteLine($"Created conversation (id: {conversation2.Id})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversations_ConversationCRUD_Async
AgentConversation conversation1 = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();
Console.WriteLine($"Created conversation (id: {conversation1.Id})");

AgentConversation conversation2 = await projectClient.OpenAI.Conversations.CreateAgentConversationAsync();
Console.WriteLine($"Created conversation (id: {conversation2.Id})");
```

3. Retrieve the `AgentConversation` object.

Synchronous sample:
```C# Snippet:Sample_GetConversation_ConversationCRUD_Sync
AgentConversation conversation = projectClient.OpenAI.Conversations.GetAgentConversation(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

Asynchronous sample:
```C# Snippet:Sample_GetConversation_ConversationCRUD_Async
AgentConversation conversation = await projectClient.OpenAI.Conversations.GetAgentConversationAsync(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

4. List all `AgentConversation` objects.

Synchronous sample:
```C# Snippet:Sample_ListConversations_ConversationCRUD_Sync
foreach (AgentConversation res in projectClient.OpenAI.Conversations.GetAgentConversations())
{
    Console.WriteLine($"Listed conversation (id: {res.Id})");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListConversations_ConversationCRUD_Async
await foreach (AgentConversation res in projectClient.OpenAI.Conversations.GetAgentConversationsAsync()){
    Console.WriteLine($"Listed conversation (id: {res.Id})");
}
```

5. Update the `AgentConversation` object metadata and retrieve it again.

Synchronous sample:
```C# Snippet:Sample_UpdateConversations_ConversationCRUD_Sync
ProjectConversationUpdateOptions updateOptions = new()
{
    Metadata = { ["key"] = "value" },
};
projectClient.OpenAI.Conversations.UpdateAgentConversation(conversation1.Id, updateOptions);

// Get the updated conversation.
conversation = projectClient.OpenAI.Conversations.GetAgentConversation(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

Asynchronous sample:
```C# Snippet:Sample_UpdateConversations_ConversationCRUD_Async
ProjectConversationUpdateOptions updateOptions = new()
{
    Metadata = { ["key"] = "value" },
};
await projectClient.OpenAI.Conversations.UpdateAgentConversationAsync(conversation.Id, updateOptions);

// Get the updated conversation.
conversation = await projectClient.OpenAI.Conversations.GetAgentConversationAsync(conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

6. Finally, remove `AgentConversation` objects we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteConversations_ConversationCRUD_Sync
projectClient.OpenAI.Conversations.DeleteConversation(conversationId: conversation1.Id);
projectClient.OpenAI.Conversations.DeleteConversation(conversationId: conversation2.Id);
```

Asynchronous sample:
```C# Snippet:Sample_DeleteConversations_ConversationCRUD_Async
await projectClient.OpenAI.Conversations.DeleteConversationAsync(conversationId: conversation1.Id);
await projectClient.OpenAI.Conversations.DeleteConversationAsync(conversationId: conversation2.Id);
```
