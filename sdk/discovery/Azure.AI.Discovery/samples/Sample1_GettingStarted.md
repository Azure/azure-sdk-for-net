# Sample: Get started with Azure AI Discovery

This sample shows how to authenticate, create the workspace and bookshelf clients, and perform a few
basic operations: creating and reading a conversation, and creating and reading a knowledge base.

## Create the clients

Both clients accept an endpoint and a [`TokenCredential`](https://learn.microsoft.com/dotnet/api/azure.core.tokencredential).
`DefaultAzureCredential` from the `Azure.Identity` package works for most scenarios.

```C# Snippet:Discovery_CreateClients
Uri workspaceEndpoint = new Uri("<workspace-endpoint>");
WorkspaceClient workspaceClient = new WorkspaceClient(workspaceEndpoint, new DefaultAzureCredential());

Uri bookshelfEndpoint = new Uri("<bookshelf-endpoint>");
BookshelfClient bookshelfClient = new BookshelfClient(bookshelfEndpoint, new DefaultAzureCredential());
```

## Create and read a conversation

Obtain the conversations sub-client from the workspace client, create a conversation under an
investigation, then read it back.

```C# Snippet:Discovery_CreateAndReadConversation
DiscoveryConversationsClient conversationsClient = workspaceClient.GetDiscoveryConversationsClient();

DiscoveryConversation created = await conversationsClient.CreateAsync(
    projectName: "my-project",
    investigationName: "/projects/my-project/investigations/my-investigation",
    displayName: "Getting started conversation");

DiscoveryConversation conversation = await conversationsClient.GetAsync(created.Name);
Console.WriteLine($"Conversation: {conversation.Name}");
```

## Create and read a knowledge base

Knowledge base create-or-update is a long-running operation. Pass `WaitUntil.Completed` to wait until
the knowledge base has finished provisioning.

```C# Snippet:Discovery_CreateAndReadKnowledgeBase
KnowledgeBases knowledgeBases = bookshelfClient.GetKnowledgeBasesClient();

RequestContent body = RequestContent.Create(new
{
    description = "My knowledge base",
    storageAssetReferences = new[]
    {
        new
        {
            id = "<storage-asset-resource-id>",
            userAssignedIdentity = "<user-assigned-identity-resource-id>",
        },
    },
});

Operation<BinaryData> operation = await knowledgeBases.CreateOrUpdateAsync(
    WaitUntil.Completed,
    "my-knowledge-base",
    body);

KnowledgeBase knowledgeBase = await knowledgeBases.GetAsync("my-knowledge-base");
Console.WriteLine($"Knowledge base: {knowledgeBase.Name}");
```

## List knowledge bases

```C# Snippet:Discovery_ListKnowledgeBases
await foreach (KnowledgeBase kb in knowledgeBases.GetAllAsync())
{
    Console.WriteLine(kb.Name);
}
```
