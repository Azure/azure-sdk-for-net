# Azure Communication Chat client library for .NET

> Server Version: 
Chat client: 2020-09-21-preview2

This package contains a C# SDK for Azure Communication Services for chat.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs]


## Getting started

### Install the package
Install the Azure Communication Chat client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.Communication.Chat --version 1.0.0-beta.3
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
```C# Snippet:Azure_Communication_Chat_Tests_E2E_UsingStatements
using Azure.Communication.Administration;
using Azure.Communication.Administration.Models;
using Azure.Communication;
using Azure.Communication.Chat;
```

### Create a ChatClient

This will allow you to create, get, or delete chat threads.
```C# Snippet:Azure_Communication_Chat_Tests_Samples_CreateChatClient
ChatClient chatClient = new ChatClient(
    new Uri(endpoint),
    new CommunicationTokenCredential(userToken));
```

### Create a ChatThreadClient

The ChatThreadClient will allow you to perform operations specific to a chat thread, like update the chat thread topic, send a message, add members to the chat thread, etc.

You can instantiate a new ChatThreadClient instance using the ChatClient:

```C# Snippet:Azure_Communication_Chat_Tests_E2E_InitializeChatThreadClient
ChatThreadClient chatThreadClient1 = chatClient.CreateChatThread("Thread topic", members);
// Alternatively, if you have created a chat thread before and you have its threadId, you can create a ChatThreadClient instance using:
ChatThreadClient chatThreadClient2 = chatClient.GetChatThreadClient("threadId");
```

## Key concepts

A chat conversation is represented by a thread. Each user in the thread is called a thread member. Thread members can chat with one another privately in a 1:1 chat or huddle up in a 1:N group chat. Users also get near-real time updates for when others are typing and when they have read the messages.

Once you initialized a `ChatClient` class, you can do the following chat operations:

### Create a thread
To create a thread, see 'Create a ChatThreadClient' section

### Get a thread
```C# Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThread
ChatThread chatThread = chatClient.GetChatThread(threadId);
```
### Get all threads for the user
```C# Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThreadsInfo
Pageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfo();
```
### Delete a thread
```C# Snippet:Azure_Communication_Chat_Tests_E2E_DeleteChatThread
chatClient.DeleteChatThread(threadId);
```

Once you initialized a `ChatThreadClient` class, you can do the following chat operations:

### Update a thread

```C# Snippet:Azure_Communication_Chat_Tests_E2E_UpdateThread
chatThreadClient.UpdateThread(topic: "Launch meeting");
```

### Send a message
```C# Snippet:Azure_Communication_Chat_Tests_E2E_SendMessage
SendChatMessageResult sendChatMessageResult = chatThreadClient.SendMessage("Let's meet at 11am");
```
### Update a message
```C# Snippet:Azure_Communication_Chat_Tests_E2E_UpdateMessage
chatThreadClient.UpdateMessage(messageId, content: "Instead of 11am, let's meet at 2pm");
```

### Get messages
```C# Snippet:Azure_Communication_Chat_Tests_E2E_GetMessage
ChatMessage message = chatThreadClient.GetMessage(messageId);
```
```C# Snippet:Azure_Communication_Chat_Tests_E2E_GetMessages
Pageable<ChatMessage> messages = chatThreadClient.GetMessages();
```
### Delete a message
```C# Snippet:Azure_Communication_Chat_Tests_E2E_DeleteMessage
chatThreadClient.DeleteMessage(messageId);
```
### Get a list of members
```C# Snippet:Azure_Communication_Chat_Tests_E2E_GetMembers
Pageable<ChatThreadMember> chatThreadMembers = chatThreadClient.GetMembers();
```
### Add members
```C# Snippet:Azure_Communication_Chat_Tests_E2E_AddMembers
chatThreadClient.AddMembers(members: new[] { newMember });
```
### Remove a member
```C# Snippet:Azure_Communication_Chat_Tests_E2E_RemoveMember
chatThreadClient.RemoveMember(user: memberToBeRemoved);
```
### Send a typing notification
```C# Snippet:Azure_Communication_Chat_Tests_E2E_SendTypingNotification
chatThreadClient.SendTypingNotification();
```
### Get a list of read receipts
```C# Snippet:Azure_Communication_Chat_Tests_E2E_GetReadReceipts
Pageable<ReadReceipt> readReceipts = chatThreadClient.GetReadReceipts();
```
### Send a read receipt
```C# Snippet:Azure_Communication_Chat_Tests_E2E_SendReadReceipt
chatThreadClient.SendReadReceipt(messageId);
```
## Examples

The following sections provide several code snippets covering some of the most common tasks, including:

- [Thread Operations](#thread-operations)
- [Message Operations](#message-operations)
- [Thread Member Operations](#thread-member-operations)
- [Events Operations](#events-operations)

## Thread Operations

### Create a thread

Use `CreateChatThread` to create a chat thread client object.
- Use `topic` to give a thread topic.
- The following are the supported attributes for each thread member:
  - `communicationUser`, required, it is the identification for the thread member.
  - `displayName`, optional, is the display name for the thread member
  - `shareHistoryTime`, optional, time from which the chat history is shared with the member.

`ChatThreadClient` is the result returned from creating a thread, you can use it to perform other operations on the chat thread.

**Important:**  Make sure the user creating the chat thread is explicitely added to the list of members, otherwise the creation call will fail.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_CreateChatClient
ChatClient chatClient = new ChatClient(
    new Uri(endpoint),
    new CommunicationTokenCredential(userToken));
```
```C# Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread
var chatThreadMember = new ChatThreadMember(new CommunicationUserIdentifier(threadCreatorId))
{
    DisplayName = "UserDisplayName"
};
ChatThreadClient chatThreadClient = await chatClient.CreateChatThreadAsync(topic: "Hello world!", members: new[] { chatThreadMember });
string threadId = chatThreadClient.Id;
```
### Get a thread

Use `GetChatThread` to retrieve a chat thread from the service.
`threadId` is the unique id of the thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetThread
ChatThread chatThread = await chatClient.GetChatThreadAsync(threadId);
```

### Get threads (for a member)

Use `GetChatThreadsInfo` to get the list of chat threads for the member that instantiated the chatClient.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetThreads
AsyncPageable<ChatThreadInfo> chatThreadsInfo = chatClient.GetChatThreadsInfoAsync();
await foreach (ChatThreadInfo chatThreadInfo in chatThreadsInfo)
{
    Console.WriteLine($"{ chatThreadInfo.Id}");
}
```

### Delete a thread

Use `DeleteChatThread` to delete a thread.
`threadId` is the unique id of the thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread
await chatClient.DeleteChatThreadAsync(threadId);
```

### Update a thread

Use `UpdateChatThread` to update the chat thread properties.
- `topic` is used to describe the updated topic for the thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread
var topic = "new topic";
await chatThreadClient.UpdateThreadAsync(topic);
```

## Message Operations

### Send a message

Use `SendMessage` to send a message to a thread.

- Use `content` to provide the content for the message, it is required.
- Use `priority` to specify the message priority level, such as 'Normal' or 'High'.If not speficied, 'Normal' will be set.
- Use `senderDisplayName` to specify the display name of the sender. If not specified, empty name will be set.

`SendChatMessageResult` is the response returned from sending a message, it contains an id, which is the unique id of the message.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendMessage
var content = "hello world";
var priority = ChatMessagePriority.Normal;
var senderDisplayName = "sender name";
SendChatMessageResult sendMessageResult = await chatThreadClient.SendMessageAsync(content, priority, senderDisplayName);
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
    Console.WriteLine($"{message.Id}:{message.Sender.Id}:{message.Content}");
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

## Thread Member Operations

### Get thread members

Use `GetMembers` to retrieve the members of the chat thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetMembers
AsyncPageable<ChatThreadMember> allMembers = chatThreadClient.GetMembersAsync();
await foreach (ChatThreadMember member in allMembers)
{
    Console.WriteLine($"{member.User.Id}:{member.DisplayName}:{member.ShareHistoryTime}");
}
```
### Add thread members

Use `AddMembers` to add members to the chat thread. The following are the supported attributes for each thread member:
- `communicationUser`, required, it is the identification for the thread member.
- `displayName`, optional, is the display name for the thread member.
- `shareHistoryTime`, optional, time from which the chat history is shared with the member.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_AddMembers
var members = new[]
{
    new ChatThreadMember(new CommunicationUserIdentifier(memberId1)) { DisplayName ="display name member 1"},
    new ChatThreadMember(new CommunicationUserIdentifier(memberId2)) { DisplayName ="display name member 2"},
    new ChatThreadMember(new CommunicationUserIdentifier(memberId3)) { DisplayName ="display name member 3"}
};
await chatThreadClient.AddMembersAsync(members);
```

### Remove thread member

Use `RemoveMember` to remove a thread member from the thread.
`communicationUser` is the identification of the chat member.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_RemoveMember
await chatThreadClient.RemoveMemberAsync(new CommunicationUserIdentifier(memberId));
```

## Events Operations

### Send typing notification

Use `SendTypingNotification` to indicate that the user is typing a response in the thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification
await chatThreadClient.SendTypingNotificationAsync();
```

### Send read receipt

Use `SendReadReceipt` to notify other members that the message is read by the user.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_SendReadReceipt
await chatThreadClient.SendReadReceiptAsync(messageId);
```

### Get read receipts

Use `GetReadReceipts` to check the status of messages to see which ones are read by other members of a chat thread.

```C# Snippet:Azure_Communication_Chat_Tests_Samples_GetReadReceipts
AsyncPageable<ReadReceipt> allReadReceipts = chatThreadClient.GetReadReceiptsAsync();
await foreach (ReadReceipt readReceipt in allReadReceipts)
{
    Console.WriteLine($"{readReceipt.ChatMessageId}:{readReceipt.Sender.Id}:{readReceipt.ReadOn}");
}
```

## Troubleshooting
### Service Responses
A `RequestFailedException` is thrown as a service response for any unsuccessful requests. The exception contains information about what response code was returned from the service.
```C# Snippet:Azure_Communication_Chat_Tests_Samples_Troubleshooting
try
{
    ChatThreadClient chatThreadClient_ = await chatClient.CreateChatThreadAsync(topic: "Hello world!", members: new[] { chatThreadMember });
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
[azure_sub]: https://azure.microsoft.com/free/
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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Chat/src
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[package]: https://www.nuget.org/packages/Azure.Communication.Chat
