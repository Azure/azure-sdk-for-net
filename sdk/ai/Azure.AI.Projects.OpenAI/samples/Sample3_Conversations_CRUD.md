# Sample for Create, Read, Update and Delete (CRUD) conversations in Azure.AI.Projects.OpenAI.

In this example we will demonstrate creation and basic use of an `ConversationResource` objects step by step.

1. First, we need to create project client and read the environment variables, which will be used in the next steps.

```C# Snippet:Sample_CreateAgentClient_ConversationCRUD
var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
```

2. Use the client to create a `ConversationClient`, which will be used to create two `ProjectConversation` objects.

Synchronous sample:
```C# Snippet:Sample_CreateConversations_ConversationCRUD_Sync
ProjectConversation conversation1 = projectClient.OpenAI.Conversations.CreateProjectConversation();
Console.WriteLine($"Created conversation (id: {conversation1.Id})");

ProjectConversation conversation2 = projectClient.OpenAI.Conversations.CreateProjectConversation();
Console.WriteLine($"Created conversation (id: {conversation2.Id})");
```

Asynchronous sample:
```C# Snippet:Sample_CreateConversations_ConversationCRUD_Async
ProjectConversation conversation1 = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();
Console.WriteLine($"Created conversation (id: {conversation1.Id})");

ProjectConversation conversation2 = await projectClient.OpenAI.Conversations.CreateProjectConversationAsync();
Console.WriteLine($"Created conversation (id: {conversation2.Id})");
```

3. Retrieve the `ProjectConversation` object.

Synchronous sample:
```C# Snippet:Sample_GetConversation_ConversationCRUD_Sync
ProjectConversation conversation = projectClient.OpenAI.Conversations.GetProjectConversation(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

Asynchronous sample:
```C# Snippet:Sample_GetConversation_ConversationCRUD_Async
ProjectConversation conversation = await projectClient.OpenAI.Conversations.GetProjectConversationAsync(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

4. List all `ProjectConversation` objects.

Synchronous sample:
```C# Snippet:Sample_ListConversations_ConversationCRUD_Sync
foreach (ProjectConversation res in projectClient.OpenAI.Conversations.GetProjectConversations())
{
    Console.WriteLine($"Listed conversation (id: {res.Id})");
}
```

Asynchronous sample:
```C# Snippet:Sample_ListConversations_ConversationCRUD_Async
await foreach (ProjectConversation res in projectClient.OpenAI.Conversations.GetProjectConversationsAsync()){
    Console.WriteLine($"Listed conversation (id: {res.Id})");
}
```

5. Update the `ProjectConversation` object metadata and retrieve it again.

Synchronous sample:
```C# Snippet:Sample_UpdateConversations_ConversationCRUD_Sync
ProjectConversationUpdateOptions updateOptions = new()
{
    Metadata = { ["key"] = "value" },
};
projectClient.OpenAI.Conversations.UpdateProjectConversation(conversation1.Id, updateOptions);

// Get the updated conversation.
conversation = projectClient.OpenAI.Conversations.GetProjectConversation(conversationId: conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

Asynchronous sample:
```C# Snippet:Sample_UpdateConversations_ConversationCRUD_Async
ProjectConversationUpdateOptions updateOptions = new()
{
    Metadata = { ["key"] = "value" },
};
await projectClient.OpenAI.Conversations.UpdateProjectConversationAsync(conversation.Id, updateOptions);

// Get the updated conversation.
conversation = await projectClient.OpenAI.Conversations.GetProjectConversationAsync(conversation1.Id);
Console.WriteLine($"Got conversation (id: {conversation.Id}, metadata: {conversation.Metadata})");
```

6. Finally, remove `ProjectConversation` objects we have created.

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
