# Sample for Create, Read, Update and Delete (CRUD) conversations in Azure.AI.Agents.

In this example we will demonstrate creation and basic use of an `ConversationResource` objects step by step.

1. First, we need to create agent client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ConversationCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create a `ConversationClient`, which will be used to create two `AgentConversation` objects.

Synchronous sample:
```C# Snippet:Sample_CreateConversations_ConversationCRUD_Sync
ConversationClient conversationClient = client.GetConversationClient();
AgentConversation conversation1 = conversationClient.CreateConversation();
Console.WriteLine($"Created conversation (id: {conversation1.Id})");

AgentConversation conversation2 = conversationClient.CreateConversation();
Console.WriteLine($"Created conversation (id: {conversation2.Id})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversations_ConversationCRUD_Async
ConversationClient conversationClient = client.GetConversationClient();
AgentConversation conversation1 = await conversationClient.CreateConversationAsync();
Console.WriteLine($"Created conversation (id: {conversation1.Id})");

AgentConversation conversation2 = await conversationClient.CreateConversationAsync();
Console.WriteLine($"Created conversation (id: {conversation2.Id})");
```

3. Retrieve the `AgentConversation` object.

Synchronous sample:
```C# Snippet:Sample_GetConversation_ConversationCRUD_Sync
AgentConversation conversation = conversationClient.GetConversation(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

Asynchronous sample:
```C# Snippet:Sample_GetConversation_ConversationCRUD_Async
AgentConversation conversation = await conversationClient.GetConversationAsync(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

4. List all `AgentConversation` objects.

Synchronous sample:
```C# Snippet:Sample_ListConversations_ConversationCRUD_Sync
foreach (AgentConversation res in conversationClient.GetConversations())
{
    Console.WriteLine($"Listed conversation (id: {res.Id})");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListConversations_ConversationCRUD_Async
await foreach (AgentConversation res in conversationClient.GetConversationsAsync()){
    Console.WriteLine($"Listed conversation (id: {res.Id})");
}
```

5. Update the `AgentConversation` object metadata and retrieve it again.

Synchronous sample:
```C# Snippet:Sample_UpdateConversations_ConversationCRUD_Sync
AgentConversationUpdateOptions updateOptions = new()
{
    Metadata = { ["key"] = "value" },
};
conversationClient.UpdateConversation(conversation1.Id, updateOptions);

// Get the updated conversation.
conversation = conversationClient.GetConversation(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

Asynchronous sample:
```C# Snippet:Sample_UpdateConversations_ConversationCRUD_Async
AgentConversationUpdateOptions updateOptions = new()
{
    Metadata = { ["key"] = "value" },
};
await conversationClient.UpdateConversationAsync(conversation.Id, updateOptions);

// Get the updated conversation.
conversation = await conversationClient.GetConversationAsync(conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

6. Finally, remove `AgentConversation` objects we have created.

Synchronous sample:
```C# Snippet:Sample_DeleteConversations_ConversationCRUD_Sync
conversationClient.DeleteConversation(conversationId: conversation1.Id);
Console.WriteLine($"Conversation deleted(id: {conversation1.Id})");
conversationClient.DeleteConversation(conversationId: conversation2.Id);
Console.WriteLine($"Conversation deleted(id: {conversation2.Id})");
```

Asynchronous sample:
```C# Snippet:Sample_DeleteConversations_ConversationCRUD_Async
await conversationClient.DeleteConversationAsync(conversationId: conversation1.Id);
Console.WriteLine($"Conversation deleted(id: {conversation1.Id})");
await conversationClient.DeleteConversationAsync(conversationId: conversation2.Id);
Console.WriteLine($"Conversation deleted(id: {conversation2.Id})");
```
