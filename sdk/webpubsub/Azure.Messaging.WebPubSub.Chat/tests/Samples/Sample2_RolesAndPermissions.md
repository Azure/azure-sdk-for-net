# Roles and permissions

This sample shows how to use the built-in roles and permissions shipped with the library, and how to define custom roles.

## Inspect a built-in role

```C# Snippet:WebPubSubChatInspectBuiltInRole
WebPubSubChatRole memberRole = client.GetRole(BuiltInChatRoles.RoomMember).Value;

Console.WriteLine($"{memberRole.Name}: {string.Join(", ", memberRole.Permissions)}");
```

## Define a custom role

A role name must start with the `user.` or `room.` prefix, and must not mix user permissions with room permissions. The following defines a custom room role from built-in permissions:

```C# Snippet:WebPubSubChatCreateCustomRole
var role = new WebPubSubChatRole(new[]
{
    ChatPermission.RoomPublishMessage,
    ChatPermission.RoomHistory,
    ChatPermission.RoomInvite,
});

WebPubSubChatRole created = client.CreateOrReplaceRole("room.contributor", role).Value;
```

## List all roles

```C# Snippet:WebPubSubChatListRoles
foreach (WebPubSubChatRole role in client.GetRoles())
{
    Console.WriteLine($"{role.Name}: {string.Join(", ", role.Permissions)}");
}
```

## Assign a role to a room member

Use a role name (built-in or custom) when creating a room member:

```C# Snippet:WebPubSubChatAssignCustomRole
client.CreateOrReplaceRoomMember(
    "room1",
    "user1",
    new WebPubSubChatRoomMember("room.contributor"));
```

## Delete a custom role

```C# Snippet:WebPubSubChatDeleteCustomRole
client.DeleteRole("room.contributor");
```
