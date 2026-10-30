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

Messages are returned from latest to earliest. Message IDs are pagination cursors:
the pageable follows each response's `nextLink`, which contains the cursor for the
next page. Save a page's `ContinuationToken` and pass it to
`messages.AsPages(continuationToken)` to resume later. You can constrain a query
with pagination parameters:

```C# Snippet:WebPubSubChatPageMessageHistory
Pageable<WebPubSubChatMessage> messages = client.GetMessages(
    room.DefaultConversation,
    new MessageQueryOptions { MaxPageSize = 50 });

foreach (WebPubSubChatMessage message in messages)
{
    Console.WriteLine($"{message.Id}: {message.Content.Text}");
}
```

## Get conversation information

```C# Snippet:WebPubSubChatGetConversation
WebPubSubChatConversation conversation = client.GetConversation(room.DefaultConversation).Value;

Console.WriteLine($"Conversation {conversation.Id} belongs to room {conversation.RoomId}");
```

## Update a message

Use `UpdateMessageOptions` to update only the supplied properties of an existing
message. Leaving `CreatedBy` unset preserves the original creator:

```C# Snippet:WebPubSubChatUpdateMessage
var updatedMessage = new UpdateMessageOptions
{
    Content = WebPubSubChatMessageContent.FromText("Updated message text")
};

client.UpdateMessage(
    room.DefaultConversation,
    "<message-id>",
    updatedMessage);
```

Leaving a property unset preserves its value, whereas explicitly assigning null
clears it (`CreatedBy` becomes an empty string, and `Content` becomes empty text).
Pass `MatchConditions` with the message's ETag to protect against concurrent changes.

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