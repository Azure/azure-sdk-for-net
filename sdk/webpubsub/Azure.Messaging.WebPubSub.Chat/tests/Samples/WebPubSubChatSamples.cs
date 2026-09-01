// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;

namespace Azure.Messaging.WebPubSub.Chat.Tests.Samples
{
    public class WebPubSubChatSamples
    {
        private const string ConnectionString = "Endpoint=https://example.webpubsub.azure.com;AccessKey=<AccessKey>;Version=1.0;";

        public void AuthenticateWithConnectionString()
        {
            #region Snippet:WebPubSubChatAuthenticateWithConnectionString
            var client = new WebPubSubChatServiceClient("<connection-string>", "chat");
            #endregion
        }

        public void AuthenticateWithKeyCredential()
        {
            #region Snippet:WebPubSubChatAuthenticateWithKeyCredential
            var client = new WebPubSubChatServiceClient(
                new Uri("https://<instance>.webpubsub.azure.com"),
                "chat",
                new AzureKeyCredential("<access-key>"));
            #endregion
        }

        public void AuthenticateWithEntraId()
        {
            #region Snippet:WebPubSubChatAuthenticateWithEntraId
            var client = new WebPubSubChatServiceClient(
                new Uri("https://<instance>.webpubsub.azure.com"),
                "chat",
                new DefaultAzureCredential());
            #endregion
        }

        public void GenerateClientAccessUri()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatGenerateClientAccessUri
            Uri clientAccessUri = client.GetClientAccessUri(new ClientAccessUriOptions
            {
                UserId = "user1",
                ExpiresAfter = TimeSpan.FromHours(1),
            });
            #endregion
        }

        public void CreateRoomAndMember()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatCreateRoomAndMember
            // Create (or replace) a room.
            WebPubSubChatRoom room = client.CreateOrReplaceRoom("room1", new WebPubSubChatRoom("General")).Value;

            // Create (or replace) a user with a built-in role.
            client.CreateOrReplaceUser("user1", new WebPubSubHumanChatUser("Alice", BuiltInChatRoles.UserNormal));

            // Add the user to the room as a room member.
            client.CreateOrReplaceRoomMember("room1", "user1", new WebPubSubChatRoomMember(BuiltInChatRoles.RoomMember));
            #endregion
        }

        public void DefineCustomRole()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatDefineCustomRole
            var role = new WebPubSubChatRole(new[]
            {
                ChatPermission.RoomPublishMessage,
                ChatPermission.RoomHistory,
                ChatPermission.RoomInvite,
            });

            client.CreateOrReplaceRole("room.contributor", role);
            #endregion
        }

        public void InspectBuiltInRole()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatInspectBuiltInRole
            WebPubSubChatRole memberRole = client.GetRole(BuiltInChatRoles.RoomMember).Value;

            Console.WriteLine($"{memberRole.Name}: {string.Join(", ", memberRole.Permissions)}");
            #endregion
        }

        public void ReadMessageHistory()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatReadMessageHistory
            WebPubSubChatRoom room = client.GetRoom("room1").Value;

            foreach (WebPubSubChatMessage message in client.GetMessages(room.DefaultConversation))
            {
                Console.WriteLine($"{message.CreatedBy}: {message.Content.Text}");
            }
            #endregion
        }

        public void HandleRequestFailure()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatHandleRequestFailure
            try
            {
                client.GetRoom("does-not-exist");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Request failed with status {ex.Status}: {ex.Message}");
            }
            #endregion
        }

        public void CreateUser()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatCreateUser
            WebPubSubChatUser user = client.CreateOrReplaceUser(
                "user1",
                new WebPubSubHumanChatUser("Alice", BuiltInChatRoles.UserNormal)).Value;
            #endregion
        }

        public void CreateRoom()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatCreateRoom
            WebPubSubChatRoom room = client.CreateOrReplaceRoom("room1", new WebPubSubChatRoom("General")).Value;

            Console.WriteLine($"Room {room.Id} default conversation: {room.DefaultConversation}");
            #endregion
        }

        public void AddRoomMember()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatAddRoomMember
            WebPubSubChatRoomMember member = client.CreateOrReplaceRoomMember(
                "room1",
                "user1",
                new WebPubSubChatRoomMember(BuiltInChatRoles.RoomMember)).Value;
            #endregion
        }

        public void ListRoomMembers()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatListRoomMembers
            foreach (WebPubSubChatRoomMember roomMember in client.GetRoomMembers("room1"))
            {
                Console.WriteLine($"{roomMember.UserId} -> {roomMember.RoleName}");
            }
            #endregion
        }

        public void DeleteRoomMemberAndRoom()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatDeleteRoomMemberAndRoom
            client.DeleteRoomMember("room1", "user1");
            client.DeleteRoom("room1");
            #endregion
        }

        public async Task ManageRoomMembersAsync()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatManageRoomMembersAsync
            WebPubSubChatRoom room = (await client.CreateOrReplaceRoomAsync("room1", new WebPubSubChatRoom("General"))).Value;

            await foreach (WebPubSubChatRoomMember roomMember in client.GetRoomMembersAsync("room1"))
            {
                Console.WriteLine($"{roomMember.UserId} -> {roomMember.RoleName}");
            }
            #endregion
        }

        public void CreateCustomRole()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatCreateCustomRole
            var role = new WebPubSubChatRole(new[]
            {
                ChatPermission.RoomPublishMessage,
                ChatPermission.RoomHistory,
                ChatPermission.RoomInvite,
            });

            WebPubSubChatRole created = client.CreateOrReplaceRole("room.contributor", role).Value;
            #endregion
        }

        public void ListRoles()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatListRoles
            foreach (WebPubSubChatRole role in client.GetRoles())
            {
                Console.WriteLine($"{role.Name}: {string.Join(", ", role.Permissions)}");
            }
            #endregion
        }

        public void AssignCustomRole()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatAssignCustomRole
            client.CreateOrReplaceRoomMember(
                "room1",
                "user1",
                new WebPubSubChatRoomMember("room.contributor"));
            #endregion
        }

        public void DeleteCustomRole()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatDeleteCustomRole
            client.DeleteRole("room.contributor");
            #endregion
        }

        public void ReadDetailedMessageHistory()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");

            #region Snippet:WebPubSubChatReadDetailedMessageHistory
            WebPubSubChatRoom room = client.GetRoom("room1").Value;

            foreach (WebPubSubChatMessage message in client.GetMessages(room.DefaultConversation))
            {
                Console.WriteLine($"[{message.CreatedOn}] {message.CreatedBy}: {message.Content.Text}");
            }
            #endregion
        }

        public void PageMessageHistory()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");
            WebPubSubChatRoom room = client.GetRoom("room1").Value;

            #region Snippet:WebPubSubChatPageMessageHistory
            Pageable<WebPubSubChatMessage> messages = client.GetMessages(
                room.DefaultConversation,
                new MessageQueryOptions { MaxPageSize = 50 });

            foreach (WebPubSubChatMessage message in messages)
            {
                Console.WriteLine($"{message.Id}: {message.Content.Text}");
            }
            #endregion
        }

        public void GetConversation()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");
            WebPubSubChatRoom room = client.GetRoom("room1").Value;

            #region Snippet:WebPubSubChatGetConversation
            WebPubSubChatConversation conversation = client.GetConversation(room.DefaultConversation).Value;

            Console.WriteLine($"Conversation {conversation.Id} belongs to room {conversation.ParentRoom}");
            #endregion
        }

        public void UpdateMessage()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");
            WebPubSubChatRoom room = client.GetRoom("room1").Value;

            #region Snippet:WebPubSubChatUpdateMessage
            var updatedContent = new WebPubSubChatMessageContent { Text = "Updated message text" };

            client.UpdateMessage(
                room.DefaultConversation,
                "<message-id>",
                RequestContent.Create(updatedContent));
            #endregion
        }

        public void DeleteMessage()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");
            WebPubSubChatRoom room = client.GetRoom("room1").Value;

            #region Snippet:WebPubSubChatDeleteMessage
            client.DeleteMessage(room.DefaultConversation, "<message-id>");
            #endregion
        }

        public async Task ManageMessagesAsync()
        {
            var client = new WebPubSubChatServiceClient(ConnectionString, "chat");
            WebPubSubChatRoom room = client.GetRoom("room1").Value;

            #region Snippet:WebPubSubChatManageMessagesAsync
            await foreach (WebPubSubChatMessage message in client.GetMessagesAsync(room.DefaultConversation))
            {
                Console.WriteLine($"{message.CreatedBy}: {message.Content.Text}");
            }

            await client.DeleteMessageAsync(room.DefaultConversation, "<message-id>");
            #endregion
        }
    }
}
