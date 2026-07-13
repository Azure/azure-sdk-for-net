# Manage rooms and members

This sample shows how to create rooms, users, and room members, and how to generate a client access URI that a client uses to connect to the service.

## Create the client

```C# Snippet:WebPubSubChatAuthenticateWithConnectionString
var client = new WebPubSubChatServiceClient("<connection-string>", "chat");
```

## Generate a client access URI

Before a client can connect over WebSocket, generate a client access URI for the user:

```C# Snippet:WebPubSubChatGenerateClientAccessUri
Uri clientAccessUri = client.GetClientAccessUri(new GetClientAccessTokenOptions
{
    UserId = "user1",
    ExpiresAfter = TimeSpan.FromHours(1),
});
```

## Create a user

Create (or replace) a chat user. A `HumanChatUser` represents an end user and is assigned a role:

```C# Snippet:WebPubSubChatCreateUser
WebPubSubChatUser user = client.CreateOrReplaceUser(
    "user1",
    new WebPubSubHumanChatUser("Alice", ChatRoles.UserNormal)).Value;
```

## Create a room

Create (or replace) a room. Each room exposes a default conversation used to exchange messages:

```C# Snippet:WebPubSubChatCreateRoom
WebPubSubChatRoom room = client.CreateOrReplaceRoom("room1", new WebPubSubChatRoom("General")).Value;

Console.WriteLine($"Room {room.Id} default conversation: {room.DefaultConversation}");
```

## Add a member to the room

Adding a user to a room creates a room member with a role in that room:

```C# Snippet:WebPubSubChatAddRoomMember
WebPubSubChatRoomMember member = client.CreateOrReplaceRoomMember(
    "room1",
    "user1",
    new WebPubSubChatRoomMember(ChatRoles.RoomMember)).Value;
```

## List room members

```C# Snippet:WebPubSubChatListRoomMembers
foreach (WebPubSubChatRoomMember roomMember in client.GetRoomMembers("room1"))
{
    Console.WriteLine($"{roomMember.UserId} -> {roomMember.RoleName}");
}
```

## Remove a member and delete the room

```C# Snippet:WebPubSubChatDeleteRoomMemberAndRoom
client.DeleteRoomMember("room1", "user1");
client.DeleteRoom("room1");
```

## Async APIs

Every operation has an asynchronous counterpart:

```C# Snippet:WebPubSubChatManageRoomMembersAsync
WebPubSubChatRoom room = (await client.CreateOrReplaceRoomAsync("room1", new WebPubSubChatRoom("General"))).Value;

await foreach (WebPubSubChatRoomMember roomMember in client.GetRoomMembersAsync("room1"))
{
    Console.WriteLine($"{roomMember.UserId} -> {roomMember.RoleName}");
}
```
