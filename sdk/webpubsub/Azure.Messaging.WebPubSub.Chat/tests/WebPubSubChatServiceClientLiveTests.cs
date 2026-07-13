// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    public class WebPubSubChatServiceClientLiveTests : RecordedTestBase<WebPubSubChatTestEnvironment>
    {
        private WebPubSubChatServiceClient _client;

        public WebPubSubChatServiceClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _client = new WebPubSubChatServiceClient(
                TestEnvironment.ConnectionString,
                "test_hub",
                InstrumentClientOptions(new WebPubSubChatServiceClientOptions()));
        }

        #region Roles

        [Test]
        public async Task CreateGetDeleteRole()
        {
            const string roleName = "user.e2e_create_get_delete";
            try
            {
                // Create
                WebPubSubChatRole created = await _client.CreateOrReplaceRoleAsync(roleName,
                    new WebPubSubChatRole(new[] { UserPermissions.CreateRoom }));
                Assert.That(created.Name, Is.EqualTo(roleName));

                // Get
                WebPubSubChatRole fetched = await _client.GetRoleAsync(roleName);
                Assert.That(fetched.Name, Is.EqualTo(roleName));
                Assert.That(fetched.Permissions, Contains.Item(UserPermissions.CreateRoom));
            }
            finally
            {
                await _client.DeleteRoleAsync(roleName);
            }
        }

        [Test]
        public async Task ListRoles()
        {
            const string userRoleName = "user.e2e_list_test";
            const string roomRoleName = "room.e2e_list_test";

            await _client.CreateOrReplaceRoleAsync(userRoleName,
                new WebPubSubChatRole(new[] { UserPermissions.CreateRoom }));
            await _client.CreateOrReplaceRoleAsync(roomRoleName,
                new WebPubSubChatRole(new[] { RoomPermissions.PublishMessage }));

            try
            {
                var roles = new List<string>();
                await foreach (WebPubSubChatRole role in _client.GetRolesAsync())
                {
                    roles.Add(role.Name);
                }

                Assert.That(roles, Does.Contain(userRoleName));
                Assert.That(roles, Does.Contain(roomRoleName));
            }
            finally
            {
                await _client.DeleteRoleAsync(userRoleName);
                await _client.DeleteRoleAsync(roomRoleName);
            }
        }

        [Test]
        public async Task ListRolesWithPagination()
        {
            // Ensure at least 2 roles exist
            const string role1 = "user.e2e_page1";
            const string role2 = "user.e2e_page2";

            await _client.CreateOrReplaceRoleAsync(role1, new WebPubSubChatRole(new[] { UserPermissions.CreateRoom }));
            await _client.CreateOrReplaceRoleAsync(role2, new WebPubSubChatRole(new[] { UserPermissions.CreateRoom }));

            try
            {
                var firstPage = new List<WebPubSubChatRole>();
                await foreach (WebPubSubChatRole role in _client.GetRolesAsync(maxPageSize: 1))
                {
                    firstPage.Add(role);
                    break; // Only take the first item
                }

                Assert.That(firstPage, Has.Count.EqualTo(1));
            }
            finally
            {
                await _client.DeleteRoleAsync(role1);
                await _client.DeleteRoleAsync(role2);
            }
        }

        #endregion

        #region Rooms

        [Test]
        public async Task CreateGetDeleteRoom()
        {
            const string roomId = "e2e-test-room";
            try
            {
                WebPubSubChatRoom created = await _client.CreateOrReplaceRoomAsync(roomId,
                    new WebPubSubChatRoom("Test Room"));
                Assert.That(created.Id, Is.EqualTo(roomId));
                Assert.That(created.Title, Is.EqualTo("Test Room"));

                WebPubSubChatRoom fetched = await _client.GetRoomAsync(roomId);
                Assert.That(fetched.Id, Is.EqualTo(roomId));
            }
            finally
            {
                await _client.DeleteRoomAsync(roomId);
            }
        }

        [Test]
        public async Task GetRoomConversationAndListMessages()
        {
            const string roomId = "e2e-conversation-room";
            try
            {
                WebPubSubChatRoom room = await _client.CreateOrReplaceRoomAsync(roomId,
                    new WebPubSubChatRoom("Conversation Test Room"));

                WebPubSubChatConversation conversation = await _client.GetConversationAsync(room.DefaultConversation);
                Assert.That(conversation.Id, Is.EqualTo(room.DefaultConversation));
                Assert.That(conversation.ParentRoom, Is.EqualTo(roomId));

                var messages = new List<WebPubSubChatMessage>();
                await foreach (WebPubSubChatMessage message in _client.GetMessagesAsync(room.DefaultConversation))
                {
                    messages.Add(message);
                }
                Assert.That(messages, Is.Not.Null);
            }
            finally
            {
                await _client.DeleteRoomAsync(roomId);
            }
        }

        [Test]
        public async Task NewRoomReturnsEmptyMessageAndMemberPages()
        {
            string roomId = $"e2e-empty-page-room-{Recording.GenerateId()}";
            try
            {
                WebPubSubChatRoom room = await _client.CreateOrReplaceRoomAsync(roomId,
                    new WebPubSubChatRoom("Empty Page Test Room"));

                var messages = new List<WebPubSubChatMessage>();
                await foreach (WebPubSubChatMessage message in _client.GetMessagesAsync(room.DefaultConversation))
                {
                    messages.Add(message);
                }
                Assert.That(messages, Is.Empty);

                var members = new List<WebPubSubChatRoomMember>();
                await foreach (WebPubSubChatRoomMember member in _client.GetRoomMembersAsync(roomId))
                {
                    members.Add(member);
                }
                Assert.That(members, Is.Empty);
            }
            finally
            {
                try
                { await _client.DeleteRoomAsync(roomId); }
                catch { }
            }
        }

        #endregion

        #region Room Members

        [Test]
        public async Task CreateListDeleteRoomMember()
        {
            const string roomId = "e2e-member-room";
            const string userId = "e2e-member-user";
            const string userRoleName = "user.e2e_member_role";
            const string roomRoleName = "room.e2e_member_role";

            try
            {
                await _client.CreateOrReplaceRoleAsync(userRoleName,
                    new WebPubSubChatRole(new[] { UserPermissions.CreateRoom }));
                await _client.CreateOrReplaceRoleAsync(roomRoleName,
                    new WebPubSubChatRole(new[] { RoomPermissions.PublishMessage }));
                await _client.CreateOrReplaceUserAsync(userId,
                    new WebPubSubHumanChatUser("TestMemberUser", userRoleName));
                await _client.CreateOrReplaceRoomAsync(roomId, new WebPubSubChatRoom("Member Test Room"));

                WebPubSubChatRoomMember created = await _client.CreateOrReplaceRoomMemberAsync(roomId, userId,
                    new WebPubSubChatRoomMember(roomRoleName));
                Assert.That(created.UserId, Is.EqualTo(userId));
                Assert.That(created.RoleName, Is.EqualTo(roomRoleName));

                var members = new List<WebPubSubChatRoomMember>();
                await foreach (WebPubSubChatRoomMember member in _client.GetRoomMembersAsync(roomId))
                {
                    members.Add(member);
                }
                Assert.That(members.Any(m => m.UserId == userId && m.RoleName == roomRoleName), Is.True);

                await _client.DeleteRoomMemberAsync(roomId, userId);
            }
            finally
            {
                try
                { await _client.DeleteRoomAsync(roomId); }
                catch { }
                try
                { await _client.DeleteUserAsync(userId); }
                catch { }
                try
                { await _client.DeleteRoleAsync(userRoleName); }
                catch { }
                try
                { await _client.DeleteRoleAsync(roomRoleName); }
                catch { }
            }
        }

        #endregion

        #region Users

        [Test]
        public async Task CreateGetDeleteUser()
        {
            const string userId = "e2e-test-user";
            const string roleName = "user.e2e_user_role";

            await _client.CreateOrReplaceRoleAsync(roleName,
                new WebPubSubChatRole(new[] { UserPermissions.CreateRoom }));

            try
            {
                WebPubSubChatUser created = await _client.CreateOrReplaceUserAsync(userId,
                    new WebPubSubHumanChatUser("TestUser", roleName));
                Assert.That(created.Id, Is.EqualTo(userId));
                Assert.That(created, Is.InstanceOf<WebPubSubHumanChatUser>());

                WebPubSubChatUser fetched = await _client.GetUserAsync(userId);
                Assert.That(fetched.Id, Is.EqualTo(userId));
            }
            finally
            {
                try
                { await _client.DeleteUserAsync(userId); }
                catch { }
                try
                { await _client.DeleteRoleAsync(roleName); }
                catch { }
            }
        }

        #endregion

        #region Client Access

        [Test]
        public async Task GetClientAccessUri()
        {
            const string userId = "e2e-access-user";
            const string roleName = "user.e2e_access_role";

            await _client.CreateOrReplaceRoleAsync(roleName,
                new WebPubSubChatRole(new[] { UserPermissions.CreateRoom }));
            await _client.CreateOrReplaceUserAsync(userId,
                new WebPubSubHumanChatUser("AccessUser", roleName));

            try
            {
                Uri uri = await _client.GetClientAccessUriAsync(
                    new GetClientAccessTokenOptions { UserId = userId });

                Assert.That(uri, Is.Not.Null);
                Assert.That(uri.ToString(), Does.Contain("access_token="));
            }
            finally
            {
                try
                { await _client.DeleteUserAsync(userId); }
                catch { }
                try
                { await _client.DeleteRoleAsync(roleName); }
                catch { }
            }
        }

        #endregion
    }
}
