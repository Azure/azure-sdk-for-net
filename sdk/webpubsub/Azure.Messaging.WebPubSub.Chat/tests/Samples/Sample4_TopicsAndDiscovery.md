# Topics and discovery

These operations require service API version `2026-08-01-preview`, the client
default. See [authentication and API-version selection](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/README.md#authenticate-the-client).

## Discover rooms

Pageable APIs fetch more pages as you enumerate them. `maxPageSize` requests a
page size, not a total-result limit:

```C# Snippet:WebPubSubChatDiscoverRooms
await foreach (WebPubSubChatRoom room in client.GetRoomsAsync(maxPageSize: 20))
{
    Console.WriteLine($"{room.Id}: {room.Title}");
}
```

## Discover users

```C# Snippet:WebPubSubChatDiscoverUsers
await foreach (WebPubSubChatUser user in client.GetUsersAsync(maxPageSize: 20))
{
    Console.WriteLine($"{user.Id}: {user.Nickname}");
}
```

## Discover a user's rooms

Create `user1` and add it to a room as shown in
[Manage rooms and members](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/webpubsub/Azure.Messaging.WebPubSub.Chat/tests/Samples/Sample1_ManageRoomsAndMembers.md)
before listing its rooms:

`GetRoomsForUserAsync` also accepts `maxPageSize` and `continuationToken`
to request a page size or resume using a service continuation token. As with
the other lists, use `AsPages` with a returned `Page<T>.ContinuationToken`
when resuming from the SDK's opaque continuation link.

```C# Snippet:WebPubSubChatDiscoverUserRooms
await foreach (ChatUserRoom room in client.GetRoomsForUserAsync("user1"))
{
    Console.WriteLine($"User belongs to {room.Title} ({room.Id})");
}
```

## Create a topic

Create `room1` first. A topic belongs to a room and has its own conversation.
The server supplies its creator, creation timestamp, conversation ID, and ETag.
This create-only example fails with status 412 if `planning` already exists;
use a fresh ID when rerunning it:

```C# Snippet:WebPubSubChatCreateTopic
ChatTopic topic = await client.CreateOrReplaceTopicAsync(
    "room1", "planning", new ChatTopic("Planning", ChatTopicState.Normal),
    new MatchConditions { IfNoneMatch = ETag.All });
Console.WriteLine($"{topic.Id}: {topic.ConversationId}");
```

## List topics

```C# Snippet:WebPubSubChatListTopics
await foreach (ChatTopic listedTopic in client.GetTopicsAsync("room1", maxPageSize: 20))
{
    Console.WriteLine($"{listedTopic.Id}: {listedTopic.Title} ({listedTopic.State})");
}
```

## Get a topic

States include `Normal`, `Archived`, and `SoftDeleted`. Unknown future states
are preserved:

```C# Snippet:WebPubSubChatGetTopic
topic = await client.GetTopicAsync("room1", "planning");
Console.WriteLine($"{topic.Title}: {topic.State}");
```

## Archive a topic

Use the ETag from the previously retrieved `topic` to avoid overwriting
concurrent changes. A conflicting change produces a `RequestFailedException`
with status 412; retrieve the latest topic and decide whether to retry.
`UpdateTopicAsync` accepts a JSON merge patch, so omitted properties are
unchanged:

```C# Snippet:WebPubSubChatUpdateTopic
// Merge patch changes only the supplied properties.
using RequestContent patch = RequestContent.Create(new { state = "Archived" });
Response updated = await client.UpdateTopicAsync(
    "room1", "planning", patch, new MatchConditions { IfMatch = topic.Etag });
topic = (ChatTopic)updated;
```

## Soft delete a topic

Use the ETag from the previous update. Deletion is not permanent removal:

```C# Snippet:WebPubSubChatDeleteTopic
// Deleting a topic is a soft delete, not a permanent removal.
await client.DeleteTopicAsync(
    "room1", "planning", new MatchConditions { IfMatch = topic.Etag });
```

## Resume a room listing

Use `Page<T>.ContinuationToken` with `AsPages` to resume enumeration. Treat it
as opaque; do not pass this link to the operation's service `continuationToken`
query parameter:

```C# Snippet:WebPubSubChatResumeRoomListing
string continuationToken = null;
foreach (Page<WebPubSubChatRoom> page in client.GetRooms().AsPages(pageSizeHint: 20))
{
    foreach (WebPubSubChatRoom room in page.Values)
    {
        Console.WriteLine(room.Title);
    }
    continuationToken = page.ContinuationToken;
    break;
}

// AsPages accepts the opaque continuation link from a previous page.
if (continuationToken != null)
{
    foreach (Page<WebPubSubChatRoom> page in client.GetRooms().AsPages(continuationToken))
    {
        foreach (WebPubSubChatRoom room in page.Values)
        {
            Console.WriteLine(room.Title);
        }
    }
}
```
