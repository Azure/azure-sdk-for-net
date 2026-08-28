# Read and manage messages

Messages are sent by connected clients over the WebSocket connection. The service client is used to read message history and to update or delete existing messages.

## Read message history

Message history is read from a conversation. A room's `DefaultConversation` identifies its conversation:

```C# Snippet:WebPubSubChatReadDetailedMessageHistory
WebPubSubChatRoom room = client.GetRoom("room1").Value;

foreach (WebPubSubChatMessage message in client.GetMessages(room.DefaultConversation))
{
    Console.WriteLine($"[{message.CreatedOn}] {message.CreatedBy}: {message.Content.Text}");
}
```

## Page through message history

Messages are returned from latest to earliest. You can constrain a query with pagination parameters:

```C# Snippet:WebPubSubChatPageMessageHistory
Pageable<WebPubSubChatMessage> messages = client.GetMessages(
    room.DefaultConversation,
    latestMessageId: null,
    earliestMessageId: null,
    maxPageSize: 50);

foreach (WebPubSubChatMessage message in messages)
{
    Console.WriteLine($"{message.Id}: {message.Content.Text}");
}
```

## Get conversation information

```C# Snippet:WebPubSubChatGetConversation
WebPubSubChatConversation conversation = client.GetConversation(room.DefaultConversation).Value;

Console.WriteLine($"Conversation {conversation.Id} belongs to room {conversation.ParentRoom}");
```

## Update a message

Update the content of an existing message using a protocol method:

```C# Snippet:WebPubSubChatUpdateMessage
var updatedContent = new WebPubSubChatMessageContent { Text = "Updated message text" };

client.UpdateMessage(
    room.DefaultConversation,
    "<message-id>",
    RequestContent.Create(updatedContent));
```

## Delete a message

```C# Snippet:WebPubSubChatDeleteMessage
client.DeleteMessage(room.DefaultConversation, "<message-id>");
```

## Async APIs

```C# Snippet:WebPubSubChatManageMessagesAsync
await foreach (WebPubSubChatMessage message in client.GetMessagesAsync(room.DefaultConversation))
{
    Console.WriteLine($"{message.CreatedBy}: {message.Content.Text}");
}

await client.DeleteMessageAsync(room.DefaultConversation, "<message-id>");
```