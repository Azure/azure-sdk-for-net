# Azure Communication Chat client library for .NET

This package contains a C# SDK for Azure Communication Services for chat.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]


## Getting started

### Install the package
Install the Azure Communication Chat client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Communication.Chat
```

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].
<!--
Here's an example using the Azure CLI:

```Powershell
[To be ADDED]
```
-->

### Authenticate the client
#### User Access Tokens

User access tokens enable you to build client applications that directly authenticate to Azure Communication Services.
For the generation of user access tokens, refer to [User Access Tokens][useraccesstokens].

### Using statements
```C# Snippet:Azure_Communication_Chat_Tests_Samples_UsingStatements
using Azure.Communication.Identity;
using Azure.Communication.Chat;
```

### Create a ChatClient

This will allow you to create, get, or delete chat threads.
```C# Snippet:Azure_Communication_Chat_Tests_Samples_CreateChatClient
ChatClient chatClient = new ChatClient(
    endpoint,
    new CommunicationTokenCredential(userToken));
```

### Create a ChatThreadClient

The ChatThreadClient will allow you to perform operations specific to a chat thread, like update the chat thread topic, send a message, add participants to the chat thread, etc.

You can instantiate a new ChatThreadClient using the GetChatThread operation of the ChatClient with an existing thread id:

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThreadClient_KeyConcepts
ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(chatThread.Id);
```

## Key concepts

A chat conversation is represented by a thread. Each user in the thread is called a thread participant. Thread participants can chat with one another privately in a 1:1 chat or huddle up in a 1:N group chat. Users also get near-real time updates for when others are typing and when they have read the messages.

Once you initialized a `ChatClient` class, you can do the following chat operations:

### Create a thread
```C# Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread_KeyConcepts
CreateChatThreadOptions createChatThreadOptions = new CreateChatThreadOptions("Hello world!");

createChatThreadOptions.Metadata.Add("MetadataKey1", "MetadataValue1");
createChatThreadOptions.Metadata.Add("MetadataKey2", "MetadataValue2");

createChatThreadOptions.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(40);

CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(createChatThreadOptions);
ChatThreadProperties chatThread = createChatThreadResult.ChatThread;
```
### Get a thread
```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThread_KeyConcepts
ChatThread chatThread = chatClient.GetChatThread(chatThread.Id);
```
### Get all threads for the user
```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThreadsInfo_KeyConcepts
Pageable<ChatThreadItem> threads = chatClient.GetChatThreads();
```
### Delete a thread
```C# Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread_KeyConcepts
chatClient.DeleteChatThread(chatThread.Id);
```

Once you initialized a `ChatThreadClient` class, you can do the following chat operations:

### Update a thread
```C# Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread_KeyConcepts
UpdateChatThreadPropertiesOptions updateChatThreadPropertiesOptions = new UpdateChatThreadPropertiesOptions();
updateChatThreadPropertiesOptions.Topic = "Launch meeting";
updateChatThreadPropertiesOptions.Metadata.Add("UpdateMetadataKey", "UpdateMetadataValue");

updateChatThreadPropertiesOptions.RetentionPolicy = ChatRetentionPolicy.None();

await chatThreadClient.UpdatePropertiesAsync(updateChatThreadPropertiesOptions);
```
### Send a message
```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendMessage_KeyConcepts
SendChatMessageResult sendChatMessageResult = chatThreadClient.SendMessage("Let's meet at 11am");
```
### Update a message
```C# Snippet:Azure_Communication_Chat_Tests_Samples_UpdateMessage_KeyConcepts
chatThreadClient.UpdateMessage(sendChatMessageResult.Id, content: "Instead of 11am, let's meet at 2pm");
```
### Get a message
```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetMessage_KeyConcepts
ChatMessage message = chatThreadClient.GetMessage(sendChatMessageResult.Id);
```
### Delete a message
```C# Snippet:Azure_Communication_Chat_Tests_Samples_DeleteMessage_KeyConcepts
chatThreadClient.DeleteMessage(sendChatMessageResult.Id);
```
### Get messages
```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetMessages_KeyConcepts
Pageable<ChatMessage> messages = chatThreadClient.GetMessages();
```
### Get a list of participants
```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetParticipants_KeyConcepts
Pageable<ChatParticipant> chatParticipants = chatThreadClient.GetParticipants();
```
### Add participants
```C# Snippet:Azure_Communication_Chat_Tests_Samples_AddParticipants_KeyConcepts
chatThreadClient.AddParticipants(participants: new[] { new ChatParticipant(participantIdentifier) });
```
### Remove a participant
```C# Snippet:Azure_Communication_Chat_Tests_Samples_RemoveParticipant_KeyConcepts
chatThreadClient.RemoveParticipant(identifier: participantIdentifier);
```
### Send a typing notification
```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification_KeyConcepts
chatThreadClient.SendTypingNotification();
```
### Get a list of read receipts
```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetReadReceipts_KeyConcepts
Pageable<ChatMessageReadReceipt> readReceipts = chatThreadClient.GetReadReceipts();
```
### Send a read receipt
```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendReadReceipt_KeyConcepts
chatThreadClient.SendReadReceipt(sendChatMessageResult.Id);
```

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following sections provide several code snippets covering some of the most common tasks, including:

- [Thread Operations](#thread-operations)
- [Message Operations](#message-operations)
- [Thread Participant Operations](#thread-participant-operations)
- [Events Operations](#events-operations)

## Thread Operations

### Create a thread

Use `CreateChatThread` to create a chat thread client object.
- Use `topic` to give a thread topic.
- The following are the supported attributes for each thread participant:
  - `communicationUser`, required, it is the identification for the thread participant.
  - `displayName`, optional, is the display name for the thread participant
  - `shareHistoryTime`, optional, time from which the chat history is shared with the participant.

`ChatThreadClient` is the result returned from creating a thread, you can use it to perform other operations on the chat thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_CreateChatClient
ChatClient chatClient = new ChatClient(
    endpoint,
    new CommunicationTokenCredential(userToken));
```
```C# Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread
var chatParticipant = new ChatParticipant(identifier: kimberly)
{
    DisplayName = "Kim"
};

chatParticipant.Metadata.Add("MetadataKey1", "MetadataValue1");
chatParticipant.Metadata.Add("MetadataKey2", "MetadataValue2");

CreateChatThreadOptions createChatThreadOptions = new CreateChatThreadOptions("Hello world!");

createChatThreadOptions.Participants.Add(chatParticipant);

createChatThreadOptions.Metadata.Add("MetadataKey1", "MetadataValue1");
createChatThreadOptions.Metadata.Add("MetadataKey2", "MetadataValue2");

createChatThreadOptions.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(60);

CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(createChatThreadOptions);
string threadId = createChatThreadResult.ChatThread.Id;
ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);
```
### Get a thread

Use `GetChatThread` to retrieve a chat thread from the service.
`threadId` is the unique id of the thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetThread
ChatThreadProperties chatThread = await chatThreadClient.GetPropertiesAsync();
```

### Get threads (for a participant)

Use `GetChatThreads` to get the list of chat threads for the participant that instantiated the chatClient.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetThreads
AsyncPageable<ChatThreadItem> chatThreadItems = chatClient.GetChatThreadsAsync();
await foreach (ChatThreadItem chatThreadItem in chatThreadItems)
{
    Console.WriteLine($"{ chatThreadItem.Id}");
}
```

### Delete a thread

Use `DeleteChatThread` to delete a thread.
`threadId` is the unique id of the thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread
await chatClient.DeleteChatThreadAsync(threadId);
```

### Update a thread

Use `UpdatePropertiesAsync` to update the chat thread topic or metadata.
```C# Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread
UpdateChatThreadPropertiesOptions updateChatThreadPropertiesOptions = new UpdateChatThreadPropertiesOptions();
updateChatThreadPropertiesOptions.Topic = "new topic !";
updateChatThreadPropertiesOptions.Metadata.Add("UpdateMetadataKey", "UpdateMetadataValue");

updateChatThreadPropertiesOptions.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(60);

await chatThreadClient.UpdatePropertiesAsync(updateChatThreadPropertiesOptions);
```

## Message Operations

### Send a message

Use `SendMessage` to send a message to a thread.

- Use `content` to provide the content for the message, it is required.
- Use `type` for the content type of the message such as 'Text' or 'Html'. If not specified, 'Text' will be set.
- Use `senderDisplayName` to specify the display name of the sender. If not specified, empty string will be set.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendMessage
SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync(content:"hello world");
var messageId = sendChatMessageResult.Id;
```

### Get a message

Use `GetMessage` to retrieve a message from the service.
`messageId` is the unique id of the message.

`ChatMessage` is the response returned from getting a message, it contains an id, which is the unique identifier of the message, among other fields. Please refer to Azure.Communication.Chat.ChatMessage

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetMessage
ChatMessage chatMessage = await chatThreadClient.GetMessageAsync(messageId);
```
### Get messages

Use `GetMessages` to retrieve all messages for the chat thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetMessages
AsyncPageable<ChatMessage> allMessages = chatThreadClient.GetMessagesAsync();
await foreach (ChatMessage message in allMessages)
{
    Console.WriteLine($"{message.Id}:{message.Content.Message}");
}
```
### Update a message

Use `UpdateMessage` to update a message.
- `messageId` is the unique identifier of the message.
- `content` is the message content to be updated.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_UpdateMessage
await chatThreadClient.UpdateMessageAsync(messageId, "updated message content");
```
### Delete a message

Use `DeleteMessage` to delete a message.
- `messageId` is the unique identifier of the message.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_DeleteMessage
await chatThreadClient.DeleteMessageAsync(messageId);
```

## Thread Participant Operations

### Get thread participants

Use `GetParticipants` to retrieve the participants of the chat thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetParticipants
AsyncPageable<ChatParticipant> allParticipants = chatThreadClient.GetParticipantsAsync();
await foreach (ChatParticipant participant in allParticipants)
{
    Console.WriteLine($"{((CommunicationUserIdentifier)participant.User).Id}:{participant.DisplayName}:{participant.ShareHistoryTime}");
}
```
### Add thread participants

Use `AddParticipants` to add one or more participants to the chat thread. The following are the supported attributes for each thread participant(s):
- `communicationUser`, required, it is the identification for the thread participant.
- `displayName`, optional, is the display name for the thread participant.
- `shareHistoryTime`, optional, time from which the chat history is shared with the participant.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_AddParticipants
var participants = new[]
{
    new ChatParticipant(josh) { DisplayName = "Josh" },
    new ChatParticipant(gloria) { DisplayName = "Gloria" },
    new ChatParticipant(amy) { DisplayName = "Amy" }
};

await chatThreadClient.AddParticipantsAsync(participants);
```

### Remove thread participant

Use `RemoveParticipant` to remove a thread participant from the thread.
`communicationUser` is the identification of the chat participant.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_RemoveParticipant
await chatThreadClient.RemoveParticipantAsync(gloria);
```

## Events Operations

### Send typing notification

Use `SendTypingNotification` to indicate that the user is typing a response in the thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification
await chatThreadClient.SendTypingNotificationAsync();
```

### Send read receipt

Use `SendReadReceipt` to notify other participants that the message is read by the user.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendReadReceipt
await chatThreadClient.SendReadReceiptAsync(messageId);
```

### Get read receipts

Use `GetReadReceipts` to check the status of messages to see which ones are read by other participants of a chat thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetReadReceipts
AsyncPageable<ChatMessageReadReceipt> allReadReceipts = chatThreadClient.GetReadReceiptsAsync();
await foreach (ChatMessageReadReceipt readReceipt in allReadReceipts)
{
    Console.WriteLine($"{readReceipt.ChatMessageId}:{((CommunicationUserIdentifier)readReceipt.Sender).Id}:{readReceipt.ReadOn}");
}
```

## Troubleshooting
### Service Responses
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.
```C# Snippet:Azure_Communication_Chat_Tests_Samples_Troubleshooting
try
{
    CreateChatThreadResult createChatThreadErrorResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new[] { josh });
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.Message);
}
```

## Next steps
[Read more about Chat in Azure Communication Services][nextsteps]

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[nuget]: https://www.nuget.org/
[netstandars2mappings]:https://github.com/dotnet/standard/blob/master/docs/versions.md
[useraccesstokens]:https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[nextsteps]:https://docs.microsoft.com/azure/communication-services/quickstarts/chat/get-started?pivots=programming-language-csharp
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.Chat/src
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[package]: https://www.nuget.org/packages/Azure.Communication.Chat
